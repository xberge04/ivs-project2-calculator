using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace calculator
{

    /// <summary>
    /// Calculate inputs from UI.
    /// </summary>
    public class CalcBackend
    {
        TextBlock display;
        Math_Library.Math Math;
        /// <summary>
        /// a switch that determines the new number, or just adding a digit to an existing number
        /// </summary>
        private bool insert_mode; 
        double operand1;
        /// <summary>
        /// it means that no mathematical operation has yet been entered
        /// </summary>
        bool firstTime_click; 
        /// <summary>
        /// if the previous operation was firsttime_click
        /// </summary>
        bool was_firstTime_click; 
        string lastOperator;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public CalcBackend(TextBlock displ) {
            display = displ;
            Math = new Math_Library.Math();
            insert_mode = true;
            operand1 = 0;
            firstTime_click = true;
            was_firstTime_click = false;
            lastOperator = "";
            display.Text = "0";
        }

        /// <summary>
        /// Method that changes font size on display depending on the number of characters displayed
        /// </summary>
        /// <param name="num_of_digits">Lenght of string</param>
        private void display_textResize(int num_of_digits)
        {
            /// <summary>
            /// 17 is the maximum of numbers which fits on the line at standard size,
            /// </summary>
            if (num_of_digits > 17) 
            {
                display.FontSize *= 0.95;
            }
            else if (num_of_digits < 17 && display.FontSize != 36)
            {
                display.FontSize = 36;
            }
        }

        /// <summary>
        /// renders the entered number and adjusts the font size by the number of digits
        /// </summary>
        /// <param name="number">Number to render on display</param>
        private void show_number(double number)
        {
            display.FontSize = 36;
            display.Text = "" + number;

            if (display.Text.Length > 30)
            {
                display.Text = ""+ dispString_to_numb(display.Text).ToString("e");
            }

            if (display.Text.Length > 17)
            {
                display.FontSize = 36 * Math.Pow(0.95, display.Text.Length - 17.0);
            }
        }


        /// <summary>
        /// Parses text to double and exchange ',' for '.' 
        /// </summary>
        /// <returns>Parsed string</returns>
        /// <param name="text">string to parse</param>
        private double dispString_to_numb(string text)
        {
            if (text.Length == 0)
                return 0;
            if (text.Contains(','))
            {
                text.Replace(',', '.');
                return double.Parse(text);
            }
            else {
                return double.Parse(text);
            }
        }

        /// <summary>
        /// Does the math operation.
        /// </summary>
        private void do_math_operation()
        {
            /// <sumamry> Variable lastOperator stores last operation which will be performed </summary>
                switch (lastOperator)
                {
                    case "+":
                        operand1 = Math.Add(operand1, dispString_to_numb(display.Text));
                        break;
                    case "-":
                        operand1 = Math.Add(operand1, -(dispString_to_numb(display.Text)));
                        break;
                    case "*":
                        operand1 = Math.Mul(operand1, dispString_to_numb(display.Text));
                        break;
                    case "/":
                        operand1 = Math.Div(operand1, dispString_to_numb(display.Text));
                        break;
                    case "power":
                        operand1 = Math.Pow(operand1, dispString_to_numb(display.Text));
                        break;
                    case "root":
                        operand1 = Math.Root(operand1, dispString_to_numb(display.Text));
                        break;
                    case "log":
                        operand1 = Math.Log(dispString_to_numb(display.Text), operand1);
                        break;
                    default:
                        break;
            }
        }

        /// <summary>
        /// Converts the number on the display to the opposite number
        /// </summary>
        public void num_invert_brn()
        {
            if (display.Text != "Chyba!")
                display.Text = "" + -(dispString_to_numb(display.Text));
        }

        /// <summary>
        /// Action after pressing number button
        /// </summary>
        /// <param name="number">Pressed number</param>
        public void num_btn_click(int number)
        {
            if (display.Text != "Chyba!")
            {
                if (number == 0)
                {
                    if (insert_mode)
                    {
                        /// <summary> if zero is entered next numbers cannot be inserted as the first</summary>
                        if (display.Text.Length == 1 && display.Text[0] == '0') 
                            return;
                        display.Text += "0";
                        display_textResize(display.Text.Length);
                    }
                    else
                    {
                        display.Text = 0.ToString();
                        display_textResize(display.Text.Length);
                        insert_mode = true;
                    }
                }
                else
                {
                    if (insert_mode)
                    {
                        if (display.Text.Length == 1 && display.Text[0] == '0')
                        {
                            display.Text = number.ToString();
                            display_textResize(display.Text.Length);
                        }
                        else
                        {
                            display.Text += "" + number;
                            display_textResize(display.Text.Length);
                        }
                    }
                    else
                    {
                        display.Text = "" + number;
                        insert_mode = true;
                    }
                }
            }
        }
  
        /// <summary>
        /// Action after pressing the reset button
        /// </summary>
        public void c_btn_click()
        {
            operand1 = 0;
            lastOperator = "";
            firstTime_click = true;
            display.Text = "0";
            insert_mode = true;
        }

        /// <summary>
        /// Action after pressing the button for erasing the last number
        /// </summary>
        public void back_arr_btn_click()
        {
            if (display.Text != "Chyba!")
                if (display.Text.Length >= 0)
                {
                    if (display.Text.Length >= 5)
                    {
                        if (display.Text[display.Text.Length - 4] == 'E')
                        {
                            if (display.Text.Length > 5)
                                show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 5, 1)));
                                if (display.Text[display.Text.Length - 4] != 'E')
                                show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 1)));
                        }
                        else if (display.Text[display.Text.Length - 5] == 'E')
                        {
                            if (display.Text.Length > 6)
                                show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 6, 1)));
                                if (display.Text[display.Text.Length - 5] != 'E')
                                show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 1)));
                        } 
                        else
                            show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 1)));
                    }
                    else if (display.Text.Length < 5 && display.Text.Length > 1)
                        show_number(dispString_to_numb(display.Text.Remove(display.Text.Length - 1)));
                    else if (display.Text.Length == 1)
                    {
                        show_number(dispString_to_numb("0"));
                    }
                }
            
        }

        /// <summary>
        /// Action after pressing the coma button
        /// </summary>
        public void point_btn_click()
        {
            if (display.Text != "Chyba!")
                if (insert_mode && display.Text.Length > 0 && !display.Text.Contains(','))
                    display.Text += ",";
        }

        /// <summary>
        /// Action after pressing the operation button which requires only one operand
        /// </summary>
        /// <param name="operation">Selected operation</param>
        public void one_operand_btn_click(string operation) {
            if (display.Text != "Chyba!")
            {
                try
                {
                    switch (operation)
                    {
                        case "!":
                            if (display.Text.Length != 0)
                            {
                                show_number(Math.Fact(dispString_to_numb(display.Text)));
                                insert_mode = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    display.Text = "Chyba!";
                    return;
                }
            }
        }

        /// <summary>
        /// Action after pressing the operation button which requires two operands
        /// </summary>
        /// <param name="operation">Selected operation</param>
        public void two_operand_btn_click(string operation)
        {
            if (display.Text != "Chyba!")
            {
                if (operation == "")
                {
                    if (was_firstTime_click)
                    {
                        firstTime_click = true;
                        was_firstTime_click = false;
                    }
                    lastOperator = "";
                    insert_mode = true;
                }
                else
                {
                    if (firstTime_click)
                    {
                        operand1 = dispString_to_numb(display.Text);
                        firstTime_click = false;
                        insert_mode = false;
                        was_firstTime_click = true;
                        lastOperator = operation;
                    }
                    else
                    {
                        do_math_operation();
                        lastOperator = operation;
                        display.Text = "" + operand1;
                        insert_mode = false;
                        was_firstTime_click = false;
                    }

                }
            }
        }

        /// <summary>
        /// Action after the '=' button
        /// </summary>
        public void eq_btn_click()
        {
            if (display.Text != "Chyba!")
            {
                try
                {
                    do_math_operation();
                    lastOperator = "";
                    show_number(operand1);
                    insert_mode = false;
                    firstTime_click = true;
                }
                catch (Exception)
                {
                    display.Text = "Chyba!";
                    return;
                }
            }
        }
    }
}