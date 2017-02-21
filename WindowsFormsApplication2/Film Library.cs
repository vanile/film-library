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
    public partial class Form1 : Form
    {
        private FilmDB library;

        public Form1()
        {
            InitializeComponent();
            library = new FilmDB();
            library.Add(new Film("Pokemon", 5));
            foreach (Film film in library.GetFilms())
            {
                dgvFilms.Rows.Add(film.GetFilmName(), film.GetRating());
            }
            
        }

        private void dgvFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Name = dgvFilms.Rows[e.RowIndex].Cells[0].Value.ToString();
            int Rating = 0;

            string tempRating = dgvFilms.Rows[e.RowIndex].Cells[1].Value.ToString();
            Int32.TryParse(tempRating, out Rating);

            Console.WriteLine("{0} - {1}", Name, Rating);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            
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
    }
}
