using ProjetoSistemaLoja.Data;
using ProjetoSistemaLoja.Models;
using ProjetoSistemaLoja.Menus;
using ProjetoSistemaLoja.Repositories.Framework;

namespace ProjetoSistemaLoja.Controllers
{
    public class TransportadoraService
    {
        private RepositoryBase<Transportadora> Repository;

        public TransportadoraService(RepositoryBase<Transportadora> repositorio)
        {
            Repository = repositorio;
        }

        public string AdicionarTransportadora()
        {
            try
            {

                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new Exception("Informe um nome válido!");
                }

                IList<Transportadora> transportadoras = Repository.GetAll<Transportadora>();
                
                foreach (var t in transportadoras)
                {
                    if (t != null && t.Nome == nome)
                        throw new Exception("Nome já existente!");
                }

                Console.WriteLine("Valor por km: ");
                string valorkmStr = Console.ReadLine();
                if (!double.TryParse(valorkmStr, out double valorkm))
                    throw new Exception("Informe um valor por km v�lido");
                if(valorkm <= 0)
                    throw new Exception("Informe um valor por km maior que 0!");

                Endereco endereco = new EnderecoService().CadastrarEndereco();
                
                int id = transportadoras.Count + 1;

                Transportadora novaTransportadora = new(id, nome, valorkm, endereco);
                
                Repository.Save(novaTransportadora);

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
                {
                    throw new Exception("Informe um id v�lido!");
                }

                bool existe = false;

                IList<Transportadora> transportadoras = Repository.GetAll<Transportadora>();


                foreach (Transportadora t in transportadoras)
                {
                    if (t == null) continue;
                    if (t.Id == id) existe = true;
                }
                if (!existe)
                {
                    throw new Exception("Informe um id existente");
                }
                
                Repository.Remove<Transportadora>(id);

                return "Transportadora n�o encontrada!";
            }
            catch(Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }

        public Transportadora ObterTransportadoraPorId(int id)
        {
            return Repository.GetById<Transportadora>(id);
        }

        public IList<Transportadora> ObterTodasTransportadoras()
        {
            return Repository.GetAll<Transportadora>();
        }

        public string EditarTransportadora()
        {
            try
            {
                Console.WriteLine("Id da transportadora a editar: ");
                string idStr = Console.ReadLine();
                if (!int.TryParse(idStr, out int id))
                    throw new Exception("Informe um id v�lido");

                bool existe = false;

                IList<Transportadora> transportadoras = Repository.GetAll<Transportadora>();

                foreach (Transportadora t in transportadoras)
                {
                    if (t == null) continue;
                    if (t.Id == id) existe = true;
                }
                if (!existe) {
                    throw new Exception("Informe um id existente");
                }
        
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

                        foreach (var z in transportadoras)
                        {
                            if (z != null && z.Nome.ToLower() == nome.ToLower())
                            {
                                Console.WriteLine("Nome j existente! Tente novamente.");
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
                            Console.WriteLine("Informe um valor por km v�lido!");
                        else if(valorkm <= 0)
                            Console.WriteLine("Informe um valor por km v�lido!");
                        else
                            valorkmValido = true;
                    }
                }

                Console.WriteLine("Deseja editar o endere�o? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    var novo = new EnderecoService().CadastrarEndereco();
                    t.Endereco = novo;
                }

                return "Transportadora editada com sucesso!";                    
                
                return "Transportadora n�o encontrada!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}

