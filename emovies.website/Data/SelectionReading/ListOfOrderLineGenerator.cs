using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public class ListOfOrderLineGenerator
    {
        private List<int> QuantityList;

        private List<Movie> CurrentMoviesInRenderedOrder;

        public ListOfOrderLineGenerator(List<int> quantityList, List<Movie> currentMoviesInRenderedOrder)
        {
            QuantityList = quantityList;
            CurrentMoviesInRenderedOrder = currentMoviesInRenderedOrder;
        }

        public List<OrderLine> GenerateOrderLines()
        {
            return ExtractNonZeroOrders(LinkDataToCreateListTypeOrderLine());
        }

        private List<OrderLine> LinkDataToCreateListTypeOrderLine()
        {
            List<OrderLine> MoviesOrdered = new List<OrderLine>();
            for (int i = 0; i < CurrentMoviesInRenderedOrder.Count; i++)
            {
                MoviesOrdered.Add(new OrderLine
                {
                    MovieId = CurrentMoviesInRenderedOrder[i].Id,
                    MovieName = CurrentMoviesInRenderedOrder[i].Name,
                    Price = CurrentMoviesInRenderedOrder[i].Price,
                    Quantity = QuantityList[i],
                    Total = QuantityList[i] * CurrentMoviesInRenderedOrder[i].Price
                });
            }
            return MoviesOrdered;
        }

        private List<OrderLine> ExtractNonZeroOrders (List<OrderLine> orderLinesZeroQuantInc)
        {
            List<OrderLine> nonZeroOrderLines = new List<OrderLine>();
            foreach (OrderLine orderLine in orderLinesZeroQuantInc)
            {
                if (orderLine.Quantity > 0)
                {
                    nonZeroOrderLines.Add(orderLine);
                }
            }
            return nonZeroOrderLines;
        }
    }
}