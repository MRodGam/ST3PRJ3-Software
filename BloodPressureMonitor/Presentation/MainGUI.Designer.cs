﻿namespace Presentation
{
    partial class filter
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
            System.Windows.Forms.Button button1;
            this.StartB = new System.Windows.Forms.Button();
            this.limitsB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.FilterRB = new System.Windows.Forms.RadioButton();
            button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.ForeColor = System.Drawing.Color.Silver;
            button1.Location = new System.Drawing.Point(35, 15);
            button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(124, 26);
            button1.TabIndex = 6;
            button1.Text = "Kalibrer";
            button1.UseVisualStyleBackColor = false;
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.ForestGreen;
            this.StartB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(13, 382);
            this.StartB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(197, 57);
            this.StartB.TabIndex = 0;
            this.StartB.Text = "START MÅLING";
            this.StartB.UseVisualStyleBackColor = false;
            this.StartB.Click += new System.EventHandler(this.StartB_Click_1);
            // 
            // limitsB
            // 
            this.limitsB.BackColor = System.Drawing.Color.Silver;
            this.limitsB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.limitsB.ForeColor = System.Drawing.Color.White;
            this.limitsB.Location = new System.Drawing.Point(624, 305);
            this.limitsB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.limitsB.Name = "limitsB";
            this.limitsB.Size = new System.Drawing.Size(160, 31);
            this.limitsB.TabIndex = 1;
            this.limitsB.Text = "Grænseværdi";
            this.limitsB.UseVisualStyleBackColor = false;
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.saveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveB.ForeColor = System.Drawing.Color.White;
            this.saveB.Location = new System.Drawing.Point(624, 343);
            this.saveB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(160, 31);
            this.saveB.TabIndex = 2;
            this.saveB.Text = "Gem";
            this.saveB.UseVisualStyleBackColor = false;
            // 
            // clearB
            // 
            this.clearB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clearB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearB.ForeColor = System.Drawing.Color.White;
            this.clearB.Location = new System.Drawing.Point(624, 382);
            this.clearB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(160, 31);
            this.clearB.TabIndex = 3;
            this.clearB.Text = "Ryd";
            this.clearB.UseVisualStyleBackColor = false;
            // 
            // pauseB
            // 
            this.pauseB.BackColor = System.Drawing.Color.Silver;
            this.pauseB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseB.ForeColor = System.Drawing.Color.White;
            this.pauseB.Location = new System.Drawing.Point(272, 377);
            this.pauseB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(188, 36);
            this.pauseB.TabIndex = 4;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = false;
            // 
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(464, 386);
            this.FilterRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(72, 21);
            this.FilterRB.TabIndex = 5;
            this.FilterRB.TabStop = true;
            this.FilterRB.Text = "Filtrer";
            this.FilterRB.UseVisualStyleBackColor = true;
            // 
            // filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(button1);
            this.Controls.Add(this.FilterRB);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.limitsB);
            this.Controls.Add(this.StartB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "filter";
            this.Text = "MainGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.Button limitsB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.Button pauseB;
        private System.Windows.Forms.RadioButton FilterRB;
    }
}