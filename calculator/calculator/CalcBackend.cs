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
    class CalcBackend
    {
        private bool insert_mode; //přepínač rozhodující o novém čísle, nebo jen přidání číslice ke stávajícímu číslu
        TextBlock display;
        Math_Library.Math Math;
        double operand1;
        bool firstTime_click; //znamená to, že ještě nebyla zadá žádná matematická operace
        string myOperator;

        public CalcBackend(TextBlock displ) {
            insert_mode = true;
            display = displ;
            Math = new Math_Library.Math();
            operand1 = 0;
            firstTime_click = true;
            myOperator = "";
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
            switch (myOperator)
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
            display.Text = "" + -(dispString_to_numb(display.Text));
        }

        public void num_btn_click(int number)
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
            }
            else
            {
                if (insert_mode)
                {
                    display.Text += "" + number;
                    display_textResize(display.Text.Length);
                }
                else
                {
                    display.Text = "" + number;
                    insert_mode = true;
                }
            }
        }

        public void c_btn_click()
        {
            operand1 = 0;
            myOperator = "";
            firstTime_click = true;
            display.Text = "";
            insert_mode = true;
        }

        public void back_arr_btn_click()
        {
            if (display.Text.Length > 0)
                display.Text = display.Text.Remove(display.Text.Length - 1);
        } 

        public void point_btn_click()
        {
            if (insert_mode && display.Text.Length > 0 && !display.Text.Contains(','))
                display.Text += ",";
        }

        public void one_operand_btn_click(string operation) {
            switch (operation) {
                case "pi":
                    break;
                case "!":
                    if (display.Text.Length != 0)
                    {
                        display.Text = "" + Math.Fact(dispString_to_numb(display.Text));
                        insert_mode = false;
                    }
                    break;
                default:
                    break;
            }


        }

        public void two_operand_btn_click(string operation)
        {
            if (operation == "")
            {
                myOperator = operation;
                return;
            }
            if (firstTime_click)
            {
                operand1 = dispString_to_numb(display.Text);
                this.myOperator = operation;
                insert_mode = false;
                firstTime_click = false;
                return;
            }
            else
            {
                do_math_operation();
                myOperator = operation;
                display.Text = "" + operand1;
                insert_mode = false;
            }

        }


        public void eq_btn_click()
        {
            do_math_operation();

            myOperator = "";
            display.Text = "" + operand1;
            insert_mode = false;
            firstTime_click = true;

        }

    }
}
