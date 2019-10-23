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
            new Movie {Name="Movie 1", Price=4.99m},
            new Movie {Name="Movie 2", Price=4.99m},
            new Movie {Name="Movie 3", Price=5.99m},
            new Movie {Name="Movie 4", Price=6.99m},
            new Movie {Name="Movie 5", Price=7.99m},
            new Movie {Name="Movie 6", Price=4.49m},
        };

        private Movie movie1 = new Movie
        {
            Name = "Movie 1",
            Price = 4.99m
        };

        private Movie movie2 = new Movie
        {
            Name = "Movie 2",
            Price = 4.99m
        };

        private Movie movie3 = new Movie
        {
            Name = "Movie 3",
            Price = 5.99m
        };

        private Movie movie4 = new Movie
        {
            Name = "Movie 4",
            Price = 5.99m
        };

        private Movie movie5 = new Movie
        {
            Name = "Movie 5",
            Price = 6.00m
        };

        private Movie movie6 = new Movie
        {
            Name = "Movie 6",
            Price = 12.00m
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            List<Movie> movieList = new List<Movie>();
            movieList.Add(movie1);
            movieList.Add(movie2);
            movieList.Add(movie3);
            movieList.Add(movie4);
            movieList.Add(movie5);
            movieList.Add(movie6);
            Repeater1.DataSource = movieList;
            Repeater1.DataBind();
        }

        protected void SubmitButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("order.aspx");
        }
    }
}