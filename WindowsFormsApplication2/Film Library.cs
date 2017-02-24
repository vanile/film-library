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

namespace CPP.CS.CS408.FilmLib
{
    public partial class Form1 : Form
    {
        private SortableBindingList<Film> bs = new SortableBindingList<Film>();
        private bool searchCleared;
        private DataIO data;
        private string currentFile;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            searchCleared = false;
            data = new DataIO();
            comboBox1.SelectedIndex = 0;

            load();
            dgvFilms.AutoGenerateColumns = false;
            dgvFilms.AutoSize = false;
            dgvFilms.DataSource = bs;

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "FilmName";
            col1.Name = "Film Name";
            col1.Width = 125;
            col1.ReadOnly = true;
            
            dgvFilms.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Rating";
            col2.Name = "Rating/10";
            col2.Width = 65;
            col2.ReadOnly = true;
            dgvFilms.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "Comments";
            col3.Name = "Comments";
            col3.Width = 100;
            col3.ReadOnly = true;
            dgvFilms.Columns.Add(col3);

            this.Controls.Add(dgvFilms);
            this.AutoSize = true;
            searchBox.GotFocus += searchBox_GotFocus;
        }

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
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;

            using (AddWindow form = new AddWindow("Edit Film", dog) { film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int lol = bs.IndexOf(dog);
                    bs[bs.IndexOf(dog)] = form.film;
                }
            }
            save();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            foreach (Film sFilm in bs)
            {
                if (sFilm.FilmName.Contains(searchBox.Text))
                {
                    searchFilm.Add(sFilm);
                }
            }
            dgvFilms.DataSource = searchFilm;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            using(AddWindow form = new AddWindow() {film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bs.Add(form.film);
                }
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
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bs.Add(form.film);
                }
            }
            save();
        }

        private void editToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;

            using (AddWindow form = new AddWindow("Edit Film", dog) { film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int lol = bs.IndexOf(dog);
                    bs[bs.IndexOf(dog)] = form.film;
                }
            }
            save();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
            save();
        }

        private void save()
        {
            if (currentFile != null)
            {
                data.SaveToFile(bs, currentFile);
            }
            else
            {
                data.SaveToFile(bs, "filmLibraryData.xml");
            }
            
        }

        private void load()
        {
            SortableBindingList<Film> loaded = new SortableBindingList<Film>();
            loaded = data.LoadFromFile("filmLibraryData.xml");
            if (loaded != null)
            {
                bs = loaded;
            }
            else { }
        }

        private void export(string fileName)
        {
            fileName = fileName + ".txt";
            data.SaveToText(bs, fileName);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Export to Text File";

            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string tab = "\t";
                string rating = "Rating: ";
                using (Stream s = File.Open(saveDialog.FileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    foreach (Film film in bs)
                    {
                        sw.WriteLine("[" + film.FilmName + "]");
                        sw.WriteLine(tab + rating + film.Rating);
                    }
                    s.Close();
                    sw.Close();
                }
            }
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void searchByName()
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            foreach (Film sFilm in bs)
            {
                string nameTemp = sFilm.FilmName.ToUpper();
                string search = searchBox.Text.ToUpper();
                if (nameTemp.Contains(search))
                {
                    searchFilm.Add(sFilm);
                }
            }
            dgvFilms.DataSource = searchFilm;
            checkSearchBoxEmpty();
        }

        private void searchByRating()
        {
            SortableBindingList<Film> searchFilm = new SortableBindingList<Film>();
            int temp;

            foreach (Film sFilm in bs)
            {
                Int32.TryParse(searchBox.Text, out temp);
                if (sFilm.Rating.Equals(temp))
                {
                    searchFilm.Add(sFilm);
                }
            }
            dgvFilms.DataSource = searchFilm;
            checkSearchBoxEmpty();
        }

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

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream strm;
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Title = "Import XML File";
            openDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if ((strm = openDialog.OpenFile()) != null)
                {
                    string fileName = openDialog.FileName;
                    currentFile = fileName;
                    strm.Close();
                    bs = data.LoadFromFile(fileName);
                    dgvFilms.DataSource = bs;
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvFilms.DataSource = bs;
        }

        private void searchOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;
            string[] tokens = dog.FilmName.Split(' ');
            string newSearch = "";
            foreach (string s in tokens)
            {
                newSearch += s + "+";
            }
            System.Diagnostics.Process.Start("https://www.google.com/search?as_q=" + newSearch);
        }
    }
}
