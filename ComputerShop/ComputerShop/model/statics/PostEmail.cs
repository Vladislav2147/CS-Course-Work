using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerShop.model.statics
{
	public static class PostEmail
	{
		public static async void SendEmail(string toAdress, string message)
		{
            try
			{
                MailAddress from = new MailAddress(Properties.Resources.AdminEmail);
                MailAddress to = new MailAddress(toAdress);
                MailMessage m = new MailMessage(from, to);
                m.Body = message;
                m.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Properties.Resources.AdminEmail, Properties.Resources.AdminPassword);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(m);
                    MessageBox.Show("Сообщение отправлено");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {e.Message}");
            }
        }
	}
}
