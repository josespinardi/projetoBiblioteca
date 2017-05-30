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
        public Cliente Cliente { get; private set; }
        public Produto Produto { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime DataDevolucao { get; private set; }

        public Locacao(Cliente cliente, Produto produto)
        {
            this.Cliente = cliente;
            this.Produto = produto;
            this.DataLocacao = DateTime.Now;
            DataDevolucao = DataLocacao.AddDays(LIMITE_DE_DIAS_PARA_AGENDAR);
        }

        public Locacao(Cliente cliente, Produto produto, DateTime agendamento)
        {
            this.Cliente = cliente;
            this.Produto = produto;
            this.DataLocacao = agendamento;
        }
    }
}
