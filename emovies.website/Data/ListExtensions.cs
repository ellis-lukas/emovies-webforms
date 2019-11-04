using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public static class ListExtensions
    {

        //      List<Movie> "Constructor" START     //

        public static List<MovieOrder> PopulateFromReturnedTable(this List<MovieOrder> orderList, RepeaterItemCollection returnedTable)
        {
            List<RepeaterItem> returnedList = returnedTable.ToPreferableListForm();
            List<MovieOrder> orders = returnedList.ExtractOrders();
            orders.AscribeIds();
            return orders;
        }

        public static List<RepeaterItem> ToPreferableListForm(this RepeaterItemCollection repeaterItemCollection)
        {
            List<RepeaterItem> listOfRepeaterItems = new List<RepeaterItem>();
            foreach (RepeaterItem repeaterItem in repeaterItemCollection)
            {
                listOfRepeaterItems.Add(repeaterItem);
            }
            return listOfRepeaterItems;
        }

        public static List<MovieOrder> ExtractOrders(this List<RepeaterItem> returnedList)
        {
            List<MovieOrder> orders = new List<MovieOrder>();
            for (int i = 0; i < Default.CurrentMovies.Count; i++)
            {
                int quantityOrdered = GetQuantityFromMovieListing(returnedList[i]);
                if (quantityOrdered != 0)
                {
                    orders.Add(new MovieOrder { MovieId = i + 1, Quantity = quantityOrdered });
                }
            }
            return orders;
        }

        private static int GetQuantityFromMovieListing(RepeaterItem movieListing)
        {
            TextBox movieListingQuantityCell = (TextBox)(movieListing.FindControl("quantity"));
            int movieListingQuantity = int.Parse(movieListingQuantityCell.Text);
            return movieListingQuantity;
        }

        public static void AscribeIds(this List<MovieOrder> orders)
        {
            foreach (MovieOrder movieOrder in orders)
            {
                movieOrder.Id = 1 + orders.IndexOf(movieOrder);
            }
        }

        //      List<Movie> "Constructor" END       //

        //      Behaviour ie. location of "reason to change"       //

        public static decimal Total (this List<MovieOrder> orderList)
        {
            decimal Total = 0.0m;
            foreach (MovieOrder order in orderList)
            {
                Total += MovieOrderTotal(order);
            }
            return Total;
        }

        public static decimal MovieOrderTotal(MovieOrder order)
        {
            return order.Quantity * Default.CurrentMovies[order.MovieId - 1].Price;
        }

    }
}