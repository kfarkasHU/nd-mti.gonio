using System;
using System.Threading;
using System.Windows.Forms;

namespace ND.MTI.Gonio.Forms
{
    public static class GonioErrorHandler
    {
        public static void HandleException(
            object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs
        )
        {
            var exception = unhandledExceptionEventArgs.ExceptionObject as Exception;
            HandleExceptionCore(exception);
        }

        public static void HandleThreadException(
            object sender,
            ThreadExceptionEventArgs threadExceptionEventArgs
        ) =>
            HandleExceptionCore(threadExceptionEventArgs.Exception);

        private static void HandleExceptionCore(Exception exception)
        {
            var message = exception.Message;

            MessageBox.Show(
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
