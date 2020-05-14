#if DEBUG

using System;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.Service.Worker
{
    internal static class WorkerHelper
    {
        private const int ENCODER_MIN = 0;
        private const int ENCODER_MAX = 8191;

        private const int LOWSPEED = 1;
        private const int HIGHSPEED = 3;
        
        internal static int CurrentX { get; private set; }
        internal static int CurrentY { get; private set; }

        private static GonioTimer _timer;
        private static int _changeX = 0;
        private static int _changeY = 0;

        internal static void Init()
        {
            CurrentX = (ENCODER_MIN + ENCODER_MAX) / 2; 
            CurrentY = (ENCODER_MIN + ENCODER_MAX) / 2;

            _timer = new GonioTimer(OnTimerTick, 20);
            _timer.Start();
        }

        internal static void IncrementX_Slow() => ChangeX(LOWSPEED * -1);
        internal static void IncrementY_Slow() => ChangeY(LOWSPEED * 1);
        internal static void IncrementX_Fast() => ChangeX(HIGHSPEED * -1);
        internal static void IncrementY_Fast() => ChangeY(HIGHSPEED * 1);

        internal static void DecrementX_Slow() => ChangeX(LOWSPEED * 1);
        internal static void DecrementY_Slow() => ChangeY(LOWSPEED * -1);
        internal static void DecrementX_Fast() => ChangeX(HIGHSPEED * 1);
        internal static void DecrementY_Fast() => ChangeY(HIGHSPEED * -1);

        internal static void StopX() => ChangeX(0);
        internal static void StopY() => ChangeY(0);

        internal static void ZeroX() => CurrentX = ENCODER_MIN;
        internal static void ZeroY() => CurrentY = ENCODER_MIN;

        private static void ChangeX(int diff) => _changeX = diff;
        private static void ChangeY(int diff) => _changeY = diff;


        private static void OnTimerTick(object sender, EventArgs e)
        {
            CurrentX += _changeX;

            if (CurrentX > ENCODER_MAX)
                CurrentX = ENCODER_MIN;

            CurrentY += _changeY;

            if (CurrentY > ENCODER_MAX)
                CurrentY = ENCODER_MIN;
        }
    }
}

#endif
