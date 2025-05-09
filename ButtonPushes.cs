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
            SetupNavigAddress();
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
            processAforceStop();
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

        private void btnImages_Click(object sender, EventArgs e)
        {
            myImageZoom = new ImageZoomer(this);
            myImageZoom.Top = Top;
            myImageZoom.Left = Left + Width - 12;
            myImageZoom.Height = Height;
            myImageZoom.imageBase = myBrowser.Url.Host;
            myImageZoom.lbImageList.Items.Clear();
            myImageZoom.lbImageList.Height = Height - myImageZoom.lbImageList.Top - 60;
            foreach (string webpageImage in webpageImages)
            {
                int i;
                for (i = webpageImage.Length - 2; i > 1; i--)
                    { if (webpageImage[i] == '\\') { break; }
                      if (webpageImage[i] == '/') { break; }
                }
                string imageToShow = webpageImage.Substring(i+1);
                myImageZoom.lbImageList.Items.Add(imageToShow);
            }
            myImageZoom.Show();
        }

        private void WebBroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbSaveOfflineFile.Checked) { return; }
            try { File.Delete(offLineFile); }
            catch { }
        }

        //--------- button pushing subroutines ---------//

        private string ConvertUrlsToLinks(string msg)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }


        //--------- UI timer events ---------//

        private void tmrShowAddHome_Tick(object sender, EventArgs e)
        {
            if (hasAhome) { btnHome.BringToFront(); }
            tmrShowAddHome.Enabled = false;
        }

        private void tmrShowStatus_Tick(object sender, EventArgs e)
        {
            this.lblStatus.Text = CurrentStatus;
            this.lblStatus.Refresh();
            if (CurrentStatus == "Ready") { tmrShowStatus.Enabled = false; }
            ;
            if (CurrentStatus == "Empty Document") { tmrShowStatus.Enabled = false; }
            ;
            if (CurrentStatus == "Google failed, click again to Bing...") { tmrNavDone.Enabled = false; }
        }
    }
}
