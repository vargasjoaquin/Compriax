namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class DataGridViewHelper
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            UIHelper.FormatGrid(dgv); 
        }

        public static void ColorRowsByStatus(DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count)
                return;

            var item = dgv.Rows[e.RowIndex].DataBoundItem;

            if (item != null)
            {
                var prop = item.GetType().GetProperty("IsActive");
                
                if (prop != null)
                {
                    bool isActive = (bool)prop.GetValue(item, null)!;
                    
                    if (!isActive)
                    {
                        e.CellStyle.ForeColor = UIThemeHelper.Danger;
                        e.CellStyle.SelectionForeColor = UIThemeHelper.Danger;
                    }
                }
            }
        }
    }
}
