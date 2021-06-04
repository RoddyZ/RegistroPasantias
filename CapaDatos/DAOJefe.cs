using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DAOJefe
    {

        public static List<Jefe> ObtenerJefe()
        {
            List<Jefe> jefes = new List<Jefe>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_consultar_jefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    Jefe auxJefe = new Jefe();
                    auxJefe.IdUsuario = reader.GetInt32(0);
                    auxJefe.NombreUsuario = reader.GetString(1);
                    auxJefe.Login = reader.GetString(2);
                    auxJefe.Contrasenia = reader.GetString(3);
                    auxJefe.Cedula = reader.GetString(4);
                    auxJefe.Telefono = reader.GetString(5);
                    auxJefe.CorreoElectronico = reader.GetString(6);
                    auxJefe.IdJefe = reader.GetInt32(7);

                    jefes.Add(auxJefe);
                }
            }
            return jefes;
        }
        public static int IngresarJefe(Jefe j)
        {
            int resultado;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_Jefe", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", j.NombreUsuario);
                comando.Parameters.AddWithValue("@login", j.Login);
                comando.Parameters.AddWithValue("@contrasenia", j.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", j.Cedula);
                comando.Parameters.AddWithValue("@telefono", j.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", j.CorreoElectronico);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }

        public static int EliminarJefe(int idJefe)
        {
            int resultado;
            try
            {
                //Eliminar Jefe
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Eliminar_Jefes", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idJefe", idJefe);
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);
            }
            return 0;
        }

        public static int EditarJefe(Jefe j)
        {
            int resultado;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Editar_Jefes", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idJefe", j.IdJefe);
                comando.Parameters.AddWithValue("@nombreUsuario", j.NombreUsuario);
                comando.Parameters.AddWithValue("@login", j.Login);
                comando.Parameters.AddWithValue("@contrasenia", j.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", j.Cedula);
                comando.Parameters.AddWithValue("@telefono", j.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", j.CorreoElectronico);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }

        public static int recuperarUltimoJefe()
        {
            int resultado=0;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_consultar_jefe", con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                resultado = 0;
            }

            return resultado;
        }



        public static List<Solicitud> ObtenerListaPracticantes(Jefe j)
        {
            List<Solicitud> solicituds = new List<Solicitud>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_BuscarPracticantesInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idJefe", j.IdJefe);
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
                    aux.Empresa.Telefono = reader.GetString(5);
                    aux.Empresa.Fax = reader.GetString(6);
                    aux.Empresa.CorreoElectronico = reader.GetString(7);
                    aux.Practicante.Cedula = reader.GetString(8);
                    aux.Practicante.IdPracticante = reader.GetInt32(9);
                    solicituds.Add(aux);
                }
            }
            return solicituds;
        }
        public static int CrearInforme(InformeJefe i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_CrearInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@areaAsignada", i.AreaAsignada);
            comando.Parameters.AddWithValue("@actividadesDesarrolladas", i.ActividadesDesarrolladas);
            comando.Parameters.AddWithValue("@horario", i.Horario);
            comando.Parameters.AddWithValue("@fortalezas", i.Fortalezas);
            comando.Parameters.AddWithValue("@debilidades", i.Debilidades);
            comando.Parameters.AddWithValue("@evaluacion", i.Evaluacion);
            comando.Parameters.AddWithValue("@desempenio", i.Desempenio);
            comando.Parameters.AddWithValue("@motivacion", i.Motivacion);
            comando.Parameters.AddWithValue("@contactoTutor", i.ContactoTutor);
            comando.Parameters.AddWithValue("@idSolicitud", i.Solicitud.IdSolicitud);
            comando.Parameters.AddWithValue("@idTutor", i.Tutor.IdTutor);
            comando.Parameters.AddWithValue("@idRegistroDeAsistencia", i.RegistroAsistencia.IdRegistroAsistencia);
            comando.Parameters.AddWithValue("@idJefe", i.Jefe.IdJefe);

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
        public static RegistroAsistencia ObtenerRegistroAsistenciaPracticante(Solicitud pasantia)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerRegistroAsistenciaPracticante", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idSolicitud", pasantia.IdSolicitud);
            SqlDataReader reader = comando.ExecuteReader();
            RegistroAsistencia aux = new RegistroAsistencia();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    aux.IdRegistroAsistencia = reader.GetInt32(0);
                    aux.HorasRealizadas = (float)reader.GetDouble(1);
                    aux.FechaFin = reader.GetDateTime(2);
                    aux.FechaInicio = reader.GetDateTime(3);
                    aux.PeriodoAcademico = reader.GetString(4);
                }
            }
            return aux;

        }
        public static Tutor ObtenerTutorPracticante(Solicitud pasantia)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerTutorPracticante", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", pasantia.Practicante.IdPracticante);
            SqlDataReader reader = comando.ExecuteReader();
            Tutor tutor = new Tutor();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tutor.IdTutor = reader.GetInt32(0);
                    tutor.NombreUsuario = reader.GetString(1);
                }
            }
            return tutor;

        }



        public static List<InformeJefe> ObtenerInformesJefe(Jefe j)
        {
            List<InformeJefe> informes = new List<InformeJefe>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerInformesJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idJefe", j.IdJefe);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InformeJefe aux = new InformeJefe();
                    aux.IdInformeJefe = reader.GetInt32(0);
                    aux.AreaAsignada = reader.GetString(1);
                    aux.ActividadesDesarrolladas = reader.GetString(2);
                    aux.Horario = reader.GetString(3);
                    aux.Fortalezas = reader.GetString(4);
                    aux.Debilidades = reader.GetString(5);
                    aux.Evaluacion = reader.GetString(6);
                    aux.Desempenio = reader.GetString(7);
                    aux.Motivacion = reader.GetString(8);
                    aux.ContactoTutor = reader.GetBoolean(9);
                    aux.Solicitud.IdSolicitud = reader.GetInt32(10);
                    aux.Solicitud.Empresa.NombreEmpresa = reader.GetString(11);
                    aux.Solicitud.Empresa.Direccion = reader.GetString(12);
                    aux.Solicitud.Empresa.Telefono = reader.GetString(13);
                    aux.Solicitud.Empresa.Fax = reader.GetString(14);
                    aux.Solicitud.Empresa.CorreoElectronico = reader.GetString(15);
                    aux.Solicitud.Practicante.IdPracticante = reader.GetInt32(16);
                    aux.Solicitud.Practicante.NombreUsuario = reader.GetString(17);
                    aux.Solicitud.Practicante.Carrera = reader.GetString(18);
                    aux.Solicitud.Practicante.Cedula = reader.GetString(19);
                    aux.RegistroAsistencia.IdRegistroAsistencia = reader.GetInt32(20);
                    aux.RegistroAsistencia.HorasRealizadas = (float)reader.GetDouble(21);
                    aux.RegistroAsistencia.FechaFin = reader.GetDateTime(22);
                    aux.RegistroAsistencia.FechaInicio = reader.GetDateTime(23);
                    aux.RegistroAsistencia.PeriodoAcademico = reader.GetString(24);
                    informes.Add(aux);
                }
            }

            return informes;
        }
        public static int BorrarInforme(InformeJefe i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EliminarInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeJefe", i.IdInformeJefe);
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
        public static int EditarInformeJefe(InformeJefe i)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_EditarInformeJefe", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idInformeJefe", i.IdInformeJefe);
            comando.Parameters.AddWithValue("@areaAsignada", i.AreaAsignada);
            comando.Parameters.AddWithValue("@actividadesDesarrolladas", i.ActividadesDesarrolladas);
            comando.Parameters.AddWithValue("@horario", i.Horario);
            comando.Parameters.AddWithValue("@fortalezas", i.Fortalezas);
            comando.Parameters.AddWithValue("@debilidades", i.Debilidades);
            comando.Parameters.AddWithValue("@evaluacion", i.Evaluacion);
            comando.Parameters.AddWithValue("@desempenio", i.Desempenio);
            comando.Parameters.AddWithValue("@motivacion", i.Motivacion);
            comando.Parameters.AddWithValue("@contactoTutor", i.ContactoTutor);
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
    }
}
