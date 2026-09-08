using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Infrastructure.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBarcodeService _barcodeService;
        private readonly IAfipService _afipService;
        private readonly ITicketDataBuilder _ticketDataBuilder;
        private readonly ITicketTemplateService _ticketTemplateService;

        public DocumentService(IUnitOfWork unitOfWork, IBarcodeService barcodeService, IAfipService afipService, ITicketDataBuilder ticketDataBuilder,
            ITicketTemplateService ticketTemplateService)
        {
            _unitOfWork = unitOfWork;
            _barcodeService = barcodeService;
            _afipService = afipService;
            _ticketDataBuilder = ticketDataBuilder;
            _ticketTemplateService = ticketTemplateService;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        /// <summary>
        /// Genera el ticket de venta en formato PDF diseñado específicamente para impresoras térmicas.
        /// </summary>
        /// <param name="sale">Datos de la venta.</param>
        /// <param name="docNumber">Número de comprobante.</param>
        /// <param name="cashierName">Nombre del cajero operador.</param>
        /// <param name="paperSize">Tamaño del papel térmico (58mm o 80mm).</param>
        /// <returns>Arreglo de bytes del PDF generado.</returns>
        public async Task<byte[]> GenerateThermalTicketReceiptAsync(SaleDto sale, string docNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm)
        {
            var ticketData = await _ticketDataBuilder.BuildSaleTicketDataAsync(sale, docNumber, cashierName, paperSize);
            return _ticketTemplateService.RenderThermalTicketPdf(ticketData);
        }

        // ================= Métodos A4 y Reportes existentes =================
        public async Task<byte[]> GenerateSaleReceiptAsync(SaleDto sale, string docNumber, string cashierName)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();

            decimal subtotal = sale.Items?.Sum(x => x.SubTotal) ?? 0;
            decimal taxRate = 21;
            decimal taxAmount = subtotal * (taxRate / 100);
            decimal totalFinal = subtotal + taxAmount;

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4);
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(75).Height(60).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(store?.Name ?? "Supermercado").FontSize(18).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Spacing(2);
                                col.Item().Text(store?.Address ?? "Dirección Comercial");
                                col.Item().Text($"Teléfono: {store?.Phone ?? "S/D"}");
                                col.Item().Text($"Email: {store?.Email ?? "S/D"}");
                            });

                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text("COMPROBANTE").FontSize(22).Thin();
                                col.Spacing(4);
                                col.Item().Text($"FECHA: {sale.Date:dd/MM/yyyy HH:mm}").SemiBold();
                                col.Item().Text($"N.°: {docNumber}").SemiBold();
                                col.Item().Text($"CUIT: {store?.CUIT ?? "S/D"}").SemiBold();
                            });
                        });

                        page.Content().PaddingVertical(15).Column(col =>
                        {
                            col.Item().Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().BorderBottom(1).PaddingBottom(2).Text("Facturar a:").Bold();
                                    c.Item().PaddingTop(3).Text(sale.CustomerName);
                                    c.Item().Text($"DNI/CUIT: {sale.CustomerDoc}");
                                });
                            });

                            col.Spacing(15);

                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(70);
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Element(HeaderStyle).Text("CANTIDAD");
                                    h.Cell().Element(HeaderStyle).Text("DESCRIPCIÓN");
                                    h.Cell().Element(HeaderStyle).Text("PRECIO UNIT.");
                                    h.Cell().Element(HeaderStyle).Text("SUBTOTAL");
                                    static IContainer HeaderStyle(IContainer c) => c.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5).DefaultTextStyle(x => x.Bold());
                                });

                                foreach (var item in sale.Items ?? Enumerable.Empty<SaleItemDto>())
                                {
                                    table.Cell().Border(0.5f).AlignCenter().Text(item.Quantity.ToString());
                                    table.Cell().Border(0.5f).PaddingLeft(5).Text(item.ProductName);
                                    table.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(item.UnitPrice.ToString("C2"));
                                    table.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(item.SubTotal.ToString("C2"));
                                }
                            });

                            col.Item().AlignRight().PaddingTop(10).Column(totalsCol =>
                            {
                                AddTotalRow(totalsCol, "SUBTOTAL", subtotal);
                                AddTotalRow(totalsCol, $"IVA ({taxRate}%)", taxAmount);
                                AddTotalRow(totalsCol, "TOTAL", totalFinal, isBold: true);
                            });
                        });

                        page.Footer().AlignCenter().Column(f =>
                        {
                            f.Item().Text("¡GRACIAS POR SU COMPRA!").FontSize(12).ExtraBold();
                            f.Item().Text($"Atendido por: {cashierName}").FontSize(8).Italic();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte detallado de inventario en formato A4 con indicadores de stock crítico.
        /// </summary>
        /// <param name="products">Colección de productos a incluir.</param>
        /// <returns>Bytes del reporte PDF de inventario.</returns>
        public async Task<byte[]> GenerateInventoryReportAsync(IEnumerable<ProductDto> products)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();
            string compName = store?.Name ?? "Supermercado";
            string storeAddr = store?.Address ?? "Reporte del Sistema";

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4);
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(compName).FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Item().Text(storeAddr);
                                col.Item().Text("Módulo de Gestión de Inventario");
                            });

                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text("REPORTE DE PRODUCTOS").FontSize(16).Thin();
                                col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                            });
                        });

                        page.Content().PaddingVertical(15).Column(col =>
                        {
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(4);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(1.5f);
                                    columns.RelativeColumn(2);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(HeaderStyle).Text("CÓDIGO");
                                    header.Cell().Element(HeaderStyle).Text("PRODUCTO");
                                    header.Cell().Element(HeaderStyle).Text("CATEGORÍA");
                                    header.Cell().Element(HeaderStyle).Text("STOCK");
                                    header.Cell().Element(HeaderStyle).Text("PRECIO VTA.");

                                    static IContainer HeaderStyle(IContainer c) =>
                                        c.DefaultTextStyle(x => x.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                                });

                                foreach (var p in products)
                                {
                                    table.Cell().Element(DataStyle).AlignCenter().Text(p.Barcode);
                                    table.Cell().Element(DataStyle).PaddingLeft(4).Text(p.Name);
                                    table.Cell().Element(DataStyle).AlignCenter().Text(p.CategoryName ?? "-");

                                    bool isCritical = p.CurrentStock <= p.MinimumStock;
                                    table.Cell().Element(DataStyle).AlignCenter().Text(p.CurrentStock.ToString())
                                         .FontColor(isCritical ? Colors.Red.Medium : Colors.Black);

                                    table.Cell().Element(DataStyle).AlignRight().PaddingRight(4).Text(p.SellPrice.ToString("C2"));

                                    static IContainer DataStyle(IContainer c) => c.Border(0.5f).PaddingVertical(3);
                                }
                            });

                            decimal totalCapital = products.Sum(x => x.CurrentStock * x.SellPrice);

                            col.Item().PaddingTop(15).AlignRight().Background(Colors.Grey.Lighten4).Padding(8).Row(row =>
                            {
                                row.RelativeItem().AlignRight().Text("VALOR TOTAL ESTIMADO DE INVENTARIO: ").Bold();
                                row.ConstantItem(150).AlignRight().Text(totalCapital.ToString("C2")).FontSize(11).Bold().FontColor(Colors.Green.Medium);
                            });
                        });

                        page.Footer().AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado completo de clientes.
        /// </summary>
        /// <param name="customers">Colección de clientes.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateCustomersReportAsync(IEnumerable<CustomerDto> customers)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4.Landscape());
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(store?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Item().Text("Reporte General de Clientes");
                            });
                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                col.Item().Text($"Total Registros: {customers.Count()}");
                            });
                        });

                        page.Content().PaddingVertical(15).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("DOCUMENTO");
                                header.Cell().Element(HeaderStyle).Text("CLIENTE");
                                header.Cell().Element(HeaderStyle).Text("CUIL");
                                header.Cell().Element(HeaderStyle).Text("TELÉFONO");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("COND. FISCAL");

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.DefaultTextStyle(x => x.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var c in customers)
                            {
                                table.Cell().Element(DataStyle).AlignCenter().Text(c.DocumentNumber);
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(c.FullName);
                                table.Cell().Element(DataStyle).AlignCenter().Text(c.Cuil ?? "-");
                                table.Cell().Element(DataStyle).AlignCenter().Text(c.Phone ?? "-");
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(c.Email ?? "-");
                                table.Cell().Element(DataStyle).AlignCenter().Text(c.TaxConditionName ?? "-");

                                static IContainer DataStyle(IContainer container) => container.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        page.Footer().AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado completo de proveedores.
        /// </summary>
        /// <param name="suppliers">Colección de proveedores.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateSuppliersReportAsync(IEnumerable<SupplierDto> suppliers)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4.Landscape());
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(store?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Item().Text("Reporte General de Proveedores");
                            });
                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                col.Item().Text($"Total Proveedores: {suppliers.Count()}");
                            });
                        });

                        page.Content().PaddingVertical(15).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(3);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("CUIT");
                                header.Cell().Element(HeaderStyle).Text("EMPRESA");
                                header.Cell().Element(HeaderStyle).Text("CONTACTO");
                                header.Cell().Element(HeaderStyle).Text("TELÉFONO");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("DIRECCIÓN");

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.DefaultTextStyle(x => x.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var s in suppliers)
                            {
                                table.Cell().Element(DataStyle).AlignCenter().Text(s.CUIT);
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(s.CompanyName);
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(s.ContactName ?? "-");
                                table.Cell().Element(DataStyle).AlignCenter().Text(s.Phone ?? "-");
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(s.Email ?? "-");
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(s.Address ?? "-");

                                static IContainer DataStyle(IContainer container) => container.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        page.Footer().AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado de usuarios del sistema.
        /// </summary>
        /// <param name="users">Colección de usuarios.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateUsersReportAsync(IEnumerable<UserDto> users)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4);
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(store?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Item().Text("Reporte de Usuarios del Sistema");
                            });
                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                col.Item().Text($"Total Usuarios: {users.Count()}");
                            });
                        });

                        page.Content().PaddingVertical(15).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1.5f);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("USUARIO");
                                header.Cell().Element(HeaderStyle).Text("NOMBRE");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("ROL");
                                header.Cell().Element(HeaderStyle).Text("ESTADO");

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.DefaultTextStyle(x => x.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var u in users)
                            {
                                table.Cell().Element(DataStyle).AlignCenter().Text(u.Username);
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text($"{u.LastName}, {u.FirstName}");
                                table.Cell().Element(DataStyle).PaddingLeft(4).Text(u.Email);
                                table.Cell().Element(DataStyle).AlignCenter().Text(u.RoleName);
                                table.Cell().Element(DataStyle).AlignCenter().Text(u.IsActive ? "Activo" : "Inactivo")
                                     .FontColor(u.IsActive ? Colors.Green.Medium : Colors.Red.Medium);

                                static IContainer DataStyle(IContainer container) => container.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        page.Footer().AlignCenter().Text(t =>
                        {
                            t.Span("Página ");
                            t.CurrentPageNumber();
                            t.Span(" de ");
                            t.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera el comprobante de ingreso de mercadería tras una compra a proveedor.
        /// </summary>
        /// <param name="purchase">Datos de la compra.</param>
        /// <param name="supplierName">Nombre del proveedor.</param>
        /// <param name="supplierCuit">CUIT del proveedor.</param>
        /// <param name="registeredBy">Usuario que registró la compra.</param>
        /// <returns>Bytes del comprobante de compra.</returns>

        public async Task<byte[]> GeneratePurchaseReceiptAsync(PurchaseCreateDto purchase, string supplierName, string supplierCuit, string registeredBy)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();
            decimal subtotal = purchase.Items?.Sum(x => x.SubTotal) ?? 0;
            decimal totalFinal = purchase.TotalAmount > 0 ? purchase.TotalAmount : subtotal;

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4);
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        // ================= CABECERA CON LOGO =================
                        page.Header().Row(row =>
                        {
                            if (store?.Logo != null && store.Logo.Length > 0)
                            {
                                row.ConstantItem(75).Height(60).PaddingRight(10).AlignMiddle().Image(store.Logo);
                            }

                            // Datos del Supermercado (Receptor)
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(store?.Name ?? "SUPERMERCADO").FontSize(18).ExtraBold().FontColor(Colors.Blue.Medium);
                                col.Spacing(2);
                                col.Item().Text($"RECEPTOR: {store?.Name}");
                                col.Item().Text($"CUIT: {store?.CUIT ?? "S/D"}");
                                col.Item().Text($"DIRECCIÓN: {store?.Address ?? "Depósito Central"}");
                                col.Item().Text($"TELÉFONO: {store?.Phone ?? "S/D"}");
                            });

                            // Datos del Comprobante de Compra
                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text("COMPROBANTE DE COMPRA").FontSize(18).ExtraBold().FontColor(Colors.Grey.Darken2);
                                col.Spacing(4);
                                col.Item().Text($"FECHA: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                col.Item().Text($"COMPROBANTE: {purchase.DocumentTypeName ?? "FACTURA COMPRA"}").SemiBold();
                                col.Item().Text($"N.° FACTURA PROVEEDOR: {purchase.DocumentNumber}").Bold();
                            });
                        });

                        // ================= CONTENIDO PRINCIPAL =================
                        page.Content().PaddingVertical(15).Column(col =>
                        {
                            // Cuadro de Información del Proveedor
                            col.Item().Border(0.5f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(8).Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text("DATOS DEL PROVEEDOR:").Bold().FontSize(10);
                                    c.Item().PaddingTop(2).Text($"Razón Social: {supplierName}").SemiBold();
                                    c.Item().Text($"CUIT / CUIL: {supplierCuit}");
                                });

                                row.RelativeItem().AlignRight().Column(c =>
                                {
                                    c.Item().Text("RECEPCIÓN DE MERCADERÍA:").Bold().FontSize(10);
                                    c.Item().PaddingTop(2).Text($"Registrado por: {registeredBy}");
                                    c.Item().Text("Destino: Inventario / Depósito");
                                });
                            });

                            col.Spacing(15);

                            // Tabla Detallada de Artículos Comprados
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(35);  // #
                                    columns.ConstantColumn(75);  // Cantidad
                                    columns.RelativeColumn(4);   // Descripción
                                    columns.RelativeColumn(2);   // Costo Unitario
                                    columns.RelativeColumn(2);   // Subtotal
                                });

                                table.Header(h =>
                                {
                                    h.Cell().Element(HeaderStyle).Text("#");
                                    h.Cell().Element(HeaderStyle).Text("CANTIDAD");
                                    h.Cell().Element(HeaderStyle).Text("DESCRIPCIÓN DEL PRODUCTO");
                                    h.Cell().Element(HeaderStyle).Text("COSTO UNIT.");
                                    h.Cell().Element(HeaderStyle).Text("SUBTOTAL");

                                    static IContainer HeaderStyle(IContainer c) =>
                                        c.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5).DefaultTextStyle(x => x.Bold());
                                });

                                int index = 1;
                                foreach (var item in purchase.Items ?? Enumerable.Empty<PurchaseItemCreateDto>())
                                {
                                    table.Cell().Border(0.5f).AlignCenter().Text(index++.ToString());
                                    table.Cell().Border(0.5f).AlignCenter().Text(item.Quantity.ToString());
                                    table.Cell().Border(0.5f).PaddingLeft(5).Text(item.ProductName);
                                    table.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(item.BuyPrice.ToString("C2"));
                                    table.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(item.SubTotal.ToString("C2"));
                                }
                            });

                            // Totales al pie de la tabla
                            col.Item().AlignRight().PaddingTop(10).Column(totalsCol =>
                            {
                                totalsCol.Item().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Row(r =>
                                {
                                    r.RelativeItem().AlignRight().PaddingRight(10).Text("TOTAL COMPRA DE STOCK:").FontSize(11).Bold();
                                    r.ConstantItem(120).AlignRight().Text(totalFinal.ToString("C2")).FontSize(12).Bold().FontColor(Colors.Green.Darken2);
                                });
                            });

                            // Cuadro de Firmas para Control Interno de Depósito
                            col.Item().PaddingTop(35).Row(r =>
                            {
                                r.RelativeItem().AlignCenter().Column(c =>
                                {
                                    c.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                                    c.Item().PaddingTop(3).Text("Firma y Sello del Proveedor / Transportista").FontSize(8).Italic();
                                });

                                r.ConstantItem(50); // Espaciador

                                r.RelativeItem().AlignCenter().Column(c =>
                                {
                                    c.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                                    c.Item().PaddingTop(3).Text($"Recibido en Depósito ({registeredBy})").FontSize(8).Italic();
                                });
                            });
                        });

                        // ================= PIE DE PÁGINA =================
                        page.Footer().AlignCenter().Column(f =>
                        {
                            f.Item().Text("Documento interno de ingreso de mercadería a inventario y control de costos.").FontSize(8).Italic();
                            f.Item().Text(t =>
                            {
                                t.Span("Página ");
                                t.CurrentPageNumber();
                                t.Span(" de ");
                                t.TotalPages();
                            });
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un ticket de resumen para el cierre o arqueo de turno de caja.
        /// </summary>
        /// <param name="shift">Información consolidada del turno.</param>
        /// <param name="isZClose">Indica si se trata de un cierre Z (definitivo).</param>
        /// <returns>Bytes del ticket de arqueo.</returns>
        public async Task<byte[]> GenerateCashShiftTicketAsync(CashShiftSummaryDto shift, bool isZClose = true)
        {
            var store = await _unitOfWork.Store.GetSettingsAsync();
            string title = isZClose ? "CIERRE DEFINITIVO DE CAJA (Z)" : "CIERRE PARCIAL DE CAJA (X)";

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.ContinuousSize(80f, Unit.Millimetre);
                        page.Margin(3, Unit.Millimetre);
                        page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Consolas));

                        page.Content().Column(col =>
                        {
                            col.Item().AlignCenter().Text(store?.Name ?? "SUPERMERCADO").FontSize(11).ExtraBold();
                            col.Item().AlignCenter().Text(title).FontSize(10).Bold();
                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().Text($"CAJERO: {shift.CashierName}");
                            col.Item().Text($"TURNO NRO: #{shift.ShiftId}");
                            col.Item().Text($"APERTURA: {shift.OpeningDate:dd/MM/yyyy HH:mm}");
                            col.Item().Text($"EMISIÓN:  {shift.CurrentDate:dd/MM/yyyy HH:mm}");
                            col.Item().Text($"CANT. VENTAS: {shift.SalesCount}");

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().AlignCenter().Text("--- RECAUDACIÓN POR MEDIO DE PAGO ---").FontSize(7.5f).Bold();
                            col.Item().Row(r => { r.RelativeItem().Text("• Efectivo:"); r.RelativeItem().AlignRight().Text(shift.TotalCashSales.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Débito:"); r.RelativeItem().AlignRight().Text(shift.TotalDebitSales.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Crédito:"); r.RelativeItem().AlignRight().Text(shift.TotalCreditSales.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Transferencia:"); r.RelativeItem().AlignRight().Text(shift.TotalTransferSales.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Mercado Pago / QR:"); r.RelativeItem().AlignRight().Text(shift.TotalQrSales.ToString("C2")); });

                            col.Item().PaddingTop(2).Row(r =>
                            {
                                r.RelativeItem().Text("TOTAL FACTURADO:").Bold();
                                r.RelativeItem().AlignRight().Text(shift.TotalSalesAmount.ToString("C2")).Bold();
                            });

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().AlignCenter().Text("--- BALANCE EN GAVETA DE EFECTIVO ---").FontSize(7.5f).Bold();
                            col.Item().Row(r => { r.RelativeItem().Text("Fondo Inicial:"); r.RelativeItem().AlignRight().Text(shift.InitialCash.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(+) Ventas Efectivo:"); r.RelativeItem().AlignRight().Text(shift.TotalCashSales.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(+) Ingresos Manuales:"); r.RelativeItem().AlignRight().Text(shift.TotalManualCashIn.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(-) Egresos / Retiros:"); r.RelativeItem().AlignRight().Text($"-{shift.TotalManualCashOut:C2}"); });

                            col.Item().PaddingTop(2).Row(r =>
                            {
                                r.RelativeItem().Text("EFECTIVO ESPERADO:").FontSize(9.5f).Bold();
                                r.RelativeItem().AlignRight().Text(shift.ExpectedCashInDrawer.ToString("C2")).FontSize(9.5f).Bold();
                            });

                            if (isZClose && shift.RealCashCounted.HasValue)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("EFECTIVO REAL CONTADO:").FontSize(9.5f).Bold();
                                    r.RelativeItem().AlignRight().Text(shift.RealCashCounted.Value.ToString("C2")).FontSize(9.5f).Bold();
                                });

                                decimal diff = shift.Difference ?? 0;
                                string diffText = diff == 0 ? "CAJA CUADRADA ($ 0.00)" : (diff > 0 ? $"SOBRANTE: +{diff:C2}" : $"FALTANTE: {diff:C2}");

                                col.Item().PaddingTop(2).Row(r =>
                                {
                                    r.RelativeItem().Text("DIFERENCIA:").Bold();
                                    r.RelativeItem().AlignRight().Text(diffText).Bold();
                                });
                            }

                            col.Item().PaddingTop(15).AlignCenter().Text("_________________________");
                            col.Item().AlignCenter().Text("Firma del Responsable / Cajero").FontSize(7.5f).Italic();
                            col.Item().PaddingTop(4).AlignCenter().Text("- - - - - - - - - - - - - - - -").FontColor(Colors.Grey.Medium);
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Agrega una fila de totalizado (Subtotal, IVA o Total) a la columna de totales de un reporte PDF.
        /// </summary>
        /// <param name="col">Descriptor de la columna en QuestPDF.</param>
        /// <param name="label">Etiqueta de la fila (ej: "SUBTOTAL").</param>
        /// <param name="val">Monto decimal a mostrar.</param>
        /// <param name="isBold">Indica si el texto debe estar en negrita.</param>
        private static void AddTotalRow(ColumnDescriptor col, string label, decimal val, bool isBold = false)
        {
            col.Item().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Row(r =>
            {
                var textItem = r.RelativeItem().AlignRight().PaddingRight(10).Text(label).FontSize(8);
                if (isBold) textItem.Bold(); else textItem.SemiBold();

                var valItem = r.ConstantItem(100).AlignRight().Text(val.ToString("C2"));
                if (isBold) valItem.Bold();
            });
        }
    }
}
