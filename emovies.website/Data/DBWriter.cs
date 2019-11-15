using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class DBWriter
    {
        private int idOfAddedCustomer;
        private int idOfAddedOrder;

        public void WriteToDB(DataStagedForDBWrite stagedData)
        {
            using (SqlConnection dbConnection = new SqlConnection(@"Server=xena\sql2017;Database=emovies.Lukas;User Id=emovies.Lukas;Password=emovies;MultipleActiveResultSets=True;"))
            {
                dbConnection.Open();

                using (SqlTransaction transaction = dbConnection.BeginTransaction())
                {
                    CreateCustomer(stagedData, dbConnection, transaction);
                    CreateOrder(stagedData, dbConnection, transaction);
                    CreateOrderLines(stagedData, dbConnection, transaction);

                    transaction.Commit();
                }
            }
        }

        private void AddCommandParametersUsingCustomerInfo(SqlCommand customerCommand, Customer customer)
        {
            customerCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = customer.Name;
            customerCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
            customerCommand.Parameters.Add("@CreditCardNumber", SqlDbType.NVarChar).Value = customer.CardNumber;
            customerCommand.Parameters.Add("@CreditCardType", SqlDbType.NVarChar).Value = customer.CardType;
            customerCommand.Parameters.Add("@FuturePromotions", SqlDbType.Bit).Value = customer.FuturePromotions;
            customerCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
        }

        private void AddCommandParametersUsingOrderInfo(SqlCommand orderCommand, CustomerOrder customerOrder)
        {
            orderCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
            orderCommand.Parameters.Add("@Total", SqlDbType.Decimal).Value = customerOrder.Total;
            orderCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = idOfAddedCustomer;
        }

        private void AddCommandParametersUsingOrderLineInfo(SqlCommand orderLineCommand, OrderLine orderLine)
        {
            orderLineCommand.Parameters.Add("@OrderId", SqlDbType.Int).Value = idOfAddedOrder;
            orderLineCommand.Parameters.Add("@MovieId", SqlDbType.Int).Value = orderLine.MovieId;
            orderLineCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = orderLine.Price;
            orderLineCommand.Parameters.Add("@Quantity", SqlDbType.TinyInt).Value = orderLine.Quantity;
        }

        private void CreateOrderLines(DataStagedForDBWrite stagedData, SqlConnection dbConnection, SqlTransaction transaction)
        {
            List<OrderLine> movieOrders = stagedData.MovieOrders;
            foreach (OrderLine movieOrder in movieOrders)
            {
                SqlCommand orderLineCommand = new SqlCommand("AddNewMovieOrder", dbConnection, transaction)
                {
                    CommandType = CommandType.StoredProcedure
                };

                AddCommandParametersUsingOrderLineInfo(orderLineCommand, movieOrder);
                using (orderLineCommand)
                {
                    SqlParameter movieOrderId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    orderLineCommand.Parameters.Add(movieOrderId);
                    orderLineCommand.ExecuteReader();
                }

            }
        }

        private void CreateOrder(DataStagedForDBWrite stagedData, SqlConnection dbConnection, SqlTransaction transaction)
        {
            SqlCommand orderCommand = new SqlCommand("AddNewOrder", dbConnection, transaction)
            {
                CommandType = CommandType.StoredProcedure
            };
            CustomerOrder customerOrder = stagedData.CustomerOrderData;

            AddCommandParametersUsingOrderInfo(orderCommand, customerOrder);
            using (orderCommand)
            {
                SqlParameter orderId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                orderCommand.Parameters.Add(orderId);
                orderCommand.ExecuteReader();
                idOfAddedOrder = Convert.ToInt32(orderId.Value);
            }
        }



        private void CreateCustomer(DataStagedForDBWrite stagedData, SqlConnection dbConnection, SqlTransaction transaction)
        {
            SqlCommand customerCommand = new SqlCommand("AddNewCustomer", dbConnection, transaction)
            {
                CommandType = CommandType.StoredProcedure
            };
            Customer customer = stagedData.CustomerData;
            AddCommandParametersUsingCustomerInfo(customerCommand, customer);
            using (customerCommand)
            {
                SqlParameter customerId = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                customerCommand.Parameters.Add(customerId);
                customerCommand.ExecuteReader();
                idOfAddedCustomer = Convert.ToInt32(customerId.Value);
            }
        }
    }
}

