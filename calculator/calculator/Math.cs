using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Math_Library
{
    
    /// <summary>
    /// Mathematics library for creating our calculator application.
    /// </summary>
    public class Math
    {
        public Math()
        {

        }

        /// <summary>
        /// Function of addition.
        /// </summary>
        /// <param name="num1">First added number.</param>
        /// <param name="num2">Second added number.</param>
        /// <returns>Sum of these numbers.</returns>
        public double Add(double num1, double num2)
        {
            double result = num1 + num2;
            return result;
        }

        /// <summary>
        /// Function of subtraction.
        /// </summary>
        /// <param name="num1">Minuend.</param>
        /// <param name="num2">Subtrahend.</param>
        /// <returns>Difference.</returns>
        public double Sub(double num1, double num2)
        {
            double result = num1 - num2;
            return result;
        }

        /// <summary>
        /// Function of multiplying.
        /// </summary>
        /// <param name="num1">Multiplicand.</param>
        /// <param name="num2">Multiplier.</param>
        /// <returns>Result of multiply.</returns>
        public double Mul(double num1, double num2)
        {
            double result = num1 * num2;
            return result;
        }

        /// <summary>
        /// Function of dividing.
        /// </summary>
        /// <param name="num1">Dividend.</param>
        /// <param name="num2">Divisor.</param>
        /// <returns>Result of devide.</returns>
        public double Div(double num1, double num2)
        {
            if(num2==0)
            {
                throw new DivideByZeroException();
            }
            double result = num1 / num2;
            return result;
        }

        /// <summary>
        /// Function of exponentiation.
        /// </summary>
        /// <param name="num1">Base.</param>
        /// <param name="num2">Exponent.</param>
        /// <returns>Result of exponentiation.</returns>
        public double Pow(double num1, double num2)
        {
            if (num2 >= 0 && num2 % 1 == 0)
            {
                double result = System.Math.Pow(num1, num2);
                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public double PowForRoot(double num1, double num2)
        {
            double result = System.Math.Pow(num1, num2);
            return result;           
        }

        /// <summary>
        /// Function of root.
        /// </summary>
        /// <param name="num1">Base.</param>
        /// <param name="num2">Exponent of root.</param>
        /// <returns>Result of root.</returns>
        public double Root(double num1, double num2)
        {
            double result = 0;
            if(num2 == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (num2 % 2 == 0)
            {
                if (num1 >= 0)
                {
                    result = this.PowForRoot(num1, 1.0 / num2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else if(num2 % 2 != 0)
            {
                result = this.PowForRoot(num1, 1.0 / num2);
            }
            
            return result;
        }

        /// <summary>
        /// Factorial function.
        /// </summary>
        /// <param name="num1">Positive natural number of factorial.</param>
        /// <returns>Result of factorial.</returns>
        public ulong Fact(double num1)
        {
            ulong result = (ulong)num1;
            if (num1 > 65)
            {
                throw new ArgumentOutOfRangeException();
                return result;
            }
            else if (num1 > 0 && num1 % 1 == 0)
            {
                for (ulong i = ((ulong)num1 - 1); i >= 1; i--)
                {
                    result = result * i;
                }
            }
            else if (num1 == 0)
            {
                result = 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }            
            return result;
        }

        /// <summary>
        /// Logarithm function.
        /// </summary>
        /// <param name="num1">Base.</param>
        /// <param name="num2">Number of logarithm</param>
        /// <returns>Result of logarithm.</returns>
        public double Log(double num1, double num2)
        {
            if(num1 > 0 && num1 != 1)
            {
                if (num2 > 0)
                {
                    double result = System.Math.Log(num2, num1);
                    return result;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}