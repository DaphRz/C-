using System;
using System.Collections.Generic;

namespace LojaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> carrinho = new List<string>();
            carrinho.Add("P1");
            carrinho.Add("P2");

            double total = 0;
            foreach (var item in carrinho)
            {
                if (item == "P1") total += 10.0;
                else if (item == "P2") total += 20.0;
                else total += 0;
            }

            Console.WriteLine("total: " + total);
        }
    }
}
