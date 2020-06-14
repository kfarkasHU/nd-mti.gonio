using ND.MTI.Gonio.ServiceInterface;
using Ninject;

namespace ND.MTI.Gonio.CLI
{
    public static class GonioNinjectModuleHelper
    {
        private static IKernel _kernel;

        public static void SetKernel(IKernel kernel)
        {
            if (_kernel is null)
                _kernel = kernel;
        }

        internal static IGonioWorker GonioWorker => GetModule<IGonioWorker>();
        internal static IPositionWorker PositionWorker => GetModule<IPositionWorker>();

        private static T GetModule<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
