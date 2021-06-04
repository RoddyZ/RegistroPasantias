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
    public class DAOEmpresa
    {
        public static List<Empresa> ObtenerEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Obtener_Empresas", con);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empresa em = new Empresa();
                    em.IdEmpresa = reader.GetInt32(0);
                    em.NombreEmpresa = reader.GetString(1);
                    em.Descripcion = reader.GetString(2);
                    em.CorreoElectronico = reader.GetString(3);
                    em.Direccion = reader.GetString(4);
                    em.Telefono = reader.GetString(5);
                    em.Fax = reader.GetString(6);
                    Jefe j = new Jefe();
                    j.IdJefe = reader.GetInt32(7);
                    em.Jefe = j;
                    empresas.Add(em);

                }
            }
            return empresas;
        }

        public static int ingresarEmpresa(Empresa e, int idJefe)
        {
            int resultado;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_insertar_empresa", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreEmpresa", e.NombreEmpresa);
                comando.Parameters.AddWithValue("@descripcion", e.Descripcion);
                comando.Parameters.AddWithValue("@correoElectronico", e.CorreoElectronico);
                comando.Parameters.AddWithValue("@direccion", e.Direccion);
                comando.Parameters.AddWithValue("@telefono", e.Telefono);
                comando.Parameters.AddWithValue("@fax", e.Fax);
                comando.Parameters.AddWithValue("@idJefe", idJefe);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                resultado = 0;
                Console.WriteLine(ex.Message);
                

            }
            return resultado;
        }

        public static int EliminarEmpresa(int idEmpresa)
        {
            int resultado;
            try
            {
                //Eliminar Jefe
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Eliminar_Empresa", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                resultado = 0;
                System.Console.WriteLine(e.Message);
            }
            return 0;
        }

        public static int EditarEmpresa(Empresa e)
        {
            int resultado;
            try
            {
                SqlConnection con = BaseDatos.ConexionBD();
                SqlCommand comando = new SqlCommand("sp_Editar_Empresa", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombreEmpresa", e.NombreEmpresa);
                comando.Parameters.AddWithValue("@descripcion", e.Descripcion);
                comando.Parameters.AddWithValue("@correoElectronico", e.CorreoElectronico);
                comando.Parameters.AddWithValue("@direccion", e.Direccion);
                comando.Parameters.AddWithValue("@telefono", e.Telefono);
                comando.Parameters.AddWithValue("@fax", e.Fax);
                comando.Parameters.AddWithValue("@idEmpresa", e.IdEmpresa);
                resultado = comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resultado = 0;


            }
            return resultado;
        }


        public static List<Empresa> ObtenerListaEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_VerListaEmpresas", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empresa aux = new Empresa();
                    aux.IdEmpresa = reader.GetInt32(0);
                    aux.NombreEmpresa = reader.GetString(1);
                    aux.Descripcion = reader.GetString(2);
                    aux.CorreoElectronico = reader.GetString(3);
                    aux.Direccion = reader.GetString(4);
                    aux.Telefono = reader.GetString(5);
                    aux.Fax = reader.GetString(6);
                    aux.Jefe.IdJefe = reader.GetInt32(7);
                    empresas.Add(aux);
                }
            }
            return empresas;
        }

    }
}
