using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Controlers;

namespace Cappta.ProjetoBiblioteca.Produtos
{
    class Revista : Produto
    {
        public Revista(string titulo, string autor, int anoDePublicacao)
        {
            base.Titulo = titulo;
            base.AnoDePublicacao = anoDePublicacao;
            base.Autor = autor;
        }
    }
}
