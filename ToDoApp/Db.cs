using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public static class Db
    {
        public static SqlConnection conn()
        {
            return new SqlConnection("Server=DESKTOP-M577INS\\SQLEXPRESS; Database=ToDoApp; Integrated Security = True; TrustServerCertificate=True");
        }
    }
}
