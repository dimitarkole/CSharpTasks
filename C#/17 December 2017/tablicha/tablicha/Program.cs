using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tablicha
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            int edinichi = ch % 10;
            ch = ch / 10;
            int desetichi = ch % 10;
            ch = ch / 10;
            int stotichi = ch;
            for (int i = 1; i <= edinichi; i++)
            {
                for (int j = 1; j <= desetichi; j++)
                {
                    for (int p= 1; p <= stotichi; p++)
                    {
                        Console.WriteLine(i + " * " + j + " * " + p + " = " + i * j * p+";");
                    }
                }
            }
        }
    }
}
