using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BLL.Util
{
    public static class EmailSender
    {
        private static SmtpClient client;

        private readonly static string userName = "tournamentmanager676@gmail.com";
        private readonly static string password = "86c0ea87a2f";

        static EmailSender()
        {
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(userName, password);
            client.EnableSsl = true;
        }

        public static void SendMessage(string title, string body, string deliverAddress)
        {
            MailMessage message = new MailMessage(userName, deliverAddress);

            message.Subject = title;
            message.Body = body;

            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
            }
            catch (SmtpException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

    }
}
