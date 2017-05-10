using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca
{
    class CadastroPessoaTDO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public CadastroPessoaTDO(string nome, string cpf, string email, string senha)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
        }
    }
}
