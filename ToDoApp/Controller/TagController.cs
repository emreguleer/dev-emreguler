using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Controller
{
    public class TagController
    {
        public static bool Add(Tag tag)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tag VALUES (@name, @createdDate,@isDeleted)", conn);
            cmd.Parameters.AddWithValue("name", tag.Name);
            cmd.Parameters.AddWithValue("createdDate", tag.CreatedDate);
            cmd.Parameters.AddWithValue("isDeleted", tag.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
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
            List<Tag> list = new List<Tag>();
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tag WHERE IsDeleted = 0", conn);
            conn.Open();
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
        public static Tag FindById(int id)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tag WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Tag tag = new Tag
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                };
                conn.Close();
                return tag;
            }
            else
            {
                conn.Close();
                return new Tag();
            }
        }
        public static Tag Find(string searchterm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Tag WHERE Name = @searchterm", conn);
            cmd.Parameters.AddWithValue("Name", searchterm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Tag status = new Tag
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
                return new Tag();
            }

        }
        public static bool Update(Tag tag)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Tag SET Name=@name, IsDeleted=@isDeleted WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("id", tag.Id);
            cmd.Parameters.AddWithValue("Name", tag.Name);
            cmd.Parameters.AddWithValue("IsDeleted", tag.IsDeleted);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;
        }
        
    }
}
