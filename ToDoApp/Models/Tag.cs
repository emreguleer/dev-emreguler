using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Tag: BaseModel
    {
        public static bool Add(Tag tag)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tag VALUES (@name, @createdDate,@isDeleted", conn);
            cmd.Parameters.AddWithValue("name", tag.Name);
            cmd.Parameters.AddWithValue("createdDate", tag.CreatedDate);
            cmd.Parameters.AddWithValue("isDeleted", tag.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0? true:false;
        }
        public static bool Delete(Tag tag)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tag WHERE @name=Name", conn);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        public static List<Tag> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tag WHERE IsDeleted = 0", conn);
            conn.Open();
            List<Tag> list = new List<Tag>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Tag
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
                return status;
                conn.Close();
                
            }
            else
            {
                conn.Close();
                return new Status();
            }

        }
        public static bool Update(Tag tag)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Tag SET Name=@name, IsDeleted=@isDeleted,", conn);
            cmd.Parameters.AddWithValue("Name", tag.Name);
            cmd.Parameters.AddWithValue("IsDeleted", tag.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        public 
    }
}
