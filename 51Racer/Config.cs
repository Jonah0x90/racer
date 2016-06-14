using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _51Racer
{
    class Config
    {
        private Hashtable config;
        private static object lockHelper = new object();   
        private static Config instance = null;
        private Config()
        {
            config = new Hashtable();
            string startPath = EnvInfo.GetStartPath();
            int OSBits = EnvInfo.GetSystemBits();
            if (OSBits == 32)
                OSBits = 86;
            config.Add("InstExePath", startPath + "\\tools\\DriverInst_x" + OSBits + ".exe");
            config.Add("DriverPath", startPath + "\\tools\\driver\\google_x" + OSBits + "_inf\\android_winusb.inf");
            config.Add("ADBExePath", startPath + "\\tools\\51adb.exe");
            config.Add("AppDirPath", startPath + "\\app\\");
            config.Add("Wav", startPath + "\\tools\\wav.wav");
            config.Add("HOST", "http://10.2.26.88/");
            config.Add("API", "http://10.2.26.88/api/a/type/xml/interface/");
        }

        public static Config GetShareInstance()
        {
            lock (lockHelper)
            {
                if (instance == null)
                    instance = new Config();
                return instance;
            }
        }

        public string GetValue(string key)
        {
            string[] temps = key.Split('\\');
            object temp = "";
            int index = 0;
            do
            {
                temp = config[temps[index++]];
            }
            while (temp.GetType() != typeof(string) && index < temps.Length);
            return (string)temp;
        }
    }
}
