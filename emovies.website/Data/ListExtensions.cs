using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public static class ListExtensions
    {
        public static decimal Total (this List<MovieOrder> orderList)
        {
            decimal Total = 0.0m;
            foreach (MovieOrder order in orderList)
            {
                Total += order.MovieOrderTotal();
            }
            return Total;
        }
    }
}