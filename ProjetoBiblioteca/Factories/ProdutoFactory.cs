using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Produtos;
using ProjetoBiblioteca.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Factories
{
    class ProdutoFactory
    {
        public Produto CriarProduto(ProdutoEnum tipo, ProdutoDTO produto)
        {
            switch (tipo)
            {
                case ProdutoEnum.Dvd:
                    return new Dvd(produto);
                case ProdutoEnum.Livro:
                    return new Livro(produto);
                case ProdutoEnum.Revista:
                    return new Revista(produto);
                default:
                    return null;
            }
        }
    }
}
