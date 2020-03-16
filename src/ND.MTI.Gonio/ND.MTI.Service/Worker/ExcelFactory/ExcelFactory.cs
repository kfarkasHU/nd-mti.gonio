using System;
using OfficeOpenXml;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Service.Worker
{
    public class ExcelFactory : IExcelFactory
    {
        private readonly IGonioConfiguration _gonioConfiguration;
        private readonly ExcelExportServiceHelper _excelExportServiceHelper;

        public ExcelFactory()
        {
            _gonioConfiguration = GonioConfiguration.GetInstance();
            _excelExportServiceHelper = new ExcelExportServiceHelper();
        }

        public byte[] CreateExcelData(Complex_ResultCollection results)
        {
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets
                    .Add("Gonio results")
                ;

                #region [ Create headers ]

                worksheet.Cells[1, 1].Value = "#";
                worksheet.Cells[1, 2].Value = "Xk";
                worksheet.Cells[1, 3].Value = "Yk";
                worksheet.Cells[1, 4].Value = "Xv";
                worksheet.Cells[1, 5].Value = "Yv";
                worksheet.Cells[1, 6].Value = "E [lx]";
                worksheet.Cells[1, 7].Value = "I [cd]";
                worksheet.Cells[1, 8].Value = "K [lx]";

                #endregion [ Create headers ]

                #region [ Insert data ]

                var i = 1;
                var j = 0;
                for(; j < results.Count; i++, j++)
                {
                    var result = results[j];

                    worksheet.Cells[1, 1].Value = j.ToString();
                    worksheet.Cells[1, 2].Value = result.WantedPosition.X.ToString();
                    worksheet.Cells[1, 3].Value = result.WantedPosition.Y.ToString();
                    worksheet.Cells[1, 4].Value = result.RealPosition.X.ToString();
                    worksheet.Cells[1, 5].Value = result.RealPosition.Y.ToString();
                    worksheet.Cells[1, 6].Value = result.MeasuredIllumination.ToString();
                    worksheet.Cells[1, 7].Value = (result.MeasuredIllumination / Math.Pow(_gonioConfiguration.Sensor_Distance, 2)).ToString();
                    worksheet.Cells[1, 8].Value = _excelExportServiceHelper.GetCorrectionValue(result.MeasuredIllumination);
                }

                #endregion [ Insert data ]

            }
            throw new NotImplementedException();
        }
    }
}
