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
            picIconOpenShift = new PictureBox();
            picIconRegisterCashIn = new PictureBox();
            picIconRegisterCashOut = new PictureBox();
            picIconPrintPartialCloseX = new PictureBox();
            picIconCloseShiftZ = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelOpenShift = new Panel();
            labelOpenTitle = new Label();
            labelInitialCash = new Label();
            numericUpDownInitialCash = new NumericUpDown();
            buttonOpenShift = new Button();
            panelActiveShift = new Panel();
            labelShiftStatus = new Label();
            labelInitialCashValue = new Label();
            labelCashSalesValue = new Label();
            labelCardSalesValue = new Label();
            labelTotalTurnoverValue = new Label();
            labelExpectedCashValue = new Label();
            buttonRegisterCashIn = new Button();
            buttonRegisterCashOut = new Button();
            buttonPrintPartialCloseX = new Button();
            buttonCloseShiftZ = new Button();
            panelMovements = new Panel();
            dataGridViewMovements = new DataGridView();
            labelMovementsTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)picIconOpenShift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintPartialCloseX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCloseShiftZ).BeginInit();
            panelHeader.SuspendLayout();
            panelOpenShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInitialCash).BeginInit();
            panelActiveShift.SuspendLayout();
            panelMovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovements).BeginInit();
            SuspendLayout();
            // 
            // picIconOpenShift
            // 
            picIconOpenShift.BackColor = Color.FromArgb(16, 185, 129);
            picIconOpenShift.Cursor = Cursors.Hand;
            picIconOpenShift.Image = Resources._092_exito;
            picIconOpenShift.Location = new Point(354, 92);
            picIconOpenShift.Name = "picIconOpenShift";
            picIconOpenShift.Size = new Size(20, 20);
            picIconOpenShift.SizeMode = PictureBoxSizeMode.Zoom;
            picIconOpenShift.TabIndex = 99;
            picIconOpenShift.TabStop = false;
            // 
            // picIconRegisterCashIn
            // 
            picIconRegisterCashIn.BackColor = Color.FromArgb(2, 132, 199);
            picIconRegisterCashIn.Cursor = Cursors.Hand;
            picIconRegisterCashIn.Image = Resources._075_ingreso_manual;
            picIconRegisterCashIn.Location = new Point(686, 16);
            picIconRegisterCashIn.Name = "picIconRegisterCashIn";
            picIconRegisterCashIn.Size = new Size(31, 60);
            picIconRegisterCashIn.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRegisterCashIn.TabIndex = 99;
            picIconRegisterCashIn.TabStop = false;
            // 
            // picIconRegisterCashOut
            // 
            picIconRegisterCashOut.BackColor = Color.FromArgb(255, 255, 255);
            picIconRegisterCashOut.Cursor = Cursors.Hand;
            picIconRegisterCashOut.Image = Resources._076_retiro_egreso;
            picIconRegisterCashOut.Location = new Point(696, 88);
            picIconRegisterCashOut.Name = "picIconRegisterCashOut";
            picIconRegisterCashOut.Size = new Size(31, 69);
            picIconRegisterCashOut.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRegisterCashOut.TabIndex = 99;
            picIconRegisterCashOut.TabStop = false;
            // 
            // picIconPrintPartialCloseX
            // 
            picIconPrintPartialCloseX.BackColor = Color.FromArgb(255, 255, 255);
            picIconPrintPartialCloseX.Cursor = Cursors.Hand;
            picIconPrintPartialCloseX.Image = Resources._082_imprimir;
            picIconPrintPartialCloseX.Location = new Point(672, 166);
            picIconPrintPartialCloseX.Name = "picIconPrintPartialCloseX";
            picIconPrintPartialCloseX.Size = new Size(45, 68);
            picIconPrintPartialCloseX.SizeMode = PictureBoxSizeMode.Zoom;
            picIconPrintPartialCloseX.TabIndex = 99;
            picIconPrintPartialCloseX.TabStop = false;
            // 
            // picIconCloseShiftZ
            // 
            picIconCloseShiftZ.BackColor = Color.FromArgb(239, 68, 68);
            picIconCloseShiftZ.Cursor = Cursors.Hand;
            picIconCloseShiftZ.Image = Resources._096_bloqueo_cierre;
            picIconCloseShiftZ.Location = new Point(948, 88);
            picIconCloseShiftZ.Name = "picIconCloseShiftZ";
            picIconCloseShiftZ.Size = new Size(47, 57);
            picIconCloseShiftZ.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCloseShiftZ.TabIndex = 99;
            picIconCloseShiftZ.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1271, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(488, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CONTROL Y ARQUEO DE CAJA (CIERRES X / Z)";
            // 
            // panelOpenShift
            // 
            panelOpenShift.BackColor = Color.White;
            panelOpenShift.Controls.Add(labelOpenTitle);
            panelOpenShift.Controls.Add(labelInitialCash);
            panelOpenShift.Controls.Add(numericUpDownInitialCash);
            panelOpenShift.Controls.Add(picIconOpenShift);
            panelOpenShift.Controls.Add(buttonOpenShift);
            panelOpenShift.Location = new Point(16, 72);
            panelOpenShift.Name = "panelOpenShift";
            panelOpenShift.Size = new Size(1100, 160);
            panelOpenShift.TabIndex = 1;
            panelOpenShift.Visible = false;
            // 
            // labelOpenTitle
            // 
            labelOpenTitle.AutoSize = true;
            labelOpenTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelOpenTitle.Location = new Point(20, 16);
            labelOpenTitle.Name = "labelOpenTitle";
            labelOpenTitle.Size = new Size(360, 25);
            labelOpenTitle.TabIndex = 0;
            labelOpenTitle.Text = "APERTURA DE NUEVO TURNO DE CAJA";
            // 
            // labelInitialCash
            // 
            labelInitialCash.AutoSize = true;
            labelInitialCash.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelInitialCash.Location = new Point(20, 56);
            labelInitialCash.Name = "labelInitialCash";
            labelInitialCash.Size = new Size(313, 21);
            labelInitialCash.TabIndex = 1;
            labelInitialCash.Text = "Fondo Inicial de Cambio en Efectivo ($):";
            // 
            // numericUpDownInitialCash
            // 
            numericUpDownInitialCash.DecimalPlaces = 2;
            numericUpDownInitialCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            numericUpDownInitialCash.Location = new Point(20, 84);
            numericUpDownInitialCash.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownInitialCash.Minimum = new decimal(new int[] { 100000000, 0, 0, int.MinValue });
            numericUpDownInitialCash.Name = "numericUpDownInitialCash";
            numericUpDownInitialCash.Size = new Size(300, 39);
            numericUpDownInitialCash.TabIndex = 2;
            // 
            // buttonOpenShift
            // 
            buttonOpenShift.BackColor = Color.FromArgb(16, 185, 129);
            buttonOpenShift.FlatAppearance.BorderSize = 0;
            buttonOpenShift.FlatStyle = FlatStyle.Flat;
            buttonOpenShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonOpenShift.ForeColor = Color.White;
            buttonOpenShift.Location = new Point(340, 80);
            buttonOpenShift.Name = "buttonOpenShift";
            buttonOpenShift.Size = new Size(260, 44);
            buttonOpenShift.TabIndex = 3;
            buttonOpenShift.Text = "ABRIR TURNO DE CAJA";
            buttonOpenShift.UseVisualStyleBackColor = false;
            // 
            // panelActiveShift
            // 
            panelActiveShift.BackColor = Color.White;
            panelActiveShift.Controls.Add(labelShiftStatus);
            panelActiveShift.Controls.Add(labelInitialCashValue);
            panelActiveShift.Controls.Add(labelCashSalesValue);
            panelActiveShift.Controls.Add(labelCardSalesValue);
            panelActiveShift.Controls.Add(labelTotalTurnoverValue);
            panelActiveShift.Controls.Add(labelExpectedCashValue);
            panelActiveShift.Controls.Add(picIconRegisterCashIn);
            panelActiveShift.Controls.Add(buttonRegisterCashIn);
            panelActiveShift.Controls.Add(picIconRegisterCashOut);
            panelActiveShift.Controls.Add(buttonRegisterCashOut);
            panelActiveShift.Controls.Add(picIconPrintPartialCloseX);
            panelActiveShift.Controls.Add(buttonPrintPartialCloseX);
            panelActiveShift.Controls.Add(picIconCloseShiftZ);
            panelActiveShift.Controls.Add(buttonCloseShiftZ);
            panelActiveShift.Location = new Point(16, 72);
            panelActiveShift.Name = "panelActiveShift";
            panelActiveShift.Size = new Size(1236, 250);
            panelActiveShift.TabIndex = 2;
            // 
            // labelShiftStatus
            // 
            labelShiftStatus.AutoSize = true;
            labelShiftStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelShiftStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelShiftStatus.Location = new Point(20, 16);
            labelShiftStatus.Name = "labelShiftStatus";
            labelShiftStatus.Size = new Size(258, 28);
            labelShiftStatus.TabIndex = 0;
            labelShiftStatus.Text = "TURNO DE CAJA ABIERTO";
            // 
            // labelInitialCashValue
            // 
            labelInitialCashValue.AutoSize = true;
            labelInitialCashValue.Font = new Font("Segoe UI", 9.5F);
            labelInitialCashValue.Location = new Point(20, 55);
            labelInitialCashValue.Name = "labelInitialCashValue";
            labelInitialCashValue.Size = new Size(148, 21);
            labelInitialCashValue.TabIndex = 1;
            labelInitialCashValue.Text = "Fondo Inicial: $ 0,00";
            // 
            // labelCashSalesValue
            // 
            labelCashSalesValue.AutoSize = true;
            labelCashSalesValue.Font = new Font("Segoe UI", 9.5F);
            labelCashSalesValue.Location = new Point(20, 88);
            labelCashSalesValue.Name = "labelCashSalesValue";
            labelCashSalesValue.Size = new Size(185, 21);
            labelCashSalesValue.TabIndex = 2;
            labelCashSalesValue.Text = "Ventas en Efectivo: $ 0,00";
            // 
            // labelCardSalesValue
            // 
            labelCardSalesValue.AutoSize = true;
            labelCardSalesValue.Font = new Font("Segoe UI", 9.5F);
            labelCardSalesValue.Location = new Point(20, 121);
            labelCardSalesValue.Name = "labelCardSalesValue";
            labelCardSalesValue.Size = new Size(204, 21);
            labelCardSalesValue.TabIndex = 3;
            labelCardSalesValue.Text = "Tarjetas / QR / Transf: $ 0,00";
            // 
            // labelTotalTurnoverValue
            // 
            labelTotalTurnoverValue.AutoSize = true;
            labelTotalTurnoverValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalTurnoverValue.Location = new Point(20, 154);
            labelTotalTurnoverValue.Name = "labelTotalTurnoverValue";
            labelTotalTurnoverValue.Size = new Size(251, 21);
            labelTotalTurnoverValue.TabIndex = 4;
            labelTotalTurnoverValue.Text = "Total Facturado en Turno: $ 0,00";
            // 
            // labelExpectedCashValue
            // 
            labelExpectedCashValue.AutoSize = true;
            labelExpectedCashValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelExpectedCashValue.ForeColor = Color.FromArgb(2, 132, 199);
            labelExpectedCashValue.Location = new Point(20, 195);
            labelExpectedCashValue.Name = "labelExpectedCashValue";
            labelExpectedCashValue.Size = new Size(287, 28);
            labelExpectedCashValue.TabIndex = 5;
            labelExpectedCashValue.Text = "EFECTIVO EN GAVETA: $ 0,00";
            // 
            // buttonRegisterCashIn
            // 
            buttonRegisterCashIn.BackColor = Color.FromArgb(2, 132, 199);
            buttonRegisterCashIn.FlatAppearance.BorderSize = 0;
            buttonRegisterCashIn.FlatStyle = FlatStyle.Flat;
            buttonRegisterCashIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonRegisterCashIn.ForeColor = Color.White;
            buttonRegisterCashIn.Location = new Point(672, 12);
            buttonRegisterCashIn.Name = "buttonRegisterCashIn";
            buttonRegisterCashIn.Size = new Size(240, 65);
            buttonRegisterCashIn.TabIndex = 6;
            buttonRegisterCashIn.Text = "INGRESO MANUAL";
            buttonRegisterCashIn.UseVisualStyleBackColor = false;
            // 
            // buttonRegisterCashOut
            // 
            buttonRegisterCashOut.FlatStyle = FlatStyle.Flat;
            buttonRegisterCashOut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonRegisterCashOut.Location = new Point(672, 88);
            buttonRegisterCashOut.Name = "buttonRegisterCashOut";
            buttonRegisterCashOut.Size = new Size(240, 69);
            buttonRegisterCashOut.TabIndex = 7;
            buttonRegisterCashOut.Text = "RETIRO / GASTO";
            buttonRegisterCashOut.UseVisualStyleBackColor = true;
            // 
            // buttonPrintPartialCloseX
            // 
            buttonPrintPartialCloseX.FlatStyle = FlatStyle.Flat;
            buttonPrintPartialCloseX.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonPrintPartialCloseX.Location = new Point(672, 166);
            buttonPrintPartialCloseX.Name = "buttonPrintPartialCloseX";
            buttonPrintPartialCloseX.Size = new Size(240, 68);
            buttonPrintPartialCloseX.TabIndex = 8;
            buttonPrintPartialCloseX.Text = "CIERRE PARCIAL (X)";
            buttonPrintPartialCloseX.UseVisualStyleBackColor = true;
            // 
            // buttonCloseShiftZ
            // 
            buttonCloseShiftZ.BackColor = Color.FromArgb(239, 68, 68);
            buttonCloseShiftZ.FlatAppearance.BorderSize = 0;
            buttonCloseShiftZ.FlatStyle = FlatStyle.Flat;
            buttonCloseShiftZ.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCloseShiftZ.ForeColor = Color.White;
            buttonCloseShiftZ.Location = new Point(929, 12);
            buttonCloseShiftZ.Name = "buttonCloseShiftZ";
            buttonCloseShiftZ.Size = new Size(291, 222);
            buttonCloseShiftZ.TabIndex = 9;
            buttonCloseShiftZ.Text = "CERRAR TURNO\r\nY ARQUEO (Z)";
            buttonCloseShiftZ.UseVisualStyleBackColor = false;
            // 
            // panelMovements
            // 
            panelMovements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMovements.Controls.Add(dataGridViewMovements);
            panelMovements.Controls.Add(labelMovementsTitle);
            panelMovements.Location = new Point(16, 325);
            panelMovements.Name = "panelMovements";
            panelMovements.Size = new Size(1236, 340);
            panelMovements.TabIndex = 3;
            // 
            // dataGridViewMovements
            // 
            dataGridViewMovements.BackgroundColor = Color.White;
            dataGridViewMovements.BorderStyle = BorderStyle.None;
            dataGridViewMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovements.Dock = DockStyle.Fill;
            dataGridViewMovements.Location = new Point(0, 30);
            dataGridViewMovements.Name = "dataGridViewMovements";
            dataGridViewMovements.RowHeadersWidth = 51;
            dataGridViewMovements.Size = new Size(1236, 310);
            dataGridViewMovements.TabIndex = 1;
            // 
            // labelMovementsTitle
            // 
            labelMovementsTitle.Dock = DockStyle.Top;
            labelMovementsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMovementsTitle.Location = new Point(0, 0);
            labelMovementsTitle.Name = "labelMovementsTitle";
            labelMovementsTitle.Size = new Size(1236, 30);
            labelMovementsTitle.TabIndex = 0;
            labelMovementsTitle.Text = "Movimientos Manuales Registrados en el Turno:";
            // 
            // FormCashShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1271, 680);
            Controls.Add(panelMovements);
            Controls.Add(panelActiveShift);
            Controls.Add(panelOpenShift);
            Controls.Add(panelHeader);
            Name = "FormCashShift";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control y Arqueo de Caja";
            ((System.ComponentModel.ISupportInitialize)picIconOpenShift).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintPartialCloseX).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCloseShiftZ).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelOpenShift.ResumeLayout(false);
            panelOpenShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInitialCash).EndInit();
            panelActiveShift.ResumeLayout(false);
            panelActiveShift.PerformLayout();
            panelMovements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelOpenShift;
        private System.Windows.Forms.Label labelOpenTitle;
        private System.Windows.Forms.Label labelInitialCash;
        private System.Windows.Forms.NumericUpDown numericUpDownInitialCash;
        private System.Windows.Forms.Button buttonOpenShift;
        private System.Windows.Forms.Panel panelActiveShift;
        private System.Windows.Forms.Label labelShiftStatus;
        private System.Windows.Forms.Label labelInitialCashValue;
        private System.Windows.Forms.Label labelCashSalesValue;
        private System.Windows.Forms.Label labelCardSalesValue;
        private System.Windows.Forms.Label labelTotalTurnoverValue;
        private System.Windows.Forms.Label labelExpectedCashValue;
        private System.Windows.Forms.Button buttonRegisterCashIn;
        private System.Windows.Forms.Button buttonRegisterCashOut;
        private System.Windows.Forms.Button buttonPrintPartialCloseX;
        private System.Windows.Forms.Button buttonCloseShiftZ;
        private System.Windows.Forms.Panel panelMovements;
        private System.Windows.Forms.Label labelMovementsTitle;
        private System.Windows.Forms.DataGridView dataGridViewMovements;
        private System.Windows.Forms.PictureBox picIconOpenShift;
        private System.Windows.Forms.PictureBox picIconRegisterCashIn;
        private System.Windows.Forms.PictureBox picIconRegisterCashOut;
        private System.Windows.Forms.PictureBox picIconPrintPartialCloseX;
        private System.Windows.Forms.PictureBox picIconCloseShiftZ;
    }
}
