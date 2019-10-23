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

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            var movie1 = new Movie
            {
                Name = "Movie 1",
                Price = 4.99m
            };

            var movie2 = new Movie
            {
                Name = "Movie 2",
                Price = 4.99m
            };

            var movie3 = new Movie
            {
                Name = "Movie 3",
                Price = 5.99m
            };

            var movie4 = new Movie
            {
                Name = "Movie 4",
                Price = 5.99m
            };

            var movie5 = new Movie
            {
                Name = "Movie 5",
                Price = 6.00m
            };

            var movie6 = new Movie
            {
                Name = "Movie 6",
                Price = 12.00m
            };

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
    }
}