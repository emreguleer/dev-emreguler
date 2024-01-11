using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Controller
{
    public  class TodoController
    {
        public static bool Add(ToDo todo)
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("INSERT INTO ToDo (Name, Description,DeadLine,StatusId,PriorityId, CreatedDate, IsDeleted) OUTPUT inserted.Id VALUES (@name, @description,@deadLine,@statusId,priorityId, @createdDate, @isDeleted", conn);
            cmd.Parameters.AddWithValue("@name", todo.Name);
            cmd.Parameters.AddWithValue("@description", DBNull.Value); 
            cmd.Parameters.AddWithValue("@deadLine", todo.DeadLine);
            cmd.Parameters.AddWithValue("@statusId", todo.StatusId);
            cmd.Parameters.AddWithValue("@priorityId", todo.PriorityId);
            cmd.Parameters.AddWithValue("@createdDate", todo.CreatedDate);
            cmd.Parameters.AddWithValue("isDeleted", todo.IsDeleted);
            conn.Open();
            todo.Id = (int)cmd.ExecuteScalar();
            foreach (Tag tag in todo.Tags)
            {
                cmd = new SqlCommand("INSERT INTO ToDoTagRel (ToDoId, TagId VALUES (@toDoId, @tagId) ", conn);
                cmd.Parameters.AddWithValue("toDoId", todo.Id);
                cmd.Parameters.AddWithValue("tagId", tag.Id);

            }
            return todo.Id > 0 ? true : false;
        }
        public static List<ToDo> GetAll()
        {
            SqlConnection conn = Db.conn();
            SqlCommand cmd = new SqlCommand("SELECT t.*, p.Name AS PriortyName, s.Name AS StatusName FROM ToDo t JOIN Priority p ON t.PriorityId = p.Id" +
                "JOIN Status s ON s.Id = t.StatusId", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ToDo todo = new ToDo
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Description = (string)dr["Description"],
                    DeadLine = (DateTime)dr["DeadLine"],
                    CreatedDate = (DateTime)dr["CreatedDate"],
                    IsDeleted = (bool)dr["IsDeleted"],
                    PriorityId = (int)dr["PriorityId"],
                    Priority = PriorityController.Find((string)dr["PriorityName"]),
                    StatusId = (int)dr["StatusId"],
                    Status = StatusController.Find((string)dr["StatusName"]),
                };
            }

        }
    }
}
