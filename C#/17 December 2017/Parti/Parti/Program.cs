using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parti
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());

            if(people*20> money)
            {
                Console.WriteLine("They won't have enough money to pay the covert. They will need "+ (people*20 - money) + " lv more.");
            }
            else
            {
                int ostatak = money - people * 20;
                Console.WriteLine("Yes! "+ ostatak * 0.4 + " lv are for fireworks and " +ostatak*0.6 + " lv are for donation.") ;
            }
        }
    }
}
