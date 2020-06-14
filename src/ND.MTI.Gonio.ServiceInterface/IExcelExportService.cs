using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface IExcelExportService
    {
        void ExportToExcel(Complex_ResultCollection results);
        void ExportToExcel(Complex_RegistrationCollection results);
    }
}
