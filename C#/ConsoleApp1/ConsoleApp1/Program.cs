using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var seson = Console.ReadLine();
            var team = Console.ReadLine();
            var countPeople = double.Parse(Console.ReadLine());
            var countNigth  = double.Parse(Console.ReadLine());
           

            double price = 0;
            string doing = "";
            if(seson== "Winter")
            {
                if (team == "mixed")
                {
                    price = 10 * countPeople;
                    doing = "Ski";
                }
                else
                {
                    price = 9.6 * countPeople;
                    if (team == "boys") doing = "Judo";
                    else doing = "Gymnastics";
                }
            }
            else if(seson== "Spring")
            {
                if (team == "mixed")
                {
                    price = 9.5 * countPeople;
                    doing = "Cycling";
                }
                else
                {
                    price = 7.2 * countPeople;
                    if (team == "boys") doing = "Tennis";
                    else doing = "Athletics";
                }
            }
            else
            {
                if (team == "mixed")
                {
                    price = 20 * countPeople;
                    doing = "Swimming";
                }
                else
                {
                    price = 15 * countPeople;
                    if (team == "boys") doing = "Football";
                    else doing = "Volleyball";
                }

            }
            price = price * countNigth;
            if (countPeople >= 50) price = price * 0.5;
            else if (countPeople >= 20) price = price * 0.85;
            else if (countPeople >= 10) price = price * 0.95;

            Console.WriteLine(doing+" "+ string.Format("{0:0.00}", price)+" lv.");
        }

        
    }
}
