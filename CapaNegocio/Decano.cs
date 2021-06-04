using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Decano : Usuario
    {
        private int idDecano;
        private Boolean activo;

        public int IdDecano { get => idDecano; set => idDecano = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Decano()
        {
        }

        public Decano(bool activo, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo) :base(0, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.activo = activo;
        }

        public override string ToString()
        {
            return this.IdDecano+" "+this.NombreUsuario;
        }
    }
}
