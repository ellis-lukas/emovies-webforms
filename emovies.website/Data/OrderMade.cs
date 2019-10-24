using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class OrderMade
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int Quantity { get; set; }
    }
}