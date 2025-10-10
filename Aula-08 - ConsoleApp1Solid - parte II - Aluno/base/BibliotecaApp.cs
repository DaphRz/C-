using System;

namespace BibliotecaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string tipo;
            int diasAtraso = 0;
            double multa = 0;

            Console.WriteLine("Qual o Tipo do Item (Livro ou Revista)?");
            // Recebe a entrada
            // Converte para minúsculas ToLower()
            // Remove espaços em branco antes e depois Trim()
            tipo = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("multa: " + multa);
        }
    }

    public static double CalcularMulta(string tipo, int diasAtraso)
        {
            double multa = 0;

            if (tipo == "livro")
            {
                return multa = diasAtraso * 1.5;
            }
            else if (tipo == "revista")
            {
                return multa = diasAtraso * 1;
            }
            else {
                throw new ArgumentException($"Tipo de Item não Reconhecido: '{tipo}'.")
            }
        }
}