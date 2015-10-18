using System;
using System.Collections.Generic;
using System.Configuration;
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

        public List<UserModel> GetUsers()
        {
            List<UserModel> list = new List<UserModel>();
            
            //create connection
            string conString = ConfigurationManager.ConnectionStrings["CSSConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            //command
            SqlCommand cmd = new SqlCommand("Select * From [User]", con);
            //execute
            //open connection
            con.Open();
            // execute command
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UserModel um = new UserModel();
                um.Id = Convert.ToInt32(dr["Id"].ToString());
                um.UserCode = dr["UserCode"].ToString();
                um.UserName = dr["UserName"].ToString();
                um.Password = dr["Password"].ToString();
                //add to the list
                list.Add(um);
            }
            // close connection
            con.Close();
            return list;
        }
    }
}