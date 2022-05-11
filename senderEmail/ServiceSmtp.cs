using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace senderEmail
{
    class ServiceSmtp
    {
        public void senderEmail()
        {
            ServiceLog log = new ServiceLog();
            String server = "10.100.176.37";
            int port = 25;
            String emailSend = "usrbootr1@Dinersclub.com.ec";
            //String password = "Proyect.1";
            MimeMessage message = new MimeMessage();
            //Quien envia el correo
            message.From.Add(new MailboxAddress("RPA-Notification", emailSend));
            //Quien recibe
            message.From.Add(MailboxAddress.Parse("christian.miranda@bayteq.com"));
            //Tema del mensaje
            message.Subject = "correo de prueba";
            message.Body = new TextPart("plain")
            {
                Text = @"Este es un mensaje de prueba"
            };

            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect(server, port, false);
                //smtpClient.Authenticate(emailSend, password);
                smtpClient.Send(message);
                Console.WriteLine("Email send");
                System.Threading.Thread.Sleep(2000);
                log.putLog("Mensaje enviado");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                log.putLog("Mensaje error:"+error.Message);

            }
            finally
            {
                Console.WriteLine("Se termino el proceso");
                System.Threading.Thread.Sleep(2000);
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }

        }
    }
}
