using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasSock
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string resultRow = "|";

            for (int i = 0; i < n*2; i++)
            {
                resultRow = resultRow + "-";
            }
            resultRow = resultRow + "|";
            Console.WriteLine(resultRow);

            resultRow = "|";
            for (int i = 0; i < n*2; i++)
            {
                resultRow = resultRow + "*";
            }
            resultRow = resultRow + "|";
            Console.WriteLine(resultRow);

            resultRow = "|";
            for (int i = 0; i < n*2; i++)
            {
                resultRow = resultRow + "-";
            }
            resultRow = resultRow + "|";
            Console.WriteLine(resultRow);

            for (int i = 0; i < n-2; i++)
            {
                resultRow = "|";
                for (int j = 0; j < n/2-i+2; j++)
                {
                    resultRow = resultRow + "-";
                }

                for (int j = n/2-i+2; j <i+n+1 ; j++)
                {
                    resultRow = resultRow + "~";
                }
                for (int j = 0; j < n / 2 - i + 2; j++)
                {
                    resultRow = resultRow + "-";
                }
                resultRow = resultRow + "|";
                Console.WriteLine(resultRow);
            }

            resultRow = "|-";

            for (int j = 0; j <n*2 -2; j++)
            {
                resultRow = resultRow + "~";
            }
            resultRow = resultRow + "-|";
            Console.WriteLine(resultRow);

            for (int i = 0; i < n - 2; i++)
            {
                resultRow = "|";
                for (int j = 0; j < n / 2 - i + 2; j++)
                {
                    resultRow = resultRow + "-";
                }


                for (int j = n / 2 - i + 2; j < i + n + 1; j++)
                {
                    resultRow = resultRow + "~";
                }

                for (int j = 0; j < n / 2 - i + 2; j++)
                {
                    resultRow = resultRow + "-";
                }
                resultRow = resultRow + "|";
                Console.WriteLine(resultRow);
            }
        }
    }
}
