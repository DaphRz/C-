using InovaWeek_WPF.BancoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovaWeek_WPF.Model
{
    internal class IdeiaInovadora
    {
        public string Area { get; set; }
        public string Ideia { get; set; } = string.Empty;
        public float Custo { get; set; }

        public Boolean CadastrarIdeia(IdeiaInovadora i)
        {
            BD.SalvarBD(i);

            return true;
        }

        public override string ToString()
        {
            return $"Área: {Area}, Ideia: {Ideia}, Custo: {Custo:C}";
        }

        //public IdeiaInovadora RecuperarIdeiaInovadoraBD
    }
}