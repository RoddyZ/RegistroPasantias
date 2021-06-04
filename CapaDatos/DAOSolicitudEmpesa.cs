using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public  class DAOSolicitudEmpesa
    {

        public static int SolicitudEmpresa(int idEmpresa)     //Obtiene el id de la SOlcitud que tiene dicha empresa
        {
            int aux=0;
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Solicitud_Empresa", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            SqlDataReader reader = comando.ExecuteReader();
            Console.WriteLine(  "idEmpresa"+idEmpresa);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     aux = reader.GetInt32(0);

                }
            }
            return aux;
            
        }
       
    }
}
