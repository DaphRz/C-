using InovaWeek_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovaWeek_WPF.Control
{
    internal class IdeiaControle
    {
        private IdeiaInovadora ModeloPersistencia = new();

        public Boolean ControleCadastrar(string area, string ideia, float custo)   // pegando info da interface gráfica
        {
            ideia = ideia + "!!";  // regra de negócio (concatenação)

            IdeiaInovadora i = new()
            {
                Area = area,
                Ideia = ideia,
                Custo = custo
            };

            if (ModeloPersistencia.CadastrarIdeia(i))
                return true;

            return false;
        }

        /* public List<IdeiaInovadora> ControleRecuperarIdeia()
        {
            return ModeloPersistencia.Recuperar
        } */ // terminar
    }
}
