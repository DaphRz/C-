using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Contato
    {

        private string Nome;
        private string Num;
        private int Qtdeve;
        private string Apelido;

        public Contato(string n, string a, string num, int deve)
        {
            Nome = n;
            Apelido = a;
            Num = num;
            Qtdeve = deve;
        }

        public string getApelido()
        {
            return Apelido;
        }
    }
}