using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSistemaLoja.Controllers;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Menus
{
    internal class UsuarioMenu
    {
        private IRepositoryBase<Usuario> Repository;

        public UsuarioMenu(IRepositoryBase<Usuario> repositorio)
        {
            Repository = repositorio;
        }

        public void ExibirMenu()
        {
            int opcao = -1;
            do
            {
                try
                {
                    Console.WriteLine("\n--- MENU Usuario ---");
                    Console.WriteLine("1. Cadastrar Usuario");
                    Console.WriteLine("2. Remover Usuario");
                    Console.WriteLine("3. Consultar Usuario");
                    Console.WriteLine("4. Editar Usuario");
                    Console.WriteLine("0. Voltar");
                    Console.Write("Op��o: ");
                    string opcaoStr = Console.ReadLine();
                    if (!int.TryParse(opcaoStr, out opcao))
                        throw new Exception("Informe uma opção valida!");

                    switch (opcao)
                    {
                        case 0:
                            break;
                        case 1:
                            CadastrarUsuario();
                            break;
                        case 2:
                            RemoverUsuario();
                            break;
                        case 3:
                            ConsultarUsuario();
                            break;
                        case 4:
                            EditarTransportadora();
                            break;
                        default:
                            Console.WriteLine("Informe uma opção v�lida!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            } while (opcao != 0);
        }

        private void CadastrarUsuario()
        {
            string resultado = new UsuarioService(Repository).AdicionarUsuario();
            Console.WriteLine(resultado);
        }

        private void ConsultarUsuario()
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

                    var u = new UsuarioService(Repository).ObterUsuarioPorId(id);
                    Console.WriteLine(u);
                }
                else
                {
                    var lista = new UsuarioService(Repository).ObterTodosUsuarios();
                    foreach (var u in lista)
                    {
                        Console.WriteLine(u);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void RemoverUsuario()
        {
            string resultado = new UsuarioService(Repository).RemoverUsuario();
            Console.WriteLine(resultado);
        }

        private void EditarTransportadora()
        {
            string resultado = new UsuarioService(Repository).EditarUsuario();
            Console.WriteLine(resultado);
        }
    }
}
