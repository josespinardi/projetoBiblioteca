using Cappta.ProjetoBiblioteca.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.DBFake
{
    class ClientesDBFake : IDBFake
    {
        private static List<Cliente> clientesCadastrados = new List<Cliente>();

        public void AdicionarItem(Cliente cliente)
        {
            clientesCadastrados.Add(cliente);
        }

        public void RemoverItem(Cliente cliente)
        {
            clientesCadastrados.Remove(cliente);
        }

        List<Cliente> ListarItens()
        {
            return clientesCadastrados;
        }
    }
}
