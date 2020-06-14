using System;
using System.Windows.Forms;
using Ninject;

namespace ND.MTI.Gonio.RouteGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel(new GonioNinjectModule());
            GonioNinjectModuleHelper.SetKernel(kernel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GonioNinjectModuleHelper.RouteGeneratorForm);
        }
    }
}
