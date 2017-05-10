using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Controlers;


namespace Cappta.ProjetoBiblioteca.Pessoas
{
    class Bibliotecario : Funcionario
    {
        public Bibliotecario(string nome, string cpf, string email, string senha) : base(nome, cpf, email, senha) { }

        public override bool AlugarItem(Locacao produto)
        {
            return ControleAluguel.AdicionarItem(produto); 
        }
    }
}
