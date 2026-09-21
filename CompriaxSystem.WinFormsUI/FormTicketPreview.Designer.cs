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
            this.picIconPrintTicket = new System.Windows.Forms.PictureBox();
            this.picIconSendWhatsapp = new System.Windows.Forms.PictureBox();
            this.picIconSavePdf = new System.Windows.Forms.PictureBox();
            panelTopBar = new Panel();
            labelTicketTitle = new Label();
            groupBoxPaperSize = new GroupBox();
            radioButtonWidth80mm = new RadioButton();
            radioButtonWidth58mm = new RadioButton();
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
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
panelTopBar.Controls.Add(this.picIconPrintTicket);
            panelTopBar.Controls.Add(buttonPrintTicket);
panelTopBar.Controls.Add(this.picIconSendWhatsapp);
            panelTopBar.Controls.Add(buttonSendWhatsapp);
panelTopBar.Controls.Add(this.picIconSavePdf);
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
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;





            // 
            // buttonPrintTicket
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            // 
            buttonPrintTicket.BackColor = Color.FromArgb(2, 132, 199);
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.FlatAppearance.BorderSize = 0;
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.FlatStyle = FlatStyle.Flat;
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.ForeColor = Color.White;
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.Location = new Point(430, 16);
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.Name = "buttonPrintTicket";
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.Size = new Size(130, 42);
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.TabIndex = 2;
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
            buttonPrintTicket.Text = "IMPRIMIR";
            // 
            // picIconPrintTicket
            // 
            this.picIconPrintTicket.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconPrintTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconPrintTicket.Image = global::CompriaxSystem.WinFormsUI.Resources._082_imprimir;
            this.picIconPrintTicket.Location = new System.Drawing.Point(440, 27);
            this.picIconPrintTicket.Name = "picIconPrintTicket";
            this.picIconPrintTicket.Size = new System.Drawing.Size(20, 20);
            this.picIconPrintTicket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPrintTicket.TabIndex = 99;
            this.picIconPrintTicket.TabStop = false;

            // 
            // picIconSendWhatsapp
            // 
            this.picIconSendWhatsapp.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSendWhatsapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendWhatsapp.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendWhatsapp.Location = new System.Drawing.Point(594, 27);
            this.picIconSendWhatsapp.Name = "picIconSendWhatsapp";
            this.picIconSendWhatsapp.Size = new System.Drawing.Size(20, 20);
            this.picIconSendWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendWhatsapp.TabIndex = 99;
            this.picIconSendWhatsapp.TabStop = false;

            // 
            // picIconSavePdf
            // 
            this.picIconSavePdf.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSavePdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSavePdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconSavePdf.Location = new System.Drawing.Point(760, 27);
            this.picIconSavePdf.Name = "picIconSavePdf";
            this.picIconSavePdf.Size = new System.Drawing.Size(20, 20);
            this.picIconSavePdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSavePdf.TabIndex = 99;
            this.picIconSavePdf.TabStop = false;
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
ResumeLayout(false);
            panelTopBar.PerformLayout();
ResumeLayout(false);
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
