namespace Presentation
{
    partial class MainGUI
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
            this.StartB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.ForestGreen;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(10, 310);
            this.StartB.Margin = new System.Windows.Forms.Padding(2);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(148, 46);
            this.StartB.TabIndex = 0;
            this.StartB.Text = "START MÅLING";
            this.StartB.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(468, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Grænseværdi";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(468, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Gem";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(468, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ryd";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pauseB
            // 
            this.pauseB.Location = new System.Drawing.Point(222, 312);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(75, 23);
            this.pauseB.TabIndex = 4;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = true;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button pauseB;
    }
}