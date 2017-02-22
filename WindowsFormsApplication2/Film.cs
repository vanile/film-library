using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.CS.CS408.FilmLib
{
    class Film
    {
        public string FilmName { get; set; }
        public int Rating { get; set; }
        private const int MAX_RATING = 10;

        public Film(string name, int rate)
        {
            FilmName = name;
            Rating = rate;
        }

        public string GetFilmName()
        {
            return FilmName;
        }

        public int GetRating()
        {
            return Rating;
        }
    }
}
