using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Management;
using System.Threading;
using System.Net.Sockets;





namespace realstate
{
    public partial class Form1 : Form
    {
        public static string server_id = "";
        MyContext mycontext = new MyContext();
        double finalamount = 0;
        double miners = 0;
        int i = 0;
        static List<TcpListener> listenerlist = new List<TcpListener>();
        static List<lisener> lisenerdetaillist = new List<lisener>();
        List<BackgroundWorker> workers = new List<BackgroundWorker>();

        public Form1()
        {


            //string newpath = @"\\MERIOLI-PC\Users\merioli\Desktop\Datafolder";
            ////string newpath = AppDomain.CurrentDomain.BaseDirectory;
            //AppDomain.CurrentDomain.SetData("DataDirectory", newpath);

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


            // To report progress from the background worker we need to set this property
            backgroundWorker1.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                                                 backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerSupportsCancellation = true;


            //backgroundworker2
            backgroundWorker2.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker2.WorkerSupportsCancellation = true;

        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MyContext mycontext = new MyContext();
            string json2;
            using (var client = new WebClient())
            {
                json2 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
            }
            RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);
            float count = log.result.data.Count();
            float amount = 0;
            if (count >= 100)
            {
                amount = count / 100;

            }
            else
            {
                amount = 100 / count;
            }


