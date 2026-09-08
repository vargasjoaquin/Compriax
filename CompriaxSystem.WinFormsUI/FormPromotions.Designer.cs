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
            pnlHeader = new Panel();
            lblTitle = new Label();
            gbPromo = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblType = new Label();
            cboType = new ComboBox();
            lblProduct = new Label();
            cboProduct = new ComboBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            lblNxM = new Label();
            numRequired = new NumericUpDown();
            lblPay = new Label();
            numPay = new NumericUpDown();
            lblStart = new Label();
            dtpStart = new DateTimePicker();
            lblEnd = new Label();
            dtpEnd = new DateTimePicker();
            btnSave = new Button();
            btnEdit = new Button();
            btnToggle = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvPromotions = new DataGridView();
            pnlHeader.SuspendLayout();
            gbPromo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRequired).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1241, 66);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(538, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MOTOR DE PROMOCIONES Y BONIFICACIONES";
            // 
            // gbPromo
            // 
            gbPromo.BackColor = Color.White;
            gbPromo.Controls.Add(lblName);
            gbPromo.Controls.Add(txtName);
            gbPromo.Controls.Add(lblDescription);
            gbPromo.Controls.Add(txtDescription);
            gbPromo.Controls.Add(lblType);
            gbPromo.Controls.Add(cboType);
            gbPromo.Controls.Add(lblProduct);
            gbPromo.Controls.Add(cboProduct);
            gbPromo.Controls.Add(lblCategory);
            gbPromo.Controls.Add(cboCategory);
            gbPromo.Controls.Add(lblDiscount);
            gbPromo.Controls.Add(numDiscount);
            gbPromo.Controls.Add(lblNxM);
            gbPromo.Controls.Add(numRequired);
            gbPromo.Controls.Add(lblPay);
            gbPromo.Controls.Add(numPay);
            gbPromo.Controls.Add(lblStart);
            gbPromo.Controls.Add(dtpStart);
            gbPromo.Controls.Add(lblEnd);
            gbPromo.Controls.Add(dtpEnd);
            gbPromo.Controls.Add(btnSave);
            gbPromo.Controls.Add(btnEdit);
            gbPromo.Controls.Add(btnToggle);
            gbPromo.Controls.Add(btnDelete);
            gbPromo.Location = new Point(16, 72);
            gbPromo.Name = "gbPromo";
            gbPromo.Size = new Size(1219, 232);
            gbPromo.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(16, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(165, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre Promoción:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(16, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(212, 30);
            txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescription.Location = new Point(245, 12);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(104, 21);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Descripción:";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(245, 37);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(213, 30);
            txtDescription.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblType.Location = new Point(479, 12);
            lblType.Name = "lblType";
            lblType.Size = new Size(159, 21);
            lblType.TabIndex = 4;
            lblType.Text = "Tipo de Promoción:";
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.Font = new Font("Segoe UI", 10F);
            cboType.Location = new Point(479, 36);
            cboType.Name = "cboType";
            cboType.Size = new Size(216, 31);
            cboType.TabIndex = 5;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblProduct.Location = new Point(16, 88);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(160, 21);
            lblProduct.TabIndex = 6;
            lblProduct.Text = "Producto Aplicable:";
            // 
            // cboProduct
            // 
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.Font = new Font("Segoe UI", 10F);
            cboProduct.Location = new Point(16, 112);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(330, 31);
            cboProduct.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategory.Location = new Point(365, 88);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(164, 21);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Categoría Aplicable:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 10F);
            cboCategory.Location = new Point(365, 112);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(330, 31);
            cboCategory.TabIndex = 9;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDiscount.Location = new Point(16, 161);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(113, 21);
            lblDiscount.TabIndex = 10;
            lblDiscount.Text = "% Descuento:";
            // 
            // numDiscount
            // 
            numDiscount.DecimalPlaces = 1;
            numDiscount.Font = new Font("Segoe UI", 10F);
            numDiscount.Location = new Point(16, 185);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(110, 30);
            numDiscount.TabIndex = 11;
            // 
            // lblNxM
            // 
            lblNxM.AutoSize = true;
            lblNxM.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNxM.Location = new Point(145, 161);
            lblNxM.Name = "lblNxM";
            lblNxM.Size = new Size(83, 21);
            lblNxM.TabIndex = 12;
            lblNxM.Text = "Lleva (N):";
            // 
            // numRequired
            // 
            numRequired.Font = new Font("Segoe UI", 10F);
            numRequired.Location = new Point(145, 185);
            numRequired.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRequired.Name = "numRequired";
            numRequired.Size = new Size(85, 30);
            numRequired.TabIndex = 13;
            numRequired.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblPay
            // 
            lblPay.AutoSize = true;
            lblPay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPay.Location = new Point(245, 161);
            lblPay.Name = "lblPay";
            lblPay.Size = new Size(83, 21);
            lblPay.TabIndex = 14;
            lblPay.Text = "Paga (M):";
            // 
            // numPay
            // 
            numPay.Font = new Font("Segoe UI", 10F);
            numPay.Location = new Point(245, 185);
            numPay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPay.Name = "numPay";
            numPay.Size = new Size(85, 30);
            numPay.TabIndex = 15;
            numPay.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStart.Location = new Point(350, 161);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(61, 21);
            lblStart.TabIndex = 16;
            lblStart.Text = "Desde:";
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(350, 185);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(130, 30);
            dtpStart.TabIndex = 17;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEnd.Location = new Point(500, 161);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(57, 21);
            lblEnd.TabIndex = 18;
            lblEnd.Text = "Hasta:";
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(500, 185);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(135, 30);
            dtpEnd.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(711, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(240, 94);
            btnSave.TabIndex = 20;
            btnSave.Text = "GUARDAR PROMOCION";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(957, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(243, 94);
            btnEdit.TabIndex = 21;
            btnEdit.Text = "EDITAR PROMOCION";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnToggle
            // 
            btnToggle.BackColor = Color.FromArgb(2, 132, 199);
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToggle.ForeColor = Color.White;
            btnToggle.Location = new Point(711, 112);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(240, 103);
            btnToggle.TabIndex = 22;
            btnToggle.Text = "ACTIVAR / PAUSAR PROMOCION";
            btnToggle.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(957, 112);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(243, 103);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "ELIMINAR PROMOCION";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(16, 322);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(152, 21);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Buscar Promoción:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(174, 319);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(420, 30);
            txtSearch.TabIndex = 3;
            // 
            // dgvPromotions
            // 
            dgvPromotions.BackgroundColor = Color.White;
            dgvPromotions.BorderStyle = BorderStyle.None;
            dgvPromotions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPromotions.Location = new Point(16, 360);
            dgvPromotions.Name = "dgvPromotions";
            dgvPromotions.RowHeadersWidth = 51;
            dgvPromotions.Size = new Size(1219, 350);
            dgvPromotions.TabIndex = 4;
            // 
            // FormPromotions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1241, 722);
            Controls.Add(dgvPromotions);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(gbPromo);
            Controls.Add(pnlHeader);
            Name = "FormPromotions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promociones y Descuentos";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            gbPromo.ResumeLayout(false);
            gbPromo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRequired).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPay).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPromotions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel gbPromo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblNxM;
        private System.Windows.Forms.NumericUpDown numRequired;
        private System.Windows.Forms.Label lblPay;
        private System.Windows.Forms.NumericUpDown numPay;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvPromotions;
    }
}