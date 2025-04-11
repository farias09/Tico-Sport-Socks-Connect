using Microsoft.AspNet.Identity;
using System;
using Abstracciones.Utilidades;
using System.Net;
using System.Net.Mail;

namespace LN.General.EmailSender
{
    public class EmailSender
    {
        public void SendEmail(Email email)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("nigelpruebasmtp@gmail.com"),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = true
                };

                mail.To.Add(email.To);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("nigelpruebasmtp@gmail.com", "ggcwpmtymtmloxrs"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
