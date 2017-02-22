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
        public AddWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public AddWindow(string Name, int Rating)
        {
            InitializeComponent();
            this.CenterToScreen();
            nameBox.Text = Name;
            ratingBox.Text = Rating.ToString();
        }

        private void AddWindow_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(ratingBox.Text))
            {
                new MessageWindow("One or more of the fields are empty.");
            }
            int temp;
            Int32.TryParse(ratingBox.Text, out temp);
            Film nFilm = new Film(nameBox.Text, temp);
        }

    }
}
