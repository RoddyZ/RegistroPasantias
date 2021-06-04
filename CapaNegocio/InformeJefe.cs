using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class InformeJefe
    {
        private int idInformeJefe;
        private string areaAsignada;
        private string actividadesDesarrolladas;
        private string horario;
        private string fortalezas;
        private string debilidades;
        private string evaluacion;
        private string desempenio;
        private string motivacion;
        private bool contactoTutor;
        private Solicitud solicitud;
        private Tutor tutor;
        private RegistroAsistencia registroAsistencia;
        private Jefe jefe;

        public InformeJefe()
        {
            Solicitud = new Solicitud();
            Tutor = new Tutor();
            RegistroAsistencia = new RegistroAsistencia();
            Jefe = new Jefe();
        }

        public InformeJefe(int idInformeJefe, string areaAsignada, string actividadesDesarrolladas, string horario, string fortalezas, string debilidades, string evaluacion, string desempenio, string motivacion, bool contactoTutor, Solicitud solicitud, Tutor tutor, RegistroAsistencia registroAsistencia, Jefe jefe)
        {
            this.IdInformeJefe = idInformeJefe;
            this.AreaAsignada = areaAsignada;
            this.ActividadesDesarrolladas = actividadesDesarrolladas;
            this.Horario = horario;
            this.Fortalezas = fortalezas;
            this.Debilidades = debilidades;
            this.Evaluacion = evaluacion;
            this.Desempenio = desempenio;
            this.Motivacion = motivacion;
            this.ContactoTutor = contactoTutor;
            this.Solicitud = solicitud;
            this.Tutor = tutor;
            this.RegistroAsistencia = registroAsistencia;
            this.Jefe = jefe;
        }

        public int IdInformeJefe { get => idInformeJefe; set => idInformeJefe = value; }
        public string AreaAsignada { get => areaAsignada; set => areaAsignada = value; }
        public string ActividadesDesarrolladas { get => actividadesDesarrolladas; set => actividadesDesarrolladas = value; }
        public string Horario { get => horario; set => horario = value; }
        public string Fortalezas { get => fortalezas; set => fortalezas = value; }
        public string Debilidades { get => debilidades; set => debilidades = value; }
        public string Evaluacion { get => evaluacion; set => evaluacion = value; }
        public string Desempenio { get => desempenio; set => desempenio = value; }
        public string Motivacion { get => motivacion; set => motivacion = value; }
        public bool ContactoTutor { get => contactoTutor; set => contactoTutor = value; }
        public Solicitud Solicitud { get => solicitud; set => solicitud = value; }
        public Tutor Tutor { get => tutor; set => tutor = value; }
        public RegistroAsistencia RegistroAsistencia { get => registroAsistencia; set => registroAsistencia = value; }
        public Jefe Jefe { get => jefe; set => jefe = value; }

        public override string ToString()
        {
            return this.idInformeJefe + ".- " + solicitud.Practicante.NombreUsuario+"(Informe)";
        }
    }
}
