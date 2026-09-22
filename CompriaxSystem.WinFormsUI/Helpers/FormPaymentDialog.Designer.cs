namespace CompriaxSystem.WinFormsUI.Helpers
{
    partial class FormPaymentDialog
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
            picIconConfirmPayment = new PictureBox();
            picIconCancel = new PictureBox();
            panelTotalHeader = new Panel();
            labelTotalTitle = new Label();
            labelTotalValue = new Label();
            labelPaymentMethodPrompt = new Label();
            comboBoxPaymentMethod = new ComboBox();
            labelAmountPaidPrompt = new Label();
            numericUpDownAmountPaid = new NumericUpDown();
            flowLayoutPanelQuickBills = new FlowLayoutPanel();
            buttonAdd1000 = new Button();
            buttonAdd2000 = new Button();
            buttonAdd5000 = new Button();
            buttonAdd10000 = new Button();
            buttonAdd20000 = new Button();
            buttonExactAmount = new Button();
            panelChangeSummary = new Panel();
            labelChangeTitle = new Label();
            labelChangeAmount = new Label();
            buttonCancel = new Button();
            buttonConfirmPayment = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconConfirmPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelTotalHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmountPaid).BeginInit();
            flowLayoutPanelQuickBills.SuspendLayout();
            panelChangeSummary.SuspendLayout();
            SuspendLayout();
            // 
            // picIconConfirmPayment
            // 
            picIconConfirmPayment.BackColor = Color.FromArgb(16, 185, 129);
            picIconConfirmPayment.Cursor = Cursors.Hand;
            picIconConfirmPayment.Image = Resources._092_exito;
            picIconConfirmPayment.Location = new Point(225, 455);
            picIconConfirmPayment.Name = "picIconConfirmPayment";
            picIconConfirmPayment.Size = new Size(36, 48);
            picIconConfirmPayment.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirmPayment.TabIndex = 99;
            picIconConfirmPayment.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.FromArgb(239, 68, 68);
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Resources._093_error;
            picIconCancel.Location = new Point(37, 455);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(36, 48);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // panelTotalHeader
            // 
            panelTotalHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelTotalHeader.Controls.Add(labelTotalTitle);
            panelTotalHeader.Controls.Add(labelTotalValue);
            panelTotalHeader.Dock = DockStyle.Top;
            panelTotalHeader.Location = new Point(0, 0);
            panelTotalHeader.Name = "panelTotalHeader";
            panelTotalHeader.Size = new Size(504, 110);
            panelTotalHeader.TabIndex = 0;
            // 
            // labelTotalTitle
            // 
            labelTotalTitle.AutoSize = true;
            labelTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalTitle.ForeColor = Color.FromArgb(148, 163, 184);
            labelTotalTitle.Location = new Point(20, 15);
            labelTotalTitle.Name = "labelTotalTitle";
            labelTotalTitle.Size = new Size(166, 25);
            labelTotalTitle.TabIndex = 0;
            labelTotalTitle.Text = "TOTAL A COBRAR";
            // 
            // labelTotalValue
            // 
            labelTotalValue.AutoSize = true;
            labelTotalValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTotalValue.ForeColor = Color.White;
            labelTotalValue.Location = new Point(20, 40);
            labelTotalValue.Name = "labelTotalValue";
            labelTotalValue.Size = new Size(137, 54);
            labelTotalValue.TabIndex = 1;
            labelTotalValue.Text = "$ 0,00";
            // 
            // labelPaymentMethodPrompt
            // 
            labelPaymentMethodPrompt.AutoSize = true;
            labelPaymentMethodPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPaymentMethodPrompt.Location = new Point(25, 130);
            labelPaymentMethodPrompt.Name = "labelPaymentMethodPrompt";
            labelPaymentMethodPrompt.Size = new Size(129, 21);
            labelPaymentMethodPrompt.TabIndex = 1;
            labelPaymentMethodPrompt.Text = "Medio de Pago:";
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethod.Font = new Font("Segoe UI", 11F);
            comboBoxPaymentMethod.Location = new Point(25, 155);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(450, 33);
            comboBoxPaymentMethod.TabIndex = 2;
            // 
            // labelAmountPaidPrompt
            // 
            labelAmountPaidPrompt.AutoSize = true;
            labelAmountPaidPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAmountPaidPrompt.Location = new Point(25, 205);
            labelAmountPaidPrompt.Name = "labelAmountPaidPrompt";
            labelAmountPaidPrompt.Size = new Size(247, 21);
            labelAmountPaidPrompt.TabIndex = 3;
            labelAmountPaidPrompt.Text = "Monto Recibido del Cliente ($):";
            // 
            // numericUpDownAmountPaid
            // 
            numericUpDownAmountPaid.DecimalPlaces = 2;
            numericUpDownAmountPaid.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            numericUpDownAmountPaid.Location = new Point(25, 230);
            numericUpDownAmountPaid.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownAmountPaid.Name = "numericUpDownAmountPaid";
            numericUpDownAmountPaid.Size = new Size(450, 43);
            numericUpDownAmountPaid.TabIndex = 4;
            // 
            // flowLayoutPanelQuickBills
            // 
            flowLayoutPanelQuickBills.BackColor = Color.Transparent;
            flowLayoutPanelQuickBills.Controls.Add(buttonAdd1000);
            flowLayoutPanelQuickBills.Controls.Add(buttonAdd2000);
            flowLayoutPanelQuickBills.Controls.Add(buttonAdd5000);
            flowLayoutPanelQuickBills.Controls.Add(buttonAdd10000);
            flowLayoutPanelQuickBills.Controls.Add(buttonAdd20000);
            flowLayoutPanelQuickBills.Controls.Add(buttonExactAmount);
            flowLayoutPanelQuickBills.Location = new Point(25, 280);
            flowLayoutPanelQuickBills.Name = "flowLayoutPanelQuickBills";
            flowLayoutPanelQuickBills.Size = new Size(450, 80);
            flowLayoutPanelQuickBills.TabIndex = 5;
            // 
            // buttonAdd1000
            // 
            buttonAdd1000.BackColor = Color.White;
            buttonAdd1000.Cursor = Cursors.Hand;
            buttonAdd1000.FlatStyle = FlatStyle.Flat;
            buttonAdd1000.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAdd1000.Location = new Point(3, 3);
            buttonAdd1000.Name = "buttonAdd1000";
            buttonAdd1000.Size = new Size(82, 34);
            buttonAdd1000.TabIndex = 0;
            buttonAdd1000.Text = "+$1.000";
            buttonAdd1000.UseVisualStyleBackColor = false;
            // 
            // buttonAdd2000
            // 
            buttonAdd2000.BackColor = Color.White;
            buttonAdd2000.Cursor = Cursors.Hand;
            buttonAdd2000.FlatStyle = FlatStyle.Flat;
            buttonAdd2000.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAdd2000.Location = new Point(91, 3);
            buttonAdd2000.Name = "buttonAdd2000";
            buttonAdd2000.Size = new Size(82, 34);
            buttonAdd2000.TabIndex = 1;
            buttonAdd2000.Text = "+$2.000";
            buttonAdd2000.UseVisualStyleBackColor = false;
            // 
            // buttonAdd5000
            // 
            buttonAdd5000.BackColor = Color.White;
            buttonAdd5000.Cursor = Cursors.Hand;
            buttonAdd5000.FlatStyle = FlatStyle.Flat;
            buttonAdd5000.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAdd5000.Location = new Point(179, 3);
            buttonAdd5000.Name = "buttonAdd5000";
            buttonAdd5000.Size = new Size(82, 34);
            buttonAdd5000.TabIndex = 2;
            buttonAdd5000.Text = "+$5.000";
            buttonAdd5000.UseVisualStyleBackColor = false;
            // 
            // buttonAdd10000
            // 
            buttonAdd10000.BackColor = Color.White;
            buttonAdd10000.Cursor = Cursors.Hand;
            buttonAdd10000.FlatStyle = FlatStyle.Flat;
            buttonAdd10000.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAdd10000.Location = new Point(267, 3);
            buttonAdd10000.Name = "buttonAdd10000";
            buttonAdd10000.Size = new Size(82, 34);
            buttonAdd10000.TabIndex = 3;
            buttonAdd10000.Text = "+$10.000";
            buttonAdd10000.UseVisualStyleBackColor = false;
            // 
            // buttonAdd20000
            // 
            buttonAdd20000.BackColor = Color.White;
            buttonAdd20000.Cursor = Cursors.Hand;
            buttonAdd20000.FlatStyle = FlatStyle.Flat;
            buttonAdd20000.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAdd20000.Location = new Point(355, 3);
            buttonAdd20000.Name = "buttonAdd20000";
            buttonAdd20000.Size = new Size(82, 34);
            buttonAdd20000.TabIndex = 4;
            buttonAdd20000.Text = "+$20.000";
            buttonAdd20000.UseVisualStyleBackColor = false;
            // 
            // buttonExactAmount
            // 
            buttonExactAmount.BackColor = Color.FromArgb(224, 242, 254);
            buttonExactAmount.Cursor = Cursors.Hand;
            buttonExactAmount.FlatAppearance.BorderSize = 0;
            buttonExactAmount.FlatStyle = FlatStyle.Flat;
            buttonExactAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonExactAmount.ForeColor = Color.FromArgb(3, 105, 161);
            buttonExactAmount.Location = new Point(3, 43);
            buttonExactAmount.Name = "buttonExactAmount";
            buttonExactAmount.Size = new Size(434, 30);
            buttonExactAmount.TabIndex = 5;
            buttonExactAmount.Text = "MONTO EXACTO";
            buttonExactAmount.UseVisualStyleBackColor = false;
            // 
            // panelChangeSummary
            // 
            panelChangeSummary.BackColor = Color.White;
            panelChangeSummary.Controls.Add(labelChangeTitle);
            panelChangeSummary.Controls.Add(labelChangeAmount);
            panelChangeSummary.Location = new Point(25, 370);
            panelChangeSummary.Name = "panelChangeSummary";
            panelChangeSummary.Size = new Size(450, 65);
            panelChangeSummary.TabIndex = 6;
            // 
            // labelChangeTitle
            // 
            labelChangeTitle.AutoSize = true;
            labelChangeTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelChangeTitle.Location = new Point(15, 22);
            labelChangeTitle.Name = "labelChangeTitle";
            labelChangeTitle.Size = new Size(104, 23);
            labelChangeTitle.TabIndex = 0;
            labelChangeTitle.Text = "SU VUELTO:";
            // 
            // labelChangeAmount
            // 
            labelChangeAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelChangeAmount.ForeColor = Color.FromArgb(16, 185, 129);
            labelChangeAmount.Location = new Point(150, 15);
            labelChangeAmount.Name = "labelChangeAmount";
            labelChangeAmount.Size = new Size(280, 35);
            labelChangeAmount.TabIndex = 1;
            labelChangeAmount.Text = "$ 0,00";
            labelChangeAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.FromArgb(239, 68, 68);
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(25, 455);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(185, 48);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonConfirmPayment
            // 
            buttonConfirmPayment.BackColor = Color.FromArgb(16, 185, 129);
            buttonConfirmPayment.Cursor = Cursors.Hand;
            buttonConfirmPayment.FlatAppearance.BorderSize = 0;
            buttonConfirmPayment.FlatStyle = FlatStyle.Flat;
            buttonConfirmPayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonConfirmPayment.ForeColor = Color.White;
            buttonConfirmPayment.Location = new Point(225, 455);
            buttonConfirmPayment.Name = "buttonConfirmPayment";
            buttonConfirmPayment.Size = new Size(250, 48);
            buttonConfirmPayment.TabIndex = 8;
            buttonConfirmPayment.Text = "CONFIRMAR PAGO";
            buttonConfirmPayment.UseVisualStyleBackColor = false;
            // 
            // FormPaymentDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(504, 521);
            Controls.Add(picIconConfirmPayment);
            Controls.Add(buttonConfirmPayment);
            Controls.Add(picIconCancel);
            Controls.Add(buttonCancel);
            Controls.Add(panelChangeSummary);
            Controls.Add(flowLayoutPanelQuickBills);
            Controls.Add(numericUpDownAmountPaid);
            Controls.Add(labelAmountPaidPrompt);
            Controls.Add(comboBoxPaymentMethod);
            Controls.Add(labelPaymentMethodPrompt);
            Controls.Add(panelTotalHeader);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPaymentDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cobro de Venta";
            ((System.ComponentModel.ISupportInitialize)picIconConfirmPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelTotalHeader.ResumeLayout(false);
            panelTotalHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmountPaid).EndInit();
            flowLayoutPanelQuickBills.ResumeLayout(false);
            panelChangeSummary.ResumeLayout(false);
            panelChangeSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picIconConfirmPayment;
        private System.Windows.Forms.PictureBox picIconCancel;
        private System.Windows.Forms.Panel panelTotalHeader;
        private System.Windows.Forms.Label labelTotalTitle;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.Label labelPaymentMethodPrompt;
        private System.Windows.Forms.ComboBox comboBoxPaymentMethod;
        private System.Windows.Forms.Label labelAmountPaidPrompt;
        private System.Windows.Forms.NumericUpDown numericUpDownAmountPaid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQuickBills;
        private System.Windows.Forms.Button buttonAdd1000;
        private System.Windows.Forms.Button buttonAdd2000;
        private System.Windows.Forms.Button buttonAdd5000;
        private System.Windows.Forms.Button buttonAdd10000;
        private System.Windows.Forms.Button buttonAdd20000;
        private System.Windows.Forms.Button buttonExactAmount;
        private System.Windows.Forms.Panel panelChangeSummary;
        private System.Windows.Forms.Label labelChangeTitle;
        private System.Windows.Forms.Label labelChangeAmount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirmPayment;
    }
}
