using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Pessoas
{
    class Administrador : Funcionario
    {
        public Administrador (CadastroPessoaTDO cadastro) : base(cadastro) { }

        public override bool AlugarItem(Cliente cliente, Produto produto)
        {
            return new ControleAluguel().AlugarItem(new Locacao(cliente, produto));

        }

        public bool VenderItem(Produto produto, Cliente cliente)
        {
            cliente.AdicionarLivroComprado(produto);
            return true;
        }

        public Administrador CriarFuncionarioAdministrador(CadastroPessoaTDO cadastro)
        {
            return new Administrador(cadastro);
        }
    }
}
