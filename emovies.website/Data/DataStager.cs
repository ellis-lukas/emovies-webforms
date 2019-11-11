using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public static class DataStager
    {
        public static DataStagedForDBWrite StageData(HttpSessionState sessionState)
        {
            return new DataStagedForDBWrite
            {
                CustomerData = CustomerMapper.MapFromSession(sessionState),
                CustomerOrderData = CustomerOrderMapper.MapFromSession(sessionState),
                MovieOrders = ListOfMoviesOrderedMapper.MapFromSession(sessionState)
            };
        }
    }
}