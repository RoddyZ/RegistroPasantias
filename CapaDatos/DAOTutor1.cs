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
    public class DAOTutor1
    {
        public static int IngresarTutor(Tutor t)
        {
            int resultado;
            try
            {
                //Ingresar Tutor
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_Tutor", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", t.NombreUsuario);
                comando.Parameters.AddWithValue("@login", t.Login);
                comando.Parameters.AddWithValue("@contrasenia", t.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", t.Cedula);
                comando.Parameters.AddWithValue("@telefono", t.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", t.CorreoElectronico);
                comando.Parameters.AddWithValue("@departamento", t.Departamento);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }

        public static int EliminarTutor(int idTutor)
        {
            int resultado;
            try
            {
                //Eliminar Tutor
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Eliminar_Tutor", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idTutor", idTutor);
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);
            }
            return 0;
        }

        public static int EditarTutor(Tutor t)
        {
            int resultado;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Editar_Tutores", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idTutor", t.IdTutor);
                comando.Parameters.AddWithValue("@nombreUsuario", t.NombreUsuario);
                comando.Parameters.AddWithValue("@login", t.Login);
                comando.Parameters.AddWithValue("@contrasenia", t.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", t.Cedula);
                comando.Parameters.AddWithValue("@telefono", t.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", t.CorreoElectronico);
                comando.Parameters.AddWithValue("@departamento", t.Departamento);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }


        public static List<Tutor> obtenerTutores()
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Obtener_Tutores", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            List<Tutor> tutores = new List<Tutor>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Tutor tutor = new Tutor();
                    tutor.IdTutor = reader.GetInt32(7);
                    tutor.NombreUsuario = reader.GetString(1);
                    tutores.Add(tutor);

                }
            }
            //comando.ExecuteNonQuery();
            return tutores;
        }
    }
}
