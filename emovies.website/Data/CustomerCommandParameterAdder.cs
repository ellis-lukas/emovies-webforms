using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public static class CustomerCommandParameterAdder
    {
        public static SqlCommand AddCustomerDataAsParameters(Customer customer, SqlCommand customerCommand)
        {
            customerCommand.CommandType = CommandType.StoredProcedure;
            customerCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            customerCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
            customerCommand.Parameters.Add("@CardNumber", SqlDbType.NVarChar).Value = customer.CardNumber;
            customerCommand.Parameters.Add("@CardType", SqlDbType.NVarChar).Value = customer.CardType;
            customerCommand.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = customer.FuturePromotions;
            customerCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;

            return customerCommand;
        }
    }
}