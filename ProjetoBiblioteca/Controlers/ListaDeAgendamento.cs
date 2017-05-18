using Cappta.ProjetoBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ListaDeAgendamento : ListaItens
    {
        protected override bool condicaoVerdadeira(Locacao locacao)
        {
            return locacao.DataLocacao > DateTime.Now;
        }
    }
}