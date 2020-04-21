using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.RawPosition
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RawPositionForm());
        }
    }
}
