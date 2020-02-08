using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Service.Worker;

namespace ND.MTI.Service
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
            var content = _excelFactory.CreateExcelData(results);
            _ioWorker.SaveFile(content);
        }
    }
}
