using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Factories;
using Cappta.ProjetoBiblioteca.DBFake;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleClientes
    {
        public void CriarCliente(CadastroPessoaTDO pessoa)
        {
            Cliente cliente = new ClienteFactory().CriarCliente(pessoa);
            var controleDB = new ClientesDBFake();
            controleDB.Adicionar(cliente);
        }

        public static Cliente LocalizarClientePorIndice(int index)
        {
            return new ClientesDBFake().ListarItens()[index];
        } 
    }
}
