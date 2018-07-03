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
            this.pbImagemTeste = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tboExameId = new System.Windows.Forms.TextBox();
            this.tboStatus = new System.Windows.Forms.TextBox();
            this.tboPacienteId = new System.Windows.Forms.TextBox();
            this.tboClinicaId = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemTeste)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPost
            // 
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Location = new System.Drawing.Point(234, 377);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(174, 28);
            this.btnPost.TabIndex = 10;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // pbImagemTeste
            // 
            this.pbImagemTeste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagemTeste.Location = new System.Drawing.Point(45, 195);
            this.pbImagemTeste.Name = "pbImagemTeste";
            this.pbImagemTeste.Size = new System.Drawing.Size(363, 117);
            this.pbImagemTeste.TabIndex = 13;
            this.pbImagemTeste.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Novo Teste";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Exame_Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Clinica_Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Paciente_Id:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Imagem do Exame:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Status:";
            // 
            // tboExameId
            // 
            this.tboExameId.Location = new System.Drawing.Point(125, 65);
            this.tboExameId.Name = "tboExameId";
            this.tboExameId.Size = new System.Drawing.Size(100, 20);
            this.tboExameId.TabIndex = 20;
            // 
            // tboStatus
            // 
            this.tboStatus.Location = new System.Drawing.Point(125, 143);
            this.tboStatus.Name = "tboStatus";
            this.tboStatus.Size = new System.Drawing.Size(100, 20);
            this.tboStatus.TabIndex = 21;
            // 
            // tboPacienteId
            // 
            this.tboPacienteId.Location = new System.Drawing.Point(125, 117);
            this.tboPacienteId.Name = "tboPacienteId";
            this.tboPacienteId.Size = new System.Drawing.Size(100, 20);
            this.tboPacienteId.TabIndex = 22;
            // 
            // tboClinicaId
            // 
            this.tboClinicaId.Location = new System.Drawing.Point(125, 91);
            this.tboClinicaId.Name = "tboClinicaId";
            this.tboClinicaId.Size = new System.Drawing.Size(100, 20);
            this.tboClinicaId.TabIndex = 23;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(274, 318);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(134, 23);
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "Selecionar Imagem";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 614);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.tboClinicaId);
            this.Controls.Add(this.tboPacienteId);
            this.Controls.Add(this.tboStatus);
            this.Controls.Add(this.tboExameId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImagemTeste);
            this.Controls.Add(this.btnPost);
            this.Name = "Form1";
            this.Text = "Teste de API";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemTeste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.PictureBox pbImagemTeste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboExameId;
        private System.Windows.Forms.TextBox tboStatus;
        private System.Windows.Forms.TextBox tboPacienteId;
        private System.Windows.Forms.TextBox tboClinicaId;
        private System.Windows.Forms.Button btnSelect;
    }
}

