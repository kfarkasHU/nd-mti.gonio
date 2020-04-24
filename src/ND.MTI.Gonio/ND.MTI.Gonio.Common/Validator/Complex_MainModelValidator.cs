using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.Common.Validator
{
    public static class Complex_MainModelValidator
    {
        private static IGonioConfiguration _gonioConfiguration;

        public static void ValidateModel(Complex_MainModel model)
        {
            if (_gonioConfiguration is null)
                _gonioConfiguration = GonioConfiguration.GetInstance();

            if (model.IsXAuto && !(model.StepX > 0))
                throw new Exception("Step X must be grater than zero.");

            if (model.IsYAuto && !(model.StepY > 0))
                throw new Exception("Step Y must be grater than zero.");

            if (model.Start.X < _gonioConfiguration.Endpoint_XMin)
                throw new Exception($"Start X must be greater than {_gonioConfiguration.Endpoint_XMin}");

            if (model.Start.Y < _gonioConfiguration.Endpoint_YMin)
                throw new Exception($"Start Y must be greater than {_gonioConfiguration.Endpoint_YMin}");

            if (model.Start.X > _gonioConfiguration.Endpoint_XMax)
                throw new Exception($"Start X must be smaller than {_gonioConfiguration.Endpoint_XMax}");

            if (model.Start.Y > _gonioConfiguration.Endpoint_YMax)
                throw new Exception($"Start Y must be smaller than {_gonioConfiguration.Endpoint_YMax}");

            if (model.End.X < _gonioConfiguration.Endpoint_XMin)
                throw new Exception($"End X must be greater than {_gonioConfiguration.Endpoint_XMin}");

            if (model.End.Y < _gonioConfiguration.Endpoint_YMin)
                throw new Exception($"End Y must be greater than {_gonioConfiguration.Endpoint_YMin}");

            if (model.End.X > _gonioConfiguration.Endpoint_XMax)
                throw new Exception($"End X must be smaller than {_gonioConfiguration.Endpoint_XMax}");

            if (model.End.Y > _gonioConfiguration.Endpoint_YMax)
                throw new Exception($"End Y must be smaller than {_gonioConfiguration.Endpoint_YMax}");

            if (model.HoldTime < 0)
                throw new Exception("Hold time must be greater than -1");
        }
    }
}
