using ADONET_Giris.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris.Controller
{
    public static class BookController
    {
        public static bool Add(Book book)
        {
            // INSERT INTO BOOKS (c1,c2,c3) OUTPUT inserted.id VALUES (c1,c2,c3)
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO BOOKS (Name,Description,PageCount,ISBN,ShelfId) OUTPUT inserted.Id VALUES (@name, @description,@pageCount,@isbn,@shelfId", conn);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@", book.Name);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@name", book.Name);
        }
    }
}
