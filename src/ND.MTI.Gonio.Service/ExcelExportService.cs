using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Service
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly IIOWorker _ioWorker;
        private readonly IExcelFactory _excelFactory;

        public ExcelExportService(IIOWorker ioWorker, IExcelFactory excelFactory)
        {
            _ioWorker = ioWorker;
            _excelFactory = excelFactory;
        }

        public void ExportToExcel(Complex_ResultCollection results)
        {
            var content = _excelFactory.CreateMeasurementResults(results);
            _ioWorker.SaveFile(content, IOWorker_Filter.ExcelFile);
        }

        public void ExportToExcel(Complex_RegistrationCollection results)
        {
            var content = _excelFactory.CreateRegistrationResults(results);
            _ioWorker.SaveFile(content, IOWorker_Filter.ExcelFile);
        }
    }
}
