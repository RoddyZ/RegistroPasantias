using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DAORegistroAsistencia
    {
        //public static RegistroAsistencia ObtenerRegistro(int idPracticante)
        //{
            
        //}

        public static int actualizarHorastotales(int idPracticante, float horasTotales, DateTime fechaInicio, DateTime fechaFinalizacion)
        {
            int resultado;

            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_actualizar_RegistroAsistencia", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPracticante", idPracticante);
                comando.Parameters.AddWithValue("@numHoras", horasTotales);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", fechaFinalizacion);
                resultado = comando.ExecuteNonQuery();
            }catch(Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);
            }

            return resultado;
        }


        public static List<String> VerPasantias(int idPracticante)
        {
            List<String> lista = new List<String>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Recuperar_Asistencia", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", idPracticante);
            SqlDataReader reader = comando.ExecuteReader();
            String resultado = "Fecha Inicio                Fecha Fin                     Numero Horas    Empresa";
            lista.Add(resultado);
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    resultado = reader.GetDateTime(0) + "  " + reader.GetDateTime(1) + "      " + (float)reader.GetSqlDouble(2) + "                     " + reader.GetString(3);

                    lista.Add(resultado);
                }
            }

            return lista;

        }

        public static void crearRegistro(float horasRealizadas, DateTime fechaFin, DateTime fechaInicio, string periodoAcademico, int idSolicitud)
        {
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Crear_Registro", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@horasRealizadas", horasRealizadas);
                comando.Parameters.AddWithValue("@fechaFin", fechaFin);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@periodoAcademico", periodoAcademico);
                comando.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
          
        }
    }
}
