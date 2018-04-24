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
    /// Interacting logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        calculator.CalcBackend CalcDo; ///<summary>Backend object </summary> 
        Thickness ThickON; ///<summary> a constant holding the width of the selected button frame </summary>
        Thickness ThicOFF; ///<summary> a constant holding the width of the selected button frame </summary>
        Button lastSelected;///<summary> variable with last operation </summary> 
        bool evenClick;///<summary> variable which stores even/odd state of click, even = true, odd - false</summary>
        bool operatorClicked;///<summary>variable which stores information about operator button click</summary>  
        
        public MainWindow()
        {
            InitializeComponent();
            CalcDo = new CalcBackend(display_textBox);
            lastSelected = null;
            ThickON = new Thickness(2);
            ThicOFF = new Thickness(0);
            evenClick = false;
            operatorClicked = false;
        }

        /// <summary>
        /// Turns off graphic of all buttons => sets BorderThickness = 0
        /// </summary>
        private void turnOff_all_borders() {
            btn_plus.BorderThickness = ThicOFF;
            btn_minus.BorderThickness = ThicOFF;
            btn_mul.BorderThickness = ThicOFF;
            btn_div.BorderThickness = ThicOFF;
            btn_pow.BorderThickness = ThicOFF;
            btn_sqrt.BorderThickness = ThicOFF;
            btn_log.BorderThickness = ThicOFF;

        }

        /// <summary>
        /// Highlights concrete button.
        /// </summary>
        /// <param name="B">Button to highlight</param>
        private void turnOn_this_border(Button B)
        {
            B.BorderThickness = ThickON;
        }

        /// <summary>
        /// A group of methods handling actions after pressing a number key
        /// </summary>
        #region number_btn_click actions
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(0);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(1);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(2);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(3);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(4);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(5);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(6);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(7);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(8);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_btn_click(9);
            turnOff_all_borders();
            lastSelected = null;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        #endregion
        private void btn_point_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.point_btn_click();
            Keyboard.Focus(btn_eq);
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            turnOff_all_borders();
            CalcDo.c_btn_click();
            lastSelected = null;
            evenClick = false;
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }

        private void btn_back_arr_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.back_arr_btn_click();
            Keyboard.Focus(btn_eq);
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.eq_btn_click();
            lastSelected = null;
            evenClick = false;
            turnOff_all_borders();
            operatorClicked = false;
        }

        /// <summary>
        /// A group of methods for pushing the operation button
        /// </summary>
        #region Operand_btn_Click actions
        #region One_operand_btn_Click actions
        private void btn_fact_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.one_operand_btn_click("!");
            lastSelected = null;
            turnOff_all_borders();
            Keyboard.Focus(btn_eq);
            operatorClicked = false;
        }
        #endregion

        #region two_operand_operations_btn_click actions
        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// clicks from another item and tick the current one
                if (lastSelected != btn_plus) /// </summary>
                {
                    evenClick = true;
                    lastSelected = btn_plus;
                    turnOn_this_border(btn_plus);
                    CalcDo.two_operand_btn_click("+");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is already checked and will uncheck
                /// </summary>
                else if (evenClick && lastSelected == btn_plus) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// clicks from another item
                /// </summary>
                if (lastSelected != btn_minus) 
                {
                    evenClick = true; 
                    lastSelected = btn_minus;
                    turnOn_this_border(btn_minus);
                    CalcDo.two_operand_btn_click("-");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_minus) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_mul_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// click from another item
                /// </summary>
                if (lastSelected != btn_mul) 
                {
                    evenClick = true; 
                    lastSelected = btn_mul;
                    turnOn_this_border(btn_mul);
                    CalcDo.two_operand_btn_click("*");
                    Keyboard.Focus(btn_eq);
                }

                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_mul) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_div_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// click from another item
                /// </summary>
                if (lastSelected != btn_div) 
                {
                    evenClick = true; //numisí být
                    lastSelected = btn_div;
                    turnOn_this_border(btn_div);
                    CalcDo.two_operand_btn_click("/");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_div) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_pow_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// click from another item
                /// </summary>
                if (lastSelected != btn_pow) 
                {
                    evenClick = true; //numisí být
                    lastSelected = btn_pow;
                    turnOn_this_border(btn_pow);
                    CalcDo.two_operand_btn_click("power");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_pow)
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// click from another item
                /// </summary>
                if (lastSelected != btn_sqrt) //kliknutí z jiné položky
                {
                    evenClick = true; //numisí být
                    lastSelected = btn_sqrt;
                    turnOn_this_border(btn_sqrt);
                    CalcDo.two_operand_btn_click("root");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_sqrt) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            if (!operatorClicked)
            {
                turnOff_all_borders();
                /// <summary>
                /// click from another item
                /// </summary>
                if (lastSelected != btn_log) 
                {
                    evenClick = true; //numisí být
                    lastSelected = btn_log;
                    turnOn_this_border(btn_log);
                    CalcDo.two_operand_btn_click("log");
                    Keyboard.Focus(btn_eq);
                }
                /// <summary>
                /// this.button is checked
                /// </summary>
                else if (evenClick && lastSelected == btn_log) 
                {
                    lastSelected = null;
                    CalcDo.two_operand_btn_click("");
                    Keyboard.Focus(btn_eq);
                }
                operatorClicked = true;
            }
        }
        #endregion
        #endregion 
        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_invert_Click(object sender, RoutedEventArgs e)
        {
            CalcDo.num_invert_brn();
            Keyboard.Focus(btn_eq);
        }

        private void Calculator_view_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad0)
            {
                btn_0_Click(sender, e);
                
            }
            else if (e.Key == Key.NumPad1)
            {
                btn_1_Click(sender, e);

            }
            else if (e.Key == Key.NumPad2)
            {
                btn_2_Click(sender, e);

            }
            else if (e.Key == Key.NumPad3)
            {
                btn_3_Click(sender, e);

            }
            else if (e.Key == Key.NumPad4)
            {
                btn_4_Click(sender, e);
            }
            else if (e.Key == Key.NumPad5)
            {
                btn_5_Click(sender, e);
            }
            else if (e.Key == Key.NumPad6)
            {
                btn_6_Click(sender, e);
            }
            else if (e.Key == Key.NumPad7)
            {
                btn_7_Click(sender, e);
            }
            else if (e.Key == Key.NumPad8)
            {
                btn_8_Click(sender, e);
            }
            else if (e.Key == Key.NumPad9)
            {
                btn_9_Click(sender, e);
            }
            else if (e.Key == Key.Add)
            {
                btn_plus_Click(sender, e);
                
            }
            else if (e.Key == Key.Multiply)
            {
                btn_mul_Click(sender, e);

            }
            else if (e.Key == Key.Divide)
            {
                btn_div_Click(sender, e);

            }
            else if (e.Key == Key.Subtract)
            {
                btn_minus_Click(sender, e);
            }
            else if (e.Key == Key.Decimal)
            {
                btn_point_Click(sender, e);

            }
            else if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                btn_eq_Click(sender, e);
            }
            else if (e.Key == Key.Back)
            {
                btn_back_arr_Click(sender, e);

            }
            else if (e.Key == Key.Delete)
            {
                btn_C_Click(sender, e);

            }
        }
    }
}