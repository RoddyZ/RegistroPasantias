using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Empresa
    {
        private int idEmpresa;
        private string nombreEmpresa;
        private string direccion;
        private string descripcion;
        private string correoElectronico;
        private string telefono;
        private string fax;
        private Jefe jefe;

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Fax { get => fax; set => fax = value; }
        public Jefe Jefe { get => jefe; set => jefe = value; }

        public Empresa(int idEmpresa, string nombreEmpresa, string direccion, string descripcion, string correoElectronico, string telefono, string fax)
        {
            this.idEmpresa = idEmpresa;
            this.nombreEmpresa = nombreEmpresa;
            this.direccion = direccion;
            this.descripcion = descripcion;
            this.correoElectronico = correoElectronico;
            this.telefono = telefono;
            this.fax = fax;
        }

        public Empresa()
        {
            this.jefe = new Jefe();
        }

        public override string ToString()
        {
            return this.NombreEmpresa;
        }
    }
}
