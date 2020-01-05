using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivanov_sFamily
{
    class Program
    {
        static void Main(string[] args)
        {
            Double budject = double.Parse(Console.ReadLine());
            Double gift1 = double.Parse(Console.ReadLine());
            Double gift2 = double.Parse(Console.ReadLine());
            Double gift3 = double.Parse(Console.ReadLine());

            double sumGift = gift1 + gift2 + gift3;

            Double ostatak = (budject - sumGift)*0.9;
            Console.WriteLine(String.Format("{0:0.00}", ostatak));

        }
    }
}
