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
    class Bibliotecario : Funcionario
    {
        public Bibliotecario(CadastroPessoaTDO cadastro) : base(cadastro) { }

        public override bool AlugarItem(Cliente cliente, Produto produto)
        {
            if (!TemPermissaoParaAlugar(produto))
            {
                return new ControleAluguel().AlugarItem(new Locacao(cliente, produto));
            }
            return false;
        }

        private bool TemPermissaoParaAlugar(Produto produto)
        {
            if(produto is Livro) { return false; }

            return true;
        }
    }
}
