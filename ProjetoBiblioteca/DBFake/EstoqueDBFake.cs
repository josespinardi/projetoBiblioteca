using Cappta.ProjetoBiblioteca.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.DBFake
{
    class EstoqueDBFake : IDBFake
    {
        private static List<Produto> estoqueDaBiblioteca = new List<Produto>();

        public void AdicionarItem(Produto produto)
        {
            estoqueDaBiblioteca.Add(produto);
        }

        public void RemoverItem(Produto produto)
        {
            estoqueDaBiblioteca.Remove(produto);
        }

        public List<Produto> ListarItens()
        {
            return estoqueDaBiblioteca;
        }
    }
}
