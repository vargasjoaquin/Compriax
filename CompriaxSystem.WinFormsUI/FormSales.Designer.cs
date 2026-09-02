namespace CompriaxSystem.WinFormsUI
{
    partial class FormSales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTopStatus = new System.Windows.Forms.Panel();
            this.lblPosTitle = new System.Windows.Forms.Label();
            this.lblCashierBadge = new System.Windows.Forms.Label();
            this.lblShiftBadge = new System.Windows.Forms.Label();
            this.pnlLeftWork = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlBarcodeBar = new System.Windows.Forms.Panel();
            this.lblScanIcon = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlShortcutsFooter = new System.Windows.Forms.Panel();
            this.lblShortcuts = new System.Windows.Forms.Label();
            this.pnlRightSummary = new System.Windows.Forms.Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalDisplay = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.btnToggleCam = new System.Windows.Forms.Button();

            this.pnlTopStatus.SuspendLayout();
            this.pnlLeftWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlBarcodeBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.pnlShortcutsFooter.SuspendLayout();
            this.pnlRightSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();

            // ==================== pnlTopStatus ====================
            this.pnlTopStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTopStatus.Controls.Add(this.lblPosTitle);
            this.pnlTopStatus.Controls.Add(this.lblCashierBadge);
            this.pnlTopStatus.Controls.Add(this.lblShiftBadge);
            this.pnlTopStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlTopStatus.Name = "pnlTopStatus";
            this.pnlTopStatus.Size = new System.Drawing.Size(1388, 52);
            this.pnlTopStatus.TabIndex = 0;

            // lblPosTitle
            this.lblPosTitle.AutoSize = true;
            this.lblPosTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPosTitle.ForeColor = System.Drawing.Color.White;
            this.lblPosTitle.Location = new System.Drawing.Point(16, 14);
            this.lblPosTitle.Name = "lblPosTitle";
            this.lblPosTitle.Size = new System.Drawing.Size(280, 25);
            this.lblPosTitle.TabIndex = 0;
            this.lblPosTitle.Text = "🛒 TERMINAL DE VENTAS (POS)";

            // lblCashierBadge
            this.lblCashierBadge.AutoSize = true;
            this.lblCashierBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCashierBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblCashierBadge.Location = new System.Drawing.Point(360, 18);
            this.lblCashierBadge.Name = "lblCashierBadge";
            this.lblCashierBadge.Size = new System.Drawing.Size(71, 17);
            this.lblCashierBadge.TabIndex = 1;
            this.lblCashierBadge.Text = "Cajero: --";

            // lblShiftBadge
            this.lblShiftBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftBadge.AutoSize = true;
            this.lblShiftBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblShiftBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblShiftBadge.Location = new System.Drawing.Point(1150, 18);
            this.lblShiftBadge.Name = "lblShiftBadge";
            this.lblShiftBadge.Size = new System.Drawing.Size(200, 17);
            this.lblShiftBadge.TabIndex = 2;
            this.lblShiftBadge.Text = "🟢 TURNO DE CAJA ACTIVO";

            // ==================== pnlLeftWork ====================
            this.pnlLeftWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlLeftWork.Controls.Add(this.dgvCart);
            this.pnlLeftWork.Controls.Add(this.pnlBarcodeBar);
            this.pnlLeftWork.Controls.Add(this.pnlShortcutsFooter);
            this.pnlLeftWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftWork.Location = new System.Drawing.Point(0, 52);
            this.pnlLeftWork.Name = "pnlLeftWork";
            this.pnlLeftWork.Padding = new System.Windows.Forms.Padding(16, 12, 8, 12);
            this.pnlLeftWork.Size = new System.Drawing.Size(1028, 702);
            this.pnlLeftWork.TabIndex = 1;

            // ==================== pnlBarcodeBar ====================
            this.pnlBarcodeBar.BackColor = System.Drawing.Color.White;
            this.pnlBarcodeBar.Controls.Add(this.lblScanIcon);
            this.pnlBarcodeBar.Controls.Add(this.txtProductCode);
            this.pnlBarcodeBar.Controls.Add(this.numQuantity);
            this.pnlBarcodeBar.Controls.Add(this.btnAdd);
            this.pnlBarcodeBar.Controls.Add(this.btnRemove);
            this.pnlBarcodeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarcodeBar.Location = new System.Drawing.Point(16, 12);
            this.pnlBarcodeBar.Name = "pnlBarcodeBar";
            this.pnlBarcodeBar.Size = new System.Drawing.Size(1004, 56);
            this.pnlBarcodeBar.TabIndex = 0;

            // lblScanIcon
            this.lblScanIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblScanIcon.Location = new System.Drawing.Point(8, 12);
            this.lblScanIcon.Name = "lblScanIcon";
            this.lblScanIcon.Size = new System.Drawing.Size(50, 32);
            this.lblScanIcon.TabIndex = 0;
            this.lblScanIcon.Text = "🔎";

            // txtProductCode
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtProductCode.Location = new System.Drawing.Point(64, 12);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.PlaceholderText = "Escanear código de barras o ingresar manual [F2]...";
            this.txtProductCode.Size = new System.Drawing.Size(457, 31);
            this.txtProductCode.TabIndex = 1;

            // numQuantity
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.numQuantity.Location = new System.Drawing.Point(527, 12);
            this.numQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(85, 31);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(638, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(169, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+ AGREGAR";
            this.btnAdd.UseVisualStyleBackColor = false;

            // btnRemove
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(813, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(177, 38);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "✕ QUITAR [SUPR]";
            this.btnRemove.UseVisualStyleBackColor = false;

            // ==================== dgvCart ====================
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(16, 68);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(1004, 586);
            this.dgvCart.TabIndex = 1;

            // ==================== pnlShortcutsFooter ====================
            this.pnlShortcutsFooter.Controls.Add(this.lblShortcuts);
            this.pnlShortcutsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlShortcutsFooter.Location = new System.Drawing.Point(16, 654);
            this.pnlShortcutsFooter.Name = "pnlShortcutsFooter";
            this.pnlShortcutsFooter.Size = new System.Drawing.Size(1004, 36);
            this.pnlShortcutsFooter.TabIndex = 2;

            // lblShortcuts
            this.lblShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcuts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblShortcuts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblShortcuts.Location = new System.Drawing.Point(0, 0);
            this.lblShortcuts.Name = "lblShortcuts";
            this.lblShortcuts.Size = new System.Drawing.Size(1004, 36);
            this.lblShortcuts.TabIndex = 0;
            this.lblShortcuts.Text = "⌨ ATAJOS: [F2] Buscar | [F3] Cliente | [F4] Cantidad | [F8] Cobrar | [SUPR] Quitar | [ESC] Cancelar";
            this.lblShortcuts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ==================== pnlRightSummary ====================
            this.pnlRightSummary.BackColor = System.Drawing.Color.White;
            this.pnlRightSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlRightSummary.Controls.Add(this.lblCustomerInfo);
            this.pnlRightSummary.Controls.Add(this.btnSelectCustomer);
            this.pnlRightSummary.Controls.Add(this.cboDocType);
            this.pnlRightSummary.Controls.Add(this.lblSubTotal);
            this.pnlRightSummary.Controls.Add(this.lblDiscount);
            this.pnlRightSummary.Controls.Add(this.lblTotalTitle);
            this.pnlRightSummary.Controls.Add(this.lblTotalDisplay);
            this.pnlRightSummary.Controls.Add(this.btnRegister);
            this.pnlRightSummary.Controls.Add(this.picWebcam);
            this.pnlRightSummary.Controls.Add(this.btnToggleCam);
            this.pnlRightSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightSummary.Location = new System.Drawing.Point(1028, 52);
            this.pnlRightSummary.Name = "pnlRightSummary";
            this.pnlRightSummary.Padding = new System.Windows.Forms.Padding(16);
            this.pnlRightSummary.Size = new System.Drawing.Size(360, 702);
            this.pnlRightSummary.TabIndex = 2;

            // lblSummaryTitle
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(16, 16);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(186, 25);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "RESUMEN DE VENTA";

            // lblCustomerInfo
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerInfo.Location = new System.Drawing.Point(16, 52);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(220, 24);
            this.lblCustomerInfo.TabIndex = 1;
            this.lblCustomerInfo.Text = "Cliente: Consumidor Final";

            // btnSelectCustomer
            this.btnSelectCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSelectCustomer.Location = new System.Drawing.Point(240, 48);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(104, 30);
            this.btnSelectCustomer.TabIndex = 2;
            this.btnSelectCustomer.Text = "CAMBIAR [F3]";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;

            // cboDocType
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDocType.Location = new System.Drawing.Point(16, 88);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(328, 25);
            this.cboDocType.TabIndex = 3;

            // lblSubTotal
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubTotal.Location = new System.Drawing.Point(16, 135);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(328, 25);
            this.lblSubTotal.TabIndex = 4;
            this.lblSubTotal.Text = "Subtotal: $ 0,00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblDiscount
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblDiscount.Location = new System.Drawing.Point(16, 165);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(328, 25);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "Descuentos: -$ 0,00";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(16, 205);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(126, 20);
            this.lblTotalTitle.TabIndex = 6;
            this.lblTotalTitle.Text = "TOTAL A PAGAR";

            // lblTotalDisplay
            this.lblTotalDisplay.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTotalDisplay.Location = new System.Drawing.Point(16, 230);
            this.lblTotalDisplay.Name = "lblTotalDisplay";
            this.lblTotalDisplay.Size = new System.Drawing.Size(328, 55);
            this.lblTotalDisplay.TabIndex = 7;
            this.lblTotalDisplay.Text = "$ 0,00";
            this.lblTotalDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(16, 300);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(328, 64);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "💳 COBRAR (F8)";
            this.btnRegister.UseVisualStyleBackColor = false;

            // picWebcam
            this.picWebcam.BackColor = System.Drawing.Color.Black;
            this.picWebcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWebcam.Location = new System.Drawing.Point(16, 380);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(328, 140);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWebcam.TabIndex = 9;
            this.picWebcam.TabStop = false;

            // btnToggleCam
            this.btnToggleCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleCam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleCam.Location = new System.Drawing.Point(16, 528);
            this.btnToggleCam.Name = "btnToggleCam";
            this.btnToggleCam.Size = new System.Drawing.Size(328, 34);
            this.btnToggleCam.TabIndex = 10;
            this.btnToggleCam.Text = "📷 CÁMARA ESCÁNER";
            this.btnToggleCam.UseVisualStyleBackColor = true;

            // ==================== Form Properties ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1388, 754);
            this.Controls.Add(this.pnlLeftWork);
            this.Controls.Add(this.pnlRightSummary);
            this.Controls.Add(this.pnlTopStatus);
            this.KeyPreview = true;
            this.Name = "FormSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta POS - CompriaxSystem";

            this.pnlTopStatus.ResumeLayout(false);
            this.pnlTopStatus.PerformLayout();
            this.pnlLeftWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlBarcodeBar.ResumeLayout(false);
            this.pnlBarcodeBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.pnlShortcutsFooter.ResumeLayout(false);
            this.pnlRightSummary.ResumeLayout(false);
            this.pnlRightSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopStatus;
        private System.Windows.Forms.Label lblPosTitle;
        private System.Windows.Forms.Label lblCashierBadge;
        private System.Windows.Forms.Label lblShiftBadge;
        private System.Windows.Forms.Panel pnlLeftWork;
        private System.Windows.Forms.Panel pnlBarcodeBar;
        private System.Windows.Forms.Label lblScanIcon;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlShortcutsFooter;
        private System.Windows.Forms.Label lblShortcuts;
        private System.Windows.Forms.Panel pnlRightSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalDisplay;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Button btnToggleCam;
    }
}