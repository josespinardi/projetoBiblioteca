using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;
using ProjetoBiblioteca.Enum;
using Cappta.ProjetoBiblioteca.Factories;
using Cappta.ProjetoBiblioteca.DBFake;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleEstoque 
    {
        const int anoLimiteParaCompra = 2010;

        public void CriarItemNoEstoque(ProdutoEnum tipo, ProdutoDTO item)
        {
            if (ItemPodeSerComprado(item))
            {
                Produto produto = new ProdutoFactory().CriarProduto(tipo, item);
                EstoqueDBFake controleDB = new EstoqueDBFake();
                controleDB.AdicionarItem(produto);
            }
            else { throw new Exception(); }
        }

        private bool ItemPodeSerComprado(ProdutoDTO item)
        {
            if (item.AnoDePublicacao >= anoLimiteParaCompra)
                return true;

            return false;
        }




        
    }
}
