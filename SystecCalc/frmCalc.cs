//This program is created for testing purposes, however, fell free to change any parts of it

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystecCalc
{
    public partial class frmCalc : Form
    {
        //Allows resetting display
        private static bool allowResetRes = false;
        public static bool AllowResetRes { get => allowResetRes; set => allowResetRes = value; }
        //Stack stores both variables and operators
        Stack calcStack = new Stack();

        public frmCalc() => InitializeComponent();
     

        //function to move content of calc display and operators to stack
        private void stackIt(string varToStack, string opToStack)
        {
            string tempFirstNum, tempSecondNum, tempOperator;
            //Checks for beginning of calculation and do nothing for "=" sign
            if (calcStack.Count == 0 && opToStack != "=")
            {
                calcStack.Push(varToStack);
                calcStack.Push(opToStack);
            } else if (calcStack.Count == 0 && opToStack == "=")
            {
                //do nothing here
            } else if (calcStack.Count == 2) //when there is one number and one operation on stack
            {
                //If second operation is one of menitoned we first have to calculate last input number with just enterend number
                //and then put it on stack with just entered operation
                if (opToStack == "+" || opToStack == "-" ||opToStack =="=")
                {

                    tempOperator = calcStack.Pop().ToString();
                    tempSecondNum = varToStack;
                    tempFirstNum = calcStack.Pop().ToString();
                    //reclycle of tempFirstNum
                    tempFirstNum = calculate(tempFirstNum, tempOperator, tempSecondNum);
                    tbResult.Text = tempFirstNum;
                    //If the stack here is empty and we dont want to store anything if "=" is pressed, just display it
                    if (opToStack != "=")
                    {
                        calcStack.Push(tempFirstNum);
                        calcStack.Push(opToStack);
                    }
                } else
                //In case of "*" or "/" we store it to stack
                {
                    calcStack.Push(varToStack);
                    calcStack.Push(opToStack);
                }

            } else
            {   //when stack is nor 0 or 2 elements we assume we have more elements
                //and we first have to multiply and divide...
                tempOperator = calcStack.Pop().ToString();
                tempSecondNum = calculate(calcStack.Pop().ToString(), tempOperator, varToStack);
                //...then we have to preform other operation from stack
                tempOperator = calcStack.Pop().ToString();
                tempFirstNum = calculate(calcStack.Pop().ToString(), tempOperator, tempSecondNum);

                //If the stack here is empty and we dont want to store anything if "=" is pressed, just display it
                if (opToStack != "=")
                {
                    calcStack.Push(tempFirstNum);
                    calcStack.Push(opToStack);
                }
                tbResult.Text = tempFirstNum;
            }
        }

        private string calculate(string first, string op, string second)
        {
            double calcResult = 0;
            switch (op)
            {
                case "*":
                    calcResult = float.Parse(first) * float.Parse(second);
                    break;
                case "/":
                    calcResult = 0;
                    if (float.Parse(second) != 0)
                    {
                        calcResult = float.Parse(first) / float.Parse(second);
                    }
                    break;
                case "+":
                    calcResult = float.Parse(first) + float.Parse(second);
                    break;
                case "-":
                    calcResult = float.Parse(first) - float.Parse(second);
                    break;
            }
            return calcResult.ToString();
        }

        private void updateResult(string numAdd)
        {
            float value;
            //if number or dot is entered, just add it to display
            if (float.TryParse(numAdd, out value) || numAdd == ".")
            {
                if ((tbResult.Text == "0" && numAdd != ".") || AllowResetRes == true) tbResult.Text = "";
                AllowResetRes = false;
                tbResult.Text += numAdd;
            }
            else
            {
                if (numAdd == "+" || numAdd == "-" || numAdd == "*" || numAdd == "/" || numAdd == "=")
                {
                    stackIt(tbResult.Text, numAdd);
                    tbOperations.Text = numAdd;
                    AllowResetRes = true;
                } else if (numAdd == "C")
                {   //reset tbOperations value
                    tbOperations.Text = "";
                    //Reset tbResult value
                    tbResult.Text = "0";
                    //Empty calcStack
                    while (calcStack.Count > 0)
                    {
                        calcStack.Pop();
                    }
                }

            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            updateResult(((System.Windows.Forms.ButtonBase)sender).Text);
        }

        private void frmCalc_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    e.Handled = true;
                    btn1.PerformClick();
                    break;
                case Keys.D2:
                    e.Handled = true;
                    btn2.PerformClick();
                    break;
                case Keys.D3:
                    e.Handled = true;
                    btn3.PerformClick();
                    break;
                case Keys.D4:
                    e.Handled = true;
                    btn4.PerformClick();
                    break;
                case Keys.D5:
                    e.Handled = true;
                    btn5.PerformClick();
                    break;
                case Keys.D6:
                    e.Handled = true;
                    btn6.PerformClick();
                    break;
                case Keys.D7:
                    e.Handled = true;
                    if (e.Shift != true)
                    {
                        btn7.PerformClick();
                    } else
                    {
                        btnDiv.PerformClick();
                    }
                    break;
                case Keys.D8:
                    e.Handled = true;
                    btn8.PerformClick();
                    break;
                case Keys.D9:
                    e.Handled = true;
                    btn9.PerformClick();
                    break;
                case Keys.D0:
                    e.Handled = true;
                    btn0.PerformClick();
                    break;
                case Keys.Enter:
                    e.Handled = true;
                    btnEqual.PerformClick();
                    break;
                case Keys.Oemplus:
                    e.Handled = true;
                    if (e.Shift != true)
                    {
                        btnPlus.PerformClick();
                    } else btnTimes.PerformClick();
                    break;
                case Keys.OemMinus:
                    e.Handled = true;
                    btnMinus.PerformClick();
                    break;

                case Keys.Delete:
                    e.Handled = true;
                    btnC.PerformClick();
                    break;
                case Keys.OemPeriod:
                    e.Handled = true;
                    btnDot.PerformClick();
                    break;
                case Keys.Oemcomma:
                    e.Handled = true;
                    btnDot.PerformClick();
                    break;
            }
        }
    }
}
