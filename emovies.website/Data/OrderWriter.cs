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

        override protected void AddStoredProcedure()
        {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "AddNewOrder";
        }

        override protected void AddCommandParameters()
        {
            Command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
            Command.Parameters.Add("@Total", SqlDbType.Decimal).Value = CustomerOrder.Total;
            Command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = AddedCustomerID;
        }
    }
}