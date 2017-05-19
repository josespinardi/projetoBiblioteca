using Cappta.ProjetoBiblioteca.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappta.ProjetoBiblioteca.DBFake
{
    class FuncionariosDBFake : IDBFake
    {
        private static List<Funcionario> funcionariosCadastrados = new List<Funcionario>();

        public void Adicionar(Funcionario funcionario)
        {
            funcionariosCadastrados.Add(funcionario);
        }

        public void Remover(Funcionario funcionario)
        {
            funcionariosCadastrados.Remove(funcionario);
        }

        public List<Funcionario> ListarItens()
        {
            return funcionariosCadastrados;
        }
    }
}
