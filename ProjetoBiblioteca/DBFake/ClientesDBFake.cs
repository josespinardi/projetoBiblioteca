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

        public void Adicionar(Cliente cliente)
        {
            clientesCadastrados.Add(cliente);
        }

        public void Remover(Cliente cliente)
        {
            clientesCadastrados.Remove(cliente);
        }

        public List<Cliente> ListarItens()
        {
            return clientesCadastrados;
        }
    }
}
