using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Subdecano: Usuario
    {
        private int idSubdecano;

        public int IdSubdecano { get => idSubdecano; set => idSubdecano = value; }

        public Subdecano(int idSubdecano, int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo) : base(idUsuario, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.idSubdecano = idSubdecano;
        }

        public Subdecano()
        {
        }

        public override string ToString()
        {
            return this.IdSubdecano+"";
        }
    }
}
