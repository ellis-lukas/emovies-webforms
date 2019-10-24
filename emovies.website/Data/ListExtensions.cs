using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    //keep this as a class for now. Eventually, when loading in from a database, it might be worth changin gthis file to a group of interfaces and classes
    public static class ListExtensions
    {
        public static L OutputAll(this IEnumerable<OrderMade> orders, RepeaterItemCollection repeaterItemCollection, List<Movie> movieList)
        {
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
    }
}