using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.DBFake;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleAluguel
    {
        ItensLocadosDBFake controleDB = new ItensLocadosDBFake();

        public bool AlugarItem(Locacao locacao)
        {
            if (PodeFazerLocacao(locacao))
            {
                controleDB.Adicionar(locacao);
                locacao.Cliente.AdicionarLocacaoTotal();
                return true;
            }
            return false;
        }

        private bool PodeFazerLocacao(Locacao locacao)
        {
            return locacao.Produto.EstaDisponivel() && locacao.Cliente.PodeFazerLocacao();
        }

        public void DevolverItem(Locacao locacao, Cliente cliente)
        {
            controleDB.Remover(locacao);
            cliente.RemoverLocacaoTotal();
        }

        public bool AgendarItem(Locacao locacao)
        {
            if (locacao.Produto.EstaDisponivelNaData())
            {
                controleDB.Adicionar(locacao);
                return true;
            }
            return false;
        }
    }
}
