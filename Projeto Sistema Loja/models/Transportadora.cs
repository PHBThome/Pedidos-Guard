namespace Projeto_Sistema_Loja.models
{
    internal class Transportadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valormk { get; set; }
        public Endereco Endereco { get; set; }

        public Transportadora(int id, string nome, double valorkm, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Valormk = valorkm;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Valorkm: {Valormk} | Endereço: {Endereco}";
        }
    }
}
