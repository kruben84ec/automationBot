
using System;

namespace senderEmail
{
    internal class Sender
    {

        public static Boolean SenderEmailWithOutlook(string mailDirection, string mailSubject, string mailContent)
        {

            Boolean statusSender = false;

            try
            {
                //referencia al objecto de outlook
                var outlookApp = new Microsoft.Office.Interop.Outlook.Application();

                Microsoft.Office.Interop.Outlook.NameSpace ns = outlookApp.GetNamespace("MAPI");

                var f = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                System.Threading.Thread.Sleep(1000);

                var mailItem = (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = mailSubject;
                mailItem.HTMLBody = mailContent;
                mailItem.To = mailDirection;
                mailItem.Send();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return statusSender;
            }
            finally
            {
                statusSender = true;
            }

            return statusSender;

        }
    }
}