namespace KinoAndme
{
    partial class ChooseFilm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.forward = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelPealkiri = new System.Windows.Forms.Label();
            this.labelZanr = new System.Windows.Forms.Label();
            this.labelAeg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(503, 55);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(207, 311);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 311);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(214, 301);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(48, 45);
            this.forward.TabIndex = 1;
            this.forward.Text = "->";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(137, 301);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(47, 45);
            this.back.TabIndex = 2;
            this.back.Text = "<-";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "osta pilet";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelPealkiri
            // 
            this.labelPealkiri.AutoSize = true;
            this.labelPealkiri.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPealkiri.Location = new System.Drawing.Point(60, 55);
            this.labelPealkiri.Name = "labelPealkiri";
            this.labelPealkiri.Size = new System.Drawing.Size(124, 42);
            this.labelPealkiri.TabIndex = 4;
            this.labelPealkiri.Text = "label1";
            // 
            // labelZanr
            // 
            this.labelZanr.AutoSize = true;
            this.labelZanr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZanr.Location = new System.Drawing.Point(62, 113);
            this.labelZanr.Name = "labelZanr";
            this.labelZanr.Size = new System.Drawing.Size(70, 25);
            this.labelZanr.TabIndex = 5;
            this.labelZanr.Text = "label1";
            // 
            // labelAeg
            // 
            this.labelAeg.AutoSize = true;
            this.labelAeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAeg.Location = new System.Drawing.Point(63, 155);
            this.labelAeg.Name = "labelAeg";
            this.labelAeg.Size = new System.Drawing.Size(51, 20);
            this.labelAeg.TabIndex = 6;
            this.labelAeg.Text = "label1";
            // 
            // ChooseFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAeg);
            this.Controls.Add(this.labelZanr);
            this.Controls.Add(this.labelPealkiri);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChooseFilm";
            this.Text = "ChooseFilm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelPealkiri;
        private System.Windows.Forms.Label labelZanr;
        private System.Windows.Forms.Label labelAeg;
    }
}