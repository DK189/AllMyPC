using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace amp_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "-install":
                            {
                                // TODO: Installing service
                                break;
                            }
                        case "-uninstall":
                            {
                                // TODO: Uninstalling service
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please run me with argument [-install] or [-uninstall].");
                                break;
                            }
                    }
                }
#if DEBUG
                else
                {
                    // TODO: Run service in debug-mode
                    Console.WriteLine(State.ThisMyPC);
                    Context.Service.Debug();
                }
#endif
            }
            else
            {
                // TODO: Run service in service-mode
                Context.Service.Start();
            }
        }
    }
}
