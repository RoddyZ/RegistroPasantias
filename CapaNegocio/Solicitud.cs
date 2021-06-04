using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class Solicitud
    {
        private int idSolicitud;
        private string descripcionSolicitud;
        private string estadoSolicitud;
        private Empresa empresa;
        private Practicante practicante;
        private Decano decano;
        private DateTime fechaEmision;

        public int IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public string DescripcionSolicitud { get => descripcionSolicitud; set => descripcionSolicitud = value; }
        public Empresa Empresa { get => empresa; set => empresa = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        public Practicante Practicante { get => practicante; set => practicante = value; }
        public Decano Decano { get => decano; set => decano = value; }
        public string EstadoSolicitud { get => estadoSolicitud; set => estadoSolicitud = value; }

        public Solicitud()
        {
            this.practicante = new Practicante();
            this.empresa = new Empresa();
        }

        public Solicitud(int idSolicitud, string descripcionSolicitud, string estadoSolicitud, Empresa empresa, Practicante practicante, Decano decano, DateTime fechaEmision)
        {
            this.practicante = new Practicante();
            this.empresa = new Empresa();
            this.idSolicitud = idSolicitud;
            this.descripcionSolicitud = descripcionSolicitud;
            this.EstadoSolicitud = estadoSolicitud;
            this.empresa = empresa;
            this.practicante = practicante;
            this.decano = decano;
            this.fechaEmision = fechaEmision;
        }

        public override string ToString()
        {
            return this.IdSolicitud+" "+this.practicante.NombreUsuario+" "+this.Empresa.NombreEmpresa+""+this.EstadoSolicitud;
        }
    }
}
