using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;
using Ninject;

namespace ND.MTI.Gonio.SpeedTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RuntimeContext.Init();

            var kernel = new StandardKernel(new GonioNinjectModule());
            GonioNinjectModuleHelper.SetKernel(kernel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GonioNinjectModuleHelper.MainForm);
        }
    }
}
