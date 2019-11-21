using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class WriteMachineBuilder
    {
        public SqlTransaction Transaction;

        public SqlConnection DBConnection;

        public WriteMachine BuildWriteMachine()
        {
            WriteMachine writeMachine = new WriteMachine();

            writeMachine.Mediator = new Mediator();

            writeMachine.CustomerWriter = new CustomerWriter
            {
                Mediator = writeMachine.Mediator,
                DBConnection = DBConnection,
                Transaction = Transaction
            };

            writeMachine.OrderWriter = new OrderWriter
            {
                Mediator = writeMachine.Mediator,
                DBConnection = DBConnection,
                Transaction = Transaction
            };

            writeMachine.OrderLineWriter = new OrderLineWriter
            {
                Mediator = writeMachine.Mediator,
                DBConnection = DBConnection,
                Transaction = Transaction
            };

            writeMachine.Mediator.CustomerWriter = writeMachine.CustomerWriter;
            writeMachine.Mediator.OrderWriter = writeMachine.OrderWriter;
            writeMachine.Mediator.OrderLinesWriter = writeMachine.OrderLineWriter;

            return writeMachine;
        }
    }
}