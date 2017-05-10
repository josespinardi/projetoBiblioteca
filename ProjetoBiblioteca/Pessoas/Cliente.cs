using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Controlers;

namespace Cappta.ProjetoBiblioteca.Pessoas
{
    class Cliente : Pessoa
    {
        const int numeroMaximoDeLocacoes = 2;
        public int Id { get; private set; }
        private List<Produto> produtosComprados = new List<Produto>();
        private static int idCliente = 0;

        public Cliente(String nome, string cpf, string email)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            base.Email = email;
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
            if(ControleAluguel.ContarAlugueisPorCliente(this) < numeroMaximoDeLocacoes)
                return true;

            return false;
        }

    }

    
}
