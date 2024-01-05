using Azure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Controller
{
    public class PriorityController
    {
        public static bool Add(Priority priority)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Priority VALUES (@name, @createdDate,@isDeleted", conn);
            cmd.Parameters.AddWithValue("name", priority.Name);
            cmd.Parameters.AddWithValue("createdDate", priority.CreatedDate);
            cmd.Parameters.AddWithValue("isDeleted", priority.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        public static bool Delete(Priority priority)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Priority WHERE @name=Name", conn);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        public static List<Priority> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Priority WHERE IsDeleted = 0", conn);
            conn.Open();
            List<Priority> list = new List<Priority>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Priority
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
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Priority WHERE Name = @searchterm", conn);
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
        public static bool Update(Priority priority)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Priority SET Name=@name, IsDeleted=@isDeleted,", conn);
            cmd.Parameters.AddWithValue("Name", priority.Name);
            cmd.Parameters.AddWithValue("IsDeleted", priority.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
    }
}
