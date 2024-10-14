using System.ComponentModel;
using System.Windows.Forms;

namespace WeatherApp
{
    partial class Form1
    {
        private IContainer components = null;

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
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.getWeatherButton = new System.Windows.Forms.Button();
            this.weatherLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // cityTextBox
            this.cityTextBox.Location = new System.Drawing.Point(30, 30);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(200, 20);
            this.cityTextBox.TabIndex = 0;

            // getWeatherButton
            this.getWeatherButton.Location = new System.Drawing.Point(250, 30);
            this.getWeatherButton.Name = "getWeatherButton";
            this.getWeatherButton.Size = new System.Drawing.Size(75, 23);
            this.getWeatherButton.TabIndex = 1;
            this.getWeatherButton.Text = "Get Weather";
            this.getWeatherButton.UseVisualStyleBackColor = true;
            this.getWeatherButton.Click += new System.EventHandler(this.GetWeatherButton_Click);

            // weatherLabel
            this.weatherLabel.AutoSize = true;
            this.weatherLabel.Location = new System.Drawing.Point(30, 70);
            this.weatherLabel.Name = "weatherLabel";
            this.weatherLabel.Size = new System.Drawing.Size(0, 13);
            this.weatherLabel.TabIndex = 2;

            // Form1
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this.weatherLabel);
            this.Controls.Add(this.getWeatherButton);
            this.Controls.Add(this.cityTextBox);
            this.Name = "Form1";
            this.Text = "Weather App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Button getWeatherButton;
        private System.Windows.Forms.Label weatherLabel;
    }
}
