using ADONET_Giris.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
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
            cmd.Parameters.AddWithValue("@description", book.Description);
            cmd.Parameters.AddWithValue("@pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("@isbn", book.ISBN);
            cmd.Parameters.AddWithValue("@shelfId", book.ShelfId);
            conn.Open();
            book.Id = (int)cmd.ExecuteScalar();
            //kitap eklendi ve ID si edinildi.
            foreach (Category category in book.Categories)
            {
                cmd = new SqlCommand("INSERT INTO BooksCategoriesRel (BookId,CategoryId) VALUES (@bookId,@categoryId", conn);
                cmd.Parameters.AddWithValue("bookid", book.Id);
                cmd.Parameters.AddWithValue("categoryid", category.Id);
                cmd.ExecuteNonQuery();
            }
            foreach (Author author in book.Authors)
            {
                cmd = new SqlCommand("INSERT INTO BooksAuthorsRel (BookId,AuthorId) VALUES (@bookId,@authorId)", conn);
                cmd.Parameters.AddWithValue("@bookId", book.Id);
                cmd.Parameters.AddWithValue("@authorId", author.Id);
                cmd.ExecuteNonQuery();
            }
            foreach (Publisher publisher in book.Publishers)
            {
                cmd = new SqlCommand("INSERT INTO BooksPublishersRel (BookId,PublisherId) VALUES (@bookId,@authorId", conn);
                cmd.Parameters.AddWithValue("@bookId", book.Id);
                cmd.Parameters.AddWithValue("@publisherId", publisher.Id);
            }
            conn.Close();
            return book.Id > 0 ? true : false;
        }
        public static List<Book> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT b.*,s.Name AS ShelfName FROM Books b JOIN Shelves s ON s.Id = b.ShelfId", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Book book = new Book
                {
                    Id = (int)dr["Id"],
                    ISBN = (string)dr["ISBN"],
                    Guid = (Guid)dr["Guid"],
                    IsActive = (bool)dr["IsActive"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    Name = (string)dr["Name"],
                    PageCount = (int)dr["PageCount"],
                    Description = (string)dr["Description"],
                    ShelfId = (int)dr["ShelfId"],
                    Shelf = ShelfController.Find((string)dr["ShelfName"]),
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    ModifiedDate = (DateTime)dr["ModifiedDate"],
                    Categories = CategoryController.GetAllByBookId((int)dr["id"]),
                    Authors = AuthorController.GetAllByBookId((int)dr["id"]),


                }
            }
            conn.Close();
        }
    }
}
