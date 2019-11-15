using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class DisplayCustomer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProtectedCardNumber { get; set; }
        public string CardType { get; set; }
        public bool FuturePromotions { get; set; }
    }
}