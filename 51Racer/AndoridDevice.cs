using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _51Racer
{
    public enum AndoridDeviceStatus
    {
        OnLine,
        OffLine
    }

    public class AndoridDevice
    {
        private string deivceId;
        public string DeivceId
        {
            get { return deivceId; }
        }

        private AndoridDeviceStatus status;
        public AndoridDeviceStatus Status
        {
            get { return status; }
        }

        public AndoridDevice(string deviceId, AndoridDeviceStatus status)
        {
            this.deivceId = deviceId;
            this.status = status;
        }
    }
}
