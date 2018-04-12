﻿using System;
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
        private bool inset_mode; //přepínač rozhodující o novém čísle, nebo jen přidání číslice ke stávajícímu číslu
        TextBlock display;

        public CalcBackend(TextBlock displ) {
            inset_mode = true;
            display = displ;
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

        public void num_btn_click(int number)
        {
            if (number == 0)
            {
                if (inset_mode)
                {
                    if (display.Text.Length == 1 && display.Text[0] == '0') // v případě, že již je zadaná 0, jako prvni znak nejde přidat další
                        return;
                    display.Text += "0";
                    display_textResize(display.Text.Length);
                }
            }
            else
            {
                if (inset_mode)
                {
                    display.Text += "" + number;
                    display_textResize(display.Text.Length);
                }
                else
                {
                    display.Text = "" + number;
                    inset_mode = true;
                }
            }
        }

        public void c_btn_click()
        {
            display.Text = "";
            inset_mode = true;
        }

        public void back_arr_btn_click()
        {
            if (display.Text.Length > 0)
                display.Text = display.Text.Remove(display.Text.Length - 1);
        } 

        public void point_btn_click()
        {
            if (inset_mode && display.Text.Length > 0 && !display.Text.Contains(','))
                display.Text += ",";
        }
    }
}
