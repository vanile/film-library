namespace CPP.CS.CS408.FilmLib
{
    partial class OMovieViewWindow
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.overviewBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.viewOBtn = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.posterBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.posterBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(364, 438);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(102, 33);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // overviewBox
            // 
            this.overviewBox.BackColor = System.Drawing.SystemColors.Menu;
            this.overviewBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overviewBox.Location = new System.Drawing.Point(44, 209);
            this.overviewBox.Multiline = true;
            this.overviewBox.Name = "overviewBox";
            this.overviewBox.Size = new System.Drawing.Size(267, 133);
            this.overviewBox.TabIndex = 2;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(209, 438);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(102, 33);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add To List";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // viewOBtn
            // 
            this.viewOBtn.Location = new System.Drawing.Point(44, 438);
            this.viewOBtn.Name = "viewOBtn";
            this.viewOBtn.Size = new System.Drawing.Size(102, 33);
            this.viewOBtn.TabIndex = 4;
            this.viewOBtn.Text = "View Online";
            this.viewOBtn.UseVisualStyleBackColor = true;
            this.viewOBtn.Click += new System.EventHandler(this.viewOBtn_Click);
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.SystemColors.Menu;
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.Location = new System.Drawing.Point(44, 42);
            this.titleBox.Multiline = true;
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(267, 100);
            this.titleBox.TabIndex = 5;
            // 
            // posterBox
            // 
            this.posterBox.Location = new System.Drawing.Point(364, 30);
            this.posterBox.Name = "posterBox";
            this.posterBox.Size = new System.Drawing.Size(168, 203);
            this.posterBox.TabIndex = 6;
            this.posterBox.TabStop = false;
            // 
            // OMovieViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 516);
            this.Controls.Add(this.posterBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.viewOBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.overviewBox);
            this.Controls.Add(this.closeBtn);
            this.Name = "OMovieViewWindow";
            this.Text = "OMovieViewWindow";
            ((System.ComponentModel.ISupportInitialize)(this.posterBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.TextBox overviewBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button viewOBtn;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.PictureBox posterBox;
    }
}