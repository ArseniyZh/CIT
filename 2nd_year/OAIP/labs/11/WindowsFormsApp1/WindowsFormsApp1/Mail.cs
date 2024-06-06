using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Mail
    {
        public static string GenerateCode()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);
            return randomNumber.ToString();
        }

        public void SendCode(string name, string email, string code)
        {
            string fromEmail = "Sayfutdinovaam@gmail.com";
            string fromPassword = "xrqwmypnjpjrtdym";
            MessageBox.Show(code);

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
            };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "Ваш код подтверждения",
                    Body = this.htmlBody(name, code),
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки почты: " + ex.Message);
            }
        }

        private string htmlBody(string name, string code)
        {
            string html = $"<body class=\"bg-red-100\">\r\n  " +
                $"<div class=\"container\">\r\n    " +
                $"<div class=\"space-y-4 mb-6\">\r\n      " +
                $"<h1 class=\"text-4xl fw-800\">{name}, ваш код для сброса пароля</h1>\r\n      " +
                $"<a class=\"btn btn-red-500 rounded-full px-6 w-full w-lg-48\" disable><b>{code}</b></a>\r\n    " +
                $"</div>\r\n  </div>\r\n</body>";
            return html;
        }
    }

}
