using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FunctionEnvioEmail.Dominio
{
    public class DadosEmail
    {
        public bool EnviarEmail(string titulo, string mensagem, string destinatarios)
        {
            var remetente = "SEU_EMAIL.COM.BR";
            var senha = "SUA SENHA";

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;

            try
            {
                MailAddress fromAddress = new MailAddress(remetente);
                message.From = fromAddress;
                foreach (var item in destinatarios.Split(";"))
                {
                    message.To.Add(item);
                }

                message.Subject = titulo;
                message.IsBodyHtml = true;
                message.Body = mensagem;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials =
                    new System.Net.NetworkCredential(remetente, senha);
                smtpClient.Send(message);

                return true;


            }
            catch (Exception ex)
            {
                msg = ex.Message;

                return false;
            }

        }

    }
}
