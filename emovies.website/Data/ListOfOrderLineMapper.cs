using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class ListOfOrderLineMapper
    {
        public List<OrderLine> MapFromSession(HttpSessionState sessionState)
        {
            List<OrderLine> listOfMoviesOrdered = (List<OrderLine>)sessionState["MoviesOrdered"];
            return listOfMoviesOrdered;
        }
    }
}