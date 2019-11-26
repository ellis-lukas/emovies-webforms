using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public interface IQuantityExtractor
    {
        List<int> ExtractQuantityList();
    }

    public class QuantityExtractor : IQuantityExtractor
    {
        private readonly RepeaterItemCollection ReturnedMovieTable;

        public QuantityExtractor(RepeaterItemCollection returnedMovieTable)
        {
            ReturnedMovieTable = returnedMovieTable;
        }

        public List<int> ExtractQuantityList()
        {
            List<int> quantityList = ListFromRepeaterItemCollection(ReturnedMovieTable);
            return quantityList;
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
    }
}