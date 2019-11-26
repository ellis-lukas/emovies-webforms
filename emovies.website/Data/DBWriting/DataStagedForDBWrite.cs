using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class DataStagedForDBWrite
    {
        public Customer CustomerData;

        public CustomerOrder CustomerOrderData;

        public List<OrderLine> OrderLines;
    }
}