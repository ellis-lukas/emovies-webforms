using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string FuturePromotions { get; set; }
        public void fillOutVisitorInfo(object obj)
        {
            this.Name = (string)obj["Name"];
            this.Email = (string)obj["Email"];
            this.CardNumber = (string)obj["CardNumber"];
            this.CardType = (string)obj["CardType"];
            this.FuturePromotions = ((int)obj["FuturePromotions"]) == 0 ? "No" : "Yes";
        }
    }
}