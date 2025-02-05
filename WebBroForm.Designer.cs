namespace WebLoader
{
    partial class WebBroForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBroForm));
            myBrowser = new WebBrowser();
            myAddrBar = new TextBox();
            btnHome = new Button();
            btnGoTo = new Button();
            btnBack = new Button();
            lboxRecent = new ListBox();
            lblWorking = new Label();
            btnStopLoad = new Button();
            btnScriptOK = new Button();
            lblCheckedOn = new Label();
            btnHistory = new Button();
            picLoading = new PictureBox();
            lblStatus = new Label();
            dlgGetFont = new FontDialog();
            btnFont = new Button();
            tmrPopUps = new System.Windows.Forms.Timer(components);
            cbSaveOfflineFile = new CheckBox();
            tmrReroute = new System.Windows.Forms.Timer(components);
            toolTipStop = new ToolTip(components);
            btnFav = new Button();
            imgLstars = new ImageList(components);
            btnAddHome = new Button();
            tmrShowAddHome = new System.Windows.Forms.Timer(components);
            tmrNavDone = new System.Windows.Forms.Timer(components);
            btnSearchEng = new Button();
            ((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
            SuspendLayout();
            // 
            // myBrowser
            // 
            myBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            myBrowser.Location = new Point(13, 40);
            myBrowser.Margin = new Padding(4, 6, 4, 6);
            myBrowser.MinimumSize = new Size(33, 39);
            myBrowser.Name = "myBrowser";
            myBrowser.ScriptErrorsSuppressed = true;
            myBrowser.Size = new Size(1292, 972);
            myBrowser.TabIndex = 0;
            myBrowser.DocumentCompleted += myBrowser_DocumentCompleted;
            myBrowser.Navigated += myBrowser_Navigated;
            myBrowser.Navigating += myBrowser_Navigating;
            // 
            // myAddrBar
            // 
            myAddrBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            myAddrBar.Location = new Point(91, 4);
            myAddrBar.Margin = new Padding(4, 6, 4, 6);
            myAddrBar.Name = "myAddrBar";
            myAddrBar.Size = new Size(1051, 31);
            myAddrBar.TabIndex = 1;
            myAddrBar.Click += myAddrBar_Click;
            // 
            // btnHome
            // 
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(4, 6, 4, 6);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(47, 39);
            btnHome.TabIndex = 2;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnGoTo
            // 
            btnGoTo.Image = (Image)resources.GetObject("btnGoTo.Image");
            btnGoTo.Location = new Point(44, 0);
            btnGoTo.Margin = new Padding(4, 6, 4, 6);
            btnGoTo.Name = "btnGoTo";
            btnGoTo.Size = new Size(47, 39);
            btnGoTo.TabIndex = 3;
            btnGoTo.UseVisualStyleBackColor = true;
            btnGoTo.Click += btnGoTo_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(1277, 0);
            btnBack.Margin = new Padding(4, 6, 4, 6);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(47, 39);
            btnBack.TabIndex = 4;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lboxRecent
            // 
            lboxRecent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lboxRecent.FormattingEnabled = true;
            lboxRecent.ItemHeight = 25;
            lboxRecent.Location = new Point(659, 0);
            lboxRecent.Margin = new Padding(4, 6, 4, 6);
            lboxRecent.Name = "lboxRecent";
            lboxRecent.Size = new Size(657, 329);
            lboxRecent.TabIndex = 5;
            lboxRecent.Visible = false;
            lboxRecent.Click += lboxRecent_Click;
            // 
            // lblWorking
            // 
            lblWorking.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWorking.AutoSize = true;
            lblWorking.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblWorking.Location = new Point(962, 48);
            lblWorking.Margin = new Padding(4, 0, 4, 0);
            lblWorking.Name = "lblWorking";
            lblWorking.Size = new Size(278, 55);
            lblWorking.TabIndex = 6;
            lblWorking.Text = "Working . . .";
            // 
            // btnStopLoad
            // 
            btnStopLoad.Image = (Image)resources.GetObject("btnStopLoad.Image");
            btnStopLoad.Location = new Point(43, 0);
            btnStopLoad.Margin = new Padding(4, 6, 4, 6);
            btnStopLoad.Name = "btnStopLoad";
            btnStopLoad.Size = new Size(47, 39);
            btnStopLoad.TabIndex = 7;
            toolTipStop.SetToolTip(btnStopLoad, "Stop Loading");
            btnStopLoad.UseVisualStyleBackColor = true;
            btnStopLoad.Click += btnStopLoad_Click;
            // 
            // btnScriptOK
            // 
            btnScriptOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScriptOK.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnScriptOK.Image = (Image)resources.GetObject("btnScriptOK.Image");
            btnScriptOK.Location = new Point(1187, 0);
            btnScriptOK.Margin = new Padding(4, 6, 4, 6);
            btnScriptOK.Name = "btnScriptOK";
            btnScriptOK.Size = new Size(47, 39);
            btnScriptOK.TabIndex = 8;
            btnScriptOK.UseVisualStyleBackColor = true;
            btnScriptOK.Click += btnScriptOK_Click;
            // 
            // lblCheckedOn
            // 
            lblCheckedOn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCheckedOn.BackColor = Color.Olive;
            lblCheckedOn.Location = new Point(1193, 40);
            lblCheckedOn.Margin = new Padding(4, 0, 4, 0);
            lblCheckedOn.Name = "lblCheckedOn";
            lblCheckedOn.Size = new Size(33, 11);
            lblCheckedOn.TabIndex = 9;
            lblCheckedOn.Visible = false;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHistory.Location = new Point(1283, 2);
            btnHistory.Margin = new Padding(4, 6, 4, 6);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(33, 44);
            btnHistory.TabIndex = 10;
            btnHistory.Text = "H";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Visible = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // picLoading
            // 
            picLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picLoading.Image = (Image)resources.GetObject("picLoading.Image");
            picLoading.Location = new Point(360, 341);
            picLoading.Margin = new Padding(4, 6, 4, 6);
            picLoading.Name = "picLoading";
            picLoading.Size = new Size(200, 200);
            picLoading.SizeMode = PictureBoxSizeMode.AutoSize;
            picLoading.TabIndex = 11;
            picLoading.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(0, 1018);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1292, 31);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Ready";
            // 
            // dlgGetFont
            // 
            dlgGetFont.Color = Color.White;
            dlgGetFont.FontMustExist = true;
            // 
            // btnFont
            // 
            btnFont.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFont.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFont.Image = (Image)resources.GetObject("btnFont.Image");
            btnFont.Location = new Point(1231, 0);
            btnFont.Margin = new Padding(4, 6, 4, 6);
            btnFont.Name = "btnFont";
            btnFont.Size = new Size(47, 39);
            btnFont.TabIndex = 14;
            btnFont.UseVisualStyleBackColor = true;
            btnFont.Click += btnFont_Click;
            // 
            // tmrPopUps
            // 
            tmrPopUps.Interval = 10000;
            tmrPopUps.Tick += tmrPopUps_Tick;
            // 
            // cbSaveOfflineFile
            // 
            cbSaveOfflineFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbSaveOfflineFile.AutoSize = true;
            cbSaveOfflineFile.Location = new Point(1116, 48);
            cbSaveOfflineFile.Margin = new Padding(3, 4, 3, 4);
            cbSaveOfflineFile.Name = "cbSaveOfflineFile";
            cbSaveOfflineFile.RightToLeft = RightToLeft.Yes;
            cbSaveOfflineFile.Size = new Size(164, 29);
            cbSaveOfflineFile.TabIndex = 15;
            cbSaveOfflineFile.Text = "Save Offline File";
            cbSaveOfflineFile.UseVisualStyleBackColor = true;
            cbSaveOfflineFile.Visible = false;
            // 
            // tmrReroute
            // 
            tmrReroute.Interval = 2000;
            tmrReroute.Tick += tmrReroute_Tick;
            // 
            // btnFav
            // 
            btnFav.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFav.ImageIndex = 0;
            btnFav.ImageList = imgLstars;
            btnFav.Location = new Point(1141, 0);
            btnFav.Name = "btnFav";
            btnFav.Size = new Size(47, 39);
            btnFav.TabIndex = 16;
            btnFav.UseVisualStyleBackColor = true;
            btnFav.Click += btnFav_Click;
            // 
            // imgLstars
            // 
            imgLstars.ColorDepth = ColorDepth.Depth8Bit;
            imgLstars.ImageStream = (ImageListStreamer)resources.GetObject("imgLstars.ImageStream");
            imgLstars.TransparentColor = Color.Transparent;
            imgLstars.Images.SetKeyName(0, "SmStar.jpg");
            imgLstars.Images.SetKeyName(1, "ShowStar.png");
            // 
            // btnAddHome
            // 
            btnAddHome.Image = (Image)resources.GetObject("btnAddHome.Image");
            btnAddHome.Location = new Point(0, 0);
            btnAddHome.Margin = new Padding(4, 6, 4, 6);
            btnAddHome.Name = "btnAddHome";
            btnAddHome.Size = new Size(47, 39);
            btnAddHome.TabIndex = 17;
            btnAddHome.UseVisualStyleBackColor = true;
            btnAddHome.Click += btnAddHome_Click;
            // 
            // tmrShowAddHome
            // 
            tmrShowAddHome.Interval = 5000;
            tmrShowAddHome.Tick += tmrShowAddHome_Tick;
            // 
            // tmrNavDone
            // 
            tmrNavDone.Interval = 2000;
            tmrNavDone.Tick += tmrNavDone_Tick;
            // 
            // btnSearchEng
            // 
            btnSearchEng.Image = (Image)resources.GetObject("btnSearchEng.Image");
            btnSearchEng.Location = new Point(90, 0);
            btnSearchEng.Margin = new Padding(4, 6, 4, 6);
            btnSearchEng.Name = "btnSearchEng";
            btnSearchEng.Size = new Size(47, 39);
            btnSearchEng.TabIndex = 18;
            btnSearchEng.UseVisualStyleBackColor = true;
            btnSearchEng.Visible = false;
            btnSearchEng.Click += btnSearchEng_Click;
            // 
            // WebBroForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 1050);
            Controls.Add(btnSearchEng);
            Controls.Add(btnHome);
            Controls.Add(btnAddHome);
            Controls.Add(lblCheckedOn);
            Controls.Add(btnGoTo);
            Controls.Add(cbSaveOfflineFile);
            Controls.Add(btnHistory);
            Controls.Add(lboxRecent);
            Controls.Add(lblStatus);
            Controls.Add(myBrowser);
            Controls.Add(btnScriptOK);
            Controls.Add(btnStopLoad);
            Controls.Add(btnBack);
            Controls.Add(myAddrBar);
            Controls.Add(lblWorking);
            Controls.Add(picLoading);
            Controls.Add(btnFont);
            Controls.Add(btnFav);
            KeyPreview = true;
            Margin = new Padding(4, 6, 4, 6);
            Name = "WebBroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "[Title Goes Here]";
            FormClosing += WebBroForm_FormClosing;
            Load += WebBroForm_Load;
            KeyPress += WebBroForm_KeyPress;
            ((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.WebBrowser myBrowser;
        private System.Windows.Forms.TextBox myAddrBar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lboxRecent;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.Button btnStopLoad;
        private System.Windows.Forms.Button btnScriptOK;
        private System.Windows.Forms.Label lblCheckedOn;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FontDialog dlgGetFont;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Timer tmrPopUps;
        private System.Windows.Forms.CheckBox cbSaveOfflineFile;
        private System.Windows.Forms.Timer tmrReroute;
        private System.Windows.Forms.ToolTip toolTipStop;
        private Button btnFav;
        private ImageList imgLstars;
        private Button btnAddHome;
        private System.Windows.Forms.Timer tmrShowAddHome;
        private System.Windows.Forms.Timer tmrNavDone;
        private Button btnSearchEng;
    }
}

