﻿namespace Presentation
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
            System.Windows.Forms.Button button1;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.StartB = new System.Windows.Forms.Button();
            this.limitsB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.FilterRB = new System.Windows.Forms.RadioButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.puls_L = new System.Windows.Forms.Label();
            this.middel_L = new System.Windows.Forms.Label();
            this.blodtryk_L = new System.Windows.Forms.Label();
            this.AlarmPictureBox = new System.Windows.Forms.PictureBox();
            this.AlarmPausedPictureBox = new System.Windows.Forms.PictureBox();
            this.kaliTekst_L = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPausedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.ForeColor = System.Drawing.Color.Silver;
            button1.Location = new System.Drawing.Point(39, 18);
            button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(140, 32);
            button1.TabIndex = 6;
            button1.Text = "Kalibrer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.ForestGreen;
            this.StartB.Enabled = false;
            this.StartB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(15, 478);
            this.StartB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(222, 71);
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
            this.limitsB.Location = new System.Drawing.Point(702, 382);
            this.limitsB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.limitsB.Name = "limitsB";
            this.limitsB.Size = new System.Drawing.Size(180, 38);
            this.limitsB.TabIndex = 1;
            this.limitsB.Text = "Juster grænseværdi";
            this.limitsB.UseVisualStyleBackColor = false;
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.saveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveB.ForeColor = System.Drawing.Color.White;
            this.saveB.Location = new System.Drawing.Point(702, 429);
            this.saveB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(180, 38);
            this.saveB.TabIndex = 2;
            this.saveB.Text = "Gem";
            this.saveB.UseVisualStyleBackColor = false;
            // 
            // clearB
            // 
            this.clearB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clearB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearB.ForeColor = System.Drawing.Color.White;
            this.clearB.Location = new System.Drawing.Point(702, 478);
            this.clearB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(180, 38);
            this.clearB.TabIndex = 3;
            this.clearB.Text = "Ryd";
            this.clearB.UseVisualStyleBackColor = false;
            // 
            // pauseB
            // 
            this.pauseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pauseB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseB.ForeColor = System.Drawing.Color.White;
            this.pauseB.Location = new System.Drawing.Point(246, 478);
            this.pauseB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(448, 71);
            this.pauseB.TabIndex = 4;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = false;
            this.pauseB.Visible = false;
            this.pauseB.Click += new System.EventHandler(this.pauseB_Click);
            // 
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.BackColor = System.Drawing.Color.Transparent;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(702, 522);
            this.FilterRB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(85, 24);
            this.FilterRB.TabIndex = 5;
            this.FilterRB.TabStop = true;
            this.FilterRB.Text = "Filtrer";
            this.FilterRB.UseVisualStyleBackColor = false;
            this.FilterRB.CheckedChanged += new System.EventHandler(this.FilterRB_CheckedChanged_1);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(18, 78);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series1.BackImageTransparentColor = System.Drawing.Color.Black;
            series1.BackSecondaryColor = System.Drawing.Color.Black;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(675, 372);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // puls_L
            // 
            this.puls_L.AutoSize = true;
            this.puls_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puls_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.puls_L.Location = new System.Drawing.Point(723, 42);
            this.puls_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.puls_L.Name = "puls_L";
            this.puls_L.Size = new System.Drawing.Size(64, 29);
            this.puls_L.TabIndex = 8;
            this.puls_L.Text = "Puls";
            // 
            // middel_L
            // 
            this.middel_L.AutoSize = true;
            this.middel_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middel_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.middel_L.Location = new System.Drawing.Point(723, 262);
            this.middel_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.middel_L.Name = "middel_L";
            this.middel_L.Size = new System.Drawing.Size(93, 29);
            this.middel_L.TabIndex = 9;
            this.middel_L.Text = "Middel";
            // 
            // blodtryk_L
            // 
            this.blodtryk_L.AutoSize = true;
            this.blodtryk_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blodtryk_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.blodtryk_L.Location = new System.Drawing.Point(723, 138);
            this.blodtryk_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blodtryk_L.Name = "blodtryk_L";
            this.blodtryk_L.Size = new System.Drawing.Size(108, 29);
            this.blodtryk_L.TabIndex = 11;
            this.blodtryk_L.Text = "Blodtryk";
            // 
            // AlarmPictureBox
            // 
            this.AlarmPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPictureBox.Image")));
            this.AlarmPictureBox.Location = new System.Drawing.Point(570, 161);
            this.AlarmPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AlarmPictureBox.Name = "AlarmPictureBox";
            this.AlarmPictureBox.Size = new System.Drawing.Size(101, 112);
            this.AlarmPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPictureBox.TabIndex = 12;
            this.AlarmPictureBox.TabStop = false;
            this.AlarmPictureBox.Visible = false;
            // 
            // AlarmPausedPictureBox
            // 
            this.AlarmPausedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPausedPictureBox.Image")));
            this.AlarmPausedPictureBox.Location = new System.Drawing.Point(570, 161);
            this.AlarmPausedPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AlarmPausedPictureBox.Name = "AlarmPausedPictureBox";
            this.AlarmPausedPictureBox.Size = new System.Drawing.Size(101, 112);
            this.AlarmPausedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPausedPictureBox.TabIndex = 13;
            this.AlarmPausedPictureBox.TabStop = false;
            this.AlarmPausedPictureBox.Visible = false;
            // 
            // kaliTekst_L
            // 
            this.kaliTekst_L.AutoSize = true;
            this.kaliTekst_L.BackColor = System.Drawing.SystemColors.ControlText;
            this.kaliTekst_L.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.kaliTekst_L.Location = new System.Drawing.Point(200, 29);
            this.kaliTekst_L.Name = "kaliTekst_L";
            this.kaliTekst_L.Size = new System.Drawing.Size(0, 20);
            this.kaliTekst_L.TabIndex = 14;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.kaliTekst_L);
            this.Controls.Add(this.AlarmPausedPictureBox);
            this.Controls.Add(this.AlarmPictureBox);
            this.Controls.Add(this.blodtryk_L);
            this.Controls.Add(this.middel_L);
            this.Controls.Add(this.puls_L);
            this.Controls.Add(this.chart1);
            this.Controls.Add(button1);
            this.Controls.Add(this.FilterRB);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.limitsB);
            this.Controls.Add(this.StartB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPausedPictureBox)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label puls_L;
        private System.Windows.Forms.Label middel_L;
        private System.Windows.Forms.Label blodtryk_L;
        private System.Windows.Forms.PictureBox AlarmPictureBox;
        private System.Windows.Forms.PictureBox AlarmPausedPictureBox;
        private System.Windows.Forms.Label kaliTekst_L;
    }
}