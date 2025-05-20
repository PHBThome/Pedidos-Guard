using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
{
    internal class EnderecoMenu
    {

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
