using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int n= int.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double ch;
            Double obshoKm = m;
            for (int i = 0; i < n; i++)
            {
                ch = int.Parse(Console.ReadLine());
                ch = m + m * ch / 100;
                obshoKm = obshoKm + ch;
                m = ch;
            }

            if (obshoKm >= 1000) Console.WriteLine("You've done a great job running " + Math.Ceiling(obshoKm-1000) + " more kilometers!");
            else Console.WriteLine("Sorry Mrs. Ivanova, you need to run " + Math.Ceiling(1000-obshoKm) + " more kilometers");
        }
    }
}
