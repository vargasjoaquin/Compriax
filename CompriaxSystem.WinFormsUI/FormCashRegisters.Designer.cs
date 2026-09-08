namespace CompriaxSystem.WinFormsUI
{
    partial class FormCashRegisters
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
            pnlCard = new Panel();
            lblNumber = new Label();
            numNumber = new NumericUpDown();
            lblName = new Label();
            txtName = new TextBox();
            lblDesc = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnToggle = new Button();
            btnCancel = new Button();
            dgvRegisters = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1020, 56);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(491, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🖥ADMINISTRACIÓN DE CAJAS";

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblNumber);
            pnlCard.Controls.Add(numNumber);
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(txtName);
            pnlCard.Controls.Add(lblDesc);
            pnlCard.Controls.Add(txtDescription);
            pnlCard.Controls.Add(btnSave);
            pnlCard.Controls.Add(btnToggle);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(16, 72);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(340, 480);
            pnlCard.TabIndex = 1;

            // lblNumber
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNumber.Location = new Point(16, 16);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(171, 21);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "Número de Caja POS:";

            // numNumber
            numNumber.Font = new Font("Segoe UI", 10F);
            numNumber.Location = new Point(16, 38);
            numNumber.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNumber.Name = "numNumber";
            numNumber.Size = new Size(120, 30);
            numNumber.TabIndex = 1;
            numNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblName
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(16, 80);
            lblName.Name = "lblName";
            lblName.Size = new Size(196, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Nombre / Identificador:";

            // txtName
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(16, 102);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Ej: Caja 01 - Principal";
            txtName.Size = new Size(306, 30);
            txtName.TabIndex = 3;

            // lblDesc
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDesc.Location = new Point(16, 145);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(168, 21);
            lblDesc.TabIndex = 4;
            lblDesc.Text = "Ubicación / Detalles:";

            // txtDescription
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(16, 168);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(306, 60);
            txtDescription.TabIndex = 5;

            // btnSave
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(16, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(306, 44);
            btnSave.TabIndex = 6;
            btnSave.Text = "GUARDAR";
            btnSave.UseVisualStyleBackColor = false;

            // btnToggle
            btnToggle.BackColor = Color.FromArgb(2, 132, 199);
            btnToggle.Enabled = false;
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToggle.ForeColor = Color.White;
            btnToggle.Location = new Point(16, 305);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(306, 38);
            btnToggle.TabIndex = 7;
            btnToggle.Text = "ACTIVAR / DESACTIVAR";
            btnToggle.UseVisualStyleBackColor = false;

            // btnCancel
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(16, 355);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(306, 36);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = true;

            // dgvRegisters
            dgvRegisters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegisters.BackgroundColor = Color.White;
            dgvRegisters.BorderStyle = BorderStyle.None;
            dgvRegisters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegisters.Location = new Point(375, 72);
            dgvRegisters.Name = "dgvRegisters";
            dgvRegisters.RowHeadersWidth = 51;
            dgvRegisters.Size = new Size(630, 480);
            dgvRegisters.TabIndex = 2;

            // FormCashRegisters
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1020, 570);
            Controls.Add(dgvRegisters);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            Name = "FormCashRegisters";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Cajas";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegisters).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.NumericUpDown numNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvRegisters;
    }
}