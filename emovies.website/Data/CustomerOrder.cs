using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}