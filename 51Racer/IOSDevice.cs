using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _51Racer
{
    public class IOSDevice
    {
        public string Name;
        public string UUID;
        public IntPtr Device;

        public IOSDevice(IntPtr device,string name,string uuid)
        {
            Name = name;
            UUID = uuid;
            Device = device;
        }
    }
}
