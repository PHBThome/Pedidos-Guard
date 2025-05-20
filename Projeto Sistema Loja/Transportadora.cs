namespace Projeto_Sistema_Loja
{
    internal class Transportadora : Endereco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valorkm { get; set; }
        public int Id { get; set; }
        public Endereco Endereco { get; set; }

        public static Transportadora[] transportadoras = new Transportadora[100];
        public static int transportadoraCount = 0;

        public static void ExibirMenuTransportadora()
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMenu Transportadora");
                Console.WriteLine("1. Incluir transportadora");
                Console.WriteLine("2. Remover transportadora");
                Console.WriteLine("3. Editar transportadora");
                Console.WriteLine("4. Consultar transportadora");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirTransportadora();
                        break;
                    case 2:
                        RemoverTransportadora();
                        break;
                    case 3:
                        // EditarTransportadora();
                        break;
                    case 4:
                        ConsultarTransportadora();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public static void InserirTransportadora()
        {
            if (transportadoraCount >= transportadoras.Length)
            {
                Console.WriteLine("\nNúmero máximo de transportadoras atingido!");
                return;
            }

            Console.WriteLine("\nInforme o nome da transportadora: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nInforme o valor por km: ");
            double valorkm = double.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o id: ");
            int id = int.Parse(Console.ReadLine());

            Endereco novo = Endereco.CadastrarEndereco(); // método da classe base

            for (int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id || transportadoras[i].Nome == nome)
                {
                    if (transportadoras[i].Id == id)
                    {
                        Console.WriteLine("Código já existente!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nome já existente!");
                        return;
                    }
                }
            }

            transportadoras[transportadoraCount++] = new Transportadora
            {
                Nome = nome,
                Valorkm = valorkm,
                Id = id,
                Endereco = novo
            };

            Console.WriteLine("Transportadora incluída com sucesso!");
        }

        public static void RemoverTransportadora()
        {
            Console.Write("Digite o id da transportadora a ser excluída: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id)
                {
                    for (int j = i; j < transportadoraCount - 1; j++)
                    {
                        transportadoras[j] = transportadoras[j + 1];
                    }

                    transportadoras[--transportadoraCount] = null;
                    Console.WriteLine("Transportadora excluída com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Transportadora não encontrada!");
        }

        public static void ConsultarTransportadora()
        {
            Console.WriteLine("Consultar por:");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Consulta geral");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o id");
                    int id = int.Parse(Console.ReadLine());

                    for (int i = 0; i <= transportadoraCount; i++)
                    {
                        if (transportadoras[i].Id == id)
                        {
                            Console.WriteLine($"\nID: {transportadoras[i].Id}");
                            Console.WriteLine($"Nome: {transportadoras[i].Nome}");
                            Console.WriteLine($"Valor KM: {transportadoras[i].Valorkm}");
                            Console.WriteLine($"Rua: {transportadoras[i].Rua}, Nº: {transportadoras[i].Numero}");
                            Console.WriteLine($"Compl: {transportadoras[i].Complemento}");
                            Console.WriteLine($"Bairro: {transportadoras[i].Bairro}, CEP: {transportadoras[i].Cep}");
                            Console.WriteLine($"Cidade: {transportadoras[i].Cidade} - {transportadoras[i].Estado}");
                            return;
                        }
                    }
                    Console.WriteLine("Transportadora não encontrada!");
                    break;

                case 2:
                    for (int i = 0; i <= transportadoraCount; i++)
                    {
                        Console.WriteLine($"\nID: {transportadoras[i].Id}");
                        Console.WriteLine($"Nome: {transportadoras[i].Nome}");
                        Console.WriteLine($"Valor KM: {transportadoras[i].Valorkm}");
                        Console.WriteLine($"Rua: {transportadoras[i].Rua}, Nº: {transportadoras[i].Numero}");
                        Console.WriteLine($"Compl: {transportadoras[i].Complemento}");
                        Console.WriteLine($"Bairro: {transportadoras[i].Bairro}, CEP: {transportadoras[i].Cep}");
                        Console.WriteLine($"Cidade: {transportadoras[i].Cidade} - {transportadoras[i].Estado}");
                    }
                    break;

                default:
                    Console.WriteLine("Opção invalida!");
                    break;
            }
        }
    }
}
