using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realstate
{
    public partial class Form5 : Form
    {
        public Form5(Image myimage)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Anchor = AnchorStyles.None;
            CenterPictureBox(pictureBox1, myimage);
        }
        private void CenterPictureBox(PictureBox picBox, Image picImage)
        {
            picBox.Image = picImage;
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }
    }
}
