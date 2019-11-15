using System.Web.SessionState;

namespace emovies.website.Data
{
    public class CustomerMapper
    {
        public Customer MapFromSession(HttpSessionState sessionState)
        {
            Customer mappedCustomer = (Customer)sessionState["CustomerInfo"];
            return mappedCustomer;
        }
    }
}