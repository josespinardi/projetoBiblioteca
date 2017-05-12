using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Controlers
{
    class ControleFuncionario
    {
        private static List<Funcionario> funcionariosCadastrados = new List<Funcionario>();

        public static void AdicionarFuncionario(Funcionario funcionario)
        {
            funcionariosCadastrados.Add(funcionario);
        }

        public static void RemoverFuncionario(Funcionario funcionario)
        {
            funcionariosCadastrados.Remove(funcionario);
        }

        public static List<Funcionario> ListarFuncionarios()
        {
            return funcionariosCadastrados;
        }

        //CADASTRAR FUNCIONARIO NO LUGAR CERTO!!
        //SEM COESAO CRESCE A CADA NOVO PRODUTO!!
        public static bool CadastrarUsuarioBibliotecario(CadastroPessoaTDO cadastro)
        {
            var funcionario = CriarUsuarioBibliotecario(cadastro);
            AdicionarFuncionario(funcionario);
            return ConsultarFuncionarioCadatrado(funcionario);
        }

        public static Funcionario CriarUsuarioBibliotecario(CadastroPessoaTDO cadastro)
        {
            return new Bibliotecario(cadastro.Nome, cadastro.Cpf, cadastro.Email, cadastro.Senha);
        }

        public static bool CadastrarUsuarioAdministrador(CadastroPessoaTDO cadastro)
        {
            var funcionario = CriarUsuarioAdministrador(cadastro);
            AdicionarFuncionario(funcionario);
            return ConsultarFuncionarioCadatrado(funcionario);
        }

        public static Funcionario CriarUsuarioAdministrador(CadastroPessoaTDO cadastro)
        {
            return new Administrador(cadastro.Nome, cadastro.Cpf, cadastro.Email, cadastro.Senha);
        }

        public static bool ConsultarFuncionarioCadatrado(Funcionario funcionario)
        {
            if (funcionariosCadastrados.Contains(funcionario))
                return true;

            return false;
        }
    }
}
