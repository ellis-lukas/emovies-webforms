using System.Collections.Generic;
using System.Web.SessionState;

namespace emovies.website.Data
{
    public class SessionDataStager
    {
        public DataStagedForDBWrite StageData(HttpSessionState sessionState)
        {
            return new DataStagedForDBWrite
            {
                CustomerData = GetCustomerFromSession(sessionState),
                CustomerOrderData = GetOrderFromSession(sessionState),
                OrderLines = GetOrderLinesFromSession(sessionState)
            };
        }

        private Customer GetCustomerFromSession(HttpSessionState sessionState)
        {
            Customer mappedCustomer = (Customer)sessionState["CustomerInfo"];
            return mappedCustomer;
        }

        private CustomerOrder GetOrderFromSession(HttpSessionState sessionState)
        {
            List<OrderLine> moviesOrdered = (List<OrderLine>)sessionState["MoviesOrdered"];
            decimal orderTotal = moviesOrdered.Total();
            return new CustomerOrder
            {
                Total = orderTotal
            };
        }

        private List<OrderLine> GetOrderLinesFromSession(HttpSessionState sessionState)
        {
            List<OrderLine> listOfMoviesOrdered = (List<OrderLine>)sessionState["MoviesOrdered"];
            return listOfMoviesOrdered;
        }
    }
}