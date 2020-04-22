using System;
using ND.MTI.Gonio.Service;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_ResultsForm : Form
    {
        private readonly Timer _timer;
        private readonly IExcelExportService _excelExportService;

        internal Form_ResultsForm()
        {
            _excelExportService = new ExcelExportService();

            _timer = new Timer();
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Interval = 1000;
            _timer.Enabled = true;

            InitializeComponent();

            BindData();
        }

        private void OnTimerTick(object sender, EventArgs e) => BindData();

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonExcelExport_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(RuntimeContext.Results);

        private void BindData()
        {
            var source = new BindingSource(RuntimeContext.ResultsBindingList, null);

            dataGridViewResults.DataSource = source;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
