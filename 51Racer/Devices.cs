using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _51Racer
{
    enum Platform
    {
        IOS,
        Android
    }

    public partial class Devices : UserControl
    {
        Platform platform;
        public AndoridDevice andoridDevice;
       public IOSDevice iosDevice;
        AppImageListPanel andoridAppImageListPanel;
        AppImageListPanel iosAppImageListPanel;
        System.Media.SoundPlayer player;
        string uid;
        string username;
        public Devices()
        {
            InitializeComponent();
            
        }

        public Devices(IOSDevice device, AppImageListPanel iosAppImageListPanel,string uid,string username)
        {
            InitializeComponent();
            this.uid = uid;
            this.username = username;
            platform = Platform.IOS;
            this.iosDevice = device;
            this.iosAppImageListPanel = iosAppImageListPanel;
            this.label1.Text = device.Name;
            label2.Text = "手机连接成功，请安装应用";
            IOSDeviceManger.GetShareInstance().OnInstallAppComplete += Devices_OnInstallAppComplete1;
            player = new System.Media.SoundPlayer(Config.GetShareInstance().GetValue("Wav"));
        }

        int successCount = 0;
        int noSuccessCount = 0;


        public Devices(AndoridDevice device, AppImageListPanel andoridAppImageListPanel, string uid, string username)
        {
            InitializeComponent();
            this.uid = uid;
            this.username = username;
            platform = Platform.Android;
            this.andoridDevice = device;
            this.andoridAppImageListPanel = andoridAppImageListPanel;
            this.label1.Text = device.DeivceId;
            AndoridDeviceManger.GetShareInstance().OnInstallAppComplete += Devices_OnInstallAppComplete;
            player = new System.Media.SoundPlayer(Config.GetShareInstance().GetValue("Wav"));
            if (device.Status == AndoridDeviceStatus.OnLine)
            {
                label2.Text = "手机连接成功，请安装应用";
            }
            else
            {
                label2.Text = "手机连接成功，但没有安装权限，请授权";
            }
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            if (platform == Platform.Android)
            {
                InstallAndoridApp(andoridAppImageListPanel.getSelcetApps());
            }
            else
            {
                InstallIOSApp(iosAppImageListPanel.getSelcetApps());
            }
        }

        public void InstallAndoridApp(ImageApp[] apps)
        {
            if (imageButton1.Enabled)
            {
                if (apps.Length > 0)
                {
                    imageButton1.Enabled = false;
                    label2.Text = "应用安装中，请稍后..";
                    progressBar1.Maximum = apps.Length;
                    progressBar1.Value = 0;
                    foreach (ImageApp i in apps)
                        AndoridDeviceManger.GetShareInstance().InstallApp(andoridDevice, i.appPath);
                }
            }
        }

        public void InstallIOSApp(ImageApp[] apps)
        {
            if (imageButton1.Enabled)
            {
                if (apps.Length > 0)
                {
                    imageButton1.Enabled = false;
                    label2.Text = "应用安装中，请稍后..";
                    progressBar1.Maximum = apps.Length;
                    progressBar1.Value = 0;
                    List<string> appList = new List<string>(); 
                    foreach (ImageApp i in apps)
                    {
                        appList.Add(i.appPath);
                    }
                    IOSDeviceManger.GetShareInstance().InstallApp(iosDevice.Device, appList.ToArray());
                }
            }
        }


        void Devices_OnInstallAppComplete(InstallAppArg installAppArg, string aid, bool success)
        {
            if (installAppArg.device.DeivceId == andoridDevice.DeivceId)
            {
                progressBar1.Value++;
                if (success) 
                {
                    API.Install(uid, username, aid,andoridDevice.DeivceId);
                    successCount++; 
                
                } else noSuccessCount++;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    imageButton1.Enabled = true;
                    label2.Text = string.Format("共安装{0}个应用,成功{1}个,失败{2}个.", successCount + noSuccessCount, successCount, noSuccessCount);
                    successCount = 0;
                    noSuccessCount = 0;
                    player.Play();
                }
            }
        }

        void Devices_OnInstallAppComplete1(IntPtr devices, string aid, bool success)
        {
            if (devices == iosDevice.Device)
            {
                progressBar1.Value++;
                if (success)
                {
                    API.Install(uid, username, aid, iosDevice.UUID);
                    successCount++;
                }
                else noSuccessCount++;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    imageButton1.Enabled = true;
                    label2.Text = string.Format("共安装{0}个应用,成功{1}个,失败{2}个.", successCount + noSuccessCount, successCount, noSuccessCount);
                    successCount = 0;
                    noSuccessCount = 0;
                    player.Play();
                }
            }
        }
    }
}
