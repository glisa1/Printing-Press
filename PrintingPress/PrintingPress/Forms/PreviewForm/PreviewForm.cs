namespace PrintingPress.Forms.PreviewForm
{
    public partial class PreviewForm : Form
    {
        private readonly Action<string> saveChanges;

        public PreviewForm(string previewText, Action<string> saveChanges)
        {
            InitializeComponent();
            previewRichTextbox.LostFocus += OnLostFocus;

            previewRichTextbox.Text = previewText;
            this.saveChanges = saveChanges;
        }

        private void OnLostFocus(object? sender, EventArgs e)
        {
            saveChanges.Invoke(previewRichTextbox.Text);

            Close();
        }
    }
}
