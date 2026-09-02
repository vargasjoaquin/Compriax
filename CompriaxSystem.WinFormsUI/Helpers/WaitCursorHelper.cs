namespace CompriaxSystem.WinFormsUI.Helpers
{
    internal class WaitCursorHelper : IDisposable
    {
        private readonly Form _f;
        public WaitCursorHelper(Form f)
        {
            _f = f;
            _f.Cursor = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            _f.Cursor = Cursors.Default;
        }
    }
}
