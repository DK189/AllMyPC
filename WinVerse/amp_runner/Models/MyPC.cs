using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amp_runner.Models
{
    internal class MyPC
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        
        public MyPC NearTop { get; set; }
        public MyPC NearBottom { get; set; }
        public MyPC NearLeft { get; set; }
        public MyPC NearRight { get; set; }

        public override string ToString()
        {
            return $"{Name} <{Identity}>";
        }
    }
}
