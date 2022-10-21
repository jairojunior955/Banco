using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

namespace Banco
{
    public class ContaInvestimento : Conta, ITributavel
    {
        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override void Saca(double valor)
        {
            this.Saldo -= valor;
        }
        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }
}
