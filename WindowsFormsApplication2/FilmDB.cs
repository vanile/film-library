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
            //Add(new Film("Pokemon", 5));
        }

        public void Add(Film film)
        {
            films.Add(film);
        }

        public Film SearchName(string filmName) //might change to list of films with short search 
        {
            string nameTemp;
            filmName = filmName.ToUpper();
            foreach(Film film in films)
            {
                nameTemp = film.GetFilmName().ToUpper();
                if (nameTemp.Equals(filmName))
                {
                    return film;
                }
            }
            return null;
        }

        public List<Film> GetFilms()
        {
            return films;
        }
    }
}
