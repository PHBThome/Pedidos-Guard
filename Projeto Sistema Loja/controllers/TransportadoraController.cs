using Projeto_Sistema_Loja.menus;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class TransportadoraController
    {
        private Transportadora[] transportadoras = new Transportadora[100];
        private int transportadoraCount = 0;
        private readonly EnderecoMenu endereco = new EnderecoMenu();

        public string AdicionarTransportadora(Transportadora novaTransportadora)
        {
            if (transportadoraCount >= transportadoras.Length)
                return "Número máximo de transportadoras atingido!";

            foreach (Transportadora t in transportadoras)
            {
                if (t == null) continue;
                if (t.Id == novaTransportadora.Id)
                    return "Id já existente!";
                if (t.Nome.ToLower() == novaTransportadora.Nome.ToLower())
                    return "Nome já cadastrado!";
            }

            transportadoras[transportadoraCount++] = novaTransportadora;
            return "Transportadora cadastrada com sucesso!";
        }

        public string RemoverTransportadora(int id)
        {
            for (int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id)
                {
                    for (int j = i; j < transportadoraCount - 1; j++)
                        transportadoras[j] = transportadoras[j + 1];

                    transportadoras[--transportadoraCount] = null;
                    return "Transportadora removida com sucesso!";
                }
            }
            return "Transportadora não encontrada!";
        }

        public Transportadora ObterTransportadoraPorId(int id)
        {
            foreach (Transportadora t in transportadoras)
            {
                if (t != null && t.Id == id)
                    return t;
            }
            return null;
        }

        public Transportadora[] ObterTodasTransportadoras()
        {
            Transportadora[] lista = new Transportadora[transportadoraCount];
            Array.Copy(transportadoras, lista, transportadoraCount);
            return lista;
        }

        
        public string EditarTransportadora(int id)
        {
            for(int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id)
                {
                    var t = transportadoras[i];
                    Console.WriteLine($"Transportadora atual:\n{t}");

                    Console.WriteLine($"Deseja alterar o nome? (s/n)");
                    string nome = " ";
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        bool nomeValido = false;

                        while (!nomeValido)
                        {
                            Console.WriteLine("Novo nome: ");
                            nome = Console.ReadLine();

                            bool nomeExistente = false;

                            foreach (Transportadora z in transportadoras)
                            {
                                if (z == null) continue;
                                if (z.Nome.ToLower() == nome.ToLower())
                                {
                                    Console.WriteLine("Nome já existente! Tente novamente.");
                                    nomeExistente = true;
                                    break;
                                }
                            }

                            if (!nomeExistente)
                            {
                                nomeValido = true;
                            }
                        }
                        t.Nome = nome;
                    }

                    Console.WriteLine("Deseja editar o valor por km? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Novo valor por km: ");
                        t.Valormk = double.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Deseja editar o endereço? (s/n)");
                    if(Console.ReadLine().ToLower() == "s")
                    {
                        var novo = endereco.CadastrarEndereco();
                        t.Endereco = novo;
                    }
                    return "Transportadora editada com sucesso";
                }
                
            }
            return "Transportadora não encontrada";
        }
    }
}
