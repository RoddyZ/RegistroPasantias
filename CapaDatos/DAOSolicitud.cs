using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAOSolicitud
    {
        public static int CrearSolicitud(Solicitud pasantia)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_InsertarSolicitud", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@descripcionSolicitud",pasantia.DescripcionSolicitud);
            comando.Parameters.AddWithValue("@estadoSolicitud",pasantia.EstadoSolicitud);
            comando.Parameters.AddWithValue("@fechaEmision",pasantia.FechaEmision);
            comando.Parameters.AddWithValue("@idEmpresa",pasantia.Empresa.IdEmpresa);
            comando.Parameters.AddWithValue("@idPracticante",pasantia.Practicante.IdPracticante);
            comando.Parameters.AddWithValue("@idDecano",pasantia.Decano.IdDecano);
            int resultado;
            try
            {
               // Console.WriteLine(Convert.ToString(pasantia.Practicante));
                resultado = comando.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);
            }
            return resultado;
        }

        public static List<Solicitud> ObtenerSolicitud(int idPracticante)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Recuperar_Solicitud", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", idPracticante);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    solicitud.IdSolicitud = reader.GetInt32(0);
                    solicitud.DescripcionSolicitud = reader.GetString(1);
                    solicitud.EstadoSolicitud = reader.GetString(2);
                    solicitud.FechaEmision = reader.GetDateTime(3);
                    Empresa empresa = new Empresa(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10));
                    solicitud.Empresa = empresa;
                    solicitudes.Add(solicitud);
                }
            }

            return solicitudes;
        }

        public static List<Solicitud> TodasSolicitudes()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Solicitudes", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Solicitud solicitud = new Solicitud();
                    solicitud.IdSolicitud = reader.GetInt32(0);
                    solicitud.DescripcionSolicitud = reader.GetString(2);
                    solicitud.EstadoSolicitud = reader.GetString(3);
                    solicitud.FechaEmision = reader.GetDateTime(4);
                    Empresa empresa = new Empresa();
                    empresa.NombreEmpresa = reader.GetString(5);
                    Practicante p = new Practicante();
                    p.NombreUsuario = reader.GetString(1);
                    p.IdPracticante = reader.GetInt32(6);
                    solicitud.Empresa = empresa;
                    solicitud.Practicante = p;
                    solicitudes.Add(solicitud);
                }
            }

            return solicitudes;
        }

        public static void ValidarSolicitud(int idSolicitud, int estado)
        {
            // Console.WriteLine(estado);
            //Console.WriteLine(idSolicitud);
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Validar_Solicitud", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idSolicitud", idSolicitud);
            comando.Parameters.AddWithValue("@estado", estado);
            int resultado = comando.ExecuteNonQuery();
            // Console.WriteLine(resultado);

        }
    }
}
