using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cappta.ProjetoBiblioteca.Produtos;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca;
using System.Net.Mail;

namespace ProjetoBiblioteca
{
    public partial class Form1 : Form
    {
        Funcionario usuarioLogadoNoSistema;
        Mensagens mensagem = new Mensagens();
        bool usuarioIsAdministrador = false;

        public Form1()
        {
            InitializeComponent();

            InicializadorDeDados cadastrosIniciais = new InicializadorDeDados();
            cadastrosIniciais.InicializarClientes();
            cadastrosIniciais.InicializarFuncionarios();
            cadastrosIniciais.InicializarProdutos();

            AtualizarComboBoxItens();
            AtualizarComboBoxClientes();

            radioButtonCliente.Checked = true;
            radioButtonLivro.Checked = true;

        }

        private void buttonComprados_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            List<Produto> itens = cliente.ListarItensComprados();

            MessageBox.Show(mensagem.MontarMensagemDeItens(itens));
        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboBoxClientes.SelectedIndex;
            Cliente cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);

            textBoxNomeCliente.Text = cliente.Nome;
            textBoxCpfCliente.Text = cliente.Cpf;

            comboBoxLivrosLocados.Items.Clear();
            comboBoxProdutosAtrasados.Items.Clear();

            foreach (Locacao locacao in ControleAluguel.ListarItensAlugadosPorCliente(cliente))
            {
                comboBoxLivrosLocados.Items.Add(locacao.getProduto());
            }

