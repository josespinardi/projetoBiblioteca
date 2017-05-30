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
        public int TotalDeLocacoes { get; private set; }
        private List<Produto> produtosComprados = new List<Produto>();
        private static int idCliente = 0;

        public Cliente(CadastroPessoaTDO cadastro)
        {
            this.Nome = cadastro.Nome;
            this.Cpf = cadastro.Cpf;
            this.TotalDeLocacoes = 0;
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

        public bool PodeFazerLocacao()
        {
            if (TotalDeLocacoes < numeroMaximoDeLocacoes) { return true; }

            return false;
        }

        public void AdicionarLocacaoTotal() { this.TotalDeLocacoes++; }

        public void RemoverLocacaoTotal() { this.TotalDeLocacoes--; }

        public override bool Equals(object obj)
        {
            Cliente cliente = (Cliente)obj;
            return this.Cpf == cliente.Cpf;
        }

    }
}
