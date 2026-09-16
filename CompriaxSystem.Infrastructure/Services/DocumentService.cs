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
        /// <param name="documentNumber">Número de comprobante.</param>
        /// <param name="cashierName">Nombre del cajero operador.</param>
        /// <param name="paperSize">Tamaño del papel térmico (58mm o 80mm).</param>
        /// <returns>Arreglo de bytes del PDF generado.</returns>
        public async Task<byte[]> GenerateThermalTicketReceiptAsync(SaleDto sale, string documentNumber, string cashierName, ThermalPaperSize paperSize = ThermalPaperSize.Width80mm)
        {
            var ticketData = await _ticketDataBuilder.BuildSaleTicketDataAsync(sale, documentNumber, cashierName, paperSize);
            return _ticketTemplateService.RenderThermalTicketPdf(ticketData);
        }

        // ================= Métodos A4 y Reportes existentes =================
        public async Task<byte[]> GenerateSaleReceiptAsync(SaleDto sale, string documentNumber, string cashierName)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();

            decimal saleSubtotal = sale.Items?.Sum(saleItem => saleItem.SubTotal) ?? 0;
            decimal taxRatePercentage = 21;
            decimal taxAmount = saleSubtotal * (taxRatePercentage / 100);
            decimal finalTotalAmount = saleSubtotal + taxAmount;

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4);
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(75).Height(60).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeSettings?.Name ?? "Supermercado").FontSize(18).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Spacing(2);
                                documentColumn.Item().Text(storeSettings?.Address ?? "Dirección Comercial");
                                documentColumn.Item().Text($"Teléfono: {storeSettings?.Phone ?? "S/D"}");
                                documentColumn.Item().Text($"Email: {storeSettings?.Email ?? "S/D"}");
                            });

                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text("COMPROBANTE").FontSize(22).Thin();
                                documentColumn.Spacing(4);
                                documentColumn.Item().Text($"FECHA: {sale.Date:dd/MM/yyyy HH:mm}").SemiBold();
                                documentColumn.Item().Text($"N.°: {documentNumber}").SemiBold();
                                documentColumn.Item().Text($"CUIT: {storeSettings?.CUIT ?? "S/D"}").SemiBold();
                            });
                        });

                        documentPage.Content().PaddingVertical(15).Column(documentColumn =>
                        {
                            documentColumn.Item().Row(documentRow =>
                            {
                                documentRow.RelativeItem().Column(container =>
                                {
                                    container.Item().BorderBottom(1).PaddingBottom(2).Text("Facturar a:").Bold();
                                    container.Item().PaddingTop(3).Text(sale.CustomerName);
                                    container.Item().Text($"DNI/CUIT: {sale.CustomerDoc}");
                                });
                            });

                            documentColumn.Spacing(15);

                            documentColumn.Item().Table(documentTable =>
                            {
                                documentTable.ColumnsDefinition(tableColumns =>
                                {
                                    tableColumns.ConstantColumn(70);
                                    tableColumns.RelativeColumn(3);
                                    tableColumns.RelativeColumn(1);
                                    tableColumns.RelativeColumn(1);
                                });

                                documentTable.Header(headerRow =>
                                {
                                    headerRow.Cell().Element(HeaderStyle).Text("CANTIDAD");
                                    headerRow.Cell().Element(HeaderStyle).Text("DESCRIPCIÓN");
                                    headerRow.Cell().Element(HeaderStyle).Text("PRECIO UNIT.");
                                    headerRow.Cell().Element(HeaderStyle).Text("SUBTOTAL");
                                    static IContainer HeaderStyle(IContainer container) => container.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5).DefaultTextStyle(saleItem => saleItem.Bold());
                                });

                                foreach (var saleItem in sale.Items ?? Enumerable.Empty<SaleItemDto>())
                                {
                                    documentTable.Cell().Border(0.5f).AlignCenter().Text(saleItem.Quantity.ToString());
                                    documentTable.Cell().Border(0.5f).PaddingLeft(5).Text(saleItem.ProductName);
                                    documentTable.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(saleItem.UnitPrice.ToString("C2"));
                                    documentTable.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(saleItem.SubTotal.ToString("C2"));
                                }
                            });

                            documentColumn.Item().AlignRight().PaddingTop(10).Column(totalsColumn =>
                            {
                                AddTotalRow(totalsColumn, "SUBTOTAL", saleSubtotal);
                                AddTotalRow(totalsColumn, $"IVA ({taxRatePercentage}%)", taxAmount);
                                AddTotalRow(totalsColumn, "TOTAL", finalTotalAmount, useBoldText: true);
                            });
                        });

                        documentPage.Footer().AlignCenter().Column(footerColumn =>
                        {
                            footerColumn.Item().Text("¡GRACIAS POR SU COMPRA!").FontSize(12).ExtraBold();
                            footerColumn.Item().Text($"Atendido por: {cashierName}").FontSize(8).Italic();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte detallado de inventario en formato A4 con indicadores de stock crítico.
        /// </summary>
        /// <param name="productDtos">Colección de productos a incluir.</param>
        /// <returns>Bytes del reporte PDF de inventario.</returns>
        public async Task<byte[]> GenerateInventoryReportAsync(IEnumerable<ProductDto> productDtos)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();
            string storeName = storeSettings?.Name ?? "Supermercado";
            string storeAddress = storeSettings?.Address ?? "Reporte del Sistema";

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4);
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeName).FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Item().Text(storeAddress);
                                documentColumn.Item().Text("Módulo de Gestión de Inventario");
                            });

                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text("REPORTE DE PRODUCTOS").FontSize(16).Thin();
                                documentColumn.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                            });
                        });

                        documentPage.Content().PaddingVertical(15).Column(documentColumn =>
                        {
                            documentColumn.Item().Table(documentTable =>
                            {
                                documentTable.ColumnsDefinition(tableColumns =>
                                {
                                    tableColumns.RelativeColumn(2);
                                    tableColumns.RelativeColumn(4);
                                    tableColumns.RelativeColumn(2);
                                    tableColumns.RelativeColumn(1.5f);
                                    tableColumns.RelativeColumn(2);
                                });

                                documentTable.Header(header =>
                                {
                                    header.Cell().Element(HeaderStyle).Text("CÓDIGO");
                                    header.Cell().Element(HeaderStyle).Text("PRODUCTO");
                                    header.Cell().Element(HeaderStyle).Text("CATEGORÍA");
                                    header.Cell().Element(HeaderStyle).Text("STOCK");
                                    header.Cell().Element(HeaderStyle).Text("PRECIO VTA.");

                                    static IContainer HeaderStyle(IContainer container) =>
                                        container.DefaultTextStyle(saleItem => saleItem.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                                });

                                foreach (var productDto in productDtos)
                                {
                                    documentTable.Cell().Element(DataStyle).AlignCenter().Text(productDto.Barcode);
                                    documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(productDto.Name);
                                    documentTable.Cell().Element(DataStyle).AlignCenter().Text(productDto.CategoryName ?? "-");

                                    bool isStockCritical = productDto.CurrentStock <= productDto.MinimumStock;
                                    documentTable.Cell().Element(DataStyle).AlignCenter().Text(productDto.CurrentStock.ToString())
                                         .FontColor(isStockCritical ? Colors.Red.Medium : Colors.Black);

                                    documentTable.Cell().Element(DataStyle).AlignRight().PaddingRight(4).Text(productDto.SellPrice.ToString("C2"));

                                    static IContainer DataStyle(IContainer container) => container.Border(0.5f).PaddingVertical(3);
                                }
                            });

                            decimal totalInventoryValue = productDtos.Sum(saleItem => saleItem.CurrentStock * saleItem.SellPrice);

                            documentColumn.Item().PaddingTop(15).AlignRight().Background(Colors.Grey.Lighten4).Padding(8).Row(documentRow =>
                            {
                                documentRow.RelativeItem().AlignRight().Text("VALOR TOTAL ESTIMADO DE INVENTARIO: ").Bold();
                                documentRow.ConstantItem(150).AlignRight().Text(totalInventoryValue.ToString("C2")).FontSize(11).Bold().FontColor(Colors.Green.Medium);
                            });
                        });

                        documentPage.Footer().AlignCenter().Text(footerText =>
                        {
                            footerText.Span("Página ");
                            footerText.CurrentPageNumber();
                            footerText.Span(" de ");
                            footerText.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado completo de clientes.
        /// </summary>
        /// <param name="customerDtos">Colección de clientes.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateCustomersReportAsync(IEnumerable<CustomerDto> customerDtos)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4.Landscape());
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeSettings?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Item().Text("Reporte General de Clientes");
                            });
                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                documentColumn.Item().Text($"Total Registros: {customerDtos.Count()}");
                            });
                        });

                        documentPage.Content().PaddingVertical(15).Table(documentTable =>
                        {
                            documentTable.ColumnsDefinition(tableColumns =>
                            {
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(2);
                            });

                            documentTable.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("DOCUMENTO");
                                header.Cell().Element(HeaderStyle).Text("CLIENTE");
                                header.Cell().Element(HeaderStyle).Text("CUIL");
                                header.Cell().Element(HeaderStyle).Text("TELÉFONO");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("COND. FISCAL");

                                static IContainer HeaderStyle(IContainer container) =>
                                    container.DefaultTextStyle(saleItem => saleItem.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var container in customerDtos)
                            {
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(container.DocumentNumber);
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(container.FullName);
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(container.Cuil ?? "-");
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(container.Phone ?? "-");
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(container.Email ?? "-");
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(container.TaxConditionName ?? "-");

                                static IContainer DataStyle(IContainer documentContainer) => documentContainer.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        documentPage.Footer().AlignCenter().Text(footerText =>
                        {
                            footerText.Span("Página ");
                            footerText.CurrentPageNumber();
                            footerText.Span(" de ");
                            footerText.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado completo de proveedores.
        /// </summary>
        /// <param name="supplierDtos">Colección de proveedores.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateSuppliersReportAsync(IEnumerable<SupplierDto> supplierDtos)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4.Landscape());
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeSettings?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Item().Text("Reporte General de Proveedores");
                            });
                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                documentColumn.Item().Text($"Total Proveedores: {supplierDtos.Count()}");
                            });
                        });

                        documentPage.Content().PaddingVertical(15).Table(documentTable =>
                        {
                            documentTable.ColumnsDefinition(tableColumns =>
                            {
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(3);
                            });

                            documentTable.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("CUIT");
                                header.Cell().Element(HeaderStyle).Text("EMPRESA");
                                header.Cell().Element(HeaderStyle).Text("CONTACTO");
                                header.Cell().Element(HeaderStyle).Text("TELÉFONO");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("DIRECCIÓN");

                                static IContainer HeaderStyle(IContainer container) =>
                                    container.DefaultTextStyle(saleItem => saleItem.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var supplierDto in supplierDtos)
                            {
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(supplierDto.CUIT);
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(supplierDto.CompanyName);
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(supplierDto.ContactName ?? "-");
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(supplierDto.Phone ?? "-");
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(supplierDto.Email ?? "-");
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(supplierDto.Address ?? "-");

                                static IContainer DataStyle(IContainer documentContainer) => documentContainer.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        documentPage.Footer().AlignCenter().Text(footerText =>
                        {
                            footerText.Span("Página ");
                            footerText.CurrentPageNumber();
                            footerText.Span(" de ");
                            footerText.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un reporte PDF con el listado de usuarios del sistema.
        /// </summary>
        /// <param name="userDtos">Colección de usuarios.</param>
        /// <returns>Bytes del reporte.</returns>
        public async Task<byte[]> GenerateUsersReportAsync(IEnumerable<UserDto> userDtos)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4);
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(65).Height(50).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeSettings?.Name ?? "Supermercado").FontSize(16).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Item().Text("Reporte de Usuarios del Sistema");
                            });
                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                documentColumn.Item().Text($"Total Usuarios: {userDtos.Count()}");
                            });
                        });

                        documentPage.Content().PaddingVertical(15).Table(documentTable =>
                        {
                            documentTable.ColumnsDefinition(tableColumns =>
                            {
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(3);
                                tableColumns.RelativeColumn(2);
                                tableColumns.RelativeColumn(1.5f);
                            });

                            documentTable.Header(header =>
                            {
                                header.Cell().Element(HeaderStyle).Text("USUARIO");
                                header.Cell().Element(HeaderStyle).Text("NOMBRE");
                                header.Cell().Element(HeaderStyle).Text("EMAIL");
                                header.Cell().Element(HeaderStyle).Text("ROL");
                                header.Cell().Element(HeaderStyle).Text("ESTADO");

                                static IContainer HeaderStyle(IContainer container) =>
                                    container.DefaultTextStyle(saleItem => saleItem.Bold()).Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5);
                            });

                            foreach (var userDto in userDtos)
                            {
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(userDto.Username);
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text($"{userDto.LastName}, {userDto.FirstName}");
                                documentTable.Cell().Element(DataStyle).PaddingLeft(4).Text(userDto.Email);
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(userDto.RoleName);
                                documentTable.Cell().Element(DataStyle).AlignCenter().Text(userDto.IsActive ? "Activo" : "Inactivo")
                                     .FontColor(userDto.IsActive ? Colors.Green.Medium : Colors.Red.Medium);

                                static IContainer DataStyle(IContainer documentContainer) => documentContainer.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        documentPage.Footer().AlignCenter().Text(footerText =>
                        {
                            footerText.Span("Página ");
                            footerText.CurrentPageNumber();
                            footerText.Span(" de ");
                            footerText.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera el comprobante de ingreso de mercadería tras una compra a proveedor.
        /// </summary>
        /// <param name="purchaseDto">Datos de la compra.</param>
        /// <param name="supplierCompanyName">Nombre del proveedor.</param>
        /// <param name="supplierCuit">CUIT del proveedor.</param>
        /// <param name="registeredByUsername">Usuario que registró la compra.</param>
        /// <returns>Bytes del comprobante de compra.</returns>

        public async Task<byte[]> GeneratePurchaseReceiptAsync(PurchaseCreateDto purchaseDto, string supplierCompanyName, string supplierCuit, string registeredByUsername)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();
            decimal saleSubtotal = purchaseDto.Items?.Sum(saleItem => saleItem.SubTotal) ?? 0;
            decimal finalTotalAmount = purchaseDto.TotalAmount > 0 ? purchaseDto.TotalAmount : saleSubtotal;

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.Margin(1.5f, Unit.Centimetre);
                        documentPage.Size(PageSizes.A4);
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(9).FontFamily(Fonts.Verdana));

                        // ================= CABECERA CON LOGO =================
                        documentPage.Header().Row(documentRow =>
                        {
                            if (storeSettings?.Logo != null && storeSettings.Logo.Length > 0)
                            {
                                documentRow.ConstantItem(75).Height(60).PaddingRight(10).AlignMiddle().Image(storeSettings.Logo);
                            }

                            // Datos del Supermercado (Receptor)
                            documentRow.RelativeItem().Column(documentColumn =>
                            {
                                documentColumn.Item().Text(storeSettings?.Name ?? "SUPERMERCADO").FontSize(18).ExtraBold().FontColor(Colors.Blue.Medium);
                                documentColumn.Spacing(2);
                                documentColumn.Item().Text($"RECEPTOR: {storeSettings?.Name}");
                                documentColumn.Item().Text($"CUIT: {storeSettings?.CUIT ?? "S/D"}");
                                documentColumn.Item().Text($"DIRECCIÓN: {storeSettings?.Address ?? "Depósito Central"}");
                                documentColumn.Item().Text($"TELÉFONO: {storeSettings?.Phone ?? "S/D"}");
                            });

                            // Datos del Comprobante de Compra
                            documentRow.RelativeItem().AlignRight().Column(documentColumn =>
                            {
                                documentColumn.Item().Text("COMPROBANTE DE COMPRA").FontSize(18).ExtraBold().FontColor(Colors.Grey.Darken2);
                                documentColumn.Spacing(4);
                                documentColumn.Item().Text($"FECHA: {DateTime.Now:dd/MM/yyyy HH:mm}").SemiBold();
                                documentColumn.Item().Text($"COMPROBANTE: {purchaseDto.DocumentTypeName ?? "FACTURA COMPRA"}").SemiBold();
                                documentColumn.Item().Text($"N.° FACTURA PROVEEDOR: {purchaseDto.DocumentNumber}").Bold();
                            });
                        });

                        // ================= CONTENIDO PRINCIPAL =================
                        documentPage.Content().PaddingVertical(15).Column(documentColumn =>
                        {
                            // Cuadro de Información del Proveedor
                            documentColumn.Item().Border(0.5f).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten4).Padding(8).Row(documentRow =>
                            {
                                documentRow.RelativeItem().Column(container =>
                                {
                                    container.Item().Text("DATOS DEL PROVEEDOR:").Bold().FontSize(10);
                                    container.Item().PaddingTop(2).Text($"Razón Social: {supplierCompanyName}").SemiBold();
                                    container.Item().Text($"CUIT / CUIL: {supplierCuit}");
                                });

                                documentRow.RelativeItem().AlignRight().Column(container =>
                                {
                                    container.Item().Text("RECEPCIÓN DE MERCADERÍA:").Bold().FontSize(10);
                                    container.Item().PaddingTop(2).Text($"Registrado por: {registeredByUsername}");
                                    container.Item().Text("Destino: Inventario / Depósito");
                                });
                            });

                            documentColumn.Spacing(15);

                            // Tabla Detallada de Artículos Comprados
                            documentColumn.Item().Table(documentTable =>
                            {
                                documentTable.ColumnsDefinition(tableColumns =>
                                {
                                    tableColumns.ConstantColumn(35);  // #
                                    tableColumns.ConstantColumn(75);  // Cantidad
                                    tableColumns.RelativeColumn(4);   // Descripción
                                    tableColumns.RelativeColumn(2);   // Costo Unitario
                                    tableColumns.RelativeColumn(2);   // Subtotal
                                });

                                documentTable.Header(headerRow =>
                                {
                                    headerRow.Cell().Element(HeaderStyle).Text("#");
                                    headerRow.Cell().Element(HeaderStyle).Text("CANTIDAD");
                                    headerRow.Cell().Element(HeaderStyle).Text("DESCRIPCIÓN DEL PRODUCTO");
                                    headerRow.Cell().Element(HeaderStyle).Text("COSTO UNIT.");
                                    headerRow.Cell().Element(HeaderStyle).Text("SUBTOTAL");

                                    static IContainer HeaderStyle(IContainer container) =>
                                        container.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(5).DefaultTextStyle(saleItem => saleItem.Bold());
                                });

                                int itemIndex = 1;
                                foreach (var saleItem in purchaseDto.Items ?? Enumerable.Empty<PurchaseItemCreateDto>())
                                {
                                    documentTable.Cell().Border(0.5f).AlignCenter().Text(itemIndex++.ToString());
                                    documentTable.Cell().Border(0.5f).AlignCenter().Text(saleItem.Quantity.ToString());
                                    documentTable.Cell().Border(0.5f).PaddingLeft(5).Text(saleItem.ProductName);
                                    documentTable.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(saleItem.BuyPrice.ToString("C2"));
                                    documentTable.Cell().Border(0.5f).AlignRight().PaddingRight(5).Text(saleItem.SubTotal.ToString("C2"));
                                }
                            });

                            // Totales al pie de la tabla
                            documentColumn.Item().AlignRight().PaddingTop(10).Column(totalsColumn =>
                            {
                                totalsColumn.Item().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Row(row =>
                                {
                                    row.RelativeItem().AlignRight().PaddingRight(10).Text("TOTAL COMPRA DE STOCK:").FontSize(11).Bold();
                                    row.ConstantItem(120).AlignRight().Text(finalTotalAmount.ToString("C2")).FontSize(12).Bold().FontColor(Colors.Green.Darken2);
                                });
                            });

                            // Cuadro de Firmas para Control Interno de Depósito
                            documentColumn.Item().PaddingTop(35).Row(row =>
                            {
                                row.RelativeItem().AlignCenter().Column(container =>
                                {
                                    container.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                                    container.Item().PaddingTop(3).Text("Firma y Sello del Proveedor / Transportista").FontSize(8).Italic();
                                });

                                row.ConstantItem(50); // Espaciador

                                row.RelativeItem().AlignCenter().Column(container =>
                                {
                                    container.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                                    container.Item().PaddingTop(3).Text($"Recibido en Depósito ({registeredByUsername})").FontSize(8).Italic();
                                });
                            });
                        });

                        // ================= PIE DE PÁGINA =================
                        documentPage.Footer().AlignCenter().Column(footerColumn =>
                        {
                            footerColumn.Item().Text("Documento interno de ingreso de mercadería a inventario y control de costos.").FontSize(8).Italic();
                            footerColumn.Item().Text(footerText =>
                            {
                                footerText.Span("Página ");
                                footerText.CurrentPageNumber();
                                footerText.Span(" de ");
                                footerText.TotalPages();
                            });
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un ticket de resumen para el cierre o arqueo de turno de caja.
        /// </summary>
        /// <param name="cashShiftSummary">Información consolidada del turno.</param>
        /// <param name="isDefinitiveZClose">Indica si se trata de un cierre Z (definitivo).</param>
        /// <returns>Bytes del ticket de arqueo.</returns>
        public async Task<byte[]> GenerateCashShiftTicketAsync(CashShiftSummaryDto cashShiftSummary, bool isDefinitiveZClose = true)
        {
            var storeSettings = await _unitOfWork.Store.GetSettingsAsync();
            string cashShiftTicketTitle = isDefinitiveZClose ? "CIERRE DEFINITIVO DE CAJA (Z)" : "CIERRE PARCIAL DE CAJA (X)";

            return await Task.Run(() =>
            {
                return Document.Create(documentContainer =>
                {
                    documentContainer.Page(documentPage =>
                    {
                        documentPage.ContinuousSize(80f, Unit.Millimetre);
                        documentPage.Margin(3, Unit.Millimetre);
                        documentPage.DefaultTextStyle(saleItem => saleItem.FontSize(8.5f).FontFamily(Fonts.Consolas));

                        documentPage.Content().Column(documentColumn =>
                        {
                            documentColumn.Item().AlignCenter().Text(storeSettings?.Name ?? "SUPERMERCADO").FontSize(11).ExtraBold();
                            documentColumn.Item().AlignCenter().Text(cashShiftTicketTitle).FontSize(10).Bold();
                            documentColumn.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            documentColumn.Item().Text($"CAJERO: {cashShiftSummary.CashierName}");
                            documentColumn.Item().Text($"TURNO NRO: #{cashShiftSummary.ShiftId}");
                            documentColumn.Item().Text($"APERTURA: {cashShiftSummary.OpeningDate:dd/MM/yyyy HH:mm}");
                            documentColumn.Item().Text($"EMISIÓN:  {cashShiftSummary.CurrentDate:dd/MM/yyyy HH:mm}");
                            documentColumn.Item().Text($"CANT. VENTAS: {cashShiftSummary.SalesCount}");

                            documentColumn.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            documentColumn.Item().AlignCenter().Text("--- RECAUDACIÓN POR MEDIO DE PAGO ---").FontSize(7.5f).Bold();
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("• Efectivo:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalCashSales.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("• Débito:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalDebitSales.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("• Crédito:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalCreditSales.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("• Transferencia:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalTransferSales.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("• Mercado Pago / QR:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalQrSales.ToString("C2")); });

                            documentColumn.Item().PaddingTop(2).Row(row =>
                            {
                                row.RelativeItem().Text("TOTAL FACTURADO:").Bold();
                                row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalSalesAmount.ToString("C2")).Bold();
                            });

                            documentColumn.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            documentColumn.Item().AlignCenter().Text("--- BALANCE EN GAVETA DE EFECTIVO ---").FontSize(7.5f).Bold();
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("Fondo Inicial:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.InitialCash.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("(+) Ventas Efectivo:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalCashSales.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("(+) Ingresos Manuales:"); row.RelativeItem().AlignRight().Text(cashShiftSummary.TotalManualCashIn.ToString("C2")); });
                            documentColumn.Item().Row(row => { row.RelativeItem().Text("(-) Egresos / Retiros:"); row.RelativeItem().AlignRight().Text($"-{cashShiftSummary.TotalManualCashOut:C2}"); });

                            documentColumn.Item().PaddingTop(2).Row(row =>
                            {
                                row.RelativeItem().Text("EFECTIVO ESPERADO:").FontSize(9.5f).Bold();
                                row.RelativeItem().AlignRight().Text(cashShiftSummary.ExpectedCashInDrawer.ToString("C2")).FontSize(9.5f).Bold();
                            });

                            if (isDefinitiveZClose && cashShiftSummary.RealCashCounted.HasValue)
                            {
                                documentColumn.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("EFECTIVO REAL CONTADO:").FontSize(9.5f).Bold();
                                    row.RelativeItem().AlignRight().Text(cashShiftSummary.RealCashCounted.Value.ToString("C2")).FontSize(9.5f).Bold();
                                });

                                decimal cashDifference = cashShiftSummary.Difference ?? 0;
                                string cashDifferenceText = cashDifference == 0 ? "CAJA CUADRADA ($ 0.00)" : (cashDifference > 0 ? $"SOBRANTE: +{cashDifference:C2}" : $"FALTANTE: {cashDifference:C2}");

                                documentColumn.Item().PaddingTop(2).Row(row =>
                                {
                                    row.RelativeItem().Text("DIFERENCIA:").Bold();
                                    row.RelativeItem().AlignRight().Text(cashDifferenceText).Bold();
                                });
                            }

                            documentColumn.Item().PaddingTop(15).AlignCenter().Text("_________________________");
                            documentColumn.Item().AlignCenter().Text("Firma del Responsable / Cajero").FontSize(7.5f).Italic();
                            documentColumn.Item().PaddingTop(4).AlignCenter().Text("- - - - - - - - - - - - - - - -").FontColor(Colors.Grey.Medium);
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Agrega una fila de totalizado (Subtotal, IVA o Total) a la columna de totales de un reporte PDF.
        /// </summary>
        /// <param name="documentColumn">Descriptor de la columna en QuestPDF.</param>
        /// <param name="totalLabel">Etiqueta de la fila (ej: "SUBTOTAL").</param>
        /// <param name="totalAmount">Monto decimal a mostrar.</param>
        /// <param name="useBoldText">Indica si el texto debe estar en negrita.</param>
        private static void AddTotalRow(ColumnDescriptor documentColumn, string totalLabel, decimal totalAmount, bool useBoldText = false)
        {
            documentColumn.Item().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Row(row =>
            {
                var totalText = row.RelativeItem().AlignRight().PaddingRight(10).Text(totalLabel).FontSize(8);
                
                if (useBoldText) 
                    totalText.Bold(); 
                else 
                    totalText.SemiBold();

                var totalValueText = row.ConstantItem(100).AlignRight().Text(totalAmount.ToString("C2"));
                
                if (useBoldText)
                    totalValueText.Bold();
            });
        }
    }
}
