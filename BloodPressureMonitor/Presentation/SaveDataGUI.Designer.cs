namespace Presentation
{
    partial class SaveDataGUI
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
            this.SaveB = new System.Windows.Forms.Button();
            this.medarbejderIDTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cprTB2 = new System.Windows.Forms.TextBox();
            this.cprTB1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.navnTB = new System.Windows.Forms.TextBox();
            this.procedureTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveB
            // 
            this.SaveB.BackColor = System.Drawing.Color.Gray;
            this.SaveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveB.ForeColor = System.Drawing.Color.White;
            this.SaveB.Location = new System.Drawing.Point(254, 336);
            this.SaveB.Margin = new System.Windows.Forms.Padding(0);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(136, 30);
            this.SaveB.TabIndex = 64;
            this.SaveB.Text = "Gem";
            this.SaveB.UseVisualStyleBackColor = false;
            // 
            // medarbejderIDTB
            // 
            this.medarbejderIDTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medarbejderIDTB.Location = new System.Drawing.Point(159, 89);
            this.medarbejderIDTB.Margin = new System.Windows.Forms.Padding(2);
            this.medarbejderIDTB.Name = "medarbejderIDTB";
            this.medarbejderIDTB.Size = new System.Drawing.Size(195, 34);
            this.medarbejderIDTB.TabIndex = 63;
            this.medarbejderIDTB.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.LightGray;
            this.label13.Location = new System.Drawing.Point(16, 92);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 35);
            this.label13.TabIndex = 62;
            this.label13.Text = "MedarbejderID";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(260, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 29);
            this.label6.TabIndex = 61;
            this.label6.Text = "-";
            // 
            // cprTB2
            // 
            this.cprTB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cprTB2.Location = new System.Drawing.Point(275, 175);
            this.cprTB2.Margin = new System.Windows.Forms.Padding(2);
            this.cprTB2.MaxLength = 4;
            this.cprTB2.Name = "cprTB2";
            this.cprTB2.Size = new System.Drawing.Size(79, 34);
            this.cprTB2.TabIndex = 60;
            // 
            // cprTB1
            // 
            this.cprTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cprTB1.Location = new System.Drawing.Point(159, 175);
            this.cprTB1.Margin = new System.Windows.Forms.Padding(2);
            this.cprTB1.Name = "cprTB1";
            this.cprTB1.Size = new System.Drawing.Size(98, 34);
            this.cprTB1.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(16, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 29);
            this.label5.TabIndex = 58;
            this.label5.Text = "Patients CPR";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(16, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 48);
            this.label4.TabIndex = 57;
            this.label4.Text = "Indtast venligst følgende oplysninger for at gemme i database ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 268);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 30);
            this.dateTimePicker1.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(16, 273);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 35);
            this.label1.TabIndex = 55;
            this.label1.Text = "Dato";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(16, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 29);
            this.label2.TabIndex = 65;
            this.label2.Text = "Patients navn";
            // 
            // navnTB
            // 
            this.navnTB.BackColor = System.Drawing.Color.Silver;
            this.navnTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navnTB.Location = new System.Drawing.Point(159, 218);
            this.navnTB.Margin = new System.Windows.Forms.Padding(2);
            this.navnTB.Multiline = true;
            this.navnTB.Name = "navnTB";
            this.navnTB.Size = new System.Drawing.Size(195, 29);
            this.navnTB.TabIndex = 66;
            // 
            // procedureTB
            // 
            this.procedureTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procedureTB.Location = new System.Drawing.Point(159, 129);
            this.procedureTB.Margin = new System.Windows.Forms.Padding(2);
            this.procedureTB.Name = "procedureTB";
            this.procedureTB.Size = new System.Drawing.Size(195, 34);
            this.procedureTB.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 35);
            this.label3.TabIndex = 68;
            this.label3.Text = "Procedure";
            // 
            // SaveDataGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(419, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.procedureTB);
            this.Controls.Add(this.navnTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveB);
            this.Controls.Add(this.medarbejderIDTB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cprTB2);
            this.Controls.Add(this.cprTB1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SaveDataGUI";
            this.Text = "SaveDataGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.TextBox medarbejderIDTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cprTB2;
        private System.Windows.Forms.TextBox cprTB1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox navnTB;
        private System.Windows.Forms.TextBox procedureTB;
        private System.Windows.Forms.Label label3;
    }
}