using ND.MTI.Gonio.Common.Configuration;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ND.MTI.Gonio.Forms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            RegisterExceptionHandlers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_LoadForm());
        }

        private static void RegisterExceptionHandlers()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(GonioErrorHandler.HandleThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GonioErrorHandler.HandleException);
        }
    }
}
