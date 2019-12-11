using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_v1
{
    /// <summary>
    /// a basic calculator
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// default constructor
        /// </summary>
        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
        #region Clearing Methods
        /// <summary>
        /// clears the user input text
        /// </summary>
        /// <param name="sender">the event sender</param>
        /// <param name="e">the even argument</param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            //clears the text from the textbox1
            this.textBox1.Text = string.Empty;
            //focus the user text
            FocusInputText();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            //dekete the value after selected position
            DeleteTextValue();
          
            //focus the user text
            FocusInputText();
        }
        #endregion
        #region Operators Methods
        private void PercentButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            //focus the user text
            FocusInputText();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            //focus the user text
            FocusInputText();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            //focus the user text
            FocusInputText();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            //focus the user text
            FocusInputText();
        }
        private void EqualButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();
            //focus the user text
            FocusInputText();
        }

        #endregion
        #region Numbers Methods
        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            //focus the user text
            FocusInputText();
        }
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            //focus the user text
            FocusInputText();
        }
        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            //focus the user text
            FocusInputText();
        }
        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            //focus the user text
            FocusInputText();
        }
        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            //focus the user text
            FocusInputText();
        }
        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            //focus the user text
            FocusInputText();
        }
        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            //focus the user text
            FocusInputText();
        }
        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            //focus the user text
            FocusInputText();
        }
        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            //focus the user text
            FocusInputText();
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            //focus the user text
            FocusInputText();
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            //focus the user text
            FocusInputText();
        }

        #endregion
        #region calculate
        /// <summary>
        /// calculates the give equation
        /// </summary>
        private void CalculateEquation()
        {
            

            // 1. Enums ok
            // 2. New classes ok
            // for loops
            // try/catch
            // 3 recurisve
            // 4. Switch statements
            this.CalculationResultText.Text = ParseOperation();
            
            
            //focus the user text
            FocusInputText();
        }
        #endregion
        #region parseoperation
        /// <summary>
        /// parses the users equatiobn and calculates
        /// </summary>
        /// <returns></returns>
        private string ParseOperation()
        {
            
            try
            {
                //get the user equation input
                var Input = this.textBox1.Text;
                //remove all spaces
                Input = Input.Replace(" ", "");
                //create a new top level operation
                var operation = new Operation();
                var leftSide = true;
                //loop character if the input
                for (int i=0;i<Input.Length;i++)
                {
                    // TODO: Handle order priority
                    //       4.2 + 5.7 * 3
                    //       It should calculate 5 * 3 first, then 4 + the result (so 4 + 15)

                    // Check if the current character is a number
                    
                    if ("0123456789.".Any(c => Input[i] == c))
                    {
                        if (leftSide)
                        {
                            operation.LeftSide = AddNumberPart(operation.LeftSide, Input[i]);
                        }
                        else
                        {
                            operation.RightSide = AddNumberPart(operation.RightSide, Input[i]);
                        }
                    }
                    //if it is an operator (+-*/) set the operator type
                    else if ("+-*/".Any(c => Input[i] == c))
                    {
                        //of we are on the right side, we now need to calculate out current operation
                        //and set the result to the left side of the next operation
                        if(!leftSide)
                        {
                            //get the operator type
                            var operatorType = GetOperationType(Input[i]);

                            //check if we actually have a right side numbber
                            if (operation.RightSide.Length == 0)
                            {
                                //check the operator is not a minus (as thwety could be reating a negative number)
                                if (operatorType != OperatorType.Minus)
                                {
                                    throw new InvalidOperationException($"Operator (+ * / or mote than one -) specified without an right side number");
                                }
                                // if we got here, the operator type is a minus, and there is no left number currenty, so add the minus to the number
                                operation.RightSide += Input[i];
                            }
                            else
                            {
                                //4 + 5 *
                                //calculate previous equation and set to the ledft side
                                operation.LeftSide = CalculateOperation(operation);
                                //set new operator
                                operation.OperationType = operatorType;

                                //clear the previous right number
                                operation.RightSide = string.Empty;
                            }
                        }
                        else
                        {
                            //get the operator type
                            var operatorType = GetOperationType(Input[i]);

                            //check if we actually have a left side numbber
                            if(operation.LeftSide.Length == 0)
                            {
                                //check the operator is not a minus (as thwety could be reating a negative number)
                                if(operatorType != OperatorType.Minus)
                                {
                                    throw new InvalidOperationException($"Operator (+ * / or mote than one -) specified without an left side number");
                                }
                                // if we got here, the operator type is a minus, and there is no left number currenty, so add the minus to the number
                                operation.LeftSide += Input[i];
                            }
                            else
                            {
                                //if we get here, we have a left number and now an operator, so we want to move to the right side

                                //set the opeerator type
                                operation.OperationType = operatorType; // sprawdzic czy ma byc operationtype czy operator type ??
                                //move to the right side
                                leftSide = false;
                            }
                        }
                    }   
                }
                // if we are done parsing, and there were no exceptions
                //calculate current operation
                return CalculateOperation(operation);
            }
            catch(Exception ex)
            {
                return $"Invalid eq. {ex.Message}";
            }
        }
        /// <summary>
        /// calculate a <<see cref="Operation"/> and returns the result
        /// </summary>
        /// <param name="operation"> the operation to calculate</param>
        private string CalculateOperation(Operation operation)
        {
            //store the number values of the string representation
            decimal left = 0;
            decimal right = 0;

            // check if we have a valid left side number
            if(string.IsNullOrEmpty(operation.LeftSide) || !decimal.TryParse(operation.LeftSide, out left))
            {
                throw new InvalidOperationException($"Left side of the operation was not a number. {operation.LeftSide}");
            }
            // check if we have a valid right side number
            if (string.IsNullOrEmpty(operation.RightSide) || !decimal.TryParse(operation.RightSide, out right))
            {
                throw new InvalidOperationException($"Right side of the operation was not a number. {operation.RightSide}");
            }
            try
            {
                switch(operation.OperationType)
                {
                    case OperatorType.Add:
                        return (left + right).ToString();
                    case OperatorType.Minus:
                        return (left - right).ToString();
                    case OperatorType.Divide:
                        return (left / right).ToString();
                    case OperatorType.Multiply:
                        return (left * right).ToString();
                    default:
                        throw new InvalidOperationException($"Unkown operator type when calculating operation. {operation.OperationType}");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation{operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }
        }

        /// <summary>
        /// accepts a character and return the known <see cref="OperatorType"/>
        /// </summary>
        /// <param name="character"> the character to parrse</param>
        /// <returns></returns>
        private OperatorType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperatorType.Add;
                case '-':
                    return OperatorType.Minus;
                case '/':
                    return OperatorType.Divide;
                case '*':
                    return OperatorType.Multiply;
                default:
                    throw new InvalidOperationException($"Unkown operator type{character}");
            }
            
        }
        #endregion
        #region addnumber
        /// <summary>
        /// attemps to add a new character to the current number
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="newCharacter"></param>
        /// <returns></returns>
        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            //check if there is already a . in the num,ber
            if (newCharacter == '.' && currentNumber.Contains('.'))
                throw new InvalidOperationException($"Number {currentNumber} already contains a . and another cannot be added");

            return currentNumber + newCharacter;
        }
        #endregion
        #region Private helpers
        /// <summary>
        /// focused the user input text
        /// </summary>
        private void FocusInputText()
        {
            this.textBox1.Focus();
        }
        /// <summary>
        /// inserts the giveten text
        /// </summary>
        /// <param name="value"></param>
        private void InsertTextValue(string value)
        {
            //int a = 100000;
            //remember selection start
            var selectionStart = this.textBox1.SelectionStart;
            //set new text
            this.textBox1.Text = this.textBox1.Text.Insert(this.textBox1.SelectionStart, value);
            //restore selection start
            this.textBox1.SelectionStart = selectionStart + value.Length;
            //set selection length
            this.textBox1.SelectionLength = 0;
        }
        /// <summary>
        /// delete charakters
        /// </summary>
    
        private void DeleteTextValue()
        {
            //if we dont have value to delelte, return
            if (this.textBox1.Text.Length < this.textBox1.SelectionStart + 1)
                return;
            // Remember selection start
            var selectionStart = this.textBox1.SelectionStart;

            // Delete the character to the right of the selection
            this.textBox1.Text = this.textBox1.Text.Remove(this.textBox1.SelectionStart, 1);

            // Restore the selection start
            this.textBox1.SelectionStart = selectionStart;

            // Set selection length to zero
            this.textBox1.SelectionLength = 0;
        }
        #endregion
    }
}
