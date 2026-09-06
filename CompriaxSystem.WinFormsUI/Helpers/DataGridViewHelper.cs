namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class DataGridViewHelper
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            UIHelper.FormatGrid(dgv); 
        }

        public static void ColorRowsByStatus(DataGridView dgv, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgv.Rows.Count) 
                return;

            var row = dgv.Rows[rowIndex];
            dynamic dataItem = row.DataBoundItem;

            if (dataItem != null)
            {
                try
                {
                    bool isActive = dataItem.IsActive;
                    
                    if (!isActive)
                    {
                        row.DefaultCellStyle.ForeColor = UIThemeHelper.Danger;
                        row.DefaultCellStyle.SelectionForeColor = UIThemeHelper.Danger;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = UIThemeHelper.TextMain;
                        row.DefaultCellStyle.SelectionForeColor = Color.White;
                    }
                }
                catch { /* Si la entidad no tiene IsActive, ignorar */ }
            }
        }
    }
}
