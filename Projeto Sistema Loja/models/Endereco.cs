namespace Projeto_Sistema_Loja.models
{
    internal class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public Endereco(string rua, int numero, string complemento, string bairro, string cidade, string estado, string cep)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public override string ToString()
        {
            return $"Rua: {Rua}, {Numero} - {Complemento}\nBairro: {Bairro}\n{Cidade} - {Estado}\nCEP: {Cep}";
        }
    }
}
