namespace ID_Card_segmentation
{
    partial class Form1
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
            this.pictureBoxOri = new System.Windows.Forms.PictureBox();
            this.pictureBoxMorp = new System.Windows.Forms.PictureBox();
            this.pictureBoxFin1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxFin2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMorp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFin2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOri
            // 
            this.pictureBoxOri.Location = new System.Drawing.Point(193, 12);
            this.pictureBoxOri.Name = "pictureBoxOri";
            this.pictureBoxOri.Size = new System.Drawing.Size(571, 363);
            this.pictureBoxOri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOri.TabIndex = 0;
            this.pictureBoxOri.TabStop = false;
            // 
            // pictureBoxMorp
            // 
            this.pictureBoxMorp.Location = new System.Drawing.Point(803, 12);
            this.pictureBoxMorp.Name = "pictureBoxMorp";
            this.pictureBoxMorp.Size = new System.Drawing.Size(530, 363);
            this.pictureBoxMorp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMorp.TabIndex = 1;
            this.pictureBoxMorp.TabStop = false;
            // 
            // pictureBoxFin1
            // 
            this.pictureBoxFin1.Location = new System.Drawing.Point(283, 440);
            this.pictureBoxFin1.Name = "pictureBoxFin1";
            this.pictureBoxFin1.Size = new System.Drawing.Size(416, 416);
            this.pictureBoxFin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFin1.TabIndex = 2;
            this.pictureBoxFin1.TabStop = false;
            // 
            // pictureBoxFin2
            // 
            this.pictureBoxFin2.Location = new System.Drawing.Point(869, 440);
            this.pictureBoxFin2.Name = "pictureBoxFin2";
            this.pictureBoxFin2.Size = new System.Drawing.Size(416, 416);
            this.pictureBoxFin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFin2.TabIndex = 3;
            this.pictureBoxFin2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 875);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Left Finger";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1045, 875);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Right Finger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Original Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1045, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Segmentation Image";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(45, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 906);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxFin2);
            this.Controls.Add(this.pictureBoxFin1);
            this.Controls.Add(this.pictureBoxMorp);
            this.Controls.Add(this.pictureBoxOri);
            this.Name = "Form1";
            this.Text = "ID Card Segmentation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMorp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFin2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOri;
        private System.Windows.Forms.PictureBox pictureBoxMorp;
        private System.Windows.Forms.PictureBox pictureBoxFin1;
        private System.Windows.Forms.PictureBox pictureBoxFin2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}

