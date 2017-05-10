using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;
using ProjetoBiblioteca;


namespace Cappta.ProjetoBiblioteca.Produtos
{
    class Livro : Produto
    {
        public Livro(string titulo, string autor, int anoDePublicacao)
        {
            base.Titulo = titulo;
            base.AnoDePublicacao = anoDePublicacao;
            base.Autor = autor;
        }
        
        public DateTime VerificaDataDeDevolucao()
        {
            return DataDeLocacao.AddDays(7);
        } 
    }
}
