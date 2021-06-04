using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Encuesta
    {
        private int idEncuesta;
        private List<int> preguntas;
        private Practicante practicante;
        private String comentariosSugerencias;

        public int IdEncuesta { get => idEncuesta; set => idEncuesta = value; }
        public List<int> Preguntas { get => preguntas; set => preguntas = value; }
        public string ComentariosSugerencias { get => comentariosSugerencias; set => comentariosSugerencias = value; }
        internal Practicante Practicante { get => practicante; set => practicante = value; }

        public Encuesta(int idEncuesta, List<int> preguntas, Practicante practicante, string comentariosSugerencias)
        {
            this.idEncuesta = idEncuesta;
            this.preguntas = preguntas;
            this.practicante = practicante;
            this.comentariosSugerencias = comentariosSugerencias;
        }

        public Encuesta()
        {
        }

        public override string ToString()
        {
            return this.IdEncuesta+" ";
        }
    }
}
