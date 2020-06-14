using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using System.Diagnostics;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_Registration : Form
    {
        private int _interval;
        private Thread _thread;
        private readonly GonioTimer _timer;
        private readonly IGonioWorker _gonioWorker;
        private readonly Complex_RegistrationCollection _results;
        private readonly IExcelExportService _excelExportService;

        public Form_Registration(IGonioWorker gonioWorker, IExcelExportService excelExportService)
        {
            _gonioWorker = gonioWorker;
            _results = new Complex_RegistrationCollection();
            _excelExportService = excelExportService;

            _timer = new GonioTimer(OnTimerTick, 100);

            InitializeComponent();

            var timeCol = new DataGridViewTextBoxColumn();
            timeCol.HeaderText = "Time";

            var deltaCol = new DataGridViewTextBoxColumn();
            deltaCol.HeaderText = "∆T (ms)";

            var valueCol = new DataGridViewTextBoxColumn();
            valueCol.HeaderText = "Data (lx)";

            dataGridViewResults.Columns.AddRange(timeCol, deltaCol, valueCol);
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            for(var i = 0; i < _results.Count; i++)
            {
                var needToAdd = true;

                foreach (DataGridViewRow row in dataGridViewResults.Rows)
                    if (row.Cells[0].Value.ToString() == _results[i].Time.ToString())
                        needToAdd = false;

                if(needToAdd)
                    dataGridViewResults.Rows.Add(_results[i].Time, _results[i].Delta, _results[i].Data);
            }
            dataGridViewResults.Update();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
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

            _thread.Abort();
            _timer.Stop();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            dataGridViewResults.Rows.Clear();
            _results.Clear();

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
            _thread.IsBackground = true;
            _thread.Start();
            _timer.Start();
        }

        private void ButtonSave_Click(object sender, EventArgs e) => _excelExportService.ExportToExcel(_results);

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            dataGridViewResults.Rows.Clear();

            buttonSave.Enabled = false;
            _results.Clear();
        }
        
        private void WorkingThreadImplementation()
        {
            var delta = 0.0d;
            while (true)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var data = _gonioWorker.MeasureOperated();
                var time = DateTime.Now.TimeOfDay;

                _results.Add(new Complex_RegistrationItem(time, data, delta));

                var remainingTime = _interval - (int)stopwatch.ElapsedMilliseconds;

                if (remainingTime > 0)
                    Thread.Sleep(remainingTime);

                delta = (double)stopwatch.ElapsedMilliseconds;
                stopwatch.Stop();
            }
        }
    }
}
