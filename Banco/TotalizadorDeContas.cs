using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

namespace Banco
{
    class TotalizadorDeContas
    {
        public double ValorTotal { get; private set; }
        public void Soma(Conta conta)
        {
            ValorTotal += conta.Saldo;        
        }
    }
}
