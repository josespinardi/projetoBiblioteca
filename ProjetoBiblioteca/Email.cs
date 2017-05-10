using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cappta.ProjetoBiblioteca.Controlers;
using Cappta.ProjetoBiblioteca.Pessoas;
using Cappta.ProjetoBiblioteca.Produtos;
using System.Net.Mail;

namespace Cappta.ProjetoBiblioteca
{
    class Email
    {
        public string ItensEmAtraso { get; private set; }
        private Mensagens criadorDeMensagem = new Mensagens();
        private System.Net.Mail.SmtpClient clientSMTP = new System.Net.Mail.SmtpClient();
        private MailMessage mail = new MailMessage();
        private Cliente cliente;

        public Email(Cliente cliente, string itensEmAtraso)
        {
            this.cliente = cliente;
            this.ItensEmAtraso = itensEmAtraso;
        }    

        private void CriarSMTP()
        {
            clientSMTP.Host = "smtp.gmail.com";
            clientSMTP.EnableSsl = true;
            clientSMTP.Credentials = new System.Net.NetworkCredential("ookami.zeh@gmail.com", "Tigreza030389@");
        }

        private void GerarEmail()
        {
            mail.Sender = new System.Net.Mail.MailAddress("ookami.zeh@gmail.com", "Jose Eduardo");
            mail.From = new MailAddress("ookami.zeh@gmail.com", "Jose Eduardo");
            mail.To.Add(new MailAddress(cliente.Email, cliente.Nome));
            mail.Subject = "Contato";
            mail.Body = " BIBLIOTECA CAPPTA<br/> Nome:  " + "Eduardo" + "<br/> Email : " + "ookami.zeh@gmail.com" +
                " <br/> Mensagem : " + "Suas locações em atraso: <br/><br/>" + ItensEmAtraso + "<br/>Favor entrar em contato";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
        }

        public void EnviarEmail()
        {
            CriarSMTP();
            GerarEmail();
            clientSMTP.Send(mail);
        }
    }
}
