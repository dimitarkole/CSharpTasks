using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int noshuvkiBr = int.Parse(Console.ReadLine());
            String destination = Console.ReadLine();
            String transport = Console.ReadLine();
            Double transportRazhodi = 0;
            Double spaneRazhosi = 0;
            
            if (transport == "train") transportRazhodi = 82.1;
            else if (transport == "bus") transportRazhodi = 201;
            else transportRazhodi = 385.5;

            if(destination== "Miami")
            {
                if (noshuvkiBr <= 10) spaneRazhosi= 94.95;
                else if((noshuvkiBr>10) && (noshuvkiBr<16)) spaneRazhosi = 81.95;
                else spaneRazhosi = 70;

            }
            else if(destination == "Philippines")
            {
                if (noshuvkiBr <= 10) spaneRazhosi = 205.95;
                else if ((noshuvkiBr > 10) && (noshuvkiBr < 16)) spaneRazhosi =190;
                else spaneRazhosi = 174.2;
            }
            else
            {
                if (noshuvkiBr <= 10) spaneRazhosi = 100.5;
                else if ((noshuvkiBr > 10) && (noshuvkiBr < 16)) spaneRazhosi = 137.8;
                else spaneRazhosi = 122;
            }

            spaneRazhosi = spaneRazhosi * 1.25;
            Double obsho = spaneRazhosi * noshuvkiBr + transportRazhodi;
            Console.WriteLine(String.Format("{0:0.000}",obsho));
        }
    }
}
