using MovieDictionaryDAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDictionaryDAL
{
    public class MovieRepository
    {
        private SqlConnection _conObj = null;
        private SqlDataAdapter _adapter = null;
        private DataSet _dataSet = null;

        public List<Movie> getAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                string query = "SELECT * FROM Movies";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Movie movie = new Movie
                            {
                                MovieID = Convert.ToInt32(reader["MovieID"]),
                                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                                MovieName = reader["MovieName"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Stars = Convert.ToInt32(reader["Stars"]),
                                Comments = reader["Comments"].ToString()
                            };
                            movies.Add(movie);
                        }
                    }
                }
            }
            return movies;
        }
       public int addNewMovie(Movie movie)
        {
            using(_conObj = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using(_adapter = new SqlDataAdapter("select * from Movies", _conObj))
                {
                    using(DataTable dt = new DataTable())
                    {
                        _adapter.Fill(dt);
                        SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);
                        _adapter.InsertCommand = builder.GetInsertCommand();
                        DataRow dataRow = dt.NewRow();
                        dataRow[0] = movie.MovieID;
                        dataRow[1] = movie.ReleaseDate;
                        dataRow[2] = movie.MovieName.ToString();
                        dataRow[3] = movie.Genre.ToString();
                        dataRow[4] = movie.Stars;
                        dataRow[5] = movie.Comments.ToString();
                        dt.Rows.Add(dataRow);
                        return _adapter.Update(dt) > 0 ? 1 : 0;
                    }
                }
            }
        }

        public int UpdateMovieRating(string MovieName, int rat)
        {
            using(_conObj = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using(_adapter = new SqlDataAdapter("select * from Movies", _conObj))
                {
                    SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(_adapter);
                    using (DataTable dt = new DataTable())
                    {
                        _adapter.Fill(dt);
                        dt.PrimaryKey = new DataColumn[1]
                        {
                           dt.Columns["MovieName"]
                        };
                        DataRow dr = dt.Rows.Find(MovieName);
                        if(dr!=null)
                        {
                            dr.BeginEdit();
                            dr["Stars"] = rat;
                            dr.EndEdit();
                            _adapter.Update(dt);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
        public int deleteMovie(string MovieName)
        {
            using (_conObj = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_adapter = new SqlDataAdapter("select * from Movies", _conObj))
                {
                    SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(_adapter);
                    using (DataTable dt = new DataTable())
                    {
                        _adapter.Fill(dt);
                        dt.PrimaryKey = new DataColumn[1]
                        {
                           dt.Columns["MovieName"]
                        };
                        DataRow dr = dt.Rows.Find(MovieName);
                        if (dr != null)
                        {
                            dr.Delete();
                            _adapter.Update(dt);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
