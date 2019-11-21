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

        public void Write()
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

        private void AddStoredProcedure()
        {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "AddNewOrder";
        }

        private void AddCommandParameters()
        {
            CustomerOrder customerOrder = StagedData.CustomerOrderData;

            Command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
            Command.Parameters.Add("@Total", SqlDbType.Decimal).Value = customerOrder.Total;
            Command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = AddedCustomerID;
        }
    }
}