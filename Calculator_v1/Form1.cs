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
        /// <summary>
        /// calculates the give equation
        /// </summary>
        private void CalculateEquation()
        {
            

            // 1. Enums ok
            // 2. New classes ok
            // 3 recurisve
            // 4. Switch statements
            this.CalculationResultText.Text = ParseOperation();
            
            
            //focus the user text
            FocusInputText();
        }
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

                }


                return string.Empty;
            }
            catch(Exception ex)
            {
                return $"Invalid eq. {ex.Message}";
            }
        }

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
