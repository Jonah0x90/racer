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
    public partial class AppImageListPanel : UserControl
    {


        private List<ImageApp> appList = new List<ImageApp>();

        public AppImageListPanel()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.Controls.Clear();
            this.appList.Clear();
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.imageButton1);
        }

        public void Add(ImageApp app)
        {
            this.Controls.Add(app);
            this.appList.Add(app);
        }



        public void Check()
        {
            bool bo = true;
            foreach (ImageApp i in appList)
            {
                bo &= i.Selected;
            }
            checkBox1.Checked = bo;
        }

        public ImageApp[] getSelcetApps()
        {
            List<ImageApp> tempList = new List<ImageApp>();
            foreach (ImageApp i in appList)
            {
                if (i.CanInstall)
                    tempList.Add(i);
            }
            return tempList.ToArray();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            foreach (ImageApp i in appList)
            {
                i.Selected = checkBox1.Checked;
            }
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            foreach (ImageApp i in appList)
            {
                if (i.Selected)
                    i.DownApp();
            }
        }
    }
}
