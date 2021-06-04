using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        private int idUsuario;
        private string nombreUsuario;
        private string contrasenia;
        private string login;
        private string cedula;
        private string telefono;
        private string correoElectronico;
        

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Login { get => login; set => login = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

        public Usuario(int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.login = login;
            this.cedula = cedula;
            this.telefono = telefono;
            this.correoElectronico = correo;
        }

        public Usuario()
        {
        }

        
    }
}
