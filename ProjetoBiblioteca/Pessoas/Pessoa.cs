using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Controlers;

namespace Cappta.ProjetoBiblioteca.Pessoas
{
    abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; protected set; }

        public override string ToString()
        {
            return this.Nome;
        }

    }
}
