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
                    if (t != null && t.Nome == nome){
                        throw new Exception("Nome já existente!");
                    }
                }

                Console.WriteLine("Valor por km: ");
                string valorkmStr = Console.ReadLine();

                if (!double.TryParse(valorkmStr, out double valorkm)){
                    throw new Exception("Informe um valor por km válido");
                }
                if(valorkm <= 0){
                    throw new Exception("Informe um valor por km maior que 0!");
                }

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
                    throw new Exception("Informe um id válido!");
                }

                IList<Transportadora> transportadoras = Repository.GetAll<Transportadora>();
                var transportadora = transportadoras.FirstOrDefault(t => t != null && t.Id == id);

                if (transportadora == null)
                {
                    throw new Exception("Transportadora não encontrada!");
                }

                Repository.Remove<Transportadora>(id);
                return "Transportadora removida com sucesso!";
            }
            catch (Exception ex)
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
                {
                    throw new Exception("Informe um id válido");
                }

                IList<Transportadora> transportadoras = Repository.GetAll<Transportadora>();
                Transportadora transportadoraEditada = transportadoras.FirstOrDefault(t => t != null && t.Id == id);

                if (transportadoraEditada == null)
                {
                    throw new Exception("Transportadora não encontrada!");
                }

                Console.WriteLine($"Transportadora atual:\n{transportadoraEditada}");

                Console.WriteLine("Deseja alterar o nome? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool nomeValido = false;
                    while (!nomeValido)
                    {
                        Console.WriteLine("Novo nome: ");
                        string nome = Console.ReadLine();

                        bool nomeExistente = transportadoras.Any(z => z != null && z.Nome.ToLower() == nome.ToLower() && z.Id != id);

                        if (nomeExistente)
                        {
                            Console.WriteLine("Nome já existente! Tente novamente.");
                        }
                        else
                        {
                            transportadoraEditada.Nome = nome;
                            nomeValido = true;
                        }
                    }
                }

                Console.WriteLine("Deseja editar o valor por km? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    bool valorkmValido = false;
                    while (!valorkmValido)
                    {
                        Console.WriteLine("Novo valor por km: ");
                        string valorkmStr = Console.ReadLine();
                        if (!double.TryParse(valorkmStr, out double valorkm) || valorkm <= 0)
                        {
                            Console.WriteLine("Informe um valor por km válido!");
                        }
                        else
                        {
                            transportadoraEditada.ValorPorKm = valorkm;
                            valorkmValido = true;
                        }
                    }
                }

                    Console.WriteLine("Deseja editar o endereço? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        transportadoraEditada.Endereco = new EnderecoService().CadastrarEndereco();
                    }

                    Repository.Update<Transportadora>(transportadoraEditada);
                    
                    return "Transportadora editada com sucesso!";
                }
                catch (Exception ex)
                {
                    return "Erro: " + ex.Message;
                }
        }

    }
}

