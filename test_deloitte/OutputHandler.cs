using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

namespace test_deloitte
{
    internal class OutputHandler
    {
        private const string ADDENDUM = "Making an impact that matters –Deloitte";
        
        public static void output(NumOrText[] list)
        {
            for (int i = 0; i < list.Length; i++)
                transform(list[i]);
        }

        private static void transform(NumOrText element)
        {
            if (element.isNumerical())
            {
                Console.Write(element.getNum().ToString() + " - ");
                Console.Write(element.getNum() % 2 == 0 ? element.getNum() / 2 : element.getNum()*2);
                if (isPrime(element.getNum()))
                    Console.Write(" !prime number");
            }
            else
            {
                Console.Write(element.getText() + " - ");
                for (int i = 0; i < (element.getText().Length < ADDENDUM.Length ? element.getText().Length : ADDENDUM.Length); i++)
                {
                    Console.Write(ADDENDUM.ElementAt(i));
                }
            }
            Console.Write('\n');
        }

        public static bool isPrime(int num)
        {
            if (num < 2)
                return false;

            int i = 2;
            while (i*i <= num && num % i != 0)
            {
                i++;
            }
            return i * i > num;
        }
    }
}
