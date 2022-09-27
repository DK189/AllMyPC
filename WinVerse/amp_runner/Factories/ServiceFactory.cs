using amp_runner.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace amp_runner.Factories
{
    public class ServiceFactory
    {
        private ServiceBase[] Services;

        internal ConfigRunner Config { get; }
        internal UdpRunner Udp { get; }

        public ServiceFactory ()
        {
            Services = new ServiceBase[]
            {
                Config = new ConfigRunner(),
                Udp = new UdpRunner(),
            };
        }

        public void Start ()
        {
            ServiceBase.Run(Services);
        }

        public void Debug(params string[] args)
        {
            MethodInfo SB_OnStart = typeof(ServiceBase).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo SB_OnStop = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);

            var servRuns = new ServiceBase[] {
                new Runners.ConfigRunner(),
                new Runners.UdpRunner(),
            };
            servRuns.Select(
                s => Task.Run(new Action(() =>
                {
                    SB_OnStart.Invoke(s, new object[] { args });
                }))
            );
            Console.Write("DEBUG-MODE: Press any key to stop debugging . . . ");
            Console.ReadKey();
            servRuns.Select(
                s => Task.Run(new Action(() =>
                {
                    SB_OnStop.Invoke(s, new object[] {  });
                }))
            );
        }

    }
}
namespace amp_runner
{
    partial class Context
    {
        public static Factories.ServiceFactory Service { get; } = new Factories.ServiceFactory();
    }
}
