namespace CPP.CS.CS408.FilmLib
{
    partial class SearchOnlineWindow
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
            this.dgvOFilms = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numResultsLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOFilms)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(25, 26);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(506, 22);
            this.searchBox.TabIndex = 0;
            this.searchBox.Text = "Search";
            // 
            // dgvOFilms
            // 
            this.dgvOFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOFilms.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOFilms.Location = new System.Drawing.Point(25, 71);
            this.dgvOFilms.Name = "dgvOFilms";
            this.dgvOFilms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOFilms.RowTemplate.Height = 24;
            this.dgvOFilms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOFilms.Size = new System.Drawing.Size(597, 359);
            this.dgvOFilms.TabIndex = 1;
            this.dgvOFilms.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOFilms_CellContentDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.addToListToolStripMenuItem,
            this.openPageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 82);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // addToListToolStripMenuItem
            // 
            this.addToListToolStripMenuItem.Name = "addToListToolStripMenuItem";
            this.addToListToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.addToListToolStripMenuItem.Text = "Add To List";
            this.addToListToolStripMenuItem.Click += new System.EventHandler(this.addToListToolStripMenuItem_Click);
            // 
            // openPageToolStripMenuItem
            // 
            this.openPageToolStripMenuItem.Name = "openPageToolStripMenuItem";
            this.openPageToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.openPageToolStripMenuItem.Text = "Open Page";
            this.openPageToolStripMenuItem.Click += new System.EventHandler(this.openPageToolStripMenuItem_Click);
            // 
            // numResultsLbl
            // 
            this.numResultsLbl.AutoSize = true;
            this.numResultsLbl.Location = new System.Drawing.Point(27, 439);
            this.numResultsLbl.Name = "numResultsLbl";
            this.numResultsLbl.Size = new System.Drawing.Size(0, 17);
            this.numResultsLbl.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchOnlineWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numResultsLbl);
            this.Controls.Add(this.dgvOFilms);
            this.Controls.Add(this.searchBox);
            this.Name = "SearchOnlineWindow";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOFilms)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView dgvOFilms;
        private System.Windows.Forms.Label numResultsLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPageToolStripMenuItem;
    }
}