using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.CS.CS408.FilmLib
{
    public class Film
    {   
        public string Name { get; set; }
        public int Rating { get; set; }
        public const int MAX_RATING = 10;
        public const int MIN_RATING = 0;
        public string Comments { get; set; }
        public DateTime DateWatched { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string FilmStatus { get; set; }
        public const string StatusInQueue = "In Queue";
        public const string StatusFinished = "Finished";
        public string Description { get; set; }
        public int tmdbID { get; set; }
        public string tmdbImgUrl { get; set; }

        public Film() 
        {
        }
    }
}
