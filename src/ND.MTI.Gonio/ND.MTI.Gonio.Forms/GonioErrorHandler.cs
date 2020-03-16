using System;
using System.Threading;
using System.Windows.Forms;
using ND.MTI.Service.Worker;
using ND.MTI.Gonio.Common.Exceptions;

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
            var title = "FATAL ERROR";
            if (exception is Gonio_EndpointException endpointException)
            {
                var positionWorker = PositionWorker.GetInstance();

                switch (endpointException.Axis)
                {
                    case "X":
                        {
                            positionWorker.StopX();
                            positionWorker.ReverseX();
                            break;
                        }
                    case "Y":
                        {
                            positionWorker.StopY();
                            positionWorker.ReverseY();
                            break;
                        }
                }
            }

            if (exception is Gonio_Exception _)
                title = "GONIO ERROR";

            var message = exception.Message;

            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
