using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class OrderCommandParameterAdder
    {
        public static SqlCommand AddCustomerDataAsParameters(CustomerOrder customerOrder, int customerId, SqlCommand orderCommand)
        {
            orderCommand.CommandType = CommandType.StoredProcedure;
            orderCommand.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerOrder.CustomerId;
            orderCommand.Parameters.Add("@Total", SqlDbType.Decimal).Value = customerOrder.Total;
            orderCommand.Parameters.Add("@DateCreated", SqlDbType.NVarChar).Value = DateTime.Now;

            return orderCommand;
        }
    }
}