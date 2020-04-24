using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.SpeedTest
{
    public partial class Form_MainForm : Form
    {
        private Thread _xThread;
        private Thread _yThread;

        private Primitive_Position _lastPosition;

        private readonly GonioTimer _xTimer;
        private readonly GonioTimer _yTimer;

        private readonly IPositionWorker _positionWorker;

        public Form_MainForm()
        {
            InitializeComponent();
            RuntimeContext.Init();

            _xTimer = new GonioTimer(OnXTimerTick, 1000);
            _yTimer = new GonioTimer(OnYTimerTick, 1000);
            _positionWorker = PositionWorker.GetInstance();

            _lastPosition = _positionWorker.GetPosition();
        }

        private void OnXTimerTick(object sender, EventArgs e)
        {
            var currentPosition = _positionWorker.GetPosition();
            var diff = Math.Abs(_lastPosition.X - currentPosition.X);

            textBoxSpeedSec.Text = diff.ToString();
            textBoxSpeedMinute.Text = (diff * 60).ToString();
            textBoxTime.Text = ToTimeString(175 * 2 / diff);

            _lastPosition = currentPosition;
        }

        private void OnYTimerTick(object sender, EventArgs e)
        {
            var currentPosition = _positionWorker.GetPosition();
            var diff = Math.Abs(_lastPosition.Y - currentPosition.Y);

            textBoxSpeedSec.Text = diff.ToString();
            textBoxSpeedMinute.Text = (diff * 60).ToString();
            textBoxTime.Text = ToTimeString(175 * 2 / diff);

            _lastPosition = currentPosition;
        }

        private void buttonExit_Click(object sender, EventArgs e) => Close();

        private void buttonStartX_Click(object sender, EventArgs e)
        {
            buttonStartX.Enabled = false;
            buttonStartY.Enabled = false;
            buttonStop.Enabled = true;

            buttonStartX.BackColor = Color.Green;

            _xThread = new Thread(ThreadWorkerX);
            _xThread.IsBackground = true;
            _xThread.Start();

            _xTimer.Start();
        }

        private void buttonStartY_Click(object sender, EventArgs e)
        {
            buttonStartX.Enabled = false;
            buttonStartY.Enabled = false;
            buttonStop.Enabled = true;

            buttonStartY.BackColor = Color.Green;

            _yThread = new Thread(ThreadWorkerY);
            _yThread.IsBackground = true;
            _yThread.Start();
                        
            _yTimer.Start();
        }

        private void ThreadWorkerX()
        {
            while (true)
            {
                var currentPosition = _positionWorker.GetPosition();
                var targetPosition = new Primitive_Position(GetTargetPosition(currentPosition.X), currentPosition.Y);

                _positionWorker.SetPosition(targetPosition);
            }
        }

        private void ThreadWorkerY()
        {
            while (true)
            {
                var currentPosition = _positionWorker.GetPosition();
                var targetPosition = new Primitive_Position(currentPosition.X, GetTargetPosition(currentPosition.Y));

                _positionWorker.SetPosition(targetPosition);
            }
        }

        private string ToTimeString(double val)
        {
            var hrs = (int)Math.Floor(val / 3600);
            var min = (int)Math.Floor((val - hrs * 3600) / 60);
            var sec = (int)Math.Floor(val - hrs * 3600 - min * 60);

            return $"{Pad(hrs)}:{Pad(min)}:{Pad(sec)}";

            string Pad(int num) => num.ToString().PadLeft(2, '0');
        }

        private double GetTargetPosition(double current)
        {
            if (current <= 175)
                return -175;

            if (current >= 175)
                return -175;

            return current < 0 ? -175 : 175;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!(_xThread is null))
                _xThread.Abort();

            if (!(_yThread is null))
                _yThread.Abort();

            _xTimer.Stop();
            _yTimer.Stop();

            buttonStartX.Enabled = true;
            buttonStartY.Enabled = true;
            buttonStop.Enabled = false;

            buttonStartX.BackColor = DefaultBackColor;
            buttonStartY.BackColor = DefaultBackColor;
        }
    }
}
