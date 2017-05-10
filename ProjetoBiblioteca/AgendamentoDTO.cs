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
        public Produto produto;
        public DateTime data;
        public Cliente cliente;

        public AgendamentoDTO(Produto produto, DateTime data, Cliente cliente)
        {
            this.produto = produto;
            this.data = data;
            this.cliente = cliente;
        }
    }
}
