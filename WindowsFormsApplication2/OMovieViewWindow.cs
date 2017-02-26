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
    public partial class OMovieViewWindow : Form
    {
        private Film film;
        private Form1 form;
        public const string TmdbUrlMovieTitle = "https://www.themoviedb.org/movie/";
        public const string TmdbImgUrl = "https://image.tmdb.org/t/p/original";

        public OMovieViewWindow(Film nFilm, Form1 nForm)
        {
            InitializeComponent();
            film = nFilm;
            form = nForm;
            overviewBox.Text = film.Description;
            titleBox.Text = film.Name;
            //posterBox.Load(TmdbImgUrl + film.tmdbImgUrl);
            posterBox.Load("https://image.tmdb.org/t/p/original/vyFj7ZFm5AWApNGowpUzoakMuyS.jpg");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            form.addFilm(film);
        }

        private void viewOBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(TmdbUrlMovieTitle + film.tmdbID);
        }
    }
}
