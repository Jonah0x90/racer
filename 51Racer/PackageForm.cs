using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _51Racer
{
    public partial class PackageForm : Form
    {
        List<ImageApp> allApps;
        public List<ImageApp> apps;
        public string PackName;
        public PackageForm(string PackName, List<ImageApp> apps, bool IsSystem)
        {
            InitializeComponent();
            this.PackName = PackName;
            this.apps = apps;
            this.allApps = API.GetAppList(1);
            textBox1.Text = PackName;
            foreach (ImageApp i in apps)
            {
                listBox2.Items.Add(i.appName);
                for (int j = 0; j < allApps.Count; j++)
                {
                    if (allApps[j].appId == i.appId)
                    {
                        allApps.RemoveAt(j);
                        j--;
                    }
                }
            }
            foreach (ImageApp i in allApps)
            {
                listBox1.Items.Add(i.appName);
            }

            listBox1.Enabled = !IsSystem;
            listBox2.Enabled = !IsSystem;
            textBox1.Enabled = !IsSystem;
            button3.Enabled = !IsSystem;
            button4.Enabled = !IsSystem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                PackName = textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入套餐名");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0 && listBox2.SelectedIndex < listBox2.Items.Count)
            {
                allApps.Add(apps[listBox2.SelectedIndex]);
                listBox1.Items.Add(apps[listBox2.SelectedIndex].appName);
                apps.RemoveAt(listBox2.SelectedIndex);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox1.Items.Count)
            {
                apps.Add(allApps[listBox1.SelectedIndex]);
                listBox2.Items.Add(allApps[listBox1.SelectedIndex].appName);
                allApps.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
    }
}
