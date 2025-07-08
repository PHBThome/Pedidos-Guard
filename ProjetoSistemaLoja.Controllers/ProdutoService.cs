using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;
using ProjetoSistemaLoja.Services;

namespace Projeto_Sistema_Loja.controllers
{
    public class ProdutoService
    {
        private IRepositoryBase<Produto> Repository;
        private IRepositoryBase<Fornecedor> fornecedorRepository;

        public ProdutoService(IRepositoryBase<Produto> repositorio, IRepositoryBase<Fornecedor> fRepositorio)
        {
            Repository = repositorio;
            fornecedorRepository = fRepositorio;
        }

        public string AdicionarProduto()
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome)){
                    throw new Exception("Informe um nome válido!");
                }

                IList<Produto> produtos = Repository.GetAll<Produto>();

                foreach (var p in produtos)
                {
                    if (p != null && p.Nome == nome){
                        throw new Exception("Nome já existente!");
                    }
                }

                Console.WriteLine("Descrição: ");
                string descricao = Console.ReadLine();

                Console.Write("Valor: ");
                double valor = double.Parse(Console.ReadLine());

                if (valor <= 0){
                    throw new Exception("Informe um valor válido!");
                }

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                if (quantidade < 0){
                    throw new Exception("Informe uma quantidade válida");
                }

                Console.Write("ID do Fornecedor: ");
                int idFornecedor = int.Parse(Console.ReadLine());

                var fornecedor = fornecedorRepository.GetById<Fornecedor>(idFornecedor);
                if (fornecedor == null)
                    throw new Exception("Informe um id de fornecedor existente!");

                List<int> ids = (from p in produtos
                                 select p.Id).ToList();

                int id = Util.NextId(ids);

                Produto novoProduto = new Produto(id, nome, descricao, valor, quantidade, idFornecedor);

                Repository.Save(novoProduto);

                return "Produto adicionado com sucesso!";
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public string RemoverProduto()
        {
            try
            {
                Console.WriteLine("Id do produto a remover: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                {
                    throw new Exception("Informe um id válido!");
                }

                IList<Produto> produtos = Repository.GetAll<Produto>();
                var produto = produtos.FirstOrDefault(p => p != null && p.Id == id);

                if (produto == null)
                {
                    throw new Exception("Produto não encontrado!");
                }

                Repository.Remove<Produto>(id);
                return "Produto removido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Produto? ObterProdutoPorId(int id)
        {
            return Repository.GetById<Produto>(id);
        }

        public IList<Produto> ObterTodosProdutos()
        {
            return Repository.GetAll<Produto>();
        }

        public string EditarProduto()
        {
            try
            {
                Console.WriteLine("Id do produto a editar: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                    throw new Exception("Informe um id válido!");

                IList<Produto> produtos = Repository.GetAll<Produto>();
                Produto produtoEditado = produtos.FirstOrDefault(p => p != null && p.Id == id);

                if (produtoEditado == null)
                    throw new Exception("Produto não encontrado!");

                Console.WriteLine($"Produto atual:\n{produtoEditado}");

                Console.WriteLine("Deseja alterar o nome? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool nomeValido = false;
                    while (!nomeValido)
                    {
                        Console.WriteLine("Novo nome: ");
                        string nome = Console.ReadLine();

                        bool nomeExistente = produtos.Any(p => p != null && p.Nome.ToLower() == nome.ToLower() && p.Id != id);

                        if (nomeExistente)
                        {
                            Console.WriteLine("Nome já existente! Tente novamente.");
                        }
                        else
                        {
                            produtoEditado.Nome = nome;
                            nomeValido = true;
                        }
                    }
                }

                Console.WriteLine("Deseja alterar a descrição? (s/n)");
                if(Console.ReadLine().ToLower() == "s")
                {
                    Console.WriteLine("Nova descrição: ");
                    string descricao = Console.ReadLine();
                }

                Console.WriteLine("Deseja editar o valor? (s/n)");
                double valor = 0;
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool valorValido = false;

                    while (!valorValido)
                    {
                        Console.WriteLine("Novo valor: ");
                        string valorStr = Console.ReadLine();
                        if (!double.TryParse(valorStr, out valor))
                            Console.WriteLine("Informe um valor válido");
                        else
                            produtoEditado.Valor = valor;
                            valorValido = true;
                    }
                }

                Console.WriteLine("Deseja editar a quantidade? (s/n)");
                int quantidade = 0;
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool quantidadeValida = false;

                    while (!quantidadeValida)
                    {
                        Console.WriteLine("Nova quantidade: ");
                        string quantidadeStr = Console.ReadLine();
                        if(!int.TryParse(quantidadeStr,out quantidade))
                            Console.WriteLine("Informe um quantidade válida!");
                        else
                            produtoEditado.Quantidade = quantidade;
                            quantidadeValida = true;
                    }
                }

                Console.WriteLine("Deseja editar o id do fornecedor? (s/n)");
                int idfornecedor = 0;
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool idValido = false;

                    while (!idValido)
                    {
                        Console.WriteLine("Novo id do fornecedor: ");
                        string idfornecedorStr = Console.ReadLine();
                        while (!idValido)
                        {
                            if (!int.TryParse(idfornecedorStr, out idfornecedor))
                                Console.WriteLine("Informe um id de fornecedor válido!");
                            else
                                idValido = true;
                        }
                        var fornecedor = fornecedorRepository.GetById<Fornecedor>(idfornecedor);

                        if (fornecedor == null)
                        {
                            Console.WriteLine("Fornecedor não encontrado! Tente novamente.");
                            idValido = false;
                        }
                        else
                        {
                            produtoEditado.IdFornecedor = idfornecedor;
                            idValido = true;
                        }
                    }
                }
                Repository.Update<Produto>(produtoEditado);
                return "Produto editado com sucesso";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}