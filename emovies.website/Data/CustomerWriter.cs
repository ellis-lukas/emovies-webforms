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

        override protected void AddStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddNewCustomer";
        }

        override protected void AddCommandParameters(SqlCommand command)
        {
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Customer.Name;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Customer.Email;
            command.Parameters.Add("@CreditCardNumber", SqlDbType.NVarChar).Value = Customer.CardNumber;
            command.Parameters.Add("@CreditCardType", SqlDbType.NVarChar).Value = Customer.CardType;
            command.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = Customer.FuturePromotions;
            command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
        }
    }
}