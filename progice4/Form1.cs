using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        private delegate int OperationHandler(int a, int b);
        private event OperationHandler OperationPerformed;

        private Calculator calculator;

        public CalculatorForm()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            calculator = new Calculator();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformOperation(calculator.Add);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            PerformOperation(calculator.Subtract);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            PerformOperation(calculator.Multiply);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            PerformOperation(calculator.Divide);
        }

        private void PerformOperation(OperationHandler operation)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text, out num1) && int.TryParse(txtNum2.Text, out num2))
            {
                int result = operation(num1, num2);
                lblResult.Text = result.ToString();
                OperationPerformed?.Invoke(num1, num2);
            }
            else
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

       
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b != 0)
                return a / b;
            else
                throw new DivideByZeroException("Cannot divide by zero.");
        }
    }
}
