using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class ListOfDisplayOrderLineMapper
    {
        public List<DisplayOrderLine> MapFromListOfOrderLine(List<OrderLine> orderLines)
        {
            List<DisplayOrderLine> displayableFormOfOrderLines = new List<DisplayOrderLine>();

            foreach(OrderLine orderLine in orderLines)
            {
                DisplayOrderLine displayableMovieOrder = new DisplayOrderLineMapper().MapFromOrderLine(orderLine);
                displayableFormOfOrderLines.Add(displayableMovieOrder);
            }

            return displayableFormOfOrderLines;
        }
    }
}