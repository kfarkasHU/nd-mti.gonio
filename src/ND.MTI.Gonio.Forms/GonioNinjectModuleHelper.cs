using Ninject;

namespace ND.MTI.Gonio.Forms
{
    public static class GonioNinjectModuleHelper
    {
        private static IKernel _kernel;

        public static void SetKernel(IKernel kernel)
        {
            if (_kernel is null)
                _kernel = kernel;
        }

        internal static Form_LoadForm LoadForm => GetModule<Form_LoadForm>();
        internal static Form_MainForm MainForm => GetModule<Form_MainForm>();
        internal static Form_Finished FinishedForm => GetModule<Form_Finished>();
        internal static Form_Registration RegistarionForm => GetModule<Form_Registration>();
        internal static Form_VirtualZeroForm VirtualZeroForm => GetModule<Form_VirtualZeroForm>();
        internal static Form_AdvancedForm AdvancedForm => GetModule<Form_AdvancedForm>();
        internal static Form_ResultsForm ResultsForm => GetModule<Form_ResultsForm>();

        private static T GetModule<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
