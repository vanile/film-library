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
    /// <summary>
    /// This window is opened when a user right clicks -> View
    /// on a searched film through Search Online Window.
    /// Displays information such as movie's picture, title,
    /// release date, and description.
    /// </summary>
    public partial class OMovieViewWindow : Form
    {
        private Film film;

        private FilmLibraryWindow form;
        
        public OMovieViewWindow(Film nFilm, FilmLibraryWindow nForm)
        {
            InitializeComponent();
            film = nFilm;
            this.Text = film.Name + " (" + film.ReleaseDate.Year +")";
            form = nForm;

            overviewBox.Text = film.Description;
            titleBox.Text = film.Name;
            releaseBox.Text = film.ReleaseDate.ToShortDateString();
            posterBox.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                posterBox.Load(Film.TmdbImgUrl + film.tmdbImgUrl);
            }
            catch (System.Net.WebException) { }
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            form.addFilm(film);
            this.Close();
        }

        private void viewOBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Film.TmdbUrlMovieTitle + film.tmdbID);
            this.Close();
        }

    }
}
