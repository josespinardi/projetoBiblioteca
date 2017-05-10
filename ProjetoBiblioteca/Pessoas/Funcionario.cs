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
        
        public Funcionario (string nome, string cpf, string email, string senha)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            base.Email = email;
            this.Senha = senha;
            AtualizaIdFuncionario();
            this.Id = idFuncionario;
        }

        public Funcionario(string email, string senha)
        {
            base.Email = email;
            this.Senha = senha;
        }

        private void AtualizaIdFuncionario()
        {
            idFuncionario++;
        }

        public bool AgendarItem(AgendamentoDTO agendamento)
        {
            Locacao locacao = new Locacao(agendamento.cliente, agendamento.produto, agendamento.data);
            return ControleAluguel.AdicionarItem(locacao); 
        }

        public abstract bool AlugarItem(Locacao produto);

        internal bool TemUmLoginValido(LoginDTO login)
        {
            return this.Email == login.Email && this.Senha == login.Senha;
        }

        public bool CompararDataDeAgendamento(DateTime agendamento)
        {
            if (agendamento > DateTime.Now)
                return true;
            
            return false;
        }
    }
}
