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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelCard = new Panel();
            labelRegisterNumber = new Label();
            numericUpDownRegisterNumber = new NumericUpDown();
            labelRegisterName = new Label();
            textBoxRegisterName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            buttonSave = new Button();
            buttonToggleStatus = new Button();
            buttonCancel = new Button();
            dataGridViewRegisters = new DataGridView();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRegisterNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegisters).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1020, 56);
            panelHeader.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(491, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "🖥ADMINISTRACIÓN DE CAJAS";

            // panelCard
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelRegisterNumber);
            panelCard.Controls.Add(numericUpDownRegisterNumber);
            panelCard.Controls.Add(labelRegisterName);
            panelCard.Controls.Add(textBoxRegisterName);
            panelCard.Controls.Add(labelDescription);
            panelCard.Controls.Add(textBoxDescription);
            panelCard.Controls.Add(buttonSave);
            panelCard.Controls.Add(buttonToggleStatus);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 72);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(340, 480);
            panelCard.TabIndex = 1;

            // labelRegisterNumber
            labelRegisterNumber.AutoSize = true;
            labelRegisterNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRegisterNumber.Location = new Point(16, 16);
            labelRegisterNumber.Name = "labelRegisterNumber";
            labelRegisterNumber.Size = new Size(171, 21);
            labelRegisterNumber.TabIndex = 0;
            labelRegisterNumber.Text = "Número de Caja POS:";

            // numericUpDownRegisterNumber
            numericUpDownRegisterNumber.Font = new Font("Segoe UI", 10F);
            numericUpDownRegisterNumber.Location = new Point(16, 38);
            numericUpDownRegisterNumber.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownRegisterNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRegisterNumber.Name = "numericUpDownRegisterNumber";
            numericUpDownRegisterNumber.Size = new Size(120, 30);
            numericUpDownRegisterNumber.TabIndex = 1;
            numericUpDownRegisterNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // labelRegisterName
            labelRegisterName.AutoSize = true;
            labelRegisterName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRegisterName.Location = new Point(16, 80);
            labelRegisterName.Name = "labelRegisterName";
            labelRegisterName.Size = new Size(196, 21);
            labelRegisterName.TabIndex = 2;
            labelRegisterName.Text = "Nombre / Identificador:";

            // textBoxRegisterName
            textBoxRegisterName.BorderStyle = BorderStyle.FixedSingle;
            textBoxRegisterName.Font = new Font("Segoe UI", 10F);
            textBoxRegisterName.Location = new Point(16, 102);
            textBoxRegisterName.Name = "textBoxRegisterName";
            textBoxRegisterName.PlaceholderText = "Ej: Caja 01 - Principal";
            textBoxRegisterName.Size = new Size(306, 30);
            textBoxRegisterName.TabIndex = 3;

            // labelDescription
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(16, 145);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(168, 21);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "Ubicación / Detalles:";

            // textBoxDescription
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(16, 168);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(306, 60);
            textBoxDescription.TabIndex = 5;

            // buttonSave
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(16, 250);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(306, 44);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;

            // buttonToggleStatus
            buttonToggleStatus.BackColor = Color.FromArgb(2, 132, 199);
            buttonToggleStatus.Enabled = false;
            buttonToggleStatus.FlatAppearance.BorderSize = 0;
            buttonToggleStatus.FlatStyle = FlatStyle.Flat;
            buttonToggleStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleStatus.ForeColor = Color.White;
            buttonToggleStatus.Location = new Point(16, 305);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Size = new Size(306, 38);
            buttonToggleStatus.TabIndex = 7;
            buttonToggleStatus.Text = "ACTIVAR / DESACTIVAR";
            buttonToggleStatus.UseVisualStyleBackColor = false;

            // buttonCancel
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.Location = new Point(16, 355);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(306, 36);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;

            // dataGridViewRegisters
            dataGridViewRegisters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRegisters.BackgroundColor = Color.White;
            dataGridViewRegisters.BorderStyle = BorderStyle.None;
            dataGridViewRegisters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRegisters.Location = new Point(375, 72);
            dataGridViewRegisters.Name = "dataGridViewRegisters";
            dataGridViewRegisters.RowHeadersWidth = 51;
            dataGridViewRegisters.Size = new Size(630, 480);
            dataGridViewRegisters.TabIndex = 2;

            // FormCashRegisters
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1020, 570);
            Controls.Add(dataGridViewRegisters);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Name = "FormCashRegisters";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Cajas";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRegisterNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegisters).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelRegisterNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownRegisterNumber;
        private System.Windows.Forms.Label labelRegisterName;
        private System.Windows.Forms.TextBox textBoxRegisterName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonToggleStatus;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewRegisters;
    }
}