using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("caceresnataliaandrea@gmail.com", "ezpp elst wvvb vpxi");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";

        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreply@catalogoarticulos.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
