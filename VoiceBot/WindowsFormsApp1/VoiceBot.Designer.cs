namespace WindowsFormsApp1
{
    partial class Bot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bot));
            this.yourcommands = new System.Windows.Forms.TextBox();
            this.stylebox = new System.Windows.Forms.ComboBox();
            this.voicebox = new System.Windows.Forms.ComboBox();
            this.quitbtn = new System.Windows.Forms.Button();
            this.minimizebtn = new System.Windows.Forms.Button();
            this.maintxtbox = new System.Windows.Forms.TextBox();
            this.sendbtn = new System.Windows.Forms.Button();
            this.Titlelbl = new System.Windows.Forms.Label();
            this.response = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.helpbtn = new System.Windows.Forms.Button();
            this.robotpicture4 = new System.Windows.Forms.PictureBox();
            this.robotpicture3 = new System.Windows.Forms.PictureBox();
            this.robotpicture2 = new System.Windows.Forms.PictureBox();
            this.pause = new System.Windows.Forms.Button();
            this.last = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PDF_BUTTON = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Pausepdfbtn = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture2)).BeginInit();
            this.SuspendLayout();
            // 
            // yourcommands
            // 
            this.yourcommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.yourcommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yourcommands.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.yourcommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.yourcommands.Location = new System.Drawing.Point(12, 31);
            this.yourcommands.Multiline = true;
            this.yourcommands.Name = "yourcommands";
            this.yourcommands.ReadOnly = true;
            this.yourcommands.Size = new System.Drawing.Size(144, 316);
            this.yourcommands.TabIndex = 1;
            // 
            // stylebox
            // 
            this.stylebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.stylebox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stylebox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.stylebox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.stylebox.FormattingEnabled = true;
            this.stylebox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stylebox.Items.AddRange(new object[] {
            "Standard",
            "Alternative",
            "Standout"});
            this.stylebox.Location = new System.Drawing.Point(476, 377);
            this.stylebox.Name = "stylebox";
            this.stylebox.Size = new System.Drawing.Size(113, 21);
            this.stylebox.TabIndex = 12;
            this.stylebox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // voicebox
            // 
            this.voicebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.voicebox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.voicebox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voicebox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.voicebox.FormattingEnabled = true;
            this.voicebox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.voicebox.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Old Male",
            "Old Female"});
            this.voicebox.Location = new System.Drawing.Point(476, 350);
            this.voicebox.Name = "voicebox";
            this.voicebox.Size = new System.Drawing.Size(113, 21);
            this.voicebox.TabIndex = 13;
            this.voicebox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // quitbtn
            // 
            this.quitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.quitbtn.FlatAppearance.BorderSize = 0;
            this.quitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitbtn.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.quitbtn.Location = new System.Drawing.Point(565, 5);
            this.quitbtn.Name = "quitbtn";
            this.quitbtn.Size = new System.Drawing.Size(25, 21);
            this.quitbtn.TabIndex = 14;
            this.quitbtn.Text = "X";
            this.quitbtn.UseVisualStyleBackColor = true;
            this.quitbtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // minimizebtn
            // 
            this.minimizebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizebtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.minimizebtn.FlatAppearance.BorderSize = 0;
            this.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebtn.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.minimizebtn.Location = new System.Drawing.Point(547, 5);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(25, 22);
            this.minimizebtn.TabIndex = 15;
            this.minimizebtn.Text = "-";
            this.minimizebtn.UseVisualStyleBackColor = true;
            this.minimizebtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // maintxtbox
            // 
            this.maintxtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(68)))));
            this.maintxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maintxtbox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.maintxtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.maintxtbox.Location = new System.Drawing.Point(14, 374);
            this.maintxtbox.Name = "maintxtbox";
            this.maintxtbox.Size = new System.Drawing.Size(234, 21);
            this.maintxtbox.TabIndex = 16;
            // 
            // sendbtn
            // 
            this.sendbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(68)))));
            this.sendbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sendbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.sendbtn.FlatAppearance.BorderSize = 0;
            this.sendbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.sendbtn.Location = new System.Drawing.Point(254, 374);
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sendbtn.Size = new System.Drawing.Size(40, 20);
            this.sendbtn.TabIndex = 17;
            this.sendbtn.Text = "Send";
            this.sendbtn.UseVisualStyleBackColor = false;
            this.sendbtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // Titlelbl
            // 
            this.Titlelbl.AutoSize = true;
            this.Titlelbl.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Titlelbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.Titlelbl.Location = new System.Drawing.Point(11, 9);
            this.Titlelbl.Name = "Titlelbl";
            this.Titlelbl.Size = new System.Drawing.Size(69, 14);
            this.Titlelbl.TabIndex = 18;
            this.Titlelbl.Text = "Voice Bot";
            // 
            // response
            // 
            this.response.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.response.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.response.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.response.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.response.Location = new System.Drawing.Point(154, 31);
            this.response.Multiline = true;
            this.response.Name = "response";
            this.response.ReadOnly = true;
            this.response.Size = new System.Drawing.Size(147, 316);
            this.response.TabIndex = 23;
            this.response.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(68)))));
            this.pictureBox1.Controls.Add(this.flowLayoutPanel1);
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 367);
            this.pictureBox1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(68)))));
            this.flowLayoutPanel1.Controls.Add(this.axAcroPDF1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(286, 367);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(3, 3);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(274, 310);
            this.axAcroPDF1.TabIndex = 27;
            this.axAcroPDF1.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(363, 348);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(20, 20);
            this.webBrowser1.TabIndex = 26;
            this.webBrowser1.TabStop = false;
            // 
            // helpbtn
            // 
            this.helpbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.helpbtn.FlatAppearance.BorderSize = 0;
            this.helpbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpbtn.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.helpbtn.Location = new System.Drawing.Point(532, 2);
            this.helpbtn.Name = "helpbtn";
            this.helpbtn.Size = new System.Drawing.Size(23, 23);
            this.helpbtn.TabIndex = 25;
            this.helpbtn.Text = "?";
            this.helpbtn.UseVisualStyleBackColor = true;
            this.helpbtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // robotpicture4
            // 
            this.robotpicture4.BackgroundImage = global::VoiceBOT.Properties.Resources.r2d2_512;
            this.robotpicture4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.robotpicture4.Location = new System.Drawing.Point(337, 41);
            this.robotpicture4.Name = "robotpicture4";
            this.robotpicture4.Size = new System.Drawing.Size(83, 79);
            this.robotpicture4.TabIndex = 21;
            this.robotpicture4.TabStop = false;
            // 
            // robotpicture3
            // 
            this.robotpicture3.BackgroundImage = global::VoiceBOT.Properties.Resources._1600;
            this.robotpicture3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.robotpicture3.Location = new System.Drawing.Point(337, 315);
            this.robotpicture3.Name = "robotpicture3";
            this.robotpicture3.Size = new System.Drawing.Size(83, 79);
            this.robotpicture3.TabIndex = 20;
            this.robotpicture3.TabStop = false;
            // 
            // robotpicture2
            // 
            this.robotpicture2.BackgroundImage = global::VoiceBOT.Properties.Resources._584599c0bcb9df443a7fb797;
            this.robotpicture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.robotpicture2.Location = new System.Drawing.Point(486, 41);
            this.robotpicture2.Name = "robotpicture2";
            this.robotpicture2.Size = new System.Drawing.Size(83, 79);
            this.robotpicture2.TabIndex = 19;
            this.robotpicture2.TabStop = false;
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pause.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.pause.Location = new System.Drawing.Point(476, 286);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(114, 26);
            this.pause.TabIndex = 27;
            this.pause.Text = "Pause Music";
            this.pause.UseVisualStyleBackColor = false;
            this.pause.Visible = false;
            this.pause.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // last
            // 
            this.last.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.last.Location = new System.Drawing.Point(476, 254);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(51, 26);
            this.last.TabIndex = 28;
            this.last.Text = "Last";
            this.last.UseVisualStyleBackColor = false;
            this.last.Visible = false;
            this.last.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.next.Location = new System.Drawing.Point(533, 254);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(57, 26);
            this.next.TabIndex = 29;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = false;
            this.next.Visible = false;
            this.next.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.label1.Location = new System.Drawing.Point(12, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 18);
            this.label1.TabIndex = 30;
            // 
            // PDF_BUTTON
            // 
            this.PDF_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.PDF_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDF_BUTTON.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDF_BUTTON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.PDF_BUTTON.Location = new System.Drawing.Point(476, 318);
            this.PDF_BUTTON.Name = "PDF_BUTTON";
            this.PDF_BUTTON.Size = new System.Drawing.Size(41, 26);
            this.PDF_BUTTON.TabIndex = 31;
            this.PDF_BUTTON.Text = "PDF";
            this.PDF_BUTTON.UseVisualStyleBackColor = false;
            this.PDF_BUTTON.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pausepdfbtn
            // 
            this.Pausepdfbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.Pausepdfbtn.Enabled = false;
            this.Pausepdfbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pausepdfbtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pausepdfbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(117)))), ((int)(((byte)(252)))));
            this.Pausepdfbtn.Location = new System.Drawing.Point(523, 318);
            this.Pausepdfbtn.Name = "Pausepdfbtn";
            this.Pausepdfbtn.Size = new System.Drawing.Size(66, 26);
            this.Pausepdfbtn.TabIndex = 32;
            this.Pausepdfbtn.Text = "Pause";
            this.Pausepdfbtn.UseVisualStyleBackColor = false;
            this.Pausepdfbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Bot
            // 
            this.AcceptButton = this.sendbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 410);
            this.Controls.Add(this.Pausepdfbtn);
            this.Controls.Add(this.PDF_BUTTON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.last);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.helpbtn);
            this.Controls.Add(this.robotpicture4);
            this.Controls.Add(this.robotpicture3);
            this.Controls.Add(this.robotpicture2);
            this.Controls.Add(this.Titlelbl);
            this.Controls.Add(this.sendbtn);
            this.Controls.Add(this.maintxtbox);
            this.Controls.Add(this.minimizebtn);
            this.Controls.Add(this.quitbtn);
            this.Controls.Add(this.voicebox);
            this.Controls.Add(this.stylebox);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.response);
            this.Controls.Add(this.yourcommands);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(595, 410);
            this.Name = "Bot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voice bot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bot_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pictureBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.robotpicture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox yourcommands;
        private System.Windows.Forms.ComboBox stylebox;
        private System.Windows.Forms.ComboBox voicebox;
        private System.Windows.Forms.Button quitbtn;
        private System.Windows.Forms.Button minimizebtn;
        private System.Windows.Forms.TextBox maintxtbox;
        private System.Windows.Forms.Button sendbtn;
        private System.Windows.Forms.Label Titlelbl;
        private System.Windows.Forms.PictureBox robotpicture2;
        private System.Windows.Forms.PictureBox robotpicture3;
        private System.Windows.Forms.PictureBox robotpicture4;
        private System.Windows.Forms.TextBox response;
        private System.Windows.Forms.FlowLayoutPanel pictureBox1;
        private System.Windows.Forms.Button helpbtn;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button last;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PDF_BUTTON;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Pausepdfbtn;
        private System.Windows.Forms.Timer timer2;
    }
}

