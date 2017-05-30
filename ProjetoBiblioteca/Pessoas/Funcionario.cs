using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Controlers;
using ProjetoBiblioteca;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca.Pessoas
{
    abstract class Funcionario : Pessoa
    {
        private static int idFuncionario = 0;
        public int Id { get; private set; }
        public string Senha { get;  set; }
        
        public Funcionario (CadastroPessoaTDO cadastro)
        {
            this.Nome = cadastro.Nome;
            this.Cpf = cadastro.Cpf;
            base.Email = cadastro.Email;
            this.Senha = cadastro.Senha;
            AtualizaIdFuncionario();
            this.Id = idFuncionario;
        }

        private void AtualizaIdFuncionario()
        {
            idFuncionario++;
        }

        public bool AgendarItem(AgendamentoDTO agendamento)
        {
            Locacao locacao = new Locacao(agendamento.Cliente, agendamento.Produto, agendamento.Data);
            return new ControleAluguel().AgendarItem(locacao);
        }

        public abstract bool AlugarItem(Cliente cliente, Produto produto);

        internal bool TemUmLoginValido(LoginDTO login)
        {
            return this.Email == login.Email && this.Senha == login.Senha;
        }
    }
}
