using System;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Model;
using OfficeOpenXml;

namespace ND.MTI.Service.Worker
{
    public class ExcelFactory : IExcelFactory
    {
        private readonly IGonioConfiguration _gonioConfiguration;

        public ExcelFactory()
        {
            _gonioConfiguration = GonioConfiguration.GetInstance();
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
                worksheet.Cells[1, 6].Value = " [lx]";
                worksheet.Cells[1, 7].Value = " [cd]";

                #endregion [ Create headers ]

                #region [ Insert data ]

                for(var i = 1; i <= results.Count; i++)
                {
                    var result = results[i];

                    worksheet.Cells[1, 1].Value = i.ToString();
                    worksheet.Cells[1, 2].Value = result.WantedPosition.X.ToString();
                    worksheet.Cells[1, 3].Value = result.WantedPosition.Y.ToString();
                    worksheet.Cells[1, 4].Value = result.RealPosition.X.ToString();
                    worksheet.Cells[1, 5].Value = result.RealPosition.Y.ToString();
                    worksheet.Cells[1, 6].Value = result.MeasuredIllumination.ToString();
                    worksheet.Cells[1, 7].Value = (result.MeasuredIllumination / Math.Pow(_gonioConfiguration.SensorDistance, 2)).ToString();
                }

                #endregion [ Insert data ]

            }
            throw new NotImplementedException();
        }
    }
}
