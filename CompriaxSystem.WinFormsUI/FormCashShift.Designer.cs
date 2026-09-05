namespace CompriaxSystem.WinFormsUI
{
    partial class FormCashShift
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlOpenShift = new Panel();
            lblOpenTitle = new Label();
            lblInitialCash = new Label();
            numInitialCash = new NumericUpDown();
            btnOpenShift = new Button();
            pnlActiveShift = new Panel();
            lblShiftStatus = new Label();
            lblFondoInicialVal = new Label();
            lblVentasEfectivoVal = new Label();
            lblVentasTarjetasVal = new Label();
            lblTotalFacturadoVal = new Label();
            lblEfectivoEsperadoVal = new Label();
            btnCashIn = new Button();
            btnCashOut = new Button();
            btnPrintX = new Button();
            btnCloseShiftZ = new Button();
            pnlMovements = new Panel();
            dgvMovements = new DataGridView();
            lblMovementsTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlOpenShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInitialCash).BeginInit();
            pnlActiveShift.SuspendLayout();
            pnlMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1271, 56);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(525, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💵 CONTROL Y ARQUEO DE CAJA (CIERRES X / Z)";

            // pnlOpenShift
            pnlOpenShift.BackColor = Color.White;
            pnlOpenShift.Controls.Add(lblOpenTitle);
            pnlOpenShift.Controls.Add(lblInitialCash);
            pnlOpenShift.Controls.Add(numInitialCash);
            pnlOpenShift.Controls.Add(btnOpenShift);
            pnlOpenShift.Location = new Point(16, 72);
            pnlOpenShift.Name = "pnlOpenShift";
            pnlOpenShift.Size = new Size(1100, 160);
            pnlOpenShift.TabIndex = 1;
            pnlOpenShift.Visible = false;

            // lblOpenTitle
            lblOpenTitle.AutoSize = true;
            lblOpenTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOpenTitle.Location = new Point(20, 16);
            lblOpenTitle.Name = "lblOpenTitle";
            lblOpenTitle.Size = new Size(387, 25);
            lblOpenTitle.TabIndex = 0;
            lblOpenTitle.Text = "🚪 APERTURA DE NUEVO TURNO DE CAJA";

            // lblInitialCash
            lblInitialCash.AutoSize = true;
            lblInitialCash.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInitialCash.Location = new Point(20, 56);
            lblInitialCash.Name = "lblInitialCash";
            lblInitialCash.Size = new Size(313, 21);
            lblInitialCash.TabIndex = 1;
            lblInitialCash.Text = "Fondo Inicial de Cambio en Efectivo ($):";

            // numInitialCash
            this.numInitialCash.DecimalPlaces = 2;
            this.numInitialCash.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.numInitialCash.Location = new System.Drawing.Point(20, 84);
            this.numInitialCash.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numInitialCash.Minimum = new decimal(new int[] { 100000000, 0, 0, -2147483648 });
            this.numInitialCash.Name = "numInitialCash";
            this.numInitialCash.Size = new System.Drawing.Size(300, 39);
            this.numInitialCash.TabIndex = 2;

            // btnOpenShift
            btnOpenShift.BackColor = Color.FromArgb(16, 185, 129);
            btnOpenShift.FlatAppearance.BorderSize = 0;
            btnOpenShift.FlatStyle = FlatStyle.Flat;
            btnOpenShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenShift.ForeColor = Color.White;
            btnOpenShift.Location = new Point(340, 80);
            btnOpenShift.Name = "btnOpenShift";
            btnOpenShift.Size = new Size(260, 44);
            btnOpenShift.TabIndex = 3;
            btnOpenShift.Text = "✓ ABRIR TURNO DE CAJA";
            btnOpenShift.UseVisualStyleBackColor = false;

            // pnlActiveShift
            pnlActiveShift.BackColor = Color.White;
            pnlActiveShift.Controls.Add(lblShiftStatus);
            pnlActiveShift.Controls.Add(lblFondoInicialVal);
            pnlActiveShift.Controls.Add(lblVentasEfectivoVal);
            pnlActiveShift.Controls.Add(lblVentasTarjetasVal);
            pnlActiveShift.Controls.Add(lblTotalFacturadoVal);
            pnlActiveShift.Controls.Add(lblEfectivoEsperadoVal);
            pnlActiveShift.Controls.Add(btnCashIn);
            pnlActiveShift.Controls.Add(btnCashOut);
            pnlActiveShift.Controls.Add(btnPrintX);
            pnlActiveShift.Controls.Add(btnCloseShiftZ);
            pnlActiveShift.Location = new Point(16, 72);
            pnlActiveShift.Name = "pnlActiveShift";
            pnlActiveShift.Size = new Size(1236, 250);
            pnlActiveShift.TabIndex = 2;

            // lblShiftStatus
            lblShiftStatus.AutoSize = true;
            lblShiftStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblShiftStatus.ForeColor = Color.FromArgb(16, 185, 129);
            lblShiftStatus.Location = new Point(15, 16);
            lblShiftStatus.Name = "lblShiftStatus";
            lblShiftStatus.Size = new Size(292, 28);
            lblShiftStatus.TabIndex = 0;
            lblShiftStatus.Text = "🟢 TURNO DE CAJA ABIERTO";

            // lblFondoInicialVal
            lblFondoInicialVal.AutoSize = true;
            lblFondoInicialVal.Font = new Font("Segoe UI", 9.5F);
            lblFondoInicialVal.Location = new Point(20, 55);
            lblFondoInicialVal.Name = "lblFondoInicialVal";
            lblFondoInicialVal.Size = new Size(148, 21);
            lblFondoInicialVal.TabIndex = 1;
            lblFondoInicialVal.Text = "Fondo Inicial: $ 0,00";

            // lblVentasEfectivoVal
            lblVentasEfectivoVal.AutoSize = true;
            lblVentasEfectivoVal.Font = new Font("Segoe UI", 9.5F);
            lblVentasEfectivoVal.Location = new Point(20, 88);
            lblVentasEfectivoVal.Name = "lblVentasEfectivoVal";
            lblVentasEfectivoVal.Size = new Size(185, 21);
            lblVentasEfectivoVal.TabIndex = 2;
            lblVentasEfectivoVal.Text = "Ventas en Efectivo: $ 0,00";

            // lblVentasTarjetasVal
            lblVentasTarjetasVal.AutoSize = true;
            lblVentasTarjetasVal.Font = new Font("Segoe UI", 9.5F);
            lblVentasTarjetasVal.Location = new Point(20, 121);
            lblVentasTarjetasVal.Name = "lblVentasTarjetasVal";
            lblVentasTarjetasVal.Size = new Size(204, 21);
            lblVentasTarjetasVal.TabIndex = 3;
            lblVentasTarjetasVal.Text = "Tarjetas / QR / Transf: $ 0,00";

            // lblTotalFacturadoVal
            lblTotalFacturadoVal.AutoSize = true;
            lblTotalFacturadoVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalFacturadoVal.Location = new Point(20, 154);
            lblTotalFacturadoVal.Name = "lblTotalFacturadoVal";
            lblTotalFacturadoVal.Size = new Size(251, 21);
            lblTotalFacturadoVal.TabIndex = 4;
            lblTotalFacturadoVal.Text = "Total Facturado en Turno: $ 0,00";

            // lblEfectivoEsperadoVal
            lblEfectivoEsperadoVal.AutoSize = true;
            lblEfectivoEsperadoVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEfectivoEsperadoVal.ForeColor = Color.FromArgb(2, 132, 199);
            lblEfectivoEsperadoVal.Location = new Point(20, 195);
            lblEfectivoEsperadoVal.Name = "lblEfectivoEsperadoVal";
            lblEfectivoEsperadoVal.Size = new Size(287, 28);
            lblEfectivoEsperadoVal.TabIndex = 5;
            lblEfectivoEsperadoVal.Text = "EFECTIVO EN GAVETA: $ 0,00";

            // btnCashIn
            btnCashIn.BackColor = Color.FromArgb(2, 132, 199);
            btnCashIn.FlatAppearance.BorderSize = 0;
            btnCashIn.FlatStyle = FlatStyle.Flat;
            btnCashIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCashIn.ForeColor = Color.White;
            btnCashIn.Location = new Point(672, 12);
            btnCashIn.Name = "btnCashIn";
            btnCashIn.Size = new Size(240, 65);
            btnCashIn.TabIndex = 6;
            btnCashIn.Text = "➕ INGRESO MANUAL";
            btnCashIn.UseVisualStyleBackColor = false;

            // btnCashOut
            btnCashOut.FlatStyle = FlatStyle.Flat;
            btnCashOut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCashOut.Location = new Point(672, 88);
            btnCashOut.Name = "btnCashOut";
            btnCashOut.Size = new Size(240, 69);
            btnCashOut.TabIndex = 7;
            btnCashOut.Text = "➖ RETIRO / GASTO";
            btnCashOut.UseVisualStyleBackColor = true;

            // btnPrintX
            btnPrintX.FlatStyle = FlatStyle.Flat;
            btnPrintX.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrintX.Location = new Point(672, 166);
            btnPrintX.Name = "btnPrintX";
            btnPrintX.Size = new Size(240, 68);
            btnPrintX.TabIndex = 8;
            btnPrintX.Text = "📄 CIERRE PARCIAL (X)";
            btnPrintX.UseVisualStyleBackColor = true;

            // btnCloseShiftZ
            btnCloseShiftZ.BackColor = Color.FromArgb(239, 68, 68);
            btnCloseShiftZ.FlatAppearance.BorderSize = 0;
            btnCloseShiftZ.FlatStyle = FlatStyle.Flat;
            btnCloseShiftZ.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCloseShiftZ.ForeColor = Color.White;
            btnCloseShiftZ.Location = new Point(929, 12);
            btnCloseShiftZ.Name = "btnCloseShiftZ";
            btnCloseShiftZ.Size = new Size(291, 222);
            btnCloseShiftZ.TabIndex = 9;
            btnCloseShiftZ.Text = "🔒 CERRAR TURNO\r\nY ARQUEO (Z)";
            btnCloseShiftZ.UseVisualStyleBackColor = false;

            // pnlMovements
            pnlMovements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMovements.Controls.Add(dgvMovements);
            pnlMovements.Controls.Add(lblMovementsTitle);
            pnlMovements.Location = new Point(16, 325);
            pnlMovements.Name = "pnlMovements";
            pnlMovements.Size = new Size(1236, 340);
            pnlMovements.TabIndex = 3;

            // dgvMovements
            dgvMovements.BackgroundColor = Color.White;
            dgvMovements.BorderStyle = BorderStyle.None;
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovements.Dock = DockStyle.Fill;
            dgvMovements.Location = new Point(0, 30);
            dgvMovements.Name = "dgvMovements";
            dgvMovements.RowHeadersWidth = 51;
            dgvMovements.Size = new Size(1236, 310);
            dgvMovements.TabIndex = 1;

            // lblMovementsTitle
            lblMovementsTitle.Dock = DockStyle.Top;
            lblMovementsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMovementsTitle.Location = new Point(0, 0);
            lblMovementsTitle.Name = "lblMovementsTitle";
            lblMovementsTitle.Size = new Size(1236, 30);
            lblMovementsTitle.TabIndex = 0;
            lblMovementsTitle.Text = "Movimientos Manuales Registrados en el Turno:";

            // FormCashShift
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1271, 680);
            Controls.Add(pnlMovements);
            Controls.Add(pnlActiveShift);
            Controls.Add(pnlOpenShift);
            Controls.Add(pnlHeader);
            Name = "FormCashShift";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control y Arqueo de Caja";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlOpenShift.ResumeLayout(false);
            pnlOpenShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numInitialCash).EndInit();
            pnlActiveShift.ResumeLayout(false);
            pnlActiveShift.PerformLayout();
            pnlMovements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlOpenShift;
        private System.Windows.Forms.Label lblOpenTitle;
        private System.Windows.Forms.Label lblInitialCash;
        private System.Windows.Forms.NumericUpDown numInitialCash;
        private System.Windows.Forms.Button btnOpenShift;
        private System.Windows.Forms.Panel pnlActiveShift;
        private System.Windows.Forms.Label lblShiftStatus;
        private System.Windows.Forms.Label lblFondoInicialVal;
        private System.Windows.Forms.Label lblVentasEfectivoVal;
        private System.Windows.Forms.Label lblVentasTarjetasVal;
        private System.Windows.Forms.Label lblTotalFacturadoVal;
        private System.Windows.Forms.Label lblEfectivoEsperadoVal;
        private System.Windows.Forms.Button btnCashIn;
        private System.Windows.Forms.Button btnCashOut;
        private System.Windows.Forms.Button btnPrintX;
        private System.Windows.Forms.Button btnCloseShiftZ;
        private System.Windows.Forms.Panel pnlMovements;
        private System.Windows.Forms.Label lblMovementsTitle;
        private System.Windows.Forms.DataGridView dgvMovements;
    }
}