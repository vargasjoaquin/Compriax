namespace CompriaxSystem.WinFormsUI
{
    partial class FormSelectCashRegister
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
            panelSelectionCard = new Panel();
            labelRegisterPrompt = new Label();
            comboBoxRegisterSelection = new ComboBox();
            labelRegisterStatusInfo = new Label();
            buttonConfirmSelection = new Button();
            buttonCancel = new Button();
            panelHeader.SuspendLayout();
            panelSelectionCard.SuspendLayout();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(440, 56);
            panelHeader.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(330, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "SELECCIONAR CAJA DE COBRO";

            // panelSelectionCard
            panelSelectionCard.BackColor = Color.White;
            panelSelectionCard.Controls.Add(labelRegisterPrompt);
            panelSelectionCard.Controls.Add(comboBoxRegisterSelection);
            panelSelectionCard.Controls.Add(labelRegisterStatusInfo);
            panelSelectionCard.Controls.Add(buttonConfirmSelection);
            panelSelectionCard.Controls.Add(buttonCancel);
            panelSelectionCard.Location = new Point(20, 72);
            panelSelectionCard.Name = "panelSelectionCard";
            panelSelectionCard.Size = new Size(400, 220);
            panelSelectionCard.TabIndex = 1;

            // labelRegisterPrompt
            labelRegisterPrompt.AutoSize = true;
            labelRegisterPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRegisterPrompt.Location = new Point(20, 16);
            labelRegisterPrompt.Name = "labelRegisterPrompt";
            labelRegisterPrompt.Size = new Size(239, 21);
            labelRegisterPrompt.TabIndex = 0;
            labelRegisterPrompt.Text = "Seleccionar Caja / Puesto POS:";

            // comboBoxRegisterSelection
            comboBoxRegisterSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRegisterSelection.Font = new Font("Segoe UI", 10.5F);
            comboBoxRegisterSelection.Location = new Point(20, 40);
            comboBoxRegisterSelection.Name = "comboBoxRegisterSelection";
            comboBoxRegisterSelection.Size = new Size(360, 31);
            comboBoxRegisterSelection.TabIndex = 1;

            // labelRegisterStatusInfo
            labelRegisterStatusInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRegisterStatusInfo.ForeColor = Color.FromArgb(16, 185, 129);
            labelRegisterStatusInfo.Location = new Point(20, 80);
            labelRegisterStatusInfo.Name = "labelRegisterStatusInfo";
            labelRegisterStatusInfo.Size = new Size(360, 22);
            labelRegisterStatusInfo.TabIndex = 2;
            labelRegisterStatusInfo.Text = "Caja disponible";

            // buttonConfirmSelection
            buttonConfirmSelection.BackColor = Color.FromArgb(16, 185, 129);
            buttonConfirmSelection.FlatAppearance.BorderSize = 0;
            buttonConfirmSelection.FlatStyle = FlatStyle.Flat;
            buttonConfirmSelection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonConfirmSelection.ForeColor = Color.White;
            buttonConfirmSelection.Location = new Point(20, 115);
            buttonConfirmSelection.Name = "buttonConfirmSelection";
            buttonConfirmSelection.Size = new Size(360, 44);
            buttonConfirmSelection.TabIndex = 3;
            buttonConfirmSelection.Text = "INGRESAR A LA CAJA";
            buttonConfirmSelection.UseVisualStyleBackColor = false;

            // buttonCancel
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.Location = new Point(20, 168);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(360, 34);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;

            // FormSelectCashRegister
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(440, 310);
            Controls.Add(panelSelectionCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSelectCashRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selección de Caja";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSelectionCard.ResumeLayout(false);
            panelSelectionCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelSelectionCard;
        private System.Windows.Forms.Label labelRegisterPrompt;
        private System.Windows.Forms.ComboBox comboBoxRegisterSelection;
        private System.Windows.Forms.Label labelRegisterStatusInfo;
        private System.Windows.Forms.Button buttonConfirmSelection;
        private System.Windows.Forms.Button buttonCancel;
    }
}