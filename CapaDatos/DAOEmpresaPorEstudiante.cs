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
    public class DAOEmpresaPorEstudiante
    {
        public static List<Empresa> EmpresaPorEstudiante(int id)
        {
            List<Empresa> empresas = new List<Empresa>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Empresa_Por_Estudiante", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", id);
            SqlDataReader reader = comando.ExecuteReader();

            
           if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.IdEmpresa = reader.GetInt32(0);
                    empresa.NombreEmpresa = reader.GetString(1);
                    
                    empresas.Add(empresa);
                    //Console.WriteLine(empresa);
                    //Console.WriteLine(aux);
                }
            }

            reader.Close();

            
            return empresas;
           
            //comando.ExecuteNonQuery();
        }
        
    }
}
