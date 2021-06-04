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
    public class DAOAsignarTutor
    {
        public static void AsignarTutor(int idPracticante, int idTutor)
        {
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_Asignar_Tutor", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPracticante", idPracticante);
            comando.Parameters.AddWithValue("@idTutor", idTutor);

            comando.ExecuteNonQuery();
        }
    }
}
