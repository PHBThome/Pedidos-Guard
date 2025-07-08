using System.Linq.Expressions;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Controllers
{
    public class PedidoService
    {
        private IRepositoryBase<Pedido> Repository;
        private IRepositoryBase<Produto> produtoRepository;
        private IRepositoryBase<Transportadora> transportadoraRepository;
        private Usuario? Atual;

        public PedidoService(IRepositoryBase<Pedido> repository, IRepositoryBase<Produto> ProdutoRepository, 
            IRepositoryBase<Transportadora> TransportadoraRepository, Usuario atual)
        {
            Repository = repository;
            produtoRepository = ProdutoRepository;
            transportadoraRepository = TransportadoraRepository;
            Atual = atual;
        }

        public void FazerPedido()
        {
            Pedido novoPedido = new Pedido() { UsuarioId = Atual.Id};
            bool finalizar = false;
            while (!finalizar)
            {
                Console.WriteLine("Deseja:\n" +
                    "1. Adicionar algum produto ao carrinho\n" +
                    "2. Remover algum produto do carrinho\n" +
                    "3. Ver meu carrinho\n" +
                    "4. Finalizar pedido\n" +
                    "0. Sair (seu carrinho sera zerado)");

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
                        MeuCarrinho(novoPedido);
                        break;
                    case 4:
                        FinalizarPedido(novoPedido);
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
                    Console.WriteLine("Informe o id do produto para adicionar ao carrinho: ");
                    int id = int.Parse(Console.ReadLine());
                    foreach (var p in resultados)
                    {
                        if (p.Id == id && p.Quantidade != 0)
                        {

                            PedidoItem novo = new PedidoItem();
                            novo.Nome = p.Nome;
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
                            Console.WriteLine($"{novo.Nome} adicionado ao carrinho.");
                            return;
                        }
                        else if (p.Id == id && p.Quantidade == 0)
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
            IList<Produto> resultados = produtos
                .Where(p => p != null &&
                            ((p.Nome != null && p.Nome.ToLower().Contains(produto)) ||
                             (p.Descricao != null && p.Descricao.ToLower().Contains(produto))))
                .ToList();
            if (resultados == null || resultados.Count == 0)
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

        public void MeuCarrinho(Pedido novo)
        {
            foreach(var p in novo.Itens)
            {
                Console.WriteLine(p);
            }
        }

        public void FinalizarPedido(Pedido novo)
        {
            try 
            {
            novo.DataPedido = DateTime.Now;
            novo.Situacao = "Novo";
            IList<Transportadora> transportadoras = transportadoraRepository.GetAll<Transportadora>();
            Console.WriteLine("Voce tem alguma preferência de transportadora? (s/n)");
            string opcao = Console.ReadLine();
                if (opcao == "s")
                {
                    Console.WriteLine("Informe o nome da transportadora desejada: ");
                    string transportadora = Console.ReadLine();
                    IList<Transportadora> resultado = (from t in transportadoras
                                                       where t.Nome.Contains(transportadora)
                                                       select t).ToList();
                    foreach (var t in resultado)
                    {
                        Console.WriteLine(t);
                    }

                    Console.WriteLine("Informe o id da transportadora: ");
                    string idStr = Console.ReadLine();
                    int id;
                    while (!int.TryParse(idStr, out id))
                    {
                        Console.WriteLine("Informe apenas números");
                        idStr = Console.ReadLine();
                    }

                    Transportadora escolhida = (from t in resultado
                                                where t.Id == id
                                                select t).FirstOrDefault();

                    Console.WriteLine("Informe quantos km serão percorridos (apenas numeros inteiros): ");
                    string kmStr = Console.ReadLine();
                    int km;
                    while (!int.TryParse(kmStr, out km))
                    {
                        Console.WriteLine("Informe apenas números");
                        kmStr = Console.ReadLine();
                    }
                    novo.PrecoFrete = km * escolhida.Valormk;
                }
                else
                {
                    Transportadora escolhida = transportadoras[0];
                    foreach(var t in transportadoras)
                    {
                        if (t.Valormk < escolhida.Valormk)
                            escolhida = t;
                    }

                    Console.WriteLine("Informe quantos km serão percorridos (apenas numeros inteiros): ");
                    string kmStr = Console.ReadLine();
                    int km;
                    while (!int.TryParse(kmStr, out km))
                    {
                        Console.WriteLine("Informe apenas números");
                        kmStr = Console.ReadLine();
                    }
                    novo.PrecoFrete = km * escolhida.Valormk;
                }

                IList<Pedido> pedidos = Repository.GetAll<Pedido>();

                novo.Valor = novo.Itens.Sum(item => item.ValorTotal);
                novo.Id = pedidos.Count + 1;

                AtualizarEstoque(novo);

                Repository.Save(novo);
                Console.WriteLine("Pedido finalizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void MeusPedidos()
        {
            IList<Pedido> pedidos = Repository.GetAll<Pedido>();
            foreach(var p in pedidos)
            {
                if(Atual.Id == p.UsuarioId)
                    Console.WriteLine(p);
            }
        }

        public void TodosPedidos()
        {
            IList<Pedido> pedidos = Repository.GetAll<Pedido>();
            foreach (var p in pedidos)
            {
                Console.WriteLine(p);
            }
        }

        public void AlterarSituação()
        {
            try
            {
                IList<Pedido> pedidos = Repository.GetAll<Pedido>();
                foreach (var p in pedidos)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine("Informe o id do pedido a alterar: ");
                string idStr = Console.ReadLine();
                int id;
                if (!int.TryParse(idStr, out id))
                    throw new Exception("Informe apenas números");
                foreach(var p in pedidos)
                {
                    if(p.Id == id)
                    {
                        Console.WriteLine("Informe a nova situação: ");
                        string situacao = Console.ReadLine();
                        if(situacao == "Entregue")
                            p.DataEntrega = DateTime.Now;
                        p.Situacao = situacao;
                        Console.WriteLine("Situação alterada!");
                        Repository.Update<Pedido>(p);
                        return;
                    }
                }
                throw new Exception("Pedido não encontrado!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void AtualizarEstoque(Pedido novo)
        {
            IList<Produto> produtos = produtoRepository.GetAll<Produto>();
            foreach(var pItem in novo.Itens)
            {
                foreach (var p in produtos)
                {
                    if (pItem.IdProduto == p.Id)
                    {
                        p.Quantidade -= pItem.Quantidade;
                        produtoRepository.Update<Produto>(p);
                    }
                }
            }
        }
    }
}
