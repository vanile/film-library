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

namespace CPP.CS.CS408.FilmLib
{
    public partial class Form1 : Form
    {
        private SortableBindingList<Film> bs = new SortableBindingList<Film>();
        private bool searchCleared;
        private DataIO data;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            searchCleared = false;
            data = new DataIO();

            bs.Add(new Film("pokerdoggger", 5));
            bs.Add(new Film("hairy porter", 1));
            bs.Add(new Film("lol", 4));

            dgvFilms.AutoGenerateColumns = false;
            dgvFilms.AutoSize = false;
            dgvFilms.DataSource = bs;

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "FilmName";
            col1.Name = "Film Name";
            col1.ReadOnly = true;
            
            dgvFilms.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Rating";
            col2.Name = "Rating/10";
            col2.ReadOnly = true;
            dgvFilms.Columns.Add(col2);

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

        private void dgvFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string Name = dgvFilms.Rows[e.RowIndex].Cells[0].Value.ToString();
            //int Rating = 0;
            //string tempRating = dgvFilms.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Int32.TryParse(tempRating, out Rating);

            //Console.WriteLine("{0} - {1}", Name, Rating);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;
            using (AddWindow form = new AddWindow("Edit Film", dog) { film = new Film() })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //bs.Remove(dog);
                   int lol = bs.IndexOf(dog);
                   // bs.Add(form.film);
                   bs[bs.IndexOf(dog)] = form.film;
                }
            }
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
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
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
                    //bs.Remove(dog);
                    int lol = bs.IndexOf(dog);
                    // bs.Add(form.film);
                    bs[bs.IndexOf(dog)] = form.film;
                }
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvFilms.DataSource = bs;
        }

        private void save()
        {
            data.SaveToFile(bs, "filmLibraryData.dat");
        }

        private void load()
        {
            bs = data.LoadFromFile("hi.dat");////
        }

        private void export()
        {

        }
    }
}
