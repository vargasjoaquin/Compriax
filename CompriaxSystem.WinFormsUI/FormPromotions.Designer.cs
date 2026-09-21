namespace CompriaxSystem.WinFormsUI
{
    partial class FormPromotions
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
            this.picIconSave = new System.Windows.Forms.PictureBox();
            this.picIconEdit = new System.Windows.Forms.PictureBox();
            this.picIconToggleStatus = new System.Windows.Forms.PictureBox();
            this.picIconDelete = new System.Windows.Forms.PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelPromotionForm = new Panel();
            labelPromotionName = new Label();
            textBoxPromotionName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelPromotionType = new Label();
            comboBoxPromotionType = new ComboBox();
            labelApplicableProduct = new Label();
            comboBoxApplicableProduct = new ComboBox();
            labelApplicableCategory = new Label();
            comboBoxApplicableCategory = new ComboBox();
            labelDiscountPercentage = new Label();
            numericUpDownDiscountPercentage = new NumericUpDown();
            labelRequiredQuantity = new Label();
            numericUpDownRequiredQuantity = new NumericUpDown();
            labelPayQuantity = new Label();
            numericUpDownPayQuantity = new NumericUpDown();
            labelStartDate = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            labelEndDate = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonToggleStatus = new Button();
            buttonDelete = new Button();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            dataGridViewPromotions = new DataGridView();
            panelHeader.SuspendLayout();
            panelPromotionForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDiscountPercentage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRequiredQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPayQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPromotions).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1241, 66);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 19);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(538, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MOTOR DE PROMOCIONES Y BONIFICACIONES";
            // 
            // panelPromotionForm
            // 
            panelPromotionForm.BackColor = Color.White;
            panelPromotionForm.Controls.Add(labelPromotionName);
            panelPromotionForm.Controls.Add(textBoxPromotionName);
            panelPromotionForm.Controls.Add(labelDescription);
            panelPromotionForm.Controls.Add(textBoxDescription);
            panelPromotionForm.Controls.Add(labelPromotionType);
            panelPromotionForm.Controls.Add(comboBoxPromotionType);
            panelPromotionForm.Controls.Add(labelApplicableProduct);
            panelPromotionForm.Controls.Add(comboBoxApplicableProduct);
            panelPromotionForm.Controls.Add(labelApplicableCategory);
            panelPromotionForm.Controls.Add(comboBoxApplicableCategory);
            panelPromotionForm.Controls.Add(labelDiscountPercentage);
            panelPromotionForm.Controls.Add(numericUpDownDiscountPercentage);
            panelPromotionForm.Controls.Add(labelRequiredQuantity);
            panelPromotionForm.Controls.Add(numericUpDownRequiredQuantity);
            panelPromotionForm.Controls.Add(labelPayQuantity);
            panelPromotionForm.Controls.Add(numericUpDownPayQuantity);
            panelPromotionForm.Controls.Add(labelStartDate);
            panelPromotionForm.Controls.Add(dateTimePickerStartDate);
            panelPromotionForm.Controls.Add(labelEndDate);
            panelPromotionForm.Controls.Add(dateTimePickerEndDate);
panelPromotionForm.Controls.Add(this.picIconSave);
            panelPromotionForm.Controls.Add(buttonSave);
panelPromotionForm.Controls.Add(this.picIconEdit);
            panelPromotionForm.Controls.Add(buttonEdit);
panelPromotionForm.Controls.Add(this.picIconToggleStatus);
            panelPromotionForm.Controls.Add(buttonToggleStatus);
panelPromotionForm.Controls.Add(this.picIconDelete);
            panelPromotionForm.Controls.Add(buttonDelete);
            panelPromotionForm.Location = new Point(16, 72);
            panelPromotionForm.Name = "panelPromotionForm";
            panelPromotionForm.Size = new Size(1219, 232);
            panelPromotionForm.TabIndex = 1;
            // 
            // labelPromotionName
            // 
            labelPromotionName.AutoSize = true;
            labelPromotionName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPromotionName.Location = new Point(16, 12);
            labelPromotionName.Name = "labelPromotionName";
            labelPromotionName.Size = new Size(165, 21);
            labelPromotionName.TabIndex = 0;
            labelPromotionName.Text = "Nombre Promoción:";
            // 
            // textBoxPromotionName
            // 
            textBoxPromotionName.BorderStyle = BorderStyle.FixedSingle;
            textBoxPromotionName.Font = new Font("Segoe UI", 10F);
            textBoxPromotionName.Location = new Point(16, 37);
            textBoxPromotionName.Name = "textBoxPromotionName";
            textBoxPromotionName.Size = new Size(212, 30);
            textBoxPromotionName.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(245, 12);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 21);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Descripción:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(245, 37);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(213, 30);
            textBoxDescription.TabIndex = 3;
            // 
            // labelPromotionType
            // 
            labelPromotionType.AutoSize = true;
            labelPromotionType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPromotionType.Location = new Point(479, 12);
            labelPromotionType.Name = "labelPromotionType";
            labelPromotionType.Size = new Size(159, 21);
            labelPromotionType.TabIndex = 4;
            labelPromotionType.Text = "Tipo de Promoción:";
            // 
            // comboBoxPromotionType
            // 
            comboBoxPromotionType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPromotionType.Font = new Font("Segoe UI", 10F);
            comboBoxPromotionType.Location = new Point(479, 36);
            comboBoxPromotionType.Name = "comboBoxPromotionType";
            comboBoxPromotionType.Size = new Size(216, 31);
            comboBoxPromotionType.TabIndex = 5;
            // 
            // labelApplicableProduct
            // 
            labelApplicableProduct.AutoSize = true;
            labelApplicableProduct.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelApplicableProduct.Location = new Point(16, 88);
            labelApplicableProduct.Name = "labelApplicableProduct";
            labelApplicableProduct.Size = new Size(160, 21);
            labelApplicableProduct.TabIndex = 6;
            labelApplicableProduct.Text = "Producto Aplicable:";
            // 
            // comboBoxApplicableProduct
            // 
            comboBoxApplicableProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxApplicableProduct.Font = new Font("Segoe UI", 10F);
            comboBoxApplicableProduct.Location = new Point(16, 112);
            comboBoxApplicableProduct.Name = "comboBoxApplicableProduct";
            comboBoxApplicableProduct.Size = new Size(330, 31);
            comboBoxApplicableProduct.TabIndex = 7;
            // 
            // labelApplicableCategory
            // 
            labelApplicableCategory.AutoSize = true;
            labelApplicableCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelApplicableCategory.Location = new Point(365, 88);
            labelApplicableCategory.Name = "labelApplicableCategory";
            labelApplicableCategory.Size = new Size(164, 21);
            labelApplicableCategory.TabIndex = 8;
            labelApplicableCategory.Text = "Categoría Aplicable:";
            // 
            // comboBoxApplicableCategory
            // 
            comboBoxApplicableCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxApplicableCategory.Font = new Font("Segoe UI", 10F);
            comboBoxApplicableCategory.Location = new Point(365, 112);
            comboBoxApplicableCategory.Name = "comboBoxApplicableCategory";
            comboBoxApplicableCategory.Size = new Size(330, 31);
            comboBoxApplicableCategory.TabIndex = 9;
            // 
            // labelDiscountPercentage
            // 
            labelDiscountPercentage.AutoSize = true;
            labelDiscountPercentage.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDiscountPercentage.Location = new Point(16, 161);
            labelDiscountPercentage.Name = "labelDiscountPercentage";
            labelDiscountPercentage.Size = new Size(113, 21);
            labelDiscountPercentage.TabIndex = 10;
            labelDiscountPercentage.Text = "% Descuento:";
            // 
            // numericUpDownDiscountPercentage
            // 
            numericUpDownDiscountPercentage.DecimalPlaces = 1;
            numericUpDownDiscountPercentage.Font = new Font("Segoe UI", 10F);
            numericUpDownDiscountPercentage.Location = new Point(16, 185);
            numericUpDownDiscountPercentage.Name = "numericUpDownDiscountPercentage";
            numericUpDownDiscountPercentage.Size = new Size(110, 30);
            numericUpDownDiscountPercentage.TabIndex = 11;
            // 
            // labelRequiredQuantity
            // 
            labelRequiredQuantity.AutoSize = true;
            labelRequiredQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRequiredQuantity.Location = new Point(145, 161);
            labelRequiredQuantity.Name = "labelRequiredQuantity";
            labelRequiredQuantity.Size = new Size(83, 21);
            labelRequiredQuantity.TabIndex = 12;
            labelRequiredQuantity.Text = "Lleva (N):";
            // 
            // numericUpDownRequiredQuantity
            // 
            numericUpDownRequiredQuantity.Font = new Font("Segoe UI", 10F);
            numericUpDownRequiredQuantity.Location = new Point(145, 185);
            numericUpDownRequiredQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRequiredQuantity.Name = "numericUpDownRequiredQuantity";
            numericUpDownRequiredQuantity.Size = new Size(85, 30);
            numericUpDownRequiredQuantity.TabIndex = 13;
            numericUpDownRequiredQuantity.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelPayQuantity
            // 
            labelPayQuantity.AutoSize = true;
            labelPayQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPayQuantity.Location = new Point(245, 161);
            labelPayQuantity.Name = "labelPayQuantity";
            labelPayQuantity.Size = new Size(83, 21);
            labelPayQuantity.TabIndex = 14;
            labelPayQuantity.Text = "Paga (M):";
            // 
            // numericUpDownPayQuantity
            // 
            numericUpDownPayQuantity.Font = new Font("Segoe UI", 10F);
            numericUpDownPayQuantity.Location = new Point(245, 185);
            numericUpDownPayQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPayQuantity.Name = "numericUpDownPayQuantity";
            numericUpDownPayQuantity.Size = new Size(85, 30);
            numericUpDownPayQuantity.TabIndex = 15;
            numericUpDownPayQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelStartDate
            // 
            labelStartDate.AutoSize = true;
            labelStartDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelStartDate.Location = new Point(350, 161);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(61, 21);
            labelStartDate.TabIndex = 16;
            labelStartDate.Text = "Desde:";
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            dateTimePickerStartDate.Location = new Point(350, 185);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(130, 30);
            dateTimePickerStartDate.TabIndex = 17;
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEndDate.Location = new Point(500, 161);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(57, 21);
            labelEndDate.TabIndex = 18;
            labelEndDate.Text = "Hasta:";
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(500, 185);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(135, 30);
            dateTimePickerEndDate.TabIndex = 19;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;





            // 
            // buttonSave
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.FlatAppearance.BorderSize = 0;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.FlatStyle = FlatStyle.Flat;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.ForeColor = Color.White;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.Location = new Point(711, 12);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.Name = "buttonSave";
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.Size = new Size(240, 94);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.TabIndex = 20;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.Text = "GUARDAR PROMOCION";
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(725, 49);
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
            this.picIconEdit.Location = new System.Drawing.Point(970, 49);
            this.picIconEdit.Name = "picIconEdit";
            this.picIconEdit.Size = new System.Drawing.Size(22, 22);
            this.picIconEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconEdit.TabIndex = 99;
            this.picIconEdit.TabStop = false;

            // 
            // picIconToggleStatus
            // 
            this.picIconToggleStatus.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconToggleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleStatus.Image = global::CompriaxSystem.WinFormsUI.Resources._089_estado_activo;
            this.picIconToggleStatus.Location = new System.Drawing.Point(725, 153);
            this.picIconToggleStatus.Name = "picIconToggleStatus";
            this.picIconToggleStatus.Size = new System.Drawing.Size(22, 22);
            this.picIconToggleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleStatus.TabIndex = 99;
            this.picIconToggleStatus.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(970, 153);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(22, 22);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(957, 12);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(243, 94);
            buttonEdit.TabIndex = 21;
            buttonEdit.Text = "EDITAR PROMOCION";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonToggleStatus
            // 
            buttonToggleStatus.BackColor = Color.FromArgb(2, 132, 199);
            buttonToggleStatus.FlatAppearance.BorderSize = 0;
            buttonToggleStatus.FlatStyle = FlatStyle.Flat;
            buttonToggleStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleStatus.ForeColor = Color.White;
            buttonToggleStatus.Location = new Point(711, 112);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Size = new Size(240, 103);
            buttonToggleStatus.TabIndex = 22;
            buttonToggleStatus.Text = "ACTIVAR / PAUSAR PROMOCION";
            buttonToggleStatus.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(957, 112);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(243, 103);
            buttonDelete.TabIndex = 23;
            buttonDelete.Text = "ELIMINAR PROMOCION";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(16, 322);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(152, 21);
            labelSearchPrompt.TabIndex = 2;
            labelSearchPrompt.Text = "Buscar Promoción:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(174, 319);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(420, 30);
            textBoxSearch.TabIndex = 3;
            // 
            // dataGridViewPromotions
            // 
            dataGridViewPromotions.BackgroundColor = Color.White;
            dataGridViewPromotions.BorderStyle = BorderStyle.None;
            dataGridViewPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPromotions.Location = new Point(16, 360);
            dataGridViewPromotions.Name = "dataGridViewPromotions";
            dataGridViewPromotions.RowHeadersWidth = 51;
            dataGridViewPromotions.Size = new Size(1219, 350);
            dataGridViewPromotions.TabIndex = 4;





            // 
            // FormPromotions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1241, 722);
            Controls.Add(dataGridViewPromotions);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearchPrompt);
            Controls.Add(panelPromotionForm);
            Controls.Add(panelHeader);
            Name = "FormPromotions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promociones y Descuentos";
ResumeLayout(false);
            panelHeader.PerformLayout();
ResumeLayout(false);
            panelPromotionForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDiscountPercentage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRequiredQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPayQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPromotions).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelPromotionForm;
        private System.Windows.Forms.Label labelPromotionName;
        private System.Windows.Forms.TextBox textBoxPromotionName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelPromotionType;
        private System.Windows.Forms.ComboBox comboBoxPromotionType;
        private System.Windows.Forms.Label labelApplicableProduct;
        private System.Windows.Forms.ComboBox comboBoxApplicableProduct;
        private System.Windows.Forms.Label labelApplicableCategory;
        private System.Windows.Forms.ComboBox comboBoxApplicableCategory;
        private System.Windows.Forms.Label labelDiscountPercentage;
        private System.Windows.Forms.NumericUpDown numericUpDownDiscountPercentage;
        private System.Windows.Forms.Label labelRequiredQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownRequiredQuantity;
        private System.Windows.Forms.Label labelPayQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownPayQuantity;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonToggleStatus;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelSearchPrompt;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewPromotions;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconToggleStatus;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
