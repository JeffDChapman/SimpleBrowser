namespace WebLoader
{
    partial class ImageZoomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageZoomer));
            pictureBox1 = new PictureBox();
            lbImageList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 187);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbImageList
            // 
            lbImageList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbImageList.FormattingEnabled = true;
            lbImageList.ItemHeight = 25;
            lbImageList.Location = new Point(40, 245);
            lbImageList.Name = "lbImageList";
            lbImageList.Size = new Size(213, 354);
            lbImageList.TabIndex = 1;
            lbImageList.SelectedValueChanged += lbImageList_SelectedValueChanged;
            // 
            // ImageZoomer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 625);
            Controls.Add(lbImageList);
            Controls.Add(pictureBox1);
            Name = "ImageZoomer";
            StartPosition = FormStartPosition.Manual;
            Text = "ImageZoomer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        public ListBox lbImageList;
    }
}