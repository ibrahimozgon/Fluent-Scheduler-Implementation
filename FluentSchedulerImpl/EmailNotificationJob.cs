using System;
using System.Collections.Generic;
using System.Net.Mail;
using FluentScheduler;

namespace FluentSchedulerImpl
{
    public class EmailNotificationJob : IJob
    {
        public void Execute()
        {
            var emailsToSend = GetEmailsToSend();
            foreach (var email in emailsToSend)
            {
                SendEmail(email);
            }
        }

        private static void SendEmail(Email email)
        {
            try
            {
                var mail = new MailMessage("you@yourcompany.com", email.Address);
                var client = new SmtpClient
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.google.com"
                };
                mail.Subject = email.Subject;
                mail.Body = email.Body;
                client.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static IEnumerable<Email> GetEmailsToSend()
        {
            var list = new List<Email>
            {
                new Email
                {
                    Address = "ibrahimozgon@gmail.com",
                    Body = "Test mail",
                    Subject = "Test Subject"
                },
                new Email
                {
                    Address = "ibrahim.ozgon@gmail.com",
                    Body = "Test mail 2",
                    Subject = "Test Subject 2"
                }
            };
            return list;

        }
    }
}