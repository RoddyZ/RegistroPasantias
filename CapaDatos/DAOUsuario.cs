using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaDatos
{
    public class DAOUsuario
    {

        public static List<Usuario> obtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlConnection con = BaseDatos.ConexionBD();
            SqlCommand comando = new SqlCommand("sp_obtener_practicantes", con);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    Practicante auxPrac = new Practicante();
                    auxPrac.IdUsuario = reader.GetInt32(0);
                    auxPrac.NombreUsuario = reader.GetString(1);
                    auxPrac.Login = reader.GetString(2);
                    auxPrac.Contrasenia = reader.GetString(3);
                    auxPrac.Cedula = reader.GetString(4);
                    auxPrac.Telefono = reader.GetString(5);
                    auxPrac.CorreoElectronico = reader.GetString(6);
                    auxPrac.IdPracticante = reader.GetInt32(7);
                    auxPrac.FechaNacimiento = reader.GetDateTime(8);
                    auxPrac.CreditosAprobados = reader.GetInt32(9);
                    auxPrac.Carrera = reader.GetString(10);

                    usuarios.Add(auxPrac);
                }
            }
            reader.Close();

            SqlCommand comando1 = new SqlCommand("sp_obtener_decanos", con);
            comando1.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader1 = comando1.ExecuteReader();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {


                    Practicante auxPrac = new Practicante();
                    Decano auxDec = new Decano();
                    auxDec.IdUsuario = reader1.GetInt32(0);
                    auxDec.NombreUsuario = reader1.GetString(1);
                    auxDec.Login = reader1.GetString(2);
                    auxDec.Contrasenia = reader1.GetString(3);
                    auxDec.Cedula = reader1.GetString(4);
                    auxDec.Telefono = reader1.GetString(5);
                    auxDec.CorreoElectronico = reader1.GetString(6);
                    auxDec.IdDecano = reader1.GetInt32(7);
                    auxDec.Activo = reader1.GetBoolean(8);


                    usuarios.Add(auxDec);
                }
            }

            reader1.Close();

            SqlCommand comando2 = new SqlCommand("sp_obtener_tutores", con);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader2 = comando2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {


                    Tutor auxTut = new Tutor();
                    auxTut.IdUsuario = reader2.GetInt32(0);
                    auxTut.NombreUsuario = reader2.GetString(1);
                    auxTut.Login = reader2.GetString(2);
                    auxTut.Contrasenia = reader2.GetString(3);
                    auxTut.Cedula = reader2.GetString(4);
                    auxTut.Telefono = reader2.GetString(5);
                    auxTut.CorreoElectronico = reader2.GetString(6);
                    auxTut.IdTutor = reader2.GetInt32(7);
                    auxTut.Departamento = reader2.GetString(8);


                    usuarios.Add(auxTut);
                }
            }
            reader2.Close();





            SqlCommand comando5 = new SqlCommand("sp_obtener_jefes", con);
            comando5.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader5 = comando5.ExecuteReader();

            if (reader5.HasRows)
            {
                while (reader5.Read())
                {


                    Jefe auxJefe = new Jefe();
                    auxJefe.IdUsuario = reader5.GetInt32(0);
                    auxJefe.NombreUsuario = reader5.GetString(1);
                    auxJefe.Login = reader5.GetString(2);
                    auxJefe.Contrasenia = reader5.GetString(3);
                    auxJefe.Cedula = reader5.GetString(4);
                    auxJefe.Telefono = reader5.GetString(5);
                    auxJefe.CorreoElectronico = reader5.GetString(6);
                    auxJefe.IdJefe = reader5.GetInt32(7);

                    usuarios.Add(auxJefe);
                }
            }
            return usuarios;
        }

    }
}
