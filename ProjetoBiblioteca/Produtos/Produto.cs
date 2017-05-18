using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Produtos
{
    abstract class Produto
    {
        const int prazoMaximoDeDevolucao = 7;
        public string Titulo { get; protected set; }
        public int AnoDePublicacao { get; protected set; }
        public string Autor { get; protected set; }

        public Produto(ProdutoDTO produto)
        {
            this.Titulo = produto.Titulo;
            this.AnoDePublicacao = produto.AnoDePublicacao;
            this.Autor = produto.Autor;
        }

        public override string ToString()
        {
            return this.Titulo;
        }

        public abstract Produto CriarProduto(ProdutoDTO produto);
    }
}
