namespace Presentation
{
    partial class ChangeLimitsGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UpperTB = new System.Windows.Forms.TextBox();
            this.lowerTB = new System.Windows.Forms.TextBox();
            this.childB = new System.Windows.Forms.Button();
            this.adultB = new System.Windows.Forms.Button();
            this.oldB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Øvre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(61, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nedre";
            // 
            // UpperTB
            // 
            this.UpperTB.Location = new System.Drawing.Point(61, 138);
            this.UpperTB.Name = "UpperTB";
            this.UpperTB.Size = new System.Drawing.Size(100, 20);
            this.UpperTB.TabIndex = 2;
            // 
            // lowerTB
            // 
            this.lowerTB.Location = new System.Drawing.Point(61, 183);
            this.lowerTB.Name = "lowerTB";
            this.lowerTB.Size = new System.Drawing.Size(100, 20);
            this.lowerTB.TabIndex = 3;
            // 
            // childB
            // 
            this.childB.BackColor = System.Drawing.Color.Silver;
            this.childB.ForeColor = System.Drawing.Color.White;
            this.childB.Location = new System.Drawing.Point(278, 109);
            this.childB.Name = "childB";
            this.childB.Size = new System.Drawing.Size(121, 23);
            this.childB.TabIndex = 4;
            this.childB.Text = "Barn";
            this.childB.UseVisualStyleBackColor = false;
            // 
            // adultB
            // 
            this.adultB.BackColor = System.Drawing.Color.Silver;
            this.adultB.ForeColor = System.Drawing.Color.White;
            this.adultB.Location = new System.Drawing.Point(278, 138);
            this.adultB.Name = "adultB";
            this.adultB.Size = new System.Drawing.Size(121, 23);
            this.adultB.TabIndex = 5;
            this.adultB.Text = "Voksen";
            this.adultB.UseVisualStyleBackColor = false;
            // 
            // oldB
            // 
            this.oldB.BackColor = System.Drawing.Color.Silver;
            this.oldB.ForeColor = System.Drawing.Color.White;
            this.oldB.Location = new System.Drawing.Point(278, 166);
            this.oldB.Name = "oldB";
            this.oldB.Size = new System.Drawing.Size(121, 23);
            this.oldB.TabIndex = 6;
            this.oldB.Text = "Ældre";
            this.oldB.UseVisualStyleBackColor = false;
            // 
            // ChangeLimitsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oldB);
            this.Controls.Add(this.adultB);
            this.Controls.Add(this.childB);
            this.Controls.Add(this.lowerTB);
            this.Controls.Add(this.UpperTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangeLimitsGUI";
            this.Text = "ChangeLimitsGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UpperTB;
        private System.Windows.Forms.TextBox lowerTB;
        private System.Windows.Forms.Button childB;
        private System.Windows.Forms.Button adultB;
        private System.Windows.Forms.Button oldB;
    }
}