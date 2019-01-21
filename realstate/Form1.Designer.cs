namespace realstate
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new Telerik.WinControls.UI.RadPanel();
            this.leftTableForMenu = new System.Windows.Forms.TableLayoutPanel();
            this.Row1OfMenuTable = new System.Windows.Forms.TableLayoutPanel();
            this.MenuIcon = new System.Windows.Forms.PictureBox();
            this.SearchPanel = new Telerik.WinControls.UI.RadPanel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.FilterPanel = new Telerik.WinControls.UI.RadPanel();
            this.panelOfFilterArrow = new Telerik.WinControls.UI.RadPanel();
            this.upPic = new System.Windows.Forms.PictureBox();
            this.filterdesc = new System.Windows.Forms.Label();
            this.downPic = new System.Windows.Forms.PictureBox();
            this.FilterDetailPanel = new Telerik.WinControls.UI.RadPanel();
            this.menuPanel = new Telerik.WinControls.UI.RadPanel();
            this.mainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).BeginInit();
            this.LeftPanel.SuspendLayout();
            this.leftTableForMenu.SuspendLayout();
            this.Row1OfMenuTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPanel)).BeginInit();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPanel)).BeginInit();
            this.FilterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOfFilterArrow)).BeginInit();
            this.panelOfFilterArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDetailPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainTable.ColumnCount = 2;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.91803F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.08197F));
            this.mainTable.Controls.Add(this.LeftPanel, 0, 0);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 1;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Size = new System.Drawing.Size(854, 607);
            this.mainTable.TabIndex = 0;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.menuPanel);
            this.LeftPanel.Controls.Add(this.leftTableForMenu);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(462, 601);
            this.LeftPanel.TabIndex = 2;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.LeftPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // leftTableForMenu
            // 
            this.leftTableForMenu.ColumnCount = 1;
            this.leftTableForMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableForMenu.Controls.Add(this.Row1OfMenuTable, 0, 0);
            this.leftTableForMenu.Controls.Add(this.FilterPanel, 0, 1);
            this.leftTableForMenu.Location = new System.Drawing.Point(3, 0);
            this.leftTableForMenu.Name = "leftTableForMenu";
            this.leftTableForMenu.RowCount = 2;
            this.leftTableForMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.leftTableForMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.leftTableForMenu.Size = new System.Drawing.Size(462, 601);
            this.leftTableForMenu.TabIndex = 0;
            // 
            // Row1OfMenuTable
            // 
            this.Row1OfMenuTable.ColumnCount = 2;
            this.Row1OfMenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.67832F));
            this.Row1OfMenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.32168F));
            this.Row1OfMenuTable.Controls.Add(this.MenuIcon, 0, 0);
            this.Row1OfMenuTable.Controls.Add(this.SearchPanel, 1, 0);
            this.Row1OfMenuTable.Location = new System.Drawing.Point(3, 3);
            this.Row1OfMenuTable.Name = "Row1OfMenuTable";
            this.Row1OfMenuTable.RowCount = 1;
            this.Row1OfMenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Row1OfMenuTable.Size = new System.Drawing.Size(391, 54);
            this.Row1OfMenuTable.TabIndex = 0;
            // 
            // MenuIcon
            // 
            this.MenuIcon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MenuIcon.Image = global::realstate.Properties.Resources.iconfinder_menu_alt_134216;
            this.MenuIcon.Location = new System.Drawing.Point(23, 17);
            this.MenuIcon.Margin = new System.Windows.Forms.Padding(8);
            this.MenuIcon.Name = "MenuIcon";
            this.MenuIcon.Size = new System.Drawing.Size(37, 29);
            this.MenuIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuIcon.TabIndex = 0;
            this.MenuIcon.TabStop = false;
            this.MenuIcon.Click += new System.EventHandler(this.MenuIcon_Click);
            // 
            // SearchPanel
            // 
            this.SearchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchPanel.Controls.Add(this.searchTextBox);
            this.SearchPanel.Controls.Add(this.pictureBox1);
            this.SearchPanel.Location = new System.Drawing.Point(84, 17);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(300, 37);
            this.SearchPanel.TabIndex = 1;
            ((Telerik.WinControls.UI.RadPanelElement)(this.SearchPanel.GetChildAt(0))).Shape = this.roundRectShape1;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.SearchPanel.GetChildAt(0).GetChildAt(0))).Shape = this.roundRectShape1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.SearchPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.Color.LightGray;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.searchTextBox.Location = new System.Drawing.Point(44, 5);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(8);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchTextBox.Size = new System.Drawing.Size(352, 24);
            this.searchTextBox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Image = global::realstate.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(8, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // roundRectShape1
            // 
            this.roundRectShape1.IsRightToLeft = false;
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.panelOfFilterArrow);
            this.FilterPanel.Controls.Add(this.FilterDetailPanel);
            this.FilterPanel.Location = new System.Drawing.Point(3, 63);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(456, 535);
            this.FilterPanel.TabIndex = 1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.FilterPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // panelOfFilterArrow
            // 
            this.panelOfFilterArrow.Controls.Add(this.upPic);
            this.panelOfFilterArrow.Controls.Add(this.filterdesc);
            this.panelOfFilterArrow.Controls.Add(this.downPic);
            this.panelOfFilterArrow.Location = new System.Drawing.Point(11, 0);
            this.panelOfFilterArrow.Name = "panelOfFilterArrow";
            this.panelOfFilterArrow.Size = new System.Drawing.Size(373, 49);
            this.panelOfFilterArrow.TabIndex = 1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.panelOfFilterArrow.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            // 
            // upPic
            // 
            this.upPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.upPic.BackColor = System.Drawing.Color.LightGray;
            this.upPic.Image = global::realstate.Properties.Resources.up;
            this.upPic.Location = new System.Drawing.Point(7, 12);
            this.upPic.Name = "upPic";
            this.upPic.Size = new System.Drawing.Size(35, 26);
            this.upPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upPic.TabIndex = 2;
            this.upPic.TabStop = false;
            this.upPic.Click += new System.EventHandler(this.upPic_Click);
            // 
            // filterdesc
            // 
            this.filterdesc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.filterdesc.AutoSize = true;
            this.filterdesc.BackColor = System.Drawing.Color.LightGray;
            this.filterdesc.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.filterdesc.Location = new System.Drawing.Point(244, 11);
            this.filterdesc.Name = "filterdesc";
            this.filterdesc.Size = new System.Drawing.Size(120, 28);
            this.filterdesc.TabIndex = 0;
            this.filterdesc.Text = "جستجوی پیشرفته";
            // 
            // downPic
            // 
            this.downPic.BackColor = System.Drawing.Color.LightGray;
            this.downPic.Image = global::realstate.Properties.Resources.down1;
            this.downPic.Location = new System.Drawing.Point(5, 12);
            this.downPic.Name = "downPic";
            this.downPic.Size = new System.Drawing.Size(37, 27);
            this.downPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.downPic.TabIndex = 1;
            this.downPic.TabStop = false;
            this.downPic.Click += new System.EventHandler(this.downPic_Click);
            // 
            // FilterDetailPanel
            // 
            this.FilterDetailPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FilterDetailPanel.Location = new System.Drawing.Point(11, 58);
            this.FilterDetailPanel.Name = "FilterDetailPanel";
            this.FilterDetailPanel.Size = new System.Drawing.Size(373, 386);
            this.FilterDetailPanel.TabIndex = 1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.FilterDetailPanel.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.FilterDetailPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuPanel.Location = new System.Drawing.Point(3, 17);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(207, 601);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Click += new System.EventHandler(this.menuPanel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 607);
            this.Controls.Add(this.mainTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.leftTableForMenu.ResumeLayout(false);
            this.Row1OfMenuTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPanel)).EndInit();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPanel)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelOfFilterArrow)).EndInit();
            this.panelOfFilterArrow.ResumeLayout(false);
            this.panelOfFilterArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDetailPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.TableLayoutPanel leftTableForMenu;
        private System.Windows.Forms.TableLayoutPanel Row1OfMenuTable;
        private System.Windows.Forms.PictureBox MenuIcon;
        private Telerik.WinControls.UI.RadPanel SearchPanel;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchTextBox;
        private Telerik.WinControls.UI.RadPanel menuPanel;
        private Telerik.WinControls.UI.RadPanel LeftPanel;
        private Telerik.WinControls.UI.RadPanel FilterPanel;
        private System.Windows.Forms.PictureBox downPic;
        private System.Windows.Forms.Label filterdesc;
        private System.Windows.Forms.PictureBox upPic;
        private Telerik.WinControls.UI.RadPanel FilterDetailPanel;
        private Telerik.WinControls.UI.RadPanel panelOfFilterArrow;
    }
}

