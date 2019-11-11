using System.Web.SessionState;

namespace emovies.website.Data
{
    public static class CustomerMapper
    {
        public static Customer MapFromSession(HttpSessionState sessionState)
        {
            return new Customer
            {
                Name = (string)sessionState["Name"],
                Email = (string)sessionState["Email"],
                CardNumber = (string)sessionState["CardNumber"],
                CardType = (string)sessionState["CardType"],
                FuturePromotions = (string)sessionState["FuturePromotions"]
            };
        }
    }
}