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

        public override bool AlugarItem(Locacao produto)
        {
            return ControleAluguel.AdicionarItem(produto); 
        }

        public Bibliotecario CriarFuncionarioBibliotecario(CadastroPessoaTDO cadastro)
        {
            return new Bibliotecario(cadastro);
        }
    }
}
