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
        public Mediator Mediator;
        public DataStagedForDBWrite StagedData;
        public SqlConnection DBConnection;
        public SqlTransaction Transaction;
        protected SqlParameter ReturnParameter;
        protected int LastAddedEntryID;
        protected SqlCommand Command;

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

        protected void InitialiseCommand()
        {
            Command = new SqlCommand();
        }

        protected void AddDBConnection()
        {
            Command.Connection = DBConnection;
        }

        protected void AddTransaction()
        {
            Command.Transaction = Transaction;
        }

        protected abstract void AddStoredProcedure();

        protected abstract void AddCommandParameters();

        protected void InitialiseReturnParameter()
        {
            ReturnParameter = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            {
                Direction = ParameterDirection.ReturnValue
            };
        }

        protected void AddReturnParameter()
        {
            Command.Parameters.Add(ReturnParameter);
        }

        protected void ExecuteCommand()
        {
            using (Command)
            {
                Command.ExecuteReader();
            }
        }

        protected void SetLastAddedEntryID()
        {
            LastAddedEntryID = Convert.ToInt32(ReturnParameter.Value);
        }

        protected void SendLastAddedIDToMediator()
        {
            Mediator.SendIDToWriter(LastAddedEntryID, this);
        }
    }
}