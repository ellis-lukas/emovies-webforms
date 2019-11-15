using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class CustomerOrderMapper
    {
        public CustomerOrder MapFromSession(HttpSessionState sessionState)
        {
            List<OrderLine> moviesOrdered = (List<OrderLine>)sessionState["MoviesOrdered"];
            decimal orderTotal = new TotalMapper().MapTotal(moviesOrdered);
            return new CustomerOrder
            {
                Total = orderTotal
            };
        }
    }
}