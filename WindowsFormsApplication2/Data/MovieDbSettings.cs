using DM.MovieApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.CS.CS408.FilmLib
{
    public class MovieDbSettings : IMovieDbSettings
    {
        public const string ApiKey = "028f68ad7e91dc4b839ad531982724bf";
        public const string  ApiUrl = "http://api.themoviedb.org/3/";

        string IMovieDbSettings.ApiKey
        {
            get { throw new NotImplementedException(); }
        }

        string IMovieDbSettings.ApiUrl
        {
            get { throw new NotImplementedException(); }
        }
    }
}
