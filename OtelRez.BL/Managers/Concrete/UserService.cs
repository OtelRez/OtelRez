using OtelRez.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OtelRez.BL.Managers.Abstract;

namespace OtelRez.BL.Managers.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SendForgotPasswordEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null) return false;

            // Mail gönderim işlemi
            try
            {
                var fromAddress = new MailAddress("istkafullkata@gmail.com", "YourApp");
                var toAddress = new MailAddress(user.Mail);
                const string fromPassword = "xofn vdfy pwql fjbj"; // Şifreyi buraya ekleyin
                const string subject = "Şifrenizi Hatırlatıyoruz";
                string body = $"Merhaba, şifreniz: {user.Sifre}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
