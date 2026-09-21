namespace CompriaxSystem.WinFormsUI
{
    partial class FormCustomers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.picIconExportPdf = new System.Windows.Forms.PictureBox();
            this.picIconSave = new System.Windows.Forms.PictureBox();
            this.picIconEdit = new System.Windows.Forms.PictureBox();
            this.picIconDelete = new System.Windows.Forms.PictureBox();
            picIconExportPdf = new PictureBox();
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconDelete = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf = new Button();
            panelMain = new Panel();
            dataGridViewCustomers = new DataGridView();
            panelCustomerForm = new Panel();
            labelDocumentNumber = new Label();
            textBoxDocumentNumber = new TextBox();
            labelTaxCode = new Label();
            textBoxTaxCode = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelTaxCondition = new Label();
            comboBoxTaxCondition = new ComboBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelCity = new Label();
            textBoxCity = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            panelCustomerForm.SuspendLayout();
            SuspendLayout();
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Resources._085_exportar_pdf;
            picIconExportPdf.Location = new Point(950, 29);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(22, 22);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Resources._077_guardar;
            picIconSave.Location = new Point(830, 16);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(58, 66);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(255, 255, 255);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Resources._078_editar;
            picIconEdit.Location = new Point(845, 106);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(20, 20);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Resources._079_eliminar;
            picIconDelete.Location = new Point(845, 171);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(20, 20);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
panelHeader.Controls.Add(this.picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1163, 79);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 22);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(245, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE CLIENTES";
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // buttonExportPdf
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.ForeColor = Color.White;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Location = new Point(936, 12);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Name = "buttonExportPdf";
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Size = new Size(211, 55);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.TabIndex = 1;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Text = "EXPORTAR PDF";
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(950, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(22, 22);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(845, 39);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(22, 22);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(845, 106);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(20, 20);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(845, 171);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 250, 252);
            panelMain.Controls.Add(dataGridViewCustomers);
            panelMain.Controls.Add(panelCustomerForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 79);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 12, 16, 16);
            panelMain.Size = new Size(1163, 624);
            panelMain.TabIndex = 1;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.BackgroundColor = Color.White;
            dataGridViewCustomers.BorderStyle = BorderStyle.None;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Dock = DockStyle.Fill;
            dataGridViewCustomers.Location = new Point(16, 239);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.RowHeadersWidth = 51;
            dataGridViewCustomers.Size = new Size(1131, 369);
            dataGridViewCustomers.TabIndex = 1;
            // 
            // panelCustomerForm
            // 
            panelCustomerForm.BackColor = Color.White;
            panelCustomerForm.Controls.Add(labelDocumentNumber);
            panelCustomerForm.Controls.Add(textBoxDocumentNumber);
            panelCustomerForm.Controls.Add(labelTaxCode);
            panelCustomerForm.Controls.Add(textBoxTaxCode);
            panelCustomerForm.Controls.Add(labelFirstName);
            panelCustomerForm.Controls.Add(textBoxFirstName);
            panelCustomerForm.Controls.Add(labelLastName);
            panelCustomerForm.Controls.Add(textBoxLastName);
            panelCustomerForm.Controls.Add(labelTaxCondition);
            panelCustomerForm.Controls.Add(comboBoxTaxCondition);
            panelCustomerForm.Controls.Add(labelPhone);
            panelCustomerForm.Controls.Add(textBoxPhone);
            panelCustomerForm.Controls.Add(labelAddress);
            panelCustomerForm.Controls.Add(textBoxAddress);
            panelCustomerForm.Controls.Add(labelCity);
            panelCustomerForm.Controls.Add(textBoxCity);
            panelCustomerForm.Controls.Add(labelEmail);
            panelCustomerForm.Controls.Add(textBoxEmail);
panelCustomerForm.Controls.Add(this.picIconSave);
            panelCustomerForm.Controls.Add(buttonSave);
panelCustomerForm.Controls.Add(this.picIconEdit);
            panelCustomerForm.Controls.Add(buttonEdit);
