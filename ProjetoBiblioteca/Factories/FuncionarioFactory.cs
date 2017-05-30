using Cappta.ProjetoBiblioteca.Enum;
using Cappta.ProjetoBiblioteca.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.Factories
{
    class FuncionarioFactory
    {
        public Funcionario CriarFuncionario(FuncionarioEnum cargo, CadastroPessoaTDO cadastro)
        {
            switch (cargo)
            {
                case FuncionarioEnum.Administrador:
                    return new Administrador(cadastro);
                case FuncionarioEnum.Bibliotecario:
                    return new Bibliotecario(cadastro);
                default:
                    return null;
            }
        }
    }
}
