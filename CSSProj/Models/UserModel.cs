using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CSSProj.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        string conString = ConfigurationManager.ConnectionStrings["CSSConnection"].ConnectionString;

        public List<UserModel> GetUsers()
        {
            List<UserModel> list = new List<UserModel>();
            
            //create connection
            
            SqlConnection con = new SqlConnection(conString);
            ////command
            //SqlCommand cmd = new SqlCommand("Select * From [User]", con);
            ////execute
            ////open connection
            //con.Open();
            //// execute command
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    UserModel um = new UserModel();
            //    um.Id = Convert.ToInt32(dr["Id"].ToString());
            //    um.UserCode = dr["UserCode"].ToString();
            //    um.UserName = dr["UserName"].ToString();
            //    um.Password = dr["Password"].ToString();
            //    //add to the list
            //    list.Add(um);
            //}
            //// close connection
            //con.Close();

            //using Data Adaper disconnected mode
            SqlDataAdapter da = new SqlDataAdapter("Select * From [User]", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "UserTable");
            for (int i = 0; i < ds.Tables["UserTable"].Rows.Count; i++)
            {
                UserModel um = new UserModel();
                um.Id = Convert.ToInt32(ds.Tables["UserTable"].Rows[i][0].ToString());
                um.UserCode = ds.Tables["UserTable"].Rows[i]["UserCode"].ToString();
                um.UserName = ds.Tables["UserTable"].Rows[i]["UserName"].ToString();
                um.Password = ds.Tables["UserTable"].Rows[i]["Password"].ToString();
                list.Add(um);
            }

            return list;
        }

        internal void UpdateUser(UserModel um, int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conString;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE [User] SET usercode = @usercode, username = @username, password = @password " +
                                      "WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@usercode", um.UserCode);
                    cmd.Parameters.AddWithValue("@username", um.UserName);
                    cmd.Parameters.AddWithValue("@password", um.Password);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void RemoverUser(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conString;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM [User] " +
                                      "WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddUser(UserModel um)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conString;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO [dbo].[User]( [UserCode] , [UserName] ,[PASSWORD])" +
                                      "VALUES(@usercode, @username, @password)";
                    cmd.Parameters.AddWithValue("@usercode", um.UserCode);
                    cmd.Parameters.AddWithValue("@username", um.UserName);
                    cmd.Parameters.AddWithValue("@password", um.Password);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UserModel GetUserById(int id)
        {
            UserModel um = new UserModel();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["CSSConnection"].ConnectionString;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from [User] where Id = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        um.Id = Convert.ToInt32(reader["Id"].ToString());
                        um.UserCode = reader["UserCode"].ToString();
                        um.UserName = reader["UserName"].ToString();
                        um.Password = reader["Password"].ToString();
                    }
                }
            }
            return um;
        }
    }
}