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
    public partial class BackImageButton : UserControl
    {
        public BackImageButton()
        {
            InitializeComponent();
        }

        private bool selected = false;
        private Image backImage = null;

        public Image BackImage
        {
            get { return backImage; }
            set { backImage = value; }
        }


        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Title
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; DrawBackImage(); }
        }

        private void DrawBackImage()
        {
            if (selected)
            {
                BackgroundImage = backImage;
            }
            else
            {
                BackgroundImage = null;
            }
        }

        private void BackImageButton_MouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = backImage;
        }

        private void BackImageButton_MouseLeave(object sender, EventArgs e)
        {
            DrawBackImage();
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!selected)
            {
                BackgroundImage = null;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!selected)
            {
                BackgroundImage = backImage;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
    }

}
