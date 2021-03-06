﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace emovies.website.Data
{

    public class MovieRepository
    {
        private MovieRepository() { }

        private static MovieRepository _instance;

        private static readonly object _lock = new object();

        public static MovieRepository GetInstance()
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new MovieRepository
                        {
                            Movies = new DBReader().GetMovies()
                        };
                    }
                }

            }
            return _instance;
        }

        private List<Movie> Movies;

        public List<Movie> GetMovies()
        {
            return Movies;
        }
    }
}