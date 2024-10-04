using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private bool IsPresent(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }

        private bool IsWithinRange(decimal value)
        {
            return value >= 0 && value <= 1000000;
        }

        private bool IsOperator(string input)
        {
            return input == "+" || input == "-" || input == "*" || input == "/";
        }

        private bool IsValidOperation(decimal operand2, string operatorSymbol) // Updated parameter name
        {
            return !(operatorSymbol == "/" && operand2 == 0);
        }

        private bool IsValidData()
        {
            if (!IsPresent(txtOperand1.Text) || !IsPresent(txtOperand2.Text) || !IsPresent(txtOperator.Text))
                return false;

            if (!IsDecimal(txtOperand1.Text) || !IsDecimal(txtOperand2.Text))
                return false;

            decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
            decimal operand2 = Convert.ToDecimal(txtOperand2.Text);

            if (!IsWithinRange(operand1) || !IsWithinRange(operand2))
                return false;

            if (!IsOperator(txtOperator.Text))
                return false;

            if (!IsValidOperation(operand2, txtOperator.Text)) // Updated parameter name
                return false;

            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidData())
                {
                    MessageBox.Show("Invalid input. Please check your values.");
                    return;
                }

                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                string operatorSymbol = txtOperator.Text; // Updated variable name
                decimal result = 0;

                switch (operatorSymbol) // Updated variable name
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        result = operand1 / operand2;
                        break;
                }

                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.GetType()}\n{ex.StackTrace}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Do you really want to exit the program?",
                "EXIT NOW?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question );

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
