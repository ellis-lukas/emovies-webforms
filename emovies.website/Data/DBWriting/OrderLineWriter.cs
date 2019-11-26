using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class OrderLineWriter : TableWriter
    {
        public int AddedOrderID;

        public OrderLine OrderLine;

        override protected void AddStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddNewOrderLine";
        }

        override protected void AddCommandParameters(SqlCommand command)
        {
            command.Parameters.Add("@OrderId", SqlDbType.Int).Value = AddedOrderID;
            command.Parameters.Add("@MovieId", SqlDbType.Int).Value = OrderLine.MovieId;
            command.Parameters.Add("@Price", SqlDbType.Decimal).Value = OrderLine.Price;
            command.Parameters.Add("@Quantity", SqlDbType.TinyInt).Value = OrderLine.Quantity;
        }
    }
}
