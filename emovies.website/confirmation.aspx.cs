using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website
{
    public partial class Confirmation : Page
    {
        public CustomerInfo VisitorInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            VisitorInfo.fillOutVisitorInfo(Session);
        }
    }
}