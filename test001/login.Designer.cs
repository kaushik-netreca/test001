namespace test001
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_access_code = new System.Windows.Forms.TextBox();
            this.txb_user_name = new System.Windows.Forms.TextBox();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Code : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            // 
            // txb_access_code
            // 
            this.txb_access_code.Location = new System.Drawing.Point(250, 301);
            this.txb_access_code.Name = "txb_access_code";
            this.txb_access_code.Size = new System.Drawing.Size(178, 26);
            this.txb_access_code.TabIndex = 3;
            // 
            // txb_user_name
            // 
            this.txb_user_name.Location = new System.Drawing.Point(250, 350);
            this.txb_user_name.Name = "txb_user_name";
            this.txb_user_name.Size = new System.Drawing.Size(178, 26);
            this.txb_user_name.TabIndex = 4;
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(250, 402);
            this.txb_password.Name = "txb_password";
            this.txb_password.PasswordChar = '*';
            this.txb_password.Size = new System.Drawing.Size(178, 26);
            this.txb_password.TabIndex = 5;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(37, 469);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(507, 69);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.txb_user_name);
            this.Controls.Add(this.txb_access_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_access_code;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txb_user_name;
    }
}

