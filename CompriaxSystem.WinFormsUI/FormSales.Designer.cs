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
            this.quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlShortcutsFooter = new System.Windows.Forms.Panel();
            this.lblShortcuts = new System.Windows.Forms.Label();
            this.pnlRightSummary = new System.Windows.Forms.Panel();
            this.pnlVoucherCard = new System.Windows.Forms.Panel();
            this.lblVoucherHeader = new System.Windows.Forms.Label();
            this.lblVoucherLetter = new System.Windows.Forms.Label();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.lblVoucherNumber = new System.Windows.Forms.Label();
            this.lblClientNameVal = new System.Windows.Forms.Label();
            this.lblClientDocVal = new System.Windows.Forms.Label();
            this.lblClientTaxVal = new System.Windows.Forms.Label();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
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
            this.pnlVoucherCard.SuspendLayout();
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
            this.lblPosTitle.Text = "TERMINAL DE VENTAS (POS)";

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
            this.lblShiftBadge.Text = "TURNO DE CAJA ACTIVO";

            // ==================== pnlLeftWork ====================
            this.pnlLeftWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlLeftWork.Controls.Add(this.dgvCart);
            this.pnlLeftWork.Controls.Add(this.pnlBarcodeBar);
            this.pnlLeftWork.Controls.Add(this.pnlShortcutsFooter);
            this.pnlLeftWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftWork.Location = new System.Drawing.Point(0, 52);
            this.pnlLeftWork.Name = "pnlLeftWork";
            this.pnlLeftWork.Padding = new System.Windows.Forms.Padding(16, 12, 8, 12);
            this.pnlLeftWork.Size = new System.Drawing.Size(1008, 702);
            this.pnlLeftWork.TabIndex = 1;

            // ==================== pnlBarcodeBar (Buscador Predictivo) ====================
            this.pnlBarcodeBar.BackColor = System.Drawing.Color.White;
            this.pnlBarcodeBar.Controls.Add(this.quickSearchBox);
            this.pnlBarcodeBar.Controls.Add(this.numQuantity);
            this.pnlBarcodeBar.Controls.Add(this.btnRemove);
            this.pnlBarcodeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarcodeBar.Location = new System.Drawing.Point(16, 12);
            this.pnlBarcodeBar.Name = "pnlBarcodeBar";
            this.pnlBarcodeBar.Size = new System.Drawing.Size(984, 56);
            this.pnlBarcodeBar.TabIndex = 0;

            // quickSearchBox (Reemplazo con Texto Sombra y Desplegable)
            this.quickSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.quickSearchBox.BackColor = System.Drawing.Color.White;
            this.quickSearchBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.quickSearchBox.Location = new System.Drawing.Point(10, 9);
            this.quickSearchBox.Name = "quickSearchBox";
            this.quickSearchBox.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.quickSearchBox.PlaceholderText = "Buscar por nombre, código de barras o descripción [F2]...";
            this.quickSearchBox.Size = new System.Drawing.Size(710, 38);
            this.quickSearchBox.TabIndex = 0;

            // numQuantity
            this.numQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.numQuantity.Location = new System.Drawing.Point(730, 12);
            this.numQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(85, 31);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnRemove
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(825, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 38);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "QUITAR [SUPR]";
            this.btnRemove.UseVisualStyleBackColor = false;

            // ==================== dgvCart ====================
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(16, 68);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(984, 586);
            this.dgvCart.TabIndex = 1;

            // ==================== pnlShortcutsFooter ====================
            this.pnlShortcutsFooter.Controls.Add(this.lblShortcuts);
            this.pnlShortcutsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlShortcutsFooter.Location = new System.Drawing.Point(16, 654);
            this.pnlShortcutsFooter.Name = "pnlShortcutsFooter";
            this.pnlShortcutsFooter.Size = new System.Drawing.Size(984, 36);
            this.pnlShortcutsFooter.TabIndex = 2;

            // lblShortcuts
            this.lblShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcuts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblShortcuts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblShortcuts.Location = new System.Drawing.Point(0, 0);
            this.lblShortcuts.Name = "lblShortcuts";
            this.lblShortcuts.Size = new System.Drawing.Size(984, 36);
            this.lblShortcuts.TabIndex = 0;
            this.lblShortcuts.Text = "ATAJOS: [F2] Buscar | [F3] Cliente | [F4] Cantidad | [F6] Ver Precio | [F8] Cobrar | [SUPR] Quitar | [ESC] Cancelar";
            this.lblShortcuts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ==================== pnlRightSummary ====================
            this.pnlRightSummary.BackColor = System.Drawing.Color.White;
            this.pnlRightSummary.Controls.Add(this.pnlVoucherCard);
            this.pnlRightSummary.Controls.Add(this.lblSubTotal);
            this.pnlRightSummary.Controls.Add(this.lblDiscount);
            this.pnlRightSummary.Controls.Add(this.lblTotalTitle);
            this.pnlRightSummary.Controls.Add(this.lblTotalDisplay);
            this.pnlRightSummary.Controls.Add(this.btnRegister);
            this.pnlRightSummary.Controls.Add(this.picWebcam);
            this.pnlRightSummary.Controls.Add(this.btnToggleCam);
            this.pnlRightSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightSummary.Location = new System.Drawing.Point(1008, 52);
            this.pnlRightSummary.Name = "pnlRightSummary";
            this.pnlRightSummary.Padding = new System.Windows.Forms.Padding(16);
            this.pnlRightSummary.Size = new System.Drawing.Size(380, 702);
            this.pnlRightSummary.TabIndex = 2;

            // ==================== pnlVoucherCard (Datos del Comprobante) ====================
            this.pnlVoucherCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlVoucherCard.Controls.Add(this.lblVoucherHeader);
            this.pnlVoucherCard.Controls.Add(this.lblVoucherLetter);
            this.pnlVoucherCard.Controls.Add(this.cboDocType);
            this.pnlVoucherCard.Controls.Add(this.lblVoucherNumber);
            this.pnlVoucherCard.Controls.Add(this.lblClientNameVal);
            this.pnlVoucherCard.Controls.Add(this.lblClientDocVal);
            this.pnlVoucherCard.Controls.Add(this.lblClientTaxVal);
            this.pnlVoucherCard.Controls.Add(this.btnSelectCustomer);
            this.pnlVoucherCard.Location = new System.Drawing.Point(16, 12);
            this.pnlVoucherCard.Name = "pnlVoucherCard";
            this.pnlVoucherCard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlVoucherCard.Size = new System.Drawing.Size(348, 198);
            this.pnlVoucherCard.TabIndex = 0;

            // lblVoucherHeader
            this.lblVoucherHeader.AutoSize = true;
            this.lblVoucherHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVoucherHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblVoucherHeader.Location = new System.Drawing.Point(10, 8);
            this.lblVoucherHeader.Name = "lblVoucherHeader";
            this.lblVoucherHeader.Size = new System.Drawing.Size(180, 17);
            this.lblVoucherHeader.TabIndex = 0;
            this.lblVoucherHeader.Text = "DATOS DEL COMPROBANTE";

            // lblVoucherLetter (Badge Letra Fiscal)
            this.lblVoucherLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblVoucherLetter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblVoucherLetter.ForeColor = System.Drawing.Color.White;
            this.lblVoucherLetter.Location = new System.Drawing.Point(10, 34);
            this.lblVoucherLetter.Name = "lblVoucherLetter";
            this.lblVoucherLetter.Size = new System.Drawing.Size(38, 36);
            this.lblVoucherLetter.TabIndex = 1;
            this.lblVoucherLetter.Text = "B";
            this.lblVoucherLetter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // cboDocType
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cboDocType.Location = new System.Drawing.Point(54, 37);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(284, 25);
            this.cboDocType.TabIndex = 2;

            // lblVoucherNumber
            this.lblVoucherNumber.AutoSize = true;
            this.lblVoucherNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVoucherNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.lblVoucherNumber.Location = new System.Drawing.Point(10, 76);
            this.lblVoucherNumber.Name = "lblVoucherNumber";
            this.lblVoucherNumber.Size = new System.Drawing.Size(161, 15);
            this.lblVoucherNumber.TabIndex = 3;
            this.lblVoucherNumber.Text = "P.V.: 0001 - N.°: 00000001";

            // lblClientNameVal
            this.lblClientNameVal.AutoEllipsis = true;
            this.lblClientNameVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientNameVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblClientNameVal.Location = new System.Drawing.Point(10, 102);
            this.lblClientNameVal.Name = "lblClientNameVal";
            this.lblClientNameVal.Size = new System.Drawing.Size(230, 20);
            this.lblClientNameVal.TabIndex = 4;
            this.lblClientNameVal.Text = "CONSUMIDOR FINAL";

            // lblClientDocVal
            this.lblClientDocVal.AutoEllipsis = true;
            this.lblClientDocVal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientDocVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClientDocVal.Location = new System.Drawing.Point(10, 124);
            this.lblClientDocVal.Name = "lblClientDocVal";
            this.lblClientDocVal.Size = new System.Drawing.Size(230, 18);
            this.lblClientDocVal.TabIndex = 5;
            this.lblClientDocVal.Text = "DOC: S/D";

            // lblClientTaxVal
            this.lblClientTaxVal.AutoEllipsis = true;
            this.lblClientTaxVal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientTaxVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClientTaxVal.Location = new System.Drawing.Point(10, 144);
            this.lblClientTaxVal.Name = "lblClientTaxVal";
            this.lblClientTaxVal.Size = new System.Drawing.Size(230, 18);
            this.lblClientTaxVal.TabIndex = 6;
            this.lblClientTaxVal.Text = "IVA: Consumidor Final";

            // btnSelectCustomer
            this.btnSelectCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSelectCustomer.Location = new System.Drawing.Point(244, 102);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(94, 60);
            this.btnSelectCustomer.TabIndex = 7;
            this.btnSelectCustomer.Text = "CLIENTE\r\n[F3]";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;

            // ==================== Totales y Cobro ====================
            // lblSubTotal
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubTotal.Location = new System.Drawing.Point(16, 218);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(348, 25);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "Subtotal: $ 0,00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblDiscount
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblDiscount.Location = new System.Drawing.Point(16, 246);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(348, 25);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Descuentos: -$ 0,00";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(16, 276);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(126, 20);
            this.lblTotalTitle.TabIndex = 3;
            this.lblTotalTitle.Text = "TOTAL A PAGAR";

            // lblTotalDisplay
            this.lblTotalDisplay.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTotalDisplay.Location = new System.Drawing.Point(16, 298);
            this.lblTotalDisplay.Name = "lblTotalDisplay";
            this.lblTotalDisplay.Size = new System.Drawing.Size(348, 55);
            this.lblTotalDisplay.TabIndex = 4;
            this.lblTotalDisplay.Text = "$ 0,00";
            this.lblTotalDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(16, 360);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(348, 64);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "COBRAR (F8)";
            this.btnRegister.UseVisualStyleBackColor = false;

            // picWebcam
            this.picWebcam.BackColor = System.Drawing.Color.Black;
            this.picWebcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWebcam.Location = new System.Drawing.Point(16, 435);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(348, 120);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWebcam.TabIndex = 6;
            this.picWebcam.TabStop = false;

            // btnToggleCam
            this.btnToggleCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleCam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleCam.Location = new System.Drawing.Point(16, 562);
            this.btnToggleCam.Name = "btnToggleCam";
            this.btnToggleCam.Size = new System.Drawing.Size(348, 34);
            this.btnToggleCam.TabIndex = 7;
            this.btnToggleCam.Text = "CÁMARA ESCÁNER";
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
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.pnlShortcutsFooter.ResumeLayout(false);
            this.pnlRightSummary.ResumeLayout(false);
            this.pnlRightSummary.PerformLayout();
            this.pnlVoucherCard.ResumeLayout(false);
            this.pnlVoucherCard.PerformLayout();
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
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlShortcutsFooter;
        private System.Windows.Forms.Label lblShortcuts;
        private System.Windows.Forms.Panel pnlRightSummary;
        private System.Windows.Forms.Panel pnlVoucherCard;
        private System.Windows.Forms.Label lblVoucherHeader;
        private System.Windows.Forms.Label lblVoucherLetter;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label lblVoucherNumber;
        private System.Windows.Forms.Label lblClientNameVal;
        private System.Windows.Forms.Label lblClientDocVal;
        private System.Windows.Forms.Label lblClientTaxVal;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalDisplay;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Button btnToggleCam;
    }
}