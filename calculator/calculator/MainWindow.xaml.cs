using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace teamCalculator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool inset_mode; //přepínač rozhodující o novém čísle, nebo jen přidání číslice ke stávajícímu číslu
        public MainWindow()
        {
            InitializeComponent();
            inset_mode = true;   
        }
        private void display_textResize(int num_of_digits)
        {
            if (num_of_digits > 17) //17 je stanovené maximum čísel, při standartní velikosti, které se vlezou na řádek
            {
                display_textBox.FontSize *= 0.95;
            }
            else if (num_of_digits < 17 && display_textBox.FontSize != 36)
            {
                display_textBox.FontSize = 36;
            }
        }

        private void num_btn_click(int number)
        {
            if (number == 0) {
                if (inset_mode)
                {
                    if (display_textBox.Text.Length == 1 && display_textBox.Text[0] == '0') // v případě, že již je zadaná 0, jako prvni znak nejde přidat další
                        return;
                    display_textBox.Text += "0";
                    display_textResize(display_textBox.Text.Length);
                }
            }
            else
            {
                if (inset_mode)
                {
                    display_textBox.Text += ""+number;
                    display_textResize(display_textBox.Text.Length);
                }
                else
                {
                    display_textBox.Text = ""+number;
                    inset_mode = true;
                }
            }    
         }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(0);
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(1);
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(2);
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(3);
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(4);
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(5);
        }

        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(6);
        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(7);
        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(8);
        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            num_btn_click(9);
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            display_textBox.Text = "";
            inset_mode = true;
        }

        private void btn_back_arr_Click(object sender, RoutedEventArgs e)
        {
            if (display_textBox.Text.Length > 0)
                display_textBox.Text = display_textBox.Text.Remove(display_textBox.Text.Length - 1);
        }

        private void btn_point_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode && display_textBox.Text.Length > 0 && !display_textBox.Text.Contains(','))
                display_textBox.Text += ",";

        }
    }
}
