namespace Projeto_Sistema_Loja
{
    internal class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public static Endereco CadastrarEndereco()
        {
            Endereco novo = new Endereco();

            Console.WriteLine("\nInforme o nome da rua: ");
            novo.Rua = Console.ReadLine();

            Console.WriteLine("\nInforme o número: ");
            novo.Numero = Console.ReadLine();

            Console.WriteLine("\nInforme o complemento: ");
            novo.Complemento = Console.ReadLine();

            Console.WriteLine("\nInforme o bairro: ");
            novo.Bairro = Console.ReadLine();

            Console.WriteLine("\nInforme o CEP: ");
            novo.Cep = Console.ReadLine();

            Console.WriteLine("\nInforme a cidade: ");
            novo.Cidade = Console.ReadLine();

            Console.WriteLine("\nInforme o estado: ");
            novo.Estado = Console.ReadLine();

            return novo;
        }
    }
}
