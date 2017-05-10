using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Produtos;

namespace Cappta.ProjetoBiblioteca
{
    class Locacao
    {
        const int LIMITE_DE_DIAS_PARA_AGENDAR = 7;
        private Cliente cliente;
        private Produto produto;
        private DateTime dataLocacao;
        private DateTime dataDevolucao;

        public Locacao(Cliente cliente, Produto produto)
        {
            this.cliente = cliente;
            this.produto = produto;
            this.dataLocacao = DateTime.Now;
            dataDevolucao = dataLocacao.AddDays(LIMITE_DE_DIAS_PARA_AGENDAR);
        }

        public Locacao(Cliente cliente, Produto produto, DateTime agendamento)
        {
            this.cliente = cliente;
            this.produto = produto;
            this.dataLocacao = agendamento;
        }

        public Cliente getCliente()
        {
            return cliente;
        }

        public Produto getProduto()
        {
            return produto;
        }

        public DateTime getDataLocacao()
        {
            return dataLocacao;
        }

        public DateTime getDataDevolucao()
        {
            return dataDevolucao;
        }
    }
}
