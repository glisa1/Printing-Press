using PrintingPress.Forms.SettingsForm;

namespace PrintingPress.SettingsForm
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            var comboBoxSelectables = SettingsFormDelimiterSelectables.GetDefaultSelectables();
            delimiterComboBox.DataSource = comboBoxSelectables;
            delimiterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            delimiterComboBox.SelectedIndexChanged += (sender, e) => SelectedDelimiter = (char)delimiterComboBox.SelectedValue;
            SelectedDelimiter = comboBoxSelectables.FirstOrDefault().CharValue;
        }
    }
}
