using System;
using System.Threading;
using System.Windows.Forms;
using ND.MTI.Gonio.Notifier;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.Exceptions;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    internal static class GonioErrorHandler
    {
        internal static void HandleException(
            object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs
        )
        {
            var exception = unhandledExceptionEventArgs.ExceptionObject as Exception;
            HandleExceptionCore(exception);
        }

        internal static void HandleThreadException(
            object sender,
            ThreadExceptionEventArgs threadExceptionEventArgs
        ) =>
            HandleExceptionCore(threadExceptionEventArgs.Exception);

        private static void HandleExceptionCore(Exception exception)
        {
            var title = "FATAL ERROR";

            if (exception is Gonio_Exception _)
                title = "GONIO ERROR";

            var message = exception.Message;

            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            if(RuntimeContext.SendNotificationOnError)
            {
                var config = GonioConfiguration.GetInstance();

                var template = config.Notification_Email_ApplicationErrorHTMLTemplate;
                var text = string.Format(template, DateTime.Now.ToString(), exception.Message);

                NotifyHub.AddMessage(config.Notification_Email_ApplicationErrorSubject, text);
                NotifyHub.SendMessages();
            }
        }
    }
}
