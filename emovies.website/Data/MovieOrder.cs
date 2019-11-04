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
            Movie GotMovie = Default.CurrentMovies[this.MovieId - 1];
            return GotMovie;
        }
    }
}