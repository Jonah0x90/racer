using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Text;


namespace _51Racer
{
    static class EnvInfo
    {
        static WebClient webClient = new WebClient();

        static EnvInfo()
        {
            webClient.Encoding = Encoding.UTF8;
        }
        public static int GetSystemBits()
        {
            try
            {
                string addressWidth = String.Empty;
                ConnectionOptions mConnOption = new ConnectionOptions();
                ManagementScope mMs = new ManagementScope(@"\\localhost", mConnOption);
                ObjectQuery mQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(mMs, mQuery);
                ManagementObjectCollection mObjectCollection = mSearcher.Get();
                foreach (ManagementObject mObject in mObjectCollection)
                {
                    addressWidth = mObject["AddressWidth"].ToString();
                }
                return Int32.Parse(addressWidth);
            }
            catch
            {
                return 86;
            }
        }

        public static string GetTempPath()
        {
            return Environment.GetEnvironmentVariable("TEMP") + "\\";
        }

        public static string GetStartPath()
        {
            return new FileInfo(Process.GetCurrentProcess().MainModule.FileName).DirectoryName;
        }

        public static string StartProcess(string exePath, string command,bool waitForExit = true)
        {
            Process p = new Process();
            p.StartInfo.FileName = exePath;
            p.StartInfo.Arguments = command;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            if (waitForExit)
            {
                p.WaitForExit(1000 * 60 * 5);
            }
            string ret = "";
            if (p.HasExited)
            {
                ret = p.StandardOutput.ReadToEnd();
            }
            else
            {
                p.Kill();
            }
            p.Close();
            return ret;
        }

        public static string HttpGet(string url)
        {
            return webClient.DownloadString(url);
        }

    }
}
