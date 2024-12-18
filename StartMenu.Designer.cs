namespace KinoAndme
{
    partial class StartMenu
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
            this.adminA = new System.Windows.Forms.Button();
            this.kasutajaR = new System.Windows.Forms.Button();
            this.kasutajaA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminA
            // 
            this.adminA.Location = new System.Drawing.Point(147, 193);
            this.adminA.Name = "adminA";
            this.adminA.Size = new System.Drawing.Size(107, 58);
            this.adminA.TabIndex = 0;
            this.adminA.Text = "admin autoriseerimine";
            this.adminA.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.adminA.UseVisualStyleBackColor = true;
            this.adminA.Click += new System.EventHandler(this.adminA_Click);
            // 
            // kasutajaR
            // 
            this.kasutajaR.Location = new System.Drawing.Point(344, 193);
            this.kasutajaR.Name = "kasutajaR";
            this.kasutajaR.Size = new System.Drawing.Size(107, 58);
            this.kasutajaR.TabIndex = 1;
            this.kasutajaR.Text = "kasutaja registreerimine";
            this.kasutajaR.UseVisualStyleBackColor = true;
            this.kasutajaR.Click += new System.EventHandler(this.kasutajaR_Click);
            // 
            // kasutajaA
            // 
            this.kasutajaA.Location = new System.Drawing.Point(540, 193);
            this.kasutajaA.Name = "kasutajaA";
            this.kasutajaA.Size = new System.Drawing.Size(107, 58);
            this.kasutajaA.TabIndex = 2;
            this.kasutajaA.Text = "kasutaja autoriseerimine";
            this.kasutajaA.UseVisualStyleBackColor = true;
            this.kasutajaA.Click += new System.EventHandler(this.kasutajaA_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kasutajaA);
            this.Controls.Add(this.kasutajaR);
            this.Controls.Add(this.adminA);
            this.Name = "StartMenu";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminA;
        private System.Windows.Forms.Button kasutajaR;
        private System.Windows.Forms.Button kasutajaA;
    }
}