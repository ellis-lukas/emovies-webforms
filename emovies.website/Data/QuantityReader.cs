using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public interface IQuantityReader
    {
        List<int> GetQuantityList();
    }

    public class QuantityReader : IQuantityReader
    {
        private List<int> quantityList;

        public QuantityReader(RepeaterItemCollection returnedMovieTable)
        {
            quantityList = ListFromRepeaterItemCollection(returnedMovieTable);
        }

        private List<int> ListFromRepeaterItemCollection(RepeaterItemCollection returnedMovieTable)
        {
            List<int> quantityList = new List<int>();
            foreach(RepeaterItem repeaterItem in returnedMovieTable)
            {
                quantityList.Add(GetQuantityFromRepeaterItem(repeaterItem));
            }
            return quantityList;
        }

        private int GetQuantityFromRepeaterItem(RepeaterItem repeaterItem)
        {
            TextBox quantityCell = (TextBox)repeaterItem.FindControl("quantityCell");
            int quantity = int.Parse(quantityCell.Text);
            return quantity;
        }

        public List<int> GetQuantityList()
        {
            return quantityList;
        }
    }
}