using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.DBFake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ListaDeLocacao : ListaItens
    {
        protected override bool condicaoVerdadeira(Locacao locacao)
        {
            return locacao.DataLocacao <= DateTime.Now;
        }

        public override List<Locacao> ListarLocacoesDoCliente(Cliente cliente)
        {
            List<Locacao> itensLocados = new List<Locacao>();

            foreach(Locacao locacao in base.ListarItens(new ItensLocadosDBFake().ListarItens()))
            {
                if (cliente.Equals(locacao.Cliente))
                {
                    itensLocados.Add(locacao);
                }
            }

            return itensLocados;
        }
    }
}
