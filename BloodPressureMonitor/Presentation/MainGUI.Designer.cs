namespace Presentation
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
            this.StartB = new System.Windows.Forms.Button();
            this.limitsB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.FilterRB = new System.Windows.Forms.RadioButton();
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
            // limitsB
            // 
            this.limitsB.BackColor = System.Drawing.Color.Silver;
            this.limitsB.ForeColor = System.Drawing.Color.White;
            this.limitsB.Location = new System.Drawing.Point(468, 248);
            this.limitsB.Name = "limitsB";
            this.limitsB.Size = new System.Drawing.Size(120, 25);
            this.limitsB.TabIndex = 1;
            this.limitsB.Text = "Grænseværdi";
            this.limitsB.UseVisualStyleBackColor = false;
            // 
            // saveB
            // 
            this.saveB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.saveB.ForeColor = System.Drawing.Color.White;
            this.saveB.Location = new System.Drawing.Point(468, 279);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(120, 25);
            this.saveB.TabIndex = 2;
            this.saveB.Text = "Gem";
            this.saveB.UseVisualStyleBackColor = false;
            // 
            // clearB
            // 
            this.clearB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clearB.ForeColor = System.Drawing.Color.White;
            this.clearB.Location = new System.Drawing.Point(468, 310);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(120, 25);
            this.clearB.TabIndex = 3;
            this.clearB.Text = "Ryd";
            this.clearB.UseVisualStyleBackColor = false;
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
            // FilterRB
            // 
            this.FilterRB.AutoSize = true;
            this.FilterRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterRB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.FilterRB.Location = new System.Drawing.Point(348, 314);
            this.FilterRB.Name = "FilterRB";
            this.FilterRB.Size = new System.Drawing.Size(57, 17);
            this.FilterRB.TabIndex = 5;
            this.FilterRB.TabStop = true;
            this.FilterRB.Text = "Filtrer";
            this.FilterRB.UseVisualStyleBackColor = true;
            // 
            // filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.FilterRB);
            this.Controls.Add(this.pauseB);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.limitsB);
            this.Controls.Add(this.StartB);
            this.Margin = new System.Windows.Forms.Padding(2);
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