using Cappta.ProjetoBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ListaDeAtraso : ListaItens
    {
        protected override bool condicaoVerdadeira(Locacao locacao)
        {
            return locacao.DataDevolucao < DateTime.Now;
        }
    }
}
