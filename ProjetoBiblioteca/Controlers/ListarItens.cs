using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    abstract class ListaItens
    {
        public List<Locacao> ListarItens(List<Locacao> itensLocados)
        {
            return itensLocados.Where(locacao => condicaoVerdadeira(locacao)).ToList();
        }

        protected abstract bool condicaoVerdadeira(Locacao locacao);
        public abstract List<Locacao> ListarLocacoesDoCliente(Cliente cliente);
    }
}
