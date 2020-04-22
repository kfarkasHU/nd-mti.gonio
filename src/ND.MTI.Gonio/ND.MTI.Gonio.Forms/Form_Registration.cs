using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using System.Diagnostics;
using ND.MTI.Gonio.Service;
using System.Windows.Forms;
using System.ComponentModel;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Registration : Form
    {
        private int _interval;
        private Thread _thread;
        private bool _isReading;
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

        ~Form_Registration()
        {
            _isReading = false;
            _timer.Stop();

            if(!(_thread is null))
                _thread.Abort();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Complex_RegistrationItem>(_results);
            var source = new BindingSource(bindingList, null);

            dataGridViewResults.DataSource = source;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            _isReading = false;

            if (!(_thread is null))
                _thread.Abort();

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

            _isReading = false;
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
            _isReading = true;
            _thread = new Thread(WorkingThreadImplementation);
            _thread.IsBackground = true;
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
            while (_isReading)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var data = _gonioWorker.Measure();
                var time = DateTime.Now.TimeOfDay;

                _results.Add(new Complex_RegistrationItem(time, data));
                stopwatch.Stop();

                var remainingTime = _interval - (int)stopwatch.ElapsedMilliseconds;

                if (remainingTime > 0)
                    Thread.Sleep(remainingTime);
            }
        }
    }
}
