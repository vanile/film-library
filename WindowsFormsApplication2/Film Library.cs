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
        private FilmDB library;
        //private BindingSource bs = new BindingSource();
        private SortableBindingList<Film> bs = new SortableBindingList<Film>();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            library = new FilmDB();
            //library.Add(new Film("Dog", 3));


            //library.Add(new Film("Pokemon", 5));
            //library.Add(new Film("Dogs", 3));
            //library.Add(new Film("Music 101", 1));
            //foreach (Film film in library.GetFilms())
            //{
            //    dgvFilm.Rows.Add(film.FilmName, film.Rating);
            //}
            bs.Add(new Film("pokerdoggger", 5));
            bs.Add(new Film("hairy porter", 1));
            bs.Add(new Film("lol", 4));

            dgvFilms.AutoGenerateColumns = false;
            dgvFilms.AutoSize = true;
            dgvFilms.DataSource = bs;

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "FilmName";
            col1.Name = "Film Name";
            col1.ReadOnly = true;
            
            dgvFilms.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Rating";
            col2.Name = "Rating";
            col2.ReadOnly = true;
            dgvFilms.Columns.Add(col2);

            this.Controls.Add(dgvFilms);
            this.AutoSize = true;
        }

        private void dgvFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string Name = dgvFilms.Rows[e.RowIndex].Cells[0].Value.ToString();
            int Rating = 0;

            //string tempRating = dgvFilms.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Int32.TryParse(tempRating, out Rating);

            //Console.WriteLine("{0} - {1}", Name, Rating);
        }

        public void EditBtn_Click(object sender, EventArgs e)
        {
            Film dog = (Film)dgvFilms.CurrentRow.DataBoundItem;
            dog.FilmName = "EDITED";
            dog.Rating = 1;
            Console.WriteLine("{0} - {1}", dog.FilmName, dog.Rating);

            //dgvFilms.DataSource = f1;
            //new AddWindow(dog);
            //List<Film> s3 = (List<Film>)dgvFilms.DataSource;
           // Console.WriteLine(s3[0].FilmName);


        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
            searchBox.SelectAll();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchBox.Text.Equals("")) //empty box
            {
                new MessageWindow("Search box is empty!").Show();
            }
            else
            {
                string name;
                foreach (DataGridView row in dgvFilms.Rows)
                {
                    name = row.CurrentCell.Value.ToString();
                    Console.WriteLine(name);
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //AddWindow aWin = new AddWindow();
            //aWin.Show();
            bs.Add(new Film("porker", 2));
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFilms.SelectedRows)
            {
                dgvFilms.Rows.RemoveAt(row.Index);
            }
        }
    }
}
