using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris
{
    public static class Db
    {
        public static SqlConnection conn()
        {
            return new SqlConnection("Server=DESKTOP-M577INS\\SQLEXPRESS; Database=Bookstore; Integrated Security = True; TrustServerCertificate=True");
        }
    }
}
