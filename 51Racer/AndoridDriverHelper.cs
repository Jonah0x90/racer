using System;
using Microsoft.Win32;

namespace _51Racer
{
    class AndoridDriverHelper
    {
        private string exePath;
        private string driverPath;

        private static object lockHelper = new object();
        private static AndoridDriverHelper instance = null;

        private AndoridDriverHelper(string exePath,string driverPath )
        {
            this.exePath = exePath;
            this.driverPath = driverPath;
        }
        public static AndoridDriverHelper GetShareInstance()
        {
            if (instance.exePath != null && instance.driverPath != null)
                return GetShareInstance(instance.exePath, instance.driverPath);
            else
                return null;
        }

        public static AndoridDriverHelper GetShareInstance(string exePath, string driverPath)
        {
            lock (lockHelper)
            {
                if (instance == null)
                    instance = new AndoridDriverHelper(exePath, driverPath);
                return instance;
            }
        }

        public void InstallDriver(string device)
        {
            string command = "\"" + device + "\" \"" + driverPath + "\"";
            EnvInfo.StartProcess(exePath, command);
        }

        public void EmunAndInstallDriver()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB");
            foreach (string i in key.GetSubKeyNames())
            {
                RegistryKey key1 = key.OpenSubKey(i);
                foreach (string j in key1.GetSubKeyNames())
                {
                    RegistryKey key2 = key1.OpenSubKey(j);
                    string[] CompatibleIDs = key2.GetValue("CompatibleIDs") as string[];
                    if (CompatibleIDs != null && CompatibleIDs[0].ToLower() == @"USB\Class_FF&SubClass_42&Prot_01".ToLower())
                    {
                        if (((int)key2.GetValue("ConfigFlags", -1)) != 0)
                        {
                            string[] device = key2.GetValue("HardwareID") as string[];
                            if (device != null)
                            {
                                InstallDriver(device[0]);
                            }
                        }
                    }
                }
            }
        }
    }
}
