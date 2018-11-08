namespace Presentation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zeroB
            // 
            this.zeroB.BackColor = System.Drawing.Color.Gray;
            this.zeroB.ForeColor = System.Drawing.Color.White;
            this.zeroB.Location = new System.Drawing.Point(158, 375);
            this.zeroB.Name = "zeroB";
            this.zeroB.Size = new System.Drawing.Size(175, 23);
            this.zeroB.TabIndex = 0;
            this.zeroB.Text = "Nulpunktsjustering udført";
            this.zeroB.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(108, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(129, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nulpunktsjustering";
            // 
            // ZeroAdjustmentGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zeroB);
            this.Name = "ZeroAdjustmentGUI";
            this.Text = "ZeroAdjustmentGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button zeroB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}