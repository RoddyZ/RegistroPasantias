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
    public class DAOPracticante
    {
        public static int IngresarPracticante(Practicante p)
        {
            int resultado;
            try
            {
                //Ingresar Practicante
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_Practicante", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", p.NombreUsuario);
                comando.Parameters.AddWithValue("@login", p.Login);
                comando.Parameters.AddWithValue("@contrasenia", p.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", p.Cedula);
                comando.Parameters.AddWithValue("@telefono", p.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", p.CorreoElectronico);
                comando.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                comando.Parameters.AddWithValue("@creditosAprobados", p.CreditosAprobados);
                comando.Parameters.AddWithValue("@carrera", p.Carrera);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }

        public static int EliminarPracticante(int idPracticante)
        {
            int resultado;
            try
            {
                //Eliminar Practicante
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Eliminar_Practicantes", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPracticante", idPracticante);
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);
            }
                return 0;
        }

        public static int EditarPracticante(Practicante p)
        {
            int resultado;
            try
            {
                //Ingresar Practicante
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Editar_Practicantes", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", p.NombreUsuario);
                comando.Parameters.AddWithValue("@login", p.Login);
                comando.Parameters.AddWithValue("@contrasenia", p.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", p.Cedula);
                comando.Parameters.AddWithValue("@telefono", p.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", p.CorreoElectronico);
                comando.Parameters.AddWithValue("@idPracticante", p.IdPracticante);
                comando.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                comando.Parameters.AddWithValue("@creditosAprobados", p.CreditosAprobados);
                comando.Parameters.AddWithValue("@carrera", p.Carrera);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }
    }
}
