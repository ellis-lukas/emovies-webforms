using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class WriteMachine
    {
        public CustomerWriter CustomerWriter;

        public OrderWriter OrderWriter;

        public OrderLineWriter OrderLineWriter;

        public Mediator Mediator;

        public void WriteCustomer(Customer customer)
        {
            CustomerWriter.Customer = customer;
            CustomerWriter.Write();
        }

        public void WriteOrder(CustomerOrder order)
        {
            OrderWriter.CustomerOrder = order;
            OrderWriter.Write();
        }

        public void WriterOrderLine(OrderLine orderLine)
        {
            OrderLineWriter.OrderLine = orderLine;
            OrderLineWriter.Write();
        }
    }
}