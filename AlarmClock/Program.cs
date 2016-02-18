using Interfaces;
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
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                RegistrationBuilder builder = new RegistrationBuilder();
                builder.ForType<AlarmClockViewPresenter>().Export<AlarmClockViewPresenter>();
                builder.ForType<AlarmViewPresenter>().Export<IAlarmViewPresenter>();
                builder.ForType<ClockViewPresenter>().Export<IClockViewPresenter>();
                builder.ForTypesDerivedFrom<IAlarmClockView>().Export<IAlarmClockView>();
                builder.ForTypesDerivedFrom<IAlarmView>().Export<IAlarmView>();
                builder.ForTypesDerivedFrom<IClockView>().Export<IClockView>();
                //was the default singletons
                var initialAlarmClockTime = DateTime.Now;
                var initialAlarmClockTimeContractName = "InitialClockTime";

                builder.ForType<InitializedAlarmClock>().SelectConstructor(ctors => ctors.First(), (p, ib) =>
                {
                    ib.AsContractName(initialAlarmClockTimeContractName);
                });
                builder.ForType<InitializedAlarmClock>().Export<IAlarmClock>();
                var loc = Assembly.GetExecutingAssembly().Location;
                AssemblyCatalog defaultOrReplacement = null;
                DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(loc));
                var isDebug = false;
#if DEBUG
                isDebug = true;
#endif
                defaultOrReplacement = new AssemblyCatalog(typeof(DefaultViews.DefaultClockView).Assembly, builder);
                if (!isDebug)
                {
                    foreach (var f in dir.GetFiles())
                    {
                        bool match = f.Name == "ReplacementParts.dll";
                        if (match)
                        {
                            defaultOrReplacement = new AssemblyCatalog(f.FullName, builder);
                            break;
                        }
                    }

                }


                var directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                //DirectoryCatalog dirCatalog = new DirectoryCatalog(directory,builder);

                AssemblyCatalog exeCatalog = new AssemblyCatalog(typeof(DefaultAlarmClockView).Assembly, builder);


                AggregateCatalog aggCatalog = new AggregateCatalog(exeCatalog, defaultOrReplacement);
                CompositionContainer container = new CompositionContainer(aggCatalog);
                container.ComposeExportedValue<DateTime>(initialAlarmClockTimeContractName, initialAlarmClockTime);


                var alarmClockView = container.GetExportedValue<AlarmClockViewPresenter>().View as Form;
                Application.Run(alarmClockView);
            }catch(Exception exc)
            {
                var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var sw = File.CreateText(dirName+Path.DirectorySeparatorChar + "Houston.txt");
                sw.WriteLine(exc.Message);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
