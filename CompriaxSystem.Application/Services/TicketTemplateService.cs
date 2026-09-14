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
        /// <param name="data">Datos del ticket a renderizar.</param>
        /// <returns>Arreglo de bytes del PDF listo para impresión.</returns>
        public byte[] RenderThermalTicketPdf(TicketDataDto data)
        {
            float widthMm = data.PaperSize == ThermalPaperSize.Width58mm ? 58f : 80f;
            float baseFontSize = data.PaperSize == ThermalPaperSize.Width58mm ? 7.2f : 8.5f;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.ContinuousSize(widthMm, Unit.Millimetre);
                    page.Margin(2.5f, Unit.Millimetre);
                    page.DefaultTextStyle(x => x.FontSize(baseFontSize).FontFamily(Fonts.Consolas));

                    page.Content().Column(col =>
                    {
                        // ==========================================
                        // 1. LOGO COMERCIAL
                        // ==========================================
                        if (data.ShowLogo && data.LogoBytes != null && data.LogoBytes.Length > 0)
                        {
                            col.Item().AlignCenter().MaxHeight(38).MaxWidth(110).Image(data.LogoBytes);
                            col.Item().PaddingBottom(2);
                        }

                        // ==========================================
                        // 2. ENCABEZADO DEL COMERCIO
                        // ==========================================
                        col.Item().AlignCenter().Text(data.StoreName.ToUpper()).FontSize(baseFontSize + 3.5f).ExtraBold();

                        if (!string.IsNullOrWhiteSpace(data.Cuit))
                            col.Item().AlignCenter().Text($"CUIT: {data.Cuit}").FontSize(baseFontSize - 0.5f);

                        if (!string.IsNullOrWhiteSpace(data.TaxConditionName))
                            col.Item().AlignCenter().Text(data.TaxConditionName).FontSize(baseFontSize - 1f);

                        if (!string.IsNullOrWhiteSpace(data.GrossIncomeNumber))
                            col.Item().AlignCenter().Text($"Ing. Brutos: {data.GrossIncomeNumber}").FontSize(baseFontSize - 1f);

                        if (!string.IsNullOrWhiteSpace(data.Address))
                            col.Item().AlignCenter().Text(data.Address).FontSize(baseFontSize - 0.5f);

                        if (!string.IsNullOrWhiteSpace(data.Phone))
                            col.Item().AlignCenter().Text($"Tel: {data.Phone}").FontSize(baseFontSize - 0.5f);

                        col.Item().PaddingVertical(2).Text(DottedLine(data.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 3. RECUADRO DE COMPROBANTE FISCAL
                        // ==========================================
                        bool isNonFiscal = data.DocumentLetter == "X" || data.DocumentTypeCode.Contains("NO FISCAL");

                        col.Item().Row(r =>
                        {
                            // Cuadrado de la Letra
                            r.ConstantItem(28).Height(28).Border(1).BorderColor(Colors.Black).AlignCenter().AlignMiddle()
                                .Text(data.DocumentLetter).FontSize(16).ExtraBold();

                            r.ConstantItem(6); // Espaciador

                            r.RelativeItem().Column(c =>
                            {
                                c.Item().Text($"{data.DocumentTypeName.ToUpper()} ({data.DocumentTypeCode})").Bold();
                                c.Item().Text($"P.V.: {data.PointOfSale:D4}  NRO: {data.DocumentNumber}").Bold();
                                c.Item().Text($"FECHA: {data.Date:dd/MM/yyyy}  HORA: {data.Date:HH:mm:ss}");
                            });
                        });

                        if (isNonFiscal)
                        {
                            col.Item().PaddingTop(3).Border(0.5f).BorderColor(Colors.Black).Padding(2).AlignCenter()
                                .Text("--- DOCUMENTO NO VÁLIDO COMO FACTURA ---").FontSize(baseFontSize - 1.5f).Bold();
                        }

                        // ==========================================
                        // 4. DATOS DEL CLIENTE
                        // ==========================================
                        string clientName = string.IsNullOrWhiteSpace(data.CustomerName) ? "CONSUMIDOR FINAL" : data.CustomerName.ToUpper();
                        string clientDoc = string.IsNullOrWhiteSpace(data.CustomerDoc) ? "S/D" : data.CustomerDoc;
                        string clientTax = string.IsNullOrWhiteSpace(data.CustomerTaxCondition) ? "Consumidor Final" : data.CustomerTaxCondition;

                        col.Item().Text($"CLIENTE: {clientName}");
                        col.Item().Text($"DOC/CUIT: {clientDoc}  ({clientTax})");

                        col.Item().PaddingVertical(2).Text(DottedLine(data.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 5. DETALLE DE ARTÍCULOS (Multilínea)
                        // ==========================================
                        col.Item().Table(table =>
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

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.BorderBottom(0.5f).BorderColor(Colors.Black).PaddingBottom(2).DefaultTextStyle(x => x.Bold());
                            });

                            foreach (var item in data.Items)
                            {
                                table.Cell().PaddingVertical(1).Text(item.Quantity.ToString());
                                table.Cell().PaddingVertical(1).Text(item.Description);
                                table.Cell().PaddingVertical(1).AlignRight().Text((item.Quantity * item.UnitPrice).ToString("C2"));

                                // Si tiene descuento o promoción bonificada
                                if (item.DiscountAmount > 0)
                                {
                                    table.Cell().Text(string.Empty);
                                    table.Cell().Text(item.PromotionTag ?? " * Ahorro Promo").FontSize(baseFontSize - 1.5f).Italic();
                                    table.Cell().AlignRight().Text($"-{item.DiscountAmount:C2}").FontSize(baseFontSize - 1.5f);
                                }
                            }
                        });

                        col.Item().PaddingVertical(2).Text(DottedLine(data.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 6. TOTALES Y CARTEL DE AHORRO
                        // ==========================================
                        col.Item().Row(r =>
                        {
                            r.RelativeItem().Text("SUBTOTAL:");
                            r.RelativeItem().AlignRight().Text(data.SubTotal.ToString("C2"));
                        });

                        if (data.TotalDiscounts > 0)
                        {
                            col.Item().PaddingVertical(2).Border(0.5f).BorderColor(Colors.Grey.Darken1).Background(Colors.Grey.Lighten4).Padding(2).Row(r =>
                            {
                                r.RelativeItem().Text("★ USTED AHORRÓ HOY:").Bold();
                                r.RelativeItem().AlignRight().Text($"-{data.TotalDiscounts:C2}").Bold();
                            });
                        }

                        col.Item().PaddingTop(2).Row(r =>
                        {
                            r.RelativeItem().Text("TOTAL A PAGAR:").FontSize(baseFontSize + 2.5f).ExtraBold();
                            r.RelativeItem().AlignRight().Text(data.FinalTotal.ToString("C2")).FontSize(baseFontSize + 2.5f).ExtraBold();
                        });

                        col.Item().PaddingVertical(2).Text(DottedLine(data.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 7. MEDIOS DE PAGO UTILIZADOS
                        // ==========================================
                        col.Item().Text("MEDIOS DE PAGO:").Bold().FontSize(baseFontSize - 0.5f);
                        foreach (var pay in data.Payments)
                        {
                            col.Item().Row(r =>
                            {
                                r.RelativeItem().Text($" • {pay.PaymentMethodName}");
                                r.RelativeItem().AlignRight().Text(pay.Amount.ToString("C2"));
                            });
                        }

                        if (data.PaymentReceived > 0)
                        {
                            col.Item().Row(r =>
                            {
                                r.RelativeItem().Text("PAGO RECIBIDO:");
                                r.RelativeItem().AlignRight().Text(data.PaymentReceived.ToString("C2"));
                            });
                            col.Item().Row(r =>
                            {
                                r.RelativeItem().Text("SU VUELTO:");
                                r.RelativeItem().AlignRight().Text(data.PaymentChange.ToString("C2")).Bold();
                            });
                        }

                        // ==========================================
                        // 8. DISCRIMINACIÓN DE IMPUESTOS (IVA)
                        // ==========================================
                        col.Item().PaddingTop(2).Row(r =>
                        {
                            r.RelativeItem().Text($"IVA Discriminado ({data.TaxRate:0.#}%):").FontSize(baseFontSize - 1f);
                            r.RelativeItem().AlignRight().Text(data.TaxAmount.ToString("C2")).FontSize(baseFontSize - 1f);
                        });

                        col.Item().PaddingVertical(2).Text(DottedLine(data.PaperSize)).FontColor(Colors.Grey.Darken1);

                        // ==========================================
                        // 9. INFORMACIÓN FISCAL OFICIAL (CAE / QR AFIP-ARCA)
                        // ==========================================
                        if (!string.IsNullOrWhiteSpace(data.Cae))
                        {
                            col.Item().Row(r =>
                            {
                                r.RelativeItem().Text($"CAE: {data.Cae}").Bold();
                                r.RelativeItem().AlignRight().Text($"VTO: {data.CaeExpirationDate:dd/MM/yyyy}").Bold();
                            });
                        }

                        if (data.FiscalQrImageBytes != null)
                        {
                            float qrSize = data.PaperSize == ThermalPaperSize.Width58mm ? 65f : 80f;
                            col.Item().PaddingTop(3).AlignCenter().MaxHeight(qrSize).MaxWidth(qrSize).Image(data.FiscalQrImageBytes);
                            col.Item().AlignCenter().Text("Comprobante Autorizado por AFIP / ARCA").FontSize(baseFontSize - 1.5f).Bold();
                        }

                        // ==========================================
                        // 10. CÓDIGO DE BARRAS INTERNO Y PIE
                        // ==========================================
                        if (data.ShowBarcode && data.InternalBarcodeBytes != null)
                        {
                            col.Item().PaddingTop(3).AlignCenter().MaxHeight(25).MaxWidth(130).Image(data.InternalBarcodeBytes);
                            col.Item().AlignCenter().Text(data.DocumentNumber).FontSize(baseFontSize - 1.5f);
                        }

                        col.Item().PaddingTop(3).AlignCenter().Text("¡GRACIAS POR SU COMPRA!").FontSize(baseFontSize).Bold();

                        if (!string.IsNullOrWhiteSpace(data.FooterMessage))
                        {
                            col.Item().AlignCenter().Text(data.FooterMessage).FontSize(baseFontSize - 1.5f).Italic();
                        }

                        // Separador de corte físico de papel
                        col.Item().PaddingTop(4).AlignCenter().Text(". . . . . . . . . . . . . . . . . . . . .").FontColor(Colors.Grey.Lighten1);
                    });
                });
            }).GeneratePdf();
        }

        private static string DottedLine(ThermalPaperSize size)
        {
            return size == ThermalPaperSize.Width58mm
                ? "- - - - - - - - - - - - - - - -"
                : "- - - - - - - - - - - - - - - - - - - - - - - -";
        }
    }
}