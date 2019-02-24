namespace realstate
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadingIMG = new System.Windows.Forms.PictureBox();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.ip = new System.Windows.Forms.TextBox();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.password = new System.Windows.Forms.TextBox();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.username = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Transparent;
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(570, 349);
            this.radPanel1.TabIndex = 100;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.Black;
            this.radPanel2.Controls.Add(this.pictureBox1);
            this.radPanel2.Controls.Add(this.label1);
            this.radPanel2.Controls.Add(this.loadingIMG);
            this.radPanel2.Controls.Add(this.radPanel5);
            this.radPanel2.Controls.Add(this.radPanel4);
            this.radPanel2.Controls.Add(this.radPanel3);
            this.radPanel2.Controls.Add(this.confirm);
            this.radPanel2.Controls.Add(this.label4);
            this.radPanel2.Controls.Add(this.label3);
            this.radPanel2.Controls.Add(this.label2);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(130);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(570, 349);
            this.radPanel2.TabIndex = 99;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(464, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "نسخه 1.6";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingIMG
            // 
            this.loadingIMG.Image = ((System.Drawing.Image)(resources.GetObject("loadingIMG.Image")));
            this.loadingIMG.Location = new System.Drawing.Point(255, 12);
            this.loadingIMG.Name = "loadingIMG";
            this.loadingIMG.Size = new System.Drawing.Size(57, 42);
            this.loadingIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingIMG.TabIndex = 105;
            this.loadingIMG.TabStop = false;
            this.loadingIMG.Visible = false;
            // 
            // radPanel5
            // 
            this.radPanel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.radPanel5.Controls.Add(this.ip);
            this.radPanel5.Location = new System.Drawing.Point(120, 217);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(347, 36);
            this.radPanel5.TabIndex = 103;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel5.GetChildAt(0))).BackColor = System.Drawing.SystemColors.ScrollBar;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel5.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // ip
            // 
            this.ip.AcceptsTab = true;
            this.ip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ip.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.Location = new System.Drawing.Point(25, 5);
            this.ip.Name = "ip";
            this.ip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ip.Size = new System.Drawing.Size(300, 13);
            this.ip.TabIndex = 3;
            this.ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radPanel4
            // 
            this.radPanel4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.radPanel4.Controls.Add(this.password);
            this.radPanel4.Location = new System.Drawing.Point(120, 154);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(347, 36);
            this.radPanel4.TabIndex = 102;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel4.GetChildAt(0))).BackColor = System.Drawing.SystemColors.ScrollBar;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel4.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // password
            // 
            this.password.AcceptsTab = true;
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(25, 5);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.password.Size = new System.Drawing.Size(300, 13);
            this.password.TabIndex = 2;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.UseSystemPasswordChar = true;
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.radPanel3.Controls.Add(this.username);
            this.radPanel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radPanel3.Location = new System.Drawing.Point(120, 88);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.radPanel3.Size = new System.Drawing.Size(347, 36);
            this.radPanel3.TabIndex = 101;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel3.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(5);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel3.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // username
            // 
            this.username.AcceptsTab = true;
            this.username.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(25, 5);
            this.username.Name = "username";
            this.username.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.username.Size = new System.Drawing.Size(300, 13);
            this.username.TabIndex = 1;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.Green;
            this.confirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.FlatAppearance.BorderSize = 0;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("B Nazanin", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(3, 295);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(564, 51);
            this.confirm.TabIndex = 104;
            this.confirm.Text = "تایید";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(404, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = ": آدرس سرور";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(417, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = ": رمز عبور";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(410, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = ": نام کاربری";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(570, 349);
            this.Controls.Add(this.radPanel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            this.radPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button confirm;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private System.Windows.Forms.TextBox username;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private System.Windows.Forms.PictureBox loadingIMG;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}