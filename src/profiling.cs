using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Program for profiling
    /// </summary>
    class Program
    {
        
        /// <summary>
        /// Function for calculating standard deviation
        /// </summary>
        /// <param name="counter">number of input values</param>
        /// <param name="input">list to store inputvalues</param>
        static void smerodatnaOdchylka(int counter, List<int> input)
        {
            Math_Library.Math math = new Math_Library.Math();

            double soucet = 0;
            double prumer = 0;
            double temp = 0;
            double definitive = 0;

            for (int i = 0; i < counter; i++)
            {
                soucet += input[i];
                prumer = math.Div(soucet, counter);
            }
            soucet = 0;

            for (int i = 0; i < counter; i++)
            {
                soucet = math.Pow((input[i] - prumer), 2);
                temp = math.Div(soucet, counter);
                definitive += temp;
            }
            Console.Write(math.Root(definitive, 2));
            
        }

        static void Main(string[] args)
        {

            int counter = 0;
            
            List<int> vstup = new List<int>();

            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                vstup.Add(int.Parse(line));
                counter++;
            }

            smerodatnaOdchylka(counter, vstup);

            System.Console.ReadLine();

        }
    }
}
