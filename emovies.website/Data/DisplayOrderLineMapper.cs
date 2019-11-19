using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public class DisplayOrderLineMapper
    {
        public DisplayOrderLine MapFromOrderLine(OrderLine orderLine)
        {
            return new DisplayOrderLine
            {
                Name = GetMovieName(orderLine),
                Price = orderLine.Price,
                Quantity = orderLine.Quantity,
                Total = new TotalMapper().MapTotal(orderLine)
            };
        }

        private string GetMovieName(OrderLine orderLine)
        {
            Movie movieToGet = GetMovie(orderLine.MovieId);
            string movieName = movieToGet.Name;
            return movieName;
        }

        private Movie GetMovie(int requestedMovieID)
        {
            MovieRepository movieRepository = MovieRepository.GetInstance();
            List<Movie> currentMovies = movieRepository.GetMovies();
            Movie requestedMovie = currentMovies.Find(movie => movie.Id == requestedMovieID);
            return requestedMovie;
        }
    }
}