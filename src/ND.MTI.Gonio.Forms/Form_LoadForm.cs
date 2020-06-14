using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.Forms
{
    internal partial class Form_LoadForm : Form
    {
        private readonly GonioTimer _timer;

        public Form_LoadForm()
        {
            InitializeComponent();

            _timer = new GonioTimer(OnTimerTick, 1500);

            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _timer.Stop();

            var mainForm = GonioNinjectModuleHelper.MainForm;
            mainForm.Show();

            Hide();
        }

        private void Form_LoadForm_Load(object sender, EventArgs e) => labelVersion.Text = $"ver.: v{Application.ProductVersion}";
    }
}
