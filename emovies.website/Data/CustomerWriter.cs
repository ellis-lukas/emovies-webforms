using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class CustomerWriter : TableWriter
    {
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
            Command.CommandText = "AddNewCustomer";
        }

        private void AddCommandParameters()
        {
            Customer customer = StagedData.CustomerData;

            Command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            Command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
            Command.Parameters.Add("@CreditCardNumber", SqlDbType.NVarChar).Value = customer.CardNumber;
            Command.Parameters.Add("@CreditCardType", SqlDbType.NVarChar).Value = customer.CardType;
            Command.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = customer.FuturePromotions;
            Command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
        }
    }
}