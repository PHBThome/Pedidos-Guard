using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.data;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.menus
{
    internal class FornecedorMenu
    {

        private readonly LojaData LojaData;

        public FornecedorMenu(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public void ExibirMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU FORNECEDOR ---");
                Console.WriteLine("1. Cadastrar Fornecedor");
                Console.WriteLine("2. Remover Fornecedores");
                Console.WriteLine("3. Consultar Fornecedor");
                Console.WriteLine("4. Editar Fornecedor");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFornecedor();
                        break;
                    case 2:
                        RemoverFornecedor();
                        break;
                    case 3:
                        ConsultarFornecedor();
                        break;
                    case 4:
                        EditarFornecedor();
                        break;
                }

            } while (opcao != 0);
        }

        private void CadastrarFornecedor()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            string telefone = Console.ReadLine();
            Endereco endereco = new EnderecoMenu().CadastrarEndereco();

            Fornecedor novoFornecedor = new (id, nome, email, telefone, endereco);
            string resultado = new FornecedorController(LojaData).AdicionarFornecedor(novoFornecedor);
            Console.WriteLine(resultado);
        }

        private void ConsultarFornecedor()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o id:");
                int id = int.Parse(Console.ReadLine());
                var f = new FornecedorController(LojaData).ObterFornecedorPorId(id);
                Console.WriteLine(f);
            }
            else
            {
                var fornecedores = new FornecedorController(LojaData).ObterTodosFornecedores();
                foreach (var f in fornecedores)
                {
                    Console.WriteLine(f);
                }
            }
        }

        private void RemoverFornecedor()
        {
            Console.Write("Id do fornecedor a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new FornecedorController(LojaData).RemoverFornecedor(id);
            Console.WriteLine(resultado);
        }

        private void EditarFornecedor()
        {
            Console.WriteLine("Id do fornecedor a editar: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new FornecedorController(LojaData).EditarFornecedor(id);
            Console.WriteLine(resultado);
        }
    }
}
