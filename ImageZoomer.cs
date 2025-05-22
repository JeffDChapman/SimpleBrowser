using System.Diagnostics;
using System.Net;

namespace WebLoader
{
    public partial class ImageZoomer : Form
    {
        private int imgCounter = 0;
        public string imageBase;
        private WebBroForm myParent;
        private string fileToUse;

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
            string pageImage = actualImagePath;
            if (actualImagePath.ToLower().IndexOf("http") == -1)
                { pageImage = "https:" + actualImagePath; }
            string fileReturned = getLocalImage(pageImage);
            FileInfo fileInfo = new FileInfo(fileReturned);
            Application.DoEvents();
            if (fileReturned.Length > 0) { 
                try { this.pictureBox1.Image = Image.FromFile(fileReturned); }
                catch { } }
        }

        private string getLocalImage(string pageImage)
        {
            string imageFileName = "imageXX.YYY";
            imgCounter++;
            string fileToUseBase = imageFileName.Replace("XX", imgCounter.ToString());
            string fileExt = pageImage.Substring(pageImage.Length - 3);
            fileToUse = fileToUseBase.Replace("YYY", fileExt);
            string imageLocBase = pageImage;
            // string imageLoc = imageLocBase.Replace("&amp;", "&");
            string imageLoc = System.Web.HttpUtility.UrlDecode(imageLocBase);
            if (imageLoc[imageLoc.Length - 1] == '/') 
                { imageLoc = imageLoc.Substring(0, imageLoc.Length - 1); }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                try { client.DownloadFile(new Uri(imageLoc), fileToUse); }
                catch { MessageBox.Show("Failed To Get: " + imageLoc); }
            }
            return fileToUse;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string processBase = System.Environment.ProcessPath;
            string baseToUse = processBase.Substring(0,processBase.Length - 13);
            string fileToOpen = baseToUse + fileToUse;
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(fileToOpen) {UseShellExecute = true};
            p.Start();
        }
    }
}
