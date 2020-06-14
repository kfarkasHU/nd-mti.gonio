﻿using Ninject.Modules;
using ND.MTI.Gonio.Service;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.ServiceInterface.Worker;
using ND.MTI.Gonio.Service.Worker.Pokeys;
using ND.MTI.Gonio.Service.Worker.SSIWorker;
using ND.MTI.Gonio.Service.Helper;

namespace ND.MTI.Gonio.DependencyResolver
{
    public class DependencyResolverCore : NinjectModule
    {
        public override void Load()
        {
            Bind<IExcelExportService>().To<ExcelExportService>();
            Bind<IExcelFactory>().To<ExcelFactory>();
            Bind<IGonioWorker>().To<GonioWorker>().InSingletonScope();
            Bind<IIOWorker>().To<IOWorker>();
            Bind<IMeasurementService>().To<MeasurementService>();
            Bind<IPokeys57UWorker>().To<Pokeys57UWorker>();
            Bind<IPositionWorker>().To<PositionWorker>().InSingletonScope();
            Bind<ISSIWorker>().To<SSIWorker>();

            Bind<MeasurementServiceHelper>().ToSelf().InSingletonScope();
            Bind<MainFormHelper>().ToSelf().InSingletonScope();

            Bind<Form_MainForm>.ToSelf();
        }
    }
}
