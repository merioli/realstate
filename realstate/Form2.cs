using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

//class OvalPictureBox : PictureBox
//{
//    public OvalPictureBox()
//    {
//        this.BackColor = Color.DarkGray;
//    }
//    protected override void OnResize(EventArgs e)
//    {
//        base.OnResize(e);
//        using (var gp = new GraphicsPath())
//        {
//            gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
//            this.Region = new Region(gp);
//        }
//    }
//}
namespace realstate
{
    public partial class Form2 : RadForm
    {

       
        protected override void OnLoad(EventArgs e)
        {
           
            whishon.Visible = false;
            try
            {
                int port = 8001;
                if (GlobalVariable.port != 0)
                {
                    port = GlobalVariable.port;
                }

                try
                {
                    //TcpClient tcpclnt2 = new TcpClient();
                    //bool mybo = true;
                    //while (mybo)
                    //{
                    //    try
                    //    {
                    //        tcpclnt2.Connect("192.168.0.1", port);
                    //        mybo = false;
                    //    }
                    //    catch (Exception)
                    //    {


                    //    }
                    //}


                    //Stream stm3 = tcpclnt2.GetStream();
                    //string srtnum = "3" + form2id;

                    //ASCIIEncoding asen2 = new ASCIIEncoding();
                    //byte[] ba2 = asen2.GetBytes(srtnum);
                    //stm3.Write(ba2, 0, ba2.Length);


                    //string json2 = "";
                    //const int blockSiz2e = 500000;
                    //byte[] buffer2 = new byte[blockSiz2e];
                    //int bytesRead2;

                    //stm.Read(buffer, 0, buffer.Length);
                    //MemoryStream ms = new MemoryStream(buffer);
                    //Image returnImage = Image.FromStream(ms);

                    //while ((bytesRead2 = stm3.Read(buffer2, 0, buffer2.Length)) > 0)
                    //{
                    //    for (int i = 0; i < bytesRead2; i++)
                    //    {
                    //        json2 = json2 + Convert.ToChar(buffer2[i]);
                    //    }
                    //}
                    RootObject log = JsonConvert.DeserializeObject<RootObject>(GlobalVariable.result);
                    mydatum = log.result.data.Where(x => x.server_id == form2id).ToList().First();
                    //MemoryStream ms = new MemoryStream(buffer2);
                    //Image returnImage = Image.FromStream(ms);
                    //imglist.Add(returnImage);
                    // tcpclnt2.Close();
                }
                catch (Exception imgerro)
                {

                    throw;
                }


            }

            catch (Exception f)
            {
                Console.Write("Error..... " + f.StackTrace);
            }

            title.Text = mydatum.title;
            phone.Text = mydatum.phone;
            origin.Text = mydatum.source;
            areaOfad.Text = mydatum.area;

            string text = mydatum.desc.Replace("\n\r\n", " ");
            text = text.Replace("\r\n", " ");
            desc.Text = text;
            metraj.Text = mydatum.metraj.ToString();
            vadie.Text = mydatum.vadie.ToString();
            room.Text = mydatum.room.ToString();
            cat.Text = mydatum.cat;
            area.Text = mydatum.area;
            ejare.Text = mydatum.ejare.ToString();
            kind.Text = mydatum.kind;
            year.Text = mydatum.build_year;
            tabdil.Text = mydatum.tabdil;
            total.Text = mydatum.total;
            if (mydatum.countryside)
            {
                hoome.Text = "بله";
            }
            else
            {
                hoome.Text = "خیر";
            }
            base.OnLoad(e);

            Task.Factory.StartNew
            (
             () =>
             {
                 Thread.Sleep(500);
                 Invoke(new Action(MyCode));
             }
            );
        }
        private void MyCode()
        {
            if (GlobalVariable.showimage)
            {
                try
                {
                    int port = 8001;
                    if (GlobalVariable.port != 0)
                    {
                        port = GlobalVariable.port;
                    }


                    Console.WriteLine("Connecting.....");

                    TcpClient tcpclnt = new TcpClient();
                    tcpclnt.Connect("192.168.0.1", port);
                    // use the ipaddress as in the server program
                    Console.WriteLine("Connected by port" + GlobalVariable.port.ToString());
                    //Console.Write("Enter the string to be transmitted : ");

                    //String str = Console.ReadLine();
                    string str = "1" + form2id;
                    Stream stm2 = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    Console.WriteLine("Transmitting.....");

                    stm2.Write(ba, 0, ba.Length);


                    string json = "";
                    const int blockSize = 1024;
                    byte[] buffer = new byte[blockSize];
                    int bytesRead;

                    //stm.Read(buffer, 0, buffer.Length);
                    //MemoryStream ms = new MemoryStream(buffer);
                    //Image returnImage = Image.FromStream(ms);
                    List<int> list = new List<int>();
                    while ((bytesRead = stm2.Read(buffer, 0, buffer.Length)) > 0)
                    {

                    }
                    int num = buffer[0];
                    tcpclnt.Close();
                    int j = 0;
                    if (num != 0)
                    {
                        for (int i = 1; i <= num; i++)
                        {

                            try
                            {
                                TcpClient tcpclnt2 = new TcpClient();
                                bool mybo = true;
                                while (mybo)
                                {
                                    try
                                    {
                                        tcpclnt2.Connect("192.168.0.1", port);
                                        mybo = false;
                                    }
                                    catch (Exception)
                                    {


                                    }
                                }


                                Stream stm3 = tcpclnt2.GetStream();
                                string srtnum = "2" + i.ToString();

                                ASCIIEncoding asen2 = new ASCIIEncoding();
                                byte[] ba2 = asen2.GetBytes(srtnum);
                                stm3.Write(ba2, 0, ba2.Length);


                                string json2 = "";
                                const int blockSiz2e = 500000;
                                byte[] buffer2 = new byte[blockSiz2e];
                                int bytesRead2;

                                //stm.Read(buffer, 0, buffer.Length);
                                //MemoryStream ms = new MemoryStream(buffer);
                                //Image returnImage = Image.FromStream(ms);

                                while ((bytesRead2 = stm3.Read(buffer2, 0, buffer2.Length)) > 0)
                                {

                                }
                                MemoryStream ms = new MemoryStream(buffer2);
                                Image returnImage = Image.FromStream(ms);


                                tcpclnt2.Close();
                                switch (j)
                                {
                                    case 0:
                                        pictureBox1.Image = returnImage;
                                        break;
                                    case 1:
                                        pictureBox2.Image = returnImage;
                                        break;
                                    case 2:
                                        pictureBox3.Image = returnImage;
                                        break;
                                    case 3:
                                        pictureBox4.Image = returnImage;
                                        break;
                                    case 4:
                                        pictureBox5.Image = returnImage;
                                        break;
                                    case 5:
                                        pictureBox6.Image = returnImage;
                                        break;
                                    case 6:
                                        pictureBox7.Image = returnImage;
                                        break;


                                }
                                j++;
                            }
                            catch (Exception imgerro)
                            {

                                throw;
                            }
                        }
                    }
                    else
                    {

                    }







                }

                catch (Exception f)
                {
                    Console.Write("Error..... " + f.StackTrace);
                }

            }
        }
        // your "special" method to handle "load is complete" event

        string form2id = "";
        List<System.Drawing.Image> imglist = new List<System.Drawing.Image>();
        Datum mydatum = new Datum();
        //string metraj = "";
        //string cat = "";
        //string room = "";
        //string title = "";
        //string desc = "";

        public Form2(string id)
        {
            GlobalVariable.showimage = true;
            form2id = id;
            InitializeComponent();
            // radRotator1.BeginRotate += new BeginRotateEventHandler(radRotator1_BeginRotate);
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

           


        }


        void radRotator1_BeginRotate(object sender, BeginRotateEventArgs e)
        {
            // radLabelElement1.Text = String.Format("Rotating from item {0} to {1}", e.From, e.To);
        }



        private void Form2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void wishoff_Click(object sender, EventArgs e)
        {
            wishoff.Visible = false;
            whishon.Visible = true;
        }

        private void whishon_Click(object sender, EventArgs e)
        {
            wishoff.Visible = true;
            whishon.Visible = false;
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox oPictureBox = (PictureBox)sender;
            // if name is unique value for the data, you can get the name 
            // and find that name in your datatable
            if (oPictureBox.Image != null)
            {
                Form5 form5 = new Form5(oPictureBox.Image);
                form5.Show();
            }

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }













    }
}
