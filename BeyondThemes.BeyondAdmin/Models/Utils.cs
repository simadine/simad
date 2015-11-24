using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Utils
    {
        public static void EnviarEmail(List<string> Destinatarios, String Mensaje, string Asunto, bool BodyHtml)
        {

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Host = "smtp.gmail.com";
            cliente.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            cliente.Port = 25;
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("scorderochavez@gmail.com", "Camila123*");
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            foreach (string dest in Destinatarios)
            {
                mail.To.Add(dest);
            }
            mail.From = new System.Net.Mail.MailAddress("scorderochavez@gmail.com", "Sistema", System.Text.Encoding.UTF8);
            mail.Body = Mensaje;
            mail.Subject = Asunto;
            mail.IsBodyHtml = BodyHtml;
            try
            {
                cliente.Send(mail);
            }
            catch
            {

            }


        }
    }
}
