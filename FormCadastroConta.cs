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
using Banco.Busca;

namespace Banco
{
    public partial class FormCadastroConta : Form
    {
        private ICollection<string> devedores;
        private Form1 formPrincipal;
        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            

            GeradorDeDevedores gerador = new GeradorDeDevedores();
            this.devedores = gerador.GeraLista();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            string titular = textoTitular.Text;
            bool ehDevedor = false;

            for(int i = 0; i < 30000; i++)
            {
                ehDevedor = this.devedores.Contains(titular);
            }
            if (!ehDevedor)
            {
                ContaCorrente novaConta = new ContaCorrente();
                novaConta.Titular = new Cliente(textoTitular.Text);
                this.formPrincipal.AdicionaConta(novaConta);
                textoTitular.Text = "";
                textoNumero.Text = "";
                MessageBox.Show("Conta criada com sucesso");
            }
            else
            {
                MessageBox.Show("devedor");
            }
            
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximaConta());
        }
    }
}
