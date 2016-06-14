using System.Drawing;
using System.Windows.Forms;
namespace _51Racer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.bodyRightPaenl = new System.Windows.Forms.Panel();
            this.bodyRgihtFooterPanel = new System.Windows.Forms.Panel();
            this.iosDevicesPanel = new System.Windows.Forms.Panel();
            this.noDevicesPaenl = new System.Windows.Forms.Panel();
            this.promptLabel = new System.Windows.Forms.Label();
            this.androidDevicesPanel = new System.Windows.Forms.Panel();
            this.bodyRgihtHeaderPanel = new System.Windows.Forms.Panel();
            this.packageComboBox = new System.Windows.Forms.ComboBox();
            this.autoInstallLabel = new System.Windows.Forms.Label();
            this.iosApplicationPanel = new System.Windows.Forms.Panel();
            this.androidAppLcationPanel = new System.Windows.Forms.Panel();
            this.appPackPanel = new System.Windows.Forms.Panel();
            this.bg_bottom = new System.Windows.Forms.PictureBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.bg_main = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.autoInstallImageButton = new _51Racer.ImageButton();
            this.appImageListPanel2 = new _51Racer.AppImageListPanel();
            this.iosdsfImageButton = new _51Racer.ImageButton();
            this.ioszjImageButton = new _51Racer.ImageButton();
            this.imageButton1 = new _51Racer.ImageButton();
            this.appImageListPanel1 = new _51Racer.AppImageListPanel();
            this.iosAppLicationButton = new _51Racer.BackImageButton();
            this.androidAppLicationButton = new _51Racer.BackImageButton();
            this.minImageButton = new _51Racer.ImageButton();
            this.closeImageButton = new _51Racer.ImageButton();
            this.bodyPanel.SuspendLayout();
            this.bodyRightPaenl.SuspendLayout();
            this.bodyRgihtFooterPanel.SuspendLayout();
            this.noDevicesPaenl.SuspendLayout();
            this.bodyRgihtHeaderPanel.SuspendLayout();
            this.iosApplicationPanel.SuspendLayout();
            this.androidAppLcationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bg_bottom)).BeginInit();
            this.bg_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bg_main)).BeginInit();
            this.bg_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.Black;
            this.bodyPanel.BackgroundImage = global::_51Racer.Properties.Resources.bg_body;
            this.bodyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bodyPanel.Controls.Add(this.bodyRightPaenl);
            this.bodyPanel.Controls.Add(this.iosApplicationPanel);
            this.bodyPanel.Controls.Add(this.androidAppLcationPanel);
            this.bodyPanel.Location = new System.Drawing.Point(0, 103);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(970, 545);
            this.bodyPanel.TabIndex = 2;
            // 
            // bodyRightPaenl
            // 
            this.bodyRightPaenl.BackColor = System.Drawing.Color.Transparent;
            this.bodyRightPaenl.Controls.Add(this.bodyRgihtFooterPanel);
            this.bodyRightPaenl.Controls.Add(this.bodyRgihtHeaderPanel);
            this.bodyRightPaenl.Location = new System.Drawing.Point(652, 0);
            this.bodyRightPaenl.Name = "bodyRightPaenl";
            this.bodyRightPaenl.Size = new System.Drawing.Size(318, 545);
            this.bodyRightPaenl.TabIndex = 4;
            // 
            // bodyRgihtFooterPanel
            // 
            this.bodyRgihtFooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.bodyRgihtFooterPanel.Controls.Add(this.iosDevicesPanel);
            this.bodyRgihtFooterPanel.Controls.Add(this.noDevicesPaenl);
            this.bodyRgihtFooterPanel.Controls.Add(this.androidDevicesPanel);
            this.bodyRgihtFooterPanel.Location = new System.Drawing.Point(0, 32);
            this.bodyRgihtFooterPanel.Name = "bodyRgihtFooterPanel";
            this.bodyRgihtFooterPanel.Size = new System.Drawing.Size(318, 513);
            this.bodyRgihtFooterPanel.TabIndex = 1;
            // 
            // iosDevicesPanel
            // 
            this.iosDevicesPanel.Location = new System.Drawing.Point(0, 0);
            this.iosDevicesPanel.Name = "iosDevicesPanel";
            this.iosDevicesPanel.Size = new System.Drawing.Size(318, 513);
            this.iosDevicesPanel.TabIndex = 1;
            this.iosDevicesPanel.Visible = false;
            // 
            // noDevicesPaenl
            // 
            this.noDevicesPaenl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.noDevicesPaenl.BackgroundImage = global::_51Racer.Properties.Resources.linkphone;
            this.noDevicesPaenl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.noDevicesPaenl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noDevicesPaenl.Controls.Add(this.promptLabel);
            this.noDevicesPaenl.Location = new System.Drawing.Point(0, 0);
            this.noDevicesPaenl.Name = "noDevicesPaenl";
            this.noDevicesPaenl.Size = new System.Drawing.Size(318, 513);
            this.noDevicesPaenl.TabIndex = 2;
            // 
            // promptLabel
            // 
            this.promptLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.promptLabel.Location = new System.Drawing.Point(28, 309);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(270, 179);
            this.promptLabel.TabIndex = 0;
            this.promptLabel.Text = "第一步：打开手机USB调试模式\r\n\r\n\r\n第二步：用USB数据线链接上手机\r\n\r\n\r\n第三步：安装应用赚取佣金\r\n\r\n\r\n最后感谢您对51快手的支持，如有链接不上" +
    "的手机请给我们反馈，谢谢。";
            // 
            // androidDevicesPanel
            // 
            this.androidDevicesPanel.Location = new System.Drawing.Point(0, 0);
            this.androidDevicesPanel.Name = "androidDevicesPanel";
            this.androidDevicesPanel.Size = new System.Drawing.Size(318, 513);
            this.androidDevicesPanel.TabIndex = 2;
            // 
            // bodyRgihtHeaderPanel
            // 
            this.bodyRgihtHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(239)))));
            this.bodyRgihtHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bodyRgihtHeaderPanel.Controls.Add(this.packageComboBox);
            this.bodyRgihtHeaderPanel.Controls.Add(this.autoInstallLabel);
            this.bodyRgihtHeaderPanel.Controls.Add(this.autoInstallImageButton);
            this.bodyRgihtHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyRgihtHeaderPanel.Name = "bodyRgihtHeaderPanel";
            this.bodyRgihtHeaderPanel.Size = new System.Drawing.Size(318, 32);
            this.bodyRgihtHeaderPanel.TabIndex = 0;
            // 
            // packageComboBox
            // 
            this.packageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.packageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.packageComboBox.FormattingEnabled = true;
            this.packageComboBox.Location = new System.Drawing.Point(217, 4);
            this.packageComboBox.Name = "packageComboBox";
            this.packageComboBox.Size = new System.Drawing.Size(87, 20);
            this.packageComboBox.TabIndex = 2;
            // 
            // autoInstallLabel
            // 
            this.autoInstallLabel.AutoSize = true;
            this.autoInstallLabel.Location = new System.Drawing.Point(74, 8);
            this.autoInstallLabel.Name = "autoInstallLabel";
            this.autoInstallLabel.Size = new System.Drawing.Size(137, 12);
            this.autoInstallLabel.TabIndex = 1;
            this.autoInstallLabel.Text = "连接上手机自动安装套餐";
            // 
            // iosApplicationPanel
            // 
            this.iosApplicationPanel.BackColor = System.Drawing.Color.Transparent;
            this.iosApplicationPanel.BackgroundImage = global::_51Racer.Properties.Resources.bg_body;
            this.iosApplicationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iosApplicationPanel.Controls.Add(this.appImageListPanel2);
            this.iosApplicationPanel.Controls.Add(this.iosdsfImageButton);
            this.iosApplicationPanel.Controls.Add(this.ioszjImageButton);
            this.iosApplicationPanel.Location = new System.Drawing.Point(0, 0);
            this.iosApplicationPanel.Name = "iosApplicationPanel";
            this.iosApplicationPanel.Size = new System.Drawing.Size(652, 545);
            this.iosApplicationPanel.TabIndex = 3;
            this.iosApplicationPanel.Visible = false;
            // 
            // androidAppLcationPanel
            // 
            this.androidAppLcationPanel.BackColor = System.Drawing.Color.Transparent;
            this.androidAppLcationPanel.BackgroundImage = global::_51Racer.Properties.Resources.bg_body;
            this.androidAppLcationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.androidAppLcationPanel.Controls.Add(this.appPackPanel);
            this.androidAppLcationPanel.Controls.Add(this.imageButton1);
            this.androidAppLcationPanel.Controls.Add(this.appImageListPanel1);
            this.androidAppLcationPanel.Location = new System.Drawing.Point(0, 0);
            this.androidAppLcationPanel.Name = "androidAppLcationPanel";
            this.androidAppLcationPanel.Size = new System.Drawing.Size(652, 545);
            this.androidAppLcationPanel.TabIndex = 3;
            // 
            // appPackPanel
            // 
            this.appPackPanel.AutoScroll = true;
            this.appPackPanel.Location = new System.Drawing.Point(88, 0);
            this.appPackPanel.Name = "appPackPanel";
            this.appPackPanel.Size = new System.Drawing.Size(558, 93);
            this.appPackPanel.TabIndex = 2;
            this.appPackPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.appPackPanel_Scroll);
            // 
            // bg_bottom
            // 
            this.bg_bottom.Controls.Add(this.linkLabel3);
            this.bg_bottom.Controls.Add(this.linkLabel2);
            this.bg_bottom.Controls.Add(this.linkLabel1);
            this.bg_bottom.Controls.Add(this.versionLabel);
            this.bg_bottom.Image = global::_51Racer.Properties.Resources.bg_bottom;
            this.bg_bottom.Location = new System.Drawing.Point(0, 648);
            this.bg_bottom.Name = "bg_bottom";
            this.bg_bottom.Size = new System.Drawing.Size(970, 31);
            this.bg_bottom.TabIndex = 1;
            this.bg_bottom.TabStop = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(153)))), ((int)(((byte)(219)))));
            this.linkLabel3.Location = new System.Drawing.Point(888, 10);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(71, 12);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "系统通知(0)";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(153)))), ((int)(((byte)(219)))));
            this.linkLabel2.Location = new System.Drawing.Point(217, 10);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "刷新";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(153)))), ((int)(((byte)(219)))));
            this.linkLabel1.Location = new System.Drawing.Point(152, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "检查更新";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Location = new System.Drawing.Point(8, 10);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(107, 12);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "当前版本：1.0.0.0";
            // 
            // bg_main
            // 
            this.bg_main.Controls.Add(this.iosAppLicationButton);
            this.bg_main.Controls.Add(this.androidAppLicationButton);
            this.bg_main.Controls.Add(this.minImageButton);
            this.bg_main.Controls.Add(this.closeImageButton);
            this.bg_main.Controls.Add(this.logo);
            this.bg_main.Image = global::_51Racer.Properties.Resources.bg_header;
            this.bg_main.Location = new System.Drawing.Point(0, 0);
            this.bg_main.Name = "bg_main";
            this.bg_main.Size = new System.Drawing.Size(970, 103);
            this.bg_main.TabIndex = 0;
            this.bg_main.TabStop = false;
            this.bg_main.Paint += new System.Windows.Forms.PaintEventHandler(this.bg_main_Paint);
            this.bg_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bg_main_MouseDown);
            this.bg_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bg_main_MouseMove);
            this.bg_main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bg_main_MouseUp);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = global::_51Racer.Properties.Resources.logo;
            this.logo.Location = new System.Drawing.Point(380, 10);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(32, 27);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // autoInstallImageButton
            // 
            this.autoInstallImageButton.BackColor = System.Drawing.Color.Transparent;
            this.autoInstallImageButton.ButtonImage = global::_51Racer.Properties.Resources.switchbuttonclose;
            this.autoInstallImageButton.Location = new System.Drawing.Point(6, 4);
            this.autoInstallImageButton.Name = "autoInstallImageButton";
            this.autoInstallImageButton.Selected = false;
            this.autoInstallImageButton.Size = new System.Drawing.Size(60, 20);
            this.autoInstallImageButton.TabIndex = 0;
            this.autoInstallImageButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.autoInstallImageButton_MouseUp);
            // 
            // appImageListPanel2
            // 
            this.appImageListPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.appImageListPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appImageListPanel2.Location = new System.Drawing.Point(0, 40);
            this.appImageListPanel2.Name = "appImageListPanel2";
            this.appImageListPanel2.Size = new System.Drawing.Size(650, 503);
            this.appImageListPanel2.TabIndex = 2;
            // 
            // iosdsfImageButton
            // 
            this.iosdsfImageButton.BackColor = System.Drawing.Color.Transparent;
            this.iosdsfImageButton.ButtonImage = global::_51Racer.Properties.Resources.devicechange2;
            this.iosdsfImageButton.Location = new System.Drawing.Point(179, 9);
            this.iosdsfImageButton.Name = "iosdsfImageButton";
            this.iosdsfImageButton.Selected = false;
            this.iosdsfImageButton.Size = new System.Drawing.Size(95, 25);
            this.iosdsfImageButton.TabIndex = 1;
            this.iosdsfImageButton.Click += new System.EventHandler(this.iosdsfImageButton_Click);
            // 
            // ioszjImageButton
            // 
            this.ioszjImageButton.BackColor = System.Drawing.Color.Transparent;
            this.ioszjImageButton.ButtonImage = global::_51Racer.Properties.Resources.devicechange1;
            this.ioszjImageButton.Location = new System.Drawing.Point(302, 9);
            this.ioszjImageButton.Name = "ioszjImageButton";
            this.ioszjImageButton.Selected = true;
            this.ioszjImageButton.Size = new System.Drawing.Size(95, 25);
            this.ioszjImageButton.TabIndex = 0;
            this.ioszjImageButton.Click += new System.EventHandler(this.ioszjImageButton_Click);
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageButton1.ButtonImage = global::_51Racer.Properties.Resources.btn_tc;
            this.imageButton1.Location = new System.Drawing.Point(12, 9);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Selected = false;
            this.imageButton1.Size = new System.Drawing.Size(70, 70);
            this.imageButton1.TabIndex = 1;
            this.imageButton1.Click += new System.EventHandler(this.imageButton1_Click);
            // 
            // appImageListPanel1
            // 
            this.appImageListPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.appImageListPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appImageListPanel1.Location = new System.Drawing.Point(0, 95);
            this.appImageListPanel1.Name = "appImageListPanel1";
            this.appImageListPanel1.Size = new System.Drawing.Size(652, 450);
            this.appImageListPanel1.TabIndex = 0;
            // 
            // iosAppLicationButton
            // 
            this.iosAppLicationButton.BackColor = System.Drawing.Color.Transparent;
            this.iosAppLicationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iosAppLicationButton.BackImage = global::_51Racer.Properties.Resources.bg_effect;
            this.iosAppLicationButton.Image = global::_51Racer.Properties.Resources.ios;
            this.iosAppLicationButton.Location = new System.Drawing.Point(12, 25);
            this.iosAppLicationButton.Name = "iosAppLicationButton";
            this.iosAppLicationButton.Selected = false;
            this.iosAppLicationButton.Size = new System.Drawing.Size(70, 70);
            this.iosAppLicationButton.TabIndex = 1;
            this.iosAppLicationButton.Title = "苹果应用";
            this.iosAppLicationButton.Click += new System.EventHandler(this.iosAppLicationButton_Click);
            // 
            // androidAppLicationButton
            // 
            this.androidAppLicationButton.BackColor = System.Drawing.Color.Transparent;
            this.androidAppLicationButton.BackgroundImage = global::_51Racer.Properties.Resources.bg_effect;
            this.androidAppLicationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.androidAppLicationButton.BackImage = global::_51Racer.Properties.Resources.bg_effect;
            this.androidAppLicationButton.Image = global::_51Racer.Properties.Resources.android;
            this.androidAppLicationButton.Location = new System.Drawing.Point(101, 25);
            this.androidAppLicationButton.Name = "androidAppLicationButton";
            this.androidAppLicationButton.Selected = true;
            this.androidAppLicationButton.Size = new System.Drawing.Size(70, 70);
            this.androidAppLicationButton.TabIndex = 3;
            this.androidAppLicationButton.Title = "安卓应用";
            this.androidAppLicationButton.Click += new System.EventHandler(this.androidAppLicationButton_Click);
            // 
            // minImageButton
            // 
            this.minImageButton.BackColor = System.Drawing.Color.Transparent;
            this.minImageButton.ButtonImage = ((System.Drawing.Bitmap)(resources.GetObject("minImageButton.ButtonImage")));
            this.minImageButton.Location = new System.Drawing.Point(897, 0);
            this.minImageButton.Name = "minImageButton";
            this.minImageButton.Selected = false;
            this.minImageButton.Size = new System.Drawing.Size(31, 22);
            this.minImageButton.TabIndex = 1;
            this.minImageButton.Click += new System.EventHandler(this.minImageButton_Click);
            // 
            // closeImageButton
            // 
            this.closeImageButton.BackColor = System.Drawing.Color.Transparent;
            this.closeImageButton.ButtonImage = global::_51Racer.Properties.Resources.close;
            this.closeImageButton.Location = new System.Drawing.Point(928, 0);
            this.closeImageButton.Name = "closeImageButton";
            this.closeImageButton.Selected = false;
            this.closeImageButton.Size = new System.Drawing.Size(44, 22);
            this.closeImageButton.TabIndex = 1;
            this.closeImageButton.Click += new System.EventHandler(this.closeImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(970, 679);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.bg_bottom);
            this.Controls.Add(this.bg_main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "51快手";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(3)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bodyPanel.ResumeLayout(false);
            this.bodyRightPaenl.ResumeLayout(false);
            this.bodyRgihtFooterPanel.ResumeLayout(false);
            this.noDevicesPaenl.ResumeLayout(false);
            this.bodyRgihtHeaderPanel.ResumeLayout(false);
            this.bodyRgihtHeaderPanel.PerformLayout();
            this.iosApplicationPanel.ResumeLayout(false);
            this.androidAppLcationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bg_bottom)).EndInit();
            this.bg_bottom.ResumeLayout(false);
            this.bg_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bg_main)).EndInit();
            this.bg_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        private void bg_main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(this.Text, titleFont, Brushes.White, 420, 10);
            g.DrawString("欢迎你：" + userInfo.NickName, SystemFonts.IconTitleFont, Brushes.White, 700, 5);
        }



        private void bg_main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CanMove = true;
                startPoint = e.Location;
            }
        }

        private void bg_main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                CanMove = false;
            }
        }

        private void bg_main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (CanMove)
                {
                    int x = e.X - startPoint.X;
                    int y = e.Y - startPoint.Y;
                    this.Location = new Point(Location.X + x, Location.Y + y);
                }
            }
        }

       

        #endregion

        Font titleFont = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Point startPoint = new Point(0, 0);
        bool CanMove = false;

        private System.Windows.Forms.PictureBox bg_main;
        private System.Windows.Forms.PictureBox logo;
        private BackImageButton iosAppLicationButton;
        private BackImageButton androidAppLicationButton;
        private ImageButton minImageButton;
        private ImageButton closeImageButton;
        private PictureBox bg_bottom;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private Label versionLabel;
        private Panel bodyPanel;
        private Panel iosApplicationPanel;
        private Panel bodyRightPaenl;
        private Panel bodyRgihtHeaderPanel;
        private Panel bodyRgihtFooterPanel;
        private ImageButton autoInstallImageButton;
        private Label autoInstallLabel;
        private ComboBox packageComboBox;
        private ImageButton ioszjImageButton;
        private ImageButton iosdsfImageButton;
        private Panel androidAppLcationPanel;
        private AppImageListPanel appImageListPanel1;
        private ImageButton imageButton1;
        private Panel appPackPanel;
        private AppImageListPanel appImageListPanel2;
        private Panel androidDevicesPanel;
        private Panel noDevicesPaenl;
        private Label promptLabel;
        private Panel iosDevicesPanel;


    }
}

