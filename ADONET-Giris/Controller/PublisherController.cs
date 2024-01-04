using ADONET_Giris.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris.Controller
{
    public static class PublisherController
    {
        public static bool Add(Publisher publisher)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO Publishers (Name,Descriptino) VALUES(@name,@description)", conn);
            cmd.Parameters.AddWithValue("@name", publisher.Name);
            cmd.Parameters.AddWithValue("@description", publisher.Description);
            conn.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows > 0 ? true : false;

        }
        public static Publisher Find(string searchTerm)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM Publishers WHERE Name=@name", conn);
            cmd.Parameters.AddWithValue("name", searchTerm);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                Publisher publisher  = new Publisher
                {
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
                return publisher;

            }
            conn.Close();
            return new Publisher();
        }
    }
}
