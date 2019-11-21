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
                    Mediator mediator = new Mediator();

                    CustomerWriter customerWriter = new CustomerWriter
                    {
                        Mediator = mediator,
                        StagedData = stagedData,
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };

                    OrderWriter orderWriter = new OrderWriter
                    {
                        Mediator = mediator,
                        StagedData = stagedData,
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };
                    
                    OrderLinesWriter orderLinesWriter = new OrderLinesWriter
                    {
                        Mediator = mediator,
                        StagedData = stagedData,
                        DBConnection = dbConnection,
                        Transaction = transaction
                    };

                    mediator.CustomerWriter = customerWriter;
                    mediator.OrderWriter = orderWriter;
                    mediator.OrderLinesWriter = orderLinesWriter;

                    customerWriter.Write();
                    orderWriter.Write();
                    orderLinesWriter.Write();

                    transaction.Commit();
                }
            }
        }
    }
}

