using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;
namespace DAL
{
    public static class DBManager
    {

        public static readonly string connString = string.Empty;
        static DBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }

        public static usermanager GetByID(int id)
        {
            usermanager theManager = new usermanager();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from usermanager WHERE Id=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    theManager.ID = int.Parse(row["Id"].ToString());
                    theManager.Username = row["Username"].ToString();
                    theManager.Email = row["Email"].ToString();
                    theManager.Role = row["Role"].ToString();
                   
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return theManager;
        }

        public static List<usermanager> GetAllManagers()
        {
            List<usermanager> allManagers = new List<usermanager>();


            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from usermanager";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    usermanager theManager = new usermanager();
                    theManager.ID = int.Parse(row["Id"].ToString());
                    theManager.Username = row["Username"].ToString();
                    theManager.Email = row["Email"].ToString();
                    theManager.Role = row["Role"].ToString();
                    allManagers.Add(theManager);
                }

            }

            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return allManagers;
        }

    }
}
