using System.Diagnostics;
using System.Net;
using System.Security.Policy;

namespace WebLoader
{
    public partial class ImageZoomer : Form
    {
        public string imageBase;
        private WebBroForm myParent;
        private string fileToUse;
        private bool gotTheFile;

        public ImageZoomer(WebBroForm parent)
        {
            InitializeComponent();
            myParent = parent;
        }

        private void lbImageList_SelectedValueChanged(object sender, EventArgs e)
        {
            int imageIndex = lbImageList.SelectedIndex;
            string actualImagePath = myParent.webpageImages[imageIndex].ToString();
            string pageImage = actualImagePath;
            if (actualImagePath.ToLower().IndexOf("http") == -1)
                { pageImage = "https:" + actualImagePath; }
            string fileReturned = getLocalImageAsync(pageImage);
            FileInfo fileInfo = new FileInfo(fileReturned);
            Application.DoEvents();
            if (fileReturned.Length > 0) { 
                try { this.pictureBox1.Image = Image.FromFile(fileReturned); }
                catch { } }
        }

        private string getLocalImageAsync(string pageImage)
        {
            string imageFileName = "imageXX.YYY";
            Program.imageCounter++;
            string fileToUseBase = imageFileName.Replace("XX", Program.imageCounter.ToString());
            string imageTrim = pageImage.Trim();
            if (imageTrim.Substring(imageTrim.Length - 1) == "?")
                { imageTrim = imageTrim.Substring(0, imageTrim.Length - 1); }
            string fileExt = imageTrim.Substring(imageTrim.Length - 3);
            fileToUse = fileToUseBase.Replace("YYY", fileExt);
            string imageLocBase = imageTrim;
            string imageLoc = System.Web.HttpUtility.UrlDecode(imageLocBase);
            if (imageLoc[imageLoc.Length - 1] == '/') 
                { imageLoc = imageLoc.Substring(0, imageLoc.Length - 1); }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                try { client.DownloadFile(new Uri(imageLoc), fileToUse); }
                catch { MessageBox.Show("Failed To Get: " + imageLoc); }
            }

            //await DownloadFileAsync(imageLoc, fileToUse).WaitAsync(TimeSpan.FromSeconds(2));
            //if (!gotTheFile) { MessageBox.Show("Failed To Get: " + imageLoc); }
            return fileToUse;
        }

        //public async Task DownloadFileAsync(string url, string outputPath)
        //{
        //    gotTheFile = false;
        //    using HttpClient client = new HttpClient();
        //    using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).WaitAsync(TimeSpan.FromSeconds(2));
        //    response.EnsureSuccessStatusCode();

        //    using Stream downloadStream = await response.Content.ReadAsStreamAsync();
        //    using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
        //    await downloadStream.CopyToAsync(fileStream);
        //    gotTheFile = true;
        //}

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
