using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Enums;
using static CompriaxSystem.Application.DTOs.TicketPaymentDataDto;

namespace CompriaxSystem.Application.Services
{
    public class TicketDataBuilder( IUnitOfWork unitOfWork, IBarcodeService barcodeService, IAfipService afipService) : ITicketDataBuilder
    {
        /// <summary>
        /// Construye el modelo de datos completo para un ticket físico, consolidando datos del comercio, cliente, impuestos y códigos QR/Barras.
        /// </summary>
        /// <param name="sale">Datos de la venta procesada.</param>
        /// <param name="documentNumber">Número de comprobante generado.</param>
        /// <param name="cashierName">Nombre del operador de caja.</param>
        /// <param name="paperSize">Tamaño de papel para la configuración de estilos.</param>
        /// <returns>Un objeto TicketDataDto listo para ser renderizado en PDF o impresión térmica.</returns>
        public async Task<TicketDataDto> BuildSaleTicketDataAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm)
        {
            var storeSettings = await unitOfWork.Store.GetSettingsAsync();

            decimal saleSubtotal = sale.SubTotal > 0 ? sale.SubTotal : sale.Items.Sum(x => x.Quantity * x.UnitPrice);
            decimal totalDiscountAmount = sale.DiscountAmount;
            decimal finalTotalAmount = sale.TotalAmount > 0 ? sale.TotalAmount : Math.Max(0, saleSubtotal - totalDiscountAmount);

            decimal taxRatePercentage = TaxConstants.STANDARD_VAT_RATE;
            decimal netTaxableAmount = Math.Round(finalTotalAmount / (1 + (taxRatePercentage / 100m)), 2);
            decimal taxAmount = finalTotalAmount - netTaxableAmount;

            int pointOfSaleNumber = sale.PointOfSale > 0 ? sale.PointOfSale : (storeSettings?.PointOfSale > 0 ? storeSettings.PointOfSale : TaxConstants.DEFAULT_POINT_OF_SALE);
            var (documentLetter, documentTypeCode) = ExtractDocumentLetterAndCode(sale.DocumentTypeName);

            byte[]? fiscalQrImageBytes = null;

            if (!string.IsNullOrWhiteSpace(sale.AfipQrUrl))
            {
                try
                {
                    fiscalQrImageBytes = afipService.GenerateQrImage(sale.AfipQrUrl, 130, 130); 
                } 
                catch 
                {
                    fiscalQrImageBytes = null; 
                }
            }

            byte[]? internalBarcodeImageBytes = null;

            if (storeSettings?.ShowBarcodeOnTicket ?? true)
            {
                try
                {
                    using var barcodeBitmap = barcodeService.GenerateBarcode(documentNumber, width: 280, height: 50);
                    using var barcodeMemoryStream = new MemoryStream();
                    
                    barcodeBitmap.Save(barcodeMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    internalBarcodeImageBytes = barcodeMemoryStream.ToArray();
                }
                catch 
                { 
                    internalBarcodeImageBytes = null;
                }
            }
            
            var ticketItems = (sale.Items ?? Enumerable.Empty<SaleItemDto>()).Select(i => new TicketItemDataDto
            {
                Quantity = i.Quantity,
                Description = i.ProductName,
                UnitPrice = i.UnitPrice,
                DiscountAmount = i.DiscountAmount,
                Total = i.SubTotal,
                PromotionTag = i.DiscountAmount > 0 ? "* Bonificación Promo" : null
            }).ToList();

            var ticketPayments = new List<TicketPaymentData>();

            if (!string.IsNullOrWhiteSpace(sale.PaymentMethodName))
            {
                ticketPayments.Add(new TicketPaymentData
                {
                    PaymentMethodName = sale.PaymentMethodName,
                    Amount = finalTotalAmount
                });
            }

            return new TicketDataDto
            {
                StoreName = storeSettings?.Name,
                LegalName = storeSettings?.Name,
                Cuit = storeSettings?.CUIT,
                Address = storeSettings?.Address,
                Phone = storeSettings?.Phone,
                Email = storeSettings?.Email,
                TaxConditionName = storeSettings?.TaxCondition?.Name,
                GrossIncomeNumber = storeSettings?.GrossIncomeNumber,
                ActivityStartDate = storeSettings?.ActivityStartDate,
                LogoBytes = storeSettings?.Logo,

                DocumentTypeName = sale.DocumentTypeName!,
                DocumentLetter = documentLetter,
                DocumentTypeCode = documentTypeCode,
                PointOfSale = pointOfSaleNumber,
                DocumentNumber = documentNumber,
                Date = sale.Date,

                CashierName = cashierName,
                ShiftId = null,
                PosNumber = pointOfSaleNumber,

                CustomerName = string.IsNullOrWhiteSpace(sale.CustomerName) ? TaxConstants.DEFAULT_TAX_CONDITION_NAME : sale.CustomerName,
                CustomerDoc = string.IsNullOrWhiteSpace(sale.CustomerDoc) ? TaxConstants.FINAL_CONSUMER_DOCUMENT_PLACEHOLDER : sale.CustomerDoc,
                CustomerTaxCondition = TaxConstants.DEFAULT_TAX_CONDITION_NAME,

                Items = ticketItems,
                SubTotal = saleSubtotal,
                TotalDiscounts = totalDiscountAmount,
                FinalTotal = finalTotalAmount,

                Payments = ticketPayments,
                PaymentReceived = sale.PaymentReceived,
                PaymentChange = sale.PaymentChange,

                TaxRate = taxRatePercentage,
                TaxAmount = taxAmount,
                NetTaxableAmount = netTaxableAmount,

                Cae = sale.Cae,
                CaeExpirationDate = sale.CaeExpirationDate,
                AfipQrUrl = sale.AfipQrUrl,
                FiscalQrImageBytes = fiscalQrImageBytes,
                InternalBarcodeBytes = internalBarcodeImageBytes,

                FooterMessage = storeSettings?.TicketFooterMessage,
                ShowLogo = storeSettings?.ShowLogoOnTicket ?? true,
                ShowBarcode = storeSettings?.ShowBarcodeOnTicket ?? true,
                PaperSize = paperSize
            };
        }

        private static (string Letter, string Code) ExtractDocumentLetterAndCode(string? documentTypeName)
        {
            if (string.IsNullOrWhiteSpace(documentTypeName))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_FACTURA_B);

            string type = documentTypeName.ToUpperInvariant();

            if (type.Contains("FACTURA A") && !type.Contains("TICKET"))
                return (VoucherLetterCodesConstants.LETTER_A, VoucherLetterCodesConstants.CODE_FACTURA_A);

            if (type.Contains("NOTA DE DÉBITO A") || type.Contains("NOTA DE DEBITO A"))
                return (VoucherLetterCodesConstants.LETTER_A, VoucherLetterCodesConstants.CODE_NOTA_DEBITO_A);

            if (type.Contains("NOTA DE CRÉDITO A") || type.Contains("NOTA DE CREDITO A"))
                return (VoucherLetterCodesConstants.LETTER_A, VoucherLetterCodesConstants.CODE_NOTA_CREDITO_A);

            if (type.Contains("RECIBO A"))
                return (VoucherLetterCodesConstants.LETTER_A, VoucherLetterCodesConstants.CODE_RECIBO_A);

            if (type.Contains("TICKET FACTURA A"))
                return (VoucherLetterCodesConstants.LETTER_A, VoucherLetterCodesConstants.CODE_TICKET_FACUTURA_A);

            //
            if (type.Contains("FACTURA B") && !type.Contains("TICKET"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_FACTURA_B);

            if (type.Contains("NOTA DE DÉBITO B") || type.Contains("NOTA DE DEBITO B"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_NOTA_DEBITO_B);

            if (type.Contains("NOTA DE CRÉDITO B") || type.Contains("NOTA DE CREDITO B"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_NOTA_CREDITO_B);

            if (type.Contains("RECIBO B"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_RECIBO_B);

            if (type.Contains("TICKET FACTURA B"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_TICKET_FACTURA_B);

            if (type.Contains("TICKET CONSUMIDOR FINAL") || type.Contains("CLIENTE CASUAL") || type.Contains("TICKET"))
                return (VoucherLetterCodesConstants.LETTER_B, VoucherLetterCodesConstants.CODE_TICKET_CONSUMIDOR_FINAL);

            //
            if (type.Contains("FACTURA C") && !type.Contains("TICKET"))
                return (VoucherLetterCodesConstants.LETTER_C, VoucherLetterCodesConstants.CODE_FACTURA_C);

            if (type.Contains("NOTA DE DÉBITO C") || type.Contains("NOTA DE DEBITO C"))
                return (VoucherLetterCodesConstants.LETTER_C, VoucherLetterCodesConstants.CODE_NOTA_DEBITO_C);

            if (type.Contains("NOTA DE CRÉDITO C") || type.Contains("NOTA DE CREDITO C"))
                return (VoucherLetterCodesConstants.LETTER_C, VoucherLetterCodesConstants.CODE_NOTA_CREDITO_C);

            if (type.Contains("RECIBO C"))
                return (VoucherLetterCodesConstants.LETTER_C, VoucherLetterCodesConstants.CODE_RECIBO_C);

            //
            if (type.Contains("FACTURA M"))
                return (VoucherLetterCodesConstants.LETTER_M, VoucherLetterCodesConstants.CODE_FACTURA_M);

            if (type.Contains("NOTA DE DÉBITO M") || type.Contains("NOTA DE DEBITO M"))
                return (VoucherLetterCodesConstants.LETTER_M, VoucherLetterCodesConstants.CODE_NOTA_DEBITO_M);

            if (type.Contains("NOTA DE CRÉDITO M") || type.Contains("NOTA DE CREDITO M"))
                return (VoucherLetterCodesConstants.LETTER_M, VoucherLetterCodesConstants.CODE_NOTA_CREDITO_M);

            //
            if (type.Contains("EXPORTACIÓN") || type.Contains("EXPORTACION"))
                return (VoucherLetterCodesConstants.LETTER_E, VoucherLetterCodesConstants.CODE_EXPORTACION_E);

            //
            if (type.Contains("REMITO R"))
                return (VoucherLetterCodesConstants.LETTER_R, VoucherLetterCodesConstants.CODE_REMITO_R);

            //
            if (type.Contains("REMITO X"))
                return (VoucherLetterCodesConstants.LETTER_X, VoucherLetterCodesConstants.NON_FISCAL_REMITO_X);

            //
            if (type.Contains("PRESUPUESTO"))
                return (VoucherLetterCodesConstants.LETTER_X, VoucherLetterCodesConstants.NON_FISCAL_PRESUPUESTO);

            return (VoucherLetterCodesConstants.LETTER_X, VoucherLetterCodesConstants.NON_FISCAL_COMPROBANTE_X);
        }
    }
}