using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public bool FuturePromotions { get; set; }
    }
}