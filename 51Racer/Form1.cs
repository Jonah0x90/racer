using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _51Racer
{
    public struct UserInfo
    {
        public string ID;
        public string NickName;
    }
    public partial class Form1 : Form
    {
        UserInfo userInfo;
        public Form1(UserInfo userInfo)
        {
            InitializeComponent();
           this.userInfo = userInfo;
        }

        void Form1_OnIOSDeviceChangeComplete(IOSDevice[] devices)
        {
            if (iosDevicesPanel.Controls.Count != devices.Length)
            {
                iosDevicesPanel.Controls.Clear();
                if (devices.Length > 0)
                {
                    int i = 0;
                    foreach (IOSDevice j in devices)
                    {
                        Devices dev = new Devices(j, appImageListPanel2,userInfo.ID,userInfo.NickName);
                        dev.Location = new Point(6, 100 * i++);
                        iosDevicesPanel.Controls.Add(dev);
                        if (autoInstall[autoInstallIndex])
                        {
                            dev.InstallIOSApp(appImageListPanel2.getSelcetApps());
                        }
                    } 
                    if (autoInstallIndex == 0)
                    {
                        noDevicesPaenl.Visible = false;
                        iosDevicesPanel.Visible = true;
                    }
                }
            }
        }

        void Form1_OnListDeviceChangeComplete(AndoridDevice[] devices)
        {
            if (androidDevicesPanel.Controls.Count != devices.Length)
            {
                androidDevicesPanel.Controls.Clear();
                if (devices.Length > 0)
                {
                    int i = 0;
                    foreach (AndoridDevice j in devices)
                    {
                        Devices dev = new Devices(j, appImageListPanel1, userInfo.ID,userInfo.NickName);
                        dev.Location = new Point(6, 100 * i++);
                        androidDevicesPanel.Controls.Add(dev);
                    }
                    if (autoInstallIndex == 1)
                    {
                        noDevicesPaenl.Visible = false;
                        androidDevicesPanel.Visible = true;
                    }
                }
                else
                {
                    if (autoInstallIndex == 1)
                    {
                        noDevicesPaenl.Visible = true;
                    }
                }
            }
        }

        bool[] autoInstall = new bool[] { false, false };
        int autoInstallIndex = 1;
        private void iosAppLicationButton_Click(object sender, EventArgs e)
        {
            this.iosAppLicationButton.Selected = true;
            this.androidAppLicationButton.Selected = false;
            this.promptLabel.Visible = false;
            this.autoInstallLabel.Text = "连接上手机自动安装选中应用";
            this.packageComboBox.Visible = false;
            autoInstallIndex = 0;
            DrawAutoInstallImage();
            iosApplicationPanel.Visible = true;
            androidAppLcationPanel.Visible = false;
            androidDevicesPanel.Visible = false;
            if (iosDevicesPanel.Controls.Count > 0)
            {
                iosDevicesPanel.Visible = true;
                noDevicesPaenl.Visible = false;
            }
            else
                noDevicesPaenl.Visible = true;
        }

        private void androidAppLicationButton_Click(object sender, EventArgs e)
        {
            this.iosAppLicationButton.Selected = false;
            this.androidAppLicationButton.Selected = true;
            this.promptLabel.Visible = true;
            this.autoInstallLabel.Text = "连接上手机自动安装套餐";
            this.packageComboBox.Visible = true;
            autoInstallIndex = 1;
            DrawAutoInstallImage();
            iosApplicationPanel.Visible = false;
            androidAppLcationPanel.Visible = true;
            iosDevicesPanel.Visible = false;
            if (androidDevicesPanel.Controls.Count > 0)
            {
                androidDevicesPanel.Visible = true;
                noDevicesPaenl.Visible = false;
            }
            else
                noDevicesPaenl.Visible = true;
        }

        private void DrawAutoInstallImage()
        {
            if (autoInstall[autoInstallIndex])
            {
                autoInstallImageButton.ButtonImage = Properties.Resources.switchbuttonopen;
            }
            else
            {
                autoInstallImageButton.ButtonImage = Properties.Resources.switchbuttonclose;
            }
            this.autoInstallImageButton.Invalidate();
        }

        private void minImageButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeImageButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void autoInstallImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            autoInstall[autoInstallIndex] = !autoInstall[autoInstallIndex];
            DrawAutoInstallImage();
        }

        private void ioszjImageButton_Click(object sender, EventArgs e)
        {
            ioszjImageButton.Selected = true;
            iosdsfImageButton.Selected = false;
        }

        private void iosdsfImageButton_Click(object sender, EventArgs e)
        {
            ioszjImageButton.Selected = false;
            iosdsfImageButton.Selected = true;
        }

        private void GetAppList(int type = 1)
        {
            AppImageListPanel panel = type == 1 ? appImageListPanel1 : appImageListPanel2;
            List<ImageApp> apps = API.GetAppList(type);
            panel.Clear();
            foreach (ImageApp i in apps)
            {
                panel.Add(i);
            }
        }

        private void GetPackList()
        {
            List<AppPackage> packs = API.GetPackList(this.androidDevicesPanel);
            appPackPanel.Controls.Clear();
            packageComboBox.Items.Clear();
            packageComboBox.Tag = packs;
            foreach (AppPackage i in packs)
            {
                appPackPanel.Controls.Add(i);
                packageComboBox.Items.Add(i.PackName);
            }
            if (packageComboBox.Items.Count > 0)
                packageComboBox.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (autoInstallIndex == 0)
                GetAppList(2);
            else
                GetAppList(1);
        }

        private void appPackPanel_Scroll(object sender, ScrollEventArgs e)
        {
                appPackPanel.Invalidate();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            PackageForm form = new PackageForm("", new List<ImageApp>(), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                int i = appPackPanel.Controls.Count;
                AppPackage pack = new AppPackage(form.PackName, form.apps,this.androidDevicesPanel,false);
                pack.Location = new Point(10 + i * 180, 9);
                appPackPanel.Controls.Add(pack);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                if (m.WParam.ToInt32() == 0x7)
                    AndoridDeviceManger.GetShareInstance().ListDevice(false);
                if(m.WParam.ToInt32()==0x8000)
                    AndoridDeviceManger.GetShareInstance().ListDevice(true);
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAppList(1);
            GetAppList(2);
            GetPackList();
            AndoridDeviceManger.GetShareInstance().OnListDeviceChangeComplete += Form1_OnListDeviceChangeComplete;
            AndoridDeviceManger.GetShareInstance().ListDevice(true);
            if (IOSDeviceManger.GetShareInstance().CheckItunes())
            {
                if (!IOSDeviceManger.GetShareInstance().CheckVCRuntime())
                {
                    MessageBox.Show("VC++运行库未安装，请安装");
                    IOSDeviceManger.GetShareInstance().InstallVCRuntime();
                }

                if (IOSDeviceManger.GetShareInstance().StatrListenDeviceChange())
                {
                    IOSDeviceManger.GetShareInstance().OnIOSDeviceChangeComplete += Form1_OnIOSDeviceChangeComplete;
                }
                else
                {
                    MessageBox.Show("苹果监听服务启动失败");

                }

            }
            else
            {
                MessageBox.Show("iTunes未安装，请安装iTunes,安装完后请重启程序");
                Process.Start("explorer", "http://www.apple.com/cn/itunes/download/");
            }
        }
    }
}