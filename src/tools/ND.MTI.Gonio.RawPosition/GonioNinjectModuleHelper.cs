using Ninject;

namespace ND.MTI.Gonio.RawPosition
{
    public static class GonioNinjectModuleHelper
    {
        private static IKernel _kernel;

        public static void SetKernel(IKernel kernel)
        {
            if (_kernel is null)
                _kernel = kernel;
        }

        internal static RawPositionForm RawPositionForm => GetModule<RawPositionForm>();

        private static T GetModule<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
