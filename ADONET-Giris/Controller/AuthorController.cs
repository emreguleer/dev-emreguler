using ADONET_Giris.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris.Controller
{
    public static  class AuthorController
    {

        public static bool Add(Author author)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Authors (Name,Descriptino) VALUES(@name,@description)", conn);
            cmd.Parameters.AddWithValue("@name", author.Name);
            cmd.Parameters.AddWithValue("@description", author.Description);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;

        }
        public static Author Find(string searchTerm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Authors WHERE Name=@name", conn);
            cmd.Parameters.AddWithValue("name", searchTerm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            
            if (dr.HasRows)
            {
                Author author = new Author
                {
                    Biography = (string)dr["Biography"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    ModifiedDate = (DateTime)dr["ModifiedDate"],
                    Description = (string)dr["Description"],
                    Guid = (Guid)dr["Guid"],
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    IsActive = (bool)dr["IsActive"],
                    IsDeleted = (bool)dr["IsDeleted"],
                };
                conn.Close();
                return author;
                
            }
            conn.Close();
            return new Author();
        }
    }
}
