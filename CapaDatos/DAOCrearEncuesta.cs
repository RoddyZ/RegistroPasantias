using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos

{
    public  class DAOEncuesta
    {
        public static int CrearEncuesta (string comentario, int idSolicitud)   //es id Solicitud se objtiene del DaoSolicitudEmpresa
        {
           

            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Crear_Encuesta", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@comentario",comentario);
            comando.Parameters.AddWithValue("@idSolicitud", idSolicitud);

            int resultado;
            resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public static int ObtenerIdEncuesta(int idSolicitud)
        {
            Encuesta encuesta= new Encuesta();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Obtener_idEncuesta", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idSolicitud", idSolicitud);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    encuesta.IdEncuesta = reader.GetInt32(0);
                    
                }
            }
            return encuesta.IdEncuesta;   //Obtengo el id De la ultima encuesta 
        }
    }
}
