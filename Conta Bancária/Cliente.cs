using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancária
{
    internal class Cliente(string nome, string cpf, string endereco)
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
    }
}
