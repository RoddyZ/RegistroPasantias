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
    public class DAODecano
    {
        public static int IngresarDecano(Decano d)
        {
            int resultado;
            try
            {
                int activo;
                //Ingresar Practicante
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_Decano", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", d.NombreUsuario);
                comando.Parameters.AddWithValue("@login", d.Login);
                comando.Parameters.AddWithValue("@contrasenia", d.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", d.Cedula);
                comando.Parameters.AddWithValue("@telefono", d.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", d.CorreoElectronico);
                if (d.Activo)
                {
                    activo = 1;
                }
                else
                {
                    activo = 0;
                }
                comando.Parameters.AddWithValue("@activo", activo);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }

        public static int EliminarDecano(int idDecano)
        {
            int resultado;
            try
            {
                //Eliminar Decano
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Eliminar_Decanos", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idDecano", idDecano);
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);
            }
            return 0;
        }

        public static int EditarDecano(Decano d)
        {
            int resultado;
            try
            {
                int activo;
                //Ingresar Practicante
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Editar_Decanos", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreUsuario", d.NombreUsuario);
                comando.Parameters.AddWithValue("@login", d.Login);
                comando.Parameters.AddWithValue("@contrasenia", d.Contrasenia);
                comando.Parameters.AddWithValue("@cedula", d.Cedula);
                comando.Parameters.AddWithValue("@telefono", d.Telefono);
                comando.Parameters.AddWithValue("@correoElectronico", d.CorreoElectronico);
                comando.Parameters.AddWithValue("@idDecano", d.IdDecano);
                if (d.Activo)
                {
                    activo = 1;
                }
                else
                {
                    activo = 0;
                }
                comando.Parameters.AddWithValue("@activo", activo);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e);

            }
            return resultado;
        }


        public static Decano ObtenerDecanoActivo()
        {
            Decano decano = new Decano();

            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_ObtenerDecanoActivo", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    decano.IdDecano = reader.GetInt32(0);
                    decano.NombreUsuario = reader.GetString(1);
                }
            }
            return decano; ;

        }
    }
}
