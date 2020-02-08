using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker
{
    public interface IExcelFactory
    {
        byte[] CreateExcelData(Complex_ResultCollection results);
    }
}
