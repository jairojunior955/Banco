using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Contas;

namespace Banco
{
    class ContaPoupanca : Conta, ITributavel
    {
        public override void Saca(double valor)
        {
            if (valor < 0.0)
            {
                throw new ArgumentException();
            }
            if (valor + 0.10 >= this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                this.Saldo -= valor + 0.10;
            }
        }
        public override void Deposita(double valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.Saldo += valor;
            }
            
        }
        public void CalculaRendimento()
        {

        }
        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
        
    }
}
