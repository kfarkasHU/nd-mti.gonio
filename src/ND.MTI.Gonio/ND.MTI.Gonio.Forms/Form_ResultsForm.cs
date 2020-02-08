using System;
using ND.MTI.Service;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_ResultsForm : Form
    {
        private readonly IExcelExportService _excelExportService;

        public Form_ResultsForm()
        {
            _excelExportService = new ExcelExportService();

            InitializeComponent();

            BindData(RuntimeContext.Results);
        }

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonExcelExport_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(RuntimeContext.Results);

        private void BindData(Complex_ResultCollection data)
        {

        }
    }
}
