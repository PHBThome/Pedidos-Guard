using ProjetoSistemaLoja.Models;

namespace ProjetoSistemaLoja.Data
{
    public class LojaData
    {
        public Produto[] Produtos { get; set; }
        public Fornecedor[] Fornecedores { get; set; }
        public Transportadora[] Transportadoras { get; set; }

        public LojaData()
        {
            Produtos = new Produto[200];
            Fornecedores = new Fornecedor[100];
            Transportadoras = new Transportadora[100];
        }
    }
}
