﻿using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebLoader
{
    public partial class WebBroForm : Form
    {
        public WebBroForm()
        {
            InitializeComponent();
        }

        public WebBroForm(string startDoc)
        {
            InitializeComponent();
            passedStartDoc = startDoc;
        }

        #region Private Variables
        private bool allowScripts = false;
        private bool stopClick = false;
        private bool isSpying;
        private bool addrAllSelected = false;
        private string passedStartDoc = "";
        private int navLoopCount = 0;
        private string homeLoc = @"Bookmarks.htm";
        private string histPath = @"wBhist.txt";
        private string favsPath = @"myFavs.htm";
        private string homeUrlPath = @"homeUrl.txt";
        private string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        private bool internalRedirect;
        private bool hadRecovery;
        private string offLineFile = "nothing.htm";
        private bool atHome;
        private bool naviErr;
        private string saveOldPage = "";
        private bool docTooShort;
        private string chosenFont = "Candara";
        private string chosenSize = "24";
        private bool stopPopUps = false;
        private bool intRptdFlag = false;
        private bool ctrlNavigated = false;
        private string GlobalFavs = "";
        private bool hasAhome;
        #endregion

        private void WebBroForm_Load(object sender, EventArgs e)
        {
            hasAhome = true;
            int findWL = strExeFilePath.IndexOf("WebLoader", strExeFilePath.Length - 15);
            strExeFilePath = strExeFilePath.Substring(0, findWL);
            try { homeLoc = File.ReadAllText(strExeFilePath + homeUrlPath); }
            catch 
            { 
                hasAhome = false;
                btnHome.Enabled = false;
                btnAddHome.BringToFront();
                btnAddHome.Enabled = false;
            }
            this.btnBack.Enabled = false;
            internalRedirect = false;

            if (passedStartDoc != "")
                { this.myBrowser.Navigate(passedStartDoc); }
            else { if (hasAhome) { myBrowser.Navigate(homeLoc); } }

            this.Top = 0;
            this.Height = Screen.PrimaryScreen.Bounds.Bottom;
            try { GlobalFavs = File.ReadAllText(strExeFilePath + favsPath); }
            catch { }
        }

        private void myBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (myBrowser.Document.Body.InnerText.Contains("Navigation to the webpage was canceled"))
            {
                this.myBrowser.Navigate("about:blank");
                SetupEndFlagging();
                return;
            }
            if ((e == null) && (!intRptdFlag)) { return; }
            if (isSpying)
                { return; }

            if (hadRecovery) { return; }
            if ((naviErr) && (!intRptdFlag)) { return; }

            docTooShort = false;
            CheckShortDoc(myAddrBar.Text, 2); 
            if ((docTooShort) && (ctrlNavigated))
            {
                this.lblStatus.Text = "Delay reroute ...";
                tmrReroute.Enabled = true;
                return;
            }
            if (docTooShort) {return;}

            CleanHTML();
        }

        private void CheckShortDoc(string GoToUrl, int Occurrence)
        {
            if (myBrowser.DocumentText.Length < 200) 
            {  
                docTooShort = true;
                if (!stopPopUps)
                    { StartnewFormWseed(GoToUrl, myBrowser.DocumentText); }
                myBrowser.DocumentText = saveOldPage;
                if ((ctrlNavigated) && (Occurrence == 2)) { return; }
                string boxMsg = "Short Reply Reroute (" + Occurrence.ToString() + ")";
                MessageBox.Show(boxMsg);
            }
        }

        private void CleanHTML()
        {
            if (hadRecovery) {return; }
            if ((naviErr) && (!intRptdFlag)) { return; }
            hadRecovery = false;
            try { CloseAllSocks(); }
            catch { }
            string pageBodyMod = "";
            this.lblStatus.Text = "Code Replacement in process...";
            this.lblStatus.Refresh();
            HtmlDocument fixDoc = myBrowser.Document;
            string recovD = tryRecovery(myBrowser.DocumentStream);
            int foundTitle = recovD.ToLower().IndexOf("<title");
            bool badLoad = (fixDoc.Body == null) || (fixDoc.Body.InnerHtml == null);

            if ((badLoad) && (foundTitle <= 0))
            {
                this.lblStatus.Text = "Empty Document";
                this.lblStatus.Refresh();
                return;
            }

            if (badLoad)
            {
                hadRecovery = true;
                pageBodyMod = recovD.Substring(foundTitle);
                SaveFileOffline(pageBodyMod, recovD, foundTitle);
            }
            else
            {
                pageBodyMod = fixDoc.Body.InnerHtml.ToString();
            }

            pageBodyMod = RemoveScriptCode(pageBodyMod, "HEAD");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "head");

            string StopRecur = pageBodyMod.Substring(1, 4).ToLower();
            if (StopRecur == "font")
            {
                this.myBrowser.Visible = true;
                this.lblStatus.Text = "Ready";
                internalRedirect = true;
                this.btnGoTo.Visible = true;
                this.Refresh();
                tmrPopUps.Enabled = true;
                return;
            }

            docTooShort = false;
            CheckShortDoc(fixDoc.Url.ToString(), 3);
            if (docTooShort) { return; }

            string pageBodyModshow = MakeFinalAdjustments(ref pageBodyMod);
            this.Text = myBrowser.DocumentTitle;
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(pageBodyModshow);

            SetupEndFlagging();
        }

        private void CloseAllSocks()
        {
            this.lblStatus.Text = "Closing sockets...";
            this.lblStatus.Refresh();
            int nProcessID = Process.GetCurrentProcess().Id;

            var p = new Process
            {
                StartInfo = { FileName = @"cmd.exe",
                    Arguments = "/C netstat -a -n -o >activeSocks.txt", UseShellExecute = false,
                    CreateNoWindow = true}
            };
            p.Start();
            p.WaitForExit();
            p.Close();

            var lines = File.ReadLines("activeSocks.txt");
            foreach (var line in lines)
            {
                string[] sockParms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (sockParms.Length < 5) { continue; }
                if (sockParms[4] != nProcessID.ToString()) { continue; }
                string myEndPoint = sockParms[1];
                string[] myIPsplit = myEndPoint.Split(new char[] { ':' });
                using Socket aSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                {
                    int myPort = 8080;
                    if (myIPsplit.Length > 0) { myPort = Convert.ToInt32(myIPsplit[myIPsplit.Length - 1]); }
                    var myEP = new IPEndPoint(IPAddress.Parse(myEndPoint), myPort);
                    try
                    {
                        aSocket.Bind(myEP);
                        aSocket.Close(10);
                    }
                    catch { bool debugstop = true; }
                }
            }
        }

        private void SaveFileOffline(string pageBodyMod, string recovD, int foundTitle)
        {
            // TODO: fix this, need user's desktop
            offLineFile = "C:\\Users\\JeffC\\Desktop\\";
            offLineFile += recovD.Substring(foundTitle + 7, 8) + ".htm";
            offLineFile = offLineFile.Replace("'", "");
            offLineFile = offLineFile.Replace("\n", "");
            offLineFile = offLineFile.Replace("\r", "");
            try
            {
                File.AppendAllText(offLineFile, pageBodyMod);
                cbSaveOfflineFile.Visible = true;
            }
            catch { }
        }

        private void SetupEndFlagging()
        {
            this.myBrowser.Visible = true;
            this.lblStatus.Text = "Ready";
            internalRedirect = true;
            this.btnGoTo.Visible = true;
            this.Refresh();
            myBrowser.Refresh();
            hadRecovery = false;
            tmrPopUps.Enabled = true;
            if (myBrowser.Url != null)
                { this.myAddrBar.Text = myBrowser.Url.ToString().Replace("ovre", "over"); }
            if (this.myAddrBar.Text.Substring(0, 5) != "file:")
            {
                string appendText = this.myAddrBar.Text + "<br />" + Environment.NewLine;
                File.AppendAllText(strExeFilePath + histPath, appendText);
            }
            atHome = false;
            stopClick = false;
            intRptdFlag = false;
            ctrlNavigated = false;
            if (myAddrBar.Text == homeLoc) { atHome = true; }
            addrAllSelected = false;
            if (GlobalFavs.Contains(myAddrBar.Text)) { btnFav.ImageIndex = 1; }
            saveOldPage = myBrowser.DocumentText;
            if (!atHome) { btnAddHome.BringToFront(); }
            tmrShowAddHome.Enabled = true;
        }

        private string MakeFinalAdjustments(ref string pageBodyMod)
        {
            pageBodyMod = pageBodyMod.Replace("font", "fnot");
            pageBodyMod = pageBodyMod.Replace("FONT", "FNOT");
            pageBodyMod = pageBodyMod.Replace("widt", "wdit");
            pageBodyMod = pageBodyMod.Replace("WIDT", "WDIT");
            pageBodyMod = pageBodyMod.Replace("H1", "br/");
            pageBodyMod = pageBodyMod.Replace("H2", "br/");
            pageBodyMod = pageBodyMod.Replace("H3", "br/");
            pageBodyMod = pageBodyMod.Replace("H4", "br/");

            if (allowScripts == false)
                pageBodyMod = ScriptReplacements(pageBodyMod);
            int webSize = (int)Convert.ToSingle(chosenSize) / 4;
            string pageBodyModshow = "<!DOCTYPE html>";
            pageBodyModshow += "<font size=\"" + webSize + "\" face=\"" + chosenFont + "\"/>" + pageBodyMod;
            return pageBodyModshow;
        }

        private string tryRecovery(Stream htmlStream)
        {
            string RecoveredDoc = "";
            byte[] bufferData =  new byte[2048];
            int countRead = 1;
            int lastread = 0;
            while (countRead > 0)
            {
                countRead = htmlStream.Read(bufferData, 0, 2048);
                lastread += countRead;
                htmlStream.Position = lastread;
                RecoveredDoc += Encoding.UTF8.GetString(bufferData);
            }
            return RecoveredDoc;
        }

        private string ScriptReplacements(string pageBodyMod)
        {
            pageBodyMod = RemoveScriptCode(pageBodyMod, "HEAD");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "head");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "SCRIPT");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "script");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "STYLE");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "style");
            pageBodyMod = pageBodyMod.Replace("REDIR", "REDRI");
            pageBodyMod = pageBodyMod.Replace("redir", "redri");
            pageBodyMod = pageBodyMod.Replace("styl", "stly");
            pageBodyMod = pageBodyMod.Replace("STYL", "STLY");
            pageBodyMod = pageBodyMod.Replace("scri", "srci");
            pageBodyMod = pageBodyMod.Replace("SCRI", "SRCI");
            pageBodyMod = pageBodyMod.Replace("Scri", "Srci");
            pageBodyMod = pageBodyMod.Replace("java", "jav");
            pageBodyMod = pageBodyMod.Replace("JAVA", "JAV");
            pageBodyMod = pageBodyMod.Replace("func", "fucn");
            pageBodyMod = pageBodyMod.Replace("FUNC", "FUCN");
            pageBodyMod = pageBodyMod.Replace("onload", "onlaod");
            pageBodyMod = pageBodyMod.Replace("over", "ovre");
            pageBodyMod = pageBodyMod.Replace("OVER", "OVRE");
            pageBodyMod = pageBodyMod.Replace("target", "tagret");
            pageBodyMod = pageBodyMod.Replace("mouseout", "mouesout");
            pageBodyMod = pageBodyMod.Replace("MOUSEOUT", "MOUESOUT");
            pageBodyMod = pageBodyMod.Replace("widg", "wigd");
            pageBodyMod = pageBodyMod.Replace("WIDG", "WIGD");
            pageBodyMod = pageBodyMod.Replace("img", "igm");
            pageBodyMod = pageBodyMod.Replace("IMG", "IGM");
            pageBodyMod = pageBodyMod.Replace("t>", "  ");
            return pageBodyMod;
        }

        private string RemoveScriptCode(string pageBodyMod, string checkWord)
        {
            string bodyReturn = pageBodyMod;
            int skipSpaceOffset = 2;
            int endScr = 0;
            int startScr = 0 - skipSpaceOffset;
            while (true)
            {
                if (startScr > bodyReturn.Length - skipSpaceOffset - 1) { return bodyReturn; }
                startScr = bodyReturn.IndexOf("<" + checkWord, startScr + skipSpaceOffset);
                if (startScr < 0) { return bodyReturn; }
                endScr = bodyReturn.IndexOf("</" + checkWord);
                if (endScr < startScr)
                { endScr = bodyReturn.IndexOf(checkWord, startScr + skipSpaceOffset + 1); }
                if (endScr < 0) { return bodyReturn; }
                bodyReturn = bodyReturn.Substring(0, startScr) + bodyReturn.Substring(endScr + 1 + checkWord.Length);
            }
            return bodyReturn;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            stopClick = false;
            navLoopCount = 0;
            ResetOfflineCkbox();
            this.myBrowser.Navigate(homeLoc);
        }

        private void ResetOfflineCkbox()
        {
            if (!cbSaveOfflineFile.Checked)
            {
                try { File.Delete(offLineFile); }
                catch { }
            }
            cbSaveOfflineFile.Visible = false;
            cbSaveOfflineFile.Checked = false;
            internalRedirect = false;
            tmrPopUps.Enabled = false;
            tmrPopUps.Enabled = true;
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            stopPopUps = true;
            this.btnBack.Enabled = true;
            this.btnGoTo.Visible = false;
            stopClick = false;
            this.lboxRecent.Items.Insert(0, myAddrBar.Text);
            isSpying = false;
            navLoopCount = 0;
            ResetOfflineCkbox();
            btnFav.ImageIndex = 0;
            if (myAddrBar.Text.Contains(" "))
            {
                string holdAddr = myAddrBar.Text;
                myAddrBar.Text = "www.google.com/search?q=" + holdAddr.Replace(" ", "+");
            }
            myBrowser.Navigate(myAddrBar.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.lboxRecent.Visible = true;
            this.btnHistory.Visible = true;
            this.btnHistory.BringToFront();
        }

        private void myBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            naviErr = false;
            if (!hasAhome) { btnAddHome.Enabled = true; }
            if (stopClick == true) { return; }
            btnFav.ImageIndex = 0;
            ctrlNavigated = false;
            if (Control.ModifierKeys == Keys.Control) { ctrlNavigated = true; }
            
            string reDirLoc = e.Url.ToString();
            if (reDirLoc == "about:blank") 
            {
                naviErr = true;
                string reDirect = FixAboutUrl(reDirLoc);
                reDirLoc = FixDoubleSlash(reDirect);
                if (!stopPopUps)
                    { StartnewForm(reDirLoc); }
                e.Cancel = true;
                return; 
            }

            bool regularNonHomeClick = false;
            if ((internalRedirect) && (!ctrlNavigated) && (!atHome)) { regularNonHomeClick = true; }

            if ((stopPopUps) && (regularNonHomeClick))
            { 
                e.Cancel = true;
                return;
            }

            if ((regularNonHomeClick) && (Control.ModifierKeys != Keys.Shift))
            {
                string reDirect = FixAboutUrl(reDirLoc);
                reDirect = FixDoubleSlash(reDirect);
                StartnewForm(reDirect);
                e.Cancel = true;
                return;
            }

            if ((ctrlNavigated) || (atHome))
                { ResetOfflineCkbox(); }
            this.lblStatus.Text = "Navigating...";
            stopPopUps = true;
            this.btnGoTo.Visible = false;
            this.Refresh();
            navLoopCount++;
            if (navLoopCount > 10)
            {
                this.lblStatus.Text = "Loop Count Exceeded...";
                PoshPageBrackets();
                myBrowser.Refresh();
                navLoopCount = 0;
                return;
            }
          
            this.myBrowser.Visible = false;
            string newRouteTo = FixAboutUrl(reDirLoc);
            myAddrBar.Text = FixDoubleSlash(newRouteTo).Replace("ovre", "over");
        }

        private string FixAboutUrl(string reDirLoc)
        {
            string reDirect = reDirLoc;
            if (reDirLoc.Substring(0, 6) == "about:")
            {
                string baseAddr = myAddrBar.Text;
                int lastSlashLoc = baseAddr.LastIndexOf("/");
                if ((reDirLoc.Substring(6, 1) == "/") && (baseAddr.IndexOf(reDirLoc.Substring(6, 4)) >= 0))
                {
                    string shorterBase = baseAddr.Substring(0, lastSlashLoc + 1);
                    lastSlashLoc = shorterBase.LastIndexOf("/") - 1;
                }
                string newBaseAddr = baseAddr.Substring(0, lastSlashLoc + 1);
                reDirect = newBaseAddr + reDirLoc.Substring(6);
                if (reDirect.IndexOf("blank") < 0)
                {
                    reDirect = RemoveDupsInPath(reDirect);
                    if (!internalRedirect)
                    {
                        myAddrBar.Text = FixDoubleSlash(reDirect);
                    }
                    addrAllSelected = true;
                }
            }
            return reDirect;
        }

        private void StartnewForm(string reDirLoc)
        {
            if (reDirLoc.ToLower().IndexOf("blank") > -1) { return; }
            WebBroForm anotherForm = new WebBroForm();
            ShowNewWebform(reDirLoc, anotherForm);
            tmrPopUps.Enabled = true;
        }

        private void StartnewFormWseed(string reDirLoc, string DocText)
        {
            WebBroForm anotherForm = new WebBroForm();
            ShowNewWebform(reDirLoc, anotherForm);
            tmrPopUps.Enabled = true;
            anotherForm.myBrowser.DocumentText = DocText;
        }

        private void ShowNewWebform(string reDirLoc, WebBroForm anotherForm)
        {
            anotherForm.Show();
            anotherForm.Left = this.Left + 50;
            anotherForm.Width = this.Width;           
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            anotherForm.myAddrBar.Text = reDirLoc.Replace("ovre", "over");
            anotherForm.chosenFont = chosenFont;
            anotherForm.chosenSize = chosenSize;
            anotherForm.stopPopUps = true;
        }

        private string RemoveDupsInPath(string inRedirect)
        {
            string reDirectBack = "";
            string priorSet = "";
            string[] backSep = new string[] { "/" };
            string[] result = inRedirect.Split(backSep, StringSplitOptions.None);
            foreach (string oneSet in result)
            {
                if (oneSet != priorSet)
                    { reDirectBack += oneSet + "/"; }
                priorSet = oneSet;
            }
            return (reDirectBack.Substring(0, reDirectBack.Length - 1));
        }

        private string FixDoubleSlash(string inRedirect)
        {
            if (inRedirect.Length < 8) { return inRedirect; }
            int dSloc = inRedirect.IndexOf("//", 8);
            if (dSloc < 0)
                {return inRedirect;}
            int fSloc = inRedirect.IndexOf("/", 8);
            string reDirectBack = "";
            reDirectBack = inRedirect.Substring(0, fSloc) + inRedirect.Substring(dSloc + 1);
            return (reDirectBack);
        }

        private void lboxRecent_Click(object sender, EventArgs e)
        {
            string goToPage = this.lboxRecent.SelectedItem.ToString();
            this.btnHistory.Visible = false;
            this.lboxRecent.Visible = false;
            navLoopCount = 0;
            internalRedirect = false;
            myBrowser.Navigate(goToPage);
        }

        private void WebBroForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.btnHistory.Visible = false;
                this.lboxRecent.Visible = false;
                this.Refresh();
            }
        }

        private void btnStopLoad_Click(object sender, EventArgs e)
        {
            if (stopClick == true)
            {
                PoshPageBrackets();
                myBrowser.Refresh();
                stopClick = false;
                return;
            }
            stopClick = true;
            this.lblStatus.Text = "Interrupting...";
            this.Refresh();
            this.myBrowser.Stop();
           
            if (isSpying)
            {
                PoshPageBrackets();
                myBrowser.Refresh();
                stopClick = false;
            }
            else
            {
                intRptdFlag = true;
                myBrowser_DocumentCompleted(this, null); 
            }
            this.myBrowser.Visible = true;
        }

        private void btnScriptOK_Click(object sender, EventArgs e)
        {
            if (allowScripts == true)
                { allowScripts = false;
                this.lblCheckedOn.Visible = false;
                }
            else
                { allowScripts = true;
                this.lblCheckedOn.Visible = true;
                }
        }

        private void myAddrBar_Click(object sender, EventArgs e)
        {
            if (addrAllSelected == false)
            {
                this.myAddrBar.SelectAll();
                addrAllSelected = true;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.btnHistory.Visible = false;
            this.lboxRecent.Visible = false;
            internalRedirect = false;
            string histHead = "<HTML><HEAD>";
            histHead += "<TITLE>History</TITLE></HEAD><BODY LANG=\"en-US\" DIR=\"LTR\" bgcolor =\"BLACK\">";
            string histText = File.ReadAllText(strExeFilePath + histPath);
            string histDocument = histHead + ConvertUrlsToLinks(histText) + "</BODY></HTML>";
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(histDocument);
            CleanHTML();
            this.myBrowser.Visible = true;
            myBrowser.Refresh();
            this.myAddrBar.Text = "History";
        }

        private string ConvertUrlsToLinks(string msg)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }

        private void myBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (naviErr) { return; }
            this.lblStatus.Text = "Navigation Done";
            this.lblStatus.Refresh();

            if (stopClick)
            {
                CleanHTML();
                return;
            }

            if (!isSpying)
                { return; }

            PoshPageBrackets();
            myBrowser.Refresh();
         }

        private void PoshPageBrackets()
        {
            HtmlDocument fixDoc = myBrowser.Document;
            if ((fixDoc.Body == null) || (fixDoc.Body.InnerHtml == null))
            {
                this.lblStatus.Text = "Empty Document";
                this.lblStatus.Refresh();
                return;
            }

            docTooShort = false;
            CheckShortDoc(fixDoc.Url.ToString(), 1);
            if (docTooShort) { return; }

            string pageBodyMod = fixDoc.Body.InnerHtml.ToString();
            pageBodyMod = pageBodyMod.Replace("<", "[");
            pageBodyMod = pageBodyMod.Replace(">", "]");
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(pageBodyMod);
            this.myBrowser.Visible = true;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            this.dlgGetFont.ShowDialog(this);
            chosenFont = dlgGetFont.Font.FontFamily.Name.ToString();
            chosenSize = dlgGetFont.Font.Size.ToString();
            btnGoTo_Click(this, null);
        }

        private void tmrPopUps_Tick(object sender, EventArgs e)
        {
            tmrPopUps.Enabled = false;
            stopPopUps = false;
        }

        private void WebBroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbSaveOfflineFile.Checked) { return; }
            try { File.Delete(offLineFile); }
            catch { }
        }

        private void tmrReroute_Tick(object sender, EventArgs e)
        {
            tmrReroute.Enabled = false;
            btnGoTo_Click(this, null);
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            bool SavingFav = false;
            if (btnFav.ImageIndex == 0) { SavingFav = true; }

            btnFav.ImageIndex = 1 - btnFav.ImageIndex;

            if (SavingFav)
            {
                string FavsText = File.ReadAllText(strExeFilePath + favsPath);
                FavsText += "<a href=\"" + this.myAddrBar.Text + "\">";
                FavsText += this.Text + "</a><br />\n\r";
                File.WriteAllText(strExeFilePath + favsPath, FavsText);
                GlobalFavs = FavsText;
                return;
            }

            internalRedirect = false;
            string favsHead = "<HTML><HEAD>";
            favsHead += "<TITLE>Favorites</TITLE></HEAD><BODY LANG=\"en-US\" DIR=\"LTR\" bgcolor =\"BLACK\">";
            string favText = File.ReadAllText(strExeFilePath + favsPath);
            string favsDocument = favsHead + favText + "</BODY></HTML>";
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(favsDocument);
            CleanHTML();
            this.myBrowser.Visible = true;
            myBrowser.Refresh();
            this.myAddrBar.Text = "Favorites";
        }

        private void btnAddHome_Click(object sender, EventArgs e)
        {
            File.WriteAllText(strExeFilePath + homeUrlPath, this.myAddrBar.Text);
            homeLoc = this.myAddrBar.Text;
            btnHome.BringToFront();
            btnHome.Enabled = true;
            hasAhome = true;
        }

        private void tmrShowAddHome_Tick(object sender, EventArgs e)
        {
            if (hasAhome) { btnHome.BringToFront(); }
            tmrShowAddHome.Enabled = false;
        }
    }
}
