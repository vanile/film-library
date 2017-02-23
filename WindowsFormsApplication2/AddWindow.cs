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

        public AddWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public AddWindow(string Name, Film film)
        {
            InitializeComponent();
            this.CenterToScreen();

            this.Text = Name;
            nameBox.Text = film.FilmName;
            ratingBox.Text = film.Rating.ToString();
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Enter a name", "Error");
            }
            film.FilmName = nameBox.Text;
            int rating;
            Int32.TryParse(ratingBox.Text, out rating);
            if (rating > 10 || rating < 0)
            {
                MessageBox.Show("Enter a valid rating", "Invalid Rating");
            }
            film.Rating = rating;
        }

        private void ratingBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
