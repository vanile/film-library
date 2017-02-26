using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
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
    public partial class SearchOnlineWindow : Form
    {
        private SortableBindingList<Film> bs = new SortableBindingList<Film>();
        private bool searchCleared;
        private Form1 form;
        private const string tmdbUrlImage = "https://image.tmdb.org/t/p/original";

        public SearchOnlineWindow(Form1 nForm)
        {
            InitializeComponent();
            searchCleared = false;
            form = nForm;
            this.Text = "Search Film Online";

            setColumns();
            dgvOFilms.AutoGenerateColumns = false;
            dgvOFilms.AutoSize = false;
            dgvOFilms.DataSource = bs;

            this.Controls.Add(dgvOFilms);
            this.AutoSize = true;
            searchBox.GotFocus += searchBox_GotFocus;
        }

        public void setColumns()
        {
            DataGridViewColumn col0 = new DataGridViewTextBoxColumn();
            col0.DataPropertyName = "Name";
            col0.Name = "Film Name";
            col0.Width = 125;
            col0.ReadOnly = true;

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "Description";
            col1.Name = "Overview";
            col1.Width = 200;
            col1.ReadOnly = true;

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "ReleaseDate";
            col2.Name = "Release Date";
            col2.Width = 80;
            col2.ReadOnly = true;

            dgvOFilms.Columns.Add(col0);
            dgvOFilms.Columns.Add(col2);
            dgvOFilms.Columns.Add(col1);
            
        }

        private void searchBox_GotFocus(object sender, EventArgs e)
        {
            if (searchCleared == false)
            {
                searchBox.Clear();
                searchCleared = true;
            }
        }

        private async void searchByName()
        {
            var movieAPI = MovieDbFactory.Create<IApiMovieRequest>().Value;
            int pageNumber = 1;
            int totalPages;

            ApiSearchResponse<MovieInfo> response = await movieAPI.SearchByTitleAsync(searchBox.Text, pageNumber);

            //Console.WriteLine("Page {0} of {1} ({2} total results)", response.PageNumber, response.TotalPages, response.TotalResults);
            foreach (MovieInfo info in response.Results)
            {
                Film film = new Film();
                film.Name = info.Title;
                film.Description = info.Overview;
                film.tmdbID = info.Id;
                film.ReleaseDate = new DateTime(info.ReleaseDate.Year, info.ReleaseDate.Month, info.ReleaseDate.Day);
                Console.WriteLine(info.PosterPath);
                bs.Add(film);
                dgvOFilms.DataSource = bs;
                //Console.WriteLine("{0} ({1}): {2}", info.Title, info.ReleaseDate, info.Id);
            }

            totalPages = response.TotalPages;
        }

        private void checkSearchBoxEmpty()
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                dgvOFilms.DataSource = bs;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchByName();
        }

        private void dgvOFilms_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;

            new OMovieViewWindow(dog, form).Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
            new OMovieViewWindow(dog, form).Show();
        }

        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
                form.addFilm(dog);
            }
            catch (NullReferenceException) { }
    
        }

        private void openPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
            System.Diagnostics.Process.Start(OMovieViewWindow.TmdbUrlMovieTitle + dog.tmdbID);
        }
    }
}
