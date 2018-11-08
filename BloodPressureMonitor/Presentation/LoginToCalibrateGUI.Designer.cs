namespace Presentation
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
            this.loginB = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginB
            // 
            this.loginB.BackColor = System.Drawing.Color.Gray;
            this.loginB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginB.ForeColor = System.Drawing.Color.White;
            this.loginB.Location = new System.Drawing.Point(70, 190);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(75, 23);
            this.loginB.TabIndex = 0;
            this.loginB.Text = "Log in";
            this.loginB.UseVisualStyleBackColor = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(64, 69);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(62, 13);
            this.username.TabIndex = 1;
            this.username.Text = "Brugernavn";
            this.username.Click += new System.EventHandler(this.username_Click);
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(67, 86);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(100, 20);
            this.usernameTB.TabIndex = 2;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(67, 138);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 3;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(67, 119);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(73, 13);
            this.password.TabIndex = 4;
            this.password.Text = "Adgangskode";
            // 
            // LoginToCalibrateGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.username);
            this.Controls.Add(this.loginB);
            this.Name = "LoginToCalibrateGUI";
            this.Text = "LoginToCalibrateGUI";
            this.Load += new System.EventHandler(this.LoginToCalibrateGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginB;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label password;
    }
}