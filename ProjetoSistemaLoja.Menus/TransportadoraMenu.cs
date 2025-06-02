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
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU TRANSPORTADORA ---");
                Console.WriteLine("1. Cadastrar Transportadora");
                Console.WriteLine("2. Remover Transportadora");
                Console.WriteLine("3. Consultar Transportadora");
                Console.WriteLine("4. Editar Transportadora");
                Console.WriteLine("0. Voltar");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
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
                }

            } while (opcao != 0);
        }

        private void CadastrarTransportadora()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Valor por km: ");
            double valorkm = double.Parse(Console.ReadLine());
            Endereco endereco = new EnderecoController().CadastrarEndereco();

            Transportadora nova = new(id, nome ?? "", valorkm, endereco);
            string resultado = new TransportadoraController(LojaData).AdicionarTransportadora(nova);
            Console.WriteLine(resultado);
        }

        private void ConsultarTransportadora()
        {
            Console.WriteLine("Consultar por: ");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o id: ");
                int id = int.Parse(Console.ReadLine());

                var t = new TransportadoraController(LojaData).ObterTransportadoraPorId(id);
                Console.WriteLine(t);
            }
            else
            {
                var lista = new TransportadoraController(LojaData).ObterTodasTransportadoras();
                foreach (var t in lista)
                {
                    Console.WriteLine(t);
                }
            }
        }

        private void RemoverTransportadora()
        {
            Console.WriteLine("Id da transportadora a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new TransportadoraController(LojaData).RemoverTransportadora(id);
            Console.WriteLine(resultado);
        }

        private void EditarTransportadora()
        {
            Console.WriteLine("Id da transportadora a editar: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = new TransportadoraController(LojaData).EditarTransportadora(id);
            Console.WriteLine(resultado);
        }
    }
}

