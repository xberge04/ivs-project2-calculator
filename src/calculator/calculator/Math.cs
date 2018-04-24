using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Math_Library
{
    
    /// <summary>
    /// Matematická knihovna vytvořená pro aplikaci Kalkulačka.
    /// </summary>
    public class Math
    {
        public Math()
        {

        }

        /// <summary>
        /// Funkce sčítání.
        /// </summary>
        /// <param name="num1">První přidané číslo.</param>
        /// <param name="num2">Druhé přidané číslo.</param>
        /// <returns>Součet dvou parametrů funkce.</returns>
        public double Add(double num1, double num2)
        {
            double result = num1 + num2;
            return result;
        }

        /// <summary>
        /// Funkce odčítání.
        /// </summary>
        /// <param name="num1">Číslo, z kterého se odčítá.</param>
        /// <param name="num2">Odčítané číslo.</param>
        /// <returns>Rozdíl dvou parametrů funkce.</returns>
        public double Sub(double num1, double num2)
        {
            double result = num1 - num2;
            return result;
        }

        /// <summary>
        /// Funkce násobení.
        /// </summary>
        /// <param name="num1">Násobenec.</param>
        /// <param name="num2">Násobitel</param>
        /// <returns>Výsledek násobení dvou parametrů funkce.</returns>
        public double Mul(double num1, double num2)
        {
            double result = num1 * num2;
            return result;
        }

        /// <summary>
        /// Funkce dělení.
        /// </summary>
        /// <param name="num1">Dělenec.</param>
        /// <param name="num2">Dělitel.</param>
        /// <returns>Výsledek dělení dvou parametrů funkce.</returns>
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
        /// Funkce přirozené mocniny.
        /// </summary>
        /// <param name="num1">Základ mocniny.</param>
        /// <param name="num2">Exponent mocniny.</param>
        /// <returns>Výsledek umocnění dvou parametrů funkce.</returns>
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
        /// <summary>
        /// Funkce mocniny, potřebná pro odmocňování.
        /// </summary>
        /// <param name="num1">Základ mocniny.</param>
        /// <param name="num2">Exponent mocniny.</param>
        /// <returns>Výsledek umocnění dvou parametrů funkce.</returns>
        public double PowForRoot(double num1, double num2)
        {
            double result = System.Math.Pow(num1, num2);
            return result;           
        }

        /// <summary>
        /// Funkce obecné odmocniny.
        /// </summary>
        /// <param name="num1">Základ odmocniny.</param>
        /// <param name="num2">Stupeň odmocniny.</param>
        /// <returns>Výsledek odmocnění.</returns>
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
        /// Funkce faktoriálu.
        /// </summary>
        /// <param name="num1">Přírozené číslo k použití faktoriálu.</param>
        /// <returns>Výsledek faktoriálu.</returns>
        public ulong Fact(double num1)
        {
            ulong result = (ulong)num1;
            if (num1 > 65)
            {
                throw new ArgumentOutOfRangeException();
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
        /// Funkce logaritmu
        /// </summary>
        /// <param name="num1">Funkční hodnota logaritmu.</param>
        /// <param name="num2">Základ logaritmu.</param>
        /// <returns>Výsldek logaritmu.</returns>
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