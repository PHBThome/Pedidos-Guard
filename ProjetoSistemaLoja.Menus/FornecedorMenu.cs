using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Data;
using System.Linq.Expressions;

namespace ProjetoSistemaLoja.Menus
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
            int opcao = -1;
            do
            {
                try
                {
                    Console.WriteLine("\n--- MENU FORNECEDOR ---");
                    Console.WriteLine("1. Cadastrar Fornecedor");
                    Console.WriteLine("2. Remover Fornecedores");
                    Console.WriteLine("3. Consultar Fornecedor");
                    Console.WriteLine("4. Editar Fornecedor");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine("Op��o: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out opcao))
                        throw new Exception("Digite um n�mero v�lido!");

                    if (opcao <= -1 || opcao >= 5)
                        throw new Exception("Informe uma op��o v�lida!");

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
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }

        private void CadastrarFornecedor()
        {
            var resultado = new FornecedorController(LojaData).AdicionarFornecedor();
            Console.WriteLine(resultado);
        }

        private void ConsultarFornecedor()
        {
            try
            {
                Console.WriteLine("Consultar por:");
                Console.WriteLine("1. Id");
                Console.WriteLine("2. Consulta geral");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao != 1 && opcao != 0)
                    throw new Exception("Escolha uma op��o v�lida!");

                if (opcao == 1)
                {
                    Console.WriteLine("Informe o id:");
                    int id = int.Parse(Console.ReadLine());
                    bool existe = false;
                    foreach (Fornecedor z in LojaData.Fornecedores)
                    {
                        if (z == null) continue;
                        if (z.Id == id)
                            existe = true;
                    }
                    if (!existe)
                        throw new Exception("Informe um id v�lido!");

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
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void RemoverFornecedor()
        {
            string resultado = new FornecedorController(LojaData).RemoverFornecedor();
            Console.WriteLine(resultado);
        }

        private void EditarFornecedor()
        {
            string resultado = new FornecedorController(LojaData).EditarFornecedor();
            Console.WriteLine(resultado);
        }
    }
}

