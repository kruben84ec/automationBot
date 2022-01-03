using Microsoft.Office.Interop.Outlook;
using System;

namespace senderEmail
{
    internal class Program : Sender
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Arguemtos invalidos");
                return;
            }

            string mailDirection = args[0];
            string mailSubject= args[1];
            string mailContent= args[2];

            Console.WriteLine(mailDirection + " " + mailSubject);

            Console.WriteLine("Este es un programa que envia correos");
            
            if(mailDirection != "" && mailSubject != "" && mailContent!= "")
            {
                bool isSend = SenderEmailWithOutlook(mailDirection, mailSubject, mailContent);
                if (isSend)
                {
                    Console.WriteLine("Se envio de manera correcta el correo");
                }else
                {
                    Console.WriteLine("Algo Fallo");
                }
            }else { Console.WriteLine("Los valores no puden ser nulos");}
            
            

        }
    }
}
