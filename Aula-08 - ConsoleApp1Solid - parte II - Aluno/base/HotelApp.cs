using System;

namespace HotelApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string tipo = "luxo";
            int dias = 3;
            double preco = 0;

            if (tipo == "simples") preco = dias * 100;
            else if (tipo == "luxo") preco = dias * 300;
            else preco = dias * 50;

            Console.WriteLine("valor: " + preco);
        }
    }
}
