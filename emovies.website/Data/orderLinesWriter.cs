using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class OrderLinesWriter : TableWriter
    {
        public int AddedOrderID;

        private int Counter;

        public void Write()
        {
            for(Counter = 0; Counter < StagedData.MovieOrders.Count; Counter++)
            {
                InitialiseCommand();
                AddDBConnection();
                AddTransaction();
                AddStoredProcedure();
                AddCommandParameters();
                InitialiseReturnParameter();
                AddReturnParameter();
                ExecuteCommand();
                SetLastAddedEntryID();
                SendLastAddedIDToMediator();
            }
        }

        private void AddStoredProcedure()
        {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "AddNewOrderLine";
        }

        private void AddCommandParameters()
        {
            OrderLine orderLine = StagedData.MovieOrders[Counter];

            Command.Parameters.Add("@OrderId", SqlDbType.Int).Value = AddedOrderID;
            Command.Parameters.Add("@MovieId", SqlDbType.Int).Value = orderLine.MovieId;
            Command.Parameters.Add("@Price", SqlDbType.Decimal).Value = orderLine.Price;
            Command.Parameters.Add("@Quantity", SqlDbType.TinyInt).Value = orderLine.Quantity;
        }
    }
}
