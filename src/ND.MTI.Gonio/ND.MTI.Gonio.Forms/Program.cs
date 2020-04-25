using System;
using System.Threading;
using System.Windows.Forms;
using ND.MTI.Gonio.Notifier.Contexts;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Notifier.Implementations;
using ND.MTI.Gonio.Notifier;

namespace ND.MTI.Gonio.Forms
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RuntimeContext.Init();

            if (args.Length == 1)
                if (args[0] == "-o")
                    RuntimeContext.IsAdminContext = true;

            RegisterNotificators();
            RegisterExceptionHandlers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_LoadForm());
        }

        private static void RegisterNotificators()
        {
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

        private static void RegisterExceptionHandlers()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(GonioErrorHandler.HandleThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GonioErrorHandler.HandleException);
        }
    }
}
