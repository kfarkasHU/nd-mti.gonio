using System;
using System.Threading;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;

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
