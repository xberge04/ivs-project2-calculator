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

namespace calculator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        calculator.CalcBackend CalcDo;
        Thickness ThickON;
        Thickness ThicOFF;
        Button lastSelected;

        public MainWindow()
        {
            InitializeComponent();
            CalcDo = new CalcBackend(display_textBox);
            lastSelected = null;
            ThickON = new Thickness(2);
            ThicOFF = new Thickness(0);
        }

        private void turnOff_all_borders() {
            btn_plus.BorderThickness = ThicOFF;
            btn_minus.BorderThickness = ThicOFF;
            btn_mul.BorderThickness = ThicOFF;
            btn_div.BorderThickness = ThicOFF;
            btn_pow.BorderThickness = ThicOFF;
            btn_sqrt.BorderThickness = ThicOFF;
            btn_log.BorderThickness = ThicOFF;

        }

        private bool doClick(Button pressed_btn)
        {
            if (lastSelected == pressed_btn)
            {
                CalcDo.two_operand_btn_click("");
                turnOff_all_borders();
                return false;
            }
            else
            {
                turnOff_all_borders();
                pressed_btn.BorderThickness = ThickON;
                lastSelected = pressed_btn;
                return true;
            }

        }

        //*****************************************************************************************************************************
        //number button clicks
        //*****************************************************************************************************************************
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(0);
        }
        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(1);
        }
        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(2);
        }
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(3);
        }
        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(4);
        }
        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(5);
        }
        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(6);
        }
        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(7);
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(8);
        }
        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(9);
        }
        //*****************************************************************************************************************************

        private void btn_point_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.point_btn_click();
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.c_btn_click();
            lastSelected = null;
        }

        private void btn_back_arr_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.back_arr_btn_click();
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.eq_btn_click();
            lastSelected = null;
            turnOff_all_borders();
        }
        //****************************************************************************************************************************
        //one opetand functions
        //****************************************************************************************************************************
        private void btn_fact_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.one_operand_btn_click("!");
            lastSelected = null;
            turnOff_all_borders();
        }
        //****************************************************************************************************************************
        //two operand functions
        //****************************************************************************************************************************
        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_plus))
            {
                CalcDo.two_operand_btn_click("+");
            }
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_minus))
            {
                CalcDo.two_operand_btn_click("-");
            }
        }

        private void btn_mul_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_mul))
            {
                CalcDo.two_operand_btn_click("*");
            }
        }

        private void btn_div_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_div))
            {
                CalcDo.two_operand_btn_click("/");
            }
        }

        private void btn_pow_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_pow))
            {
                CalcDo.two_operand_btn_click("power");
            }
        }

        private void btn_sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_sqrt))
            {
                CalcDo.two_operand_btn_click("root");
            }
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            if (doClick(btn_log))
            {
                CalcDo.two_operand_btn_click("log");
            }
        }
        //***********************************************************************************************************************
        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_invert_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_invert_brn();
        }

        private void Calculator_view_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
