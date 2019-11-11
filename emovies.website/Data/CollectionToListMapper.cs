using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace emovies.website.Data
{
    public static class MapXCollectionToListOfX
    {
        public static List<RepeaterItem> XisRepeaterItem(RepeaterItemCollection repeaterItemCollection)
        {
            List<RepeaterItem> listOfRepeaterItems = new List<RepeaterItem>();
            foreach (RepeaterItem repeaterItem in repeaterItemCollection)
            {
                listOfRepeaterItems.Add(repeaterItem);
            }
            return listOfRepeaterItems;
        }
    }
}