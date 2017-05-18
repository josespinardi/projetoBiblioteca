using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;

namespace Cappta.ProjetoBiblioteca
{
    class Mensagens
    {
        public string Mensagem { get; set; }

        public string MontarMensagemDeItens(List<Produto> itensComprados)
        {
            Mensagem = "";
            foreach (Produto produto in itensComprados)
            {
                Mensagem += (" Título: " + produto.Titulo +
                            "\n Autor: " + produto.Autor +
                            "\n Ano de lançamento: " + produto.AnoDePublicacao +
                            "\n\n");

                //string.Format(Mensagens.MensagemModeloAutor, produto.Autor, produto.AnoDePublicacao);

            }
            return Mensagem;
        }

        public string MontarMensagemDeLocacao(List<Locacao> itensLocados)
        {
            Mensagem = "";
            foreach (Locacao locacao in itensLocados)
            {
                Mensagem += (" Título: " + locacao.Produto +
                            "\n Cliente: " + locacao.Cliente +
                            "\n Data de agendamento: " + locacao.DataLocacao +
                            "\n Data de devolução: " + locacao.DataDevolucao +
                            "\n\n");
            }
            return Mensagem;
        }

        public string MontarMensagensDeAgendamento(List<Locacao> itensAgendados)
        {
            Mensagem = "";
            foreach (Locacao locacao in itensAgendados)
            {
                Mensagem += (" Título: " + locacao.Produto +
                            "\n Cliente: " + locacao.Cliente +
                            "\n Data de agendamento: " + locacao.DataLocacao +
                            "\n\n");
            }
            return Mensagem;
        }
    }
}
