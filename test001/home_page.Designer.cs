namespace test001
{
    partial class home_page
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_user_name = new System.Windows.Forms.Label();
            this.btn_signout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current User :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_user_name
            // 
            this.lb_user_name.AutoSize = true;
            this.lb_user_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user_name.Location = new System.Drawing.Point(142, 105);
            this.lb_user_name.Name = "lb_user_name";
            this.lb_user_name.Size = new System.Drawing.Size(0, 25);
            this.lb_user_name.TabIndex = 1;
            // 
            // btn_signout
            // 
            this.btn_signout.BackColor = System.Drawing.Color.MistyRose;
            this.btn_signout.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signout.Location = new System.Drawing.Point(12, 215);
            this.btn_signout.Name = "btn_signout";
            this.btn_signout.Size = new System.Drawing.Size(285, 86);
            this.btn_signout.TabIndex = 2;
            this.btn_signout.Text = "Sign Out";
            this.btn_signout.UseVisualStyleBackColor = false;
            this.btn_signout.Click += new System.EventHandler(this.Btn_signout_Click);
            // 
            // home_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 313);
            this.Controls.Add(this.btn_signout);
            this.Controls.Add(this.lb_user_name);
            this.Controls.Add(this.label1);
            this.Name = "home_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOME";
            this.Load += new System.EventHandler(this.Home_page_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_user_name;
        private System.Windows.Forms.Button btn_signout;
    }
}