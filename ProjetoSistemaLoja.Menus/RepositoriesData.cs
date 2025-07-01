using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Repositories.ArrayRepositories;
using ProjetoSistemaLoja.Repositories.ListRepositories;
using ProjetoSistemaLoja.Repositories.Framework;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Menus
{
    public class RepositoriesData
    {
        public IRepositoryBase<Produto> produtoRepository   { get; set; }
        public IRepositoryBase<Fornecedor> fornecedorRepository  { get; set; }
        public IRepositoryBase<Transportadora> transportadoraRepository { get; set; }

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
