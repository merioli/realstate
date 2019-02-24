using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace realstate
{
    public partial class Form4 : Form
    {

        List<TextBox> nameList = new List<TextBox>();
        List<TextBox> usernameList = new List<TextBox>();
        List<TextBox> passList = new List<TextBox>();
        List<int > portList = new List<int>();

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

        public Form4()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            if (Settings1.Default.ServerIP != null)
            {
                ipholder.Text = Settings1.Default.ServerIP;
            }
           
            PanelOne.PanelElement.Shape = new RoundRectShape();
            PanelOne.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            PanelOne.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            PanelTwo.PanelElement.Shape = new RoundRectShape();
            PanelTwo.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            PanelTwo.PanelElement.PanelFill.BackColor = Color.WhiteSmoke;

            string json = "";
            while (true)
            {
                try
                {
                    string filepath = Path.Combine(Application.StartupPath, "Resources", "text.txt");
                    json = System.IO.File.ReadAllText(filepath);
                    break;
                }
                catch (Exception)
                {

                }
            }
            List<login> mymodel = new List<login>();
            if (json != "")
            {
                mymodel = JsonConvert.DeserializeObject<List<login>>(json);
            }
         

            int k = 0;
            for (int i = GlobalVariable.portlimit; i > 0; i--)
            {
               
                string name = "panel" + i;
                Telerik.WinControls.UI.RadPanel panel = new Telerik.WinControls.UI.RadPanel();
                panel.Dock = System.Windows.Forms.DockStyle.Top;
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Name = name;
                panel.Size = new System.Drawing.Size(729, 50);
                ((Telerik.WinControls.Primitives.BorderPrimitive)(panel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                System.Windows.Forms.TableLayoutPanel tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                tableLayoutPanel1.ColumnCount = 5;
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
                tableLayoutPanel1.RowCount = 1;
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                tableLayoutPanel1.Name = "tableLayoutPanel1";
                for (int j = 1; j < 4; j++)
                {

                    Telerik.WinControls.UI.RadPanel panelfortable = new Telerik.WinControls.UI.RadPanel();
                    panelfortable.BackColor = System.Drawing.SystemColors.ScrollBar;

                    System.Windows.Forms.TextBox textBox6 = new TextBox();
                    textBox6.BackColor = System.Drawing.SystemColors.ScrollBar;
                    textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    textBox6.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    textBox6.Location = new System.Drawing.Point(12, 2);
                    textBox6.Name = "textBox6";
                    textBox6.Size = new System.Drawing.Size(149, 23);
                    textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                    textBox6.TabIndex = 1;
                   


                    panelfortable.Controls.Add(textBox6);
                    panelfortable.Location = new System.Drawing.Point(161, 37);
                    panelfortable.BackColor = System.Drawing.SystemColors.ScrollBar;
                    panelfortable.Name = "panelfortable";
                    panelfortable.Size = new System.Drawing.Size(180, 29);
                    panelfortable.Anchor = System.Windows.Forms.AnchorStyles.Right;
                    panelfortable.TabIndex = 16;
                    panelfortable.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
                    //panelfortable.BackColor = System.Drawing.Color.Transparent;

                    ((Telerik.WinControls.Primitives.BorderPrimitive)(panelfortable.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    // panelfortable.Dock = System.Windows.Forms.DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(panelfortable, j, 0);
                    if (j == 1)
                    {
                        string tab = i.ToString() + "4";
                        textBox6.TabIndex = Convert.ToInt32(tab) ;
                        if (k < mymodel.Count)
                        {
                            textBox6.Text = mymodel[k].name;
                        }
                        else
                        {
                            textBox6.Text = "";
                        }
                       nameList.Add(textBox6);
                    }
                    else if (j == 2)
                    {
                        string tab = i.ToString() + "3";
                        textBox6.TabIndex = Convert.ToInt32(tab);

                        if (k < mymodel.Count)
                        {
                            textBox6.Text = mymodel[k].username;
                        }
                        else
                        {
                            textBox6.Text = "";
                        }
                        usernameList.Add(textBox6);
                    }
                    else if (j == 3)
                    {
                        string tab = i.ToString() + "2";
                        textBox6.TabIndex = Convert.ToInt32(tab);

                        if (k < mymodel.Count)
                        {
                            textBox6.Text = mymodel[k].password;
                        }
                        else
                        {
                            textBox6.Text = "";
                        }
                        passList.Add(textBox6);
                    }
                  

                }
                System.Windows.Forms.Label number = new Label();
                number.Anchor = System.Windows.Forms.AnchorStyles.Right;
                number.BackColor = System.Drawing.Color.Transparent;
                number.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                number.Location = new System.Drawing.Point(630, 8);
                number.Name = "number";
                number.Size = new System.Drawing.Size(113, 28);
                number.TabIndex = 10;
                number.Text = i.ToString();
                number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tableLayoutPanel1.Controls.Add(number, 0, 0);

                Telerik.WinControls.UI.RadPanel panelforport = new Telerik.WinControls.UI.RadPanel();
                panelforport.BackColor = System.Drawing.SystemColors.ScrollBar;
                panelforport.Location = new System.Drawing.Point(161, 37);
                panelforport.Name = "panelfortable";
                panelforport.Size = new System.Drawing.Size(180, 29);
                panelforport.Anchor = System.Windows.Forms.AnchorStyles.Right;
                panelforport.TabIndex = 16;
                ((Telerik.WinControls.Primitives.BorderPrimitive)(panelforport.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

                System.Windows.Forms.Label Port = new Label();
                Port.Dock = System.Windows.Forms.DockStyle.Fill;
                Port.BackColor = System.Drawing.Color.Transparent;
                Port.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                Port.Location = new System.Drawing.Point(630, 8);
                Port.Name = "Port";
                Port.Size = new System.Drawing.Size(113, 28);
                Port.TabIndex = 10;
                Port.Text = (8000 + i).ToString();
                Port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                panelforport.Controls.Add(Port);
                portList.Add(8000 + i);
                tableLayoutPanel1.Controls.Add(panelforport, 4, 0);
                tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;

                tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                //  tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;

                panel.Controls.Add(tableLayoutPanel1);
                PanelOfDynamicData.Controls.Add(panel);
                k++;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            List<login> list = new List<login>();
         
            int mesure = nameList.Count();

            for (int count = 0; count < nameList.Count; count++)
            {
                login row = new login();
                row.port = portList[count].ToString();
                row.password = passList[count].Text;
                row.name = nameList[count].Text; 
                row.username = usernameList[count].Text;
                list.Add(row);
            }
            string jsonmodel = JsonConvert.SerializeObject(list);
           
            
            while (true)
            {
                try
                {
                    string filepath = Path.Combine(Application.StartupPath, "Resources", "text.txt");
                    System.IO.File.WriteAllText(filepath, jsonmodel);
                    MessageBox.Show("تغییرات مورد نظر با موفقیت انجام شد");
                    break;
                }
                catch (Exception)
                {

                }
            }

        }

 

        private void label5_Click(object sender, EventArgs e)
        {
            string text = ipholder.Text;
            Settings1.Default.ServerIP = text;
            Settings1.Default.Save();
            MessageBox.Show(" آی سرور با موفقیت تنظیم شد");
        }




    }
}
