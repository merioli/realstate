using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace realstate
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public static class Util
        {
            public enum Effect { Roll, Slide, Center, Blend }

            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];
                if (ctl.Visible) { flags |= 0x10000; angle += 180; }
                else
                {
                    if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                    else if (effect == Effect.Blend) throw new ArgumentException();
                }
                flags |= dirmap[(angle % 360) / 45];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok) throw new Exception("Animation failed");
                ctl.Visible = !ctl.Visible;
            }

            private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
            private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

            [DllImport("user32.dll")]
            private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
        }

        private void MenuIcon_Click(object sender, EventArgs e)
        {
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 360);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SearchPanel.PanelElement.Shape = new RoundRectShape();
            SearchPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            SearchPanel.PanelElement.PanelFill.BackColor = Color.LightGray;
            panelOfFilterArrow.PanelElement.Shape = new RoundRectShape();
            panelOfFilterArrow.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panelOfFilterArrow.PanelElement.PanelFill.BackColor = Color.LightGray;

            FilterDetailPanel.PanelElement.Shape = new RoundRectShape();
            FilterDetailPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            FilterDetailPanel.PanelElement.PanelFill.BackColor = Color.LightGray;


            FilterDetailPanel.Height = FilterPanel.Height;
            menuPanel.Width = leftTableForMenu.Width;
            leftTableForMenu.Height = LeftPanel.Height;
            menuPanel.Height = LeftPanel.Height;
            menuPanel.Hide();
            downPic.Hide();
            

        }

       

        private void menuPanel_Click(object sender, EventArgs e)
        {
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 360);
        }

        private void downPic_Click(object sender, EventArgs e)
        {
            Util.Animate(FilterDetailPanel, Util.Effect.Slide, 150, 90);
            downPic.Hide();
            upPic.Show();

        }

        private void upPic_Click(object sender, EventArgs e)
        {
            Util.Animate(FilterDetailPanel, Util.Effect.Slide, 150, 90);
            upPic.Hide();
            downPic.Show();
        }

      

       

        

       
    }
}
