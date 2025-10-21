using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDados2_AutorLivro
{
    internal class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Autor()
        {
            
        }

        public Autor(string nome)
        {
            Nome = nome;
        }

        public override string? ToString()
        {
            return $"Autor -> Id: {Id} | Nome: {Nome}";
        }
    }
}
