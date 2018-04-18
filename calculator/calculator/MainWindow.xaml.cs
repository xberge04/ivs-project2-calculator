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
        calculator.CalcBackend CalcDo; //objekt backendu
        Thickness ThickON; // konstanta uchovávající šířku rámečku zvoleného tlačítka
        Thickness ThicOFF; // konstanta uchovávající šířku rámečku zvoleného tlačítka
        Button lastSelected; //proměná uchovávající poslední zvolenou operaci
        bool evenClick; //proměná uchovávající sude/liché kliknutí; sudé = true, liché= false

        public MainWindow()
        {
            InitializeComponent();
            CalcDo = new CalcBackend(display_textBox);
            lastSelected = null;
            ThickON = new Thickness(2);
            ThicOFF = new Thickness(0);
            evenClick = false;
        }

        //vypiná označení všech tlačítek, nastavuje BorderThickness = 0
        private void turnOff_all_borders() {
            btn_plus.BorderThickness = ThicOFF;
            btn_minus.BorderThickness = ThicOFF;
            btn_mul.BorderThickness = ThicOFF;
            btn_div.BorderThickness = ThicOFF;
            btn_pow.BorderThickness = ThicOFF;
            btn_sqrt.BorderThickness = ThicOFF;
            btn_log.BorderThickness = ThicOFF;

        }
        //zvýraznění konkrétního tlačítka
        private void turnOn_this_border(Button B)
        {
            B.BorderThickness = ThickON;
        }

        //*****************************************************************************************************************************
        //number button clicks
        //*****************************************************************************************************************************
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(0);
            turnOff_all_borders();
        }
        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(1);
            turnOff_all_borders();
        }
        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(2);
            turnOff_all_borders();
        }
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(3);
            turnOff_all_borders();
        }
        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(4);
            turnOff_all_borders();
        }
        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(5);
            turnOff_all_borders();
        }
        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(6);
            turnOff_all_borders();
        }
        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(7);
            turnOff_all_borders();
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(8);
            turnOff_all_borders();
        }
        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(9);
            turnOff_all_borders();
        }
        //*****************************************************************************************************************************

        private void btn_point_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.point_btn_click();
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            CalcDo.c_btn_click();
            lastSelected = null;
            evenClick = false;
        }

        private void btn_back_arr_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.back_arr_btn_click();
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.eq_btn_click();
            lastSelected = null;
            evenClick = false;
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
            turnOff_all_borders();
            if (lastSelected != btn_plus) //kliknutí z jiné položky a zaškrtnutí současné
            {
                evenClick = true; 
                lastSelected = btn_plus;
                turnOn_this_border(btn_plus);
                CalcDo.two_operand_btn_click("+");
            }
            
            else if (evenClick && lastSelected == btn_plus) //this.tlačitko už je zaškrtnuté a odškrtne se
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_minus) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_minus;
                turnOn_this_border(btn_minus);
                CalcDo.two_operand_btn_click("-");
            }

            else if (evenClick && lastSelected == btn_minus) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_mul_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_mul) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_mul;
                turnOn_this_border(btn_mul);
                CalcDo.two_operand_btn_click("*");
            }

            else if (evenClick && lastSelected == btn_mul) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_div_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_div) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_div;
                turnOn_this_border(btn_div);
                CalcDo.two_operand_btn_click("/");
            }

            else if (evenClick && lastSelected == btn_div) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_pow_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_pow) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_pow;
                turnOn_this_border(btn_pow);
                CalcDo.two_operand_btn_click("**");
            }

            else if (evenClick && lastSelected == btn_pow) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_sqrt_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_sqrt) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_sqrt;
                turnOn_this_border(btn_sqrt);
                CalcDo.two_operand_btn_click("//");
            }

            else if (evenClick && lastSelected == btn_sqrt) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
            }
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            if (lastSelected != btn_log) //kliknutí z jiné položky
            {
                evenClick = true; //numisí být
                lastSelected = btn_log;
                turnOn_this_border(btn_log);
                CalcDo.two_operand_btn_click("log");
            }

            else if (evenClick && lastSelected == btn_log) //this.tlačitko je zaškrtnuté
            {
                lastSelected = null;
                CalcDo.two_operand_btn_click("");
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
    }
}