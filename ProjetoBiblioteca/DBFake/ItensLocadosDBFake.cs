using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.DBFake
{
    class ItensLocadosDBFake : IDBFake
    {
        private static List<Locacao> ItensLocados = new List<Locacao>();

        public void Adicionar(Locacao locacao)
        {
            ItensLocados.Add(locacao);
        }

        public void Remover(Locacao locacao)
        {
            ItensLocados.Remove(locacao);
        }

        public List<Locacao> ListarItens()
        {
            return ItensLocados;
        }
    }
}
