using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca.Enum;
using Cappta.ProjetoBiblioteca.Factories;
using Cappta.ProjetoBiblioteca.DBFake;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleFuncionario
    {
        public void CriarFuncionario(FuncionarioEnum cargo, CadastroPessoaTDO pessoa)
        {
            Funcionario funcionario = new FuncionarioFactory().CriarFuncionario(cargo, pessoa);
            var controleDB = new FuncionariosDBFake();
            controleDB.Adicionar(funcionario);
        }
    }
}
