namespace CompriaxSystem.WinFormsUI
{
    partial class FormEmployees
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
            picIconExportPdf = new PictureBox();
            picIconBrowsePhoto = new PictureBox();
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconDelete = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportPdf = new Button();
            panelEmployeeForm = new Panel();
            pictureBoxPhoto = new PictureBox();
            buttonBrowsePhoto = new Button();
            labelEmployeeCode = new Label();
            textBoxEmployeeCode = new TextBox();
            labelDocumentNumber = new Label();
            textBoxDocumentNumber = new TextBox();
            labelTaxCode = new Label();
            textBoxTaxCode = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelPosition = new Label();
            comboBoxPosition = new ComboBox();
            labelGender = new Label();
            comboBoxGender = new ComboBox();
            labelCivilStatus = new Label();
            comboBoxCivilStatus = new ComboBox();
            labelChildrenCount = new Label();
            numericUpDownChildrenCount = new NumericUpDown();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            dataGridViewEmployees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconBrowsePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            panelHeader.SuspendLayout();
            panelEmployeeForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownChildrenCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            SuspendLayout();
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Resources._085_exportar_pdf;
            picIconExportPdf.Location = new Point(1007, 15);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(42, 61);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconBrowsePhoto
            // 
            picIconBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            picIconBrowsePhoto.Cursor = Cursors.Hand;
            picIconBrowsePhoto.Image = Resources._086_capturar_foto;
            picIconBrowsePhoto.Location = new Point(28, 183);
            picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            picIconBrowsePhoto.Size = new Size(38, 66);
            picIconBrowsePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picIconBrowsePhoto.TabIndex = 99;
            picIconBrowsePhoto.TabStop = false;
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Resources._077_guardar;
            picIconSave.Location = new Point(1013, 16);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(38, 82);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(255, 255, 255);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Resources._078_editar;
            picIconEdit.Location = new Point(1031, 104);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(35, 73);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Resources._079_eliminar;
            picIconDelete.Location = new Point(1018, 183);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(38, 77);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1227, 91);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(414, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE PERSONAL Y EMPLEADOS";
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(995, 15);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Size = new Size(220, 61);
            buttonExportPdf.TabIndex = 1;
            buttonExportPdf.Text = "EXPORTAR PDF";
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // panelEmployeeForm
            // 
            panelEmployeeForm.BackColor = Color.White;
            panelEmployeeForm.Controls.Add(pictureBoxPhoto);
            panelEmployeeForm.Controls.Add(picIconBrowsePhoto);
            panelEmployeeForm.Controls.Add(buttonBrowsePhoto);
            panelEmployeeForm.Controls.Add(labelEmployeeCode);
            panelEmployeeForm.Controls.Add(textBoxEmployeeCode);
            panelEmployeeForm.Controls.Add(labelDocumentNumber);
            panelEmployeeForm.Controls.Add(textBoxDocumentNumber);
            panelEmployeeForm.Controls.Add(labelTaxCode);
            panelEmployeeForm.Controls.Add(textBoxTaxCode);
            panelEmployeeForm.Controls.Add(labelFirstName);
            panelEmployeeForm.Controls.Add(textBoxFirstName);
            panelEmployeeForm.Controls.Add(labelLastName);
            panelEmployeeForm.Controls.Add(textBoxLastName);
            panelEmployeeForm.Controls.Add(labelPosition);
            panelEmployeeForm.Controls.Add(comboBoxPosition);
            panelEmployeeForm.Controls.Add(labelGender);
            panelEmployeeForm.Controls.Add(comboBoxGender);
            panelEmployeeForm.Controls.Add(labelCivilStatus);
            panelEmployeeForm.Controls.Add(comboBoxCivilStatus);
            panelEmployeeForm.Controls.Add(labelChildrenCount);
            panelEmployeeForm.Controls.Add(numericUpDownChildrenCount);
            panelEmployeeForm.Controls.Add(labelPhone);
            panelEmployeeForm.Controls.Add(textBoxPhone);
            panelEmployeeForm.Controls.Add(labelEmail);
            panelEmployeeForm.Controls.Add(textBoxEmail);
            panelEmployeeForm.Controls.Add(labelAddress);
            panelEmployeeForm.Controls.Add(textBoxAddress);
            panelEmployeeForm.Controls.Add(picIconSave);
            panelEmployeeForm.Controls.Add(buttonSave);
            panelEmployeeForm.Controls.Add(picIconEdit);
            panelEmployeeForm.Controls.Add(buttonEdit);
            panelEmployeeForm.Controls.Add(picIconDelete);
            panelEmployeeForm.Controls.Add(buttonDelete);
            panelEmployeeForm.Location = new Point(16, 97);
            panelEmployeeForm.Name = "panelEmployeeForm";
            panelEmployeeForm.Size = new Size(1199, 267);
            panelEmployeeForm.TabIndex = 1;
            // 
            // pictureBoxPhoto
            // 
            pictureBoxPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPhoto.Location = new Point(16, 16);
            pictureBoxPhoto.Name = "pictureBoxPhoto";
            pictureBoxPhoto.Size = new Size(140, 150);
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPhoto.TabIndex = 0;
            pictureBoxPhoto.TabStop = false;
            // 
            // buttonBrowsePhoto
            // 
            buttonBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowsePhoto.FlatAppearance.BorderSize = 0;
            buttonBrowsePhoto.FlatStyle = FlatStyle.Flat;
            buttonBrowsePhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonBrowsePhoto.ForeColor = Color.White;
            buttonBrowsePhoto.Location = new Point(16, 183);
            buttonBrowsePhoto.Name = "buttonBrowsePhoto";
            buttonBrowsePhoto.Size = new Size(140, 66);
            buttonBrowsePhoto.TabIndex = 1;
            buttonBrowsePhoto.Text = "FOTO";
            buttonBrowsePhoto.UseVisualStyleBackColor = false;
            // 
            // labelEmployeeCode
            // 
            labelEmployeeCode.AutoSize = true;
            labelEmployeeCode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmployeeCode.Location = new Point(171, 29);
            labelEmployeeCode.Name = "labelEmployeeCode";
            labelEmployeeCode.Size = new Size(65, 21);
            labelEmployeeCode.TabIndex = 2;
            labelEmployeeCode.Text = "Legajo:";
            // 
            // textBoxEmployeeCode
            // 
            textBoxEmployeeCode.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmployeeCode.Font = new Font("Segoe UI", 10F);
            textBoxEmployeeCode.Location = new Point(171, 53);
            textBoxEmployeeCode.Name = "textBoxEmployeeCode";
            textBoxEmployeeCode.Size = new Size(120, 30);
            textBoxEmployeeCode.TabIndex = 3;
            // 
            // labelDocumentNumber
            // 
            labelDocumentNumber.AutoSize = true;
            labelDocumentNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDocumentNumber.Location = new Point(311, 29);
            labelDocumentNumber.Name = "labelDocumentNumber";
            labelDocumentNumber.Size = new Size(44, 21);
            labelDocumentNumber.TabIndex = 4;
            labelDocumentNumber.Text = "DNI:";
            // 
            // textBoxDocumentNumber
            // 
            textBoxDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentNumber.Font = new Font("Segoe UI", 10F);
            textBoxDocumentNumber.Location = new Point(311, 53);
            textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            textBoxDocumentNumber.Size = new Size(140, 30);
            textBoxDocumentNumber.TabIndex = 5;
            // 
            // labelTaxCode
            // 
            labelTaxCode.AutoSize = true;
            labelTaxCode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxCode.Location = new Point(475, 29);
            labelTaxCode.Name = "labelTaxCode";
            labelTaxCode.Size = new Size(49, 21);
            labelTaxCode.TabIndex = 6;
            labelTaxCode.Text = "CUIL:";
            // 
            // textBoxTaxCode
            // 
            textBoxTaxCode.BorderStyle = BorderStyle.FixedSingle;
            textBoxTaxCode.Font = new Font("Segoe UI", 10F);
            textBoxTaxCode.Location = new Point(475, 53);
            textBoxTaxCode.Name = "textBoxTaxCode";
            textBoxTaxCode.Size = new Size(140, 30);
            textBoxTaxCode.TabIndex = 7;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelFirstName.Location = new Point(638, 29);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(77, 21);
            labelFirstName.TabIndex = 8;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(638, 53);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(168, 30);
            textBoxFirstName.TabIndex = 9;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLastName.Location = new Point(820, 29);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(79, 21);
            labelLastName.TabIndex = 10;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(820, 53);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(165, 30);
            textBoxLastName.TabIndex = 11;
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPosition.Location = new Point(171, 90);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(39, 21);
            labelPosition.TabIndex = 12;
            labelPosition.Text = "Rol:";
            // 
            // comboBoxPosition
            // 
            comboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPosition.Font = new Font("Segoe UI", 10F);
            comboBoxPosition.Location = new Point(171, 114);
            comboBoxPosition.Name = "comboBoxPosition";
            comboBoxPosition.Size = new Size(180, 31);
            comboBoxPosition.TabIndex = 13;
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelGender.Location = new Point(372, 90);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(69, 21);
            labelGender.TabIndex = 14;
            labelGender.Text = "Género:";
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Segoe UI", 10F);
            comboBoxGender.Location = new Point(372, 114);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(140, 31);
            comboBoxGender.TabIndex = 15;
            // 
            // labelCivilStatus
            // 
            labelCivilStatus.AutoSize = true;
            labelCivilStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCivilStatus.Location = new Point(540, 90);
            labelCivilStatus.Name = "labelCivilStatus";
            labelCivilStatus.Size = new Size(103, 21);
            labelCivilStatus.TabIndex = 16;
            labelCivilStatus.Text = "Estado Civil:";
            // 
            // comboBoxCivilStatus
            // 
            comboBoxCivilStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCivilStatus.Font = new Font("Segoe UI", 10F);
            comboBoxCivilStatus.Location = new Point(540, 114);
            comboBoxCivilStatus.Name = "comboBoxCivilStatus";
            comboBoxCivilStatus.Size = new Size(150, 31);
            comboBoxCivilStatus.TabIndex = 17;
            // 
            // labelChildrenCount
            // 
            labelChildrenCount.AutoSize = true;
            labelChildrenCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelChildrenCount.Location = new Point(723, 91);
            labelChildrenCount.Name = "labelChildrenCount";
            labelChildrenCount.Size = new Size(53, 21);
            labelChildrenCount.TabIndex = 18;
            labelChildrenCount.Text = "Hijos:";
            // 
            // numericUpDownChildrenCount
            // 
            numericUpDownChildrenCount.Font = new Font("Segoe UI", 10F);
            numericUpDownChildrenCount.Location = new Point(723, 115);
            numericUpDownChildrenCount.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDownChildrenCount.Name = "numericUpDownChildrenCount";
            numericUpDownChildrenCount.Size = new Size(70, 30);
            numericUpDownChildrenCount.TabIndex = 19;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPhone.Location = new Point(820, 91);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(81, 21);
            labelPhone.TabIndex = 20;
            labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(820, 114);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(165, 30);
            textBoxPhone.TabIndex = 21;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(171, 162);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 22;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(171, 186);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(270, 30);
            textBoxEmail.TabIndex = 23;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAddress.Location = new Point(486, 162);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(165, 21);
            labelAddress.TabIndex = 24;
            labelAddress.Text = "Dirección Completa:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10F);
            textBoxAddress.Location = new Point(486, 186);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(320, 30);
            textBoxAddress.TabIndex = 25;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(999, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(193, 82);
            buttonSave.TabIndex = 26;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(999, 104);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(193, 73);
            buttonEdit.TabIndex = 27;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(999, 183);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(193, 77);
            buttonDelete.TabIndex = 28;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewEmployees.BackgroundColor = Color.White;
            dataGridViewEmployees.BorderStyle = BorderStyle.None;
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Location = new Point(16, 385);
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.RowHeadersWidth = 51;
            dataGridViewEmployees.Size = new Size(1192, 328);
            dataGridViewEmployees.TabIndex = 2;
            // 
            // FormEmployees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1227, 733);
            Controls.Add(dataGridViewEmployees);
            Controls.Add(panelEmployeeForm);
            Controls.Add(panelHeader);
            Name = "FormEmployees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Empleados";
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconBrowsePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelEmployeeForm.ResumeLayout(false);
            panelEmployeeForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownChildrenCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExportPdf;
        private System.Windows.Forms.Panel panelEmployeeForm;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Button buttonBrowsePhoto;
        private System.Windows.Forms.Label labelEmployeeCode;
        private System.Windows.Forms.TextBox textBoxEmployeeCode;
        private System.Windows.Forms.Label labelDocumentNumber;
        private System.Windows.Forms.TextBox textBoxDocumentNumber;
        private System.Windows.Forms.Label labelTaxCode;
        private System.Windows.Forms.TextBox textBoxTaxCode;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Label labelCivilStatus;
        private System.Windows.Forms.ComboBox comboBoxCivilStatus;
        private System.Windows.Forms.Label labelChildrenCount;
        private System.Windows.Forms.NumericUpDown numericUpDownChildrenCount;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.PictureBox picIconExportPdf;
        private System.Windows.Forms.PictureBox picIconBrowsePhoto;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
