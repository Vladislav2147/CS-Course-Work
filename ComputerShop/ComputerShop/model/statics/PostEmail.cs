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
		public static void SendEmail(string fromAdress, string fromPassword, string toAdress, string message)
		{

                MailAddress from = new MailAddress(fromAdress);
                MailAddress to = new MailAddress(toAdress);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Заказ подтвержден";
                m.Body = message;
                m.IsBodyHtml = true;
               
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAdress, fromPassword);
                smtp.EnableSsl = true;
               
                smtp.Send(m);
            }
        }
	}
}
