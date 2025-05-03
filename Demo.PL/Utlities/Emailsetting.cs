using System.Net;
using System.Net.Mail;
using Humanizer;

namespace Demo.PL.Utlities
{
    public static class Emailsetting
    {

        public static void sendEmail(Emails emails)
        {
            // عشان أبعت أيميل لازم يكون عندي ميل سيرفر انا هنا هعتمد علي الجميل كسيرفر ليه

            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("hassanfarahat570@gmail.com", "pyuz lhch gqqo grnu");
            client.Send("hassanfarahat570@gmail.com", emails.To, emails.Subject, emails.Body);
        }
    }
}
