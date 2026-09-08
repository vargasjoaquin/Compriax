namespace CompriaxSystem.WinFormsUI
{
    partial class FormTicketPreview
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
            pnlTop = new Panel();
            lblTicketTitle = new Label();
            gbPaperSize = new GroupBox();
            rb80mm = new RadioButton();
            rb58mm = new RadioButton();
            btnPrint = new Button();
            btnWhatsapp = new Button();
            btnSavePdf = new Button();
            pdfViewer = new WebBrowser();
            pnlTop.SuspendLayout();
            gbPaperSize.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            pnlTop.Controls.Add(lblTicketTitle);
            pnlTop.Controls.Add(gbPaperSize);
            pnlTop.Controls.Add(btnPrint);
            pnlTop.Controls.Add(btnWhatsapp);
            pnlTop.Controls.Add(btnSavePdf);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1006, 70);
            pnlTop.TabIndex = 0;
            // 
            // lblTicketTitle
            // 
            lblTicketTitle.AutoSize = true;
            lblTicketTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTicketTitle.ForeColor = Color.White;
            lblTicketTitle.Location = new Point(3, 26);
            lblTicketTitle.Name = "lblTicketTitle";
            lblTicketTitle.Size = new Size(0, 30);
            lblTicketTitle.TabIndex = 0;
            // 
            // gbPaperSize
            // 
            gbPaperSize.Controls.Add(rb80mm);
            gbPaperSize.Controls.Add(rb58mm);
            gbPaperSize.Font = new Font("Segoe UI", 8.5F);
            gbPaperSize.ForeColor = Color.FromArgb(226, 232, 240);
            gbPaperSize.Location = new Point(231, 12);
            gbPaperSize.Name = "gbPaperSize";
            gbPaperSize.Size = new Size(180, 52);
            gbPaperSize.TabIndex = 1;
            gbPaperSize.TabStop = false;
            gbPaperSize.Text = "Ancho Térmico:";
            // 
            // rb80mm
            // 
            rb80mm.AutoSize = true;
            rb80mm.Checked = true;
            rb80mm.Font = new Font("Segoe UI", 8.5F);
            rb80mm.Location = new Point(12, 22);
            rb80mm.Name = "rb80mm";
            rb80mm.Size = new Size(76, 24);
            rb80mm.TabIndex = 0;
            rb80mm.TabStop = true;
            rb80mm.Text = "80 mm";
            rb80mm.UseVisualStyleBackColor = true;
            // 
            // rb58mm
            // 
            rb58mm.AutoSize = true;
            rb58mm.Font = new Font("Segoe UI", 8.5F);
            rb58mm.Location = new Point(98, 22);
            rb58mm.Name = "rb58mm";
            rb58mm.Size = new Size(76, 24);
            rb58mm.TabIndex = 1;
            rb58mm.Text = "58 mm";
            rb58mm.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(2, 132, 199);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(430, 16);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(130, 42);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "IMPRIMIR";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnWhatsapp
            // 
            btnWhatsapp.BackColor = Color.FromArgb(16, 185, 129);
            btnWhatsapp.FlatAppearance.BorderSize = 0;
            btnWhatsapp.FlatStyle = FlatStyle.Flat;
            btnWhatsapp.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnWhatsapp.ForeColor = Color.White;
            btnWhatsapp.Location = new Point(584, 16);
            btnWhatsapp.Name = "btnWhatsapp";
            btnWhatsapp.Size = new Size(140, 42);
            btnWhatsapp.TabIndex = 3;
            btnWhatsapp.Text = "WHATSAPP";
            btnWhatsapp.UseVisualStyleBackColor = false;
            // 
            // btnSavePdf
            // 
            btnSavePdf.FlatStyle = FlatStyle.Flat;
            btnSavePdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSavePdf.ForeColor = Color.White;
            btnSavePdf.Location = new Point(750, 16);
            btnSavePdf.Name = "btnSavePdf";
            btnSavePdf.Size = new Size(130, 42);
            btnSavePdf.TabIndex = 4;
            btnSavePdf.Text = "GUARDAR";
            btnSavePdf.UseVisualStyleBackColor = true;
            // 
            // pdfViewer
            // 
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.Location = new Point(0, 70);
            pdfViewer.MinimumSize = new Size(20, 20);
            pdfViewer.Name = "pdfViewer";
            pdfViewer.Size = new Size(1006, 680);
            pdfViewer.TabIndex = 1;
            // 
            // FormTicketPreview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1006, 750);
            Controls.Add(pdfViewer);
            Controls.Add(pnlTop);
            Name = "FormTicketPreview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comprobante Fiscal Digital - Ticket Térmico";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            gbPaperSize.ResumeLayout(false);
            gbPaperSize.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTicketTitle;
        private System.Windows.Forms.GroupBox gbPaperSize;
        private System.Windows.Forms.RadioButton rb80mm;
        private System.Windows.Forms.RadioButton rb58mm;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnWhatsapp;
        private System.Windows.Forms.Button btnSavePdf;
        private System.Windows.Forms.WebBrowser pdfViewer;
    }
}