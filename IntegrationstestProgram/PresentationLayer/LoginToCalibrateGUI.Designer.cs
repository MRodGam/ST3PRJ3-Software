namespace PresentationLayer
{
    partial class LoginToCalibrateGUI
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
            this.password = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.loginB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Log in for at kalibrer";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(15, 121);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(95, 17);
            this.password.TabIndex = 10;
            this.password.Text = "Adgangskode";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(15, 145);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(132, 22);
            this.passwordTB.TabIndex = 9;
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(15, 81);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(132, 22);
            this.usernameTB.TabIndex = 8;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(11, 60);
            this.username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(82, 17);
            this.username.TabIndex = 7;
            this.username.Text = "Brugernavn";
            // 
            // loginB
            // 
            this.loginB.BackColor = System.Drawing.Color.Gray;
            this.loginB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginB.ForeColor = System.Drawing.Color.White;
            this.loginB.Location = new System.Drawing.Point(15, 197);
            this.loginB.Margin = new System.Windows.Forms.Padding(4);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(100, 28);
            this.loginB.TabIndex = 6;
            this.loginB.Text = "Log in";
            this.loginB.UseVisualStyleBackColor = false;
            this.loginB.Click += new System.EventHandler(this.loginB_Click);
            // 
            // LoginToCalibrateGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.username);
            this.Controls.Add(this.loginB);
            this.Name = "LoginToCalibrateGUI";
            this.Text = "LoginToCalibrateGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button loginB;
    }
}