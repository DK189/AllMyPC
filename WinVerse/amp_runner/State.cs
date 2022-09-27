using amp_runner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace amp_runner
{
    internal static class State
    {
        public static MyPC ThisMyPC { get; } = new MyPC()
        {
            Identity = $"WIN_OS${new ManagementObject("Win32_OperatingSystem=@")["SerialNumber"]}",
            Name = $"{Environment.MachineName} ({Environment.OSVersion})",
        };
    }
}
