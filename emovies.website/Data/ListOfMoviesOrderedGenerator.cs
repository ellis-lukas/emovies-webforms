using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public static class ListOfMoviesOrderedGenerator
    {
        public static List<MovieOrder> GenerateFromReturnedTable(RepeaterItemCollection returnedMovieTable)
        {
            List<RepeaterItem> listOfReturnedMovieTableRows = MapXCollectionToListOfX.XisRepeaterItem(returnedMovieTable);
            List<MovieOrder> allMovieOrders = ConvertToMovieOrders(listOfReturnedMovieTableRows);
            List<MovieOrder> nonZeroMovieOrders = ExtractNonZeroOrders(allMovieOrders);
            return nonZeroMovieOrders;
        }

        private static List<MovieOrder> ConvertToMovieOrders(List<RepeaterItem> returnedList)
        {
            List<MovieOrder> movieOrders = new List<MovieOrder>();

            List<int> quantities = new List<int>();
            foreach (RepeaterItem item in returnedList)
            {
                quantities.Add(MovieOrderMapper.GetQuantityFromRepeaterItem(item));
            }

            List<Movie> CurrentMovies = new MovieRepository().GetMovies();
            foreach(Movie movie in CurrentMovies)
            {
                movieOrders.Add(new MovieOrder
                {
                    MovieId = movie.Id,
                    Price = movie.Price,
                    Quantity = quantities[movie.Id]
                });
            }

            return movieOrders;
        }

        private static List<MovieOrder> ExtractNonZeroOrders (List<MovieOrder> listOfAllMovieOrders)
        {
            List<MovieOrder> nonZeroMovieOrders = new List<MovieOrder>();
            foreach (MovieOrder movieOrder in listOfAllMovieOrders)
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