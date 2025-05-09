using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLoader
{
    public partial class ImageZoomer : Form
    {
        private int imgCounter = 0;
        public string imageBase;
        private WebBroForm myParent;

        public ImageZoomer(WebBroForm parent)
        {
            InitializeComponent();
            myParent = parent;
        }

        private void lbImageList_SelectedValueChanged(object sender, EventArgs e)
        {
            int imageIndex = lbImageList.SelectedIndex;
            string actualImagePath = myParent.webpageImages[imageIndex].ToString();
            // string pageImage = "https://" + imageBase + actualImagePath;
            string pageImage = "https:" + actualImagePath;
            string fileReturned = getLocalImage(pageImage);
            FileInfo fileInfo = new FileInfo(fileReturned);
            Application.DoEvents();
            if (fileReturned.Length > 0) { this.pictureBox1.Image = Image.FromFile(fileReturned); }
        }

        private string getLocalImage(string pageImage)
        {
            string imageFileName = "imageXX.png";
            imgCounter++;
            string fileToUse = imageFileName.Replace("XX", imgCounter.ToString());
            string imageLocBase = pageImage;
            string imageLoc = imageLocBase.Replace("&amp;", "&");
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                client.DownloadFile(new Uri(imageLoc), fileToUse);
            }
            return fileToUse;
        }
    }
}
