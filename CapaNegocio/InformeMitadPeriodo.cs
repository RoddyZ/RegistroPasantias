using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class InformeMitadPeriodo
    {
        private int idInformeMitadPeriodo;
        private Solicitud solicitud;
        private string preparacionTecnica;
        private string capacidadAprendizaje;
        private Boolean trabajoEquipo;
        private Boolean creatividad;
        private Boolean adaptacion;
        private Boolean responsabilidad;
        private Boolean puntualidad;
        private List<ControlTutor> controlesTutorias;

        public int IdInformeMitadPeriodo { get => idInformeMitadPeriodo; set => idInformeMitadPeriodo = value; }
        public string PreparacionTecnica { get => preparacionTecnica; set => preparacionTecnica = value; }
        public string CapacidadAprendizaje { get => capacidadAprendizaje; set => capacidadAprendizaje = value; }
        public bool TrabajoEquipo { get => trabajoEquipo; set => trabajoEquipo = value; }
        public bool Creatividad { get => creatividad; set => creatividad = value; }
        public bool Adaptacion { get => adaptacion; set => adaptacion = value; }
        public bool Responsabilidad { get => responsabilidad; set => responsabilidad = value; }
        public bool Puntualidad { get => puntualidad; set => puntualidad = value; }
        
        internal List<ControlTutor> ControlesTutorias { get => controlesTutorias; set => controlesTutorias = value; }
        public Solicitud Solicitud { get => solicitud; set => solicitud = value; }

        public InformeMitadPeriodo()
        {
            this.solicitud = new Solicitud();
            this.adaptacion = false;
            this.creatividad = false;
            this.puntualidad = false;
        }

        public InformeMitadPeriodo(int idInformeMitadPeriodo, Solicitud solicitud, string preparacionTecnica, string capacidadAprendizaje, bool trabajoEquipo, bool creatividad, bool adaptacion, bool responsabilidad, bool puntualidad, List<ControlTutor> controlesTutorias)
        {
            this.solicitud = new Solicitud();
            this.idInformeMitadPeriodo = idInformeMitadPeriodo;
            this.preparacionTecnica = preparacionTecnica;
            this.capacidadAprendizaje = capacidadAprendizaje;
            this.trabajoEquipo = trabajoEquipo;
            this.creatividad = creatividad;
            this.adaptacion = adaptacion;
            this.responsabilidad = responsabilidad;
            this.puntualidad = puntualidad;
            this.controlesTutorias = controlesTutorias;
            this.Solicitud = solicitud;
        }

        public override string ToString()
        {
            return this.IdInformeMitadPeriodo+" "+this.solicitud.Practicante.NombreUsuario+" "+this.solicitud.Empresa.NombreEmpresa+"(Informe)";
        }
    }
}
