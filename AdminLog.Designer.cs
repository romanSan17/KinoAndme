namespace KinoAndme
{
    partial class AdminLog
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
            this.loginA = new System.Windows.Forms.TextBox();
            this.paroolA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.adminAutoris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginA
            // 
            this.loginA.Location = new System.Drawing.Point(173, 137);
            this.loginA.Name = "loginA";
            this.loginA.Size = new System.Drawing.Size(100, 20);
            this.loginA.TabIndex = 0;
            // 
            // paroolA
            // 
            this.paroolA.Location = new System.Drawing.Point(173, 185);
            this.paroolA.Name = "paroolA";
            this.paroolA.Size = new System.Drawing.Size(100, 20);
            this.paroolA.TabIndex = 1;
            this.paroolA.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(54, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(54, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "parool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(262, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Admin autoriseerimine";
            // 
            // adminAutoris
            // 
            this.adminAutoris.Location = new System.Drawing.Point(58, 283);
            this.adminAutoris.Name = "adminAutoris";
            this.adminAutoris.Size = new System.Drawing.Size(148, 41);
            this.adminAutoris.TabIndex = 5;
            this.adminAutoris.Text = "autoriseerimine";
            this.adminAutoris.UseVisualStyleBackColor = true;
            this.adminAutoris.Click += new System.EventHandler(this.adminAutoris_Click);
            // 
            // AdminLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.adminAutoris);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paroolA);
            this.Controls.Add(this.loginA);
            this.Name = "AdminLog";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginA;
        private System.Windows.Forms.TextBox paroolA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button adminAutoris;
    }
}

