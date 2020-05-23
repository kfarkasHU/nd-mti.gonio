using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Notifier;
using ND.MTI.Gonio.Notifier.Contexts;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Notifier.Implementations;

namespace ND.MTI.Gonio.EmailSender
{
    public partial class Form_EmailSender : Form
    {
        public Form_EmailSender()
        {
            InitializeComponent();

            NotifyHub.Init();

            var config = GonioConfiguration.GetInstance();

            var data = new EmailNotifierData(
                config.Notification_Email_SMTPAddress,
                config.Notification_Email_SMTPPort,
                config.Notification_Email_SMTPUsername,
                config.Notification_Email_SMTPPassword,
                config.Notification_Email_SMTPSSLEnabled,
                config.Notification_Email_FromDisplayName,
                config.Notification_Email_FromEmailAddress
            );

            var notifier = new EmailNotifier(data, config.Notification_Email_TargetAddresses);

            NotifyHub.RegisterNotifier(notifier);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxSubject.Text = "";
            richTextBoxBody.Text = "";
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            var subject = textBoxSubject.Text;
            var body = richTextBoxBody.Text;

            NotifyHub.AddMessage(subject, body);
            NotifyHub.SendMessages();
        }

        private void ButtonClose_Click(object sender, EventArgs e) => Close();
    }
}
