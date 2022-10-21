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
    public partial class FormCadastroConta : Form
    {
        private Form1 formPrincipal;
        public FormCadastroConta(Form1 formPrincipal)
        {
            HashSet<string> devedores = new HashSet<string>();
            devedores.Add("victor");
            devedores.Add("osni");
            string titular = textoTitular.Text;
            bool ehDevedor = devedores.Contains(titular);
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            ContaCorrente novaConta = new ContaCorrente();
            novaConta.Titular = new Cliente(textoTitular.Text);
            this.formPrincipal.AdicionaConta(novaConta);

            textoTitular.Text = "";
            textoNumero.Text = "";
            MessageBox.Show("Conta criada com sucesso");
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximaConta());
        }
    }
}
