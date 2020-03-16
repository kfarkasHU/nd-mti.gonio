using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_LoadForm : Form
    {
        private readonly Timer _timer;

        public Form_LoadForm()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = 1500;

            _timer.Start();

            RuntimeContext.LoadFormInstance = this;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _timer.Stop();

            var mainForm = new Form_MainForm();
            mainForm.Show();

            Hide();
        }
    }
}
