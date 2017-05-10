﻿using System;
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
        public Administrador(string nome, string cpf, string email, string senha) : base(nome, cpf, email, senha) { }

        public override bool AlugarItem (Locacao produto)
        {
            return ControleAluguel.AdicionarItem(produto);
        }

        public bool VenderItem(Produto produto, Cliente cliente)
        {
            cliente.AdicionarLivroComprado(produto);
            return true;
        }
    }
}
