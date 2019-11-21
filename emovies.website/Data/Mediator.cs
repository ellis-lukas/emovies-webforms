using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class Mediator : IMediator
    {
        private CustomerWriter _CustomerWriter;

        private OrderWriter _OrderWriter;

        private OrderLineWriter _OrderLinesWriter;

        public CustomerWriter CustomerWriter
        {
            set { _CustomerWriter = value; }
        }

        public OrderWriter OrderWriter
        {
            set { _OrderWriter = value; }
        }

        public OrderLineWriter OrderLinesWriter
        {
            set { _OrderLinesWriter = value; }
        }

        public void SendIDToWriter(int ID, TableWriter tableWriter)
        {
            if (tableWriter == _CustomerWriter)
            {
                _OrderWriter.AddedCustomerID = ID;
            } 
            else if (tableWriter == _OrderWriter) 
            {
                _OrderLinesWriter.AddedOrderID = ID;
            } 
        }
    }
}