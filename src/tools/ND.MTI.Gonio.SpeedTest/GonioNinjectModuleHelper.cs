using ND.MTI.Gonio.ServiceInterface;
using Ninject;

namespace ND.MTI.Gonio.SpeedTest
{
    public static class GonioNinjectModuleHelper
    {
        private static IKernel _kernel;

        public static void SetKernel(IKernel kernel)
        {
            if (_kernel is null)
                _kernel = kernel;
        }

        internal static Form_MainForm MainForm => GetModule<Form_MainForm>();

        private static T GetModule<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
