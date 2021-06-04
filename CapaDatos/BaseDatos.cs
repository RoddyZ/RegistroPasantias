using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class BaseDatos
    {
        public static SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-QS8JAED\SQLEXPRESS;Initial Catalog=Pasantias;Integrated Security=True");
            conexion.Open();
            return conexion;
        }
    }
}
