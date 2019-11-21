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
        public Customer Customer;

        override protected void AddStoredProcedure()
        {
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = "AddNewCustomer";
        }

        override protected void AddCommandParameters()
        {
            Command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Customer.Name;
            Command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Customer.Email;
            Command.Parameters.Add("@CreditCardNumber", SqlDbType.NVarChar).Value = Customer.CardNumber;
            Command.Parameters.Add("@CreditCardType", SqlDbType.NVarChar).Value = Customer.CardType;
            Command.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = Customer.FuturePromotions;
            Command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
        }
    }
}