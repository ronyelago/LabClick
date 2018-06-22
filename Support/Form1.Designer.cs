namespace Support
{
    partial class Form1
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
            this.btnGet = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtGet = new System.Windows.Forms.TextBox();
            this.btnSeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGet.Location = new System.Drawing.Point(364, 361);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(83, 26);
            this.btnGet.TabIndex = 7;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 364);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 8;
            this.lblUrl.Text = "URL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "File Path:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnPost
            // 
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Location = new System.Drawing.Point(364, 30);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(83, 28);
            this.btnPost.TabIndex = 10;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(197, 394);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(161, 198);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(69, 30);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(289, 20);
            this.txtPost.TabIndex = 14;
            // 
            // txtGet
            // 
            this.txtGet.Location = new System.Drawing.Point(50, 361);
            this.txtGet.Name = "txtGet";
            this.txtGet.Size = new System.Drawing.Size(308, 20);
            this.txtGet.TabIndex = 15;
            // 
            // btnSeed
            // 
            this.btnSeed.Location = new System.Drawing.Point(364, 80);
            this.btnSeed.Name = "btnSeed";
            this.btnSeed.Size = new System.Drawing.Size(75, 23);
            this.btnSeed.TabIndex = 16;
            this.btnSeed.Text = "Run Seed";
            this.btnSeed.UseVisualStyleBackColor = true;
            this.btnSeed.Click += new System.EventHandler(this.btnSeed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 614);
            this.Controls.Add(this.btnSeed);
            this.Controls.Add(this.txtGet);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnGet);
            this.Name = "Form1";
            this.Text = "Teste de API";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.TextBox txtGet;
        private System.Windows.Forms.Button btnSeed;
    }
}

