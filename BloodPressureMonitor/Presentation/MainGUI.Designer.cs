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
            this.SuspendLayout();
            // 
            // StartB
            // 
            this.StartB.BackColor = System.Drawing.Color.ForestGreen;
            this.StartB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartB.Location = new System.Drawing.Point(13, 381);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(198, 57);
            this.StartB.TabIndex = 0;
            this.StartB.Text = "START MÅLING";
            this.StartB.UseVisualStyleBackColor = false;
            this.StartB.Click += new System.EventHandler(this.StartB_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartB);
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button StartB;
    }
}