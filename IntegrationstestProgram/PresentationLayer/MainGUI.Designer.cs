namespace PresentationLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.AlarmPausedPictureBox = new System.Windows.Forms.PictureBox();
            this.AlarmPictureBox = new System.Windows.Forms.PictureBox();
            this.blodtryk_L = new System.Windows.Forms.Label();
            this.middel_L = new System.Windows.Forms.Label();
            this.puls_L = new System.Windows.Forms.Label();
            this.FilterRB = new System.Windows.Forms.RadioButton();
            this.pauseB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.limitsB = new System.Windows.Forms.Button();
            this.StartB = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPausedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.ForeColor = System.Drawing.Color.Silver;
            button1.Location = new System.Drawing.Point(37, 13);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(124, 26);
            button1.TabIndex = 20;
            button1.Text = "Kalibrer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlarmPausedPictureBox
            // 
            this.AlarmPausedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPausedPictureBox.Image")));
            this.AlarmPausedPictureBox.Location = new System.Drawing.Point(509, 128);
            this.AlarmPausedPictureBox.Name = "AlarmPausedPictureBox";
            this.AlarmPausedPictureBox.Size = new System.Drawing.Size(90, 90);
            this.AlarmPausedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPausedPictureBox.TabIndex = 25;
            this.AlarmPausedPictureBox.TabStop = false;
            this.AlarmPausedPictureBox.Visible = false;
            // 
            // AlarmPictureBox
            // 
            this.AlarmPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPictureBox.Image")));
            this.AlarmPictureBox.Location = new System.Drawing.Point(509, 128);
            this.AlarmPictureBox.Name = "AlarmPictureBox";
            this.AlarmPictureBox.Size = new System.Drawing.Size(90, 90);
            this.AlarmPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPictureBox.TabIndex = 24;
            this.AlarmPictureBox.TabStop = false;
            this.AlarmPictureBox.Visible = false;
            // 
            // blodtryk_L
            // 
            this.blodtryk_L.AutoSize = true;
            this.blodtryk_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blodtryk_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.blodtryk_L.Location = new System.Drawing.Point(645, 109);
            this.blodtryk_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blodtryk_L.Name = "blodtryk_L";
            this.blodtryk_L.Size = new System.Drawing.Size(90, 25);
            this.blodtryk_L.TabIndex = 23;
            this.blodtryk_L.Text = "Blodtryk";
            // 
            // middel_L
            // 
            this.middel_L.AutoSize = true;
            this.middel_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middel_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.middel_L.Location = new System.Drawing.Point(645, 209);
            this.middel_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.middel_L.Name = "middel_L";
            this.middel_L.Size = new System.Drawing.Size(76, 25);
            this.middel_L.TabIndex = 22;
            this.middel_L.Text = "Middel";
            // 
            // puls_L
            // 
            this.puls_L.AutoSize = true;
            this.puls_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puls_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.puls_L.Location = new System.Drawing.Point(645, 33);
            this.puls_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.puls_L.Name = "puls_L";
            this.puls_L.Size = new System.Drawing.Size(54, 25);
            this.puls_L.TabIndex = 21;
            this.puls_L.Text = "Puls";
            // 
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.BackColor = System.Drawing.Color.Transparent;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(626, 417);
            this.FilterRB.Margin = new System.Windows.Forms.Padding(4);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(72, 21);
            this.FilterRB.TabIndex = 19;
            this.FilterRB.TabStop = true;
            this.FilterRB.Text = "Filtrer";
            this.FilterRB.UseVisualStyleBackColor = false;
            // 
            // pauseB
            // 
            this.pauseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pauseB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseB.ForeColor = System.Drawing.Color.White;
            this.pauseB.Location = new System.Drawing.Point(221, 381);
            this.pauseB.Margin = new System.Windows.Forms.Padding(4);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(398, 57);
            this.pauseB.TabIndex = 18;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = false;
            this.pauseB.Visible = false;
            // 
            // clearB
            // 
            this.clearB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clearB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearB.ForeColor = System.Drawing.Color.White;
            this.clearB.Location = new System.Drawing.Point(626, 381);
            this.clearB.Margin = new System.Windows.Forms.Padding(4);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(160, 30);
            this.clearB.TabIndex = 17;
            this.clearB.Text = "Ryd";
            this.clearB.UseVisualStyleBackColor = false;
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.saveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveB.ForeColor = System.Drawing.Color.White;
            this.saveB.Location = new System.Drawing.Point(626, 342);
            this.saveB.Margin = new System.Windows.Forms.Padding(4);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(160, 30);
            this.saveB.TabIndex = 16;
            this.saveB.Text = "Gem";
            this.saveB.UseVisualStyleBackColor = false;
            // 
            // limitsB
            // 
            this.limitsB.BackColor = System.Drawing.Color.Silver;
            this.limitsB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.limitsB.ForeColor = System.Drawing.Color.White;
            this.limitsB.Location = new System.Drawing.Point(626, 305);
            this.limitsB.Margin = new System.Windows.Forms.Padding(4);
            this.limitsB.Name = "limitsB";
            this.limitsB.Size = new System.Drawing.Size(160, 30);
            this.limitsB.TabIndex = 15;
            this.limitsB.Text = "Juster grænseværdi";
            this.limitsB.UseVisualStyleBackColor = false;
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.ForestGreen;
            this.StartB.Enabled = false;
            this.StartB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(15, 381);
            this.StartB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(197, 57);
            this.StartB.TabIndex = 14;
            this.StartB.Text = "START MÅLING";
            this.StartB.UseVisualStyleBackColor = false;
            this.StartB.Click += new System.EventHandler(this.StartB_Click_1);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 46);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(599, 314);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AlarmPausedPictureBox);
            this.Controls.Add(this.AlarmPictureBox);
            this.Controls.Add(this.blodtryk_L);
            this.Controls.Add(this.middel_L);
            this.Controls.Add(this.puls_L);
            this.Controls.Add(button1);
            this.Controls.Add(this.FilterRB);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.limitsB);
            this.Controls.Add(this.StartB);
            this.Controls.Add(this.chart1);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPausedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AlarmPausedPictureBox;
        private System.Windows.Forms.PictureBox AlarmPictureBox;
        private System.Windows.Forms.Label blodtryk_L;
        private System.Windows.Forms.Label middel_L;
        private System.Windows.Forms.Label puls_L;
        private System.Windows.Forms.RadioButton FilterRB;
        private System.Windows.Forms.Button pauseB;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button limitsB;
        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}