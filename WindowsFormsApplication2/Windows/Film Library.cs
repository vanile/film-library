using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;

using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.ApiResponse;

namespace CPP.CS.CS408.FilmLib
{
    public partial class FilmLibraryWindow : Form
    {
        private SortableBindingList<Film> bs = new SortableBindingList<Film>();

        private string currentFile;

        private bool searchCleared;

        
        public FilmLibraryWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
            searchCleared = false;
            comboBox1.SelectedIndex = 0;

            setColumns();
            load();
            dgvFilms.AutoGenerateColumns = false;
            dgvFilms.AutoSize = false;
            dgvFilms.DataSource = bs;

            this.Controls.Add(dgvFilms);
            this.AutoSize = true;

            MovieDbFactory.RegisterSettings(MovieDbSettings.ApiKey, MovieDbSettings.ApiUrl);
            searchBox.GotFocus += searchBox_GotFocus;
        }

        /// <summary>
        /// Used by other classes to add a Film
        /// to the list.
        /// </summary>
        /// <param name="film"></param>
        public void addFilm(Film film)
        {
            bs.Add(film);
            dgvFilms.DataSource = bs;
            save();
        }

        /// <summary>
        /// Sets necessary columns in DataGridView with needed
        /// properties
        /// </summary>
        private void setColumns()
        {
            DataGridViewColumn col0 = new DataGridViewImageColumn();
            col0.DataPropertyName = "Favorite Film";
            col0.Name = "";
            col0.Width = 20;
            col0.ReadOnly = true;

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "Name";
            col1.Name = "Film Name";
            col1.Width = 125;
            col1.ReadOnly = true;

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Rating";
            col2.Name = "Rating/10";
            col2.Width = 65;
            col2.ReadOnly = true;

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "Comments";
            col3.Name = "Comments";
            col3.Width = 100;
            col3.ReadOnly = true;

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.DataPropertyName = "DateWatched";
            col4.Name = "Date Watched";
            col4.Width = 70;
            col4.ReadOnly = true;

            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.DataPropertyName = "FilmStatus";
            col5.Name = "Status";
            col5.Width = 80;
            col5.ReadOnly = true;

            //dgvFilms.Columns.Add(col0);
            dgvFilms.Columns.Add(col1);
            dgvFilms.Columns.Add(col2);
            dgvFilms.Columns.Add(col5);
            dgvFilms.Columns.Add(col4);
            dgvFilms.Columns.Add(col3);
        }

        /// <summary>
        /// When user clicks on search box, default "Search" text
        /// will be removed only the first time user does this action.
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Film cFilm = (Film)dgvFilms.CurrentRow.DataBoundItem;

