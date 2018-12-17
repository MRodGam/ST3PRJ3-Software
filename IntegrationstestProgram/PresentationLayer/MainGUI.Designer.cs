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
            System.Windows.Forms.Button calibrateB;
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
            this.PulsL = new System.Windows.Forms.Label();
            this.SystoliskL = new System.Windows.Forms.Label();
            this.MiddelL = new System.Windows.Forms.Label();
            this.DiastoliskL = new System.Windows.Forms.Label();
            this.kaliTekst_L = new System.Windows.Forms.Label();
            calibrateB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPausedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // calibrateB
            // 
            calibrateB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            calibrateB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            calibrateB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            calibrateB.ForeColor = System.Drawing.Color.Silver;
            calibrateB.Location = new System.Drawing.Point(22, 13);
            calibrateB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            calibrateB.Name = "calibrateB";
            calibrateB.Size = new System.Drawing.Size(124, 26);
            calibrateB.TabIndex = 35;
            calibrateB.Text = "Kalibrer";
            calibrateB.UseVisualStyleBackColor = false;
            calibrateB.Click += new System.EventHandler(this.calibrateB_Click);
            // 
            // AlarmPausedPictureBox
            // 
            this.AlarmPausedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPausedPictureBox.Image")));
            this.AlarmPausedPictureBox.Location = new System.Drawing.Point(1209, 468);
            this.AlarmPausedPictureBox.Name = "AlarmPausedPictureBox";
            this.AlarmPausedPictureBox.Size = new System.Drawing.Size(116, 112);
            this.AlarmPausedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPausedPictureBox.TabIndex = 25;
            this.AlarmPausedPictureBox.TabStop = false;
            this.AlarmPausedPictureBox.Visible = false;
            // 
            // AlarmPictureBox
            // 
            this.AlarmPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AlarmPictureBox.Image")));
            this.AlarmPictureBox.Location = new System.Drawing.Point(1209, 468);
            this.AlarmPictureBox.Name = "AlarmPictureBox";
            this.AlarmPictureBox.Size = new System.Drawing.Size(116, 112);
            this.AlarmPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlarmPictureBox.TabIndex = 24;
            this.AlarmPictureBox.TabStop = false;
            this.AlarmPictureBox.Visible = false;
            // 
            // blodtryk_L
            // 
            this.blodtryk_L.AutoSize = true;
            this.blodtryk_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blodtryk_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.blodtryk_L.Location = new System.Drawing.Point(1192, 170);
            this.blodtryk_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blodtryk_L.Name = "blodtryk_L";
            this.blodtryk_L.Size = new System.Drawing.Size(70, 18);
            this.blodtryk_L.TabIndex = 23;
            this.blodtryk_L.Text = "Blodtryk";
            // 
            // middel_L
            // 
            this.middel_L.AutoSize = true;
            this.middel_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middel_L.ForeColor = System.Drawing.Color.DarkGreen;
            this.middel_L.Location = new System.Drawing.Point(1192, 330);
            this.middel_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.middel_L.Name = "middel_L";
            this.middel_L.Size = new System.Drawing.Size(57, 18);
            this.middel_L.TabIndex = 22;
            this.middel_L.Text = "Middel";
            // 
            // puls_L
            // 
            this.puls_L.AutoSize = true;
            this.puls_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puls_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.puls_L.Location = new System.Drawing.Point(1192, 49);
            this.puls_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.puls_L.Name = "puls_L";
            this.puls_L.Size = new System.Drawing.Size(41, 18);
            this.puls_L.TabIndex = 21;
            this.puls_L.Text = "Puls";
            // 
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.BackColor = System.Drawing.Color.Transparent;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(349, 651);
            this.FilterRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(104, 33);
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
            this.pauseB.Location = new System.Drawing.Point(346, 627);
            this.pauseB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(1023, 57);
            this.pauseB.TabIndex = 18;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = false;
            this.pauseB.Visible = false;
            this.pauseB.Click += new System.EventHandler(this.pauseB_Click_1);
            // 
            // clearB
            // 
            this.clearB.BackColor = System.Drawing.SystemColors.GrayText;
            this.clearB.Enabled = false;
            this.clearB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearB.ForeColor = System.Drawing.Color.White;
            this.clearB.Location = new System.Drawing.Point(1185, 627);
            this.clearB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(183, 57);
            this.clearB.TabIndex = 17;
            this.clearB.Text = "Ryd";
            this.clearB.UseVisualStyleBackColor = false;
            this.clearB.Click += new System.EventHandler(this.clearB_Click);
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.SystemColors.GrayText;
            this.saveB.Enabled = false;
            this.saveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveB.ForeColor = System.Drawing.Color.White;
            this.saveB.Location = new System.Drawing.Point(981, 627);
            this.saveB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(183, 57);
            this.saveB.TabIndex = 16;
            this.saveB.Text = "Gem";
            this.saveB.UseVisualStyleBackColor = false;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // limitsB
            // 
            this.limitsB.BackColor = System.Drawing.Color.DimGray;
            this.limitsB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.limitsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitsB.ForeColor = System.Drawing.Color.White;
            this.limitsB.Location = new System.Drawing.Point(775, 627);
            this.limitsB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.limitsB.Name = "limitsB";
            this.limitsB.Size = new System.Drawing.Size(186, 57);
            this.limitsB.TabIndex = 15;
            this.limitsB.Text = "Juster grænseværdi";
            this.limitsB.UseVisualStyleBackColor = false;
            this.limitsB.Click += new System.EventHandler(this.limitsB_Click);
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.StartB.Enabled = false;
            this.StartB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(22, 627);
            this.StartB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(305, 57);
            this.StartB.TabIndex = 14;
            this.StartB.Text = "START MÅLING";
            this.StartB.UseVisualStyleBackColor = false;
            this.StartB.Click += new System.EventHandler(this.StartB_Click_1);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.Interval = 60D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MinorGrid.Interval = 1D;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.Interval = 20D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.MinorGrid.Interval = 5D;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BorderColor = System.Drawing.Color.DimGray;
            chartArea2.CursorY.Interval = 0.05D;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.LineWidth = 2;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(23, 48);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1156, 563);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            // 
            // PulsL
            // 
            this.PulsL.AutoSize = true;
            this.PulsL.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsL.ForeColor = System.Drawing.Color.LimeGreen;
            this.PulsL.Location = new System.Drawing.Point(1199, 67);
            this.PulsL.Name = "PulsL";
            this.PulsL.Size = new System.Drawing.Size(0, 55);
            this.PulsL.TabIndex = 29;
            // 
            // SystoliskL
            // 
            this.SystoliskL.AutoSize = true;
            this.SystoliskL.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystoliskL.ForeColor = System.Drawing.Color.ForestGreen;
            this.SystoliskL.Location = new System.Drawing.Point(1199, 187);
            this.SystoliskL.Name = "SystoliskL";
            this.SystoliskL.Size = new System.Drawing.Size(0, 55);
            this.SystoliskL.TabIndex = 31;
            // 
            // MiddelL
            // 
            this.MiddelL.AutoSize = true;
            this.MiddelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddelL.ForeColor = System.Drawing.Color.ForestGreen;
            this.MiddelL.Location = new System.Drawing.Point(1199, 366);
            this.MiddelL.Name = "MiddelL";
            this.MiddelL.Size = new System.Drawing.Size(0, 55);
            this.MiddelL.TabIndex = 32;
            // 
            // DiastoliskL
            // 
            this.DiastoliskL.AutoSize = true;
            this.DiastoliskL.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiastoliskL.ForeColor = System.Drawing.Color.ForestGreen;
            this.DiastoliskL.Location = new System.Drawing.Point(1271, 232);
            this.DiastoliskL.Name = "DiastoliskL";
            this.DiastoliskL.Size = new System.Drawing.Size(0, 55);
            this.DiastoliskL.TabIndex = 33;
            // 
            // kaliTekst_L
            // 
            this.kaliTekst_L.AutoSize = true;
            this.kaliTekst_L.BackColor = System.Drawing.SystemColors.ControlText;
            this.kaliTekst_L.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.kaliTekst_L.Location = new System.Drawing.Point(166, 18);
            this.kaliTekst_L.Name = "kaliTekst_L";
            this.kaliTekst_L.Size = new System.Drawing.Size(0, 17);
            this.kaliTekst_L.TabIndex = 36;
            this.kaliTekst_L.Click += new System.EventHandler(this.kaliTekst_L_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1382, 706);
            this.Controls.Add(this.kaliTekst_L);
            this.Controls.Add(calibrateB);
            this.Controls.Add(this.DiastoliskL);
            this.Controls.Add(this.MiddelL);
            this.Controls.Add(this.SystoliskL);
            this.Controls.Add(this.PulsL);
            this.Controls.Add(this.AlarmPausedPictureBox);
            this.Controls.Add(this.AlarmPictureBox);
            this.Controls.Add(this.blodtryk_L);
            this.Controls.Add(this.middel_L);
            this.Controls.Add(this.puls_L);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.limitsB);
            this.Controls.Add(this.StartB);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.FilterRB);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.Load += new System.EventHandler(this.MainGUI_Load);
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
        private System.Windows.Forms.Label PulsL;
        private System.Windows.Forms.Label SystoliskL;
        private System.Windows.Forms.Label MiddelL;
        private System.Windows.Forms.Label DiastoliskL;
        private System.Windows.Forms.Label kaliTekst_L;
    }
}