namespace CPP.CS.CS408.FilmLib
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
            this.components = new System.ComponentModel.Container();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.dgvFilms = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.dgvFilm = new System.Windows.Forms.DataGridView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.filmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.searchBox.Location = new System.Drawing.Point(561, 31);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(194, 22);
            this.searchBox.TabIndex = 0;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Search";
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(561, 60);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(194, 24);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // dgvFilms
            // 
            this.dgvFilms.AllowUserToAddRows = false;
            this.dgvFilms.AllowUserToDeleteRows = false;
            this.dgvFilms.AllowUserToResizeRows = false;
            this.dgvFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFilms.Location = new System.Drawing.Point(34, 31);
            this.dgvFilms.Name = "dgvFilms";
            this.dgvFilms.RowHeadersVisible = false;
            this.dgvFilms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFilms.RowTemplate.Height = 24;
            this.dgvFilms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFilms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilms.Size = new System.Drawing.Size(487, 317);
            this.dgvFilms.TabIndex = 2;
            this.dgvFilms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilms_CellContentClick);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(561, 228);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(91, 33);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(664, 228);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(91, 33);
            this.EditBtn.TabIndex = 4;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // dgvFilm
            // 
            this.dgvFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvFilm.Location = new System.Drawing.Point(207, 409);
            this.dgvFilm.Name = "dgvFilm";
            this.dgvFilm.RowTemplate.Height = 24;
            this.dgvFilm.Size = new System.Drawing.Size(240, 150);
            this.dgvFilm.TabIndex = 5;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(617, 276);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(91, 33);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // filmBindingSource
            // 
            this.filmBindingSource.DataSource = typeof(CPP.CS.CS408.FilmLib.Film);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Film Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Rating";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 611);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.dgvFilm);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.dgvFilms);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchBox);
            this.Name = "Form1";
            this.Text = "Film Library";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridView dgvFilms;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.BindingSource filmBindingSource;
        private System.Windows.Forms.DataGridView dgvFilm;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

