using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _51Racer
{
    struct InstallAppArg
    {
        public AndoridDevice device;
        public string app;
    }
    class AndoridDeviceManger
    {
        private ADBHelper adbHelper;
        private AndoridDriverHelper driverHelper;

        private static object lockHelper = new object();
        private static AndoridDeviceManger instance = null;

        public delegate void ListDeviceChange(AndoridDevice[] devices);
        public event ListDeviceChange OnListDeviceChangeComplete;

        public delegate void InstallAppComplete(InstallAppArg installAppArg, string aid, bool success);
        public event InstallAppComplete OnInstallAppComplete;


        private AndoridDeviceManger()
        {
            Config config = Config.GetShareInstance();
            driverHelper = AndoridDriverHelper.GetShareInstance(config.GetValue("InstExePath"), config.GetValue("DriverPath"));
            adbHelper = ADBHelper.GetShareInstance(config.GetValue("ADBExePath"));
        }

        public static AndoridDeviceManger GetShareInstance()
        {
            lock (lockHelper)
            {
                if (instance == null)
                    instance = new AndoridDeviceManger();
                return instance;
            }
        }

        public void ListDevice(bool needCheckDriver = false)
        {
            new Thread(new ParameterizedThreadStart(_ListDevice)).Start(needCheckDriver);
        }

        private void _ListDevice(object needCheckDriver)
        {
            if (OnListDeviceChangeComplete != null)
            {

                if ((bool)needCheckDriver)
                {
                    driverHelper.EmunAndInstallDriver();
                }
                lock (this)
                {
                    Thread.Sleep(1000);
                    AndoridDevice[] devices = adbHelper.ListDevice();
                    Control target = OnListDeviceChangeComplete.Target as Control;
                    if (target != null)
                    {

                        target.Invoke(OnListDeviceChangeComplete, new object[] { devices });

                    }
                    else
                    {
                        OnListDeviceChangeComplete(devices);
                    }
                }
            }
        }

        public void InstallApp(AndoridDevice device, string[] apps)
        {
            foreach (string i in apps)
            {
                InstallApp(device, i);
            }
        }

        public void InstallApp(AndoridDevice device, string app)
        {
            InstallAppArg temp = new InstallAppArg();
            temp.device = device;
            temp.app = app;
            new Thread(new ParameterizedThreadStart(_InstallApp)).Start(temp);
        }

        private void _InstallApp(object argv)
        {
            try
            {
                InstallAppArg temp = (InstallAppArg)argv;
                FileInfo f = new FileInfo(temp.app);
                string aid = f.Name;
                aid = aid.Substring(0, aid.IndexOf("."));
                bool ret = adbHelper.InstallApp(temp.device.DeivceId, temp.app);
                if (OnInstallAppComplete != null)
                {
                    Control target = OnInstallAppComplete.Target as Control;
                    if (target != null)
                    {
                        lock (this)
                        {
                            target.Invoke(OnInstallAppComplete, new object[] { temp, aid, ret });
                        }
                    }
                    else
                    {
                        OnInstallAppComplete(temp, aid, ret);
                    }
                }
            }
            catch { }
        }

    }
}
