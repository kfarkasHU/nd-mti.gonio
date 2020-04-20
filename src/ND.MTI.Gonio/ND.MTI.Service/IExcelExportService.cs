using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Service
{
    public interface IExcelExportService
    {
        void ExportToExcel(Complex_ResultCollection results);
        void ExportToExcel(Complex_RegistrationCollection results);
    }
}
