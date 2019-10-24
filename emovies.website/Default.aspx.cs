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
        private List<Movie> MovieList = new List<Movie>()
        { 
            new Movie {Id=1, Name="Movie 1", Price=4.99m},
            new Movie {Id=2, Name="Movie 2", Price=4.99m},
            new Movie {Id=3, Name="Movie 3", Price=5.99m},
            new Movie {Id=4, Name="Movie 4", Price=6.99m},
            new Movie {Id=5, Name="Movie 5", Price=7.99m},
            new Movie {Id=6, Name="Movie 6", Price=4.49m}
        };

        private List<OrderMade> OrderMadeList = new List<OrderMade>() {};

        private int GetQuantityFromItem(RepeaterItem item)
        {
            TextBox quantityBox = (TextBox)item.FindControl("quantity");
            int quantity = int.Parse(quantityBox.Text);
            return quantity;
        }

        private decimal Total = 0;

        private void WriteOrderList()
        {
            int counter = 0;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                int _quantity = GetQuantityFromItem(item);
                if (_quantity != 0)
                {
                    int _Id = OrderMadeList.Count + 1;
                    int _MovieId = MovieList[counter].Id;
                    OrderMadeList.Add(new OrderMade { Id = _Id, MovieId = _MovieId, Quantity = _quantity });
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

        protected void OrderNowClicked(object sender, EventArgs e)
        {
            WriteOrderList();
            CalculateTotal();
            Session["Total"] = Total;
            Session["OrderMade"] = OrderMadeList;
            Response.Redirect("order.aspx");
        }
    }
}