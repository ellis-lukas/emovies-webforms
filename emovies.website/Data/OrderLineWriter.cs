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

        override protected void AddStoredProcedure()
        {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "AddNewOrderLine";
        }

        override protected void AddCommandParameters()
        {
            Command.Parameters.Add("@OrderId", SqlDbType.Int).Value = AddedOrderID;
            Command.Parameters.Add("@MovieId", SqlDbType.Int).Value = OrderLine.MovieId;
            Command.Parameters.Add("@Price", SqlDbType.Decimal).Value = OrderLine.Price;
            Command.Parameters.Add("@Quantity", SqlDbType.TinyInt).Value = OrderLine.Quantity;
        }
    }
}
