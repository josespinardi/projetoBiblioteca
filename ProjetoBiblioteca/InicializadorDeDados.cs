using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;

namespace Cappta.ProjetoBiblioteca
{
    class InicializadorDeDados
    {
        public void InicializarFuncionarios()
        {
            var func1 = new Administrador("Paulo Roberto", "74185296325", "paulo@paulo.com", "1234");
            var func2 = new Bibliotecario("Antonio Carlos", "14785236925", "antonio@antonio.com", "1234");
            var func3 = new Administrador("Jose Spinardi", "32165498745", "jose@jose.com", "1234");


            ControleFuncionario.AdicionarFuncionario(func1);
            ControleFuncionario.AdicionarFuncionario(func2);
            ControleFuncionario.AdicionarFuncionario(func3);
        }

        public void InicializarProdutos()
        {
            var livro1 = new Livro("Clean Code", "R.C. Martin", 2009);
            var livro2 = new Livro("O Hobbit", "J.R.R. Tolkien", 2012);
            var livro3 = new Livro("Apenda Java", "Glauco Todesco", 2005);
            var livro4 = new Livro("Scrum", "Antonio Bandeira", 2016);

            ControleEstoque.AdicionarItem(livro1);
            ControleEstoque.AdicionarItem(livro2);
            ControleEstoque.AdicionarItem(livro3);
            ControleEstoque.AdicionarItem(livro4);
        }

        public void InicializarClientes()
        {
            var cliente1 = new Cliente("Renato Forcinni", "36985214789", "cesar.nobre@cappta.com.br");
            var cliente2 = new Cliente("Brandon Lee", "12547896521", "cesar.nobre@cappta.com.br");
            var cliente3 = new Cliente("Sergio Alvares", "20145860230", "cesar.nobre@cappta.com.br");
            var cliente4 = new Cliente("Leticia Romei", "02145201456", "cesar.nobre@cappta.com.br");

            ControleClientes.AdicionarCliente(cliente1);
            ControleClientes.AdicionarCliente(cliente2);
            ControleClientes.AdicionarCliente(cliente3);
            ControleClientes.AdicionarCliente(cliente4);
        }
    }
}