            using (AddWindow form = new AddWindow("Edit Film", cFilm) { film = cFilm })
            {
                if (form.ShowDialog() == DialogResult.OK) { bs[bs.IndexOf(cFilm)] = form.film; }
            }
            save();
        }

        /// <summary>
        /// When user double click's on a row, open an AddWindow 
        /// for editing purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilms_DoubleClick(object sender, EventArgs e)
        {
            Film cFilm = (Film)dgvFilms.CurrentRow.DataBoundItem;

            using (AddWindow form = new AddWindow("Edit Film", cFilm) { film = cFilm })
            {
                if (form.ShowDialog() == DialogResult.OK) { bs[bs.IndexOf(cFilm)] = form.film; }
            }
            save();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            foreach (Film sFilm in bs)
            {
                if (sFilm.Name.Contains(searchBox.Text)) { searchFilm.Add(sFilm); }
            }
            dgvFilms.DataSource = searchFilm;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            using(AddWindow form = new AddWindow() {film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK) { bs.Add(form.film); }
            }
            save();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
            save();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddWindow form = new AddWindow() { film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK) { bs.Add(form.film); }
            }
            save();
        }

        /// <summary>
        /// Right click -> Edit
        /// Opens AddWindow for editing selected film's information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Film cFilm = (Film)dgvFilms.CurrentRow.DataBoundItem;

            using (AddWindow form = new AddWindow("Edit Film", cFilm) { film = cFilm})
            {
                if (form.ShowDialog() == DialogResult.OK) { bs[bs.IndexOf(cFilm)] = form.film; }
            }
            save();
        }

        /// <summary>
        /// Right click -> Delete
        /// Deletes Film row and object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
            save();
        }

        /// <summary>
        /// Saves state of SortableBindingList<Film> into default
        /// XML file.
        /// </summary>
        private void save()
        {
            if (currentFile != null)
            {
                DataIO.SaveToFile(bs, currentFile);
            }
            else
            {
                DataIO.SaveToFile(bs, "filmLibraryData.xml");
            }  
        }

        /// <summary>
        /// Load from default file.
        /// </summary>
        private void load()
        {
            SortableBindingList<Film> loaded = new SortableBindingList<Film>();
            loaded = DataIO.LoadFromFile("filmLibraryData.xml");

            if (loaded != null)
            {
                bs = loaded;
            }
            else { }
        }

        private void export(string fileName)
        {
            fileName = fileName + ".txt";
            DataIO.SaveToText(bs, fileName);
        }

        /// <summary>
        /// Export list into a more readable .txt file. 
        /// Location is selected by user with a Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Export XML File";
            saveDialog.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                DataIO.SaveToFile(bs, saveDialog.FileName);
            }
        }

        /// <summary>
        /// Searches through user's library for films with film names
        /// that contain the strings entered into search box
        /// </summary>
        private void searchByName()
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            foreach (Film sFilm in bs)
            {
                string nameTemp = sFilm.Name.ToUpper();
                string search = searchBox.Text.ToUpper();
                if (nameTemp.Contains(search))
                {
                    searchFilm.Add(sFilm);
                }
            }
            dgvFilms.DataSource = searchFilm;
            checkSearchBoxEmpty();
        }

        /// <summary>
        /// Searches through the user's library for films with the same
        /// rating as entered by user. Range enabled. Use >7 <7 for example
        /// </summary>
        private void searchByRating()
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            char[] searchText = searchBox.Text.ToCharArray();
            int temp;
            try
            {
                if (searchText[0] == '>')
                {
                    foreach (Film sFilm in bs)
                    {
                        Int32.TryParse(searchText[1].ToString(), out temp);
                        if (sFilm.Rating > temp) { searchFilm.Add(sFilm); }
                    }
                }
                else if (searchText[0] == '<')
                {
                    foreach (Film sFilm in bs)
                    {
                        Int32.TryParse(searchText[1].ToString(), out temp);
                        if (sFilm.Rating < temp) { searchFilm.Add(sFilm); }
                    }
                }
                else
                {
                    foreach (Film sFilm in bs)
                    {
                        Int32.TryParse(searchBox.Text, out temp);
                        if (sFilm.Rating.Equals(temp)) { searchFilm.Add(sFilm); }
                    }
                }
            }
            catch (Exception) { }
            
            dgvFilms.DataSource = searchFilm;
            checkSearchBoxEmpty();
        }

        /// <summary>
        /// Checks if the search box is empty.
        /// empty meaning not characters entered
        /// </summary>
        private void checkSearchBoxEmpty()
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                dgvFilms.DataSource = bs;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        /// <summary>
        /// A Dialog will open up to search/browse through the user's
        /// file system to open an XML file to import.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream strm;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Import XML File";
            openDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openDialog.FilterIndex = 1;
            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if ((strm = openDialog.OpenFile()) != null)
                {
                    string fileName = openDialog.FileName;
                    currentFile = fileName;
                    strm.Close();
                    bs = DataIO.LoadFromFile(fileName);
                    dgvFilms.DataSource = bs;
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvFilms.DataSource = bs;
        }

        /// <summary>
        /// Right click -> Search Online
        /// Google searches the selected film's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;
            string[] tokens = dog.Name.Split(' ');
            string newSearch = "";
            foreach (string s in tokens)
            {
                newSearch += s + "+";
            }
            System.Diagnostics.Process.Start("https://www.google.com/search?as_q=" + newSearch);
        }

        /// <summary>
        /// Real time search through user's library as the user types.
        /// Searches by Name if drop down is set to "by Name" and rating
        /// if "by Rating".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                searchByName();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                searchByRating();
            }
        }

        /// <summary>
        /// Does a Google web search of the film name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchOMovieBtn_Click(object sender, EventArgs e)
        {
            new SearchOnlineWindow(this).Show();
        }

        /// <summary>
        /// Tooltip text pops up when the user hovers mouse over
        /// a row. Information is the film's description if available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFilms_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;
                dgvFilms.CurrentCell.ToolTipText = dog.Description;
            }
            catch (NullReferenceException) { }
        }

        /// <summary>
        /// Options -> Clear.
        /// Allows user to clear his entire saved library.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear your library?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bs.Clear();
                dgvFilms.DataSource = bs;
                save();
            }
            else { }
        }
    }
}
