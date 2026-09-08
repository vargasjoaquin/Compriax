using CompriaxSystem.WinFormsUI.Helpers;
using DocumentFormat.OpenXml.Drawing;

namespace CompriaxSystem.WinFormsUI
{
    partial class FormHome
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
            this.pnlTopCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardSalesToday = new System.Windows.Forms.Panel();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblSalesAmount = new System.Windows.Forms.Label();
            this.cardWeekly = new System.Windows.Forms.Panel();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblWeeklyAmount = new System.Windows.Forms.Label();
            this.cardTickets = new System.Windows.Forms.Panel();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblSalesCount = new System.Windows.Forms.Label();
            this.cardStockAlert = new System.Windows.Forms.Panel();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.pnlBottomContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopProducts = new System.Windows.Forms.Panel();
            this.lblTopProdTitle = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.pnlCriticalStock = new System.Windows.Forms.Panel();
            this.lblCriticalTitle = new System.Windows.Forms.Label();
            this.dgvCriticalStock = new System.Windows.Forms.DataGridView();

            this.pnlTopCards.SuspendLayout();
            this.cardSalesToday.SuspendLayout();
            this.cardWeekly.SuspendLayout();
            this.cardTickets.SuspendLayout();
            this.cardStockAlert.SuspendLayout();
            this.pnlBottomContent.SuspendLayout();
            this.pnlTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.pnlCriticalStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalStock)).BeginInit();
            this.SuspendLayout();

            // ==================== TARJETAS SUPERIORES (KPIs) ====================
            this.pnlTopCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopCards.Height = 110;
            this.pnlTopCards.ColumnCount = 4;
            this.pnlTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlTopCards.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);

            this.pnlTopCards.Controls.Add(this.cardSalesToday, 0, 0);
            this.pnlTopCards.Controls.Add(this.cardWeekly, 1, 0);
            this.pnlTopCards.Controls.Add(this.cardTickets, 2, 0);
            this.pnlTopCards.Controls.Add(this.cardStockAlert, 3, 0);

            // Card 1: Ventas Hoy
            SetupKpiCard(this.cardSalesToday, this.lblTitle1, "VENTAS DE HOY", this.lblSalesAmount, "$ 0,00", UIThemeHelper.Primary);

            // Card 2: Ventas Semana
            SetupKpiCard(this.cardWeekly, this.lblTitle2, "INGRESOS SEMANALES", this.lblWeeklyAmount, "$ 0,00", Color.FromArgb(79, 70, 229));

            // Card 3: Tickets
            SetupKpiCard(this.cardTickets, this.lblTitle3, "TICKETS DE HOY", this.lblSalesCount, "0", Color.FromArgb(15, 118, 110));

            // Card 4: Alerta Stock
            SetupKpiCard(this.cardStockAlert, this.lblTitle4, "PRODUCTOS STOCK BAJO", this.lblLowStockCount, "0", UIThemeHelper.Danger);

            // ==================== TABLAS INFERIORES ====================
            this.pnlBottomContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomContent.ColumnCount = 2;
            this.pnlBottomContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBottomContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBottomContent.Padding = new System.Windows.Forms.Padding(16, 8, 16, 16);
            this.pnlBottomContent.Controls.Add(this.pnlTopProducts, 0, 0);
            this.pnlBottomContent.Controls.Add(this.pnlCriticalStock, 1, 0);

            // Top Productos
            this.pnlTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopProducts.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvTopProducts, this.lblTopProdTitle });
            this.lblTopProdTitle.Text = "Artículos Más Vendidos de Hoy";
            this.lblTopProdTitle.Font = UIThemeHelper.FontHeader;
            this.lblTopProdTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopProdTitle.Height = 36;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;

            // Stock Crítico
            this.pnlCriticalStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCriticalStock.Controls.AddRange(new System.Windows.Forms.Control[] { this.dgvCriticalStock, this.lblCriticalTitle });
            this.lblCriticalTitle.Text = "Reposición Inmediata de Stock";
            this.lblCriticalTitle.Font = UIThemeHelper.FontHeader;
            this.lblCriticalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCriticalTitle.Height = 36;
            this.dgvCriticalStock.Dock = System.Windows.Forms.DockStyle.Fill;

            // Form Properties
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.pnlBottomContent, this.pnlTopCards });
            this.BackColor = UIThemeHelper.Background;
            this.Text = "Dashboard de Control";

            this.pnlTopCards.ResumeLayout(false);
            this.cardSalesToday.ResumeLayout(false);
            this.cardWeekly.ResumeLayout(false);
            this.cardTickets.ResumeLayout(false);
            this.cardStockAlert.ResumeLayout(false);
            this.pnlBottomContent.ResumeLayout(false);
            this.pnlTopProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.pnlCriticalStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalStock)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupKpiCard(System.Windows.Forms.Panel card, System.Windows.Forms.Label title, string titleText, System.Windows.Forms.Label value, string valText, Color accentColor)
        {
            card.Dock = System.Windows.Forms.DockStyle.Fill;
            card.BackColor = UIThemeHelper.Surface;
            card.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            UIThemeHelper.ApplyCardStyle(card);

            title.Text = titleText;
            title.Font = UIThemeHelper.FontSmall;
            title.ForeColor = UIThemeHelper.TextMuted;
            title.Location = new System.Drawing.Point(12, 10);
            title.AutoSize = true;

            value.Text = valText;
            value.Font = UIThemeHelper.FontDisplayMedium;
            value.ForeColor = accentColor;
            value.Location = new System.Drawing.Point(10, 36);
            value.AutoSize = true;

            card.Controls.AddRange(new System.Windows.Forms.Control[] { title, value });
        }

        private System.Windows.Forms.TableLayoutPanel pnlTopCards, pnlBottomContent;
        private System.Windows.Forms.Panel cardSalesToday, cardWeekly, cardTickets, cardStockAlert, pnlTopProducts, pnlCriticalStock;
        private System.Windows.Forms.Label lblTitle1, lblTitle2, lblTitle3, lblTitle4, lblSalesAmount, lblWeeklyAmount, lblSalesCount, lblLowStockCount;
        private System.Windows.Forms.Label lblTopProdTitle, lblCriticalTitle;
        private System.Windows.Forms.DataGridView dgvTopProducts, dgvCriticalStock;

        #endregion
    }
}