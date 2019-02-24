using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realstate
{
    public partial class Form3 : Form
    {
        BackgroundWorker ConfirmBG = new BackgroundWorker();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private System.Drawing.Text.PrivateFontCollection fonts = new System.Drawing.Text.PrivateFontCollection();

        Font myFont;
        private void fontload()
        {
            Font lableFont;
            lableFont = new Font(fonts.Families[0], 9.0F);
            label1.Font = lableFont;
            label2.Font = lableFont;
            label3.Font = lableFont;
            label4.Font = lableFont;

            Font textfont;
            textfont = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);
            username.Font = textfont;
            password.Font = textfont;
            ip.Font = textfont;

        }
        public Form3()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fontload();
           

            this.Location = new Point(400, 150); 
            if (Settings1.Default.IsLogedIn == "1")
            {
                Form1 form = new Form1();
                form.Show();

            }
           
           // form.createBackgroundWorker(2);
        }

        
        private void confirm_Click(object sender, EventArgs e)
        {
           
           
            doConfirmProcess();
            //ConfirmBG.DoWork += new DoWorkEventHandler(doConfirmProcess);
           // ConfirmBG.WorkerSupportsCancellation = true;
           // ConfirmBG.RunWorkerAsync(argument: count);
           // ConfirmBG.RunWorkerAsync();
          

        }
        //void doConfirmProcess(object sender, DoWorkEventArgs e)
        //{


        //}
       public void doConfirmProcess()
        {

            username.Enabled = false;
            password.Enabled = false;
            ip.Enabled = false;

            loadingIMG.Visible = true;
            BackgroundWorker checkPassBackGroundWorker = new BackgroundWorker();
            checkPassBackGroundWorker.WorkerSupportsCancellation = true;
            checkPassBackGroundWorker.DoWork += new DoWorkEventHandler(checkPassBackGroundWorker_doWork);
            checkPassBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(checkPassBackGroundWorker_done);

            login model = new login();
            if (password.Text == "" || username.Text == "" || ip.Text == "" )
           {
               MessageBox.Show("لطفاً همه موارد را تکمیل کنید");
               loadingIMG.Visible = false;
           }
           else
	        {
                if (!ip.Text.Contains(":"))
                {
                    MessageBox.Show("آی پی وارد شده صحیح نیست");
                    loadingIMG.Visible = false;
                }
                else
                {
                    model.password = password.Text;
                    model.username = username.Text;
                    model.port = ip.Text;

                    string str = JsonConvert.SerializeObject(model);
                   
                    checkPassBackGroundWorker.RunWorkerAsync(argument: str);
                }
               
	        }
           


        }

       void checkPassBackGroundWorker_doWork(object sender, DoWorkEventArgs e)
       {

           string query = (string)e.Argument;
           login mymodel = JsonConvert.DeserializeObject<login>(query);
         
           string myip = mymodel.port;
           string myusername = mymodel.username;
           string mypassword = mymodel.password;

           int index = myip.IndexOf(":");
           string portstr = myip.Substring(index + 1, myip.Length - index - 1);
           int port = Convert.ToInt32(portstr);
           GlobalVariable.port = port;
           string negip = myip.Substring(0, index);


           TcpClient tcpclnt = new TcpClient();
           try
           {
               tcpclnt.Connect(negip, port);
             

           }

           catch (Exception)
           {
               MessageBox.Show("پاسخی از سرور دریافت نشد");
               tcpclnt.Close();
               return;

           }



           try
           {
               login login = new realstate.login()
               {
                   username = myusername,
                   password = mypassword
               };
               //List<login> list = new List<realstate.login>();
               //list.Add(login);
               //list.Add(login);

               string str = JsonConvert.SerializeObject(login);
               // use the ipaddress as in the server program
               Console.WriteLine("Connected with port" + port.ToString());
               str = "4" + str;
               //Console.Write("Enter the string to be transmitted : ");

               //String str = Console.ReadLine();

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
               loginback response = JsonConvert.DeserializeObject<loginback>(json);
               if (response.status == "Error")
               {
                   loadingIMG.Visible = false;
                   MessageBox.Show("خطای سرور لطفاً مجدداً تلاش کنید");
                   tcpclnt.Close();
                   //"خطای سرور لطفاً مجدداً تلاش کنید";
               }
               else if (response.status == "error2")
               {
                   loadingIMG.Visible = false;
                   MessageBox.Show("رمز عبور یا نام کاربری صحیح نیست");
                   tcpclnt.Close();
               }
               else
               {
                   loginback log = JsonConvert.DeserializeObject<loginback>(json);

                   if (log.status == "success")
                   {
                       Settings1.Default.IsLogedIn = "1";
                       GlobalVariable.catsAndAreas = log.autocompleteObject;
                       GlobalVariable.token = log.token;
                       tcpclnt.Close();
                       //ConfirmBG.CancelAsync();
                       
                       e.Result = "change";
                      

                   }
                   else
                   {
                       tcpclnt.Close();

                   }
               }
           }
           catch (Exception)
           {

               MessageBox.Show("خطا در برقراری ارتباط با سرور");
               tcpclnt.Close();
               return;
           }
           

       }
       private void checkPassBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
       {

           if (e.Result == "change")
           {
               loadingIMG.Visible = false;
               username.Enabled = true;
               password.Enabled = true;
               ip.Enabled = true;
               Form1 form1 = new Form1();
               form1.Show();
               loadingIMG.Visible = false;
               this.Visible = false;
                   
           }
           else
           {
               loadingIMG.Visible = false;
               username.Enabled = true;
               password.Enabled = true;
               ip.Enabled = true;
           }
       

          
       }

      

      


       




    }
}
