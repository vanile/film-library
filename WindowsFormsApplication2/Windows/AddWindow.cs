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
        private const string TmdbUrlMovieTitle = "https://www.themoviedb.org/movie/";

        public AddWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Constructor for editing a film's information.
        /// Will input information from film being edited
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="nfilm"></param>
        public AddWindow(string Name, Film nfilm)
        {
            InitializeComponent();
            
            this.CenterToScreen();
            this.Text = Name;
            film = nfilm;
            filmHasTmdbId();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            nameBox.Text = film.Name;
            ratingBox.Text = film.Rating.ToString();
            commentsBox.Text = film.Comments;
            descriptionBox.Text = film.Description;

            int year = film.DateWatched.Year;
            int month = film.DateWatched.Month;
            int day = film.DateWatched.Day;
            if (year == 1 && month == 1 && day == 1)
            {
                dateTimePicker1.Value = new DateTime(DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day);
            }
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
            } catch (NullReferenceException) { }
        }

        /// <summary>
        /// Checks if t he Film object has a tmdbID, if it does
        /// then a button will be enabled. That button 
        /// allows the user to click and go to the tmdb page
        /// of the film.
        /// </summary>
        private void filmHasTmdbId()
        {
            try
            {
                if (film.tmdbID != 0)
                {
                    viewOBtn.Visible = true;
                }
            }
            catch (NullReferenceException) { }
        }

        /// <summary>
        /// Saves user modifications to a film with a DialogResult to
        /// for previous call. Usually from Film Library window
        /// editContextMenu or button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Enter a name", "Error");
            }

            int rating;
            Int32.TryParse(ratingBox.Text, out rating);
            film.Name = nameBox.Text;
            film.Rating = rating;
            film.Comments = commentsBox.Text;
            film.DateWatched = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            film.Description = descriptionBox.Text;

            try
            {
                film.FilmStatus = comboBox1.SelectedItem.ToString();
            }
            catch (NullReferenceException) { }

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

        /// <summary>
        /// Only allows integers to be inputed into the Rating Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Opens a TMDB webpage of the movie selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewOBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(TmdbUrlMovieTitle + film.tmdbID);
        }

        /// <summary>
        /// Disables date picker if the movie is not set to Finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 1)
            {
                dateTimePicker1.Enabled = false;
                ratingBox.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                ratingBox.Enabled = true;
            }
        }
    }
}