            foreach (Locacao locacao in ControleAluguel.ListarItensEmAtrasoPorCliente(cliente))
            {
                comboBoxProdutosAtrasados.Items.Add(locacao.getProduto());
            }
        }

        private void comboBoxLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produto = ControleEstoque.LocalizarProdudoPorIndice(comboBoxItens.SelectedIndex);

            textBoxTitulo.Text = produto.Titulo;
            textBoxAutor.Text = produto.Autor;
            textBoxLancamento.Text = Convert.ToString(produto.AnoDePublicacao);
        }

        private void buttonAlugar_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            var produto = ControleEstoque.LocalizarProdudoPorIndice(comboBoxItens.SelectedIndex);
            var itemLocado = new Locacao(cliente, produto);

            if (cliente.PodeFazerLocacao())
            {
                if (produto is Livro && usuarioIsAdministrador)
                {
                    if (usuarioLogadoNoSistema.AlugarItem(itemLocado))
                        MessageBox.Show("Livro locado");
                    else
                        MessageBox.Show("Problema na locação");
                }
                else
                {
                    if (ControleAluguel.AdicionarItem(itemLocado))
                        MessageBox.Show("Livro locado");
                    else
                        MessageBox.Show("Problema na locação");
                }
            }
            else
                MessageBox.Show("Limite de locações alcançado. \n" + "Devolva um item para poder locar outro!");
        }

        private void buttonLocados_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            List<Locacao> itensLocados = ControleAluguel.ListarItensAlugadosPorCliente(cliente);

            MessageBox.Show(mensagem.MontarMensagemDeLocacao(itensLocados));
        }

        private void buttonDevolucao_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            List<Locacao> alugueis = ControleAluguel.ListarItensAlugadosPorCliente(cliente);

            ControleAluguel.RemoverItem(alugueis[comboBoxLivrosLocados.SelectedIndex]);

            comboBoxLivrosLocados.Text = "Selecione";
            MessageBox.Show("Item devolvido");
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            var item = ControleEstoque.LocalizarProdudoPorIndice(comboBoxItens.SelectedIndex);
            Administrador administrador;

            if (usuarioIsAdministrador)
            {
                administrador = (Administrador)usuarioLogadoNoSistema;
                administrador.VenderItem(item, cliente);
                MessageBox.Show("Sucesso");
            }
            else
                MessageBox.Show("Funcionário sem permissão para realizar a venda!");

        }

        private void buttonAgendar_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            DateTime dataAgendamento = monthCalendarAgendamento.SelectionStart;
            Produto item = ControleEstoque.LocalizarProdudoPorIndice(comboBoxItens.SelectedIndex);
            AgendamentoDTO agendamento = new AgendamentoDTO(item, dataAgendamento, cliente);

            if (usuarioLogadoNoSistema.CompararDataDeAgendamento(dataAgendamento))
            {
                if (usuarioLogadoNoSistema.AgendarItem(agendamento))
                    MessageBox.Show("Livro Agendado!");

            }
            else
                MessageBox.Show("Deu ruim");
        }

        private void buttonAgendados_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            var alugueisDoCliente = ControleAluguel.ListarItensAgendadosPorCliente(cliente);

            MessageBox.Show(mensagem.MontarMensagemDeLocacao(alugueisDoCliente));
        }

        private void buttonListarAgendamentos_Click(object sender, EventArgs e)
        {
            List<Locacao> itensLocados = ControleAluguel.ListarItensAgendados();

            MessageBox.Show(mensagem.MontarMensagemDeLocacao(itensLocados));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO!
            string email = textBoxEmailLogin.Text;
            string senha = textBoxSenhaLogin.Text;
            LoginDTO login = new LoginDTO(email, senha);

            if (VerificarUsuarioLogado())
            {
                foreach (var funcionario in ControleFuncionario.ListarFuncionarios())
                {
                    if (funcionario.TemUmLoginValido(login))
                    {
                        MessageBox.Show("Logado");
                        usuarioLogadoNoSistema = funcionario;
                        labelNomeDoUsuarioLogado.Text = funcionario.Nome;
                        VerificarPermissaoDeUsuario(funcionario);
                        textBoxEmailLogin.Text = "";
                        textBoxSenhaLogin.Text = "";
                        break;
                    }

                }
                if (usuarioLogadoNoSistema == null)
                {
                    MessageBox.Show("Usuário não encontrado");
                }
            }
            else
                MessageBox.Show("Favor deslogar antes de entrar com novo usuário");
        }

        private bool VerificarUsuarioLogado()
        {
            if (usuarioLogadoNoSistema == null)
                return true;
            else
                return false;
        }

        private void VerificarPermissaoDeUsuario(Funcionario funcionario)
        {
            if (funcionario is Administrador)
            {
                usuarioIsAdministrador = true;
                groupBoxCadastro.Visible = true;
                groupBoxCadastroProduto.Visible = true;
            }
            groupBoxCliente.Visible = true;
            groupBoxProdutos.Visible = true;
            groupBoxLogin.Visible = false;
            pictureBoxLogo.Location = new Point(75, 8);
            pictureBoxLogo.Visible = true;
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            if (usuarioLogadoNoSistema != null)
            {
                labelNomeDoUsuarioLogado.Text = "Favor fazer login!";
                usuarioLogadoNoSistema = null;
                usuarioIsAdministrador = false;
                groupBoxCadastro.Visible = false;
                groupBoxCadastroProduto.Visible = false;
                groupBoxCliente.Visible = false;
                groupBoxProdutos.Visible = false;
                pictureBoxLogo.Visible = false;
                groupBoxLogin.Visible = true;
            }
        }

        private void radioButtonFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            labelEmailCadastro.Visible = true;
            labelSenhaCadastro.Visible = true;
            textBoxEmailCadastro.Visible = true;
            textBoxSenhaCadastro.Visible = true;
            groupBoxCadastroFuncao.Visible = true;
            radioButtonBibliotecario.Checked = true;
        }

        private void radioButtonCliente_CheckedChanged(object sender, EventArgs e)
        {
            labelEmailCadastro.Visible = true;
            labelSenhaCadastro.Visible = false;
            textBoxEmailCadastro.Visible = true;
            textBoxSenhaCadastro.Visible = false;
            groupBoxCadastroFuncao.Visible = false;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeCadastro.Text;
            string cpf = textBoxCpfCadastro.Text;
            string email = textBoxEmailCadastro.Text;
            string senha = textBoxSenhaCadastro.Text;
            CadastroPessoaTDO cadastro = new CadastroPessoaTDO(nome, cpf, email, senha);

            //TODO melhorar esse controle
            if (nome != "" && cpf != "" && email != "")
            {
                if (radioButtonCliente.Checked)
                    ControleClientes.CadastrarCliente(cadastro);
                else if (radioButtonAdministrador.Checked)
                    ControleFuncionario.CadastrarUsuarioAdministrador(cadastro);
                else
                    ControleFuncionario.CadastrarUsuarioBibliotecario(cadastro);
            }
            else
                MessageBox.Show("Digitar os campos");

            AtualizarComboBoxClientes();
            textBoxNomeCadastro.Text = "";
            textBoxCpfCadastro.Text = "";
            textBoxEmailCadastro.Text = "";
            textBoxSenhaCadastro.Text = "";
        }

        public void AtualizarComboBoxItens()
        {
            comboBoxItens.Items.Clear();
            foreach (Produto l in ControleEstoque.ListarItens())
            {
                comboBoxItens.Items.Add(l.Titulo);
            }
        }

        public void AtualizarComboBoxClientes()
        {
            comboBoxClientes.Items.Clear();
            foreach (Cliente cliente in ControleClientes.ListarClientes())
            {
                comboBoxClientes.Items.Add(cliente.Nome);
            }
        }

        private void buttonCadastrarProduto_Click(object sender, EventArgs e)
        {
            string titulo = textBoxCadastroProdutoTitulo.Text;
            string autor = textBoxCadastroProdutoAutor.Text;
            int ano = Convert.ToInt32(textBoxCadastroProdutoAno.Text);
            ProdutoDTO itemParaCadastro = new ProdutoDTO(titulo, ano, autor);
            Produto produto;

            if (ControleEstoque.VerificarAnoDeLancamento(Convert.ToInt32(textBoxCadastroProdutoAno.Text)))
            {
                if (radioButtonLivro.Checked)
                {
                    
                }
                else if (radioButtonRevista.Checked)
                {

                }
                else

                
                AtualizarComboBoxItens();
            }
            else
            {
                MessageBox.Show("Protudo muito antigo");
            }

            textBoxCadastroProdutoTitulo.Text = "";
            textBoxCadastroProdutoAutor.Text = "";
            textBoxCadastroProdutoAno.Text = "";
        }

        private void buttonListarTodosProdutos_Click(object sender, EventArgs e)
        {
            var produtos = ControleEstoque.ListarItens();

            MessageBox.Show(mensagem.MontarMensagemDeItens(produtos));
        }

        private void buttonListarTodasLocacoes_Click(object sender, EventArgs e)
        {
            List<Locacao> itensLocados = ControleAluguel.ListarItensAlugados();

            MessageBox.Show(mensagem.MontarMensagemDeLocacao(itensLocados));

        }

        private void buttonListarDevolucaoAtrasada_Click(object sender, EventArgs e)
        {
            List<Locacao> itensEmAtraso = ControleAluguel.ListarItensEmAtraso();

            MessageBox.Show(mensagem.MontarMensagemDeLocacao(itensEmAtraso));
        }
        
        private void buttonEnviarEmail_Click(object sender, EventArgs e)
        {
            var cliente = ControleClientes.LocalizarClientePorIndice(comboBoxClientes.SelectedIndex);
            List<Locacao> itensEmAtraso = ControleAluguel.ListarItensEmAtrasoPorCliente(cliente);
            string mensagemItensEmAtraso = mensagem.MontarMensagemDeLocacao(itensEmAtraso);

            if (MessageBox.Show("Deseja enviar cobrança para os itens abaixo? \n\n" + mensagemItensEmAtraso + "\n\n para o email " + cliente.Email, "Locações em atraso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            {
                Email email = new Email(cliente, mensagemItensEmAtraso);
                email.EnviarEmail();
                MessageBox.Show("Email Enviado");
            }
        }
    }
}
