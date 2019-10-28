using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string FuturePromotions { get; set; }
        public CustomerInfo(HttpSessionState session)
        {
            this.Name = (string)session["Name"];
            this.Email = (string)session["Email"];
            this.CardNumber = (string)session["CardNumber"];
            this.CardType = (string)session["CardType"];
            this.FuturePromotions = (int)session["FuturePromotions"] == 0 ? "No" : "Yes";
        }
    }
}