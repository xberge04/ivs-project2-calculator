using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    
    class Program
    {
        //Math_Library.Math Math;

        static void smerodatnaOdchylka(int counter, List<int> input)
        {
            Math_Library.Math math = new Math_Library.Math();
            
            //double smerodatnaOdchylka = 0;
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
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\users\ivs\documents\visual studio 2015\Projects\profiling\profiling\TextFile3.txt");
            List<int> vstup = new List<int>();

            string line;
            while ((line = file.ReadLine()) != null && line != "")
            {
                vstup.Add(int.Parse(line));
                counter++;
            }
            
            file.Close();

            smerodatnaOdchylka(counter, vstup);

            System.Console.ReadLine();

        }
    }
}
