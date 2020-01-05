using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelenchukovaBorsa
{
    class Program
    {
        static void Main(string[] args)
        {
            var lvZelenchuci = Double.Parse(Console.ReadLine());
            var lvPlodove= Double.Parse(Console.ReadLine());
            var kgZelenchuci = Double.Parse(Console.ReadLine());
            var kgPlodove = Double.Parse(Console.ReadLine());
            var lvPrihod = (lvPlodove * kgPlodove + kgZelenchuci * lvZelenchuci);
            Console.WriteLine(lvPrihod/1.94);
        }
    }
}
