using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public static class ListOfOrderLineExtensions
    {
        public static decimal Total(this List<OrderLine> listOfOrderLines) 
        {
            decimal total = 0;

            foreach (OrderLine orderLine in listOfOrderLines)
            {
                total += orderLine.Total;
            }

            return total;
        }
    }
}