using emovies.website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace emovies.website
{
    public partial class Default : Page
    {
        //public List<Movie> MovieList = new MovieRepository().GetMovies();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["MovieList"] = new MovieRepository().GetMovies();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                Repeater1.DataSource = (List<Movie>)Session["MovieList"];
                Repeater1.DataBind();
            }
        }

        protected void OrderNowClicked(object sender, EventArgs e)
        {
            List<OrderMade> OrderMadeList = new List<OrderMade>().PopulateOrderListFromMovieTable(Repeater1.Items, (List<Movie>)Session["MovieList"]);
            Session["Total"] = OrderMadeList.Total((List<Movie>)Session["MovieList"]);
            Session["OrderMade"] = OrderMadeList;
            Response.Redirect("order.aspx");
        }
    }
}