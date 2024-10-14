namespace CalculatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // input
            this.input.Location = new System.Drawing.Point(50, 20);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(200, 20);
            this.input.TabIndex = 0;

            // buttons
            string[] buttonLabels = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };
            for (int i = 0; i < buttonLabels.Length; i++)
            {
                var button = new System.Windows.Forms.Button
                {
                    Text = buttonLabels[i],
                    Width = 50,
                    Height = 50,
                    Left = 50 + (i % 4) * 60,
                    Top = 60 + (i / 4) * 60
                };
                button.Click += Button_Click;
                this.Controls.Add(button);
            }

            // Form1
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.input);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox input;
    }
}
