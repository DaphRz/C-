using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contato c = new Contato("Daphne", "Dadá", "123", 0);
            Contato c1 = new Contato("Vinicius", "Prof", "321", 20);

            AgendaTelefonica agenda = new AgendaTelefonica();

            agenda.Inserir("Daphne", c);
            agenda.Inserir("Vinicius", c1);

            Console.WriteLine(agenda.Buscar("Daphne"));
            Console.WriteLine($"Minha Agenda tem {agenda.Quantidade()} contatos");
        }
    }
}
