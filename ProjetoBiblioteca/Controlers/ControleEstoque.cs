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

        //colocar logica de acesso no dbfake

        public static Produto LocalizarProdudoPorIndice(int index)
        {
            return estoqueDaBiblioteca[index];
        }

        //ISSO PRECISA ESTAR AQUI?
        public static bool VerificarAnoDeLancamento(int ano)
        {
            if (ano >= anoLimiteParaCompra)
                return true;
            
            return false;
        }
    }
}
