using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;

namespace Cappta.ProjetoBiblioteca.Produtos
{
    abstract class Produto
    {
        public string Titulo { get; protected set; }
        public int AnoDePublicacao { get; protected set; }
        public string Autor { get; protected set; }
        public Cliente Locador { get; set; }
        public DateTime DataDeLocacao { get; set; }
        public Cliente AgendadoPara { get; set; }
        public DateTime DataDeAgendamento { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}
