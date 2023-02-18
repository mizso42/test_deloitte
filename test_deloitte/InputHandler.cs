using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_deloitte
{
    internal class InputHandler
    {
        private const int MIN_INTEGER = 10;
        private const int MAX_INTEGER = 9999;
        private const int MIN_TEXT_LENGTH = 5;
        private const int MAX_TEXT_LENGTH = 45;


        public static void fill(NumOrText[] list)
        {
            Console.WriteLine("Please provide " + list.Length + " input!");

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("Please provide the " + ordinal(i+1) + " element");
                list[i] = getElement();
            }
        }

        private static NumOrText getElement()
        {
            bool error = false, numerical = false;
            NumOrText element = new NumOrText("");

            char c;

            do
            {
                Console.WriteLine("Is it numerical? (y/n)");
                try {
                    c = Convert.ToChar(Console.ReadLine());
                    if (c == 'y' || c == 'Y')
                    {
                        error = false;
                        numerical = true;
                    }
                    else if (c == 'n' || c == 'N')
                    {
                        error = numerical = false;
                    }
                    else
                    {
                        error = true;
                    }
                }
                catch
                {
                    error = true;
                }

                if (error)
                {
                    Console.WriteLine("Please provide a valid input!");
                }
            } while (error);

            do
            {
                if (numerical)
                {
                    try
                    {
                        Console.WriteLine("Please provide an integer between " + MIN_INTEGER + " and " + MAX_INTEGER + " (inclusive):");
                        element = new NumOrText(Convert.ToInt32(Console.ReadLine()));
                        error = element.getNum() < MIN_INTEGER || element.getNum() > MAX_INTEGER; 
                    }
                    catch
                    {
                        error = true;
                    }
                }
                else
                {
                    try
                    {
                        Console.WriteLine("Please provide a string between " + MIN_TEXT_LENGTH + " and " + MAX_TEXT_LENGTH + " characters (inclusive):");
                        string str = Console.ReadLine();
                        if (str != null && str.Length >= MIN_TEXT_LENGTH && str.Length <= MAX_TEXT_LENGTH)
                        {
                            element = new NumOrText(str);
                            error = false;
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    catch
                    {
                        error = true;
                    }
                }

                if (error)
                {
                    Console.WriteLine("Please provide a valid input!");
                }
            } while (error);

            return element;
        }

        private static string ordinal(int cardinal)
        {
            string ord = "" + cardinal;
            ord += cardinal > 3 ? "th" : (cardinal == 1 ? "st" : (cardinal == 2 ? "nd" : "rd"));
            return ord;
        }
    }
}
