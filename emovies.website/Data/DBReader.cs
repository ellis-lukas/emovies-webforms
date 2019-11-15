using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace emovies.website.Data
{
    public class DBReader
    {
        public List<Movie> GetMovies()
        {
            string connStr = @"Server=xena\sql2017;Database=emovies.Lukas;User Id=emovies.Lukas;Password=emovies;";
            using (SqlConnection dbConnection = new SqlConnection(connStr))
            {
                List<Movie> currentMovies = new List<Movie>();

                dbConnection.Open();

                currentMovies = LoadInMoviesFromDB(dbConnection);

                return currentMovies;
            }
        }

        private List<Movie> LoadInMoviesFromDB(SqlConnection conn)
        {
            List<Movie> currentMovies;
            using (SqlCommand readCommand = new SqlCommand("ReadMovie", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                currentMovies = CreateListOfMoviesFromDBMovies(readCommand);
            }

            return currentMovies;
        }

        private List<Movie> CreateListOfMoviesFromDBMovies(SqlCommand readCommand)
        {
            List<Movie> currentMovies = new List<Movie>();
            using (SqlDataReader reader = readCommand.ExecuteReader())
            {
                using (readCommand)
                {
                    while (reader.Read())
                    {
                        Movie movieRead = new Movie
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            Price = decimal.Parse(reader["Price"].ToString())
                        };
                        currentMovies.Add(movieRead);
                    }
                }
            }
            return currentMovies;
        }
    }
}