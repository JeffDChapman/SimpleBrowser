namespace WebLoader
{
    partial class EditFavDesc
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
            label1 = new Label();
            tbSaveName = new TextBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 28);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Save As:";
            // 
            // tbSaveName
            // 
            tbSaveName.BorderStyle = BorderStyle.FixedSingle;
            tbSaveName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbSaveName.Location = new Point(109, 24);
            tbSaveName.Name = "tbSaveName";
            tbSaveName.Size = new Size(602, 37);
            tbSaveName.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(621, 77);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(90, 38);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // EditFavDesc
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 125);
            Controls.Add(btnOK);
            Controls.Add(tbSaveName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EditFavDesc";
            Text = "Editing Favorites Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnOK;
        public TextBox tbSaveName;
    }
}