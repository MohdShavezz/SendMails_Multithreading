using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Multithreading
{
    public class Program
    {
        public string email;
        public string subject;
        public string body;

        //2 step verification
        //go to bottom click app passwords
        public static void Mail(string email, string subject, string body)
        {
            string fromEmail = email;
            string fromPassword = "xxxxxxxxxxxxx";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;
            message.To.Add(new MailAddress(fromEmail));
            message.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                int ii = i+1;
                string address = "mdpctbtech19cse@gmail.com"; // Assuming you want to change the email address 
                Thread thread = new Thread(() => Mail(address, $"hello{ii}", "World"));
                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}
