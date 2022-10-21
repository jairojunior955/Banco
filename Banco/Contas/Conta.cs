using System;
using Caelum.Banco.Usuarios;

namespace Banco.Contas
{
    public abstract class Conta
    {
        public int Numero { get; set;}
        public double Saldo { get; protected set;}
        public Cliente Titular { get; set; }
        public int Tipo { get; set; }
        private  static int numeroDeContas = 0;

        public abstract void Deposita(double valor);
        public abstract void Saca(double valor);
        public Conta()
        {
            Conta.numeroDeContas++;
            this.Numero = Conta.numeroDeContas;
        }
        public static int ProximaConta()
        {
            return numeroDeContas + 1;
        }
        public override string ToString()
        {
            return "Titular: " + this.Titular.Nome; 
        }
        public override bool Equals(Object outro)
        {
            if (!(outro is Conta))
            {
                return false;
            }
            Conta outraConta = (Conta)outro;    
            return this.Numero == outraConta.Numero;
        }
    }
}