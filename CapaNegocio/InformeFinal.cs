using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class InformeFinal
    {
        private int idInformeFinal;
        private DateTime fechaEmision;
        private string descripcionInforme;
        private Practicante practicante;
        private Empresa empresa;
        private string materiasUtiles;
        private string temasRelevantes;
        private string observaciones;

        public int IdInformeFinal { get => idInformeFinal; set => idInformeFinal = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        public string DescripcionInforme { get => descripcionInforme; set => descripcionInforme = value; }
        public string MateriasUtiles { get => materiasUtiles; set => materiasUtiles = value; }
        public string TemasRelevantes { get => temasRelevantes; set => temasRelevantes = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        internal Practicante Practicante { get => practicante; set => practicante = value; }
        internal Empresa Empresa { get => empresa; set => empresa = value; }

        public InformeFinal()
        {
        }

        public InformeFinal(int idInformeFinal, DateTime fechaEmision, string descripcionInforme, Practicante practicante, Empresa empresa, string materiasUtiles, string temasRelevantes, string observaciones)
        {
            this.idInformeFinal = idInformeFinal;
            this.fechaEmision = fechaEmision;
            this.descripcionInforme = descripcionInforme;
            this.practicante = practicante;
            this.empresa = empresa;
            this.materiasUtiles = materiasUtiles;
            this.temasRelevantes = temasRelevantes;
            this.observaciones = observaciones;
        }

        public override string ToString()
        {
            return this.IdInformeFinal+"";
        }
    }
}
