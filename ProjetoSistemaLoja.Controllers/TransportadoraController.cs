using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Menus;

namespace ProjetoSistemaLoja.Controllers
{
    public class TransportadoraController
    {
        private readonly LojaData LojaData;

        public TransportadoraController(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarTransportadora(Transportadora novaTransportadora)
        {
            foreach (var t in LojaData.Transportadoras)
            {
                if (t != null)
                {
                    if (t.Id == novaTransportadora.Id)
                        return "ID da transportadora já existe!";
                    if (t.Nome.ToLower() == novaTransportadora.Nome.ToLower())
                        return "Nome já cadastrado!";
                }
            }

            int posicaoLivre = -1;
            for (int i = 0; i < LojaData.Transportadoras.Length; i++)
            {
                if (LojaData.Transportadoras[i] == null)
                {
                    posicaoLivre = i;
                    break;
                }
            }

            if (posicaoLivre == -1)
                return "Número máximo de transportadoras atingido!";

            Transportadora[] novoArray = new Transportadora[LojaData.Transportadoras.Length];
            Array.Copy(LojaData.Transportadoras, novoArray, LojaData.Transportadoras.Length);
            novoArray[posicaoLivre] = novaTransportadora;
            LojaData.Transportadoras = novoArray;

            return "Transportadora cadastrada com sucesso!";
        }

        public string RemoverTransportadora(int id)
        {
            for (int i = 0; i < LojaData.Transportadoras.Length; i++)
            {
                if (LojaData.Transportadoras[i] != null && LojaData.Transportadoras[i].Id == id)
                {
                    LojaData.Transportadoras[i] = null;
                    return "Transportadora removida com sucesso!";
                }
            }
            return "Transportadora não encontrada!";
        }

        public Transportadora ObterTransportadoraPorId(int id)
        {
            foreach (var t in LojaData.Transportadoras)
            {
                if (t != null && t.Id == id)
                    return t;
            }
            return null;
        }

        public Transportadora[] ObterTodasTransportadoras()
        {
            return LojaData.Transportadoras.Where(t => t != null).ToArray();
        }

        public string EditarTransportadora(int id)
        {
            for (int i = 0; i < LojaData.Transportadoras.Length; i++)
            {
                if (LojaData.Transportadoras[i] != null && LojaData.Transportadoras[i].Id == id)
                {
                    var t = LojaData.Transportadoras[i];
                    Console.WriteLine($"Transportadora atual:\n{t}");

                    Console.WriteLine("Deseja alterar o nome? (s/n)");
                    string nome = " ";
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        bool nomeValido = false;

                        while (!nomeValido)
                        {
                            Console.WriteLine("Novo nome: ");
                            nome = Console.ReadLine();

                            bool nomeExistente = false;

                            foreach (var z in LojaData.Transportadoras)
                            {
                                if (z != null && z.Nome.ToLower() == nome.ToLower())
                                {
                                    Console.WriteLine("Nome já existente! Tente novamente.");
                                    nomeExistente = true;
                                    break;
                                }
                            }

                            if (!nomeExistente)
                                nomeValido = true;
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
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        var novo = new EnderecoController().CadastrarEndereco();
                        t.Endereco = novo;
                    }

                    return "Transportadora editada com sucesso!";
                }
            }
            return "Transportadora não encontrada!";
        }
    }
}

