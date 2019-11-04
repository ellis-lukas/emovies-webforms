using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public class MovieOrder
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int Quantity { get; set; }

        public Movie GetMovie()
        {
            List<Movie> currentMovies = Default.CurrentMovies;
            Movie GotMovie = currentMovies[this.MovieId - 1];
            return GotMovie;
        }

        /*
        public MovieOrder(RepeaterItem movieListing)
        {
            this.MovieId = 
            this.Quantity = 
        }*/

        //total function here instead??
    }
}