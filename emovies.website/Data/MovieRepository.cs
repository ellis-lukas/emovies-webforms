using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emovies.website.Data
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
    }

    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Name = "Movie 1",
                    Price = 4.99m
                },
                new Movie
                {

                }
            };
        }
    }

    public class MovieDatabaseRepository : IMovieRepository
    {
        public List<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }
    }
}