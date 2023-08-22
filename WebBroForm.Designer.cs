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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBroForm));
            this.myBrowser = new System.Windows.Forms.WebBrowser();
            this.myAddrBar = new System.Windows.Forms.TextBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lboxRecent = new System.Windows.Forms.ListBox();
            this.lblWorking = new System.Windows.Forms.Label();
            this.btnStopLoad = new System.Windows.Forms.Button();
            this.btnScriptOK = new System.Windows.Forms.Button();
            this.lblCheckedOn = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dlgGetFont = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.tmrPopUps = new System.Windows.Forms.Timer(this.components);
            this.cbSaveOfflineFile = new System.Windows.Forms.CheckBox();
            this.tmrReroute = new System.Windows.Forms.Timer(this.components);
            this.toolTipStop = new System.Windows.Forms.ToolTip(this.components);
            this.btnFav = new System.Windows.Forms.Button();
            this.imgLstars = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // myBrowser
            // 
            this.myBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myBrowser.Location = new System.Drawing.Point(13, 40);
            this.myBrowser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.myBrowser.MinimumSize = new System.Drawing.Size(33, 39);
            this.myBrowser.Name = "myBrowser";
            this.myBrowser.ScriptErrorsSuppressed = true;
            this.myBrowser.Size = new System.Drawing.Size(1292, 972);
            this.myBrowser.TabIndex = 0;
            this.myBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.myBrowser_DocumentCompleted);
            this.myBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.myBrowser_Navigated);
            this.myBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.myBrowser_Navigating);
            // 
            // myAddrBar
            // 
            this.myAddrBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myAddrBar.Location = new System.Drawing.Point(91, 4);
            this.myAddrBar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.myAddrBar.Name = "myAddrBar";
            this.myAddrBar.Size = new System.Drawing.Size(1051, 31);
            this.myAddrBar.TabIndex = 1;
            this.myAddrBar.Click += new System.EventHandler(this.myAddrBar_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(47, 39);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Image = ((System.Drawing.Image)(resources.GetObject("btnGoTo.Image")));
            this.btnGoTo.Location = new System.Drawing.Point(44, 0);
            this.btnGoTo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(47, 39);
            this.btnGoTo.TabIndex = 3;
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(1277, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(47, 39);
            this.btnBack.TabIndex = 4;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lboxRecent
            // 
            this.lboxRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxRecent.FormattingEnabled = true;
            this.lboxRecent.ItemHeight = 25;
            this.lboxRecent.Location = new System.Drawing.Point(656, 0);
            this.lboxRecent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lboxRecent.Name = "lboxRecent";
            this.lboxRecent.Size = new System.Drawing.Size(657, 329);
            this.lboxRecent.TabIndex = 5;
            this.lboxRecent.Visible = false;
            this.lboxRecent.Click += new System.EventHandler(this.lboxRecent_Click);
            // 
            // lblWorking
            // 
            this.lblWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorking.AutoSize = true;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWorking.Location = new System.Drawing.Point(962, 48);
            this.lblWorking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(278, 55);
            this.lblWorking.TabIndex = 6;
            this.lblWorking.Text = "Working . . .";
            // 
            // btnStopLoad
            // 
            this.btnStopLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLoad.Image")));
            this.btnStopLoad.Location = new System.Drawing.Point(43, 0);
            this.btnStopLoad.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStopLoad.Name = "btnStopLoad";
            this.btnStopLoad.Size = new System.Drawing.Size(47, 39);
            this.btnStopLoad.TabIndex = 7;
            this.toolTipStop.SetToolTip(this.btnStopLoad, "Stop Loading");
            this.btnStopLoad.UseVisualStyleBackColor = true;
            this.btnStopLoad.Click += new System.EventHandler(this.btnStopLoad_Click);
            // 
            // btnScriptOK
            // 
            this.btnScriptOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnScriptOK.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptOK.Image")));
            this.btnScriptOK.Location = new System.Drawing.Point(1187, 0);
            this.btnScriptOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScriptOK.Name = "btnScriptOK";
            this.btnScriptOK.Size = new System.Drawing.Size(47, 39);
            this.btnScriptOK.TabIndex = 8;
            this.btnScriptOK.UseVisualStyleBackColor = true;
            this.btnScriptOK.Click += new System.EventHandler(this.btnScriptOK_Click);
            // 
            // lblCheckedOn
            // 
            this.lblCheckedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckedOn.BackColor = System.Drawing.Color.Olive;
            this.lblCheckedOn.Location = new System.Drawing.Point(1193, 40);
            this.lblCheckedOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckedOn.Name = "lblCheckedOn";
            this.lblCheckedOn.Size = new System.Drawing.Size(33, 11);
            this.lblCheckedOn.TabIndex = 9;
            this.lblCheckedOn.Visible = false;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(1283, 2);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(33, 44);
            this.btnHistory.TabIndex = 10;
            this.btnHistory.Text = "H";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Visible = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // picLoading
            // 
            this.picLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(360, 341);
            this.picLoading.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(200, 200);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(0, 1018);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1292, 31);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Ready";
            // 
            // dlgGetFont
            // 
            this.dlgGetFont.Color = System.Drawing.Color.White;
            this.dlgGetFont.FontMustExist = true;
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFont.Image = ((System.Drawing.Image)(resources.GetObject("btnFont.Image")));
            this.btnFont.Location = new System.Drawing.Point(1231, 0);
            this.btnFont.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(47, 39);
            this.btnFont.TabIndex = 14;
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // tmrPopUps
            // 
            this.tmrPopUps.Interval = 10000;
            this.tmrPopUps.Tick += new System.EventHandler(this.tmrPopUps_Tick);
            // 
            // cbSaveOfflineFile
            // 
            this.cbSaveOfflineFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSaveOfflineFile.AutoSize = true;
            this.cbSaveOfflineFile.Location = new System.Drawing.Point(1116, 48);
            this.cbSaveOfflineFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSaveOfflineFile.Name = "cbSaveOfflineFile";
            this.cbSaveOfflineFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbSaveOfflineFile.Size = new System.Drawing.Size(164, 29);
            this.cbSaveOfflineFile.TabIndex = 15;
            this.cbSaveOfflineFile.Text = "Save Offline File";
            this.cbSaveOfflineFile.UseVisualStyleBackColor = true;
            this.cbSaveOfflineFile.Visible = false;
            // 
            // tmrReroute
            // 
            this.tmrReroute.Interval = 2000;
            this.tmrReroute.Tick += new System.EventHandler(this.tmrReroute_Tick);
            // 
            // btnFav
            // 
            this.btnFav.ImageIndex = 0;
            this.btnFav.ImageList = this.imgLstars;
            this.btnFav.Location = new System.Drawing.Point(1141, 0);
            this.btnFav.Name = "btnFav";
            this.btnFav.Size = new System.Drawing.Size(47, 39);
            this.btnFav.TabIndex = 16;
            this.btnFav.UseVisualStyleBackColor = true;
            this.btnFav.Click += new System.EventHandler(this.btnFav_Click);
            // 
            // imgLstars
            // 
            this.imgLstars.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLstars.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstars.ImageStream")));
            this.imgLstars.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstars.Images.SetKeyName(0, "SmStar.jpg");
            this.imgLstars.Images.SetKeyName(1, "SmStarFill.png");
            // 
            // WebBroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 1050);
            this.Controls.Add(this.btnGoTo);
            this.Controls.Add(this.cbSaveOfflineFile);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.lboxRecent);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.myBrowser);
            this.Controls.Add(this.lblCheckedOn);
            this.Controls.Add(this.btnScriptOK);
            this.Controls.Add(this.btnStopLoad);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.myAddrBar);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.btnFav);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "WebBroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Title Goes Here]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebBroForm_FormClosing);
            this.Load += new System.EventHandler(this.WebBroForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WebBroForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

