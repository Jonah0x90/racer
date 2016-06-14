using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _51Racer
{
    class AMDeviceManger
    {
        const string dllName = "AMDeviceManger.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static bool StartListen(AbCallBack callBack);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr GetDeivceType(IntPtr device);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr GetDeivceUUID(IntPtr device);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        public extern static int InstallApp(IntPtr device, string app);

        public static string getIOSName(string type)
        {
            string ret = "iPhone";
            switch (type)
            {
                case "iPhone1,1":
                    ret = "iPhone2G";
                    break;
                case "iPhone1,2":
                    ret = "iPhone3G";
                    break;
                case "iPhone2,1":
                    ret = "iPhone3GS";
                    break;
                case "iPhone3,1":
                    ret = "iPhone4";
                    break;
                case "iPhone4,1":
                    ret = "iPhone4S";
                    break;
                case "iPhone5,1":
                    ret = "iPhone5";
                    break;
                case "iPhone5,2":
                    ret = "iPhone5";
                    break;
                case "iPhone5,3":
                    ret = "iPhone5c";
                    break;
                case "iPhone5,4":
                    ret = "iPhone5c";
                    break;
                case "iPhone6,1":
                    ret = "iPhone5s";
                    break;
                case "iPhone6,2":
                    ret = "iPhone5s";
                    break;
            }
            return ret;
        }


    }

    enum IOSDeviceStatus
    {
        Connected = 1,
        DisConnected = 2
    }

    struct AbListenCbk
    {
        public IntPtr device;
        public IOSDeviceStatus Status;
    };

    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    delegate void AbCallBack(ref AbListenCbk info);
}
