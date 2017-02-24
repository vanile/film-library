using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP.CS.CS408.FilmLib
{
    public partial class AddWindow : Form
    {
        public Film film { get; set; }

        public AddWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
            Console.WriteLine(
            dateTimePicker1.Value.Date);
            //dateTimePicker1.Value = new DateTime(2012, 05, 28);
        }

        public AddWindow(string Name, Film film)
        {
            InitializeComponent();
            this.CenterToScreen();

            this.Text = Name;
            nameBox.Text = film.FilmName;
            ratingBox.Text = film.Rating.ToString();
            commentsBox.Text = film.Comments;
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Enter a name", "Error");
            }
            film.FilmName = nameBox.Text;
            int rating;
            Int32.TryParse(ratingBox.Text, out rating);
            film.Rating = rating;
            film.Comments = commentsBox.Text;
            if (rating > Film.MAX_RATING || rating < Film.MIN_RATING)
            {
                errorProvider1.SetError(ratingBox, "Enter a number 0 - 10");
            }
            else
            {
                errorProvider1.Dispose();
                addBtn.DialogResult = DialogResult.OK;
            }
            
        }

        private void ratingBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                errorProvider1.SetError(ratingBox, "Enter a number: 0 - 10");
            }
            else
            {
                errorProvider1.Dispose();
            }
        }
    }
}
