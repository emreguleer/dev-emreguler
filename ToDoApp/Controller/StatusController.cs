using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Controller
{
    public class StatusController
    {
        public static bool Add(Status status)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Status VALUES (@name, @createdDate,@isDeleted", conn);
            cmd.Parameters.AddWithValue("name", status.Name);
            cmd.Parameters.AddWithValue("createdDate", status.CreatedDate);
            cmd.Parameters.AddWithValue("isDeleted", status.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        public static bool Delete(Status status)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Status WHERE @name=Name", conn);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0? true:false;
        }
        public static List<Status> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Status WHERE IsDeleted = 0", conn);
            conn.Open();
            List<Status> list = new List<Status>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Status
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    CreatedDate = (DateTime)dr["CreatedDate"]
                });
                conn.Close();
                return list;
            }
            conn.Close();
            return list;
        }
        public static Status Find(string searchterm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Status WHERE Name = @searchterm", conn);
            cmd.Parameters.AddWithValue("Name", searchterm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Status status = new Status
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                };
                conn.Close();
                return status;
            }
            else
            {
                conn.Close();
                return new Status();
            }
        }
        public static bool Update(Status status)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Status SET Name=@name, IsDeleted=@isDeleted,", conn);
            cmd.Parameters.AddWithValue("Name", status.Name);
            cmd.Parameters.AddWithValue("IsDeleted", status.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0? true:false;
        }
    }
}
