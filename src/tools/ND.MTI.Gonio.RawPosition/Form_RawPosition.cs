using System;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.RawPosition
{
    public partial class RawPositionForm : Form
    {
        private readonly GonioTimer _timer;
        private readonly IPositionWorker _positionWorker;

        private bool _keyPressed;

        public RawPositionForm()
        {
            InitializeComponent();

            _timer = new GonioTimer(OnTimerTick, 10);
            _positionWorker = PositionWorker.GetInstance();

            _positionWorker.StopX();
            _positionWorker.StopY();

            KeyPreview = true;
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            _timer.Start();
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
                    _positionWorker.IncrementXSlow();
                    break;

                case Keys.W:
                    _positionWorker.DecrementXSlow();
                    break;

                case Keys.E:
                    _positionWorker.IncrementXFast();
                    break;

                case Keys.R:
                    _positionWorker.DecrementXFast();
                    break;

                case Keys.A:
                    _positionWorker.IncrementYSlow();
                    break;

                case Keys.S:
                    _positionWorker.DecrementYSlow();
                    break;

                case Keys.D:
                    _positionWorker.IncrementYFast();
                    break;

                case Keys.F:
                    _positionWorker.DecrementYFast();
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
                case Keys.E:
                case Keys.R:
                    _positionWorker.StopX();
                    break;

                case Keys.A:
                case Keys.S:
                case Keys.D:
                case Keys.F:
                    _positionWorker.StopY();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void ButtonStopX_Click(object sender, EventArgs e) => _positionWorker.StopX();

        private void ButtonStopY_Click(object sender, EventArgs e) => _positionWorker.StopY();

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            _positionWorker.StopX();
            _positionWorker.StopY();

            Close();
        }

        private void ButtonIncXSlow_Click(object sender, EventArgs e) => _positionWorker.IncrementXSlow();

        private void ButtonDecXSlow_Click(object sender, EventArgs e) => _positionWorker.DecrementYSlow();

        private void ButtonIncXFast_Click(object sender, EventArgs e) => _positionWorker.IncrementXFast();

        private void ButtonDecXFast_Click(object sender, EventArgs e) => _positionWorker.DecrementXFast();

        private void ButtonIncYSlow_Click(object sender, EventArgs e) => _positionWorker.IncrementYSlow();

        private void ButtonDecYSlow_Click(object sender, EventArgs e) => _positionWorker.DecrementYSlow();

        private void ButtonIncYFast_Click(object sender, EventArgs e) => _positionWorker.IncrementXFast();

        private void ButtonDecYFast_Click(object sender, EventArgs e) => _positionWorker.DecrementYFast();
    }
}
