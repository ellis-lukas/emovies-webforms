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
        public readonly MovieRepository MovieRepo = new MovieRepository();
        public readonly List<Movie> MovieList;

        private readonly List<OrderMade> OrderMadeList = new List<OrderMade>() {};

        private int GetQuantityFromRepeatedRow(RepeaterItem row)
        {
            TextBox quantityTextBox = (TextBox)(row.FindControl("quantity"));
            int quantity = int.Parse(quantityTextBox.Text);
            return quantity;
        }

        private decimal Total = 0;

        private void FillInOrderListFromMovieTable(RepeaterItemCollection repeaterItems, List<OrderMade> orderList)
        {
            int counter = 0;

            foreach (RepeaterItem item in repeaterItems)
            {
                int _quantity = GetQuantityFromRepeatedRow(item);
                if (_quantity != 0)
                {
                    int _Id = orderList.Count + 1;
                    int _MovieId = MovieList[counter].Id;
                    orderList.Add(new OrderMade { Id = _Id, MovieId = _MovieId, Quantity = _quantity });
                }
                counter++;
            }
        }

        private void CalculateTotal()
        {
            foreach (OrderMade order in OrderMadeList)
            {
                Total += order.Quantity * MovieList[order.MovieId-1].Price;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            if (!Page.IsPostBack)
            {
                Repeater1.DataSource = MovieList;
                Repeater1.DataBind();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            MovieList = MovieRepo.GetMovies();
        }

        protected void OrderNowClicked(object sender, EventArgs e)
        {
            FillInOrderListFromMovieTable(Repeater1.Items);
            CalculateTotal();
            Session["Total"] = Total;
            Session["OrderMade"] = OrderMadeList;
            Response.Redirect("order.aspx");
        }
    }
}