using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class OrderWriter : TableWriter
    {
        public int AddedCustomerID;

        public CustomerOrder CustomerOrder;

        override protected void AddStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddNewOrder";
        }

        override protected void AddCommandParameters(SqlCommand command)
        {
            command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@Total", SqlDbType.Decimal).Value = CustomerOrder.Total;
            command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = AddedCustomerID;
        }
    }
}