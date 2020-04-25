namespace ND.MTI.Gonio.Notifier.Contexts
{
    public sealed class EmailNotifierData
    {
        public EmailNotifierData(
                string smtpAddress,
                int smtpPort,
                string smtpUsername,
                string smtpPassword,
                bool smtpSslEnabled,
                string fromDisplayName,
                string fromEmailAddress
            )
        {
            SMTPAddress = smtpAddress;
            SMTPPort = smtpPort;
            SMTPUsername = smtpUsername;
            SMTPPassword = smtpPassword;
            SMTPSSLEnabled = smtpSslEnabled;

            FromDisplayName = fromDisplayName;
            FromEmailAddress = fromEmailAddress;
        }

        public string SMTPAddress { get; private set; }
        public int SMTPPort { get; private set; }
        public string SMTPUsername { get; private set; }
        public string SMTPPassword { get; private set; }
        public bool SMTPSSLEnabled { get; private set; }

        public string FromEmailAddress { get; private set; }
        public string FromDisplayName { get; private set; }
    }
}
