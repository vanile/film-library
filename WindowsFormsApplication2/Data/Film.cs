using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.CS.CS408.FilmLib
{
    /// <summary>
    /// Film object class. The unit of this program.
    /// Holds a film's information.
    /// </summary>
    public class Film
    {   
        public string Name { get; set; }
        public string Description { get; set; }
        public string tmdbImgUrl { get; set; }
        public string Comments { get; set; }
        public string FilmStatus { get; set; }

        public static string StatusInQueue = "In Queue";
        public static string StatusFinished = "Finished";
        public static string tmdbUrlImage = "https://image.tmdb.org/t/p/original";
        public static string TmdbUrlMovieTitle = "https://www.themoviedb.org/movie/";
        public static string TmdbImgUrl = "https://image.tmdb.org/t/p/original";

        public int Rating { get; set; }
        public int tmdbID { get; set; }

        public static int MIN_RATING = 0;
        public static int MAX_RATING = 10;
        
        public DateTime DateWatched { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public Film() 
        {
        }
    }
}
