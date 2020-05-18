using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Userconfig
{
    public interface IUserconfig
    {
        Primitive_Userconfig UserConfig { get; }
        void SaveUserConfig(Primitive_Userconfig config);
    }
}
