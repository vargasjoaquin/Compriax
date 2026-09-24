namespace CompriaxSystem.WinFormsUI.Helpers
{
    partial class FormSearchCustomerDialog
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
            picIconSearch = new PictureBox();
            picIconCancel = new PictureBox();
            labelHeaderTitle = new Label();
            labelDocumentPrompt = new Label();
            textBoxDocumentNumber = new TextBox();
            buttonCancel = new Button();
            buttonSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            SuspendLayout();
            // 
            // picIconSearch
            // 
            picIconSearch.BackColor = Color.FromArgb(2, 132, 199);
            picIconSearch.Cursor = Cursors.Hand;
            picIconSearch.Image = Resources._080_buscar;
            picIconSearch.Location = new Point(243, 126);
            picIconSearch.Name = "picIconSearch";
            picIconSearch.Size = new Size(38, 38);
            picIconSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSearch.TabIndex = 99;
            picIconSearch.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.FromArgb(255, 255, 255);
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Resources._093_error;
            picIconCancel.Location = new Point(35, 126);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(33, 38);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelHeaderTitle.Location = new Point(20, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(354, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "BÚSQUEDA DE CLIENTE POR DNI";
            // 
            // labelDocumentPrompt
            // 
            labelDocumentPrompt.AutoSize = true;
            labelDocumentPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDocumentPrompt.ForeColor = Color.FromArgb(15, 23, 42);
            labelDocumentPrompt.Location = new Point(20, 50);
            labelDocumentPrompt.Name = "labelDocumentPrompt";
            labelDocumentPrompt.Size = new Size(422, 21);
            labelDocumentPrompt.TabIndex = 1;
            labelDocumentPrompt.Text = "Ingrese el número de DNI del Cliente (hasta 8 dígitos):";
            // 
            // textBoxDocumentNumber
            // 
            textBoxDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxDocumentNumber.Location = new Point(20, 78);
            textBoxDocumentNumber.MaxLength = 8;
            textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            textBoxDocumentNumber.Size = new Size(385, 34);
            textBoxDocumentNumber.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonCancel.Location = new Point(20, 126);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(180, 38);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.FromArgb(2, 132, 199);
            buttonSearch.Cursor = Cursors.Hand;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(215, 126);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(213, 38);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "BUSCAR";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // FormSearchCustomerDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(451, 181);
            Controls.Add(picIconSearch);
            Controls.Add(buttonSearch);
            Controls.Add(picIconCancel);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxDocumentNumber);
            Controls.Add(labelDocumentPrompt);
            Controls.Add(labelHeaderTitle);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSearchCustomerDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscar Cliente para la Venta";
            ((System.ComponentModel.ISupportInitialize)picIconSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picIconSearch;
        private System.Windows.Forms.PictureBox picIconCancel;
        private System.Windows.Forms.Label labelHeaderTitle;
        private System.Windows.Forms.Label labelDocumentPrompt;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSearch;
    }
}
