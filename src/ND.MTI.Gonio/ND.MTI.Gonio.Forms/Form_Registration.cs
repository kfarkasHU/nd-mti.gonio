using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service;
using System.Windows.Forms;
using ND.MTI.Service.Worker;
using System.ComponentModel;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Registration : Form
    {
        private int _interval;
        private Thread _thread;
        private readonly IGonioWorker _gonioWorker;
        private readonly System.Windows.Forms.Timer _timer;
        private readonly Complex_RegistrationCollection _results;
        private readonly IExcelExportService _excelExportService;

        public Form_Registration()
        {
            _gonioWorker = GonioWorker.GetInstance();
            _results = new Complex_RegistrationCollection();
            _excelExportService = new ExcelExportService();

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 100;
            _timer.Tick += OnTimerTick;

            InitializeComponent();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Complex_RegistrationItem>(_results);
            var source = new BindingSource(bindingList, null);

            dataGridViewResults.DataSource = source;
            dataGridViewResults.AutoResizeColumns();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            Close();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            buttonReset.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonClose.Enabled = true;
            buttonSave.Enabled = true;
            textBoxInterval.ReadOnly = false;

            _thread.Abort();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
            buttonReset.Enabled = false;
            buttonClose.Enabled = false;
            buttonStart.Enabled = false;
            buttonSave.Enabled = false;
            textBoxInterval.ReadOnly = true;

            var intervalStr = textBoxInterval.Text;
            var interval = Parser.StringToInteger(intervalStr);

            _interval = interval;

            _thread = new Thread(WorkingThreadImplementation);
            _thread.Start();
            _timer.Start();
        }

        private void ButtonSave_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(_results);

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            _results.Clear();
        }
        
        private void WorkingThreadImplementation()
        {
            while (true)
            {
                // TODO Explicit time!

                var data = _gonioWorker.Measure();
                var time = DateTime.Now.TimeOfDay;

                _results.Add(new Complex_RegistrationItem(time, data));

                Thread.Sleep(_interval * 900);
            }
        }
    }
}
