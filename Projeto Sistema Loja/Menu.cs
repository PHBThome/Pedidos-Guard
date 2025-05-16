using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Sistema_Loja
{
    internal class Menu
    {
       
        public static void Login()
        {
            Console.WriteLine("Digite o usuario: ");
            string user = Console.ReadLine();

            Console.WriteLine("Digite a senha: ");
            string senha = Console.ReadLine();
            
            if(user == "admin" && senha == "1234")
            {
                MenuAdministrador.ExibirMenuAdministrador();
            }
        }

    }
}
