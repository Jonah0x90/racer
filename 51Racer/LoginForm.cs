using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _51Racer
{
    public partial class LoginForm : Form
    {
        string api;
        public LoginForm()
        {
            InitializeComponent();
            api = Config.GetShareInstance().GetValue("API") + "login/?username={0}&password={1}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string xmlString = EnvInfo.HttpGet(string.Format(api, userName, password));
            XmlDocument xmlDom = new XmlDocument();
            xmlDom.LoadXml(xmlString);
            XmlNode node = xmlDom.ChildNodes[1].ChildNodes[2];
            if (node.SelectSingleNode("code").InnerText != "0")
            {
                MessageBox.Show(node.SelectSingleNode("message").InnerText);
            }
            else
            {
                new Form1(new UserInfo { ID = node.SelectSingleNode("uid").InnerText, NickName = userName }).Show();
                this.Hide();
            }
        }
    }
}
