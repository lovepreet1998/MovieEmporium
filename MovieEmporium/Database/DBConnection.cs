using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieEmporium.Database
{
    public class DBConnection
    {
        private string dbstring = @"Data Source=DESKTOP-3C0DRCK\SQLEXPRESS;Initial Catalog=movie_emporium;Integrated Security=True;";
        private string masterstring = @"Data Source=DESKTOP-3C0DRCK\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        protected SqlConnection conn;

        public DBConnection()
        {
            if (!IsDatabaseExists())
            {
                RestoreFromBackup();
                MessageBox.Show("Backup is Restored.. Re-run the application agains.");
                Application.Exit();
                return;
            }
            conn = new SqlConnection(dbstring);
            conn.Open();
        }

        private void RestoreFromBackup()
        {
            SqlConnection cn;
            SqlCommand cm;
            try
            {
                string script = null;
                script = MovieEmporium.Properties.Resources.scripts;
                string[] ScriptSplitter = script.Split(new string[] { "GO" }, StringSplitOptions.None);
                using (cn = new SqlConnection(masterstring))
                {
                    cn.Open();
                    foreach (string str in ScriptSplitter)
                    {
                        using (cm = cn.CreateCommand())
                        {
                            cm.CommandText = str;
                            cm.ExecuteNonQuery();
                        }
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private bool IsDatabaseExists()
        {
            SqlConnection con = new SqlConnection(dbstring);
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ConnectionStatus()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        public void CloseConnection()
        {
            if (ConnectionStatus())
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public bool ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet ExecuteQueryForDataSet(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        public DataSet ExecuteQueryForDataSet(string query, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }

        public DataTable ExecuteQueryForDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataSet ExecuteSelectProcedure(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
    }
}
