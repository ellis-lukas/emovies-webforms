using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class DataStager
    {
        public DataStagedForDBWrite StageData(HttpSessionState sessionState)
        {
            return new DataStagedForDBWrite
            {
                CustomerData = new CustomerMapper().MapFromSession(sessionState),
                CustomerOrderData = new CustomerOrderMapper().MapFromSession(sessionState),
                MovieOrders = new ListOfOrderLineMapper().MapFromSession(sessionState)
            };
        }
    }
}