using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.IO;

namespace _51Racer
{
    struct IOSInstallArg
    {
        public IntPtr device;
        public string[] apps;
    }
    class IOSDeviceManger
    {
        private static object lockHelper = new object();
        private static IOSDeviceManger instance = null;
        private AbCallBack haveDeviceChange;
        public delegate void InstallAppComplete(IntPtr devices, string aid, bool Success);
        public event InstallAppComplete OnInstallAppComplete;

        public delegate void IOSDeviceChange(IOSDevice[] devices);
        public event IOSDeviceChange OnIOSDeviceChangeComplete;


        List<IOSDevice> devices = new List<IOSDevice>();
        private IOSDeviceManger()
        {
            haveDeviceChange = new AbCallBack(HaveDeviceChange);
        }


        public bool CheckItunes()
        {
            string addpath1 = "", addpath2 = "";
            if (EnvInfo.GetSystemBits() == 64)
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Apple Inc.\Apple Mobile Device Support");
                if (reg == null) return false;
                object temp = reg.GetValue("InstallDir");
                if (temp == null) return false;
                addpath1 = temp.ToString();
                RegistryKey reg2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Apple Inc.\Apple Application Support");
                if (reg2 == null) return false;
                temp = reg2.GetValue("InstallDir");
                if (temp == null) return false;
                addpath2 = temp.ToString();
            }
            else
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Apple Inc.\Apple Mobile Device Support");
                if (reg == null) return false;
                object temp = reg.GetValue("InstallDir");
                if (temp == null) return false;
                addpath1 = temp.ToString();
                RegistryKey reg2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Apple Inc.\Apple Application Support");
                if (reg2 == null) return false;
                temp = reg2.GetValue("InstallDir");
                if (temp == null) return false;
                addpath2 = temp.ToString();
            }
            Environment.SetEnvironmentVariable("path", Environment.GetEnvironmentVariable("path") + ";" + addpath1 + ";" + addpath2);
            return true;
        }

        public bool CheckVCRuntime()
        {
            return File.Exists(Environment.SystemDirectory + "\\msvcr120.dll");
        }

        public void InstallVCRuntime()
        {
            string fileName = EnvInfo.GetStartPath() + "\\tools\\vcredist_x86.exe";
            EnvInfo.StartProcess(fileName, "");
        }

        public bool StatrListenDeviceChange()
        {
            bool ret = false;
            try
            {
                ret = AMDeviceManger.StartListen(haveDeviceChange);
            }
            catch { }
            return ret;
        }

        void HaveDeviceChange(ref AbListenCbk info)
        {
            if (info.Status == IOSDeviceStatus.Connected)
            {
                try
                {
                    bool bo = true;
                    foreach (IOSDevice i in devices)
                    {
                        if (i.Device == info.device)
                        {
                            bo = false;
                        }
                    }
                    if (bo)
                    {
                        string typeid = AMDeviceManger.getIOSName(Marshal.PtrToStringAnsi(AMDeviceManger.GetDeivceType(info.device)));
                        string uuid = Marshal.PtrToStringAnsi(AMDeviceManger.GetDeivceUUID(info.device));
                        devices.Add(new IOSDevice(info.device, typeid, uuid));
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    foreach (IOSDevice i in devices)
                    {
                        if (i.Device == info.device)
                        {
                            devices.Remove(i);
                            break;
                        }
                    }
                }
                catch { }
            }
            if (OnIOSDeviceChangeComplete != null)
            {
                Control target = OnIOSDeviceChangeComplete.Target as Control;
                if (target != null)
                {

                    target.Invoke(OnIOSDeviceChangeComplete, new object[] { devices.ToArray() });

                }
                else
                {
                    OnIOSDeviceChangeComplete(devices.ToArray());
                }
            }
        }




        public void InstallApp(IntPtr device, string[] apps)
        {
            IOSInstallArg temp = new IOSInstallArg();
            temp.device = device;
            temp.apps = apps;
            new Thread(new ParameterizedThreadStart(_InstallApp)).Start(temp);
        }

        public void InstallApp(IntPtr device, string app)
        {
            InstallApp(device, new string[] { app });
        }

        private void _InstallApp(object argv)
        {

            int ret = 0;
            IOSInstallArg arg = (IOSInstallArg)argv;
            foreach (string i in arg.apps)
            {
                FileInfo f = new FileInfo(i);
                string aid = f.Name;
                aid = aid.Substring(0, aid.IndexOf("."));
                try
                {
                    ret = AMDeviceManger.InstallApp(arg.device, i);
                }
                catch { }
                if (OnInstallAppComplete != null)
                {
                    Control target = OnInstallAppComplete.Target as Control;
                    if (target != null && arg.device != null)
                    {
                        lock (target)
                        {
                            target.Invoke(OnInstallAppComplete, new object[] { arg.device, aid, ret == 0 ? true : false });
                        }
                    }
                    else
                    {
                        OnInstallAppComplete(arg.device, aid, ret == 0 ? true : false);
                    }
                }
            }
        }

        public static IOSDeviceManger GetShareInstance()
        {
            lock (lockHelper)
            {
                if (instance == null)
                    instance = new IOSDeviceManger();
                return instance;
            }
        }
    }
}
