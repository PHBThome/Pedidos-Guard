using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class UsuarioController
    {
        public int LoginEfetuado(Usuario testar)
        {
            if (testar.User == "admin" && testar.Password == "1234")
            {
                return 1;
            }
            else
            {
                return 0;
            }
                
        }
    }
}
