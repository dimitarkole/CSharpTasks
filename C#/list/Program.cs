using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }
            //извеждане на всики елементи
            Console.WriteLine("Всичкки елемнти");
            Console.WriteLine(string.Join("; ", numbers));

            //извеждане на елементи кратни на 7
            Console.WriteLine("Всичкки елемнти кратни на 7");
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] % 7 == 0) Console.WriteLine("{0}; ",numbers[i]);
            }

            //сортиране на елемнтите и извеждане
            Console.WriteLine("Всичкки елемнти сортирани");
            numbers.Sort();
            Console.WriteLine(string.Join("; ", numbers));
            Console.WriteLine(numbers.Max() ); 
        }
    }
}
