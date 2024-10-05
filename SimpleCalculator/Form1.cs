//Simple Calculator Assignment by Sikanderdeep Singh Kingra

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
        //To make sure the textboxes are not empty
        private bool IsPresent(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }
        //To check if the values entered are within the required range
        private bool IsWithinRange(decimal value)
        {
            return value >= 0 && value <= 1000000;
        }
        //To make sure the operator entered is One of the defined ones
        private bool IsOperator(string input)
        {
            return input == "+" || input == "-" || input == "*" || input == "/";
        }
        //Checks the validation of all the data entered by running previous defined methods
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
                //Displays result
                txtResult.Text = result.ToString();
            }
               //Exceptions used to catch specific errors
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter valid numeric values.\n" +
                                "Error Type: " + ex.GetType().Name + "\n" +
                                "Error Message: " + ex.Message,
                                "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("The number entered is too large or too small.\n" +
                                "Error Type: " + ex.GetType().Name + "\n" +
                                "Error Message: " + ex.Message,
                                "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Division by zero is not allowed.\n" +
                                "Error Type: " + ex.GetType().Name + "\n" +
                                "Error Message: " + ex.Message,
                                "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // General catch for any other exceptions
                MessageBox.Show("An error occurred:\n" +
                                "Error Type: " + ex.GetType().Name + "\n" +
                                "Error Message: " + ex.Message + "\n" +
                                "Stack Trace: " + ex.StackTrace,
                                "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void lblOperand1_Click(object sender, EventArgs e)
        {

        }
    }
}


