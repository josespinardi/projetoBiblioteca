using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;


//TODO TIRAR OS METODOS QUE SÓ UTILIZAM CLIENTE E COLOCAR NA CLASSE CLIENTE

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleAluguel
    {
        private ControleAluguel instance;
        private static List<Locacao> ItensLocados = new List<Locacao>();

        private ControleAluguel() { }

        public ControleAluguel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControleAluguel();
                }
                return instance;
            }
        }

        public static bool AdicionarItem(Locacao item)
        {
            ItensLocados.Add(item);
            return ConsultarItemLocado(item);
        }

        public static void RemoverItem(Locacao item)
        {
            if(ItensLocados.Contains(item))
                ItensLocados.Remove(item);
        }

        public static List<Locacao> ListarItens()
        {
            return ItensLocados;
        }

        public static bool ConsultarItemLocado(Locacao item)
        {
            if (ItensLocados.Contains(item))
                return true;

            return false;
        }

        public static List<Locacao> ListarItensAlugados()
        {
            DateTime hoje = DateTime.Now;

            var itensAgendados = ItensLocados.Where(locacao => locacao.getDataLocacao() <= hoje).ToList();

            return itensAgendados;
        }

        public static List<Locacao> ListarItensAlugadosPorCliente(Cliente cliente)
        {
            List<Locacao> alugueisDoCliente = new List<Locacao>();

            CriarListaDeItensDoCliente(cliente, alugueisDoCliente);

            return alugueisDoCliente;
        }

        public static int ContarAlugueisPorCliente(Cliente cliente)
        {
            List<Locacao> locacaoDoCliente = ListarItensAlugadosPorCliente(cliente);

            return locacaoDoCliente.Count;
        }

        public static List<Locacao> ListarItensAgendados()
        {
            DateTime hoje = DateTime.Now;

            var itensAgendados = ItensLocados.Where(locacao => locacao.getDataLocacao() > hoje).ToList();

            return itensAgendados;
        }

        public static List<Locacao> ListarItensAgendadosPorCliente(Cliente cliente)
        {
            var alugueisDoCliente = new List<Locacao>();

            CriarListaDeItensDoCliente(cliente, alugueisDoCliente);

            return alugueisDoCliente;
        }

        public static List<Locacao> ListarItensEmAtraso()
        {
            DateTime hoje = DateTime.Now;

            var itensAgendados = ItensLocados.Where(locacao => locacao.getDataDevolucao() < hoje).ToList();

            return itensAgendados;
        }

        public static List<Locacao> ListarItensEmAtrasoPorCliente(Cliente cliente)
        {
            var atrasosDoCliente = new List<Locacao>();

            CriarListaDeItensDoCliente(cliente, atrasosDoCliente);

            return atrasosDoCliente;
        }

        private static void CriarListaDeItensDoCliente(Cliente cliente, List<Locacao> alugueisDoCliente)
        {
            foreach (Locacao aluguel in ListarItensAlugados())
            {
                if (aluguel.getCliente() == cliente)
                    alugueisDoCliente.Add(aluguel);
            }
        }
    }
}
