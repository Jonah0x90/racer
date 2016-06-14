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
    public partial class AppPackage : UserControl
    {
        private List<ImageApp> apps;
        public List<ImageApp> Apps
        {
            get { return apps; }
            set { apps = value; }
        }

        public string PackName
        {
            get { return label1.Text; }
        }

        private bool IsSystem;
        Panel andoridDevicesPanel;


        public AppPackage(string packName, List<ImageApp> apps, Panel andoridDevicesPanel, bool IsSystem = true)
        {
            InitializeComponent();
            this.label1.Text = packName;
            this.apps = apps;
            this.IsSystem = IsSystem;
            this.andoridDevicesPanel = andoridDevicesPanel;
            button3.Enabled = !IsSystem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PackageForm form = new PackageForm(PackName,apps,IsSystem);
            if (form.ShowDialog() == DialogResult.OK)
            {
                apps = form.apps;
                label1.Text = form.PackName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control i in andoridDevicesPanel.Controls)
            {
                Devices dev = i as Devices;
                if (dev != null)
                {
                    dev.InstallAndoridApp(apps.ToArray());
                }
            }
        }

 
    }
}
