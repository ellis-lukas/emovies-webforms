using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public static class CustomerOrderMapper
    {
        public static CustomerOrder MapFromSession(HttpSessionState sessionState)
        {
            return new CustomerOrder
            {
                Total = ((List<MovieOrder>)sessionState["MoviesOrdered"]).Total()
            };
        }
    }
}