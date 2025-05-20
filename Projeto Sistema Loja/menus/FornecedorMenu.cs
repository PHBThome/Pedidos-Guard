using Projeto_Sistema_Loja.models;
using Projeto_Sistema_Loja.controllers;

namespace Projeto_Sistema_Loja.menus
{
    internal class FornecedorMenu
    {
        public static void ExibirMenuFornecedor()
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMenu Fornecedor");
                Console.WriteLine("1. Incluir fornecedor");
                Console.WriteLine("2. Remover fornecedor");
                Console.WriteLine("3. Editar fornecedor");
                Console.WriteLine("4. Consultar fornecedores");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirFornecedor();
                        break;
                    case 2:
                        RemoverFornecedor();
                        break;
                    case 3:
                        // EditarFornecedor();
                        break;
                    case 4:
                        ConsultarFornecedores();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void InserirFornecedor()
        {
            Console.Write("\nInforme o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("\nInforme o telefone do fornecedor: ");
            string telefone = Console.ReadLine();

            Console.Write("\nInforme o email: ");
            string email = Console.ReadLine();

            Console.Write("\nInforme o id: ");
            int id = int.Parse(Console.ReadLine());

            Endereco endereco = EnderecoMenu.CadastrarEndereco();

            Fornecedor novoFornecedor = new Fornecedor
            {
                Nome = nome,
                Telefone = telefone,
                Email = email,
                Id = id,
                Endereco = endereco
            };

            string resultado = FornecedorController.AdicionarFornecedor(novoFornecedor);
            Console.WriteLine(resultado);
        }

        private static void RemoverFornecedor()
        {
            Console.Write("\nDigite o código do fornecedor a ser excluído: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = FornecedorController.RemoverFornecedor(id);
            Console.WriteLine(resultado);
        }

        private static void ConsultarFornecedores()
        {
            Console.WriteLine("\nConsultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            Console.Write("Escolha: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("\nInforme o id: ");
                    int id = int.Parse(Console.ReadLine());
                    Fornecedor fornecedor = FornecedorController.ObterFornecedorPorId(id);

                    if (fornecedor != null)
                        ExibirDetalhesFornecedor(fornecedor);
                    else
                        Console.WriteLine("Fornecedor não encontrado!");
                    break;

                case 2:
                    Fornecedor[] todos = FornecedorController.ObterTodosFornecedores();
                    foreach (Fornecedor f in todos)
                        ExibirDetalhesFornecedor(f);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private static void ExibirDetalhesFornecedor(Fornecedor fornecedor)
        {
            Console.WriteLine("\n--------------------------");
            Console.WriteLine($"ID: {fornecedor.Id}");
            Console.WriteLine($"Nome: {fornecedor.Nome}");
            Console.WriteLine($"Telefone: {fornecedor.Telefone}");
            Console.WriteLine($"Email: {fornecedor.Email}");
            Console.WriteLine($"Endereço: {fornecedor.Endereco.Rua}, {fornecedor.Endereco.Numero}");
            Console.WriteLine($"Complemento: {fornecedor.Endereco.Complemento}");
            Console.WriteLine($"Bairro: {fornecedor.Endereco.Bairro}, CEP: {fornecedor.Endereco.Cep}");
            Console.WriteLine($"Cidade/Estado: {fornecedor.Endereco.Cidade} - {fornecedor.Endereco.Estado}");
            Console.WriteLine("--------------------------");
        }
    }
}