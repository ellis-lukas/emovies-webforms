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
        public void WriteToDB(DataStagedForDBWrite stagedData)
        {
            using (SqlConnection dbConnection = new SqlConnection(@"Server=xena\sql2017;Database=emovies.Lukas;User Id=emovies.Lukas;Password=emovies;MultipleActiveResultSets=True;"))
            {
                dbConnection.Open();

                using (SqlTransaction transaction = dbConnection.BeginTransaction())
                {
                    CustomerWriter customerWriter = new CustomerWriter
                    {
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };

                    OrderWriter orderWriter = new OrderWriter
                    {
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };

                    OrderLineWriter orderLineWriter = new OrderLineWriter
                    {
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };

                    customerWriter.Customer = stagedData.CustomerData;
                    customerWriter.Write();

                    orderWriter.CustomerOrder = stagedData.CustomerOrderData;
                    orderWriter.AddedCustomerID = customerWriter.GetLastAddedEntryID();
                    orderWriter.Write();

                    foreach(OrderLine movieOrder in stagedData.MovieOrders)
                    {
                        orderLineWriter.OrderLine = movieOrder;
                        orderLineWriter.AddedOrderID = orderWriter.GetLastAddedEntryID();
                        orderLineWriter.Write();
                    }

                    transaction.Commit();
                }
            }
        }
    }
}

