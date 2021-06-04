using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DAOTUTOR
    {
       public static List<Solicitud> ObtenerListaPracticantes(Tutor t)
        {
            List<Solicitud> solicituds = new List<Solicitud>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_BuscarPracticantesInformeMitad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTutor", t.IdTutor);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Solicitud aux = new Solicitud();
                    aux.IdSolicitud = reader.GetInt32(0);
                    aux.Practicante.NombreUsuario = reader.GetString(1);
                    aux.Practicante.Carrera = reader.GetString(2);
                    aux.Empresa.NombreEmpresa = reader.GetString(3);
                    aux.Empresa.Direccion = reader.GetString(4);
                    aux.Empresa.Telefono= reader.GetString(5);
                    aux.Empresa.Fax= reader.GetString(6);
                    aux.Empresa.CorreoElectronico= reader.GetString(7);
                    solicituds.Add(aux);
                }
            }
            return solicituds;
        }
        public static int CrearInforme(InformeMitadPeriodo i,Solicitud pasantia,Tutor t)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_CrearInformeMitadPeriodo", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@preparacionTecnica",i.PreparacionTecnica);
            comando.Parameters.AddWithValue("@capacidadAprendizaje", i.CapacidadAprendizaje);
            comando.Parameters.AddWithValue("@trabajoEquipo", i.TrabajoEquipo);
            comando.Parameters.AddWithValue("@creatividad", i.Creatividad);
            comando.Parameters.AddWithValue("@adaptacion", i.Adaptacion);
            comando.Parameters.AddWithValue("@responsabilidad", i.Responsabilidad);
            comando.Parameters.AddWithValue("@puntualidad ", i.Puntualidad);
            comando.Parameters.AddWithValue("@idSolicitud", pasantia.IdSolicitud);
            comando.Parameters.AddWithValue("@idTutor",t.IdTutor);
            SqlDataReader reader = comando.ExecuteReader();
            int idInformeMitad=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    try
                    {
                        idInformeMitad = (int)reader.GetDecimal(0);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                }
            }
            return idInformeMitad;
        }
        public static List<InformeMitadPeriodo> ObtenerInformesMitadPeriodo(Tutor t)
        {
            List<InformeMitadPeriodo> informes = new List<InformeMitadPeriodo>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_BuscarInformesMitadPeriodoTutor", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTutor", t.IdTutor);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InformeMitadPeriodo aux = new InformeMitadPeriodo();
                    aux.IdInformeMitadPeriodo = reader.GetInt32(0);
                    aux.PreparacionTecnica = reader.GetString(1);
                    aux.CapacidadAprendizaje = reader.GetString(2);
                    aux.TrabajoEquipo = reader.GetBoolean(3);
                    aux.Creatividad = reader.GetBoolean(4);
                    aux.Adaptacion = reader.GetBoolean(5);
                    aux.Responsabilidad = reader.GetBoolean(6);
                    aux.Puntualidad = reader.GetBoolean(7);
                    aux.Solicitud.Empresa.NombreEmpresa = reader.GetString(8);
                    aux.Solicitud.Empresa.Direccion = reader.GetString(9);
                    aux.Solicitud.Empresa.Telefono = reader.GetString(10);
                    aux.Solicitud.Empresa.Fax = reader.GetString(11);
                    aux.Solicitud.Empresa.CorreoElectronico = reader.GetString(12);
                    aux.Solicitud.Practicante.NombreUsuario= reader.GetString(13);
                    aux.Solicitud.Practicante.Carrera = reader.GetString(14);
                    informes.Add(aux);
                }
            }
            return informes;
        }
        public static int BorrarInforme(InformeMitadPeriodo i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EliminarInformeMitad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeMitad", i.IdInformeMitadPeriodo);
            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                Console.WriteLine(e.Message);
            }
            return resultado;
        }
        public static int EditarInforme(InformeMitadPeriodo i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EditarInformeMitad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeMitad", i.IdInformeMitadPeriodo);
            comando.Parameters.AddWithValue("@preparacionTecnica", i.PreparacionTecnica);
            comando.Parameters.AddWithValue("@capacidadAprendizaje", i.CapacidadAprendizaje);
            comando.Parameters.AddWithValue("@trabajoEquipo", i.TrabajoEquipo);
            comando.Parameters.AddWithValue("@creatividad", i.Creatividad);
            comando.Parameters.AddWithValue("@adaptacion", i.Adaptacion);
            comando.Parameters.AddWithValue("@responsabilidad", i.Responsabilidad);
            comando.Parameters.AddWithValue("@puntualidad ", i.Puntualidad);
            
            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = 0;

            }
            return resultado;
        }
        public static int InsertarControl(ControlTutor c,int idInformeMitadPeriodo)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_insertarControlTutor", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha",c.Fecha);
            comando.Parameters.AddWithValue("@medio", c.Medio);
            comando.Parameters.AddWithValue("@tema", c.Tema);
            comando.Parameters.AddWithValue("@idInformeMitadPeriodo",idInformeMitadPeriodo);
            int resultado;
            try
            {
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = 0;

            }
            return resultado;
        }
        public static List<ControlTutor> ObtenerControlTutoria(int idInformeMitadPeriodo)
        {
            List<ControlTutor> controles = new List<ControlTutor>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerControlTutoria", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeMitadPeriodo",idInformeMitadPeriodo);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ControlTutor aux = new ControlTutor();
                    aux.IdControlTutor = reader.GetInt32(0);
                    aux.Fecha = reader.GetDateTime(1);
                    aux.Medio = reader.GetString(2);
                    aux.Tema = reader.GetString(3);
                    controles.Add(aux);
                }
            }
            return controles;
        }

    }
}

 