            foreach (var item in log.result.data)
            {


                finalamount = finalamount + amount;
                try
                {
                    Datum newdata = new Datum
                    {
                        area = item.area,
                        build_year = item.build_year,
                        canbeAgent = item.canbeAgent,
                        cat = item.cat,
                        countryside = item.countryside,
                        desc = item.desc,
                        ejare = item.ejare,
                        email = item.email,
                        isAgent = item.isAgent,
                        lat = item.lat,
                        lng = item.lng,
                        metraj = item.metraj,
                        phone = item.phone,
                        room = item.room,
                        server_id = item.server_id,
                        source = item.source,
                        tabdil = item.tabdil,
                        title = item.title,
                        vadie = item.vadie
                    };
                    miners = finalamount - Math.Truncate(finalamount);
                    if (miners > 0.99)
                    {

                        backgroundWorker1.ReportProgress(Convert.ToInt32(Math.Truncate(finalamount)) + 1);
                        miners = miners - 0.99;
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(Convert.ToInt32(finalamount));
                    }

                    mycontext.Data.Add(newdata);
                    mycontext.SaveChanges();
                    foreach (var image in item.images)
                    {


                        bool exists = System.IO.Directory.Exists(Path.Combine(Application.StartupPath, "Images"));

                        if (!exists)
                            System.IO.Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Images"));

                        WebClient myWebClient = new WebClient();
                        string myStringWebResource = image;
                        string name = RandomString(7);
                        string fileName = Path.Combine(Application.StartupPath, "Images", name + ".jpg");
                        myWebClient.DownloadFile(myStringWebResource, fileName);

                        image newimage = new image();
                        newimage.name = name;
                        newimage.ProductID = item.server_id;
                        mycontext.images.Add(newimage);

                        mycontext.SaveChanges();

                    }


                }
                catch (Exception myerror)
                {


                }




            }




        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = e.ProgressPercentage.ToString() + "%";

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MyContext mycontext = new MyContext();
            List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
                                                       select p).ToList();
            this.radListView1.DataSource = songsDataTableBindingSource;
            this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
            this.radListView1.ViewType = ListViewType.DetailsView;
        }



        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //  public ChromiumWebBrowser chromeBrowser;

        //public void InitializeChromium()
        //{
        //    CefSettings settings = new CefSettings();
        //    // Initialize cef with the provided settings
        //    Cef.Initialize(settings);
        //    // Create a browser component
        //    chromeBrowser = new ChromiumWebBrowser("http://ourcodeworld.com");
        //    // Add it to the form and fill it to the form window.
        //    this.Controls.Add(chromeBrowser);
        //    chromeBrowser.Dock = DockStyle.Fill;
        //}


        private void MenuIcon_Click(object sender, EventArgs e)
        {
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 360);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalVariable.ConnectionString_IP = @".\SQLExpress";
            //MyContext mycontext = new MyContext(GlobalVariable.ConnectionString_IP);
            MyContext mycontext = new MyContext();
            // ChromiumWebBrowser myBrowser = new ChromiumWebBrowser();
            //  myBrowser.RegisterJsObject("winformobj",)
            // this.Controls.Add(myBrowser);

            SearchPanel.PanelElement.Shape = new RoundRectShape();
            SearchPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            SearchPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;
            panelOfFilterArrow.PanelElement.Shape = new RoundRectShape();
            panelOfFilterArrow.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panelOfFilterArrow.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            FilterDetailPanel.PanelElement.Shape = new RoundRectShape();
            FilterDetailPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            FilterDetailPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            sortPanel.PanelElement.Shape = new RoundRectShape();
            sortPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            sortPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            listviewPanel.PanelElement.Shape = new RoundRectShape();
            listviewPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            listviewPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;




            FilterDetailPanel.Height = FilterPanel.Height;
            menuPanel.Width = leftTableForMenu.Width;
            leftTableForMenu.Height = LeftPanel.Height;
            menuPanel.Height = LeftPanel.Height;
            menuPanel.Hide();
            downPic.Hide();

            progressBar1.Hide();


            //this.radListView1.ItemDataBound += new Telerik.WinControls.UI.ListViewItemEventHandler(radListView1_ItemDataBound);
            //this.radListView1.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(radListView1_VisualItemFormatting);
            //this.radListView1.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(radListView1_CellFormatting);
            this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
            //this.radListView1.ViewTypeChanged += new EventHandler(radListView1_ViewTypeChanged);
            //this.radListView1.AllowEdit = false;
            //this.radListView1.AllowRemove = false;
            string source = "C:\\Users\\merioli";
            string sourcFile = System.IO.Path.Combine(source, "myrealstate.mdf");

            try
            {
                if (File.Exists(sourcFile))
                {
                    List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
                                                               select p).ToList();
                    this.radListView1.DataSource = songsDataTableBindingSource;
                    this.radListView1.DisplayMember = "server_id";
                    this.radListView1.ValueMember = "server_id";
                    this.radListView1.ViewType = ListViewType.DetailsView;
                }

            }
            catch (Exception error)
            {

            }





        }

        void radListView1_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName == "desc" || e.Column.FieldName == "images" || e.Column.FieldName == "server_id" || e.Column.FieldName == "isAgent" || e.Column.FieldName == "lat" || e.Column.FieldName == "lng" || e.Column.FieldName == "canbeAgent" || e.Column.FieldName == "tabdil" || e.Column.FieldName == "phone" || e.Column.FieldName == "email" || e.Column.FieldName == "source")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "SongName")
            {
                e.Column.HeaderText = "Song Title";
            }
            if (e.Column.FieldName == "ArtistName")
            {
                e.Column.HeaderText = "Artist";
            }
            if (e.Column.FieldName == "AlbumName")
            {
                e.Column.HeaderText = "Album";
            }
        }
        private void commandBarDropDownSort_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radListView1.SortDescriptors.Clear();
            switch (this.commandBarDropDownSort.Text)
            {
                case "رهن":
                    this.radListView1.SortDescriptors.Add(new SortDescriptor("vadie", ListSortDirection.Ascending));
                    this.radListView1.EnableSorting = true;
                    break;
                case "اجاره":
                    this.radListView1.SortDescriptors.Add(new SortDescriptor("ejare", ListSortDirection.Ascending));
                    this.radListView1.EnableSorting = true;
                    break;
                case "متراژ":
                    this.radListView1.SortDescriptors.Add(new SortDescriptor("metraj", ListSortDirection.Ascending));
                    this.radListView1.EnableSorting = true;
                    break;
            }
        }
        private void commandBarDropDownGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radListView1.GroupDescriptors.Clear();
            switch (this.commandBarDropDownGroup.Text)
            {
                case "None":
                    this.radListView1.EnableGrouping = false;
                    this.radListView1.ShowGroups = false;
                    break;
                case "تعداد اتاق":
                    this.radListView1.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("room", ListSortDirection.Ascending) }));
                    this.radListView1.EnableGrouping = true;
                    this.radListView1.ShowGroups = true;
                    break;
                case "منطقه":
                    this.radListView1.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("cat", ListSortDirection.Ascending) }));
                    this.radListView1.EnableGrouping = true;
                    this.radListView1.ShowGroups = true;
                    break;
                case "سال ساخت":
                    this.radListView1.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("build_year", ListSortDirection.Ascending) }));
                    this.radListView1.EnableGrouping = true;
                    this.radListView1.ShowGroups = true;
                    break;
                case "دسته بندی":
                    this.radListView1.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("cat", ListSortDirection.Ascending) }));
                    this.radListView1.EnableGrouping = true;
                    this.radListView1.ShowGroups = true;
                    break;
            }
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


        private void radButton1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            progressBar1.Show();
            radButton1.Hide();
            // MyContext mycontext = new MyContext(GlobalVariable.ConnectionString_IP);



            //List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
            //                                           select p).ToList();
            //this.radListView1.DataSource = songsDataTableBindingSource;
            //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
            //this.radListView1.ViewType = ListViewType.DetailsView;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVariable.port = 8001;
            clientsector(8001);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalVariable.port = 8002;
            clientsector(8002);
        }
        public void clientsector(int port)
        {

            try
            {



                TcpClient tcpclnt = new TcpClient();
                bool mybo = true;
                while (mybo)
                {
                    try
                    {
                        tcpclnt.Connect("192.168.0.1", port);
                        mybo = false;
                    }
                    catch (Exception)
                    {


                    }
                }

                // use the ipaddress as in the server program
                Console.WriteLine("Connected with port" + port.ToString());
                //Console.Write("Enter the string to be transmitted : ");

                //String str = Console.ReadLine();
                string str = "aaaaa";
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);
                string json = "";

                const int blockSize = 1024;
                byte[] buffer = new byte[blockSize];
                int bytesRead;

                while ((bytesRead = stm.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        json = json + Convert.ToChar(buffer[i]);
                    }
                }

                RootObject log = JsonConvert.DeserializeObject<RootObject>(json);
                List<Datum> songsDataTableBindingSource = (from p in log.result.data
                                                           select p).ToList();
                this.radListView1.DataSource = songsDataTableBindingSource;
                this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
                this.radListView1.ViewType = ListViewType.DetailsView;

                tcpclnt.Close();

            }

            catch (Exception f)
            {
                Console.Write("Error..... " + f.StackTrace);
            }
        }
        private void listen_Click(object sender, EventArgs e)
        {
            createBackgroundWorker(2);
        }

        void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int value = (int)e.Argument;
            donegociate(value);

        }
        //static void donegociate(int port)
        //{
        //    //backgroundWorker2.ReportProgress(Convert.ToInt32(Math.Truncate(finalamount)) + 1);
        //    // IPAddress ipAd = IPAddress.Parse("192.168.0.1");
        //    // use local m/c IP address, and 
        //    // use the same in the client

        //    /* Initializes the Listener */
        //    TcpListener myList = listenerlist[port];

        //    /* Start Listeneting at the specified port */

        //    bool mybool = true;
        //    string id = "";
        //    while (mybool)
        //    {
        //        try
        //        {

        //            myList.Start();
        //            Console.WriteLine("The server is running at port " + port + "...");
        //            Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
        //            Console.WriteLine("Waiting for a connection.....");
        //            Socket s = myList.AcceptSocket();
        //            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

        //            byte[] b = new byte[100];
        //            int k = s.Receive(b);
        //            Console.WriteLine("Recieved...");
        //            string mes = "";
        //            for (int i = 0; i < k; i++)
        //            {
        //                Console.Write(Convert.ToChar(b[i]));
        //                mes = mes + Convert.ToChar(b[i]);
        //            }
        //            string json2;
        //            using (var client = new WebClient())
        //            {
        //                json2 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
        //            }
        //            RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);

        //            if (Convert.ToChar(b[0]).ToString() == "1")
        //            {
        //                string income = mes.Substring(1, mes.Length - 1);
        //                id = income;


        //                Datum dataselected = (from p in log.result.data
        //                                      where p.server_id == income
        //                                      select p).SingleOrDefault();

        //                byte[] imagenum = new Byte[1];


        //                ASCIIEncoding asencoding = new ASCIIEncoding();
        //                switch (dataselected.images.Count())
        //                {
        //                    case 1:
        //                        imagenum[0] = 1;
        //                        break;
        //                    case 2:
        //                        imagenum[0] = 2;
        //                        break;
        //                    case 3:
        //                        imagenum[0] = 3;
        //                        break;
        //                    case 4:
        //                        imagenum[0] = 4;
        //                        break;
        //                    case 5:
        //                        imagenum[0] = 5;
        //                        break;
        //                    case 6:
        //                        imagenum[0] = 6;
        //                        break;
        //                    case 7:
        //                        imagenum[0] = 7;
        //                        break;
        //                    case 8:
        //                        imagenum[0] = 8;
        //                        break;
        //                    case 9:
        //                        imagenum[0] = 9;
        //                        break;
        //                    default:
        //                        imagenum[0] = 9;
        //                        break;


        //                }
        //                s.Send(imagenum);


        //            }
        //            else if (Convert.ToChar(b[0]).ToString() == "2")
        //            {
        //                int imagenum = Convert.ToInt32(Convert.ToChar(b[1]).ToString()) - 1;
        //                Datum dataselected = (from p in log.result.data
        //                                      where p.server_id == id
        //                                      select p).SingleOrDefault();
        //                string item = dataselected.images[imagenum];
        //                var webClient = new WebClient();

        //                byte[] imageBytes = webClient.DownloadData(item);
        //                s.Send(imageBytes);

        //                //Console.WriteLine("\nSent Acknowledgement");
        //            }
        //            else if (Convert.ToChar(b[0]).ToString() == "3")
        //            {


        //                ASCIIEncoding asen = new ASCIIEncoding();
        //                s.Send(asen.GetBytes(json2));

        //            }
        //            else
        //            {
        //                string json3;
        //                using (var client = new WebClient())
        //                {
        //                    json3 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
        //                }
        //                ASCIIEncoding asen = new ASCIIEncoding();
        //                s.Send(asen.GetBytes(json2));
        //                Console.WriteLine("\nSent Acknowledgement");
        //            }



        //            /* clean up */
        //            s.Close();

        //            myList.Stop();
        //        }
        //        catch (Exception h)
        //        {
        //            Console.WriteLine("Error..... " + h.StackTrace);
        //        }
        //        // mybool = false;
        //    }
        //}
        static void donegociate(int port)
        {
            //backgroundWorker2.ReportProgress(Convert.ToInt32(Math.Truncate(finalamount)) + 1);
            // IPAddress ipAd = IPAddress.Parse("192.168.0.1");
            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */


            /* Start Listeneting at the specified port */


            while (true)
            {
                try
                {

                    listenerlist[port].Start();
                    Console.WriteLine("The server is running at port " + port + "...");
                    Console.WriteLine("The local End point is  :" + listenerlist[port].LocalEndpoint);
                    Console.WriteLine("Waiting for a connection.....");
                    lisenerdetaillist[port].newsocket = listenerlist[port].AcceptSocket();
                    Console.WriteLine("Connection accepted from " + lisenerdetaillist[port].newsocket.RemoteEndPoint);


                    lisenerdetaillist[port].RecievedByteCount = lisenerdetaillist[port].newsocket.Receive(lisenerdetaillist[port].b);
                    Console.WriteLine("Recieved...");
                    string mes = "";
                    while (lisenerdetaillist[port].counter < lisenerdetaillist[port].RecievedByteCount)
                    {
                        Console.Write(Convert.ToChar(lisenerdetaillist[port].b[lisenerdetaillist[port].counter]));
                        lisenerdetaillist[port].message = lisenerdetaillist[port].message + Convert.ToChar(lisenerdetaillist[port].b[lisenerdetaillist[port].counter]);
                        lisenerdetaillist[port].counter += 1;
                    }

                    string json2;
                    using (var client = new WebClient())
                    {
                        json2 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
                    }
                    RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);

                    if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "1")
                    {

                        lisenerdetaillist[port].id = lisenerdetaillist[port].message.Substring(1, lisenerdetaillist[port].message.Length - 1);


                        lisenerdetaillist[port].datumselected = (from p in log.result.data
                                                                 where p.server_id == lisenerdetaillist[port].id
                                                                 select p).SingleOrDefault();



                        ASCIIEncoding asencoding = new ASCIIEncoding();
                        switch (lisenerdetaillist[port].datumselected.images.Count())
                        {
                            case 1:
                                lisenerdetaillist[port].imagenum[0] = 1;
                                break;
                            case 2:
                                lisenerdetaillist[port].imagenum[0] = 2;
                                break;
                            case 3:
                                lisenerdetaillist[port].imagenum[0] = 3;
                                break;
                            case 4:
                                lisenerdetaillist[port].imagenum[0] = 4;
                                break;
                            case 5:
                                lisenerdetaillist[port].imagenum[0] = 5;
                                break;
                            case 6:
                                lisenerdetaillist[port].imagenum[0] = 6;
                                break;
                            case 7:
                                lisenerdetaillist[port].imagenum[0] = 7;
                                break;
                            case 8:
                                lisenerdetaillist[port].imagenum[0] = 8;
                                break;
                            case 9:
                                lisenerdetaillist[port].imagenum[0] = 9;
                                break;
                            default:
                                lisenerdetaillist[port].imagenum[0] = 9;
                                break;


                        }
                        lisenerdetaillist[port].newsocket.Send(lisenerdetaillist[port].imagenum);
                        listenerlist[port].Stop();

                    }
                    else if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "2")
                    {
                        lisenerdetaillist[port].imageNumberSent = Convert.ToInt32(Convert.ToChar(lisenerdetaillist[port].b[1]).ToString()) - 1;
                        lisenerdetaillist[port].datumselected = (from p in log.result.data
                                                                 where p.server_id == lisenerdetaillist[port].id
                                                                 select p).SingleOrDefault();
                        lisenerdetaillist[port].imageurlForDownload = lisenerdetaillist[port].datumselected.images[lisenerdetaillist[port].imageNumberSent];
                        var webClient = new WebClient();
                        lisenerdetaillist[port].newsocket.Send(webClient.DownloadData(lisenerdetaillist[port].imageurlForDownload));
                        listenerlist[port].Stop();
                        //Console.WriteLine("\nSent Acknowledgement");
                    }
                    else if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "3")
                    {


                        ASCIIEncoding asen = new ASCIIEncoding();
                        lisenerdetaillist[port].newsocket.Send(asen.GetBytes(json2));
                        listenerlist[port].Stop();
                    }
                    else
                    {
                        string json3;
                        using (var client = new WebClient())
                        {
                            json3 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
                        }
                        ASCIIEncoding asen = new ASCIIEncoding();
                        lisenerdetaillist[port].newsocket.Send(asen.GetBytes(json2));
                        listenerlist[port].Stop();
                        Console.WriteLine("\nSent Acknowledgement");
                    }



                    /* clean up */
                   
                    lisenerdetaillist[port].newsocket.Close();
                    lisenerdetaillist[port].newsocket = null;
                    lisenerdetaillist[port].b = new byte[100];
                    lisenerdetaillist[port].datumselected = new Datum();
                    lisenerdetaillist[port].imageurlForDownload = "";
                    lisenerdetaillist[port].imageNumberSent = 0;
                    lisenerdetaillist[port].imagenum = new byte[1];
                    lisenerdetaillist[port].message = "";
                    lisenerdetaillist[port].RecievedByteCount = 0;
                    lisenerdetaillist[port].counter = 0;
                        

                  
                }
                catch (Exception h)
                {
                    Console.WriteLine("Error..... " + h.StackTrace);
                }
                // mybool = false;
            }
        }


        public void createBackgroundWorker(int num)
        {
            IPAddress ipAd = IPAddress.Parse("192.168.0.1");
            int numberOfWorkersNeeded = num;

            for (i = 1; i <= numberOfWorkersNeeded; i++)
            {
                int count = listenerlist.Count();
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
                //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyWorkFinishedHandler);
                int port = 8000 + i;

                TcpListener myList = new TcpListener(ipAd, port);
                lisener newlistener = new lisener()
                {
                    newsocket = null,
                    b = new byte[100],
                    datumselected = new Datum(),
                    id = "",
                    imagenum = new byte[1],
                    imageNumberSent = 0,
                    imageurlForDownload = "",
                    message = "",
                    RecievedByteCount = 0,
                    counter = 0


                };

                lisenerdetaillist.Add(newlistener);
                listenerlist.Add(myList);
                workers.Add(bg);
                bg.RunWorkerAsync(argument: count);
            }

        }
        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {

            Datum myCustomId = (Datum)radListView1.SelectedItem.Value;
            server_id = myCustomId.server_id;

            Form2 form2 = new Form2(server_id);

            form2.Show();

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


    }
}
//public void docopy()
//{
//    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
//    string desfolder = System.IO.Path.Combine(path, "Datafolder");
//    if (!System.IO.Directory.Exists(desfolder))
//    {
//        System.IO.Directory.CreateDirectory(desfolder);
//    }
//    string desfile = System.IO.Path.Combine(desfolder, "myrealstatedes.mdf");
//    string desfile2 = System.IO.Path.Combine(desfolder, "myrealstatedes_log.ldf");

//    string source = "C:\\Users\\merioli";
//    string sourcFile = System.IO.Path.Combine(source, "myrealstate.mdf");
//    string sourcFile2 = System.IO.Path.Combine(source, "myrealstate_log.ldf");

//    try
//    {
//        if (File.Exists(sourcFile))
//        {
//            System.IO.File.Copy(sourcFile, desfile, true);
//        }
//        if (File.Exists(sourcFile2))
//        {
//            System.IO.File.Copy(sourcFile2, desfile2, true);
//        }
//    }
//    catch (Exception)
//    {

//    }



//}

