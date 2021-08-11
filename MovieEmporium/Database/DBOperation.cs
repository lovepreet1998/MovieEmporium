using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEmporium.Database
{
    public class DBOperation:DBConnection
    {
        public bool InsertGenre(string genre_name)
        {
            string query = "insert into genre(genre_name) values(@genre_name)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@genre_name", genre_name);
            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateGenre(int genre_id, string genre_name)
        {
            string query = "update genre set genre_name=@genre_name where genre_id = @genre_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@genre_name", genre_name);
            parameters.Add("@genre_id", genre_id);
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteGenre(int genre_id)
        {
            string query = "delete from genre where genre_id = @genre_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@genre_id", genre_id);
            return ExecuteNonQuery(query, parameters);
        }

        public DataSet GetAllGenres()
        {
            string query = "select * from genre";
            return ExecuteQueryForDataSet(query);
        }

        public DataTable GetGenres()
        {
            
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from genre";
                dt = ExecuteQueryForDataTable(query);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Genre" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public bool InsertMovie(string title, float rating, int release_year, int genre_id, float rental_cost)
        {
            string query = "insert into movie(title,rating,release_year,genre_id,rental_cost) values(@title,@rating,@release_year,@genre_id,@rental_cost)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@title", title);
            parameters.Add("@rating", rating);
            parameters.Add("@release_year", release_year);
            parameters.Add("@genre_id", genre_id);
            parameters.Add("@rental_cost", rental_cost);
            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateMovie(int movie_id, string title, float rating, int release_year, int genre_id, float rental_cost)
        {
            string query = "update movie set title=@title,rating=@rating,release_year=@release_year,genre_id=@genre_id,rental_cost=@rental_cost where movie_id = @movie_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@title", title);
            parameters.Add("@rating", rating);
            parameters.Add("@release_year", release_year);
            parameters.Add("@genre_id", genre_id);
            parameters.Add("@rental_cost", rental_cost);
            parameters.Add("@movie_id", movie_id);
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteMovie(int movie_id)
        {
            string query = "delete from movie where movie_id = @movie_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@movie_id", movie_id);
            return ExecuteNonQuery(query, parameters);
        }

        public DataSet GetAllMovies()
        {
            string query = "select movie_id,title,rating,rental_cost,release_year,copies,genre_name from movie m join genre g ";
            query += " on m.genre_id = g.genre_id";
            return ExecuteQueryForDataSet(query);
        }

        public int GetGenreIDUsingMovieID(int movie_id)
        {
            int genre_id = 0;
            try
            {
                string query = "select genre_id from movie where movie_id = @movie_id";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@movie_id", movie_id);
                DataSet ds = ExecuteQueryForDataSet(query, parameters);
                genre_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
            }
            return genre_id;
        }
        
        public float GetMovieRent(int movie_id)
        {
            float rental_cost = 0;
            try
            {
                string query = "select rental_cost from movie where movie_id = @movie_id";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@movie_id", movie_id);
                DataSet ds = ExecuteQueryForDataSet(query, parameters);
                rental_cost = float.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
            }
            return rental_cost;
        }

        public bool InsertCustomer(string first_name, string last_name, string address, string phone_no)
        {
            string query = "insert into customer(first_name,last_name,address,phone_no) values(@first_name,@last_name,@address,@phone_no)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@first_name", first_name);
            parameters.Add("@last_name", last_name);
            parameters.Add("@address", address);
            parameters.Add("@phone_no", phone_no);
            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateCustomer(int cust_id, string first_name, string last_name, string address, string phone_no)
        {
            string query = "update customer set first_name=@first_name,last_name=@last_name,address=@address,phone_no=@phone_no  where cust_id = @cust_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@first_name", first_name);
            parameters.Add("@last_name", last_name);
            parameters.Add("@address", address);
            parameters.Add("@phone_no", phone_no);
            parameters.Add("@cust_id", cust_id);
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteCustomer(int cust_id)
        {
            string query = "delete from customer where cust_id = @cust_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cust_id", cust_id);
            return ExecuteNonQuery(query, parameters);
        }

        public DataSet GetAllCustomer()
        {
            return ExecuteQueryForDataSet("select * from customer");
        }

        public DataTable ViewAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from DisplayAllCustomer ";
                dt = ExecuteQueryForDataTable(query);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Customer" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable ViewAllMovie()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from DisplayAllMovie ";
                dt = ExecuteQueryForDataTable(query);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Movie" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public bool IssueMovieToCustomer(int movie_id, int cust_id, float rented_cost, DateTime date_rented)
        {
            string query = "insert into movie_rent_details(movie_id,cust_id,rented_cost,date_rented,date_returned) values(@movie_id,@cust_id,@rented_cost,@date_rented,null)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@movie_id", movie_id);
            parameters.Add("@cust_id", cust_id);
            parameters.Add("@rented_cost", rented_cost);
            parameters.Add("@date_rented", date_rented);
            return ExecuteNonQuery(query, parameters);
        }

        public DataSet GetRentedMovieDetails()
        {
            return ExecuteSelectProcedure("ShowRentedMovies");
        }

        public DataSet GetRentedOutMovieDetails()
        {
            return ExecuteSelectProcedure("ShowRentedOutMovies");
        }

        public bool ReturnMovie(int movie_rent_id, DateTime date_returned)
        {
            string query = "update movie_rent_details set date_returned = @date_returned where movie_rent_id = @movie_rent_id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@date_returned", date_returned);
            parameters.Add("@movie_rent_id", movie_rent_id);
            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteRentedDetails(int movie_rent_id)
        {
            string query = "delete from movie_rent_details where movie_rent_id = @movie_rent_id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@movie_rent_id", movie_rent_id);
            return ExecuteNonQuery(query, parameters);
        }
    }
}
