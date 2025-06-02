using ProjetoSistemaLoja.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProjetoSistemaLoja.Menus
{
    public class EnderecoController
    {
        public Endereco CadastrarEndereco()
        {
            string[] siglasEstados =   
                {
                    "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES",
                    "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
                    "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
                    "SP", "SE", "TO"
                };

            Console.Write("Rua: ");
            string rua = Console.ReadLine();

            bool numeroCorreto = false;
            int numero = 0;
            while (!numeroCorreto)
            {
                Console.Write("Número: ");
                string input = Console.ReadLine();
                numeroCorreto = int.TryParse(input, out numero);
                if (!numeroCorreto)
                    Console.WriteLine("Informe um número válido!");
            }


            Console.Write("Complemento: ");
            string complemento = Console.ReadLine();

            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();

            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();

            bool estadoValido = false;
            string estado = null;
            while (!estadoValido)
            {
                Console.Write("Estado (apenas sigla): ");
                estado = Console.ReadLine();
                if(!siglasEstados.Contains(estado.ToUpper()))
                    Console.WriteLine("Informe um estado válido");
            }

            bool cepValido = false;
            string cep = null;
            while (!cepValido)
            {
                Console.Write("CEP: ");
                cep = Console.ReadLine();
                if(cep.Length != 8)
                    Console.WriteLine("Informe um cep válido");
            }

            return new Endereco(rua, numero, complemento, bairro, cidade, estado, cep);
        }
    }
}

