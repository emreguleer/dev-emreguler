using ADONET_Giris.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris.Controller
{
    public static class ShelfController
    {
        public static bool Add(Shelf shelf)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Shelves (Name,Descriptino) VALUES(@name,@description)", conn);
            cmd.Parameters.AddWithValue("@name", shelf.Name);
            cmd.Parameters.AddWithValue("@description", shelf.Description);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0? true:false;
            
        }
        public static Shelf Find(string searchTerm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Shelves WHERE Name=@searchTerm", conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            conn.Close();
            if(dr.HasRows)
            {
                Shelf shelf = new Shelf
                {
                    Id = (int)dr["ID"],
                    Name = (string)dr["Name"],
                    Guid = (Guid)dr["Guid"],
                    Description = (string)dr["Description"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    IsActive = (bool)dr["IsActive"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    ModifiedDate = (DateTime)dr["ModifiedDate"],
                };
                return shelf;
            }
            else
            {
                return new Shelf();
            }
        }
    }
}
