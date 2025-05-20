using Projeto_Sistema_Loja.models;
using Projeto_Sistema_Loja.controllers;

namespace Projeto_Sistema_Loja.menus
{
    internal class TransportadoraMenu
    {
        public static void ExibirMenuTransportadora()
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMenu Transportadora");
                Console.WriteLine("1. Incluir transportadora");
                Console.WriteLine("2. Remover transportadora");
                Console.WriteLine("3. Editar transportadora");
                Console.WriteLine("4. Consultar transportadora");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirTransportadora();
                        break;
                    case 2:
                        RemoverTransportadora();
                        break;
                    case 3:
                        EditarTransportadora();
                        break;
                    case 4:
                        ConsultarTransportadora();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void InserirTransportadora()
        {
            Console.Write("\nNome da transportadora: ");
            string nome = Console.ReadLine();

            Console.Write("Valor por KM: ");
            double valorKm = double.Parse(Console.ReadLine());

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Endereco endereco = EnderecoMenu.CadastrarEndereco();

            Transportadora novaTransportadora = new Transportadora
            {
                Nome = nome,
                ValorKm = valorKm,
                Id = id,
                Endereco = endereco
            };

            Console.WriteLine(TransportadoraController.AdicionarTransportadora(novaTransportadora));
        }

        private static void RemoverTransportadora()
        {
            Console.Write("\nID da transportadora a remover: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(TransportadoraController.RemoverTransportadora(id));
        }

        private static void ConsultarTransportadora()
        {
            Console.WriteLine("\nConsultar por:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Todas");
            Console.Write("Escolha: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("\nID da transportadora: ");
                    int id = int.Parse(Console.ReadLine());
                    Transportadora t = TransportadoraController.ObterTransportadoraPorId(id);

                    if (t != null)
                        ExibirDetalhesTransportadora(t);
                    else
                        Console.WriteLine("Transportadora não encontrada!");
                    break;

                case 2:
                    Transportadora[] todas = TransportadoraController.ObterTodasTransportadoras();
                    foreach (Transportadora transportadora in todas)
                        ExibirDetalhesTransportadora(transportadora);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private static void EditarTransportadora()
        {
            Console.Write("\nID da transportadora a editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo valor por KM: ");
            double valorKm = double.Parse(Console.ReadLine());

            Console.Write("Novo endereço:\n");
            Endereco endereco = EnderecoMenu.CadastrarEndereco();

            Transportadora dadosAtualizados = new Transportadora
            {
                Id = id,
                Nome = nome,
                ValorKm = valorKm,
                Endereco = endereco
            };

            Console.WriteLine(TransportadoraController.EditarTransportadora(id, dadosAtualizados));
        }

        private static void ExibirDetalhesTransportadora(Transportadora transportadora)
        {
            Console.WriteLine("\n--------------------------");
            Console.WriteLine($"ID: {transportadora.Id}");
            Console.WriteLine($"Nome: {transportadora.Nome}");
            Console.WriteLine($"Valor/KM: {transportadora.ValorKm:C}");
            Console.WriteLine($"Endereço: {transportadora.Endereco.Rua}, {transportadora.Endereco.Numero}");
            Console.WriteLine($"Complemento: {transportadora.Endereco.Complemento}");
            Console.WriteLine($"Bairro: {transportadora.Endereco.Bairro}");
            Console.WriteLine($"CEP: {transportadora.Endereco.Cep}");
            Console.WriteLine($"Cidade/Estado: {transportadora.Endereco.Cidade} - {transportadora.Endereco.Estado}");
            Console.WriteLine("--------------------------");
        }
    }
}