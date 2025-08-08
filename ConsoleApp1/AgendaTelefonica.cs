using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AgendaTelefonica
    {
        Dictionary<string, Contato> Agenda = new Dictionary<string, Contato>();
        //private Dictionary<string, Contato> Agenda = [];

        public int MyProperty { get; set; }

        public void Inserir(string nome, Contato c)
        {
            Agenda.Add(nome, c);
        }

        public Contato Buscar(string nome)
        {
            return Agenda[nome];
        }

        //public Contato Buscar(string nome) => Agenda[nome];


        public int Quantidade()
        {
            return Agenda.Count;
        }

        //public int Quantidade() => Agenda.Count;

    }
}
