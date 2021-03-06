﻿using ND.MTI.Gonio.Model.Enum;

namespace ND.MTI.Gonio.Model
{
    public class Primitive_Userconfig
    {
        public double Offset { get; set; }
        public bool ResetToZero { get; set; }
        public bool ResetToVZero { get; set; }
        public bool UseCorrection { get; set; }
        public double Amplification { get; set; }

        public string ExternalRouteFilePath { get; set; }
        public int MeasuresInSamePosition { get; set; }
        public bool SendNotificationOnError { get; set; }
        public bool SendNotificationOnComplete { get; set; }
        public MathOperation MeasuresInSamePositionOperation { get; set; }
    }
}
