using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace calculator
{

    /**
     *@brief Třída zpracovává vstupy z UI 
     * 
     */
    public class CalcBackend
    {
        TextBlock display;
        Math_Library.Math Math;
        private bool insert_mode; //přepínač rozhodující o novém čísle, nebo jen přidání číslice ke stávajícímu číslu
        double operand1;
        bool firstTime_click; //znamená to, že ještě nebyla zadá žádná matematická operace
        bool was_firstTime_click; //jestli předchozí operace byla firsttime_click
        string lastOperator;

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

        private void display_textResize(int num_of_digits)
        {
            if (num_of_digits > 17) //17 je stanovené maximum čísel, při standartní velikosti, které se vlezou na řádek
            {
                display.FontSize *= 0.95;
            }
            else if (num_of_digits < 17 && display.FontSize != 36)
            {
                display.FontSize = 36;
            }
        }

        private void dislay_number(double number)
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

        private void do_math_operation()
        {
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

        public void num_invert_brn()
        {
            if (display.Text != "Chyba!")
                display.Text = "" + -(dispString_to_numb(display.Text));
        }

        public void num_btn_click(int number)
        {
            if (display.Text != "Chyba!")
            {
                if (number == 0)
                {
                    if (insert_mode)
                    {
                        if (display.Text.Length == 1 && display.Text[0] == '0') // v případě, že již je zadaná 0, jako prvni znak nejde přidat další
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

        public void c_btn_click()
        {
            operand1 = 0;
            lastOperator = "";
            firstTime_click = true;
            display.Text = "0";
            insert_mode = true;
        }

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
                                display.Text = display.Text.Remove(display.Text.Length - 5, 1);
                                if (display.Text[display.Text.Length - 4] != 'E')
                                    display.Text = display.Text.Remove(display.Text.Length - 1);
                        }
                        else if (display.Text[display.Text.Length - 5] == 'E')
                        {
                            if (display.Text.Length > 6)
                                display.Text = display.Text.Remove(display.Text.Length - 6, 1);
                                if (display.Text[display.Text.Length - 5] != 'E')
                                    display.Text = display.Text.Remove(display.Text.Length - 1);
                        } 
                        else
                            display.Text = display.Text.Remove(display.Text.Length - 1);
                    }
                    else if (display.Text.Length < 5 && display.Text.Length > 1)
                        display.Text = display.Text.Remove(display.Text.Length - 1);
                    else if (display.Text.Length == 1)
                    {
                        display.Text = "0";
                    }
                }
            
        } 

        public void point_btn_click()
        {
            if (display.Text != "Chyba!")
                if (insert_mode && display.Text.Length > 0 && !display.Text.Contains(','))
                    display.Text += ",";
        }

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
                                dislay_number(Math.Fact(dispString_to_numb(display.Text)));
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

        public void eq_btn_click()
        {
            if (display.Text != "Chyba!")
            {
                try
                {
                    do_math_operation();
                    lastOperator = "";
                    dislay_number(operand1);
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