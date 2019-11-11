using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public static class DBWriter
    {
        public static void WriteToDB(DataStagedForDBWrite stagedData)
        {
            SqlConnection dbConnection = new SqlConnection(@"Server=xena\sql2017;Database=emovies.Lukas;User Id=emovies.Lukas;Password=emovies;MultipleActiveResultSets=True;");
            dbConnection.Open();

            SqlCommand customerCommand = new SqlCommand("AddNewCustomer", dbConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            Customer customer = stagedData.CustomerData;

            customerCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            customerCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
            customerCommand.Parameters.Add("@CreditCardNumber", SqlDbType.NVarChar).Value = customer.CardNumber;
            customerCommand.Parameters.Add("@CreditCardType", SqlDbType.NVarChar).Value = customer.CardType;
            customerCommand.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = customer.FuturePromotions;
            customerCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;

            SqlParameter customerId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            customerCommand.Parameters.Add(customerId);

            customerCommand.ExecuteReader();

            int idOfAddedCustomer = Convert.ToInt32(customerId.Value);



            SqlCommand orderCommand = new SqlCommand("AddNewOrder", dbConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            orderCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
            orderCommand.Parameters.Add("@Total", SqlDbType.Decimal).Value = stagedData.CustomerOrderData.Total;
            orderCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = idOfAddedCustomer;

            SqlParameter orderId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
            orderCommand.Parameters.Add(orderId);

            orderCommand.ExecuteReader();

            int idOfAddedOrder = Convert.ToInt32(orderId.Value);



            foreach (MovieOrder movieOrder in stagedData.MovieOrders)
            {
                SqlCommand movieOrderCommand = new SqlCommand("AddNewMovieOrder", dbConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                movieOrderCommand.Parameters.Add("@OrderId", SqlDbType.Int).Value = idOfAddedOrder;
                movieOrderCommand.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieOrder.MovieId;
                movieOrderCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = movieOrder.Price;
                movieOrderCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = movieOrder.Quantity;

                SqlParameter movieOrderId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                movieOrderCommand.Parameters.Add(movieOrderId);

                movieOrderCommand.ExecuteReader();

                int idOfAddedMovieOrder = Convert.ToInt32(movieOrderId.Value);
            }


            dbConnection.Close();
        }
    }
}