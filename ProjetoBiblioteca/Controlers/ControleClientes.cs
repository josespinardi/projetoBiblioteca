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
    class ControleClientes
    {

        //colocar logica de acesso no dbfake

        public static Cliente LocalizarClientePorIndice(int index)
        {
            return clientesCadastrados[index];
        } 
    }
}
