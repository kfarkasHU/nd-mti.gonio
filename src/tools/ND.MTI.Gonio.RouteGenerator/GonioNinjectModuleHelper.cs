using Ninject;

namespace ND.MTI.Gonio.RouteGenerator
{
    public static class GonioNinjectModuleHelper
    {
        private static IKernel _kernel;

        public static void SetKernel(IKernel kernel)
        {
            if (_kernel is null)
                _kernel = kernel;
        }

        internal static Form_RouteGenerator RouteGeneratorForm => GetModule<Form_RouteGenerator>();

        private static T GetModule<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
