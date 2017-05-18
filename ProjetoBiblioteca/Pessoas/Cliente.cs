using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Pessoas
{
    class Cliente : Pessoa
    {
        const int numeroMaximoDeLocacoes = 2;
        public int Id { get; private set; }
        private List<Produto> produtosComprados = new List<Produto>();
        private static int idCliente = 0;

        public Cliente(CadastroPessoaTDO cadastro)
        {
            this.Nome = cadastro.Nome;
            this.Cpf = cadastro.Cpf;
            base.Email = cadastro.Email;
            AtualizaIdCliente();
            this.Id = idCliente;

        }

        private void AtualizaIdCliente()
        {
            idCliente++;
        }

        public void AdicionarLivroComprado(Produto produto)
        {
            this.produtosComprados.Add(produto);
        }

        public List<Produto> ListarItensComprados()
        {
            return produtosComprados;
        }


        /// <summary>
        /// ////////////////
        /// </summary>
        /// <returns></returns>

        public bool PodeFazerLocacao()
        {
            if(ControleAluguel.ContarAlugueisPorCliente(this) < numeroMaximoDeLocacoes)
                return true;

            return false;
        }

        public Cliente CriarUsuarioCLiente(CadastroPessoaTDO cadastro)
        {
            return new Cliente(cadastro);
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

        public static List<Locacao> ListarItensAgendadosPorCliente(Cliente cliente)
        {
            var alugueisDoCliente = new List<Locacao>();

            CriarListaDeItensDoCliente(cliente, alugueisDoCliente);

            return alugueisDoCliente;
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
                if (aluguel.Cliente == cliente)
                    alugueisDoCliente.Add(aluguel);
            }
        }

    }

    
}
