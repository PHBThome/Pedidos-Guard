using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSistemaLoja.Repositories.Interfaces;
using ProjetoSistemaLoja.Models;
using Projeto_Sistema_Loja.controllers;
using ProjetoSistemaLoja.Controllers;

namespace ProjetoSistemaLoja.Menus
{
    internal class PedidosMenu
    {
        private IRepositoryBase<Pedido> Repository;
        private IRepositoryBase<Produto> produtoRepository;
        private IRepositoryBase<Transportadora> transportadoraRepository;
        
        public PedidosMenu(IRepositoryBase<Pedido> repositorio, 
            IRepositoryBase<Produto> ProdutoRepository, IRepositoryBase<Transportadora> TransportadoraRepository)
        {
            Repository = repositorio;
            produtoRepository = ProdutoRepository;
            transportadoraRepository = TransportadoraRepository;
        }

        public void ExibirMenu()
        {

            int opcao = -1;
            do
            {
                try
                {
                    Usuario atual = null;
                    Console.WriteLine("\n--- MENU PEDIDO ---");
                    Console.WriteLine("1. Ver todos os pedidos");
                    Console.WriteLine("2. Alterar Situação");
                    Console.WriteLine("0. Voltar");
                    Console.Write("Opção: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma op��o v�lida!");

                    switch (opcao)
                    {
                        case 0:
                            break;
                        case 1:
                            new PedidoService(Repository, produtoRepository, transportadoraRepository, atual).TodosPedidos();
                            break;
                        case 2:
                            new PedidoService(Repository, produtoRepository, transportadoraRepository, atual).AlterarSituação();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção válida!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }
    }
}
