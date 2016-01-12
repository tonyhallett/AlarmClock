using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegistrationBuilder builder = new RegistrationBuilder();
            builder.ForType<AlarmClockViewPresenter>().Export<AlarmClockViewPresenter>();
            builder.ForType<AlarmViewPresenter>().Export<IAlarmViewPresenter>();
            builder.ForType<ClockViewPresenter>().Export<IClockViewPresenter>();
            builder.ForType<DefaultAlarmClockView>().Export<IAlarmClockView>();
            builder.ForType<DefaultAlarmView>().Export<IAlarmView>();
            builder.ForType<DefaultClockView>().Export<IClockView>();
            //was the default singletons
            var initialAlarmClockTime = DateTime.Now;
            var initialAlarmClockTimeContractName = "InitialClockTime";

            builder.ForType<InitializedAlarmClock>().SelectConstructor(ctors => ctors.First(), (p, ib) =>
            {
                ib.AsContractName(initialAlarmClockTimeContractName);
            });
            builder.ForType<InitializedAlarmClock>().Export<IAlarmClock>();
            //var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //DirectoryCatalog dirCatalog = new DirectoryCatalog(directory,builder);
            AssemblyCatalog assCatalog = new AssemblyCatalog(Assembly.GetEntryAssembly(),builder);
            CompositionContainer container = new CompositionContainer(assCatalog);
            container.ComposeExportedValue<DateTime>(initialAlarmClockTimeContractName, initialAlarmClockTime);

            
            var alarmClockView = container.GetExportedValue<AlarmClockViewPresenter>().View as Form;
            Application.Run(alarmClockView);
        }
    }
}
