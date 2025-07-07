using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Controllers
{
    public class PedidoService
    {
        private IRepositoryBase<Pedido> Repository;
        private IRepositoryBase<Usuario> usuarioRepository;
        private IRepositoryBase<Produto> produtoRepository;
        private Usuario Atual;

        public PedidoService(IRepositoryBase<Pedido> repository, IRepositoryBase<Usuario> UsuarioRepository, IRepositoryBase<Produto> ProdutoRepository, Usuario atual)
        {
            Repository = repository;
            usuarioRepository = UsuarioRepository;
            produtoRepository = ProdutoRepository;
            Atual = atual;
        }

        public void FazerPedido()
        {
            Pedido novoPedido = new Pedido() { UsuarioId = Atual.Id};
            bool finalizar = false;
            while (!finalizar)
            {
                Console.WriteLine("Deseja:\n" +
                    "1. Adicionar algum produto ao carrinho\n " +
                    "2. Remover algum produto do carrinho" +
                    "3. Finalizar pedido\n" +
                    "0. Sair");

                string opcaoStr = Console.ReadLine();
                int opcao = 0;
                while (!int.TryParse(opcaoStr, out opcao))
                {
                    Console.WriteLine("Digite apenas numeros!");
                    opcaoStr = Console.ReadLine();
                }

                switch (opcao)
                {
                    case 1:
                        IList<Produto> resultados = ExibirResultados();
                        if (resultados == null)
                            break;
                        AdicionarAoCarrinho(resultados, novoPedido);
                        break;
                    case 2:
                        RemoverProdutoCarrinho(novoPedido);
                        break;
                    case 3:
                        Repository.Save(novoPedido);
                        return;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }
        }

        public void AdicionarAoCarrinho(IList<Produto> resultados, Pedido novoPedido)
        {
            Console.WriteLine("1. Adicionar algum produto ao carrinho\n" +
                "2. Voltar");
            string opcaoStr = Console.ReadLine();
            int opcao = 0;
            while (!int.TryParse(opcaoStr, out opcao))
            {
                Console.WriteLine("Informe apenas numeros!");
                opcaoStr = Console.ReadLine();
            }
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o nome do produto para adicionar ao carrinho: ");
                    string produto = Console.ReadLine().ToLower();
                    foreach (var p in resultados)
                    {
                        if (p.Nome.ToLower() == produto && p.Quantidade != 0)
                        {

                            PedidoItem novo = new PedidoItem();
                            novo.IdProduto = p.Id;
                            bool avançar = false;
                            while (!avançar)
                            {
                                Console.WriteLine("Informe a quantidade: ");
                                string quantStr = Console.ReadLine();
                                int quant = 0;
                                while (!int.TryParse(quantStr, out quant))
                                {
                                    Console.WriteLine("Informe apenas números!");
                                    quantStr = Console.ReadLine();
                                }

                                if (quant > p.Quantidade)
                                {
                                    bool continuar = false;
                                    while (!continuar)
                                    {
                                        Console.WriteLine($"Quantidade em estoque insuficiente! Deseja adicionar apenas {p.Quantidade} ao carrinho? (s/n)");
                                        string escolha = Console.ReadLine();

                                        if (escolha.ToLower() == "s")
                                        {
                                            novo.Quantidade = p.Quantidade;
                                            continuar = true;
                                            avançar = true;
                                        }
                                        else if (escolha.ToLower() == "n")
                                            return;
                                        else
                                            Console.WriteLine("Opção Inválida");
                                    }
                                }
                                else if (quant > 0)
                                {
                                    novo.Quantidade = quant;
                                    avançar = true;
                                }
                                else
                                {
                                    Console.WriteLine("Informe uma quantidade maior que 0!");
                                }
                            }
                            novo.ValorTotal = novo.Quantidade * p.Valor;
                            novoPedido.Itens.Add(novo);
                            return;
                        }
                        else if (p.Nome.ToLower() == produto && p.Quantidade == 0)
                        {
                            Console.WriteLine("Produto Indisponível");
                            return;
                        }
                    }
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine("Opcao Invalida!");
                    break;
            }
        }

        public void RemoverProdutoCarrinho(Pedido novoPedido)
        {
            if (novoPedido.Itens == null || novoPedido.Itens.Count == 0)
            {
                Console.WriteLine("O carrinho está vazio.");
                return;
            }

            foreach (var p in novoPedido.Itens)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Informe o ID do produto que deseja remover: ");
            string idStr = Console.ReadLine();
            int id = 0;
            while (!int.TryParse(idStr, out id))
            {
                Console.WriteLine("Informe um ID válido!");
                idStr = Console.ReadLine();
            }

            var item = novoPedido.Itens.FirstOrDefault(i => i.IdProduto == id);

            if (item == null)
            {
                Console.WriteLine("Produto não encontrado no carrinho.");
                return;
            }

            novoPedido.Itens.Remove(item);
            Console.WriteLine("Produto removido do carrinho com sucesso.");
        }

        public IList<Produto> ExibirResultados()
        {
            Console.WriteLine("Produto: ");
            string produto = Console.ReadLine().ToLower();
            IList<Produto> produtos = produtoRepository.GetAll<Produto>();
            IList<Produto> resultados = (from p in produtos
                                         where p != null &&
                                         (p.Nome.ToLower().Contains(produto) ||
                                         p.Descricao.ToLower().Contains(produto))
                                         select p).ToList();
            if(resultados == null || resultados.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado!");
                return null;
            }


            foreach (var p in resultados)
            {
                if (p.Quantidade == 0)
                    Console.WriteLine($"Indisponivel: {p}");
                else
                    Console.WriteLine(p + "\n");
            }

            return resultados;
        }
    }
}
