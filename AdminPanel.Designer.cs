namespace KinoAndme
{
    partial class AdminPanel
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
            this.dataGridViewMovies = new System.Windows.Forms.DataGridView();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.filID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pealkiri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zanr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMovies
            // 
            this.dataGridViewMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filID,
            this.pealkiri,
            this.zanr,
            this.aeg});
            this.dataGridViewMovies.Location = new System.Drawing.Point(78, 196);
            this.dataGridViewMovies.Name = "dataGridViewMovies";
            this.dataGridViewMovies.Size = new System.Drawing.Size(389, 193);
            this.dataGridViewMovies.TabIndex = 0;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(91, 46);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(136, 20);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "title";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(564, 210);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(91, 32);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "lisa";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(564, 269);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(91, 32);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "kustuta";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // filID
            // 
            this.filID.HeaderText = "filID";
            this.filID.Name = "filID";
            // 
            // pealkiri
            // 
            this.pealkiri.HeaderText = "pealkiri";
            this.pealkiri.Name = "pealkiri";
            // 
            // zanr
            // 
            this.zanr.HeaderText = "zanr";
            this.zanr.Name = "zanr";
            // 
            // aeg
            // 
            this.aeg.HeaderText = "aeg";
            this.aeg.Name = "aeg";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(89, 134);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(138, 20);
            this.textBoxTime.TabIndex = 6;
            this.textBoxTime.Text = "time";
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Location = new System.Drawing.Point(91, 88);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(136, 20);
            this.textBoxGenre.TabIndex = 7;
            this.textBoxGenre.Text = "genre";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.dataGridViewMovies);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMovies;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn filID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pealkiri;
        private System.Windows.Forms.DataGridViewTextBoxColumn zanr;
        private System.Windows.Forms.DataGridViewTextBoxColumn aeg;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxGenre;
    }
}