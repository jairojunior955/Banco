using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

namespace Banco
{
    class ContaCorrente : Conta, ITributavel
    {

        public override void Deposita(double valor)
        {
           this.Saldo += valor - 0.10;
        }
        public override void Saca(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException();
            }
            if(valor >= this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                this.Saldo -= valor - 0.05;
            }
        }
        public double CalculaTributo()
        {
            return this.Saldo * 0.05;
        }

        
    }
}
