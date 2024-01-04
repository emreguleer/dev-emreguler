using ADONET_Giris.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlDataReader = Microsoft.Data.SqlClient.SqlDataReader;

namespace ADONET_Giris.Controller
{
    public class CategoryController
    {
        public static bool Add(Category category)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES(@guid, @name, @description, @IsDeleted, @IsActive, @ModifiedDate, @CreatedDate)", conn);
            cmd.Parameters.AddWithValue("guid", category.Guid);
            cmd.Parameters.AddWithValue("name", category.Name);
            cmd.Parameters.AddWithValue("description", category.Description==null?DBNull.Value:category.Description);
            cmd.Parameters.AddWithValue("IsDeleted", category.IsDeleted);
            cmd.Parameters.AddWithValue("IsActive", category.IsActive);
            cmd.Parameters.AddWithValue("Modifieddate", category.ModifiedDate);
            cmd.Parameters.AddWithValue("CreatedDate", category.CreatedDate);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;

        }
        public static bool Delete(Category category)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE Name=@name", conn);
            cmd.Parameters.AddWithValue ("name", category.Name);
            conn.Open ();
            int affectedRows = cmd.ExecuteNonQuery ();
            conn.Close ();
            return affectedRows > 0? true:false;
        }
        public static List<Category> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE IsDeleted=0", conn);
            conn.Open();
            List<Category> list = new List<Category>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Category
                {
                    Id = (int)dr["ID"],
                    Name = (string)dr["Name"],
                    Guid = (Guid)dr["Guid"],
                    Description = (string)dr["Description"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    IsActive = (bool)dr["IsActive"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    ModifiedDate = (DateTime)dr["ModifiedDate"],
                });
                conn.Close ();
                return list;
            }
            return list;
        }
        public static Category Find(string searchTerm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Categories WHERE Name=@searchterm", conn);
            cmd.Parameters.AddWithValue("name", searchTerm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            conn.Close();
            if(dr.HasRows) 
            {
                Category category = new Category
                {
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    ModifiedDate = (DateTime)dr["ModifiedDate"],
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Description = (string)dr["Description"],
                    Guid = (Guid)dr["Guid"],
                    IsActive = (bool)dr["IsActive"],
                    IsDeleted = (bool)dr["IsDeleted"],
                };
                return category;
            }
            else
            {
                return new Category();
            } 
        }
        public static bool Update(Category category)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("UPDATE Categories SET Name=@name,Description=@description, IsDeleted=@IsDeleted, IsActive=@IsActive, ModifiedDate=GETDATE(),WHERE Id=@Id)", conn );
            cmd.Parameters.AddWithValue("name", category.Name);
            cmd.Parameters.AddWithValue("description", category.Description == null ? DBNull.Value : category.Description);
            cmd.Parameters.AddWithValue("isdeleted", category.IsDeleted);
            cmd.Parameters.AddWithValue("isactive", category.IsActive);
            cmd.Parameters.AddWithValue("id", category.Id);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;

        }
    }
}
