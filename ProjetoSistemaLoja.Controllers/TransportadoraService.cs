using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Menus;

namespace ProjetoSistemaLoja.Controllers
{
    public class TransportadoraService
    {
        private readonly LojaData LojaData;

        public TransportadoraService(LojaData lojaData)
        {
            LojaData = lojaData;
        }

        public string AdicionarTransportadora()
        {
            try
            {
                int transportadoraCount = LojaData.Transportadoras.Count(f => f != null);

                if (transportadoraCount >= LojaData.Transportadoras.Length)
                    return "\nNúmero máximo de transportadoras atingido!";


                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Informe um nome válido!");

                foreach (var t in LojaData.Transportadoras)
                {
                    if (t != null && t.Nome == nome) 
                        throw new Exception("Nome já existente!");
                }

                Console.WriteLine("Valor por km: ");
                string valorkmStr = Console.ReadLine();
                if (!double.TryParse(valorkmStr, out double valorkm))
                    throw new Exception("Informe um valor por km válido");
                if(valorkm <= 0)
                    throw new Exception("Informe um valor por km maior que 0!");

                Endereco endereco = new EnderecoService().CadastrarEndereco();
                
                int id = transportadoraCount + 1;

                Transportadora novaTransportadora = new(id, nome, valorkm, endereco);


                int posicaoLivre = -1;
                for (int i = 0; i < LojaData.Transportadoras.Length; i++)
                {
                    if (LojaData.Transportadoras[i] == null)
                    {
                        posicaoLivre = i;
                        break;
                    }
                }

                Transportadora[] novoArray = new Transportadora[LojaData.Transportadoras.Length];
                Array.Copy(LojaData.Transportadoras, novoArray, LojaData.Transportadoras.Length);
                novoArray[posicaoLivre] = novaTransportadora;
                LojaData.Transportadoras = novoArray;

                return "Transportadora cadastrada com sucesso!";
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public string RemoverTransportadora()
        {
            try
            {
                Console.WriteLine("Id da transportadora a remover: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                    throw new Exception("Informe um id válido!");

                bool existe = false;
                foreach (Transportadora t in LojaData.Transportadoras)
                {
                    if (t == null) continue;
                    if (t.Id == id) existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id existente");

                for (int i = 0; i < LojaData.Produtos.Length; i++)
                {
                    if (LojaData.Produtos[i] != null && LojaData.Produtos[i].Id == id)
                    {
                        LojaData.Produtos[i] = null;
                        return "Transportadora removida com sucesso!";
                    }
                }
                return "Transportadora não encontrada!";
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
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

        public string EditarTransportadora()
        {
            try
            {
                Console.WriteLine("Id da transportadora a editar: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                    throw new Exception("Informe um id válido");

                bool existe = false;
                foreach (Transportadora t in LojaData.Transportadoras)
                {
                    if (t == null) continue;
                    if (t.Id == id) existe = true;
                }
                if (!existe)
                    throw new Exception("Informe um id existente");

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
                        double valorkm = 0;
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            bool valorkmValido = false;
                            while (!valorkmValido)
                            {
                                Console.WriteLine("Novo valor por km: ");
                                string valorkmStr = Console.ReadLine();
                                if (!double.TryParse(valorkmStr, out valorkm))
                                    Console.WriteLine("Informe um valor por km válido!");
                                else if(valorkm <= 0)
                                    Console.WriteLine("Informe um valor por km válido!");
                                else
                                    valorkmValido = true;
                            }
                        }

                        Console.WriteLine("Deseja editar o endereço? (s/n)");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            var novo = new EnderecoService().CadastrarEndereco();
                            t.Endereco = novo;
                        }

                        return "Transportadora editada com sucesso!";
                    }
                }
                return "Transportadora não encontrada!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}

