using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;


namespace realstate
{
    public partial class Form2 : RadForm
    {
        
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
            form2id = id;
            InitializeComponent();
           // radRotator1.BeginRotate += new BeginRotateEventHandler(radRotator1_BeginRotate);
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 formobj = new Form1();
            try
            {

                Console.WriteLine("Connecting.....");

                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("192.168.0.1", GlobalVariable.port);
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
                                tcpclnt2.Connect("192.168.0.1", GlobalVariable.port);
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
                        imglist.Add(returnImage);
                        tcpclnt2.Close();
                    }
                    catch (Exception imgerro)
                    {

                        throw;
                    }
                }

                try
                {
                    TcpClient tcpclnt2 = new TcpClient();
                    bool mybo = true;
                    while (mybo)
                    {
                        try
                        {
                            tcpclnt2.Connect("192.168.0.1", GlobalVariable.port);
                            mybo = false;
                        }
                        catch (Exception)
                        {


                        }
                    }


                    Stream stm3 = tcpclnt2.GetStream();
                    string srtnum ="3"+ form2id;

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
                        for (int i = 0; i < bytesRead2; i++)
                        {
                            json2 = json2 + Convert.ToChar(buffer2[i]);
                        }
                    }
                    RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);
                    mydatum = log.result.data.First();
                    //MemoryStream ms = new MemoryStream(buffer2);
                    //Image returnImage = Image.FromStream(ms);
                    //imglist.Add(returnImage);
                    tcpclnt2.Close();
                }
                catch (Exception imgerro)
                {

                    throw;
                }



                //RootObject log = JsonConvert.DeserializeObject<RootObject>(json);
                //List<Datum> songsDataTableBindingSource = (from p in log.result.data
                //                                           select p).ToList();
                //this.radListView1.DataSource = songsDataTableBindingSource;
                //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
                //this.radListView1.ViewType = ListViewType.DetailsView;



            }

            catch (Exception f)
            {
                Console.Write("Error..... " + f.StackTrace);
            }
            foreach (var item in imglist){
                RadImageItem imageItem = new RadImageItem();
                imageItem.Image = item;
                radRotator1.Items.Add(imageItem);
            }
            radRotator1.Start(true);
            radRotator1.ShouldStopOnMouseOver = false;
            title.Text = mydatum.title;

            string text = mydatum.desc.Replace("\n\r\n", " ");
            desc.Text = text;
            metraj.Text = mydatum.metraj.ToString();
            vadie.Text = mydatum.vadie.ToString();
            room.Text = mydatum.room.ToString();
            cat.Text = mydatum.cat;
            area.Text = mydatum.area;
            ejare.Text = mydatum.ejare.ToString();
            
        }

       
        void radRotator1_BeginRotate(object sender, BeginRotateEventArgs e)
        {
           // radLabelElement1.Text = String.Format("Rotating from item {0} to {1}", e.From, e.To);
        }

       
     

       

        
    }
}
