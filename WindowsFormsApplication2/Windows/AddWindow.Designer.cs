namespace CPP.CS.CS408.FilmLib
{
    partial class AddWindow
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
            this.addBtn = new System.Windows.Forms.Button();
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.ratingLbl = new System.Windows.Forms.Label();
            this.ratingBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.finishLbl = new System.Windows.Forms.Label();
            this.commentsLbl = new System.Windows.Forms.Label();
            this.commentsBox = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.viewOBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(281, 529);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(97, 33);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "OK";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 45);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(74, 17);
            this.nameLbl.TabIndex = 1;
            this.nameLbl.Text = "Film Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(101, 40);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(139, 22);
            this.nameBox.TabIndex = 2;
            // 
            // ratingLbl
            // 
            this.ratingLbl.AutoSize = true;
            this.ratingLbl.Location = new System.Drawing.Point(12, 92);
            this.ratingLbl.Name = "ratingLbl";
            this.ratingLbl.Size = new System.Drawing.Size(49, 17);
            this.ratingLbl.TabIndex = 3;
            this.ratingLbl.Text = "Rating";
            // 
            // ratingBox
            // 
            this.ratingBox.Location = new System.Drawing.Point(101, 89);
            this.ratingBox.Name = "ratingBox";
            this.ratingBox.Size = new System.Drawing.Size(139, 22);
            this.ratingBox.TabIndex = 4;
            this.ratingBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ratingBox_KeyPress_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 195);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // finishLbl
            // 
            this.finishLbl.AutoSize = true;
            this.finishLbl.Location = new System.Drawing.Point(12, 195);
            this.finishLbl.Name = "finishLbl";
            this.finishLbl.Size = new System.Drawing.Size(79, 17);
            this.finishLbl.TabIndex = 6;
            this.finishLbl.Text = "Finish Date";
            // 
            // commentsLbl
            // 
            this.commentsLbl.AutoSize = true;
            this.commentsLbl.Location = new System.Drawing.Point(12, 376);
            this.commentsLbl.Name = "commentsLbl";
            this.commentsLbl.Size = new System.Drawing.Size(74, 17);
            this.commentsLbl.TabIndex = 7;
            this.commentsLbl.Text = "Comments";
            // 
            // commentsBox
            // 
            this.commentsBox.Location = new System.Drawing.Point(101, 376);
            this.commentsBox.Multiline = true;
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentsBox.Size = new System.Drawing.Size(265, 64);
            this.commentsBox.TabIndex = 8;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 135);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(48, 17);
            this.statusLbl.TabIndex = 9;
            this.statusLbl.Text = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "In Queue",
            "Finished"});
            this.comboBox1.Location = new System.Drawing.Point(101, 135);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionBox.Location = new System.Drawing.Point(101, 244);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(265, 110);
            this.descriptionBox.TabIndex = 11;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Location = new System.Drawing.Point(13, 244);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(79, 17);
            this.descriptionLbl.TabIndex = 12;
            this.descriptionLbl.Text = "Description";
            // 
            // viewOBtn
            // 
            this.viewOBtn.Location = new System.Drawing.Point(163, 529);
            this.viewOBtn.Name = "viewOBtn";
            this.viewOBtn.Size = new System.Drawing.Size(97, 33);
            this.viewOBtn.TabIndex = 13;
            this.viewOBtn.Text = "View Online";
            this.viewOBtn.UseVisualStyleBackColor = true;
            this.viewOBtn.Visible = false;
            this.viewOBtn.Click += new System.EventHandler(this.viewOBtn_Click);
            // 
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 583);
            this.Controls.Add(this.viewOBtn);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.commentsBox);
            this.Controls.Add(this.commentsLbl);
            this.Controls.Add(this.finishLbl);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ratingBox);
            this.Controls.Add(this.ratingLbl);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.addBtn);
            this.MaximizeBox = false;
            this.Name = "AddWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Film";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label ratingLbl;
        private System.Windows.Forms.TextBox ratingBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label finishLbl;
        private System.Windows.Forms.TextBox commentsBox;
        private System.Windows.Forms.Label commentsLbl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button viewOBtn;
    }
}