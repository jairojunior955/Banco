namespace Caelum.Banco.Usuarios
{
    public class Cliente
    {
        public string Nome { get; set; }
        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        /*public bool PodeAbrirContaSozinho
        {
            get
            {
                var maiorDeIdade = this.idade >= 18;
                //var emancipado = this.documentos.contains("emancipacao");
                var possuiCPF = !string.IsNullOrEmpty(this.cpf);
                //return (maiorDeIdade || emancipado) && possuiCPF;
            }
        }*/

        public int idade { get; private set; }
        public object documentos { get; private set; }
        public string cpf { get; private set; }
    }
}