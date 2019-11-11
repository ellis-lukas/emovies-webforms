using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public class MovieOrder
    {
        public int OrderId { get; set; }

        public int MovieId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal MovieOrderTotal()
        {
            Movie movieInOrder = new MovieRepository().GetMovies[MovieId-1];
            return Quantity * movieInOrder.Price;
        }
    }
}