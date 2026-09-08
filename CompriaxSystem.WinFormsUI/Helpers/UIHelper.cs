using CompriaxSystem.Application.Common;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class UIHelper
    {
        public static void CleanControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox t)
                    t.Clear();
                else if (c is ComboBox cb)
                    cb.SelectedIndex = -1;
                else if (c is NumericUpDown n)
                    n.Value = n.Minimum;
                else if (c is PictureBox p)
                    p.Image = null;

                if (c.HasChildren && c is not DataGridView)
                    CleanControls(c);
            }
        }

        public static void ShowResult(OperationResult result, string title, Action? onSuccess = null)
        {
            if (result.Success)
            {
                MessageBox.Show(result.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                onSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show(result.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static readonly Dictionary<string, string> _translations = new()
        {
            // 1. Cajas y Puestos POS (Multi-Caja)
            { "Number", "N.° Caja" },
            { "CashRegisterName", "Caja / Terminal" },
            { "CashRegisterNumber", "N.° Caja" },
            { "CurrentCashierName", "Cajero/a en Turno" },
            { "CurrentShiftId", "Turno Activo" },
            { "HasOpenShift", "¿Turno Abierto?" },

            // 2. Productos e Inventario
            { "Barcode", "Código de Barras" },
            { "ProductName", "Producto" },
            { "Description", "Descripción" },
            { "CategoryName", "Categoría" },
            { "BrandName", "Marca" },
            { "SellPrice", "Precio Venta" },
            { "BuyPrice", "Precio Compra / Costo" },
            { "CurrentStock", "Stock Actual" },
            { "MinimumStock", "Stock Mínimo" },
            { "StockStatus", "Estado Stock" },
            { "UnitOfMeasureName", "Unidad de Medida" },
            { "InitialStock", "Stock Inicial" },

            // 3. Personas (Clientes, Proveedores, Empleados)
            { "DocumentNumber", "N.° Documento / DNI" },
            { "FirstName", "Nombre" },
            { "LastName", "Apellido" },
            { "FullName", "Nombre Completo" },
            { "TaxCondition", "Cond. Fiscal" },
            { "TaxConditionName", "Condición Tributaria" },
            { "Cuil", "CUIL / CUIT" },
            { "CUIT", "CUIT / CUIL" },
            { "Email", "Correo Electrónico" },
            { "Phone", "Teléfono" },
            { "Address", "Dirección" },
            { "City", "Ciudad" },
            { "CompanyName", "Razón Social / Empresa" },
            { "ContactName", "Contacto Comercial" },
            { "EmployeeCode", "Legajo" },
            { "Position", "Cargo" },
            { "PositionName", "Puesto / Cargo" },
            { "GenderName", "Género" },
            { "CivilStatusName", "Estado Civil" },
            { "ChildrenCount", "Hijos" },

            // 4. Operaciones, Ventas y Compras
            { "Date", "Fecha y Hora" },
            { "DocumentType", "Tipo Comprobante" },
            { "DocumentTypeName", "Comprobante" },
            { "PaymentMethodName", "Medio de Pago" },
            { "CustomerName", "Cliente" },
            { "CustomerDoc", "DNI/CUIT Cliente" },
            { "CashierName", "Cajero/a" },
            { "Quantity", "Cantidad" },
            { "UnitPrice", "Precio Unit." },
            { "CostPrice", "Costo Unit." },
            { "DiscountAmount", "Descuento" },
            { "SubTotal", "Subtotal" },
            { "TotalAmount", "Total Facturado" },
            { "PaymentReceived", "Monto Abonado" },
            { "PaymentChange", "Vuelto" },
            { "PointOfSale", "Punto de Venta" },
            { "Cae", "CAE Oficial" },
            { "CaeExpirationDate", "Vto. CAE" },
            { "FiscalStatus", "Estado Fiscal" },
            { "QuantitySold", "Cant. Vendida" },
            { "TotalRevenue", "Recaudación Total" },
            { "SupplierName", "Proveedor" },
            { "SupplierTaxId", "CUIT Proveedor" },

            // 5. Control de Caja, Turnos y Arqueos (X/Z)
            { "UserName", "Cajero / Responsable" },
            { "OpeningDate", "Fecha Apertura" },
            { "ClosingDate", "Fecha Cierre" },
            { "InitialCash", "Fondo Inicial" },
            { "RealCash", "Efectivo Real Contado" },
            { "ExpectedCash", "Efectivo Esperado" },
            { "Difference", "Diferencia / Balance" },
            { "TotalCashSales", "Ventas Efectivo" },
            { "TotalDebitSales", "Ventas Débito" },
            { "TotalCreditSales", "Ventas Crédito" },
            { "TotalTransferSales", "Ventas Transferencia" },
            { "TotalQrSales", "Ventas QR / MP" },
            { "TotalManualCashIn", "Ingresos Manuales" },
            { "TotalManualCashOut", "Egresos / Retiros" },
            { "CurrentSystemCash", "Efectivo en Gaveta" },
            { "TotalTurnover", "Facturación Turno" },
            { "ClosingNotes", "Observaciones Cierre" },
            { "MovementTypeName", "Tipo Movimiento" },
            { "Amount", "Importe" },
            { "CreatedAt", "Fecha de Registro" },
            { "Remarks", "Observaciones / Detalle" },

            // 6. Seguridad y Usuarios
            { "Username", "Usuario (Login)" },
            { "RoleName", "Rol / Acceso" },
            { "Status", "Estado" },
            { "StatusSummary", "Estado Actual" },

            // 7. Promociones y Descuentos
            { "PromotionTypeName", "Tipo de Regla" },
            { "DiscountPercentage", "% Descuento" },
            { "RequiredQuantity", "Lleva (N)" },
            { "PayQuantity", "Paga (M)" },
            { "StartDate", "Fecha Inicio" },
            { "EndDate", "Fecha Fin" },

            // 8. Papelera de Reciclaje / Auditoría (Soft Delete)
            { "EntityType", "Módulo / Entidad" },
            { "Identifier", "Identificador" },
            { "Name", "Nombre / Detalle" },
            { "AdditionalInfo", "Información Extra" },
            { "DeletedAt", "Fecha Eliminación" },
            { "DeletedBy", "Eliminado Por" },
            { "CreatedBy", "Creado Por" },
            { "LastUpdatedAt", "Última Modificación" },
            { "LastUpdatedBy", "Modificado Por" }
        };

        public static void FormatGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 66, 91);
            dgv.ColumnHeadersHeight = 30;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 149, 237);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            string[] columnsToHide = {
                "Id", "IsDeleted", "RowVersion", "IsActive", "Status", "FullName",
                "RoleId", "CategoryId", "BrandId", "UnitOfMeasureId", "TaxConditionId",
                "GenderId", "CivilStatusId", "PositionId", "ProductId", "SupplierId",
                "CustomerId", "EmployeeId", "SaleId", "PurchaseId", "PromotionId",
                "PromotionType", "DaysOfWeek", "DocumentTypeId", "UserId",
                "PaymentMethodId", "CashShiftId", "MovementType", "CashRegisterId",
                "Photo", "Image", "Logo", "LogoBytes", "Password", "NewPassword", "CurrentPassword",
                "InternalBarcodeBytes", "FiscalQrImageBytes", "AfipQrUrl", "QrUrl",
                "Items", "AppliedDiscounts", "CalculatedItems", "Discounts", "Payments",
                "SaleItems", "PurchaseItems", "CashMovements", "Sales", "CashShifts"
            };

            foreach (var colName in columnsToHide)
            {
                if (dgv.Columns.Contains(colName))
                    dgv.Columns[colName].Visible = false;
            }

            foreach (var item in _translations)
            {
                if (dgv.Columns.Contains(item.Key))
                    dgv.Columns[item.Key].HeaderText = item.Value;
            }

            string[] moneyCols = {
                "SellPrice", "BuyPrice", "TotalAmount", "UnitPrice", "CostPrice",
                "SubTotal", "TotalRevenue", "PaymentReceived", "PaymentChange",
                "DiscountAmount", "InitialCash", "RealCash", "ExpectedCash",
                "Difference", "TotalCashSales", "TotalDebitSales", "TotalCreditSales",
                "TotalTransferSales", "TotalQrSales", "TotalManualCashIn",
                "TotalManualCashOut", "CurrentSystemCash", "TotalTurnover", "Amount",
                "ExpectedCashInDrawer", "TotalSalesAmount"
            };

            foreach (var col in moneyCols)
            {
                if (dgv.Columns.Contains(col)) dgv.Columns[col].DefaultCellStyle.Format = "C2";
            }

            string[] dateCols = { "Date", "DeletedAt", "CreatedAt", "LastUpdatedAt", "OpeningDate", "ClosingDate" };
            foreach (var col in dateCols)
            {
                if (dgv.Columns.Contains(col))
                {
                    dgv.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgv.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void AttachManagedSelection(Form form, DataGridView dgv, Action onSync, Action onClear)
        {
            if (dgv.Tag is SelectionState oldState)
            {
                dgv.CellClick -= oldState.OnCellClick;
                dgv.MouseDown -= oldState.OnDgvMouseDown;

                foreach (var (control, handler) in oldState.ExternalHandlers)
                    control.Click -= handler;
            }

            var state = new SelectionState();

            void SafeClear()
            {
                if (state.SelectedRowIndex != -1)
                {
                    state.SelectedRowIndex = -1;
                    dgv.ClearSelection();
                    onClear();
                }
            }

            void OnCellClick(object? sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0 || dgv.CurrentRow == null)
                    return;

                if (state.SelectedRowIndex == e.RowIndex)
                    SafeClear();
                else
                {
                    state.SelectedRowIndex = e.RowIndex;
                    onSync();
                }
            }

            void OnDgvMouseDown(object? sender, MouseEventArgs e)
            {
                var hit = dgv.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.None) SafeClear();
            }

            void OnExternalClick(object? sender, EventArgs e) => SafeClear();

            state.OnCellClick = OnCellClick;
            state.OnDgvMouseDown = OnDgvMouseDown;

            dgv.CellClick += OnCellClick;
            dgv.MouseDown += OnDgvMouseDown;
            AttachExternalClick(form, OnExternalClick, state);
            dgv.Tag = state;
        }

        private static void AttachExternalClick(Control container, EventHandler handler, SelectionState state)
        {
            if (container is Form or Panel or GroupBox or Label)
            {
                container.Click += handler;
                state.ExternalHandlers.Add((container, handler));
            }

            if (container.HasChildren && container is not DataGridView)
            {
                foreach (Control child in container.Controls)
                {
                    if (child is not DataGridView and not TextBox and not ComboBox
                        and not NumericUpDown and not Button and not PictureBox
                        and not DateTimePicker and not CheckBox and not RadioButton)
                    {
                        AttachExternalClick(child, handler, state);
                    }
                }
            }
        }

        private sealed class SelectionState
        {
            public int SelectedRowIndex { get; set; } = -1;
            public DataGridViewCellEventHandler? OnCellClick { get; set; }
            public MouseEventHandler? OnDgvMouseDown { get; set; }
            public List<(Control Control, EventHandler Handler)> ExternalHandlers { get; } = new();
        }

        public static List<SearchCriteria> GetSearchableCriteria(params string[] propertyNames)
        {
            var list = new List<SearchCriteria>();

            foreach (var prop in propertyNames)
            {
                string displayName = _translations.ContainsKey(prop) ? _translations[prop] : prop;
                list.Add(new SearchCriteria { Id = prop, Name = displayName });
            }
            return list;
        }

        public static bool ConfirmMessage(string message, string title = "Confirmación")
            => MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static void InfoMessage(IWin32Window? owner, string message, string title = "Información")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void WarnMessage(IWin32Window? owner, string message, string title = "Aviso")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void ErrorMessage(IWin32Window? owner, string message, string title = "Error")
            => MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public class SearchCriteria
        {
            public string Id { get; set; } = null!;
            public string Name { get; set; } = null!;
        }
    }
}
