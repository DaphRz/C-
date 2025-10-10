using System;
using System.Collections.Generic;

namespace CafeteriaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> pedidos = new List<string>();
            pedidos.Add("C1");
            pedidos.Add("C2");
            pedidos.Add("S1");

            double t = 0;
            foreach (var p in pedidos)
            {
                if (p == "C1")
                    t += 5.0;
                else if (p == "C2")
                    t += 7.0;
                else if (p == "S1")
                    t += 4.0;
                else
                    Console.WriteLine("Item não encontrado!");
            }

            Console.WriteLine("Total: " + t);
        }
    }
}
