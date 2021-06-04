using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Jefe : Usuario
    {
        private int idJefe;

        public int IdJefe { get => idJefe; set => idJefe = value; }

        public Jefe(int idJefe, int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo):base( idUsuario, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.idJefe = idJefe;
        }

        public Jefe()
        {
        }

        public override string ToString()
        {
            return this.idJefe+" "+this.NombreUsuario;
        }
    }
}
