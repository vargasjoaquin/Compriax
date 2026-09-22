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
            this.tableLayoutPanelTopCards = new System.Windows.Forms.TableLayoutPanel();
            this.panelCardSalesToday = new System.Windows.Forms.Panel();
            this.labelTitleSalesToday = new System.Windows.Forms.Label();
            this.labelSalesAmountToday = new System.Windows.Forms.Label();
            this.panelCardWeekly = new System.Windows.Forms.Panel();
            this.labelTitleWeekly = new System.Windows.Forms.Label();
            this.labelWeeklyAmount = new System.Windows.Forms.Label();
            this.panelCardTickets = new System.Windows.Forms.Panel();
            this.labelTitleTickets = new System.Windows.Forms.Label();
            this.labelSalesCountToday = new System.Windows.Forms.Label();
            this.panelCardStockAlert = new System.Windows.Forms.Panel();
            this.labelTitleStockAlert = new System.Windows.Forms.Label();
            this.labelLowStockCount = new System.Windows.Forms.Label();
            this.tableLayoutPanelBottomContent = new System.Windows.Forms.TableLayoutPanel();
            this.panelTopProductsContainer = new System.Windows.Forms.Panel();
            this.labelTopProductsTitle = new System.Windows.Forms.Label();
            this.dataGridViewTopProducts = new System.Windows.Forms.DataGridView();
            this.panelCriticalStockContainer = new System.Windows.Forms.Panel();
            this.labelCriticalStockTitle = new System.Windows.Forms.Label();
            this.dataGridViewCriticalStock = new System.Windows.Forms.DataGridView();

            this.tableLayoutPanelTopCards.SuspendLayout();
            this.panelCardSalesToday.SuspendLayout();
            this.panelCardWeekly.SuspendLayout();
            this.panelCardTickets.SuspendLayout();
            this.panelCardStockAlert.SuspendLayout();
            this.tableLayoutPanelBottomContent.SuspendLayout();
            this.panelTopProductsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopProducts)).BeginInit();
            this.panelCriticalStockContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriticalStock)).BeginInit();
            this.SuspendLayout();

            // ==================== TARJETAS SUPERIORES (KPIs) ====================
            this.tableLayoutPanelTopCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelTopCards.Height = 110;
            this.tableLayoutPanelTopCards.ColumnCount = 4;
            this.tableLayoutPanelTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTopCards.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);

            this.tableLayoutPanelTopCards.Controls.Add(this.panelCardSalesToday, 0, 0);
            this.tableLayoutPanelTopCards.Controls.Add(this.panelCardWeekly, 1, 0);
            this.tableLayoutPanelTopCards.Controls.Add(this.panelCardTickets, 2, 0);
            this.tableLayoutPanelTopCards.Controls.Add(this.panelCardStockAlert, 3, 0);

            // Card 1: Ventas Hoy
            SetupKpiCard(this.panelCardSalesToday, this.labelTitleSalesToday, "VENTAS DE HOY", this.labelSalesAmountToday, "$ 0,00", UIThemeHelper.Primary);

            // Card 2: Ventas Semana
            SetupKpiCard(this.panelCardWeekly, this.labelTitleWeekly, "INGRESOS SEMANALES", this.labelWeeklyAmount, "$ 0,00", Color.FromArgb(79, 70, 229));

            // Card 3: Tickets
            SetupKpiCard(this.panelCardTickets, this.labelTitleTickets, "TICKETS DE HOY", this.labelSalesCountToday, "0", Color.FromArgb(15, 118, 110));

            // Card 4: Alerta Stock
            SetupKpiCard(this.panelCardStockAlert, this.labelTitleStockAlert, "PRODUCTOS STOCK BAJO", this.labelLowStockCount, "0", UIThemeHelper.Danger);

            // ==================== TABLAS INFERIORES ====================
            this.tableLayoutPanelBottomContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottomContent.ColumnCount = 2;
            this.tableLayoutPanelBottomContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottomContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottomContent.Padding = new System.Windows.Forms.Padding(16, 8, 16, 16);
            this.tableLayoutPanelBottomContent.Controls.Add(this.panelTopProductsContainer, 0, 0);
            this.tableLayoutPanelBottomContent.Controls.Add(this.panelCriticalStockContainer, 1, 0);

            // Top Productos
            this.panelTopProductsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopProductsContainer.Controls.AddRange(new System.Windows.Forms.Control[] { this.dataGridViewTopProducts, this.labelTopProductsTitle });
            this.labelTopProductsTitle.Text = "Artículos Más Vendidos de Hoy";
            this.labelTopProductsTitle.Font = UIThemeHelper.FontHeader;
            this.labelTopProductsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTopProductsTitle.Height = 36;
            this.dataGridViewTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;

            // Stock Crítico
            this.panelCriticalStockContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCriticalStockContainer.Controls.AddRange(new System.Windows.Forms.Control[] { this.dataGridViewCriticalStock, this.labelCriticalStockTitle });
            this.labelCriticalStockTitle.Text = "Reposición Inmediata de Stock";
            this.labelCriticalStockTitle.Font = UIThemeHelper.FontHeader;
            this.labelCriticalStockTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCriticalStockTitle.Height = 36;
            this.dataGridViewCriticalStock.Dock = System.Windows.Forms.DockStyle.Fill;

            // Form Properties
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.tableLayoutPanelBottomContent, this.tableLayoutPanelTopCards });
            this.BackColor = UIThemeHelper.Background;
            this.Text = "Dashboard";

            this.tableLayoutPanelTopCards.ResumeLayout(false);
            this.panelCardSalesToday.ResumeLayout(false);
            this.panelCardWeekly.ResumeLayout(false);
            this.panelCardTickets.ResumeLayout(false);
            this.panelCardStockAlert.ResumeLayout(false);
            this.tableLayoutPanelBottomContent.ResumeLayout(false);
            this.panelTopProductsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopProducts)).EndInit();
            this.panelCriticalStockContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriticalStock)).EndInit();
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

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTopCards, tableLayoutPanelBottomContent;
        private System.Windows.Forms.Panel panelCardSalesToday, panelCardWeekly, panelCardTickets, panelCardStockAlert, panelTopProductsContainer, panelCriticalStockContainer;
        private System.Windows.Forms.Label labelTitleSalesToday, labelTitleWeekly, labelTitleTickets, labelTitleStockAlert, labelSalesAmountToday, labelWeeklyAmount, labelSalesCountToday, labelLowStockCount;
        private System.Windows.Forms.Label labelTopProductsTitle, labelCriticalStockTitle;
        private System.Windows.Forms.DataGridView dataGridViewTopProducts, dataGridViewCriticalStock;

        #endregion
    }
}