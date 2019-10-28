using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    //keep this as a class for now. Eventually, when loading in from a database, it might be worth changing this file to a group of interfaces and classes
    public static class ListExtensions
    {
        private static int GetQuantityFromRepeatedRow(RepeaterItem row)
        {
            TextBox quantityTextBox = (TextBox)(row.FindControl("quantity"));
            int quantity = int.Parse(quantityTextBox.Text);
            return quantity;
        }

        public static List<OrderMade> PopulateOrderListFromMovieTable (this List<OrderMade> orderList, RepeaterItemCollection repeaterItemCollection, List<Movie> movieList)
        {
            List<OrderMade> orders = new List<OrderMade>();
            int counter = 0;

            foreach (RepeaterItem item in repeaterItemCollection)
            {
                int _quantity = GetQuantityFromRepeatedRow(item);
                if (_quantity != 0)
                {
                    int _Id = orders.Count + 1;
                    int _MovieId = movieList[counter].Id;
                    orders.Add(new OrderMade { Id = _Id, MovieId = _MovieId, Quantity = _quantity });
                }
                counter++;
            }

            return orders;
        }

        public static decimal Total (this List<OrderMade> orderList, List<Movie> movieList)
        {
            decimal Total = 0.0m;

            foreach (OrderMade order in orderList)
            {
                Total += order.Quantity * movieList[order.MovieId - 1].Price;
            }

            return Total;
        }
    }
}