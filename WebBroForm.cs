using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLoader
{
    public partial class WebBroForm : Form
    {
        public WebBroForm()
        {
            InitializeComponent();
        }

        private bool tbSkipNav = true;
        private string PriorPage = "";
        private string SavePage = "";
        private string homeLoc = "file:///C:/Users/jchapman/Desktop/Basics/Work%20Favorites.htm";

        private void WebBroForm_Load(object sender, EventArgs e)
        {
            this.btnBack.Enabled = false;
            this.myBrowser.Navigate(homeLoc);
        }

        private void myBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument fixDoc = myBrowser.Document;
            string pageBodyMod = fixDoc.Body.InnerHtml.ToString();
            string StopRecur = pageBodyMod.Substring(1, 4).ToLower();
            if (StopRecur == "font")
            {
                if (PriorPage != myBrowser.Url.ToString())
                    {this.btnBack.Enabled = true;}
                return; }
            pageBodyMod = pageBodyMod.Replace("font", "fnot");
            pageBodyMod = pageBodyMod.Replace("FONT", "FNOT");
            pageBodyMod = pageBodyMod.Replace("widt", "wdit");
            pageBodyMod = pageBodyMod.Replace("WIDT", "WDUT");
            pageBodyMod = pageBodyMod.Replace("styl", "stly");
            pageBodyMod = pageBodyMod.Replace("STYL", "STLY");
            pageBodyMod = pageBodyMod.Replace("scri", "srci");
            pageBodyMod = pageBodyMod.Replace("SCRI", "SRCI");
            pageBodyMod = pageBodyMod.Replace("Scri", "Srci");
            pageBodyMod = pageBodyMod.Replace("java", "jav");
            pageBodyMod = pageBodyMod.Replace("JAVA", "JAV");
            pageBodyMod = pageBodyMod.Replace("func", "fucn");
            pageBodyMod = pageBodyMod.Replace("FUNC", "FUCN");
            pageBodyMod = pageBodyMod.Replace("over", "ovre");
            pageBodyMod = pageBodyMod.Replace("OVER", "OVRE");
            pageBodyMod = pageBodyMod.Replace("mouseout", "mouesout");
            pageBodyMod = pageBodyMod.Replace("MOUSEOUT", "MOUESOUT");
            pageBodyMod = pageBodyMod.Replace("widg", "wigd");
            pageBodyMod = pageBodyMod.Replace("WIDG", "WIGD");
            pageBodyMod = pageBodyMod.Replace("onload", "onlaod");
            string pageBodyModshow = "<font face=\"verdana\">" + pageBodyMod;

            tbSkipNav = true;
            this.Text = myBrowser.DocumentTitle;
            myBrowser.Document.OpenNew(false);
            myBrowser.Document.Write(pageBodyModshow);
            myBrowser.Refresh();
            this.myAddrBar.Text = myBrowser.Url.ToString();
            tbSkipNav = false;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.myBrowser.Navigate(homeLoc);
        }

        private void myBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (tbSkipNav) { return; }
            SavePage = myBrowser.Url.ToString();
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            tbSkipNav = false;
            this.btnBack.Enabled = true;
            SavePage = myBrowser.Url.ToString();
            myBrowser.Navigate(myAddrBar.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbSkipNav = false;
            myBrowser.Navigate(PriorPage);
            PriorPage = SavePage;
            this.btnBack.Enabled = false;

        }
    }
}
