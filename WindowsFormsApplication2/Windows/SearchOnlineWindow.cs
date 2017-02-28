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

        private FilmLibraryWindow form;

        private bool searchCleared;
        
        /// <summary>
        /// Constructor. nForm is the Film Library window. Necessary
        /// to call a function to add a Film selected in this window
        /// to the user's library.
        /// </summary>
        /// <param name="nForm"></param>
        public SearchOnlineWindow(FilmLibraryWindow nForm)
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

        /// <summary>
        /// Sets columns in the DataGridView with necessary names
        /// and properties
        /// </summary>
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

        /// <summary>
        /// When user first opens window, if user clicks on the search box,
        /// search box will empty. Only one time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_GotFocus(object sender, EventArgs e)
        {
            if (searchCleared == false)
            {
                searchBox.Clear();
                searchCleared = true;
            }
        }

        /// <summary>
        /// Does an online search of film name entered into the Search Box
        /// Fills the data grid view with all films in Film object format
        /// </summary>
        private async void searchByName()
        {
            var movieAPI = MovieDbFactory.Create<IApiMovieRequest>().Value;
            int pageNumber = 1;
            int totalPages;
            int numResults = 0;

            ApiSearchResponse<MovieInfo> response = await movieAPI.SearchByTitleAsync(searchBox.Text, pageNumber);

            bs.Clear();
            foreach (MovieInfo info in response.Results)
            {
                Film film = new Film();

                film.Name = info.Title;
                film.Description = info.Overview;
                film.tmdbID = info.Id;
                film.tmdbImgUrl = info.PosterPath;
                film.ReleaseDate = new DateTime(info.ReleaseDate.Year, info.ReleaseDate.Month, info.ReleaseDate.Day);

                bs.Add(film);
                dgvOFilms.DataSource = bs;
                numResults++;
                numResultsLbl.Text = "Page: " + pageNumber.ToString();
            }

            totalPages = response.TotalPages;
            if (numResults == 0) { MessageBox.Show("No results found"); }
        }

        private void checkSearchBoxEmpty()
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                dgvOFilms.DataSource = bs;
            }
        }

        /// <summary>
        /// button1 = Search Button
        /// Will procede to search online tmdb for user's input film name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            searchByName();
        }

        /// <summary>
        /// When user double clicks on a row of Film, a OMovieViewWindow
        /// will open with Film's information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOFilms_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
            new OMovieViewWindow(dog, form).Show();
        }

        /// <summary>
        /// Right click -> View.
        /// Opens a OMovieViewWindow with Film's information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
            new OMovieViewWindow(dog, form).Show();
        }

        /// <summary>
        /// Right Click -> Add
        /// Adds selected Film to the user's film library.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
                form.addFilm(dog);
            }
            catch (NullReferenceException) { }
    
        }

        /// <summary>
        /// Right click -> Open Page
        /// Opens a TMDB webpage of the film selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvOFilms.CurrentRow.DataBoundItem;
            System.Diagnostics.Process.Start(OMovieViewWindow.TmdbUrlMovieTitle + dog.tmdbID);
        }
    }
}
