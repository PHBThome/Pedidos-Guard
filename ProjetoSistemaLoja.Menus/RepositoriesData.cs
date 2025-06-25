using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.ArrayRepositories;
using ProjetoSistemaLoja.Repositories.ListRepositories;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Menus
{
    public class RepositoriesData
    {
        public RepositoryBase<Produto> produtoRepository   { get; set; }
        public RepositoryBase<Fornecedor> fornecedorRepository  { get; set; }
        public RepositoryBase<Transportadora> transportadoraRepository { get; set; }

        public RepositoriesData(int isArray)
        {
            if (isArray == 1)
            {
                produtoRepository = new ProdutoRepositoryArray();
                fornecedorRepository = new FornecedorRepositoryArray();
                transportadoraRepository = new TransportadoraRepositoryArray();
            }
            else
            {
                produtoRepository = new ProdutoRepositoryList();
                fornecedorRepository = new FornecedorRepositoryList();
                transportadoraRepository = new TransportadoraRepositoryList();
            }
        }
    }
}
