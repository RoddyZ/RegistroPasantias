using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ControlTutor
    {
        private int idControlTutor;
        private DateTime fecha;
        private string medio;
        private string tema;

        public int IdControlTutor { get => idControlTutor; set => idControlTutor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Medio { get => medio; set => medio = value; }
        public string Tema { get => tema; set => tema = value; }

        public ControlTutor()
        {
        }

        public ControlTutor(int idControlTutor, DateTime fecha, string medio, string tema)
        {
            this.idControlTutor = idControlTutor;
            this.fecha = fecha;
            this.medio = medio;
            this.tema = tema;
        }

        public override string ToString()
        {
            return this.IdControlTutor+" "+this.Tema;
        }
    }
}
