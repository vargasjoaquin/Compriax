using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;
using static CompriaxSystem.Application.DTOs.TicketPaymentDataDto;

namespace CompriaxSystem.Application.Services
{
    public class TicketDataBuilder(
        IUnitOfWork unitOfWork,
        IBarcodeService barcodeService,
        IAfipService afipService) : ITicketDataBuilder
    {
        /// <summary>
        /// Construye el modelo de datos completo para un ticket físico, consolidando datos del comercio, cliente, impuestos y códigos QR/Barras.
        /// </summary>
        /// <param name="sale">Datos de la venta procesada.</param>
        /// <param name="documentNumber">Número de comprobante generado.</param>
        /// <param name="cashierName">Nombre del operador de caja.</param>
        /// <param name="paperSize">Tamaño de papel para la configuración de estilos.</param>
        /// <returns>Un objeto TicketDataDto listo para ser renderizado en PDF o impresión térmica.</returns>
        public async Task<TicketDataDto> BuildSaleTicketDataAsync(
            SaleDto sale,
            string documentNumber,
            string cashierName,
            ThermalPaperSize paperSize = ThermalPaperSize.Width80mm)
        {
            var store = await unitOfWork.Store.GetSettingsAsync();

            decimal subtotal = sale.SubTotal > 0 ? sale.SubTotal : sale.Items.Sum(x => x.Quantity * x.UnitPrice);
            decimal discount = sale.DiscountAmount;
            decimal totalFinal = sale.TotalAmount > 0 ? sale.TotalAmount : Math.Max(0, subtotal - discount);

            decimal taxRate = 21.00m;
            decimal netTaxable = Math.Round(totalFinal / (1 + (taxRate / 100m)), 2);
            decimal taxAmount = totalFinal - netTaxable;

            int pointOfSale = sale.PointOfSale > 0 ? sale.PointOfSale : (store?.PointOfSale > 0 ? store.PointOfSale : 1);
            var (documentLetter, documentTypeCode) = ExtractDocumentLetterAndCode(sale.DocumentTypeName);

            byte[]? qrBytes = null;
            if (!string.IsNullOrWhiteSpace(sale.AfipQrUrl))
            {
                try
                { 
                    qrBytes = afipService.GenerateQrImage(sale.AfipQrUrl, 130, 130); } catch { qrBytes = null; }
            }

            byte[]? barcodeBytes = null;

            if (store?.ShowBarcodeOnTicket ?? true)
            {
                try
                {
                    using var bmp = barcodeService.GenerateBarcode(documentNumber, width: 280, height: 50);
                    using var ms = new MemoryStream();
                    
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    barcodeBytes = ms.ToArray();
                }
                catch 
                { 
                    barcodeBytes = null;
                }
            }
            
            var items = (sale.Items ?? Enumerable.Empty<SaleItemDto>()).Select(i => new TicketItemDataDto
            {
                Quantity = i.Quantity,
                Description = i.ProductName,
                UnitPrice = i.UnitPrice,
                DiscountAmount = i.DiscountAmount,
                Total = i.SubTotal,
                PromotionTag = i.DiscountAmount > 0 ? "* Bonificación Promo" : null
            }).ToList();

            var payments = new List<TicketPaymentData>();

            if (!string.IsNullOrWhiteSpace(sale.PaymentMethodName))
            {
                payments.Add(new TicketPaymentData
                {
                    PaymentMethodName = sale.PaymentMethodName,
                    Amount = totalFinal
                });
            }

            return new TicketDataDto
            {
                StoreName = store?.Name,
                LegalName = store?.Name,
                Cuit = store?.CUIT,
                Address = store?.Address,
                Phone = store?.Phone,
                Email = store?.Email,
                TaxConditionName = store?.TaxCondition?.Name,
                GrossIncomeNumber = store?.GrossIncomeNumber,
                ActivityStartDate = store?.ActivityStartDate,
                LogoBytes = store?.Logo,

                DocumentTypeName = sale.DocumentTypeName!,
                DocumentLetter = documentLetter,
                DocumentTypeCode = documentTypeCode,
                PointOfSale = pointOfSale,
                DocumentNumber = documentNumber,
                Date = sale.Date,

                CashierName = cashierName,
                ShiftId = null,
                PosNumber = pointOfSale,

                CustomerName = string.IsNullOrWhiteSpace(sale.CustomerName) ? "Consumidor Final" : sale.CustomerName,
                CustomerDoc = string.IsNullOrWhiteSpace(sale.CustomerDoc) ? "S/D" : sale.CustomerDoc,
                CustomerTaxCondition = "Consumidor Final",

                Items = items,
                SubTotal = subtotal,
                TotalDiscounts = discount,
                FinalTotal = totalFinal,

                Payments = payments,
                PaymentReceived = sale.PaymentReceived,
                PaymentChange = sale.PaymentChange,

                TaxRate = taxRate,
                TaxAmount = taxAmount,
                NetTaxableAmount = netTaxable,

                Cae = sale.Cae,
                CaeExpirationDate = sale.CaeExpirationDate,
                AfipQrUrl = sale.AfipQrUrl,
                FiscalQrImageBytes = qrBytes,
                InternalBarcodeBytes = barcodeBytes,

                FooterMessage = store?.TicketFooterMessage,
                ShowLogo = store?.ShowLogoOnTicket ?? true,
                ShowBarcode = store?.ShowBarcodeOnTicket ?? true,
                PaperSize = paperSize
            };
        }

        private static (string Letter, string Code) ExtractDocumentLetterAndCode(string? documentTypeName)
        {
            if (string.IsNullOrWhiteSpace(documentTypeName))
                return ("B", "COD. 006");

            string type = documentTypeName.ToUpperInvariant();

            // 1. COMPROBANTES CLASE 'A' (Responsable Inscripto a Responsable Inscripto)
            if (type.Contains("FACTURA A") && !type.Contains("TICKET")) 
                return ("A", "COD. 001");
            
            if (type.Contains("NOTA DE DÉBITO A") || type.Contains("NOTA DE DEBITO A")) 
                return ("A", "COD. 002");
            
            if (type.Contains("NOTA DE CRÉDITO A") || type.Contains("NOTA DE CREDITO A"))
                return ("A", "COD. 003");
            
            if (type.Contains("RECIBO A"))
                return ("A", "COD. 004");
            
            if (type.Contains("TICKET FACTURA A")) 
                return ("A", "COD. 081");

            // 2. COMPROBANTES CLASE 'B' (A Consumidor Final / Exento)
            if (type.Contains("FACTURA B") && !type.Contains("TICKET"))
                return ("B", "COD. 006");
            
            if (type.Contains("NOTA DE DÉBITO B") || type.Contains("NOTA DE DEBITO B"))
                return ("B", "COD. 007");
            
            if (type.Contains("NOTA DE CRÉDITO B") || type.Contains("NOTA DE CREDITO B")) 
                return ("B", "COD. 008");
            
            if (type.Contains("RECIBO B")) 
                return ("B", "COD. 009");
            
            if (type.Contains("TICKET FACTURA B")) 
                return ("B", "COD. 082");
            
            if (type.Contains("TICKET CONSUMIDOR FINAL") || type.Contains("CLIENTE CASUAL") || type.Contains("TICKET"))
                return ("B", "COD. 083");

            // 3. COMPROBANTES CLASE 'C' (Monotributo)
            if (type.Contains("FACTURA C") && !type.Contains("TICKET")) 
                return ("C", "COD. 011");
            
            if (type.Contains("NOTA DE DÉBITO C") || type.Contains("NOTA DE DEBITO C")) 
                return ("C", "COD. 012");
            
            if (type.Contains("NOTA DE CRÉDITO C") || type.Contains("NOTA DE CREDITO C"))
                return ("C", "COD. 013");
            
            if (type.Contains("RECIBO C"))
                return ("C", "COD. 015");

            // 4. COMPROBANTES CLASE 'M' Y 'E'
            if (type.Contains("FACTURA M")) 
                return ("M", "COD. 051");
            
            if (type.Contains("NOTA DE DÉBITO M") || type.Contains("NOTA DE DEBITO M"))
                return ("M", "COD. 052");
            
            if (type.Contains("NOTA DE CRÉDITO M") || type.Contains("NOTA DE CREDITO M")) 
                return ("M", "COD. 053");
            
            if (type.Contains("EXPORTACIÓN") || type.Contains("EXPORTACION"))
                return ("E", "COD. 019");

            // 5. REMITOS OFICIALES 'R'
            if (type.Contains("REMITO R")) 
                return ("R", "COD. 091");

            // 6. COMPROBANTES NO FISCALES CLASE 'X' (Remito X, Presupuestos, Comprobante X)
            if (type.Contains("REMITO X")) 
                return ("X", "REMITO X (NO FISCAL)");
            
            if (type.Contains("PRESUPUESTO")) 
                return ("X", "PRESUPUESTO (NO FISCAL)");

            return ("X", "COMPROBANTE X (NO FISCAL)");
        }
    }
}