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

using System.Net.Sockets;
using System.Security.Cryptography;
using System.Drawing.Text;





namespace realstate
{
    public partial class Form1 : Form
    {


        public static string server_id = "";
        MyContext mycontext = new MyContext();
        double finalamount = 0;
        double miners = 0;
        int i = 0;
        int panelForList = 0;
        static bool ContinuAllListener = true;
        static List<TcpListener> listenerlist = new List<TcpListener>();
        static List<lisener> lisenerdetaillist = new List<lisener>();
        List<BackgroundWorker> workers = new List<BackgroundWorker>();

        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion


        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion



        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;



        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
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
            // backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            // backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                                                 backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerSupportsCancellation = true;


            //backgroundworker2
            backgroundWorker2.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            //backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker2.WorkerSupportsCancellation = true;



            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

          

        }

        //void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    MyContext mycontext = new MyContext();
        //    string json2;
        //    using (var client = new WebClient())
        //    {
        //        json2 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
        //    }
        //    RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);
        //    float count = log.result.data.Count();
        //    float amount = 0;
        //    if (count >= 100)
        //    {
        //        amount = count / 100;

        //    }
        //    else
        //    {
        //        amount = 100 / count;
        //    }


        //    foreach (var item in log.result.data)
        //    {


        //        finalamount = finalamount + amount;
        //        try
        //        {
        //            Datum newdata = new Datum
        //            {
        //                area = item.area,
        //                build_year = item.build_year,
        //                canbeAgent = item.canbeAgent,
        //                cat = item.cat,
        //                countryside = item.countryside,
        //                desc = item.desc,
        //                ejare = item.ejare,
        //                email = item.email,
        //                isAgent = item.isAgent,
        //                lat = item.lat,
        //                lng = item.lng,
        //                metraj = item.metraj,
        //                phone = item.phone,
        //                room = item.room,
        //                server_id = item.server_id,
        //                source = item.source,
        //                tabdil = item.tabdil,
        //                title = item.title,
        //                vadie = item.vadie
        //            };
        //            miners = finalamount - Math.Truncate(finalamount);
        //            if (miners > 0.99)
        //            {

        //                backgroundWorker1.ReportProgress(Convert.ToInt32(Math.Truncate(finalamount)) + 1);
        //                miners = miners - 0.99;
        //            }
        //            else
        //            {
        //                backgroundWorker1.ReportProgress(Convert.ToInt32(finalamount));
        //            }

        //            mycontext.Data.Add(newdata);
        //            mycontext.SaveChanges();
        //            foreach (var image in item.images)
        //            {


        //                bool exists = System.IO.Directory.Exists(Path.Combine(Application.StartupPath, "Images"));

        //                if (!exists)
        //                    System.IO.Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Images"));

        //                WebClient myWebClient = new WebClient();
        //                string myStringWebResource = image;
        //                string name = RandomString(7);
        //                string fileName = Path.Combine(Application.StartupPath, "Images", name + ".jpg");
        //                myWebClient.DownloadFile(myStringWebResource, fileName);

        //                image newimage = new image();
        //                newimage.name = name;
        //                newimage.ProductID = item.server_id;
        //                mycontext.images.Add(newimage);

        //                mycontext.SaveChanges();

        //            }


        //        }
        //        catch (Exception myerror)
        //        {


        //        }




        //    }




        //}

        //void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    // The progress percentage is a property of e
        //    progressBar1.Value = e.ProgressPercentage;
        //    label3.Text = e.ProgressPercentage.ToString() + "%";

