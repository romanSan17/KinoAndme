﻿namespace KinoAndme
{
    partial class KasutajaReg
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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paroolR = new System.Windows.Forms.TextBox();
            this.loginR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nimiR = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "registreerimine";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(235, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Kasutaja registreerimine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(37, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "parool";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(37, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "login";
            // 
            // paroolR
            // 
            this.paroolR.Location = new System.Drawing.Point(208, 240);
            this.paroolR.Name = "paroolR";
            this.paroolR.Size = new System.Drawing.Size(100, 20);
            this.paroolR.TabIndex = 13;
            // 
            // loginR
            // 
            this.loginR.Location = new System.Drawing.Point(208, 192);
            this.loginR.Name = "loginR";
            this.loginR.Size = new System.Drawing.Size(100, 20);
            this.loginR.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(37, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "nimi";
            // 
            // nimiR
            // 
            this.nimiR.Location = new System.Drawing.Point(208, 142);
            this.nimiR.Name = "nimiR";
            this.nimiR.Size = new System.Drawing.Size(100, 20);
            this.nimiR.TabIndex = 18;
            // 
            // KasutajaReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nimiR);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paroolR);
            this.Controls.Add(this.loginR);
            this.Name = "KasutajaReg";
            this.Text = "KasutajaReg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paroolR;
        private System.Windows.Forms.TextBox loginR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nimiR;
    }
}