using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private string operation;
        private double result;
        private bool operationPerformed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button.Text == "C")
            {
                input.Clear();
                return;
            }

            if (button.Text == "=")
            {
                CalculateResult();
                return;
            }

            if (operationPerformed)
            {
                input.Clear();
                operationPerformed = false;
            }

            input.Text += button.Text;
        }

        private void CalculateResult()
        {
            // This code will evaluate the expression
            try
            {
                var expression = input.Text;
                var dataTable = new System.Data.DataTable();
                result = Convert.ToDouble(dataTable.Compute(expression, string.Empty));
                input.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
                input.Clear();
            }
        }
    }
}
