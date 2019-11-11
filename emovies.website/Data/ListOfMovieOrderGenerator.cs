using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public class ListOfMovieOrderGenerator
    {
        private List<int> QuantityList;

        private List<Movie> CurrentMoviesInRenderedOrder;

        public ListOfMovieOrderGenerator(List<int> quantityList, List<Movie> currentMoviesInRenderedOrder)
        {
            QuantityList = quantityList;
            CurrentMoviesInRenderedOrder = currentMoviesInRenderedOrder;
        }

        public List<MovieOrder> GenerateMovieOrders()
        {
            return ExtractNonZeroOrders(LinkDataToCreateListTypeMovieOrder());
        }

        public List<MovieOrder> LinkDataToCreateListTypeMovieOrder()
        {
            List<MovieOrder> MoviesOrdered = new List<MovieOrder>();
            for (int i = 0; i < CurrentMoviesInRenderedOrder.Count; i++)
            {
                MoviesOrdered.Add(new MovieOrder
                {
                    MovieId = CurrentMoviesInRenderedOrder[i].Id,
                    Price = CurrentMoviesInRenderedOrder[i].Price,
                    Quantity = QuantityList[i]
                });
            }
            return MoviesOrdered;
        }

        private List<MovieOrder> ExtractNonZeroOrders (List<MovieOrder> movieOrdersZeroQuantInc)
        {
            List<MovieOrder> nonZeroMovieOrders = new List<MovieOrder>();
            foreach (MovieOrder movieOrder in movieOrdersZeroQuantInc)
            {
                if (movieOrder.Quantity > 0)
                {
                    nonZeroMovieOrders.Add(movieOrder);
                }
            }
            return nonZeroMovieOrders;
        }
    }
}