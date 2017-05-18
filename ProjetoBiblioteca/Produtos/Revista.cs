using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Produtos
{
    class Revista : Produto
    {
        public Revista(ProdutoDTO produto) : base(produto) { }

        public override Produto CriarProduto(ProdutoDTO produto)
        {
            return new Revista(produto);
        }
    }
}
