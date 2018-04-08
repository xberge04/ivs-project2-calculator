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

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                 display_textBox.Text += "0";

            //@todo nesmí jít přidat na začátku víc jak jedna nula (00,5)

        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "1";
            else
            {
                display_textBox.Text = "1";
                inset_mode = true;
            }
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "2";
            else
            {
                display_textBox.Text = "2";
                inset_mode = true;
            }
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "3";
            else
            {
                display_textBox.Text = "3";
                inset_mode = true;
            }
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "4";
            else
            {
                display_textBox.Text = "4";
                inset_mode = true;
            }
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "5";
            else
            {
                display_textBox.Text = "5";
                inset_mode = true;
            }
        }

        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "6";
            else
            {
                display_textBox.Text = "6";
                inset_mode = true;
            }
        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "7";
            else
            {
                display_textBox.Text = "7";
                inset_mode = true;
            }
        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "8";
            else
            {
                display_textBox.Text = "8";
                inset_mode = true;
            }
        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            if (inset_mode)
                display_textBox.Text += "9";
            else
            {
                display_textBox.Text = "9";
                inset_mode = true;
            }
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
            if (inset_mode && display_textBox.Text.Length > 0)
                display_textBox.Text += ",";

        }
    }
}
