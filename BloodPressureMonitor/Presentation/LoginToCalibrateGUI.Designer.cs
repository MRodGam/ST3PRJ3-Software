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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginB
            // 
            this.loginB.BackColor = System.Drawing.Color.Gray;
            this.loginB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginB.ForeColor = System.Drawing.Color.White;
            this.loginB.Location = new System.Drawing.Point(100, 278);
            this.loginB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginB.Name = "loginB";
            this.loginB.Size = new System.Drawing.Size(112, 35);
            this.loginB.TabIndex = 0;
            this.loginB.Text = "Log in";
            this.loginB.UseVisualStyleBackColor = false;
            this.loginB.Click += new System.EventHandler(this.loginB_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(96, 106);
            this.username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(91, 20);
            this.username.TabIndex = 1;
            this.username.Text = "Brugernavn";
            this.username.Click += new System.EventHandler(this.username_Click);
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(100, 132);
            this.usernameTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(148, 26);
            this.usernameTB.TabIndex = 2;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(100, 212);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(148, 26);
            this.passwordTB.TabIndex = 3;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(100, 183);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(108, 20);
            this.password.TabIndex = 4;
            this.password.Text = "Adgangskode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(98, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Log in for at kalibrer";
            // 
            // LoginToCalibrateGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(576, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.username);
            this.Controls.Add(this.loginB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Label label1;
    }
}