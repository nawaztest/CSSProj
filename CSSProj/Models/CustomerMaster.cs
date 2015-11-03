using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSSProj.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; } 
        public string CustomerName { get; set; }
        public string ContactPersonName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string CustomerType { get; set; }
        public string InstallationDate { get; set; }
        public string ExpiryDate { get; set; }
        public List<SelectListItem> listMoveTo { get; set; }

        public string cnnstring = ConfigurationManager.ConnectionStrings["CSSConnection"].ConnectionString;
        public List<CustomerModel> GetAllCusts()
        {
            List<CustomerModel> custs = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = cnnstring;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM [dbo].[CustomerMaster]", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "CustTab");

                for(int i = 0; i < ds.Tables["CustTab"].Rows.Count; i++)
                {
                    CustomerModel cm = new CustomerModel();
                    cm.Id = Convert.ToInt32(ds.Tables["CustTab"].Rows[i]["Id"].ToString());
                    cm.CustomerCode = ds.Tables["CustTab"].Rows[i]["CustomerCode"].ToString();
                    cm.CustomerName = ds.Tables["CustTab"].Rows[i]["CustomerName"].ToString();
                    cm.ContactPersonName = ds.Tables["CustTab"].Rows[i]["ContactPersonName"].ToString();
                    cm.AddressLine1 = ds.Tables["CustTab"].Rows[i]["AddressLine1"].ToString();
                    cm.AddressLine2 = ds.Tables["CustTab"].Rows[i]["AddressLine2"].ToString();
                    cm.AddressLine3 = ds.Tables["CustTab"].Rows[i]["AddressLine3"].ToString();
                    cm.Telephone1 = ds.Tables["CustTab"].Rows[i]["Telephone1"].ToString();
                    cm.Telephone2 = ds.Tables["CustTab"].Rows[i]["Telephone2"].ToString();
                    cm.CountryCode = ds.Tables["CustTab"].Rows[i]["CountryCode"].ToString();
                    cm.CountryName = ds.Tables["CustTab"].Rows[i]["CountryName"].ToString();
                    cm.Fax1 = ds.Tables["CustTab"].Rows[i]["Fax1"].ToString();
                    cm.Fax2 = ds.Tables["CustTab"].Rows[i]["Fax2"].ToString();
                    cm.Email = ds.Tables["CustTab"].Rows[i]["Email"].ToString();
                    cm.Remarks = ds.Tables["CustTab"].Rows[i]["Remarks"].ToString();
                    cm.CustomerType = ds.Tables["CustTab"].Rows[i]["CustomerType"].ToString();
                    cm.InstallationDate = ds.Tables["CustTab"].Rows[i]["InstallationDate"].ToString();
                    cm.ExpiryDate = ds.Tables["CustTab"].Rows[i]["ExpiryDate"].ToString();
                    custs.Add(cm);
                }

                return custs;
            }
        }

        public void AddCust(CustomerModel cm)
        {
            using (SqlConnection conn = new SqlConnection(cnnstring))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AddCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerCode", cm.CustomerCode);
                    cmd.Parameters.AddWithValue("@CustomerName", cm.CustomerName);
                    cmd.Parameters.AddWithValue("@ContactPersonName", cm.ContactPersonName);
                    cmd.Parameters.AddWithValue("@AddressLine1", cm.AddressLine1);
                    cmd.Parameters.AddWithValue("@AddressLine2", cm.AddressLine2);
                    cmd.Parameters.AddWithValue("@AddressLine3", cm.AddressLine3);
                    cmd.Parameters.AddWithValue("@Telephone1", cm.Telephone1);
                    cmd.Parameters.AddWithValue("@Telephone2", cm.Telephone2);
                    cmd.Parameters.AddWithValue("@CountryCode", cm.CountryCode);
                    cmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
                    cmd.Parameters.AddWithValue("@Fax1", cm.Fax1);
                    cmd.Parameters.AddWithValue("@Fax2", cm.Fax2);
                    cmd.Parameters.AddWithValue("@Email", cm.Email);
                    cmd.Parameters.AddWithValue("@Remarks", cm.Remarks);
                    cmd.Parameters.AddWithValue("@CustomerType", cm.CustomerType);
                    cmd.Parameters.AddWithValue("@InstallationDate", cm.InstallationDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", cm.ExpiryDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public CustomerModel GetCustomerById(int id)
        {
            CustomerModel cm = new CustomerModel();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = cnnstring;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM [dbo].[CustomerMaster] where Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        cm.CustomerCode = rdr["CustomerCode"].ToString();
                        cm.CustomerName = rdr["CustomerName"].ToString();
                        cm.ContactPersonName = rdr["ContactPersonName"].ToString();
                        cm.AddressLine1 = rdr["AddressLine1"].ToString();
                        cm.AddressLine2 = rdr["AddressLine2"].ToString();
                        cm.AddressLine3 = rdr["AddressLine3"].ToString();
                        cm.Telephone1 = rdr["Telephone1"].ToString();
                        cm.Telephone2 = rdr["Telephone2"].ToString();
                        cm.CountryCode = rdr["CountryCode"].ToString();
                        cm.CountryName = rdr["CountryName"].ToString();
                        cm.Fax1 = rdr["Fax1"].ToString();
                        cm.Fax2 = rdr["Fax2"].ToString();
                        cm.Email = rdr["Email"].ToString();
                        cm.Remarks = rdr["Remarks"].ToString();
                        cm.CustomerType = rdr["CustomerType"].ToString();
                        cm.InstallationDate = rdr["InstallationDate"].ToString();
                        cm.ExpiryDate = rdr["ExpiryDate"].ToString();
                        
                    }
                }
            }

            return cm;
        }

        public void UpdateCustByID(CustomerModel cm, int id)
        {
            using (SqlConnection conn = new SqlConnection(cnnstring))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UpdateCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@CustomerCode", cm.CustomerCode);
                    cmd.Parameters.AddWithValue("@CustomerName", cm.CustomerName);
                    cmd.Parameters.AddWithValue("@ContactPersonName", cm.ContactPersonName);
                    cmd.Parameters.AddWithValue("@AddressLine1", cm.AddressLine1);
                    cmd.Parameters.AddWithValue("@AddressLine2", cm.AddressLine2);
                    cmd.Parameters.AddWithValue("@AddressLine3", cm.AddressLine3);
                    cmd.Parameters.AddWithValue("@Telephone1", cm.Telephone1);
                    cmd.Parameters.AddWithValue("@Telephone2", cm.Telephone2);
                    cmd.Parameters.AddWithValue("@CountryCode", cm.CountryCode);
                    cmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
                    cmd.Parameters.AddWithValue("@Fax1", cm.Fax1);
                    cmd.Parameters.AddWithValue("@Fax2", cm.Fax2);
                    cmd.Parameters.AddWithValue("@Email", cm.Email);
                    cmd.Parameters.AddWithValue("@Remarks", cm.Remarks);
                    cmd.Parameters.AddWithValue("@CustomerType", cm.CustomerType);
                    cmd.Parameters.AddWithValue("@InstallationDate", cm.InstallationDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", cm.ExpiryDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


    public class MoveToModel
    {
        public string MoveTo { get; set; }
    }
}