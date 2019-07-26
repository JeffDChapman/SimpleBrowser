using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WebLoader
{
    public partial class WebBroForm : Form
    {
        public WebBroForm()
        {
            InitializeComponent();
        }

        private bool allowScripts = false;
        private bool tbSkipNav = true;
        private bool isSpying = false;
        private bool stopClick = false;
        private Image spyImg;
        private bool addrAllSelected = false;
        private int navLoopCount = 0;
        private string homeLoc = "file:///C:/Users/JeffC/Desktop/Stuff/Bookmarks.htm";
        private string histPath = @"wBhist.txt";

        private void WebBroForm_Load(object sender, EventArgs e)
        {
            this.btnBack.Enabled = false;
            this.myBrowser.Navigate(homeLoc);
            spyImg = this.btnSpy.Image;
            this.btnSpy.Image = null;
            this.Top = 15;
            this.Height = 700;
        }

        private void myBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (isSpying)
                { return; }

            CleanHTML();
        }

        private void CleanHTML()
        {
            this.lblStatus.Text = "Code Replacement in process...";
            this.lblStatus.Refresh();
            HtmlDocument fixDoc = myBrowser.Document;
            if ((fixDoc.Body == null) || (fixDoc.Body.InnerHtml == null))
            {
                this.lblStatus.Text = "Empty Document";
                this.lblStatus.Refresh();
                return;
            }
            string pageBodyMod = fixDoc.Body.InnerHtml.ToString();

            pageBodyMod = RemoveScriptCode(pageBodyMod, "HEAD");
            pageBodyMod = RemoveScriptCode(pageBodyMod, "head");

            string StopRecur = pageBodyMod.Substring(1, 4).ToLower();
            if (StopRecur == "font")
            {
                this.myBrowser.Visible = true;
                this.lblStatus.Text = "Ready";
                this.Refresh();
                return;
            }

            pageBodyMod = pageBodyMod.Replace("font", "fnot");
            pageBodyMod = pageBodyMod.Replace("FONT", "FNOT");
            pageBodyMod = pageBodyMod.Replace("widt", "wdit");
            pageBodyMod = pageBodyMod.Replace("WIDT", "WDIT");
            pageBodyMod = pageBodyMod.Replace("H1", "br/");
            pageBodyMod = pageBodyMod.Replace("H2", "br/");
            pageBodyMod = pageBodyMod.Replace("H3", "br/");
            pageBodyMod = pageBodyMod.Replace("H4", "br/");

            if (allowScripts == false)
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
            }
            string pageBodyModshow = "<font face=\"verdana\">" + pageBodyMod;

            stopClick = false;
            this.Text = myBrowser.DocumentTitle;
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(pageBodyModshow);

            this.myBrowser.Visible = true;
            this.lblStatus.Text = "Ready";
            this.Refresh();
            myBrowser.Refresh();
            if (myBrowser.Url != null)
            { this.myAddrBar.Text = myBrowser.Url.ToString(); }
            string appendText = this.myAddrBar.Text + Environment.NewLine;
            File.AppendAllText(histPath, appendText);
            addrAllSelected = false;
        }

        private string RemoveScriptCode(string pageBodyMod, string checkWord)
        {
            string bodyReturn = pageBodyMod;
            while (true)
            {
                int startScr = bodyReturn.IndexOf("<" + checkWord);
                if (startScr < 0) { return bodyReturn; }
                int endScr = bodyReturn.IndexOf("</" + checkWord);
                bodyReturn = bodyReturn.Substring(0, startScr) + bodyReturn.Substring(endScr + 3 + checkWord.Length);
            }
            return bodyReturn;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            isSpying = false;
            this.btnSpy.Image = null;
            stopClick = false;
            navLoopCount = 0;
            this.myBrowser.Navigate(homeLoc);
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            this.btnBack.Enabled = true;
            stopClick = false;
            this.lboxRecent.Items.Insert(0, myAddrBar.Text);
            isSpying = false;
            navLoopCount = 0;
            this.btnSpy.Image = null;
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
            if (stopClick == true) { return; }
            this.lblStatus.Text = "Navigating...";
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
            string reDirLoc = e.Url.ToString();
            this.myBrowser.Visible = false;
            if (reDirLoc.Substring(0,6) == "about:")
            {
                string baseAddr = myAddrBar.Text;
                int lastSlashLoc = baseAddr.LastIndexOf("/");
                if ((reDirLoc.Substring(6, 1) == "/") && (baseAddr.IndexOf(reDirLoc.Substring(6, 4)) >= 0))
                {
                    string shorterBase = baseAddr.Substring(0, lastSlashLoc + 1);
                    lastSlashLoc = shorterBase.LastIndexOf("/") - 1;
                }
                string newBaseAddr = baseAddr.Substring(0, lastSlashLoc + 1);
                string reDirect = newBaseAddr + reDirLoc.Substring(6);
                if (reDirect.IndexOf("blank") < 0) 
                {
                    reDirect = RemoveDupsInPath(reDirect);
                    myAddrBar.Text = FixDoubleSlash(reDirect);
                    addrAllSelected = true;
                }
            }
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
            string histHead = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
            histHead += "<HTML><HEAD>";
            histHead += "<META HTTP-EQUIV=\"CONTENT-TYPE\" CONTENT=\"text/html; charset=windows-1252\">";
            histHead += "<TITLE>History</TITLE></HEAD><BODY LANG=\"en-US\" DIR=\"LTR\" bgcolor =\"BLACK\">";
            string histText = File.ReadAllText(histPath);
            string histDocument = histHead + ConvertUrlsToLinks(histText) + "</BODY></HTML>";
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(histDocument);
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

        private void btnSpy_Click(object sender, EventArgs e)
        {
            this.btnSpy.Image = spyImg;
            isSpying = true;
            string goToPage = this.myAddrBar.Text;
            myBrowser.Navigate(goToPage);
        }

        private void myBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
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
            string pageBodyMod = fixDoc.Body.InnerHtml.ToString();
            pageBodyMod = pageBodyMod.Replace("<", "[");
            pageBodyMod = pageBodyMod.Replace(">", "]");
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(pageBodyMod);
            this.myBrowser.Visible = true;
        }
    }
}
