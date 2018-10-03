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
            this.btnPost = new System.Windows.Forms.Button();
            this.pbImagemLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnderecoId = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tboEnderecoId = new System.Windows.Forms.TextBox();
            this.tboEmail = new System.Windows.Forms.TextBox();
            this.tboNome = new System.Windows.Forms.TextBox();
            this.btnSelectImagemLogo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImagemFooter = new System.Windows.Forms.PictureBox();
            this.btnSelectImagemFooter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemFooter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPost
            // 
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Location = new System.Drawing.Point(234, 553);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(174, 28);
            this.btnPost.TabIndex = 10;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // pbImagemLogo
            // 
            this.pbImagemLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagemLogo.Location = new System.Drawing.Point(45, 195);
            this.pbImagemLogo.Name = "pbImagemLogo";
            this.pbImagemLogo.Size = new System.Drawing.Size(363, 117);
            this.pbImagemLogo.TabIndex = 13;
            this.pbImagemLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Novo Laboratório";
            // 
            // lblEnderecoId
            // 
            this.lblEnderecoId.AutoSize = true;
            this.lblEnderecoId.Location = new System.Drawing.Point(53, 68);
            this.lblEnderecoId.Name = "lblEnderecoId";
            this.lblEnderecoId.Size = new System.Drawing.Size(61, 13);
            this.lblEnderecoId.TabIndex = 15;
            this.lblEnderecoId.Text = "enderecoId";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(81, 94);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(33, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "ImagemLogo";
            // 
            // tboEnderecoId
            // 
            this.tboEnderecoId.Location = new System.Drawing.Point(125, 65);
            this.tboEnderecoId.Name = "tboEnderecoId";
            this.tboEnderecoId.Size = new System.Drawing.Size(100, 20);
            this.tboEnderecoId.TabIndex = 20;
            // 
            // tboEmail
            // 
            this.tboEmail.Location = new System.Drawing.Point(125, 117);
            this.tboEmail.Name = "tboEmail";
            this.tboEmail.Size = new System.Drawing.Size(100, 20);
            this.tboEmail.TabIndex = 22;
            // 
            // tboNome
            // 
            this.tboNome.Location = new System.Drawing.Point(125, 91);
            this.tboNome.Name = "tboNome";
            this.tboNome.Size = new System.Drawing.Size(100, 20);
            this.tboNome.TabIndex = 23;
            // 
            // btnSelectImagemLogo
            // 
            this.btnSelectImagemLogo.Location = new System.Drawing.Point(274, 318);
            this.btnSelectImagemLogo.Name = "btnSelectImagemLogo";
            this.btnSelectImagemLogo.Size = new System.Drawing.Size(134, 23);
            this.btnSelectImagemLogo.TabIndex = 24;
            this.btnSelectImagemLogo.Text = "Selecionar Imagem";
            this.btnSelectImagemLogo.UseVisualStyleBackColor = true;
            this.btnSelectImagemLogo.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "ImagemFooter";
            // 
            // pbImagemFooter
            // 
            this.pbImagemFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagemFooter.Location = new System.Drawing.Point(45, 381);
            this.pbImagemFooter.Name = "pbImagemFooter";
            this.pbImagemFooter.Size = new System.Drawing.Size(363, 117);
            this.pbImagemFooter.TabIndex = 26;
            this.pbImagemFooter.TabStop = false;
            // 
            // btnSelectImagemFooter
            // 
            this.btnSelectImagemFooter.Location = new System.Drawing.Point(274, 504);
            this.btnSelectImagemFooter.Name = "btnSelectImagemFooter";
            this.btnSelectImagemFooter.Size = new System.Drawing.Size(134, 23);
            this.btnSelectImagemFooter.TabIndex = 27;
            this.btnSelectImagemFooter.Text = "Selecionar Imagem";
            this.btnSelectImagemFooter.UseVisualStyleBackColor = true;
            this.btnSelectImagemFooter.Click += new System.EventHandler(this.btnSelectImagemFooter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 614);
            this.Controls.Add(this.btnSelectImagemFooter);
            this.Controls.Add(this.pbImagemFooter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectImagemLogo);
            this.Controls.Add(this.tboNome);
            this.Controls.Add(this.tboEmail);
            this.Controls.Add(this.tboEnderecoId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEnderecoId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImagemLogo);
            this.Controls.Add(this.btnPost);
            this.Name = "Form1";
            this.Text = "Teste de API";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemFooter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.PictureBox pbImagemLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnderecoId;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboEnderecoId;
        private System.Windows.Forms.TextBox tboEmail;
        private System.Windows.Forms.TextBox tboNome;
        private System.Windows.Forms.Button btnSelectImagemLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbImagemFooter;
        private System.Windows.Forms.Button btnSelectImagemFooter;
    }
}

