using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Services
{
    public class TicketTemplateService : ITicketTemplateService
    {
        public TicketTemplateService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        /// <summary>
        /// Genera un documento PDF optimizado para impresoras térmicas basado en una plantilla.
        /// </summary>
        /// <param name="ticketData">Datos del ticket a renderizar.</param>
        /// <returns>Arreglo de bytes del PDF listo para impresión.</returns>
        public byte[] RenderThermalTicketPdf(TicketDataDto ticketData)
        {
            float paperWidthMillimetres = ticketData.PaperSize == ThermalPaperSize.Width58mm ? 58f : 80f;
            float baseFontSize = ticketData.PaperSize == ThermalPaperSize.Width58mm ? 7.2f : 8.5f;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.ContinuousSize(paperWidthMillimetres, Unit.Millimetre);
                    page.Margin(2.5f, Unit.Millimetre);
                    page.DefaultTextStyle(x => x.FontSize(baseFontSize).FontFamily(Fonts.Consolas));

                    page.Content().Column(column =>
                    {
                        // ==========================================
                        // 1. LOGO COMERCIAL
                        // ==========================================
                        if (ticketData.ShowLogo && ticketData.LogoBytes != null && ticketData.LogoBytes.Length > 0)
                        {
                            column.Item().AlignCenter().MaxHeight(38).MaxWidth(110).Image(ticketData.LogoBytes);
                            column.Item().PaddingBottom(2);
                        }

                        // ==========================================
                        // 2. ENCABEZADO DEL COMERCIO
                        // ==========================================
                        column.Item().AlignCenter().Text(ticketData.StoreName.ToUpper()).FontSize(baseFontSize + 3.5f).ExtraBold();

                        if (!string.IsNullOrWhiteSpace(ticketData.Cuit))
                            column.Item().AlignCenter().Text($"CUIT: {ticketData.Cuit}").FontSize(baseFontSize - 0.5f);

                        if (!string.IsNullOrWhiteSpace(ticketData.TaxConditionName))
                            column.Item().AlignCenter().Text(ticketData.TaxConditionName).FontSize(baseFontSize - 1f);

                        if (!string.IsNullOrWhiteSpace(ticketData.GrossIncomeNumber))
                            column.Item().AlignCenter().Text($"Ing. Brutos: {ticketData.GrossIncomeNumber}").FontSize(baseFontSize - 1f);

                        if (!string.IsNullOrWhiteSpace(ticketData.Address))
                            column.Item().AlignCenter().Text(ticketData.Address).FontSize(baseFontSize - 0.5f);

                        if (!string.IsNullOrWhiteSpace(ticketData.Phone))
                            column.Item().AlignCenter().Text($"Tel: {ticketData.Phone}").FontSize(baseFontSize - 0.5f);

                        column.Item().PaddingVertical(2).Text(DottedLine(ticketData.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 3. RECUADRO DE COMPROBANTE FISCAL
                        // ==========================================
                        bool isNonFiscalDocument = ticketData.DocumentLetter == "X" || ticketData.DocumentTypeCode.Contains("NO FISCAL");

                        column.Item().Row(row =>
                        {
                            // Cuadrado de la Letra
                            row.ConstantItem(28).Height(28).Border(1).BorderColor(Colors.Black).AlignCenter().AlignMiddle()
                                .Text(ticketData.DocumentLetter).FontSize(16).ExtraBold();

                            row.ConstantItem(6); // Espaciador

                            row.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text($"{ticketData.DocumentTypeName.ToUpper()} ({ticketData.DocumentTypeCode})").Bold();
                                documentColumn.Item().Text($"P.V.: {ticketData.PointOfSale:D4}  NRO: {ticketData.DocumentNumber}").Bold();
                                documentColumn.Item().Text($"FECHA: {ticketData.Date:dd/MM/yyyy}  HORA: {ticketData.Date:HH:mm:ss}");
                            });
                        });

                        if (isNonFiscalDocument)
                        {
                            column.Item().PaddingTop(3).Border(0.5f).BorderColor(Colors.Black).Padding(2).AlignCenter()
                                .Text("--- DOCUMENTO NO VÁLIDO COMO FACTURA ---").FontSize(baseFontSize - 1.5f).Bold();
                        }

                        // ==========================================
                        // 4. DATOS DEL CLIENTE
                        // ==========================================
                        string clientName = string.IsNullOrWhiteSpace(ticketData.CustomerName) ? "CONSUMIDOR FINAL" : ticketData.CustomerName.ToUpper();
                        string customerDocument = string.IsNullOrWhiteSpace(ticketData.CustomerDoc) ? "S/D" : ticketData.CustomerDoc;
                        string customerTaxCondition = string.IsNullOrWhiteSpace(ticketData.CustomerTaxCondition) ? "Consumidor Final" : ticketData.CustomerTaxCondition;

                        column.Item().Text($"CLIENTE: {clientName}");
                        column.Item().Text($"DOC/CUIT: {customerDocument}  ({customerTaxCondition})");

                        column.Item().PaddingVertical(2).Text(DottedLine(ticketData.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 5. DETALLE DE ARTÍCULOS (Multilínea)
                        // ==========================================
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(22); // Cantidad
                                columns.RelativeColumn(3);  // Descripción
                                columns.RelativeColumn(2);  // Subtotal
                            });

                            table.Header(h =>
                            {
                                h.Cell().Element(HeaderStyle).Text("CANT");
                                h.Cell().Element(HeaderStyle).Text("DESCRIPCIÓN");
                                h.Cell().Element(HeaderStyle).AlignRight().Text("TOTAL");

                                static IContainer HeaderStyle(IContainer documentColumn) =>
                                    documentColumn.BorderBottom(0.5f).BorderColor(Colors.Black).PaddingBottom(2).DefaultTextStyle(x => x.Bold());
                            });

                            foreach (var ticketItem in ticketData.Items)
                            {
                                table.Cell().PaddingVertical(1).Text(ticketItem.Quantity.ToString());
                                table.Cell().PaddingVertical(1).Text(ticketItem.Description);
                                table.Cell().PaddingVertical(1).AlignRight().Text((ticketItem.Quantity * ticketItem.UnitPrice).ToString("C2"));

                                // Si tiene descuento o promoción bonificada
                                if (ticketItem.DiscountAmount > 0)
                                {
                                    table.Cell().Text(string.Empty);
                                    table.Cell().Text(ticketItem.PromotionTag ?? " * Ahorro Promo").FontSize(baseFontSize - 1.5f).Italic();
                                    table.Cell().AlignRight().Text($"-{ticketItem.DiscountAmount:C2}").FontSize(baseFontSize - 1.5f);
                                }
                            }
                        });

                        column.Item().PaddingVertical(2).Text(DottedLine(ticketData.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 6. TOTALES Y CARTEL DE AHORRO
                        // ==========================================
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text("SUBTOTAL:");
                            row.RelativeItem().AlignRight().Text(ticketData.SubTotal.ToString("C2"));
                        });

                        if (ticketData.TotalDiscounts > 0)
                        {
                            column.Item().PaddingVertical(2).Border(0.5f).BorderColor(Colors.Grey.Darken1).Background(Colors.Grey.Lighten4).Padding(2).Row(row =>
                            {
                                row.RelativeItem().Text("★ USTED AHORRÓ HOY:").Bold();
                                row.RelativeItem().AlignRight().Text($"-{ticketData.TotalDiscounts:C2}").Bold();
                            });
                        }

                        column.Item().PaddingTop(2).Row(row =>
                        {
                            row.RelativeItem().Text("TOTAL A PAGAR:").FontSize(baseFontSize + 2.5f).ExtraBold();
                            row.RelativeItem().AlignRight().Text(ticketData.FinalTotal.ToString("C2")).FontSize(baseFontSize + 2.5f).ExtraBold();
                        });

                        column.Item().PaddingVertical(2).Text(DottedLine(ticketData.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 7. MEDIOS DE PAGO UTILIZADOS
                        // ==========================================
                        column.Item().Text("MEDIOS DE PAGO:").Bold().FontSize(baseFontSize - 0.5f);
                        
                        foreach (var payment in ticketData.Payments)
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text($" • {payment.PaymentMethodName}");
                                row.RelativeItem().AlignRight().Text(payment.Amount.ToString("C2"));
                            });
                        }

                        if (ticketData.PaymentReceived > 0)
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text("PAGO RECIBIDO:");
                                row.RelativeItem().AlignRight().Text(ticketData.PaymentReceived.ToString("C2"));
                            });
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text("SU VUELTO:");
                                row.RelativeItem().AlignRight().Text(ticketData.PaymentChange.ToString("C2")).Bold();
                            });
                        }

                        // ==========================================
                        // 8. DISCRIMINACIÓN DE IMPUESTOS (IVA)
                        // ==========================================
                        column.Item().PaddingTop(2).Row(row =>
                        {
                            row.RelativeItem().Text($"IVA Discriminado ({ticketData.TaxRate:0.#}%):").FontSize(baseFontSize - 1f);
                            row.RelativeItem().AlignRight().Text(ticketData.TaxAmount.ToString("C2")).FontSize(baseFontSize - 1f);
                        });

                        column.Item().PaddingVertical(2).Text(DottedLine(ticketData.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 9. INFORMACIÓN FISCAL OFICIAL (CAE / QR AFIP-ARCA)
                        // ==========================================
                        if (!string.IsNullOrWhiteSpace(ticketData.Cae))
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text($"CAE: {ticketData.Cae}").Bold();
                                row.RelativeItem().AlignRight().Text($"VTO: {ticketData.CaeExpirationDate:dd/MM/yyyy}").Bold();
                            });
                        }

                        if (ticketData.FiscalQrImageBytes != null)
                        {
                            float fiscalQrImageSize = ticketData.PaperSize == ThermalPaperSize.Width58mm ? 65f : 80f;
                            
                            column.Item().PaddingTop(3).AlignCenter().MaxHeight(fiscalQrImageSize).MaxWidth(fiscalQrImageSize).Image(ticketData.FiscalQrImageBytes);
                            column.Item().AlignCenter().Text("Comprobante Autorizado por AFIP / ARCA").FontSize(baseFontSize - 1.5f).Bold();
                        }

                        // ==========================================
                        // 10. CÓDIGO DE BARRAS INTERNO Y PIE
                        // ==========================================
                        if (ticketData.ShowBarcode && ticketData.InternalBarcodeBytes != null)
                        {
                            column.Item().PaddingTop(3).AlignCenter().MaxHeight(25).MaxWidth(130).Image(ticketData.InternalBarcodeBytes);
                            column.Item().AlignCenter().Text(ticketData.DocumentNumber).FontSize(baseFontSize - 1.5f);
                        }

                        column.Item().PaddingTop(3).AlignCenter().Text("¡GRACIAS POR SU COMPRA!").FontSize(baseFontSize).Bold();

                        if (!string.IsNullOrWhiteSpace(ticketData.FooterMessage))
                        {
                            column.Item().AlignCenter().Text(ticketData.FooterMessage).FontSize(baseFontSize - 1.5f).Italic();
                        }

                        // Separador de corte físico de papel
                        column.Item().PaddingTop(4).AlignCenter().Text(". . . . . . . . . . . . . . . . . . . . .").FontColor(Colors.Grey.Lighten1);
                    });
                });
            }).GeneratePdf();
        }

        /// <summary>
        /// Genera una línea punteada adaptada al ancho del papel térmico.
        /// </summary>
        /// <param name="paperSize">Tamaño del papel térmico utilizado para el ticket.</param>
        /// <returns>Cadena de caracteres que representa una línea punteada.</returns>
        private static string DottedLine(ThermalPaperSize paperSize)
        {
            return paperSize == ThermalPaperSize.Width58mm
                ? "- - - - - - - - - - - - - - - -"
                : "- - - - - - - - - - - - - - - - - - - - - - - -";
        }
    }
}