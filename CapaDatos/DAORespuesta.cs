using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAORespuesta
    {
        public static int CrearRespuesta(int calificacion, int idEncuesta,int idPregunta)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Crear_Respuesta", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("calificacion", calificacion);
            comando.Parameters.AddWithValue("idEncuesta", idEncuesta);
            comando.Parameters.AddWithValue("idPregunta", idPregunta);


            int resultado;
            resultado = comando.ExecuteNonQuery();
            return resultado;
        }
    }
}
