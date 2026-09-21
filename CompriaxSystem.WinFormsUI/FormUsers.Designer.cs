namespace CompriaxSystem.WinFormsUI
{
    partial class FormUsers
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
            this.picIconExportPdf = new System.Windows.Forms.PictureBox();
            this.picIconBrowsePhoto = new System.Windows.Forms.PictureBox();
            this.picIconClearPhoto = new System.Windows.Forms.PictureBox();
            this.picIconSave = new System.Windows.Forms.PictureBox();
            this.picIconEdit = new System.Windows.Forms.PictureBox();
            this.picIconDelete = new System.Windows.Forms.PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf = new Button();
            panelUserForm = new Panel();
            pictureBoxUserPhoto = new PictureBox();
            buttonBrowsePhoto = new Button();
            buttonClearPhoto = new Button();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonTogglePasswordVisibility = new Button();
            labelRole = new Label();
            comboBoxRole = new ComboBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            dataGridViewUsers = new DataGridView();
            panelHeader.SuspendLayout();
            panelUserForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
panelHeader.Controls.Add(this.picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1103, 76);
            panelHeader.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(534, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ADMINISTRACIÓN DE USUARIOS DEL SISTEMA";
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // buttonExportPdf
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Location = new Point(919, 12);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.Size = new Size(165, 54);
            // 
            // picIconExportPdf
            // 
            this.picIconExportPdf.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconExportPdf.Image = global::CompriaxSystem.WinFormsUI.Resources._085_exportar_pdf;
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
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
            this.picIconExportPdf.Location = new System.Drawing.Point(931, 29);
            this.picIconExportPdf.Name = "picIconExportPdf";
            this.picIconExportPdf.Size = new System.Drawing.Size(20, 20);
            this.picIconExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconExportPdf.TabIndex = 99;
            this.picIconExportPdf.TabStop = false;

            // 
            // picIconBrowsePhoto
            // 
            this.picIconBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconBrowsePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconBrowsePhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._086_capturar_foto;
            this.picIconBrowsePhoto.Location = new System.Drawing.Point(24, 205);
            this.picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            this.picIconBrowsePhoto.Size = new System.Drawing.Size(20, 20);
            this.picIconBrowsePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconBrowsePhoto.TabIndex = 99;
            this.picIconBrowsePhoto.TabStop = false;

            // 
            // picIconClearPhoto
            // 
            this.picIconClearPhoto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconClearPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearPhoto.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconClearPhoto.Location = new System.Drawing.Point(122, 205);
            this.picIconClearPhoto.Name = "picIconClearPhoto";
            this.picIconClearPhoto.Size = new System.Drawing.Size(18, 18);
            this.picIconClearPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearPhoto.TabIndex = 99;
            this.picIconClearPhoto.TabStop = false;

            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(803, 35);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(20, 20);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconEdit
            // 
            this.picIconEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconEdit.Image = global::CompriaxSystem.WinFormsUI.Resources._078_editar;
            this.picIconEdit.Location = new System.Drawing.Point(803, 118);
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
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconDelete.Location = new System.Drawing.Point(803, 205);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(20, 20);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonExportPdf.UseVisualStyleBackColor = false;

            // panelUserForm
            panelUserForm.BackColor = Color.White;
            panelUserForm.Controls.Add(pictureBoxUserPhoto);
panelUserForm.Controls.Add(this.picIconBrowsePhoto);
            panelUserForm.Controls.Add(buttonBrowsePhoto);
panelUserForm.Controls.Add(this.picIconClearPhoto);
            panelUserForm.Controls.Add(buttonClearPhoto);
            panelUserForm.Controls.Add(labelUsername);
            panelUserForm.Controls.Add(textBoxUsername);
            panelUserForm.Controls.Add(labelFirstName);
            panelUserForm.Controls.Add(textBoxFirstName);
            panelUserForm.Controls.Add(labelLastName);
            panelUserForm.Controls.Add(textBoxLastName);
            panelUserForm.Controls.Add(labelEmail);
            panelUserForm.Controls.Add(textBoxEmail);
            panelUserForm.Controls.Add(labelPassword);
            panelUserForm.Controls.Add(textBoxPassword);
            panelUserForm.Controls.Add(buttonTogglePasswordVisibility);
            panelUserForm.Controls.Add(labelRole);
            panelUserForm.Controls.Add(comboBoxRole);
panelUserForm.Controls.Add(this.picIconSave);
            panelUserForm.Controls.Add(buttonSave);
panelUserForm.Controls.Add(this.picIconEdit);
            panelUserForm.Controls.Add(buttonEdit);
panelUserForm.Controls.Add(this.picIconDelete);
            panelUserForm.Controls.Add(buttonDelete);
            panelUserForm.Location = new Point(16, 82);
            panelUserForm.Name = "panelUserForm";
            panelUserForm.Size = new Size(1068, 261);
            panelUserForm.TabIndex = 1;

            // pictureBoxUserPhoto
            pictureBoxUserPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxUserPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxUserPhoto.Location = new Point(16, 16);
            pictureBoxUserPhoto.Name = "pictureBoxUserPhoto";
            pictureBoxUserPhoto.Size = new Size(162, 170);
            pictureBoxUserPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserPhoto.TabIndex = 0;
            pictureBoxUserPhoto.TabStop = false;

            // buttonBrowsePhoto
            buttonBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowsePhoto.FlatAppearance.BorderSize = 0;
            buttonBrowsePhoto.FlatStyle = FlatStyle.Flat;
            buttonBrowsePhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonBrowsePhoto.ForeColor = Color.White;
            buttonBrowsePhoto.Location = new Point(16, 192);
            buttonBrowsePhoto.Name = "buttonBrowsePhoto";
            buttonBrowsePhoto.Size = new Size(96, 46);
            buttonBrowsePhoto.TabIndex = 1;
            buttonBrowsePhoto.Text = "FOTO";
            buttonBrowsePhoto.UseVisualStyleBackColor = false;

            // buttonClearPhoto
            buttonClearPhoto.BackColor = Color.FromArgb(239, 68, 68);
            buttonClearPhoto.FlatAppearance.BorderSize = 0;
            buttonClearPhoto.FlatStyle = FlatStyle.Flat;
            buttonClearPhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonClearPhoto.ForeColor = Color.White;
            buttonClearPhoto.Location = new Point(118, 192);
            buttonClearPhoto.Name = "buttonClearPhoto";
            buttonClearPhoto.Size = new Size(60, 46);
            buttonClearPhoto.TabIndex = 2;
            buttonClearPhoto.Text = "";
            buttonClearPhoto.UseVisualStyleBackColor = false;

            // labelUsername
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelUsername.Location = new Point(209, 16);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(163, 21);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Nombre de Usuario:";

            // textBoxUsername
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 10F);
            textBoxUsername.Location = new Point(209, 40);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(227, 30);
            textBoxUsername.TabIndex = 4;

            // labelFirstName
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelFirstName.Location = new Point(209, 88);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(77, 21);
            labelFirstName.TabIndex = 5;
            labelFirstName.Text = "Nombre:";

            // textBoxFirstName
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(209, 111);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(227, 30);
            textBoxFirstName.TabIndex = 6;

            // labelLastName
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLastName.Location = new Point(209, 165);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(79, 21);
            labelLastName.TabIndex = 7;
            labelLastName.Text = "Apellido:";

            // textBoxLastName
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(209, 190);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(227, 30);
            textBoxLastName.TabIndex = 8;

            // labelEmail
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(501, 16);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 9;
            labelEmail.Text = "Correo Electrónico:";

            // textBoxEmail
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(501, 40);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(239, 30);
            textBoxEmail.TabIndex = 10;

            // labelPassword
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPassword.Location = new Point(501, 87);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 21);
            labelPassword.TabIndex = 11;
            labelPassword.Text = "Contraseña:";

            // textBoxPassword
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(501, 111);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(190, 30);
            textBoxPassword.TabIndex = 12;

            // buttonTogglePasswordVisibility (Botón con Ojito)
            buttonTogglePasswordVisibility.BackColor = Color.FromArgb(241, 245, 249);
            buttonTogglePasswordVisibility.FlatStyle = FlatStyle.Flat;
            buttonTogglePasswordVisibility.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            buttonTogglePasswordVisibility.Font = new Font("Segoe UI", 10F);
            buttonTogglePasswordVisibility.Location = new Point(697, 111);
            buttonTogglePasswordVisibility.Name = "buttonTogglePasswordVisibility";
            buttonTogglePasswordVisibility.Size = new Size(43, 30);
            buttonTogglePasswordVisibility.TabIndex = 13;
            buttonTogglePasswordVisibility.Text = "";
            buttonTogglePasswordVisibility.UseVisualStyleBackColor = false;

            // labelRole
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRole.Location = new Point(501, 165);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(119, 21);
            labelRole.TabIndex = 14;
            labelRole.Text = "Rol de Acceso:";

            // comboBoxRole
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.Font = new Font("Segoe UI", 10F);
            comboBoxRole.Location = new Point(501, 190);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(239, 31);
            comboBoxRole.TabIndex = 15;

            // buttonSave
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(789, 8);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(251, 74);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "GUARDAR USUARIO";
            buttonSave.UseVisualStyleBackColor = false;

            // buttonEdit
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(789, 88);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(251, 81);
            buttonEdit.TabIndex = 17;
            buttonEdit.Text = "EDITAR USUARIO";
            buttonEdit.UseVisualStyleBackColor = true;

            // buttonDelete
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(789, 177);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(251, 76);
            buttonDelete.TabIndex = 18;
            buttonDelete.Text = "ACTIVAR / DESACTIVAR";
            buttonDelete.UseVisualStyleBackColor = false;

            // dataGridViewUsers
            dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(16, 349);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(1068, 367);
            dataGridViewUsers.TabIndex = 2;

            // FormUsers
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1103, 728);
            Controls.Add(dataGridViewUsers);
            Controls.Add(panelUserForm);
            Controls.Add(panelHeader);
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios del Sistema";
ResumeLayout(false);
            panelHeader.PerformLayout();
ResumeLayout(false);
            panelUserForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExportPdf;
        private System.Windows.Forms.Panel panelUserForm;
        private System.Windows.Forms.PictureBox pictureBoxUserPhoto;
        private System.Windows.Forms.Button buttonBrowsePhoto;
        private System.Windows.Forms.Button buttonClearPhoto;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonTogglePasswordVisibility;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.PictureBox picIconExportPdf;
        private System.Windows.Forms.PictureBox picIconBrowsePhoto;
        private System.Windows.Forms.PictureBox picIconClearPhoto;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
