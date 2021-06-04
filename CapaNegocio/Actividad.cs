using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public  class Actividad
    {
        private int idActividad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private float numHoras;

        public int IdActividad { get => idActividad; set => idActividad = value; }
        
        public float NumHoras { get => numHoras; set => numHoras = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }

        public Actividad()
        {
        }

        public Actividad(DateTime fechaInicio, DateTime fechaFin, float numHoras)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.numHoras = numHoras;
        }

        public override string ToString()
        {
            return this.IdActividad+"";
        }
    }
}
