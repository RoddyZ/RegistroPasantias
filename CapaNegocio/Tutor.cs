using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Tutor : Usuario
    {
        private int idTutor;
        private string departamento;

        public int IdTutor { get => idTutor; set => idTutor = value; }
        public string Departamento { get => departamento; set => departamento = value; }

        public Tutor()
        {
        }

        public Tutor(int idTutor, string departamento, int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo):base(idUsuario, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.idTutor = idTutor;
            this.departamento = departamento;
        }


        public override string ToString()
        {
            return this.IdTutor+""+this.NombreUsuario;
        }
    }
}
