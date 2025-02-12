using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebLoader
{
    public partial class WebBroForm : Form
    {
        private void btnHome_Click(object sender, EventArgs e)
        {
            stopClick = false;
            navLoopCount = 0;
            ResetOfflineCkbox();
            this.myBrowser.Navigate(homeLoc);
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            stopPopUps = true;
            this.btnGoTo.Visible = false;
            stopClick = false;
            isSpying = false;
            navLoopCount = 0;
            ResetOfflineCkbox();
            btnFav.ImageIndex = 0;
            if (btnSearchEng.Visible) { isAsearch = true; }
            if (myAddrBar.Text.Contains(" "))
            {
                isAsearch = true;
                string holdAddr = myAddrBar.Text;
                myAddrBar.Text = "https://www." + currentSearchEng + ".com/search?q=" + holdAddr.Replace(" ", "+");
                ChckReqsForSearchWord(true);
            }
            myBrowser.Navigate(myAddrBar.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.lboxRecent.Visible = true;
            this.btnHistory.Visible = true;
            this.btnHistory.BringToFront();
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
            tmrNavDone.Enabled = false;
            this.Refresh();
            try { this.myBrowser.Stop(); }
            catch { }

            if (isSpying)
            {
                PoshPageBrackets();
                myBrowser.Refresh();
                stopClick = false;
            }
            else try
                {
                    {
                        intRptdFlag = true;
                        myBrowser_DocumentCompleted(this, null);
                    }
                    this.myBrowser.Visible = true;
                }
                catch { }
        }

        private void btnScriptOK_Click(object sender, EventArgs e)
        {
            if (allowScripts == true)
            {
                allowScripts = false;
                this.lblCheckedOn.Visible = false;
            }
            else
            {
                allowScripts = true;
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

        private void btnFont_Click(object sender, EventArgs e)
        {
            this.dlgGetFont.ShowDialog(this);
            chosenFont = dlgGetFont.Font.FontFamily.Name.ToString();
            chosenSize = dlgGetFont.Font.Size.ToString();
            btnGoTo_Click(this, null);
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            bool SavingFav = false;
            if (btnFav.ImageIndex == 0) { SavingFav = true; }

            btnFav.ImageIndex = 1 - btnFav.ImageIndex;

            if (SavingFav)
            {
                EditFavDesc SaveDescForm = new EditFavDesc();
                SaveDescForm.tbSaveName.Text = this.Text;
                SaveDescForm.ShowDialog();
                string newFavsTitle = SaveDescForm.tbSaveName.Text;
                string FavsText = File.ReadAllText(strExeFilePath + favsPath);
                FavsText += "<a href=\"" + this.myAddrBar.Text + "\">";
                FavsText += newFavsTitle + "</a><br />\n\r";
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

        private void btnSearchEng_Click(object sender, EventArgs e)
        {
            sEngIndex++;
            if (sEngIndex >= sEngList.Length) { sEngIndex = 0; }
            string priorSearchEng = currentSearchEng;
            currentSearchEng = sEngList[sEngIndex];
            btnSearchEng.Image = Image.FromFile(strExeFilePath + "\\SearchLogos\\" + currentSearchEng + ".png");
            savedAddrBar = myAddrBar.Text;
            myAddrBar.Text = savedAddrBar.Replace(priorSearchEng, currentSearchEng);
            bool hasSearch = myAddrBar.Text.Contains("search");
            savedAddrBar = ChckReqsForSearchWord(hasSearch);
        }

        //--------- button pushing subroutines ---------//

        private string ChckReqsForSearchWord(bool hasSearch)
        {
            savedAddrBar = myAddrBar.Text;
            if ((sNsList[sEngIndex] == "0") && hasSearch)
            { myAddrBar.Text = savedAddrBar.Replace("search", ""); }
            if ((sNsList[sEngIndex] == "1") && !hasSearch)
            {
                int qLoc = savedAddrBar.IndexOf("?");
                myAddrBar.Text = savedAddrBar.Substring(0, qLoc) + "search" + savedAddrBar.Substring(qLoc);
            }

            return savedAddrBar;
        }

        private string ConvertUrlsToLinks(string msg)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }

    }
}
