namespace PresentationLayer
{
    partial class ZeroAdjustmentGUI
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
            this.zeroB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zeroB
            // 
            this.zeroB.BackColor = System.Drawing.Color.Gray;
            this.zeroB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zeroB.ForeColor = System.Drawing.Color.White;
            this.zeroB.Location = new System.Drawing.Point(284, 211);
            this.zeroB.Margin = new System.Windows.Forms.Padding(4);
            this.zeroB.Name = "zeroB";
            this.zeroB.Size = new System.Drawing.Size(233, 28);
            this.zeroB.TabIndex = 1;
            this.zeroB.Text = "Nulpunktsjustering udført";
            this.zeroB.UseVisualStyleBackColor = false;
            this.zeroB.Click += new System.EventHandler(this.zeroB_Click);
            // 
            // ZeroAdjustmentGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zeroB);
            this.Name = "ZeroAdjustmentGUI";
            this.Text = "ZeroAdjustmentGUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zeroB;
    }
}