using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public static class ListOfMoviesOrderedMapper
    {

        public static List<MovieOrder> MapFromSession(HttpSessionState sessionState)
        {
            List<MovieOrder> listOfMoviesOrdered = (List<MovieOrder>)sessionState["MoviesOrdered"];
            return listOfMoviesOrdered;
        }
    }
}