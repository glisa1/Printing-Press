using PrintingPress.Forms.SettingsForm;

namespace PrintingPress.SettingsForm
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            delimiterLabel = new Label();
            delimiterComboBox = new ComboBox();
            settingsTextBoxTitle = new TextBox();
            SuspendLayout();
            // 
            // delimiterLabel
            // 
            delimiterLabel.AutoSize = true;
            delimiterLabel.Location = new Point(21, 180);
            delimiterLabel.Margin = new Padding(4, 0, 4, 0);
            delimiterLabel.Name = "delimiterLabel";
            delimiterLabel.Size = new Size(132, 25);
            delimiterLabel.TabIndex = 1;
            delimiterLabel.Text = "Select delimiter";
            // 
            // delimiterComboBox
            // 
            delimiterComboBox.DisplayMember = "DisplayName";
            delimiterComboBox.FormattingEnabled = true;
            delimiterComboBox.Location = new Point(199, 172);
            delimiterComboBox.Margin = new Padding(4, 5, 4, 5);
            delimiterComboBox.Name = "delimiterComboBox";
            delimiterComboBox.Size = new Size(233, 33);
            delimiterComboBox.TabIndex = 2;
            delimiterComboBox.ValueMember = "CharValue";
            // 
            // settingsTextBoxTitle
            // 
            settingsTextBoxTitle.Enabled = false;
            settingsTextBoxTitle.Location = new Point(21, 12);
            settingsTextBoxTitle.Multiline = true;
            settingsTextBoxTitle.Name = "settingsTextBoxTitle";
            settingsTextBoxTitle.Size = new Size(411, 126);
            settingsTextBoxTitle.TabIndex = 3;
            settingsTextBoxTitle.Text = "Settings will be saved when the form is closed.";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 375);
            Controls.Add(settingsTextBoxTitle);
            Controls.Add(delimiterComboBox);
            Controls.Add(delimiterLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Text = "PrintingPress Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label delimiterLabel;
        private ComboBox delimiterComboBox;
        private TextBox settingsTextBoxTitle;

        public char SelectedDelimiter { get; set; }
    }
}