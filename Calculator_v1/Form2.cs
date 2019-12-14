using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_v1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region load

        private Form1 _mainForm = null;

        public Form2(Form callingForm)
        {
            _mainForm = callingForm as Form1;
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        #endregion
        #region basiccalc-ladowanie

        private void StandCalc_Click(object sender, EventArgs e)
        {
            Form1 frm2 = new Form1();
            frm2.Show();
            this.Hide();
        }

        #endregion

        #region clearing methods
        private void CEButton_Click(object sender, EventArgs e)
        {
            // Clears the text from the user input text box
            this.UserInputText.Text = string.Empty;
            this.CalculationResultText.Text = string.Empty;

            // Focus the user input text
            FocusInputText();
        }
        private void DelButton_Click(object sender, EventArgs e)
        {
            // Delete the value after the selected position
            DeleteTextValue();

            // Focus the user input text
            FocusInputText();
        }
        #endregion
        #region operators
        private void DivideButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("/");

            // Focus the user input text
            FocusInputText();
        }

        private void TimesButton_Click(object sender, EventArgs e)
        {
            
                // Insert the value in the user input text box at the currently selected position
                InsertTextValue("*");

                // Focus the user input text
                FocusInputText();
            
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("-");

            // Focus the user input text
            FocusInputText();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("+");

            // Focus the user input text
            FocusInputText();
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            // Calculate the equation
            CalculateEquation();

            // Focus the user input text
            FocusInputText();
        }
        private void PiButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("3,1416");

            // Focus the user input text
            FocusInputText();
        }

        private void Pow2Button_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("^");

            // Focus the user input text
            FocusInputText();
        }

        private void PierwButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            
            InsertTextValue("√");

            // Focus the user input text
            FocusInputText();
        }

        private void Pow3Button_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("#");

            // Focus the user input text
            FocusInputText();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("l");

            // Focus the user input text
            FocusInputText();
        }
        #endregion
        #region number method
        private void DotButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue(",");

            // Focus the user input text
            FocusInputText();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("0");

            // Focus the user input text
            FocusInputText();
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("1");

            // Focus the user input text
            FocusInputText();
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("2");

            // Focus the user input text
            FocusInputText();
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("3");

            // Focus the user input text
            FocusInputText();
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("4");

            // Focus the user input text
            FocusInputText();
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("5");

            // Focus the user input text
            FocusInputText();
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("6");

            // Focus the user input text
            FocusInputText();
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("7");

            // Focus the user input text
            FocusInputText();
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("8");

            // Focus the user input text
            FocusInputText();
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            // Insert the value in the user input text box at the currently selected position
            InsertTextValue("9");

            // Focus the user input text
            FocusInputText();
        }
        #endregion
        #region quation
        private void CalculateEquation()
        {
            // 1. Enums
            // 2. New classes
            // 3. For loops
            // 4. try/catch

            // 5. Recursive functions
            // 6. Switch statements

            this.CalculationResultText.Text = ParseOperation();

            // Focus the user input text
            FocusInputText();
        }

        /// <summary>
        /// Parses the users equation and calculates the result
        /// </summary>
        /// <returns></returns>
        private string ParseOperation()
        {
            try
            {
                // Get the users equation input
                var input = this.UserInputText.Text;

                // Remove all spaces
                input = input.Replace(" ", "");

                // Create a new top-level operation
                var operation = new Operation();
                var leftSide = true;

                // Loop through each character of the input
                // starting from the left working to the right
                for (int i = 0; i < input.Length; i++)
                {
                    // TODO: Handle order priority
                    //       4.2 + 5.7 * 3
                    //       It should calculate 5 * 3 first, then 4 + the result (so 4 + 15)

                    // Check if the current character is a number
                    if ("0123456789,".Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        else
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);
                    }
                    // If it is an operator ( + - * / ) set the operator type
                    else if ("+-*/l#^".Any(c => input[i] == c))
                    {
                        // If we are on the right side already, we now need to calculate our current operation
                        // and set the result to the left side of the next operation
                        if (!leftSide)
                        {
                            // Get the operator type
                            var operatorType = GetOperationType(input[i]);

                            // Check if we actually have a right side number
                            if (operation.RightSide.Length == 0)
                            {
                                // Check the operator is not a minus (as they could be creating a negative number)
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without an right side number");

                                // If we got here, the operator type is a minus, and there is no left number currently, so add the minus to the number
                                operation.RightSide += input[i];
                            }
                            else
                            {
                                // Calculate previous equation and set to the left side
                                operation.LeftSide = CalculateOperation(operation);

                                // Set new operator
                                operation.OperationType = operatorType;

                                // Clear the previous right number
                                operation.RightSide = string.Empty;
                            }
                        }
                        else
                        {
                            // Get the operator type
                            var operatorType = GetOperationType(input[i]);

                            // Check if we actually have a left side number
                            if (operation.LeftSide.Length == 0)
                            {
                                // Check the operator is not a minus (as they could be creating a negative number)
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without an left side number");

                                // If we got here, the operator type is a minus, and there is no left number currently, so add the minus to the number
                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                // If we get here, we have a left number and now an operator, so we want to move to the right side

                                // Set the operation type
                                operation.OperationType = operatorType;

                                // Move to the right side
                                leftSide = false;
                            }
                        }
                    }
                }

                // If we are done parsing, and there were no exceptions
                // calculate the current operation
                return CalculateOperation(operation);
            }
            catch (Exception ex)
            {
                return $"Invalid equation. {ex.Message}";
            }
        }

        /// <summary>
        /// Calculates an <see cref="Operation"/> and returns the result
        /// </summary>
        /// <param name="operation">The operation to calculate</param>
        private string CalculateOperation(Operation operation)
        {
            // Store the number values of the string representations
            double left = 0;
            double right = 0;

            // Check if we have a valid left side number
            if (string.IsNullOrEmpty(operation.LeftSide) || !double.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException($"Left side of the operation was not a number. {operation.LeftSide}");

            // Check if we have a valid right side number
            if (string.IsNullOrEmpty(operation.RightSide) || !double.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException($"Right side of the operation was not a number. {operation.RightSide}");

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    case OperationType.Pow2:
                        return (Math.Pow(left, right)).ToString();
                    /*case OperationType.Pow3:
                        right = 3;
                        return (Math.Pow(left, right)).ToString();*/
                    case OperationType.Logg:
                        return (Math.Log(left, right)).ToString();
                    /*case OperationType.SQT:
                        return SQT.ToString();*/
                    default:
                        throw new InvalidOperationException($"Unknown operator type when calculating operation. { operation.OperationType }");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }
        }

        /// <summary>
        /// Accepts a character and returns the known <see cref="OperationType"/>
        /// </summary>
        /// <param name="character">The character to parse</param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Add;
                case '-':
                    return OperationType.Minus;
                case '/':
                    return OperationType.Divide;
                case '*':
                    return OperationType.Multiply;
                case '^':
                    return OperationType.Pow2;
                case '#':
                    return OperationType.Pow3;
                case 'l':
                    return OperationType.Logg;
                case '√':
                    return OperationType.SQT;
                default:
                    throw new InvalidOperationException($"Unknown operator type { character }");
            }
        }

        /// <summary>
        /// Attempts to add a new character to the current number, checking for valid characters as it goes
        /// </summary>
        /// <param name="currentNumber">The current number string</param>
        /// <param name="newCharacter">The new character to append to the string</param>
        /// <returns></returns>
        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            // Check if there is already a . in the number
            if (newCharacter == ',' && currentNumber.Contains(','))
                throw new InvalidOperationException($"Number {currentNumber} already contains a . and another cannot be added");

            return currentNumber + newCharacter;
        }
        #endregion
        #region Private Helpers

        /// <summary>
        /// Focuses the user input text
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        /// <summary>
        /// Inserts the given text into the user input text box
        /// </summary>
        /// <param name="value">The value to insert</param>
        private void InsertTextValue(string value)
        {
            // Remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            // Set new text
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);

            // Restore the selection start
            this.UserInputText.SelectionStart = selectionStart + value.Length;

            // Set selection length to zero
            this.UserInputText.SelectionLength = 0;
        }

        /// <summary>
        /// Deletes the character to the right of the selection start of the user input text box
        /// </summary>
        private void DeleteTextValue()
        {
            if ((String.Compare(UserInputText.Text, " ") < 0))
            {
                UserInputText.Text = UserInputText.Text.Substring(0, UserInputText.Text.Length - 1 + 1);
            }
            else
            {
                UserInputText.Text = UserInputText.Text.Substring(0, UserInputText.Text.Length - 1);
            }
        }

        #endregion

        


    }
}