using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_Quanly
{
    public class DBConnect
    {
        protected string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=QuanlyFarm; Integrated Security=True";
    }
}
