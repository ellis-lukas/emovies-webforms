using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public class ListOfOrderLineGenerator
    {
        private List<int> QuantityList;

        private List<Movie> CurrentMoviesInRenderedOrder;

        public ListOfOrderLineGenerator(List<int> quantityList, List<Movie> currentMoviesInRenderedOrder)
        {
            QuantityList = quantityList;
            CurrentMoviesInRenderedOrder = currentMoviesInRenderedOrder;
        }

        public List<OrderLine> GenerateMovieOrders()
        {
            return ExtractNonZeroOrders(LinkDataToCreateListTypeMovieOrder());
        }

        public List<OrderLine> LinkDataToCreateListTypeMovieOrder()
        {
            List<OrderLine> MoviesOrdered = new List<OrderLine>();
            for (int i = 0; i < CurrentMoviesInRenderedOrder.Count; i++)
            {
                MoviesOrdered.Add(new OrderLine
                {
                    MovieId = CurrentMoviesInRenderedOrder[i].Id,
                    Price = CurrentMoviesInRenderedOrder[i].Price,
                    Quantity = QuantityList[i]
                });
            }
            return MoviesOrdered;
        }

        private List<OrderLine> ExtractNonZeroOrders (List<OrderLine> movieOrdersZeroQuantInc)
        {
            List<OrderLine> nonZeroMovieOrders = new List<OrderLine>();
            foreach (OrderLine movieOrder in movieOrdersZeroQuantInc)
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