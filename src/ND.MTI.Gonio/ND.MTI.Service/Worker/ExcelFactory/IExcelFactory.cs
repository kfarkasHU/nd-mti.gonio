using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Service.Worker
{
    public interface IExcelFactory
    {
        byte[] CreateMeasurementResults(Complex_ResultCollection results);
        byte[] CreateRegistrationResults(Complex_RegistrationCollection results);
    }
}
