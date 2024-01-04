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
        public static Author Find(string searchTerm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) FROM Authors WHERE Name=@name", conn);
            cmd.Parameters.AddWithValue("name", searchTerm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            conn.Close();
            if (dr.HasRows)
            {
                return new Author
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
            }
        }
    }
}
