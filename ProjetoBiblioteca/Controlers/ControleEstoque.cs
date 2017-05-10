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
    class ControleEstoque 
    {
        const int anoLimiteParaCompra = 2010;
        private static ControleEstoque instance;
        private static List<Produto> estoqueDaBiblioteca = new List<Produto>();

        private ControleEstoque() { }

        public static ControleEstoque Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControleEstoque();
                }
                return instance;
            }
        }

        public static void AdicionarItem(Produto produto)
        {
            estoqueDaBiblioteca.Add(produto);
        }

        public static bool CadastrarProdutoLivro(ProdutoDTO produto)
        {
            var item = new Livro(produto.Titulo, produto.Autor, produto.AnoDePublicacao);
            AdicionarItem(item);
            return ConsultarItemCadatrado(item);
        }

        public static bool CadastrarProdutoDvd(ProdutoDTO produto)
        {
            var item = new Dvd(produto.Titulo, produto.Autor, produto.AnoDePublicacao);
            AdicionarItem(item);
            return ConsultarItemCadatrado(item);
        }

        public static bool CadastrarProdutoRevista(ProdutoDTO produto)
        {
            var item =  new Revista(produto.Titulo, produto.Autor, produto.AnoDePublicacao);
            AdicionarItem(item);
            return ConsultarItemCadatrado(item);
        }

        public static bool ConsultarItemCadatrado(Produto produto)
        {
            if (estoqueDaBiblioteca.Contains(produto))
                return true;

            return false;
        }

        public static void RemoverItem(Produto produto)
        {
            estoqueDaBiblioteca.Remove(produto);
        }

        public static List<Produto> ListarItens()
        {
            return estoqueDaBiblioteca;
        }

        public static Produto LocalizarProdudoPorIndice(int index)
        {
            return estoqueDaBiblioteca[index];
        }

        public static bool VerificarAnoDeLancamento(int ano)
        {
            if (ano >= anoLimiteParaCompra)
                return true;
            
            return false;
        }
    }
}
