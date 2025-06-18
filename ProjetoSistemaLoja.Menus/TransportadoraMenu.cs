using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Data;

namespace ProjetoSistemaLoja.Menus
{
    internal class TransportadoraMenu
    {
        private readonly LojaData LojaData;

        public TransportadoraMenu(LojaData lojaData)
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
                    Console.WriteLine("\n--- MENU TRANSPORTADORA ---");
                    Console.WriteLine("1. Cadastrar Transportadora");
                    Console.WriteLine("2. Remover Transportadora");
                    Console.WriteLine("3. Consultar Transportadora");
                    Console.WriteLine("4. Editar Transportadora");
                    Console.WriteLine("0. Voltar");
                    Console.Write("Opção: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma opção valida!");

                    switch (opcao)
                    {
                        case 0:
                            break;
                        case 1:
                            CadastrarTransportadora();
                            break;
                        case 2:
                            RemoverTransportadora();
                            break;
                        case 3:
                            ConsultarTransportadora();
                            break;
                        case 4:
                            EditarTransportadora();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção válida!");
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }

        private void CadastrarTransportadora()
        {
            string resultado = new TransportadoraService(LojaData).AdicionarTransportadora();
            Console.WriteLine(resultado);
        }

        private void ConsultarTransportadora()
        {
            try
            {
                Console.WriteLine("Consultar por: ");
                Console.WriteLine("1. Id");
                Console.WriteLine("2. Consulta geral");
                string opcaoStr = Console.ReadLine();
                if (!int.TryParse(opcaoStr, out int opcao))
                    throw new Exception("Informe uma opção válida");
                if (opcao <= 0 && opcao >= 3)
                    throw new Exception("Informe uma opção válida!");

                if (opcao == 1)
                {
                    Console.WriteLine("Informe o id: ");
                    int id = int.Parse(Console.ReadLine());

                    var t = new TransportadoraService(LojaData).ObterTransportadoraPorId(id);
                    Console.WriteLine(t);
                }
                else
                {
                    var lista = new TransportadoraService(LojaData).ObterTodasTransportadoras();
                    foreach (var t in lista)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void RemoverTransportadora()
        {
            string resultado = new TransportadoraService(LojaData).RemoverTransportadora();
            Console.WriteLine(resultado);
        }

        private void EditarTransportadora()
        {
            string resultado = new TransportadoraService(LojaData).EditarTransportadora();
            Console.WriteLine(resultado);
        }
    }
}

