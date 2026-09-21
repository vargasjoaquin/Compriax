namespace CompriaxSystem.WinFormsUI
{
    partial class FormCategories
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
            this.picIconDelete = new System.Windows.Forms.PictureBox();
            this.picIconCancel = new System.Windows.Forms.PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelCard = new Panel();
            labelCategoryName = new Label();
            textBoxCategoryName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            dataGridViewCategories = new DataGridView();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1167, 56);
            panelHeader.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(478, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CATEGORÍAS Y FAMILIAS DE PRODUCTOS";

            // panelCard
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelCategoryName);
            panelCard.Controls.Add(textBoxCategoryName);
            panelCard.Controls.Add(labelDescription);
            panelCard.Controls.Add(textBoxDescription);
panelCard.Controls.Add(this.picIconSave);
            panelCard.Controls.Add(buttonSave);
panelCard.Controls.Add(this.picIconDelete);
            panelCard.Controls.Add(buttonDelete);
panelCard.Controls.Add(this.picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 72);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(340, 562);
            panelCard.TabIndex = 1;

            // labelCategoryName
            labelCategoryName.AutoSize = true;
            labelCategoryName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCategoryName.Location = new Point(16, 20);
            labelCategoryName.Name = "labelCategoryName";
            labelCategoryName.Size = new Size(196, 21);
            labelCategoryName.TabIndex = 0;
            labelCategoryName.Text = "Nombre de la Categoría:";

            // textBoxCategoryName
            textBoxCategoryName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCategoryName.Font = new Font("Segoe UI", 10F);
            textBoxCategoryName.Location = new Point(16, 45);
            textBoxCategoryName.Name = "textBoxCategoryName";
            textBoxCategoryName.Size = new Size(306, 30);
            textBoxCategoryName.TabIndex = 1;

            // labelDescription
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(16, 90);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 21);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Descripción:";

            // textBoxDescription
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(16, 115);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(306, 120);
            textBoxDescription.TabIndex = 3;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;

            // buttonSave
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.FlatAppearance.BorderSize = 0;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.FlatStyle = FlatStyle.Flat;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.ForeColor = Color.White;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.Location = new Point(16, 260);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.Name = "buttonSave";
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.Size = new Size(306, 92);
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.TabIndex = 4;
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.Text = "GUARDAR";
            // 
            // picIconSave
            // 
            this.picIconSave.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSave.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconSave.Location = new System.Drawing.Point(28, 294);
            this.picIconSave.Name = "picIconSave";
            this.picIconSave.Size = new System.Drawing.Size(24, 24);
            this.picIconSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSave.TabIndex = 99;
            this.picIconSave.TabStop = false;

            // 
            // picIconDelete
            // 
            this.picIconDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconDelete.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconDelete.Location = new System.Drawing.Point(28, 388);
            this.picIconDelete.Name = "picIconDelete";
            this.picIconDelete.Size = new System.Drawing.Size(24, 24);
            this.picIconDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconDelete.TabIndex = 99;
            this.picIconDelete.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(28, 484);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(24, 24);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSave.UseVisualStyleBackColor = false;

            // buttonDelete
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(16, 358);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(306, 85);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Visible = false;

            // buttonCancel
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.Location = new Point(15, 449);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(306, 94);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;

            // dataGridViewCategories
            dataGridViewCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCategories.BackgroundColor = Color.White;
            dataGridViewCategories.BorderStyle = BorderStyle.None;
            dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Location = new Point(375, 72);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.RowHeadersWidth = 51;
            dataGridViewCategories.Size = new Size(767, 562);
            dataGridViewCategories.TabIndex = 2;

            // FormCategories
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1167, 662);
            Controls.Add(dataGridViewCategories);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Name = "FormCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Categorías";
ResumeLayout(false);
            panelHeader.PerformLayout();
ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewCategories;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconDelete;
        private System.Windows.Forms.PictureBox picIconCancel;
    }
}
