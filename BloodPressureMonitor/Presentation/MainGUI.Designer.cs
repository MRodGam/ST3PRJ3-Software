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
            System.Windows.Forms.Button button1;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StartB = new System.Windows.Forms.Button();
            this.limitsB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.FilterRB = new System.Windows.Forms.RadioButton();
            this.EKGdiagram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EKGdiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.ForeColor = System.Drawing.Color.Silver;
            button1.Location = new System.Drawing.Point(35, 15);
            button1.Margin = new System.Windows.Forms.Padding(4);
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
            // 
            // limitsB
            // 
            this.limitsB.BackColor = System.Drawing.Color.Silver;
            this.limitsB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.limitsB.ForeColor = System.Drawing.Color.White;
            this.limitsB.Location = new System.Drawing.Point(624, 305);
            this.limitsB.Margin = new System.Windows.Forms.Padding(4);
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
            this.saveB.Margin = new System.Windows.Forms.Padding(4);
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
            this.clearB.Margin = new System.Windows.Forms.Padding(4);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(160, 31);
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
            this.pauseB.Location = new System.Drawing.Point(217, 382);
            this.pauseB.Margin = new System.Windows.Forms.Padding(4);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(567, 57);
            this.pauseB.TabIndex = 4;
            this.pauseB.Text = "Kvitter alarm ";
            this.pauseB.UseVisualStyleBackColor = false;
            this.pauseB.Visible = false;
            this.pauseB.Click += new System.EventHandler(this.pauseB_Click);
            // 
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(464, 386);
            this.FilterRB.Margin = new System.Windows.Forms.Padding(4);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(72, 21);
            this.FilterRB.TabIndex = 5;
            this.FilterRB.TabStop = true;
            this.FilterRB.Text = "Filtrer";
            this.FilterRB.UseVisualStyleBackColor = true;
            this.FilterRB.CheckedChanged += new System.EventHandler(this.FilterRB_CheckedChanged);
            // 
            // EKGdiagram
            // 
            this.EKGdiagram.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.Interval = 0.2D;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 16;
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Interval = 0.5D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineWidth = 3;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.MajorTickMark.LineWidth = 3;
            chartArea1.AxisX.Maximum = 10D;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 0.1D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.Interval = 1D;
            chartArea1.AxisX.ScaleView.SmallScrollMinSize = 0D;
            chartArea1.AxisX.ScaleView.SmallScrollSize = 5D;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.White;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            chartArea1.AxisX.ScrollBar.Size = 20D;
            chartArea1.AxisY.Interval = 0.5D;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 16;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.Interval = 1D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineWidth = 3;
            chartArea1.AxisY.MajorTickMark.LineWidth = 3;
            chartArea1.AxisY.Maximum = 3D;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.Interval = 0.2D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.CursorY.Interval = 0.05D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartArea1.CursorY.LineWidth = 2;
            chartArea1.CursorY.Position = 2D;
            chartArea1.Name = "ChartArea1";
            this.EKGdiagram.ChartAreas.Add(chartArea1);
            this.EKGdiagram.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.EKGdiagram.Legends.Add(legend1);
            this.EKGdiagram.Location = new System.Drawing.Point(-65, 68);
            this.EKGdiagram.Margin = new System.Windows.Forms.Padding(0);
            this.EKGdiagram.Name = "EKGdiagram";
            this.EKGdiagram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.EKGdiagram.Series.Add(series1);
            this.EKGdiagram.Size = new System.Drawing.Size(685, 271);
            this.EKGdiagram.TabIndex = 12;
            this.EKGdiagram.Text = "EKG diagram";
            // 
            // filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EKGdiagram);
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
            ((System.ComponentModel.ISupportInitialize)(this.EKGdiagram)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart EKGdiagram;
    }
}