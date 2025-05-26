using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
{
    internal class EnderecoMenu
    {
        public Endereco CadastrarEndereco()
        {
            Console.Write("Rua: ");
            string rua = Console.ReadLine();
            Console.Write("Número: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Complemento: ");
            string complemento = Console.ReadLine();
            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();
            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Estado: ");
            string estado = Console.ReadLine();
            Console.Write("CEP: ");
            string cep = Console.ReadLine();

            return new Endereco(rua, numero, complemento, bairro, cidade, estado, cep);
        }
    }
}
