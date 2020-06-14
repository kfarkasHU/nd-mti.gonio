using System.Net;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;
using ND.MTI.Gonio.Notifier.Contexts;

namespace ND.MTI.Gonio.Notifier.Implementations
{
    public sealed class EmailNotifier : NotifierBase<EmailNotifierData>
    {
        private SmtpClient _smtpClient;

        public EmailNotifier(EmailNotifierData context, IList<string> addresses) : base(context, addresses)
        {
        }

        protected override void BeforeSendMessages()
        {
            _smtpClient = new SmtpClient(_context.SMTPAddress, _context.SMTPPort);

            _smtpClient.EnableSsl = _context.SMTPSSLEnabled;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(_context.SMTPUsername, _context.SMTPPassword);
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        protected override void AfterSendMessages() => _smtpClient.Dispose();

        protected override void ExecuteMessage(string target, string body, string title)
        {
            var message = new MailMessage(_context.FromEmailAddress, target, title, body);

            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;
            message.Sender = new MailAddress(_context.FromEmailAddress, _context.FromDisplayName, Encoding.UTF8);

            _smtpClient.Send(message);
        }
    }
}
