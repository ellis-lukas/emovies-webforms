using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public abstract class TableWriter
    {
        public SqlConnection DBConnection;
        public SqlTransaction Transaction;
        private SqlParameter ReturnParameter;

        public void Write()
        {
            SqlCommand tableWriteCommand = BuildCommand();
            AddStoredProcedure(tableWriteCommand);
            AddCommandParameters(tableWriteCommand);
            AddReturnParameter(tableWriteCommand);
            ExecuteCommand(tableWriteCommand);
        }

        public int GetLastAddedEntryID()
        {
            int lastAddedEntryID = Convert.ToInt32(ReturnParameter.Value);
            return lastAddedEntryID;
        }

        private SqlCommand BuildCommand()
        {
            var command = new SqlCommand();
            command.Connection = DBConnection;
            command.Transaction = Transaction;

            return command;
        }

        private void AddReturnParameter(SqlCommand command)
        {
            ReturnParameter = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };

            command.Parameters.Add(ReturnParameter);
        }

        protected abstract void AddStoredProcedure(SqlCommand command);

        protected abstract void AddCommandParameters(SqlCommand command);

        private void ExecuteCommand(SqlCommand command)
        {
            using (command)
            {
                command.ExecuteReader();
            }
        }
    }
}