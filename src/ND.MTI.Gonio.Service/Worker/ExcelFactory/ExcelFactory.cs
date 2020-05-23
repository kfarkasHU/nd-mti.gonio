using System.Linq;
using OfficeOpenXml;
using ND.MTI.Gonio.Model;
using System;

namespace ND.MTI.Gonio.Service.Worker
{
    public class ExcelFactory : IExcelFactory
    {
        public ExcelFactory()
        {
        }

        public byte[] CreateMeasurementResults(Complex_ResultCollection results)
        {

            byte[] content;
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets
                    .Add("Results");

                var uniqueXValues = results
                    .Select(m => m.Position.X)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                var xColIndex = 2;
                for (var i = 0; i < uniqueXValues.Count; i++, xColIndex += 2)
                {
                    worksheet.Cells[1, xColIndex].Value = uniqueXValues[i];

                    var relatedResults = results
                        .Where(m => m.Position.X == uniqueXValues[i])
                        .OrderBy(m => m.Position.Y)
                        .ToList();

                    for(var j = 0; j < relatedResults.Count; j++)
                    {
                        worksheet.Cells[j + 2, xColIndex - 1].Value = relatedResults[j].Position.Y;
                        worksheet.Cells[j + 2, xColIndex].Value = relatedResults[j].Candela;
                    }
                }

                content = package.GetAsByteArray();
            }

            return content;
        }

        public byte[] CreateRegistrationResults(Complex_RegistrationCollection results)
        {
            byte[] content;

            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets
                    .Add("Results");

                worksheet.Cells[1, 1].Value = "Time";
                worksheet.Cells[1, 2].Value = "∆T (ms)";
                worksheet.Cells[1, 3].Value = "Data (lx)";

                worksheet.Column(1).Style.Numberformat.Format = "hh:mm:ss";

                for (var i = 0; i < results.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = results[i].Time;
                    worksheet.Cells[i + 2, 2].Value = results[i].Delta;
                    worksheet.Cells[i + 2, 3].Value = results[i].Data;
                }

                content = package.GetAsByteArray();
            }
            
            return content;
        }
    }
}
