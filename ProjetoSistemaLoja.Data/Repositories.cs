public class Repositories
{
    public Repositories(int isArray){
        if(isArray == 1){
            UsuarioRepositoryArray usuarioRepository = new UsuarioRepositoryArray();
            ProdutoRepositoryArray produtoRepository = new ProdutoRepositoryArray();
            FornecedorRepositoryArray fornecedorRepository = new FornecedorRepositoryArray();
            TransportadoraRepositoryArray transportadoraRepository = new TransportadoraRepositoryArray();
        }
        else{
            UsuarioRepositoryList usuarioRepository = new UsuarioRepositoryList();
            ProdutoRepositoryList produtoRepository = new ProdutoRepositoryList();
            FornecedorRepositoryList fornecedorRepository = new FornecedorRepositoryList();
            TransportadoraRepositoryList transportadoraRepository = new TransportadoraRepositoryList();
        }
    }