panelCustomerForm.Controls.Add(this.picIconDelete);
            panelCustomerForm.Controls.Add(buttonDelete);
            panelCustomerForm.Dock = DockStyle.Top;
            panelCustomerForm.Location = new Point(16, 12);
            panelCustomerForm.Name = "panelCustomerForm";
            panelCustomerForm.Size = new Size(1131, 227);
            panelCustomerForm.TabIndex = 0;
            // 
            // labelDocumentNumber
            // 
            labelDocumentNumber.AutoSize = true;
            labelDocumentNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDocumentNumber.Location = new Point(20, 16);
            labelDocumentNumber.Name = "labelDocumentNumber";
            labelDocumentNumber.Size = new Size(149, 21);
            labelDocumentNumber.TabIndex = 0;
            labelDocumentNumber.Text = "DNI / Documento:";
            // 
            // textBoxDocumentNumber
            // 
            textBoxDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentNumber.Font = new Font("Segoe UI", 10F);
            textBoxDocumentNumber.Location = new Point(20, 42);
            textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            textBoxDocumentNumber.Size = new Size(160, 30);
            textBoxDocumentNumber.TabIndex = 1;
            // 
            // labelTaxCode
            // 
            labelTaxCode.AutoSize = true;
            labelTaxCode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxCode.Location = new Point(195, 16);
            labelTaxCode.Name = "labelTaxCode";
            labelTaxCode.Size = new Size(100, 21);
            labelTaxCode.TabIndex = 2;
            labelTaxCode.Text = "CUIL / CUIT:";
            // 
            // textBoxTaxCode
            // 
            textBoxTaxCode.BorderStyle = BorderStyle.FixedSingle;
            textBoxTaxCode.Font = new Font("Segoe UI", 10F);
            textBoxTaxCode.Location = new Point(195, 42);
            textBoxTaxCode.Name = "textBoxTaxCode";
            textBoxTaxCode.Size = new Size(160, 30);
            textBoxTaxCode.TabIndex = 3;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelFirstName.Location = new Point(370, 16);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(77, 21);
            labelFirstName.TabIndex = 4;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(370, 42);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(200, 30);
            textBoxFirstName.TabIndex = 5;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLastName.Location = new Point(585, 16);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(79, 21);
            labelLastName.TabIndex = 6;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(585, 42);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(200, 30);
            textBoxLastName.TabIndex = 7;
            // 
            // labelTaxCondition
            // 
            labelTaxCondition.AutoSize = true;
            labelTaxCondition.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxCondition.Location = new Point(20, 88);
            labelTaxCondition.Name = "labelTaxCondition";
            labelTaxCondition.Size = new Size(138, 21);
            labelTaxCondition.TabIndex = 8;
            labelTaxCondition.Text = "Condición Fiscal:";
            // 
            // comboBoxTaxCondition
            // 
            comboBoxTaxCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTaxCondition.Font = new Font("Segoe UI", 10F);
            comboBoxTaxCondition.Location = new Point(20, 113);
            comboBoxTaxCondition.Name = "comboBoxTaxCondition";
            comboBoxTaxCondition.Size = new Size(160, 31);
            comboBoxTaxCondition.TabIndex = 9;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPhone.Location = new Point(195, 88);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(81, 21);
            labelPhone.TabIndex = 10;
            labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(195, 113);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(160, 30);
            textBoxPhone.TabIndex = 11;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAddress.Location = new Point(370, 88);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(87, 21);
            labelAddress.TabIndex = 12;
            labelAddress.Text = "Dirección:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10F);
            textBoxAddress.Location = new Point(370, 113);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(200, 30);
            textBoxAddress.TabIndex = 13;
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCity.Location = new Point(585, 88);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(68, 21);
            labelCity.TabIndex = 14;
            labelCity.Text = "Ciudad:";
            // 
            // textBoxCity
            // 
            textBoxCity.BorderStyle = BorderStyle.FixedSingle;
            textBoxCity.Font = new Font("Segoe UI", 10F);
            textBoxCity.Location = new Point(585, 113);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(200, 30);
            textBoxCity.TabIndex = 15;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(20, 158);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 16;
            labelEmail.Text = "Correo electronico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(20, 182);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(335, 30);
            textBoxEmail.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(830, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(286, 66);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "GUARDAR CLIENTE";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(830, 88);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(286, 56);
            buttonEdit.TabIndex = 19;
            buttonEdit.Text = "EDITAR CLIENTE";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(830, 150);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(286, 62);
            buttonDelete.TabIndex = 20;
            buttonDelete.Text = "ELIMINAR CLIENTE";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // FormCustomers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1163, 703);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Name = "FormCustomers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Clientes";
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            panelCustomerForm.ResumeLayout(false);
            panelCustomerForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExportPdf;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelCustomerForm;
        private System.Windows.Forms.Label labelDocumentNumber;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.Label labelTaxCode;
        private System.Windows.Forms.TextBox textBoxTaxCode;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelTaxCondition;
        private System.Windows.Forms.ComboBox comboBoxTaxCondition;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.PictureBox picIconExportPdf;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
