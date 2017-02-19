using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.CS.CS408.FilmLib
{
    class Film
    {
        private string filmName;
        private int rating;
        private string[] tags;

        public Film(string name, int rate, string[] tag)
        {
            filmName = name;
            rating = rate;
            tags = tag;
        }

        public string GetFilmName()
        {
            return filmName;
        }

        public int GetRating()
        {
            return rating;
        }

        public string[] GetTags()
        {
            return tags;
        }
    }
}
