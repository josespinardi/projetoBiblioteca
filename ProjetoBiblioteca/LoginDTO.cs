using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca
{
    class LoginDTO
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public LoginDTO(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;
        }
    }
}
