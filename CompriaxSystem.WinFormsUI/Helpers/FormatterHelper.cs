namespace CompriaxSystem.WinFormsUI.Helpers
{
    public class FormatterHelper
    {
        private static bool _isFormatting = false;

        public static void HandleCuitFormat(TextBox textBox)
        {
            if (_isFormatting) 
                return;

            string rawText = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (rawText.Length > 11)
                rawText = rawText.Substring(0, 11);

            string formattedText = rawText;

            if(rawText.Length > 2 && rawText.Length <= 10)
                formattedText = rawText.Insert(2, "-");
            else if(rawText.Length > 10)
                formattedText = rawText.Insert(2, "-").Insert(11, "-");

            _isFormatting = true;

            int cursorPosition = textBox.SelectionStart;
            int oldLength = textBox.Text.Length;

            textBox.Text = formattedText;

            if (textBox.Text.Length > oldLength && (cursorPosition == 2 || cursorPosition == 11))
                cursorPosition++;

            textBox.SelectionStart = Math.Max(0, Math.Min(cursorPosition, textBox.Text.Length));
            
            _isFormatting = false;
        }
    }
}
