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
    public partial class ImageButton :UserControl
    {
        public ImageButton()
        {
            InitializeComponent();
        }

        private Bitmap buttonImage;
        private int index = 0;

        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; Draw(value ? 2 : 0); }
        }

         

        public Bitmap ButtonImage
        {
            get 
            {
                return buttonImage; 
            }
            set
            {
                buttonImage = value;
                Width = buttonImage.Width / 4;
                Height = buttonImage.Height;
                Draw(0);
            }
        }


        private void ImageButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (buttonImage != null)
            {
                Rectangle rect = new Rectangle(index * Width, 0, Width, Height);
                Bitmap bmp = buttonImage.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                rect.X = 0;
                g.DrawImage(bmp, rect);
            }
        }

        private void Draw(int index)
        {
            this.index = index;
            if (selected && index == 0)
            {
                this.index = 2;
            }
            Invalidate();
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            Draw(1);
        }

        private void ImageButton_MouseDown(object sender, MouseEventArgs e)
        {
            Draw(2);
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            Draw(0);
        }

        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            Draw(1);
        }

        private void ImageButton_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
            {
                Draw(3);
            }
        }

    }
}
