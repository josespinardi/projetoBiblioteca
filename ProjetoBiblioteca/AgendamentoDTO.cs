using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Produtos;

namespace ProjetoBiblioteca
{
    class AgendamentoDTO
    {
        public Produto Produto { get; protected set; }
        public DateTime Data { get; protected set; }
        public Cliente Cliente { get; protected set; }

        public AgendamentoDTO(Produto produto, DateTime data, Cliente cliente)
        {
            this.Produto = produto;
            this.Data = data;
            this.Cliente = cliente;
        }
    }
}
