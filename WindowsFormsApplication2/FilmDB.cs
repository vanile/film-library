using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPP.CS.CS408.FilmLib
{
    class FilmDB
    {
        private List<Film> films;

        public FilmDB()
        {
            films = new List<Film>();
        }

        public void Add(Film film)
        {
            films.Add(film);
        }

        public List<Film> GetFilms()
        {
            return films;
        }
    }
}
