using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public static class MovieOrderMapper
    {
        public static int GetQuantityFromRepeaterItem(RepeaterItem repeaterItem)
        {
            TextBox quantityCell = (TextBox)repeaterItem.FindControl("quantity");
            int quantity = int.Parse(quantityCell.Text);
            return quantity;
        } 
    }
}