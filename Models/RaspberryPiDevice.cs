using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORMULARIOCENSI.Models
{
    
    public class RaspberryPiDevice
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
    }

    public class RaspberryPiConfig
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
    }

}