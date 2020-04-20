using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.Service
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly IIOWorker _ioWorker;
        private readonly IExcelFactory _excelFactory;

        public ExcelExportService()
        {
            _ioWorker = new IOWorker();
            _excelFactory = new ExcelFactory();
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
