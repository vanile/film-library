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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            comboBox1.SelectedIndex = 0;
        }

        public AddWindow(string Name, Film film)
        {
            InitializeComponent();
            this.CenterToScreen();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.Text = Name;
            nameBox.Text = film.FilmName;
            ratingBox.Text = film.Rating.ToString();
            commentsBox.Text = film.Comments;
            try
            {
                if (film.FilmStatus.Equals(Film.StatusFinished))
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
            } catch (NullReferenceException e) { }

            int year = film.DateWatched.Year;
            int month = film.DateWatched.Month;
            int day = film.DateWatched.Day;
            if (year == 1 && month == 1 && day == 1)
            {
                dateTimePicker1.Value = new DateTime(DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day);
            }
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
            film.DateWatched = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            try
            {
                film.FilmStatus = comboBox1.SelectedItem.ToString();
            }
            catch (NullReferenceException ex) { }
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
