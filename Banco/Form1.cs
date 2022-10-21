using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caelum.Banco.Usuarios;
using Banco.Contas;

namespace Banco
{
    public partial class Form1 : Form
    {
        private List<Conta> contas;
        private Dictionary<string, Conta> dicionario;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dicionario = new Dictionary<string, Conta>();

            this.contas = new List<Conta>();

            ContaCorrente c1 = new ContaCorrente();
            c1.Titular = new Cliente("Victor");
            c1.Numero = 1;
            this.AdicionaConta(c1);

            Conta c2 = new ContaPoupanca();
            c2.Titular = new Cliente("Maurício");
            c2.Numero = 2;
            this.AdicionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("Osni");
            c3.Numero = 3;
            this.AdicionaConta(c3);
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            
            Conta selecionada = (Conta) comboContas.SelectedItem;
            double valor = Convert.ToDouble(textoValor.Text);
            try
            {
                selecionada.Deposita(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                MessageBox.Show("Dinheiro Depositado");
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("Argumento Inválido");
            }
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {

            Conta selecionada = (Conta)comboContas.SelectedItem;
            double valor = Convert.ToDouble(textoValor.Text);
            try
            {
                selecionada.Saca(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                MessageBox.Show("Dinheiro liberado");
                
            }
            catch(SaldoInsuficienteException ex)
            {
                MessageBox.Show("Saldo Insuficiente");
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show("Não é possível sacar um valor negativo");
            }
        }



        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoNumero.Text = Convert.ToString(selecionada.Numero);
        }

        private void comboDestinoTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];
        }

        private void botaoTransferir_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            int indiceTransferencia = comboDestinoTransferencia.SelectedIndex;
            Conta selecionadaTransferencia = this.contas[indiceTransferencia];
            Conta selecionada = this.contas[indice];
            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Saca(valor);
            selecionadaTransferencia.Deposita(valor);
            MessageBox.Show("Sucesso");
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoValor.Text = "";
        }

        public void AdicionaConta(Conta conta)
        {
            this.contas.Add(conta);
            comboContas.Items.Add(conta);
            this.dicionario.Add(conta.Titular.Nome,conta);
            comboDestinoTransferencia.Items.Add(conta);
            comboContas.DisplayMember = conta.Titular.ToString();
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200);
            SeguroDeVida sv = new SeguroDeVida();
            TotalizadorDeTributos totalizador = new TotalizadorDeTributos();
            totalizador.Adiciona(sv);
            MessageBox.Show("Total: " + totalizador.Total);
            totalizador.Adiciona(conta);
            MessageBox.Show("Total: " + totalizador.Total);           
            
        }

        private void botaoBusca_Click(object sender, EventArgs e)
        {
            string nomeTitular = textoBuscaTitular.Text;
            Conta conta = dicionario[nomeTitular];

            textoTitular.Text = conta.Titular.Nome;
            textoNumero.Text = Convert.ToString(conta.Numero);
            textoSaldo.Text = Convert.ToString(conta.Saldo);
        }
    }
}
