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
            picIconPrintTicket = new PictureBox();
            picIconSendWhatsapp = new PictureBox();
            picIconSavePdf = new PictureBox();
            panelTopBar = new Panel();
            labelTicketTitle = new Label();
            groupBoxPaperSize = new GroupBox();
            radioButtonWidth80mm = new RadioButton();
            radioButtonWidth58mm = new RadioButton();
            buttonPrintTicket = new Button();
            buttonSendWhatsapp = new Button();
            buttonSavePdf = new Button();
            webBrowserPdfViewer = new WebBrowser();
            ((System.ComponentModel.ISupportInitialize)picIconPrintTicket).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSendWhatsapp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSavePdf).BeginInit();
            panelTopBar.SuspendLayout();
            groupBoxPaperSize.SuspendLayout();
            SuspendLayout();
            // 
            // picIconPrintTicket
            // 
            picIconPrintTicket.BackColor = Color.FromArgb(2, 132, 199);
            picIconPrintTicket.Cursor = Cursors.Hand;
            picIconPrintTicket.Image = Resources._082_imprimir;
            picIconPrintTicket.Location = new Point(445, 17);
            picIconPrintTicket.Name = "picIconPrintTicket";
            picIconPrintTicket.Size = new Size(36, 50);
            picIconPrintTicket.SizeMode = PictureBoxSizeMode.Zoom;
            picIconPrintTicket.TabIndex = 99;
            picIconPrintTicket.TabStop = false;
            // 
            // picIconSendWhatsapp
            // 
            picIconSendWhatsapp.BackColor = Color.FromArgb(16, 185, 129);
            picIconSendWhatsapp.Cursor = Cursors.Hand;
            picIconSendWhatsapp.Image = Resources._083_enviar_mensaje;
            picIconSendWhatsapp.Location = new Point(607, 17);
            picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            picIconSendWhatsapp.Size = new Size(30, 50);
            picIconSendWhatsapp.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSendWhatsapp.TabIndex = 99;
            picIconSendWhatsapp.TabStop = false;
            // 
            // picIconSavePdf
            // 
            picIconSavePdf.BackColor = Color.FromArgb(15, 23, 42);
            picIconSavePdf.Cursor = Cursors.Hand;
            picIconSavePdf.Image = Resources._085_exportar_pdf;
            picIconSavePdf.Location = new Point(765, 17);
            picIconSavePdf.Name = "picIconSavePdf";
            picIconSavePdf.Size = new Size(37, 52);
            picIconSavePdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSavePdf.TabIndex = 99;
            picIconSavePdf.TabStop = false;
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(15, 23, 42);
            panelTopBar.Controls.Add(labelTicketTitle);
            panelTopBar.Controls.Add(groupBoxPaperSize);
            panelTopBar.Controls.Add(picIconPrintTicket);
            panelTopBar.Controls.Add(buttonPrintTicket);
            panelTopBar.Controls.Add(picIconSendWhatsapp);
            panelTopBar.Controls.Add(buttonSendWhatsapp);
            panelTopBar.Controls.Add(picIconSavePdf);
            panelTopBar.Controls.Add(buttonSavePdf);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1006, 82);
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
            groupBoxPaperSize.Location = new Point(237, 12);
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
            buttonPrintTicket.Location = new Point(445, 17);
            buttonPrintTicket.Name = "buttonPrintTicket";
            buttonPrintTicket.Size = new Size(148, 52);
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
            buttonSendWhatsapp.Location = new Point(607, 17);
            buttonSendWhatsapp.Name = "buttonSendWhatsapp";
            buttonSendWhatsapp.Size = new Size(152, 52);
            buttonSendWhatsapp.TabIndex = 3;
            buttonSendWhatsapp.Text = "WHATSAPP";
            buttonSendWhatsapp.UseVisualStyleBackColor = false;
            // 
            // buttonSavePdf
            // 
            buttonSavePdf.FlatStyle = FlatStyle.Flat;
            buttonSavePdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSavePdf.ForeColor = Color.White;
            buttonSavePdf.Location = new Point(765, 17);
            buttonSavePdf.Name = "buttonSavePdf";
            buttonSavePdf.Size = new Size(150, 52);
            buttonSavePdf.TabIndex = 4;
            buttonSavePdf.Text = "GUARDAR";
            buttonSavePdf.UseVisualStyleBackColor = true;
            // 
            // webBrowserPdfViewer
            // 
            webBrowserPdfViewer.Dock = DockStyle.Fill;
            webBrowserPdfViewer.Location = new Point(0, 82);
            webBrowserPdfViewer.MinimumSize = new Size(20, 20);
            webBrowserPdfViewer.Name = "webBrowserPdfViewer";
            webBrowserPdfViewer.Size = new Size(1006, 668);
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
            Text = "Comprobante de Ticket Digital";
            ((System.ComponentModel.ISupportInitialize)picIconPrintTicket).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSendWhatsapp).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSavePdf).EndInit();
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
        private System.Windows.Forms.PictureBox picIconPrintTicket;
        private System.Windows.Forms.PictureBox picIconSendWhatsapp;
        private System.Windows.Forms.PictureBox picIconSavePdf;
    }
}
