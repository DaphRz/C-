using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Bancária
{
    internal class Conta(double limite)
    {
        public double Limite { get; set; }
         
        private bool VerificarTransacao(double valor) => Saldo > valor;    /*private bool VerificarTransacao(double valor)
                                                                           {
                                                                                if (Saldo > valor)
                                                                                {
                                                                                    return true;
                                                                                }
                                                                                return false;
                                                                            }*/

                                                                            /*private bool VerificarTransacao(double valor)
                                                                            {
                                                                                return Saldo > valor;
                                                                            }*/


    }
} 