        //}
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MyContext mycontext = new MyContext();
            List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
                                                       select p).ToList();
            //this.radListView1.DataSource = songsDataTableBindingSource;
            //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
            //this.radListView1.ViewType = ListViewType.DetailsView;
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


        private void fontload()
        {
            Font lableFont;
            lableFont = new Font(fonts.Families[0], 12.0F);
            label2.Font = lableFont;
            label28.Font = lableFont;
            label27.Font = lableFont;
            label26.Font = lableFont;
            label5.Font = lableFont;
            //listheader

           

            label29.Font = lableFont;
            //titlelogo

            seachButt.Font = lableFont;
            //confirmlable






            Font smallfont;
            smallfont = new Font(fonts.Families[0], 10.0F);

            Font smallfontmedium;
            smallfontmedium = new Font(fonts.Families[0], 9.0F, System.Drawing.FontStyle.Bold);


            label17.Font = smallfontmedium;
            lastupdataLable.Font = smallfontmedium;
            label21.Font = smallfontmedium;
            label22.Font = smallfontmedium;
            label23.Font = smallfontmedium;
            label24.Font = smallfontmedium;
            label25.Font = smallfontmedium;
            //headerbar
            label30.Font = smallfontmedium;
            //versionlogo
            lable8.Font = smallfont;
            label9.Font = smallfont;
            label10.Font = smallfont;
            label11.Font = smallfont;
            label12.Font = smallfont;
            label13.Font = smallfont;
            label14.Font = smallfont;
            label15.Font = smallfont;
            label18.Font = smallfont;
            label19.Font = smallfont;

            cat.Font = smallfont;
            kind.Font = smallfont;
            AreaPart.Font = smallfont;
            metrajfrom.Font = smallfont;
            room.Font = smallfont;
            metrajto.Font = smallfont;
            metrajto.Font = smallfont;
            vadiefrom.Font = smallfont;
            vadieto.Font = smallfont;
            ejarefrom.Font = smallfont;
            ejareto.Font = smallfont;
            searchTextBox.Font = smallfont;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            if (Settings1.Default.lastTimeStamp !=DateTime.MinValue)
            {
                TimeSpan duration = DateTime.Now - Settings1.Default.lastTimeStamp;
                double minute = duration.TotalMinutes;
                if (minute < 1)
                {
                    lastupdataLable.Text = "لحظاتی پیش";
                }
                else if(minute > 1 && minute < 60){
                    lastupdataLable.Text = Convert.ToInt32(minute).ToString() + " دقیقه پیش ";
                }
                else
                {
                    lastupdataLable.Text =   "+ یکساعت پیش";
                }
            }   


            fontload();
           
            bool isgo = true;
            string json5 = "";


           


            while (isgo)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        json5 = client.DownloadString("http://api.backino.net/melkagahi/getCats&Areas.php");
                    }
                    isgo = false;
                }
                catch (Exception)
                {


                    isgo = false;
                }
            }
            GlobalVariable.portlimit = 2;
            CatsAndAreasObject autocompleteObject = JsonConvert.DeserializeObject<CatsAndAreasObject>(json5);
            GlobalVariable.catsAndAreas = autocompleteObject;
            if (GlobalVariable.catsAndAreas != null)
            {


                var sourceofcat = new AutoCompleteStringCollection();
                foreach (var item in GlobalVariable.catsAndAreas.result2.category)
                {
                    cat.Items.Add(item.title);
                    sourceofcat.Add(item.title);
                }

                cat.AutoCompleteCustomSource = sourceofcat;
                cat.AutoCompleteMode = AutoCompleteMode.Append;
                cat.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cat.MaxDropDownItems = 10;


                var sourceofkind = new AutoCompleteStringCollection();
                foreach (var item in GlobalVariable.catsAndAreas.result2.cats2)
                {
                    kind.Items.Add(item.title);
                    sourceofkind.Add(item.title);
                }

                kind.AutoCompleteCustomSource = sourceofkind;
                kind.AutoCompleteMode = AutoCompleteMode.Append;
                kind.AutoCompleteSource = AutoCompleteSource.CustomSource;
                kind.MaxDropDownItems = 10;




                var sourceofarea = new AutoCompleteStringCollection();
                foreach (var item in GlobalVariable.catsAndAreas.result2.areas2)
                {
                    AreaPart.Items.Add(item.title);
                    sourceofarea.Add(item.title);
                }
                AreaPart.AutoCompleteCustomSource = sourceofarea;
                AreaPart.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AreaPart.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AreaPart.MaxDropDownItems = 10;
            }


            GlobalVariable.ConnectionString_IP = @".\SQLExpress";
            //MyContext mycontext = new MyContext(GlobalVariable.ConnectionString_IP);
            MyContext mycontext = new MyContext();
            // ChromiumWebBrowser myBrowser = new ChromiumWebBrowser();
            //  myBrowser.RegisterJsObject("winformobj",)
            // this.Controls.Add(myBrowser);

            SearchPanel.PanelElement.Shape = new RoundRectShape();
            SearchPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            SearchPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;
            //panelOfFilterArrow.PanelElement.Shape = new RoundRectShape();
            //panelOfFilterArrow.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //panelOfFilterArrow.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            //FilterDetailPanel.PanelElement.Shape = new RoundRectShape();
            //FilterDetailPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //FilterDetailPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            mainPanelOfList.PanelElement.Shape = new RoundRectShape();
            mainPanelOfList.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            mainPanelOfList.PanelElement.PanelFill.BackColor = Color.White;
            

            //sortPanel.PanelElement.Shape = new RoundRectShape();
            //sortPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //sortPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            menuPanel.PanelElement.Shape = new RoundRectShape();
            menuPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            // menuPanel.PanelElement.PanelFill.BackColor = Color.;



            //flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            //flowLayoutPanel1.WrapContents = false;
            //flowLayoutPanel1.AutoScroll = true;



            //listviewPanel.PanelElement.Shape = new RoundRectShape();
            //listviewPanel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            //listviewPanel.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;




            FilterDetailPanel.Height = FilterPanel.Height;
            menuPanel.Width = leftTableForMenu.Width;
            leftTableForMenu.Height = LeftPanel.Height;
            menuPanel.Height = LeftPanel.Height;
            menuPanel.Hide();
            //downPic.Hide();

            //radListView1.ListViewElement.DrawBorder = false;
            //radListView1.ListViewElement.DrawFill = false;
            //radListView1.ListViewElement.TextAlignment = ContentAlignment.MiddleCenter;
            // progressBar1.Hide();
            connect.Visible = false;

            //this.radListView1.ItemDataBound += new Telerik.WinControls.UI.ListViewItemEventHandler(radListView1_ItemDataBound);
            //this.radListView1.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(radListView1_VisualItemFormatting);
            //this.radListView1.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(radListView1_CellFormatting);
            //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
            ////this.radListView1.ViewTypeChanged += new EventHandler(radListView1_ViewTypeChanged);
            //this.radListView1.AllowEdit = false;
            //this.radListView1.AllowRemove = false;
            //string source = "C:\\Users\\merioli";
            //string sourcFile = System.IO.Path.Combine(source, "myrealstate.mdf");

            //try
            //{
            //    if (File.Exists(sourcFile))
            //    {
            //        List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
            //                                                   select p).ToList();
            //        //this.radListView1.DataSource = songsDataTableBindingSource;
            //        //this.radListView1.DisplayMember = "server_id";
            //        //this.radListView1.ValueMember = "server_id";
            //        //this.radListView1.ViewType = ListViewType.DetailsView;
            //    }

            //}
            //catch (Exception error)
            //{

            //}
            // var listofcat = new List<string>();
            if (GlobalVariable.catsAndAreas != null)
            {
                var sourceofcat = new AutoCompleteStringCollection();
                foreach (var item in GlobalVariable.catsAndAreas.result2.cats2)
                {
                    sourceofcat.Add(item.title);
                }
                cat.AutoCompleteCustomSource = sourceofcat;
                cat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cat.AutoCompleteSource = AutoCompleteSource.CustomSource;

                var sourceofarea = new AutoCompleteStringCollection();
                foreach (var item in GlobalVariable.catsAndAreas.result2.areas2)
                {
                    sourceofarea.Add(item.title);
                }
                AreaPart.AutoCompleteCustomSource = sourceofarea;
                AreaPart.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AreaPart.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            getDataFromServer();



        }
        //private void radListView1_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        //{
        //    DetailListViewDataCellElement cell = e.CellElement as DetailListViewDataCellElement;
        //    if (cell != null)
        //    {
        //        DataRowView productRowView = cell.Row.DataBoundItem as DataRowView;
        //        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
        //        if (cell.Text == "False")
        //        {
        //            cell.Text = "خیر";
        //        }
        //        if (cell.Text == "True")
        //        {
        //            cell.Text = "بله";

        //        }
        //        //if (productRowView != null && (bool)productRowView.Row["Discontinued"] == true)
        //        //{
        //        //    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
        //        //    //e.CellElement.ForeColor = Color.Red;
        //        //    //e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;

        //        //}
        //        //else
        //        //{
        //        //    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
        //        //    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
        //        //    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local);
        //        //    e.CellElement.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local);
        //        //}
        //    }
        //}
        //void radListView1_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        //{
        //    if (e.Column.FieldName == "desc" || e.Column.FieldName == "images" || e.Column.FieldName == "server_id" || e.Column.FieldName == "isAgent" || e.Column.FieldName == "lat" || e.Column.FieldName == "lng" || e.Column.FieldName == "canbeAgent" || e.Column.FieldName == "tabdil" || e.Column.FieldName == "phone" || e.Column.FieldName == "email" || e.Column.FieldName == "source")
        //    {
        //        e.Column.Visible = false;
        //    }
        //    if (e.Column.FieldName == "title")
        //    {
        //        e.Column.HeaderText = "عنوان";

        //    }
        //    if (e.Column.FieldName == "area")
        //    {
        //        e.Column.HeaderText = "منطقه";
        //    }
        //    if (e.Column.FieldName == "build_year")
        //    {
        //        e.Column.HeaderText = "سال ساخت";
        //    }
        //    if (e.Column.FieldName == "countryside")
        //    {
        //        e.Column.HeaderText = "حومه شهر";
        //    }
        //    if (e.Column.FieldName == "metraj")
        //    {
        //        e.Column.HeaderText = "متراژ";
        //    }
        //    if (e.Column.FieldName == "vadie")
        //    {
        //        e.Column.HeaderText = "رهن";
        //    }
        //    if (e.Column.FieldName == "ejare")
        //    {
        //        e.Column.HeaderText = "اجاره";
        //    }
        //    if (e.Column.FieldName == "room")
        //    {
        //        e.Column.HeaderText = "تعداد اتاق";
        //    }
        //    if (e.Column.FieldName == "cat")
        //    {
        //        e.Column.HeaderText = "دسته بندی";
        //    }

        //}
        //private void commandBarDropDownSort_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        //{
        //    this.radListView1.SortDescriptors.Clear();
        //    switch (this.commandBarDropDownSort.Text)
        //    {
        //        case "رهن":
        //            this.radListView1.SortDescriptors.Add(new SortDescriptor("vadie", ListSortDirection.Ascending));
        //            this.radListView1.EnableSorting = true;
        //            break;
        //        case "اجاره":
        //            this.radListView1.SortDescriptors.Add(new SortDescriptor("ejare", ListSortDirection.Ascending));
        //            this.radListView1.EnableSorting = true;
        //            break;
        //        case "متراژ":
        //            this.radListView1.SortDescriptors.Add(new SortDescriptor("metraj", ListSortDirection.Ascending));
        //            this.radListView1.EnableSorting = true;
        //            break;
        //    }
        //}


        private void menuPanel_Click(object sender, EventArgs e)
        {
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 360);
        }

        private void downPic_Click(object sender, EventArgs e)
        {
            Util.Animate(FilterDetailPanel, Util.Effect.Slide, 150, 90);
            //downPic.Hide();
            //upPic.Show();

        }

        private void upPic_Click(object sender, EventArgs e)
        {
            Util.Animate(FilterDetailPanel, Util.Effect.Slide, 150, 90);
            //upPic.Hide();
            //downPic.Show();
        }


        //private void radButton1_Click(object sender, EventArgs e)
        //{
        //    progressBar1.Maximum = 100;
        //    progressBar1.Step = 1;
        //    progressBar1.Value = 0;
        //    backgroundWorker1.RunWorkerAsync();
        //    progressBar1.Show();
        //    radButton1.Hide();
        //    // MyContext mycontext = new MyContext(GlobalVariable.ConnectionString_IP);



        //    //List<Datum> songsDataTableBindingSource = (from p in mycontext.Data
        //    //                                           select p).ToList();
        //    //this.radListView1.DataSource = songsDataTableBindingSource;
        //    //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
        //    //this.radListView1.ViewType = ListViewType.DetailsView;




        //}

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVariable.port = 8001;
            clientsector(GlobalVariable.port);
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
                //this.radListView1.DataSource = songsDataTableBindingSource;
                //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
                //this.radListView1.ViewType = ListViewType.DetailsView;

                tcpclnt.Close();

            }

            catch (Exception f)
            {
                Console.Write("Error..... " + f.StackTrace);
            }
        }
        private void listen_Click(object sender, EventArgs e)
        {
            GlobalVariable.port = 8001;
            Form3 form3 = new Form3();
            form3.Show();
            //createBackgroundWorker(2);
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
          
            int value = (int)e.Argument;

            

            int port = value;
            while (ContinuAllListener)
            {
                if (workers[value].CancellationPending == true)
                {
                    e.Cancel = true;
                    ContinuAllListener = false;
                }
                else
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

                        //string json2;
                        //using (var client = new WebClient())
                        //{
                        //    json2 = client.DownloadString("http://api.backino.net/melkagahi/syncEngine.php");
                        //}


                        //RootObject log = JsonConvert.DeserializeObject<RootObject>(json2);

                        RootObject log = new RootObject();
                        if (GlobalVariable.result != null)
                        {
                            log = JsonConvert.DeserializeObject<RootObject>(GlobalVariable.result);
                        }
                        //یک ینی درخواست تعداد عکسای یه محصول
                        if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "1")
                        {
                            try
                            {
                                lisenerdetaillist[port].id = lisenerdetaillist[port].message.Substring(1, lisenerdetaillist[port].message.Length - 1);


                                lisenerdetaillist[port].datumselected = (from p in log.result.data
                                                                         where p.server_id == lisenerdetaillist[port].id
                                                                         select p).SingleOrDefault();



                                ASCIIEncoding asencoding = new ASCIIEncoding();
                                switch (lisenerdetaillist[port].datumselected.images.Count())
                                {
                                    case 1:
                                        if (lisenerdetaillist[port].datumselected.images[0].Length > 0)
                                        {
                                            lisenerdetaillist[port].imagenum[0] = 1;
                                        }
                                        else
                                        {
                                            lisenerdetaillist[port].imagenum[0] = 0;
                                        }

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
                            }
                            catch (Exception h)
                            {

                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes("Error"));
                                listenerlist[port].Stop();
                                Console.WriteLine("Error..... ");
                            }
                            finally
                            {
                                listenerlist[port].Stop();
                            }


                        }
                        // دو یعنی درخواست خود عکس که عدد عکس هم تو درخواست می آد
                        else if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "2")
                        {
                            try
                            {
                                lisenerdetaillist[port].imageNumberSent = Convert.ToInt32(Convert.ToChar(lisenerdetaillist[port].b[1]).ToString()) - 1;
                                lisenerdetaillist[port].datumselected = (from p in log.result.data
                                                                         where p.server_id == lisenerdetaillist[port].id
                                                                         select p).SingleOrDefault();
                                lisenerdetaillist[port].imageurlForDownload = lisenerdetaillist[port].datumselected.images[lisenerdetaillist[port].imageNumberSent];
                                MD5 md5Hash = MD5.Create();
                                string hash = GetMd5Hash(md5Hash, lisenerdetaillist[port].imageurlForDownload) + ".jpg";
                                string filepath = Path.Combine(Application.StartupPath, "Images", hash);
                                var webClient = new WebClient();
                                if (File.Exists(filepath))
                                {
                                    while (true)
                                    {
                                        try
                                        {

                                            lisenerdetaillist[port].newsocket.Send(webClient.DownloadData(filepath));
                                            break;
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }


                                else
                                {
                                    webClient.DownloadFile(new Uri(lisenerdetaillist[port].imageurlForDownload), filepath);
                                    lisenerdetaillist[port].newsocket.Send(webClient.DownloadData(filepath));

                                }
                                listenerlist[port].Stop();
                            }
                            catch (Exception)
                            {

                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes("Error"));
                                listenerlist[port].Stop();
                                Console.WriteLine("Error..... ");
                            }




                            //Console.WriteLine("\nSent Acknowledgement");
                        }
                        // یوزر و پس
                        else if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "4")
                        {
                            try
                            {
                                lisenerdetaillist[port].loginmodel = JsonConvert.DeserializeObject<login>(lisenerdetaillist[port].message.Substring(1, lisenerdetaillist[port].message.Length - 1));
                                while (true)
                                {
                                    try
                                    {
                                        string filepath = Path.Combine(Application.StartupPath, "Resources", "text.txt");
                                        lisenerdetaillist[port].loginDB = System.IO.File.ReadAllText(filepath);
                                        break;
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                if (JsonConvert.DeserializeObject<List<login>>(lisenerdetaillist[port].loginDB).Any(i => i.username == lisenerdetaillist[port].loginmodel.username && i.password == lisenerdetaillist[port].loginmodel.password))
                                {
                                    bool isgo = true;
                                    string json5 = "";
                                    string error = "0";
                                    while (isgo)
                                    {
                                        try
                                        {
                                            using (var client = new WebClient())
                                            {
                                                json5 = client.DownloadString("http://api.backino.net/melkagahi/getCats&Areas.php");
                                            }
                                            isgo = false;
                                        }
                                        catch (Exception)
                                        {

                                            error = "1";
                                            isgo = false;
                                        }
                                    }

                                    if (error == "1")
                                    {
                                        loginback answer = new loginback()
                                        {

                                            status = "خطای ارتباط با سرور",
                                            token = "",

                                        };
                                        ASCIIEncoding asen = new ASCIIEncoding();
                                        lisenerdetaillist[port].newsocket.Send(asen.GetBytes(JsonConvert.SerializeObject(answer)));
                                        listenerlist[port].Stop();
                                    }
                                    else
                                    {
                                        CatsAndAreasObject autocompleteObject = JsonConvert.DeserializeObject<CatsAndAreasObject>(json5);
                                        loginback answer = new loginback()
                                        {

                                            status = "success",
                                            token = "123456",
                                            autocompleteObject = autocompleteObject
                                        };
                                        ASCIIEncoding asen = new ASCIIEncoding();
                                        lisenerdetaillist[port].newsocket.Send(asen.GetBytes(JsonConvert.SerializeObject(answer)));
                                        listenerlist[port].Stop();
                                    }




                                }
                                else
                                {
                                    loginback answer = new loginback()
                                    {

                                        status = "error2",
                                        token = "",

                                    };
                                    ASCIIEncoding asen = new ASCIIEncoding();
                                    lisenerdetaillist[port].newsocket.Send(asen.GetBytes(JsonConvert.SerializeObject(answer)));
                                    listenerlist[port].Stop();
                                }
                            }
                            catch (Exception)
                            {

                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes("Error"));
                                listenerlist[port].Stop();
                                Console.WriteLine("Error..... ");
                            }
                            // lisenerdetaillist[port].loginjson = lisenerdetaillist[port].message.Substring(1, lisenerdetaillist[port].message.Length - 1);



                        }
                        // سه ینی درخواست اطلاعات یه محصول
                        else if (Convert.ToChar(lisenerdetaillist[port].b[0]).ToString() == "3")
                        {
                            try
                            {
                                string model = JsonConvert.SerializeObject(lisenerdetaillist[port].datumselected);
                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes(model));
                                listenerlist[port].Stop();
                            }
                            catch (Exception)
                            {

                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes("Error"));
                                listenerlist[port].Stop();
                                Console.WriteLine("Error..... ");
                            }
                            // GlobalVariable.result


                        }

                        else
                        {
                            try
                            {
                                string kj = lisenerdetaillist[port].message;

                                lisenerdetaillist[port].queryModel = JsonConvert.DeserializeObject<queryModel>(kj);

                                string result = "";
                                using (WebClient client = new WebClient())
                                {
                                    var collection = new System.Collections.Specialized.NameValueCollection();
                                    collection.Add("category", lisenerdetaillist[port].queryModel.cat);
                                    collection.Add("cat", lisenerdetaillist[port].queryModel.kind);
                                    collection.Add("area", lisenerdetaillist[port].queryModel.area);
                                    collection.Add("metraj_from", lisenerdetaillist[port].queryModel.metrajfrom);
                                    collection.Add("metraj_to", lisenerdetaillist[port].queryModel.metrajto);
                                    collection.Add("vadie_from", lisenerdetaillist[port].queryModel.vadiefrom);
                                    collection.Add("vadie_to", lisenerdetaillist[port].queryModel.vadieto);
                                    collection.Add("room", lisenerdetaillist[port].queryModel.room);
                                    collection.Add("ajare_from", lisenerdetaillist[port].queryModel.ejarefrom);
                                    collection.Add("ajare_to", lisenerdetaillist[port].queryModel.ejareto);
                                    //  collection.Add("query", code);

                                    //foreach (var myvalucollection in imaglist) {
                                    //    collection.Add("imaglist[]", myvalucollection);
                                    //}
                                    byte[] response =
                                    client.UploadValues("http://api.backino.net/melkagahi/listOfAds.php", collection);

                                    result = System.Text.Encoding.UTF8.GetString(response);
                                }
                                GlobalVariable.result = result;
                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes(result));
                                listenerlist[port].Stop();
                                Console.WriteLine("\nSent Acknowledgement");
                            }
                            catch (Exception)
                            {

                                ASCIIEncoding asen = new ASCIIEncoding();
                                lisenerdetaillist[port].newsocket.Send(asen.GetBytes("Error"));
                                listenerlist[port].Stop();
                                Console.WriteLine("Error..... ");
                            }

                        }



                        /* clean up */

                        lisenerdetaillist[port].newsocket.Close();
                        lisenerdetaillist[port].newsocket = null;
                        lisenerdetaillist[port].b = new byte[1000];
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
                        //MessageBox.Show("خطا در برقراری اتصال با آی پی سرور");

                    }
                }
               
                // mybool = false;
            }

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


           
        }


        public void createBackgroundWorker(int num)
        {
            IPAddress ipAd = IPAddress.Parse("192.168.0.1");
            int numberOfWorkersNeeded = num;

            for (i = 1; i <= numberOfWorkersNeeded; i++)
            {
                int count = listenerlist.Count();
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += new DoWorkEventHandler(bg_DoWork);
                bg.WorkerSupportsCancellation = true;
                bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_MyWorkFinishedHandler);
               
                bg.WorkerSupportsCancellation = true;
                int port = 8000 + i;

                TcpListener myList = new TcpListener(ipAd, port);
                lisener newlistener = new lisener()
                {
                    newsocket = null,
                    b = new byte[1000],
                    datumselected = new Datum(),
                    id = "",
                    imagenum = new byte[1],
                    imageNumberSent = 0,
                    imageurlForDownload = "",
                    message = "",
                    RecievedByteCount = 0,
                    counter = 0,
                    workercontinu = true


                };

                lisenerdetaillist.Add(newlistener);
                listenerlist.Add(myList);
                workers.Add(bg);
                bg.RunWorkerAsync(argument: count);
            }
            dissconnect.Visible = false;
            connect.Visible = true;

        }
        private void bg_MyWorkFinishedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker mysender = sender as BackgroundWorker;
            if (mysender.CancellationPending == true)
            {

            }
            if (listenerlist.Count > 0)
            {
                foreach (var item in listenerlist)
                {
                    item.Stop();
                }
            }
          
        }

        //private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        //{

        //    Datum myCustomId = (Datum)radListView1.SelectedItem.Value;
        //    server_id = myCustomId.server_id;

        //    Form2 form2 = new Form2(server_id);

        //    form2.Show();

        //}
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "ایجاد ارتباط")
            {
                
                label6.Text = "قطع ارتباط";

            }
            else
            {
               
                foreach (var item in workers)
                {
                    item.CancelAsync();
                    
                  
                }
              
                //foreach (var item in listenerlist)
                //{
                //    item.Stop();
                //}
                ContinuAllListener = false;
                connect.Visible = false;
                dissconnect.Visible = true;
                label6.Text = "ایجاد ارتباط";
            }


        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            listenButtonHolderPanel.BackColor = Color.LightGray;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            listenButtonHolderPanel.BackColor = Color.Transparent;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            UserAccessPanel.BackColor = Color.LightGray;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            UserAccessPanel.BackColor = Color.Transparent;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            CreateFilePanel.BackColor = Color.LightGray;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            CreateFilePanel.BackColor = Color.Transparent;
        }

        private void label8_MouseEnter_1(object sender, EventArgs e)
        {
            CreateFilePanel.BackColor = Color.LightGray;
        }

        private void label8_MouseLeave_1(object sender, EventArgs e)
        {
            CreateFilePanel.BackColor = Color.Transparent;
        }



        private void label7_Click(object sender, EventArgs e)
        {
           
        }

       
        private void getDataFromServer()
        {
            BackgroundWorker getDataBackGroundWorker = new BackgroundWorker();
            getDataBackGroundWorker.WorkerSupportsCancellation = true;
            getDataBackGroundWorker.DoWork += new DoWorkEventHandler(getDataFromServer);
            getDataBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorker_done);
            string areaaof = "";
            string kindof = "";
            string catof = "";
            string mtjfrom = metrajfrom.Text;
            string mtjto = metrajto.Text;
            string rom = room.Text;
            string vadfrom = vadiefrom.Text;
            string vadto = vadieto.Text;
            string ejfrom = ejarefrom.Text;
            string ejto = ejareto.Text;
            if (AreaPart.Text != "")
            {
                Areas2 q = (from p in GlobalVariable.catsAndAreas.result2.areas2
                            where p.title == AreaPart.Text
                            select p).SingleOrDefault();
                areaaof = q.ID;
            }
            if (kind.Text != "")
            {
                Cats2 q = (from p in GlobalVariable.catsAndAreas.result2.cats2
                           where p.title == kind.Text
                           select p).SingleOrDefault();
                kindof = q.ID;
            }
            if (cat.Text != "")
            {
                Category q = (from p in GlobalVariable.catsAndAreas.result2.category
                              where p.title == cat.Text
                              select p).SingleOrDefault();
                catof = q.ID;
            }
            queryModel myquery = new queryModel();
            myquery.area = areaaof;
            myquery.cat = catof;
            myquery.kind = kindof;
            myquery.metrajfrom = mtjfrom;
            myquery.metrajto = mtjto;
            myquery.ejarefrom = ejfrom;
            myquery.ejareto = ejto;
            myquery.vadiefrom = vadfrom;
            myquery.vadieto = vadto;
            myquery.room = rom;
            string str = JsonConvert.SerializeObject(myquery);

            getDataBackGroundWorker.RunWorkerAsync(argument: str);
            refresh.Visible = true;
        }
        private void getDataBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                RootObject log = JsonConvert.DeserializeObject<RootObject>(e.Result as string);
                List<Datum> songsDataTableBindingSource = (from p in log.result.data
                                                           select p).ToList();
                foreach (var item in songsDataTableBindingSource)
                {

                    string name = "panel" + panelForList;
                    Telerik.WinControls.UI.RadPanel panel = new Telerik.WinControls.UI.RadPanel();
                    panel.Dock = System.Windows.Forms.DockStyle.Top;
                    panel.Location = new System.Drawing.Point(0, 0);
                    panel.Name = name;

                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    //panel.BackColor = System.Drawing.SystemColors.ScrollBar;
                    panel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
                    //panel.PanelElement.Shape = new RoundRectShape();
                    //panel.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;


                    string name2 = "panelinside" + panelForList;
                    Telerik.WinControls.UI.RadPanel panelinsed = new Telerik.WinControls.UI.RadPanel();
                    panelinsed.Dock = System.Windows.Forms.DockStyle.Fill;
                    panelinsed.Location = new System.Drawing.Point(0, 0);
                    panelinsed.Name = name2;

                    panelinsed.PanelElement.Shape = new RoundRectShape();
                    panelinsed.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
                    panelinsed.PanelElement.PanelFill.BackColor = Color.LightGray;

                    //((Telerik.WinControls.UI.RadPanelElement)(panelinsed.GetChildAt(0))).Shape = new RoundRectShape();
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelinsed.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.DarkGray;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelinsed.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;



                    System.Windows.Forms.TableLayoutPanel tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                    tableLayoutPanel1.ColumnCount = 6;
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
                    tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
                    tableLayoutPanel1.RowCount = 1;
                    tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

                    tableLayoutPanel1.Name = "tableLayoutPanel1";

                    Telerik.WinControls.UI.RadPanel panelforpic = new Telerik.WinControls.UI.RadPanel();
                    panelforpic.BackColor = System.Drawing.Color.Transparent;
                    panelforpic.Location = new System.Drawing.Point(161, 37);
                    panelforpic.Name = "panelforvadie";
                    panelforpic.Size = new System.Drawing.Size(180, 29);
                    panelforpic.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelforpic.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforpic.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                    if (Settings1.Default.ides.Contains(item.server_id))
                    {
                        System.Windows.Forms.PictureBox pic = new PictureBox();
                        pic.BackColor = System.Drawing.Color.LightGray;
                        pic.Image = global::realstate.Properties.Resources.down;
                        pic.Location = new System.Drawing.Point(8, 6);
                        pic.Margin = new System.Windows.Forms.Padding(8);


                        pic.Name = "0-" + item.server_id;
                        pic.Size = new System.Drawing.Size(29, 26);
                        pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        pic.TabIndex = 0;
                        pic.TabStop = false;
                        pic.Click += new System.EventHandler(this.starPic_Click);
                        //pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));
                        pic.Dock = System.Windows.Forms.DockStyle.Top;
                        pic.Visible = false;

                        System.Windows.Forms.PictureBox pic2 = new PictureBox();
                        pic2.BackColor = System.Drawing.Color.LightGray;
                        pic2.Image = global::realstate.Properties.Resources.up;
                        pic2.Location = new System.Drawing.Point(8, 6);
                        pic2.Margin = new System.Windows.Forms.Padding(8);
                        pic2.Name = "1-" + item.server_id;
                        pic2.Size = new System.Drawing.Size(29, 26);
                        pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        pic2.TabIndex = 0;
                        pic2.TabStop = false;
                        pic2.Click += new System.EventHandler(this.starPic_Click2);
                        pic2.Visible = true;
                        //   pic2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));
                        pic2.Dock = System.Windows.Forms.DockStyle.Top;


                        panelforpic.Controls.Add(pic);
                        panelforpic.Controls.Add(pic2);
                    }
                    else
                    {
                        System.Windows.Forms.PictureBox pic = new PictureBox();
                        pic.BackColor = System.Drawing.Color.LightGray;
                        pic.Image = global::realstate.Properties.Resources.down;
                        pic.Location = new System.Drawing.Point(8, 6);
                        pic.Margin = new System.Windows.Forms.Padding(8);


                        pic.Name = "0-" + item.server_id;
                        pic.Size = new System.Drawing.Size(29, 26);
                        pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        pic.TabIndex = 0;
                        pic.TabStop = false;
                        pic.Click += new System.EventHandler(this.starPic_Click);
                        //pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));
                        pic.Dock = System.Windows.Forms.DockStyle.Top;
                        pic.Visible = true;

                        System.Windows.Forms.PictureBox pic2 = new PictureBox();
                        pic2.BackColor = System.Drawing.Color.LightGray;
                        pic2.Image = global::realstate.Properties.Resources.up;
                        pic2.Location = new System.Drawing.Point(8, 6);
                        pic2.Margin = new System.Windows.Forms.Padding(8);
                        pic2.Name = "1-" + item.server_id;
                        pic2.Size = new System.Drawing.Size(29, 26);
                        pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        pic2.TabIndex = 0;
                        pic2.TabStop = false;
                        pic2.Click += new System.EventHandler(this.starPic_Click2);
                        pic2.Visible = false;
                        //   pic2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));
                        pic2.Dock = System.Windows.Forms.DockStyle.Top;

                        panelforpic.Controls.Add(pic2);
                        panelforpic.Controls.Add(pic);
                    }



                    tableLayoutPanel1.Controls.Add(panelforpic, 0, 0);

                    Telerik.WinControls.UI.RadPanel panelforvadie = new Telerik.WinControls.UI.RadPanel();
                    panelforvadie.BackColor = System.Drawing.Color.Transparent;
                    panelforvadie.Location = new System.Drawing.Point(161, 37);
                    panelforvadie.Name = "panelforvadie";
                    panelforvadie.Size = new System.Drawing.Size(180, 29);
                    panelforvadie.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelforvadie.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforvadie.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                    System.Windows.Forms.Label vadie = new Label();
                    vadie.Dock = System.Windows.Forms.DockStyle.Fill;
                    vadie.BackColor = System.Drawing.Color.Transparent;
                    vadie.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    vadie.Location = new System.Drawing.Point(630, 8);
                    vadie.Name = "vadie";
                    vadie.Size = new System.Drawing.Size(113, 28);
                    vadie.TabIndex = 10;
                    // Port.Text = (8000 + panelForList).ToString();
                    vadie.Text = (item.vadie).ToString();
                    vadie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    vadie.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelforvadie.Controls.Add(vadie);


                    Telerik.WinControls.UI.RadPanel panelforejare = new Telerik.WinControls.UI.RadPanel();
                    panelforejare.BackColor = System.Drawing.Color.Transparent;
                    panelforejare.Location = new System.Drawing.Point(161, 37);
                    panelforejare.Name = "panelforejare";
                    panelforejare.Size = new System.Drawing.Size(180, 29);
                    panelforejare.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelforejare.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforejare.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                    System.Windows.Forms.Label ejare = new Label();
                    ejare.Dock = System.Windows.Forms.DockStyle.Fill;
                    ejare.BackColor = System.Drawing.Color.Transparent;
                    ejare.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ejare.Location = new System.Drawing.Point(630, 8);
                    ejare.Name = "ejare";
                    ejare.Size = new System.Drawing.Size(113, 28);
                    ejare.TabIndex = 10;
                    // Port.Text = (8000 + panelForList).ToString();
                    ejare.Text = (item.ejare).ToString();
                    ejare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    ejare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelforejare.Controls.Add(ejare);

                    Telerik.WinControls.UI.RadPanel panelfortotal = new Telerik.WinControls.UI.RadPanel();
                    panelfortotal.BackColor = System.Drawing.Color.Transparent;
                    panelfortotal.Location = new System.Drawing.Point(161, 37);
                    panelfortotal.Name = "panelfortotal";
                    panelfortotal.Size = new System.Drawing.Size(180, 29);
                    panelfortotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelfortotal.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelfortotal.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                    System.Windows.Forms.Label total = new Label();
                    total.Dock = System.Windows.Forms.DockStyle.Fill;
                    total.BackColor = System.Drawing.Color.Transparent;
                    total.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    total.Location = new System.Drawing.Point(630, 8);
                    total.Name = "total";
                    total.Size = new System.Drawing.Size(113, 28);
                    total.TabIndex = 10;
                    total.Text = (item.total).ToString();
                    total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelfortotal.Controls.Add(total);


                    Telerik.WinControls.UI.RadPanel panelforkind = new Telerik.WinControls.UI.RadPanel();
                    panelforkind.BackColor = System.Drawing.Color.Transparent;
                    panelforkind.Location = new System.Drawing.Point(161, 37);
                    panelforkind.Name = "panelforkind";
                    panelforkind.Size = new System.Drawing.Size(180, 29);
                    panelforkind.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelforkind.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforkind.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                    System.Windows.Forms.Label kindforlist = new Label();
                    kindforlist.Dock = System.Windows.Forms.DockStyle.Fill;
                    kindforlist.BackColor = System.Drawing.Color.Transparent;
                    kindforlist.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    kindforlist.Location = new System.Drawing.Point(630, 8);
                    kindforlist.Name = "kindforlist";
                    kindforlist.Size = new System.Drawing.Size(113, 28);
                    kindforlist.TabIndex = 10;
                    kindforlist.Text = (item.kind).ToString();
                    kindforlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    kindforlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelforkind.Controls.Add(kindforlist);

                    Telerik.WinControls.UI.RadPanel panelfortitleandarea = new Telerik.WinControls.UI.RadPanel();
                    panelfortitleandarea.BackColor = System.Drawing.Color.Transparent;
                    panelfortitleandarea.Location = new System.Drawing.Point(161, 37);
                    panelfortitleandarea.Name = "panelfortitleandarea";
                    panelfortitleandarea.Size = new System.Drawing.Size(180, 29);
                    panelfortitleandarea.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelfortitleandarea.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelfortitleandarea.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    panelfortitleandarea.Dock = System.Windows.Forms.DockStyle.Fill;
                    panelfortitleandarea.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);


                    Telerik.WinControls.UI.RadPanel panelfortitle = new Telerik.WinControls.UI.RadPanel();
                    panelfortitle.BackColor = System.Drawing.Color.Transparent;
                    panelfortitle.Location = new System.Drawing.Point(161, 37);
                    panelfortitle.Name = "panelfortitle";
                    panelfortitle.Size = new System.Drawing.Size(180, 29);
                    panelfortitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelfortitle.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelfortitle.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    panelfortitle.Dock = System.Windows.Forms.DockStyle.Top;

                    Telerik.WinControls.UI.RadPanel panelforarea = new Telerik.WinControls.UI.RadPanel();
                    panelforarea.BackColor = System.Drawing.Color.Transparent;
                    panelforarea.Location = new System.Drawing.Point(161, 37);
                    panelforarea.Name = "panelforarea";
                    panelforarea.Size = new System.Drawing.Size(180, 29);
                    panelforarea.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelforarea.TabIndex = 16;
                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforarea.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    panelforarea.Dock = System.Windows.Forms.DockStyle.Top;

                    System.Windows.Forms.Label titleforlist = new Label();
                    titleforlist.Dock = System.Windows.Forms.DockStyle.Fill;
                    titleforlist.BackColor = System.Drawing.Color.Transparent;
                    titleforlist.ForeColor = System.Drawing.Color.BlueViolet;
                    titleforlist.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    titleforlist.Location = new System.Drawing.Point(630, 8);
                    titleforlist.Name = "titleforlist";
                    titleforlist.Size = new System.Drawing.Size(113, 28);
                    titleforlist.TabIndex = 10;
                    // Port.Text = (8000 + panelForList).ToString();
                    titleforlist.Text = (item.title).ToString();
                    titleforlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    titleforlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelfortitle.Controls.Add(titleforlist);

                    System.Windows.Forms.Label areaforlist = new Label();
                    areaforlist.Dock = System.Windows.Forms.DockStyle.Fill;
                    areaforlist.BackColor = System.Drawing.Color.Transparent;
                    areaforlist.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    areaforlist.Location = new System.Drawing.Point(630, 8);
                    areaforlist.Name = "titleforlist";
                    areaforlist.Size = new System.Drawing.Size(113, 28);
                    areaforlist.TabIndex = 10;
                    // Port.Text = (8000 + panelForList).ToString();
                    areaforlist.Text = (item.area).ToString();
                    areaforlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    areaforlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    panelforarea.Controls.Add(areaforlist);

                    panelfortitleandarea.Controls.Add(panelforarea);
                    panelfortitleandarea.Controls.Add(panelfortitle);



                    tableLayoutPanel1.Controls.Add(panelforejare, 1, 0);
                    tableLayoutPanel1.Controls.Add(panelforvadie, 2, 0);
                    tableLayoutPanel1.Controls.Add(panelfortotal, 3, 0);
                    tableLayoutPanel1.Controls.Add(panelforkind, 4, 0);
                    tableLayoutPanel1.Controls.Add(panelfortitleandarea, 5, 0);

                    tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
                    tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                    //  tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;

                    panelinsed.Controls.Add(tableLayoutPanel1);
                    panel.Controls.Add(panelinsed);

                    Settings1.Default.lastTimeStamp = Convert.ToDateTime(DateTime.Now);
                    Settings1.Default.Save();
                    label22.Text = log.result.today_files.ToString();
                    radScrollablePanel1.Controls.Add(panel);
                    


                    panelForList++;
                }

                
            }
            catch (Exception)
            {
                
                
            }
            refresh.Visible = false;
           
        }
        void getDataFromServer(object sender, DoWorkEventArgs e)
       // private void getDataFromServer(string query)
        {
           
            string query = (string)e.Argument;  
            // فعلاً پورت 8001 باشه
            int port = 8001;
            if (GlobalVariable.port != 0)
            {
                port = GlobalVariable.port;
            }

            TcpClient tcpclnt = new TcpClient();
            try
            {
                tcpclnt.Connect("192.168.0.1", port);
            }
            catch (Exception)
            {
                
                MessageBox.Show("خطا در اتصال به سرور");
                tcpclnt.Close();
                return;
            }


            try
            {
                // use the ipaddress as in the server program
                Console.WriteLine("Connected with port" + port.ToString());
                //Console.Write("Enter the string to be transmitted : ");

                //String str = Console.ReadLine();

                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(query);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);
                string json = "";

                const int blockSize = 100000;
                byte[] buffer = new byte[blockSize];
                int bytesRead;

                while ((bytesRead = stm.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        json = json + Convert.ToChar(buffer[i]);
                    }
                }


             


                e.Result = json;

                //this.radListView1.DataSource = songsDataTableBindingSource;
                //this.radListView1.ColumnCreating += new ListViewColumnCreatingEventHandler(radListView1_ColumnCreating);
                //this.radListView1.ViewType = ListViewType.DetailsView;

                tcpclnt.Close();
                //string result = "";
                //using (WebClient client = new WebClient())
                //{
                //    var collection = new System.Collections.Specialized.NameValueCollection();
                //    collection.Add("category", catof);
                //    collection.Add("cat", kindof);
                //    collection.Add("area", areaaof);
                //    collection.Add("metraj_from", metrajfrom.Text);
                //    collection.Add("metraj_to", metrajto.Text);
                //    collection.Add("vadie_from", vadiefrom.Text);
                //    collection.Add("vadie_to", vadieto.Text);
                //    collection.Add("room", room.Text);
                //    collection.Add("ajare_from", ejarefrom.Text);
                //    collection.Add("ajare_to", ejareto.Text);
                //  //  collection.Add("query", code);

                //    //foreach (var myvalucollection in imaglist) {
                //    //    collection.Add("imaglist[]", myvalucollection);
                //    //}
                //    byte[] response =
                //    client.UploadValues("http://supectco.com/webs/roholah/Main/handler/getMainData.php", collection);

                //    result = System.Text.Encoding.UTF8.GetString(response);
                //}

            }
            catch (Exception)
            {

                MessageBox.Show("خطا در ارتباط با سرور");
             
                tcpclnt.Close();
                return;
            }
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            radPanel12.BackColor = Color.DarkGray;
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            radPanel12.BackColor = Color.Silver;
        }
        private void starPic_Click(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            string name = pic.Name;
            string name2 = "1-" + name.Substring(2, name.Length - 2);
            string id =  name.Substring(2, name.Length - 2);
            var control = this.Controls.Find(name, true).First();
            var control2 = this.Controls.Find(name2, true).First();
            control.Visible = false;
            control2.Visible = true;
            string ideas = Settings1.Default.ides;
            Settings1.Default.ides = ideas + "," + id;
            Settings1.Default.Save();

            
            
        }
        private void starPic_Click2(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            string name = pic.Name;
            string name2 = "0-" + name.Substring(2, name.Length - 2);
            string id = name.Substring(2, name.Length - 2);
            int index = Settings1.Default.ides.LastIndexOf(id);
            Settings1.Default.ides.Remove(index, 6);
            var control = this.Controls.Find(name, true).First();
            var control2 = this.Controls.Find(name2, true).First();
            control.Visible = false;
            control2.Visible = true;


        }
      

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

       
        private void refreshPic_Click(object sender, EventArgs e)
        {
            getDataFromServer();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            getDataFromServer();
        }

        private void dissconnect_Click(object sender, EventArgs e)
        {
            ContinuAllListener = true;
            createBackgroundWorker(GlobalVariable.portlimit);
            connect.Visible = true;
            dissconnect.Visible = false;
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

