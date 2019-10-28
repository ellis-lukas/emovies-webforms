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
            new Movie {Id=1, Name="Movie 1", Price=4.99m},
            new Movie {Id=2, Name="Movie 2", Price=4.99m},
            new Movie {Id=3, Name="Movie 3", Price=5.99m},
            new Movie {Id=4, Name="Movie 4", Price=6.99m},
            new Movie {Id=5, Name="Movie 5", Price=7.99m},
            new Movie {Id=6, Name="Movie 6", Price=4.49m}
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