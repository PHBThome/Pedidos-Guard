namespace Projeto_Sistema_Loja
{
    internal class Fornecedor : Endereco
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public Endereco endereço { get; set; }


        public static Fornecedor[] fornecedores = new Fornecedor[100];
        public static int fornecedorCount = 0;

        public static void ExibirMenuFornecedor()
        {
            int opcao = -1;
            
            while(opcao != 0)
            {
                Console.WriteLine("\nMenu Fornecedor");
                Console.WriteLine("1. Incluir fornecedor");
                Console.WriteLine("2. Remover fornecedor");
                Console.WriteLine("3. Editar fornecedor");
                Console.WriteLine("4. Consultar fornecedores");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirFornecedor();
                        break;
                    case 2:
                        RemoverFornecedor();
                        break;
                    case 3:
                        // EditarFornecedor();
                        break;
                    case 4:
                        ConsultarFornecedores();
                        break;
                    default:
                        return;
                }

            }
        }

        public static void InserirFornecedor()
        {
            if(fornecedorCount >= fornecedores.Length)
            {
                Console.WriteLine("\nNumero máximo de fornecedores atingido!");
                return;
            }

            Console.WriteLine("\nInforme o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nInforme o telefone do fornecedor: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("\nInforme o email: ");
            string email = Console.ReadLine();

            Console.WriteLine("\nInforme o id");
            int id = int.Parse(Console.ReadLine());

            Endereco novo = Endereco.CadastrarEndereço();

            for(int i = 0; i < fornecedorCount; i++)
            {
                Fornecedor fornecedor = fornecedores[i];
                if (fornecedor.Id == id || fornecedor.Nome == nome)
                {
                    if (fornecedor.Id == id)
                    {
                        Console.WriteLine("Codigo ja existente!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nome ja existente!");
                        return;
                    }
                }
            }

            fornecedores[fornecedorCount++] = new Fornecedor 
            { 
                Nome = nome, 
                Telefone = telefone,
                Email = email,
                Id = id,
                endereço = novo
            };
            Console.WriteLine("Fornecedor incluído com sucesso!");
        }

        public static void RemoverFornecedor()
        {
            Console.Write("Digite o código do fornecedor a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < fornecedorCount; i++)
            {
                if (fornecedores[i].Id == id)
                {
                    for (int j = i; j < fornecedorCount - 1; j++)
                    {
                        fornecedores[j] = fornecedores[j + 1];
                    }

                    fornecedores[--fornecedorCount] = null;
                    Console.WriteLine("Fornecedor excluído com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Fornecedor não encontrado!");
        }

        public static void ConsultarFornecedores()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Informe o id:");
                int id = int.Parse(Console.ReadLine());
                for(int i = 0; i < fornecedorCount; i++)
                {
                    Fornecedor fornecedor = fornecedores[i];
                    if (fornecedor.Id == id)
                    {
                        Console.WriteLine($"\nID: {fornecedor.Id}");
                        Console.WriteLine($"Nome: {fornecedor.Nome}");
                        Console.WriteLine($"Telefone: {fornecedor.Telefone}");
                        Console.WriteLine($"Email: {fornecedor.Email}");
                        Console.WriteLine($"Rua: {fornecedor.endereço.Rua}, Nº: {fornecedor.endereço.Numero}");
                        Console.WriteLine($"Compl: {fornecedor.endereço.Complemento}");
                        Console.WriteLine($"Bairro: {fornecedor.endereço.Bairro}, CEP: {fornecedor.endereço.Cep}");
                        Console.WriteLine($"Cidade: {fornecedor.endereço.Cidade} - {fornecedor.endereço.Estado}");
                        return;
                    }
                }
                Console.WriteLine("Fornecedor não encontrado");
                
            }
            else
            {
                for (int i = 0; i < fornecedorCount; i++)
                {
                    Fornecedor fornecedor = fornecedores[i];
                    Console.WriteLine($"\nID: {fornecedor.Id}");
                    Console.WriteLine($"Nome: {fornecedor.Nome}");
                    Console.WriteLine($"Telefone: {fornecedor.Telefone}");
                    Console.WriteLine($"Email: {fornecedor.Email}");
                    Console.WriteLine($"Rua: {fornecedor.endereço.Rua}, Nº: {fornecedor.endereço.Numero}");
                    Console.WriteLine($"Compl: {fornecedor.endereço.Complemento}");
                    Console.WriteLine($"Bairro: {fornecedor.endereço.Bairro}, CEP: {fornecedor.endereço.Cep}");
                    Console.WriteLine($"Cidade: {fornecedor.endereço.Cidade} - {fornecedor.endereço.Estado}");
                }
            }
        }





    }
}
