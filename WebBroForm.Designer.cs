﻿namespace WebLoader
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

            this.SuspendLayout();
            // 
            // myBrowser
            // 
            this.myBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myBrowser.Location = new System.Drawing.Point(-5, 25);
            this.myBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.myBrowser.Name = "myBrowser";
            this.myBrowser.ScriptErrorsSuppressed = true;
            this.myBrowser.Size = new System.Drawing.Size(799, 613);
            this.myBrowser.TabIndex = 0;
            this.myBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.myBrowser_DocumentCompleted);
            this.myBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.myBrowser_Navigating);
            // 
            // myAddrBar
            // 
            this.myAddrBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myAddrBar.Location = new System.Drawing.Point(53, 0);
            this.myAddrBar.Name = "myAddrBar";
            this.myAddrBar.Size = new System.Drawing.Size(660, 20);
            this.myAddrBar.TabIndex = 1;
            this.myAddrBar.Click += new System.EventHandler(this.myAddrBar_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(28, 20);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoTo.Image = ((System.Drawing.Image)(resources.GetObject("btnGoTo.Image")));
            this.btnGoTo.Location = new System.Drawing.Point(739, 0);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(28, 20);
            this.btnGoTo.TabIndex = 3;
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(766, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(28, 20);
            this.btnBack.TabIndex = 4;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lboxRecent
            // 
            this.lboxRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxRecent.FormattingEnabled = true;
            this.lboxRecent.Location = new System.Drawing.Point(398, 0);
            this.lboxRecent.Name = "lboxRecent";
            this.lboxRecent.Size = new System.Drawing.Size(396, 173);
            this.lboxRecent.TabIndex = 5;
            this.lboxRecent.Visible = false;
            this.lboxRecent.Click += new System.EventHandler(this.lboxRecent_Click);
            // 
            // lblWorking
            // 
            this.lblWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorking.AutoSize = true;
            this.lblWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.Location = new System.Drawing.Point(577, 25);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(190, 37);
            this.lblWorking.TabIndex = 6;
            this.lblWorking.Text = "Working . . .";
            // 
            // btnStopLoad
            // 
            this.btnStopLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLoad.Image")));
            this.btnStopLoad.Location = new System.Drawing.Point(26, 0);
            this.btnStopLoad.Name = "btnStopLoad";
            this.btnStopLoad.Size = new System.Drawing.Size(28, 20);
            this.btnStopLoad.TabIndex = 7;
            this.btnStopLoad.UseVisualStyleBackColor = true;
            this.btnStopLoad.Click += new System.EventHandler(this.btnStopLoad_Click);
            // 
            // btnScriptOK
            // 
            this.btnScriptOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnScriptOK.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptOK.Image")));
            this.btnScriptOK.Location = new System.Drawing.Point(712, 0);
            this.btnScriptOK.Name = "btnScriptOK";
            this.btnScriptOK.Size = new System.Drawing.Size(28, 20);
            this.btnScriptOK.TabIndex = 8;
            this.btnScriptOK.UseVisualStyleBackColor = true;
            this.btnScriptOK.Click += new System.EventHandler(this.btnScriptOK_Click);
            // 
            // lblCheckedOn
            // 
            this.lblCheckedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckedOn.BackColor = System.Drawing.Color.Olive;
            this.lblCheckedOn.Location = new System.Drawing.Point(716, 21);
            this.lblCheckedOn.Name = "lblCheckedOn";
            this.lblCheckedOn.Size = new System.Drawing.Size(20, 6);
            this.lblCheckedOn.TabIndex = 9;
            this.lblCheckedOn.Visible = false;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(770, 1);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(20, 23);
            this.btnHistory.TabIndex = 10;
            this.btnHistory.Text = "H";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Visible = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // WebBroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 638);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.lboxRecent);
            this.Controls.Add(this.lblCheckedOn);
            this.Controls.Add(this.btnScriptOK);
            this.Controls.Add(this.btnStopLoad);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGoTo);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.myAddrBar);
            this.Controls.Add(this.myBrowser);
            this.Controls.Add(this.lblWorking);
            this.KeyPreview = true;
            this.Name = "WebBroForm";
            this.Text = "[Title Goes Here]";
            this.Load += new System.EventHandler(this.WebBroForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WebBroForm_KeyPress);
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
    }
}

