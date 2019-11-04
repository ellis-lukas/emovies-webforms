using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class CustomerInformation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        private ProtectedCardNumber CardNumber { get; set; }
        public string CardNumberStarred { get => CardNumber.SafeFormat; }
        public string CardType { get; set; }
        public string FuturePromotions { get; set; }
        public CustomerInformation()
        {

        }
        public CustomerInformation(HttpSessionState session)
        {
            this.Name = (string)session["Name"];
            this.Email = (string)session["Email"];
            this.CardNumber = new ProtectedCardNumber((string)session["CardNumber"]);
            this.CardType = (string)session["CardType"];
            if ((int)session["FuturePromotions"] == 0)
            {
                this.FuturePromotions = "No";
            }
            else
            {
                this.FuturePromotions = "Yes";
            }
        }
    }
}