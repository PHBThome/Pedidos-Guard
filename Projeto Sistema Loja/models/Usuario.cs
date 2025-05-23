using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Sistema_Loja.models
{
    internal class Usuario
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Usuario(string user, string password)
        {
            this.User = user;  
            this.Password = password;
        }

    }
}
