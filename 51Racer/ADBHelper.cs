using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _51Racer
{
    class ADBHelper
    {
        private string exePath;
        private static object lockHelper = new object();
        private static ADBHelper instance = null;
        private ADBHelper(string exePath)
        {
            this.exePath = exePath;
            EnvInfo.StartProcess(exePath, "fork-server server", false);
        }

        public static ADBHelper GetShareInstance()
        {
            if (instance.exePath != null)
                return GetShareInstance(instance.exePath);
            else
                return null;
        }

        public static ADBHelper GetShareInstance(string exePath)
        {
            lock (lockHelper)
            {
                if (instance == null)
                    instance = new ADBHelper(exePath);
                return instance;
            }
        }

        private string SendMessage(string message)
        {
            return EnvInfo.StartProcess(exePath, message);
        }

        private string SendMessage(string device, string message)
        {
            message = "-s "+device+" "+message;
            return SendMessage(message);
        }

        public AndoridDevice[] ListDevice()
        {
            string temp = SendMessage("devices");
            int index = temp.IndexOf("List of devices attached");
            List<AndoridDevice> list = new List<AndoridDevice>();
            if (index >= 0)
            {
                temp = temp.Substring(index);
                temp = temp.Replace("List of devices attached \r\n", "");
                temp = temp.Replace("\r\n\r\n", "");
                temp = temp.Replace("\r\n", "|");
                if (temp.Length > 6)
                {
                    foreach (string i in temp.Split('|'))
                    {
                        string[] temp2 = i.Split('\t');
                        AndoridDeviceStatus status = AndoridDeviceStatus.OnLine;
                        if (temp2.Length > 1 && temp2[1] != "device")
                            status = AndoridDeviceStatus.OffLine;
                        list.Add(new AndoridDevice(temp2[0], status));
                    }
                }
            }
            return list.ToArray();
        }

        public bool InstallApp(string device, string appPath)
        {
            string message = "install -r \"" + appPath + "\"";
            if (SendMessage(device, message).ToLower().IndexOf("success") >= 0)
                return true;
            return false;
        }
    }
}
