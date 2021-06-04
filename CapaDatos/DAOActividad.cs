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
    public class DAOActividad
    {
        public static List<Actividad> RecuperarAsistencia(int idPracticante, int idEmpresa)
        {
            List<Actividad> asistencias = new List<Actividad>();
            try
            {
                
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Recuperar_Asistencia1", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPracticante", idPracticante);
                comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Actividad act = new Actividad();
                        act.IdActividad = reader.GetInt32(0);
                        act.FechaInicio = reader.GetDateTime(1);
                        act.FechaFin = reader.GetDateTime(2);
                        act.NumHoras = (float)reader.GetSqlDouble(3);
                        asistencias.Add(act);
                    }
                }

                
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return asistencias;

        }

        public static int RecuperarIDRegistro(int idPracticante, int idEmpresa)
        {
            int idRegistroAsistencia=0;
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Recuperar_IdRegistro", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", idPracticante);
            comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idRegistroAsistencia = reader.GetInt32(0);
                }
            }
            

            return idRegistroAsistencia;
        }


        public static int IngresarAsistencia(int idRegistroAsistencia, Actividad a)
        {
            int resultado;
            try
            {
                //Ingresar Asistencia
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_actividad", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idRegistroDeasistencia", idRegistroAsistencia);
                comando.Parameters.AddWithValue("@fechaInicio", a.FechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", a.FechaFin);
                comando.Parameters.AddWithValue("@numHoras", a.NumHoras);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);
                

            }
            return resultado;
        }

        public static int EditarAsistencia(Actividad a)
        {
            int resultado;
            try
            {
                //Editar Asistencia
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_editar_actividad", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idActividad", a.IdActividad);
                comando.Parameters.AddWithValue("@fechaInicio", a.FechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", a.FechaFin);
                comando.Parameters.AddWithValue("@numHoras", a.NumHoras);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);


            }
            return resultado;
        }

        public static int EliminarActividad(Actividad a)
        {
            int resultado;
            try
            {
                //Eliminar Asistencia
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_eliminar_actividad", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idActividad", a.IdActividad);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = 0;


            }
            return resultado;
        }
    }
}
