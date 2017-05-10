using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleClientes
    {
        private static List<Cliente> clientesCadastrados = new List<Cliente>();

        public static bool CadastrarCliente(CadastroPessoaTDO cadastro)
        {
            var cliente = CriarUsuarioCliente(cadastro);
            AdicionarCliente(cliente);
            return ConsultarClienteCadatrado(cliente);
        }

        public static Cliente CriarUsuarioCliente(CadastroPessoaTDO cadastro)
        {
            return new Cliente(cadastro.Nome, cadastro.Cpf, cadastro.Email);
        }

        public static void AdicionarCliente(Cliente cliente)
        {
            clientesCadastrados.Add(cliente);
        }

        public static bool ConsultarClienteCadatrado(Cliente cliente)
        {
            if (clientesCadastrados.Contains(cliente))
                return true;

            return false;
        }

        public static void RemoverClienteo(Cliente cliente)
        {
            clientesCadastrados.Remove(cliente);
        }

        public static List<Cliente> ListarClientes()
        {
            return clientesCadastrados;
        }

        public static Cliente LocalizarClientePorIndice(int index)
        {
            return clientesCadastrados[index];
        } 
    }
}
