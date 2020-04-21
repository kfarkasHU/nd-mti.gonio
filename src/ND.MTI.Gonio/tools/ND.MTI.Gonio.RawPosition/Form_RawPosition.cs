using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.RawPosition
{
    public partial class RawPositionForm : Form
    {
        private readonly Timer _timer;
        private readonly IPositionWorker _positionWorker;

        private bool _keyPressed;

        public RawPositionForm()
        {
            InitializeComponent();

            _timer = new Timer();
            _positionWorker = PositionWorker.GetInstance();

            _positionWorker.StopX();
            _positionWorker.StopY();

            KeyPreview = true;
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            _timer.Interval = 10;
            _timer.Tick += OnTimerTick;
            _timer.Enabled = true;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var income = _positionWorker.GetIncomeData();
            var rawPosition = _positionWorker.GetRawPosition();
            var normalisedPosition = _positionWorker.GetPosition();

            TextBoxX_Raw.Text = income.Item1.ToString();
            TextBoxY_Raw.Text = income.Item2.ToString();

            TextBoxX_Angle.Text = rawPosition.X.ToString();
            TextBoxY_Angle.Text = rawPosition.Y.ToString();

            TextBoxX_Normal.Text = normalisedPosition.X.ToString();
            TextBoxY_Normal.Text = normalisedPosition.Y.ToString();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_keyPressed)
                return;

            _keyPressed = true;

            Cursor = Cursors.WaitCursor;

            switch (e.KeyCode)
            {
                case Keys.Q:
                    _positionWorker.IncrementX();
                    break;

                case Keys.W:
                    _positionWorker.DecrementX();
                    break;

                case Keys.A:
                    _positionWorker.IncrementY();
                    break;

                case Keys.S:
                    _positionWorker.DecrementY();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;

            Cursor = Cursors.Arrow;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            _keyPressed = false;

            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.W:
                    _positionWorker.StopX();
                    break;

                case Keys.A:
                case Keys.S:
                    _positionWorker.StopY();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void ButtonIncX_Click(object sender, EventArgs e) => _positionWorker.IncrementX();

        private void ButtonDecX_Click(object sender, EventArgs e) => _positionWorker.DecrementX();

        private void ButtonStopX_Click(object sender, EventArgs e) => _positionWorker.StopX();

        private void ButtonIncY_Click(object sender, EventArgs e) => _positionWorker.IncrementY();

        private void ButtonDecY_Click(object sender, EventArgs e) => _positionWorker.DecrementY();

        private void ButtonStopY_Click(object sender, EventArgs e) => _positionWorker.StopY();

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            _positionWorker.StopX();
            _positionWorker.StopY();

            Close();
        }
    }
}
