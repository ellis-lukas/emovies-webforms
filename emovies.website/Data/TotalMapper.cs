using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class TotalMapper
    {
        public decimal MapTotal(OrderLine movieOrder)
        {
            decimal total = 0;
            total += movieOrder.Price * movieOrder.Quantity;
            return total;
        }

        public decimal MapTotal(List<OrderLine> movieOrders)
        {
            decimal total = 0;
            foreach(OrderLine movieOrder in movieOrders)
            {
                total += MapTotal(movieOrder);
            }
            return total;
        }

        public decimal MapTotal(DisplayOrderLine movieOrder)
        {
            decimal total = 0;
            total += movieOrder.Price * movieOrder.Quantity;
            return total;
        }

        public decimal MapTotal(List<DisplayOrderLine> movieOrders)
        {
            decimal total = 0;
            foreach(DisplayOrderLine movieOrder in movieOrders)
            {
                total += MapTotal(movieOrder);
            }
            return total;
        }
    }
}