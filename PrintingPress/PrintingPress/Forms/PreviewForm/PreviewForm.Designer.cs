namespace PrintingPress.Forms.PreviewForm
{
    partial class PreviewForm
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
            previewRichTextbox = new RichTextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // previewRichTextbox
            // 
            previewRichTextbox.Location = new Point(12, 113);
            previewRichTextbox.Name = "previewRichTextbox";
            previewRichTextbox.ScrollBars = RichTextBoxScrollBars.Vertical;
            previewRichTextbox.Size = new Size(346, 456);
            previewRichTextbox.TabIndex = 0;
            previewRichTextbox.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(346, 95);
            textBox1.TabIndex = 1;
            textBox1.Text = "You can change text here, it will be saved upon close. This form will close if the input loses focus.";
            // 
            // PreviewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 581);
            ControlBox = false;
            Controls.Add(textBox1);
            Controls.Add(previewRichTextbox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreviewForm";
            Text = "Press preview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox previewRichTextbox;
        private TextBox textBox1;
    }
}