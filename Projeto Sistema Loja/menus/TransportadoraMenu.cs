using Projeto_Sistema_Loja.controllers;
using Projeto_Sistema_Loja.models;
using System;

namespace Projeto_Sistema_Loja.menus
{
    internal class TransportadoraMenu
    {
        private readonly TransportadoraController transportadoraController;
        private readonly EnderecoMenu enderecoMenu;

        public TransportadoraMenu(TransportadoraController controller, EnderecoMenu enderecoMenu)
        {
            this.transportadoraController = controller;
            this.enderecoMenu = enderecoMenu;
        }

        public void ExibirMenu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- MENU TRANSPORTADORA ---");
                Console.WriteLine("1. Cadastrar Transportadora");
                Console.WriteLine("2. Remover Transportadoras");
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
            Endereco endereco = enderecoMenu.CadastrarEndereco();

            var nova = new Transportadora(id, nome, valorkm, endereco);
            string resultado = transportadoraController.AdicionarTransportadora(nova);
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

                var t = transportadoraController.ObterTransportadoraPorId(id);
                Console.WriteLine(t);
                return;
            }
            else
            {
                var lista = transportadoraController.ObterTodasTransportadoras();
                foreach (var t in lista)
                {
                    Console.WriteLine(t);
                }
                return;
            }
        }

        private void RemoverTransportadora()
        {
            Console.WriteLine("Id da transportadora a remover: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = transportadoraController.RemoverTransportadora(id);
            Console.WriteLine(resultado);
        }

        private void EditarTransportadora()
        {
            Console.WriteLine("Id da transportadora a editar: ");
            int id = int.Parse(Console.ReadLine());
            string resultado = transportadoraController.EditarTransportadora(id);
            Console.WriteLine(resultado);
        }

        
    }
}
