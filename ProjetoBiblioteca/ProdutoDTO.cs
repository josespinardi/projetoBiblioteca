using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca
{
    class ProdutoDTO
    {
        public string Titulo { get; protected set; }
        public int AnoDePublicacao { get; protected set; }
        public string Autor { get; protected set; }

        public ProdutoDTO(string titulo, int anoDePublicacao, string autor)
        {
            this.Titulo = titulo;
            this.AnoDePublicacao = anoDePublicacao;
            this.Autor = autor;
        }
    }
}
