using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_MainModel
    {
        public Complex_MainModel() => ResetInternal();

        public Primitive_Position Start { get; set; }
        public Primitive_Position End { get; set; }
        public double? StepX { get; set; }
        public double? StepY { get; set; }
        public bool IsXAuto { get; set; }
        public bool IsYAuto { get; set; }
        public Action OnFinishedCallback { get; set; }

        public void Reset() => ResetInternal();

        public void Validate() => ValidateInternal();

        private void ResetInternal()
        {
            Start = new Primitive_Position(0, 0);
            End = new Primitive_Position(0, 0);
            StepX = null;
            StepY = null;
            IsXAuto = false;
            IsYAuto = false;
        }

        private void ValidateInternal()
        {
            if (IsXAuto && !(StepX > 0))
                throw new Exception("Step X must be grater than zero.");

            if (IsYAuto && !(StepY > 0))
                throw new Exception("Step Y must be grater than zero.");

            if (Start.X < -174)
                throw new Exception("Start X must be greater than -174");

            if (Start.Y < -174)
                throw new Exception("Start Y must be greater than -174");

            if (Start.X > 174)
                throw new Exception("Start X must be smaller than 174");

            if (Start.Y > 174)
                throw new Exception("Start Y must be smaller than 174");

            if (End.X < -174)
                throw new Exception("End X must be greater than -174");

            if (End.Y < -174)
                throw new Exception("End Y must be greater than -174");

            if (End.X > 174)
                throw new Exception("End X must be smaller than 174");

            if (End.Y > 174)
                throw new Exception("End Y must be smaller than 174");
        }
    }
}
