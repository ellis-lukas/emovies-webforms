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
                    WriteMachineBuilder writeMachineBuilder = new WriteMachineBuilder
                    {
                        Transaction = transaction,
                        DBConnection = dbConnection
                    };

                    WriteMachine writeMachine = writeMachineBuilder.BuildWriteMachine();

                    writeMachine.WriteCustomer(stagedData.CustomerData);
                    writeMachine.WriteOrder(stagedData.CustomerOrderData);
                    foreach(OrderLine orderLine in stagedData.MovieOrders)
                    {
                        writeMachine.WriterOrderLine(orderLine);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}

