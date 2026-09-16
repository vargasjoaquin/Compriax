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
            panelTopBar = new Panel();
            labelTicketTitle = new Label();
            groupBoxPaperSize = new GroupBox();
            radioButtonWidth80mm = new RadioButton();
            radioButtonWidth58mm = new RadioButton();
            buttonPrintTicket = new Button();
            buttonSendWhatsapp = new Button();
            buttonSavePdf = new Button();
            webBrowserPdfViewer = new WebBrowser();
            panelTopBar.SuspendLayout();
            groupBoxPaperSize.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(15, 23, 42);
            panelTopBar.Controls.Add(labelTicketTitle);
            panelTopBar.Controls.Add(groupBoxPaperSize);
            panelTopBar.Controls.Add(buttonPrintTicket);
            panelTopBar.Controls.Add(buttonSendWhatsapp);
            panelTopBar.Controls.Add(buttonSavePdf);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1006, 70);
            panelTopBar.TabIndex = 0;
            // 
            // labelTicketTitle
            // 
            labelTicketTitle.AutoSize = true;
            labelTicketTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTicketTitle.ForeColor = Color.White;
            labelTicketTitle.Location = new Point(3, 26);
            labelTicketTitle.Name = "labelTicketTitle";
            labelTicketTitle.Size = new Size(0, 30);
            labelTicketTitle.TabIndex = 0;
            // 
            // groupBoxPaperSize
            // 
            groupBoxPaperSize.Controls.Add(radioButtonWidth80mm);
            groupBoxPaperSize.Controls.Add(radioButtonWidth58mm);
            groupBoxPaperSize.Font = new Font("Segoe UI", 8.5F);
            groupBoxPaperSize.ForeColor = Color.FromArgb(226, 232, 240);
            groupBoxPaperSize.Location = new Point(231, 12);
            groupBoxPaperSize.Name = "groupBoxPaperSize";
            groupBoxPaperSize.Size = new Size(180, 52);
            groupBoxPaperSize.TabIndex = 1;
            groupBoxPaperSize.TabStop = false;
            groupBoxPaperSize.Text = "Ancho Térmico:";
            // 
            // radioButtonWidth80mm
            // 
            radioButtonWidth80mm.AutoSize = true;
            radioButtonWidth80mm.Checked = true;
            radioButtonWidth80mm.Font = new Font("Segoe UI", 8.5F);
            radioButtonWidth80mm.Location = new Point(12, 22);
            radioButtonWidth80mm.Name = "radioButtonWidth80mm";
            radioButtonWidth80mm.Size = new Size(76, 24);
            radioButtonWidth80mm.TabIndex = 0;
            radioButtonWidth80mm.TabStop = true;
            radioButtonWidth80mm.Text = "80 mm";
            radioButtonWidth80mm.UseVisualStyleBackColor = true;
            // 
            // radioButtonWidth58mm
            // 
            radioButtonWidth58mm.AutoSize = true;
            radioButtonWidth58mm.Font = new Font("Segoe UI", 8.5F);
            radioButtonWidth58mm.Location = new Point(98, 22);
            radioButtonWidth58mm.Name = "radioButtonWidth58mm";
            radioButtonWidth58mm.Size = new Size(76, 24);
            radioButtonWidth58mm.TabIndex = 1;
            radioButtonWidth58mm.Text = "58 mm";
            radioButtonWidth58mm.UseVisualStyleBackColor = true;
            // 
            // buttonPrintTicket
            // 
            buttonPrintTicket.BackColor = Color.FromArgb(2, 132, 199);
            buttonPrintTicket.FlatAppearance.BorderSize = 0;
            buttonPrintTicket.FlatStyle = FlatStyle.Flat;
            buttonPrintTicket.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonPrintTicket.ForeColor = Color.White;
            buttonPrintTicket.Location = new Point(430, 16);
            buttonPrintTicket.Name = "buttonPrintTicket";
            buttonPrintTicket.Size = new Size(130, 42);
            buttonPrintTicket.TabIndex = 2;
            buttonPrintTicket.Text = "IMPRIMIR";
            buttonPrintTicket.UseVisualStyleBackColor = false;
            // 
            // buttonSendWhatsapp
            // 
            buttonSendWhatsapp.BackColor = Color.FromArgb(16, 185, 129);
            buttonSendWhatsapp.FlatAppearance.BorderSize = 0;
            buttonSendWhatsapp.FlatStyle = FlatStyle.Flat;
            buttonSendWhatsapp.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSendWhatsapp.ForeColor = Color.White;
            buttonSendWhatsapp.Location = new Point(584, 16);
            buttonSendWhatsapp.Name = "buttonSendWhatsapp";
            buttonSendWhatsapp.Size = new Size(140, 42);
            buttonSendWhatsapp.TabIndex = 3;
            buttonSendWhatsapp.Text = "WHATSAPP";
            buttonSendWhatsapp.UseVisualStyleBackColor = false;
            // 
            // buttonSavePdf
            // 
            buttonSavePdf.FlatStyle = FlatStyle.Flat;
            buttonSavePdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSavePdf.ForeColor = Color.White;
            buttonSavePdf.Location = new Point(750, 16);
            buttonSavePdf.Name = "buttonSavePdf";
            buttonSavePdf.Size = new Size(130, 42);
            buttonSavePdf.TabIndex = 4;
            buttonSavePdf.Text = "GUARDAR";
            buttonSavePdf.UseVisualStyleBackColor = true;
            // 
            // webBrowserPdfViewer
            // 
            webBrowserPdfViewer.Dock = DockStyle.Fill;
            webBrowserPdfViewer.Location = new Point(0, 70);
            webBrowserPdfViewer.MinimumSize = new Size(20, 20);
            webBrowserPdfViewer.Name = "webBrowserPdfViewer";
            webBrowserPdfViewer.Size = new Size(1006, 680);
            webBrowserPdfViewer.TabIndex = 1;
            // 
            // FormTicketPreview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1006, 750);
            Controls.Add(webBrowserPdfViewer);
            Controls.Add(panelTopBar);
            Name = "FormTicketPreview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comprobante Fiscal Digital - Ticket Térmico";
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            groupBoxPaperSize.ResumeLayout(false);
            groupBoxPaperSize.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label labelTicketTitle;
        private System.Windows.Forms.GroupBox groupBoxPaperSize;
        private System.Windows.Forms.RadioButton radioButtonWidth80mm;
        private System.Windows.Forms.RadioButton radioButtonWidth58mm;
        private System.Windows.Forms.Button buttonPrintTicket;
        private System.Windows.Forms.Button buttonSendWhatsapp;
        private System.Windows.Forms.Button buttonSavePdf;
        private System.Windows.Forms.WebBrowser webBrowserPdfViewer;
    }
}