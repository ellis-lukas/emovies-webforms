using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emovies.website
{
    public partial class Order : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitOrderClicked(object sender, EventArgs e)
        {
            Session["Name"] = name.Text;
            Session["Email"] = email.Text;
            Session["CardNumber"] = cardNumber.Text;
            Session["CardType"] = cardType.Text;
            Session["FuturePromotions"] = Convert.ToInt32(futurePromotions.Checked);
            Response.Redirect("confirmation.aspx");
        }
    }
}