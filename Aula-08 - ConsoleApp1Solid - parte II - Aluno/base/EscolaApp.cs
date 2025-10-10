using System;

namespace EscolaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string aluno = "Maria";
            double n1 = 7.5;
            double n2 = 8.0;
            double n3 = 6.0;

            double m = (n1 + n2 + n3) / 3;
            if (m >= 7)
                Console.WriteLine("aprovado");
            else
                Console.WriteLine("reprovado");
        }
    }
}
