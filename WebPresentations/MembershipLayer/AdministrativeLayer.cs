using System.Net.Mail;
using System.Web.Security;

namespace WebPresentations.MembershipLayer
{
    public class AccountService
    {
        public static string PasswordReset(string userName)
        {
            try
            {
                var user = Membership.GetUser(userName);
                var newPassword = user.ResetPassword();
                var message = new MailService.MessageModel
                {
                    UserName = userName,
                    MessageSubject = "Password reset notification",
                    MessageBody = "Your password has been reset to: " + newPassword
                };
                MailService.SendConfirmationEmail(message);
                return ("Success");
            }
            catch
            {
                return ("Error");
            }
        }
    }

    public class MailService
    {
        public class MessageModel
        {
            public string UserName { get; set; }
            public string MessageSubject { get; set; }
            public string MessageBody { get; set; }
        }

        public static void SendConfirmationEmail(MessageModel model)
        {
            MembershipUser user = Membership.GetUser(model.UserName);
            var message = new MailMessage("iliketits.spambot@yahoo.com", user.Email)
            {
                Subject = model.MessageSubject,
                Body = model.MessageBody
            };
            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
