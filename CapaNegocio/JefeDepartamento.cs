using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class JefeDepartamento : Usuario
    {
        private int idJefeDepartamento;

        public int IdJefeDepartamento { get => idJefeDepartamento; set => idJefeDepartamento = value; }

        public JefeDepartamento()
        {
        }

        public JefeDepartamento(int idJefeDepartamento, int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo) :base( idUsuario,  nombreUsuario,  contrasenia, login, cedula, telefono, correo)
        {
            this.idJefeDepartamento = idJefeDepartamento;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
