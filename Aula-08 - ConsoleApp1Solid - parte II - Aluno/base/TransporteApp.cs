using System;

namespace TransporteApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string v = "uber";
            double d = 12.5;
            double t = 0;

            if (v == "uber")
                t = d * 2.5;
            else if (v == "99")
                t = d * 2.0;
            else if (v == "taxi")
                t = d * 3.0;

            Console.WriteLine("preco: " + t);
        }
    }
}
