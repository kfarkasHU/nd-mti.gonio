using System;
using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using ND.MTI.Service.Worker;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    public partial class Form_VirtualZeroForm : Form
    {
        private readonly IPositionWorker _positionWorker;
        private readonly Timer _timer;

        public Form_VirtualZeroForm()
        {
            _positionWorker = PositionWorker.GetInstance();

            InitializeComponent();

            KeyPreview = true;
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);

            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Enabled = true;
        }

        private void Form_VirtualZeroForm_Load(object sender, EventArgs e) => SetModelInternal(_positionWorker.GetPosition());

        private void ButtonClose_Click(object sender, EventArgs e) => Close();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            RuntimeContext.VirtualZeroPosition = _positionWorker.GetPosition();

            Close();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Q:
                    DecrementXInternal();
                    break;

                case Keys.W:
                    IncrementXInternal();
                    break;

                case Keys.A:
                    DecrementYInternal();
                    break;

                case Keys.S:
                    IncrementYInternal();
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                case Keys.W:
                    StopXInternal();
                    break;

                case Keys.A:
                case Keys.S:
                    StopYInternal();
                    break;
            }
        }

        private void ButtonIncrementX_Click(object sender, EventArgs e) => IncrementXInternal();

        private void ButtonIncrementY_Click(object sender, EventArgs e) => IncrementYInternal();

        private void ButtonDecrementX_Click(object sender, EventArgs e) => DecrementXInternal();

        private void ButtonDecrementY_Click(object sender, EventArgs e) => DecrementYInternal();

        private void ButtonStopX_Click(object sender, EventArgs e) => StopXInternal();

        private void ButtonStopY_Click(object sender, EventArgs e) => StopYInternal();

        private void IncrementXInternal() => _positionWorker.IncrementX();

        private void IncrementYInternal() => _positionWorker.IncrementY();

        private void DecrementXInternal() => _positionWorker.DecrementX();

        private void DecrementYInternal() => _positionWorker.DecrementY();

        private void StopXInternal() => _positionWorker.StopX();

        private void StopYInternal() => _positionWorker.StopY();

        private void OnTimerTick(object sender, EventArgs e) => SetModelInternal();

        private void SetModelInternal() => SetModelInternal(_positionWorker.GetPosition());

        private void SetModelInternal(Primitive_Position position)
        {
            textBoxXCoord.Text = position.X.ToString();
            textBoxYCoord.Text = position.Y.ToString();
        }
    }
}
