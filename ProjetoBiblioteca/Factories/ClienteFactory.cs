using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Factories
{
    class ClienteFactory
    {
        public Cliente CriarCliente(CadastroPessoaTDO cadastro)
        {
            return new Cliente(cadastro);
        }
    }
}
