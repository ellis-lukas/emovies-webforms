using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class PresentationOrderLine
    {
        public string Name;

        public int Quantity;

        public decimal Price;
        public PresentationOrderLine(MovieOrder movieOrder)
        {
            
        }

        private Movie GetMovie(MovieOrder movieOrder)
        {
            List<Movie> currentMovieList = new MovieRepository().GetMovies();
            int movieId = movieOrder.MovieId;
            if (currentMovieList.Exists(movie => movie.Id == movieId))
            {
                return movie;
            }
        }
    }
}