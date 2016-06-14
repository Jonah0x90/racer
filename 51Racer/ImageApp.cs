using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace _51Racer
{
    struct DownSing { public ImageApp app; public bool IsImage;}
    public partial class ImageApp : UserControl
    {
        bool appDowned = false;
        WebClient webClient = new WebClient();
        public string appId,appName, appPath, appUrlPath, appImgPath, appImgUrlPath;

        public ImageApp(string appId,string appName, string appPath, string appUrlPath, string appImgPath, string appImgUrlPath)
        {
            InitializeComponent();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            label1.Text = appName;
            if (File.Exists(appPath))
            {
                appDowned = true;
                button1.Enabled = false;
                button1.Text = "已下载";
            }
            if (!File.Exists(appImgPath))
            {
                if (File.Exists(appImgPath + ".temp"))
                    File.Delete(appImgPath + ".temp");
                DownSing ds = new DownSing();
                ds.app = this;
                ds.IsImage = true;
                webClient.DownloadFileAsync(new Uri(appImgUrlPath), appImgPath + ".temp", ds);
            }
            else
            {
                pictureBox1.Image = new Bitmap(appImgPath);
            }
            this.appId = appId;
            this.appName = appName;
            this.appPath = appPath;
            this.appUrlPath = appUrlPath;
            this.appImgPath = appImgPath;
            this.appImgUrlPath = appImgUrlPath;
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownSing ds = (DownSing)e.UserState;
            if (ds.app == this)
            {
                progressBar1.Value = e.ProgressPercentage;
                if (progressBar1.Value == 100)
                {
                    try
                    {
                        if (ds.IsImage)
                        {
                            if (File.Exists(appImgPath + ".temp"))
                            {
                                File.Move(appImgPath + ".temp", appImgPath);
                                pictureBox1.Image = new Bitmap(appImgPath);
                            }
                        }
                        else
                        {
                            if (File.Exists(appPath + ".temp"))
                            {
                                File.Move(appPath + ".temp", appPath);
                                appDowned = true;
                                button1.Text = "已下载";
                                button1.Visible = true;
                                progressBar1.Visible = false;
                            }
                        }
                    }
                    catch { }
                }
            }
        }


        public string AppPath
        {
            get { return appPath; }
        }
        public bool CanInstall
        {
            get
            {
                return appDowned && pictureBox2.Visible;
            }
        }

        public bool Selected
        {
            get
            {
                return  pictureBox2.Visible;
            }
            set
            {
                pictureBox2.Visible = value;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (!appDowned)
            {
                button1.BackColor = Color.FromArgb(6, 169, 254);
                button1.ForeColor = Color.White;
                button1.Text = "下载";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownApp();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.Enabled && !appDowned)
            {
                button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
                button1.ForeColor = Color.Black;
                button1.Text = "求下载";
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = !pictureBox2.Visible;
            AppImageListPanel panel = this.Parent as AppImageListPanel;
            if (panel != null)
                panel.Check();
        }

        public void DownApp()
        {
            if (button1.Enabled)
            {
                if (!appDowned)
                {
                    button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
                    button1.Enabled = false;
                    button1.Text = "下载中";
                    button1.Visible = false;
                    progressBar1.Visible = true;
                    if (File.Exists(appPath + ".temp"))
                        File.Delete(appPath + ".temp");
                    DownSing ds = new DownSing();
                    ds.app = this;
                    ds.IsImage = false;
                    webClient.DownloadFileAsync(new Uri(appUrlPath), appPath + ".temp", ds);
                }
            }
        }

    }
}
