using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Practicante : Usuario
    {
        private int idPracticante;
        private DateTime fechaNacimiento;
        private int creditosAprobados;
        private string carrera;
        private Tutor tutor;
        private Jefe jefe;

        public int IdPracticante { get => idPracticante; set => idPracticante = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int CreditosAprobados { get => creditosAprobados; set => creditosAprobados = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public Tutor Tutor { get => tutor; set => tutor = value; }
        public Jefe Jefe { get => jefe; set => jefe = value; }

        public Practicante(int idUsuario, string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo, int idPracticante, DateTime fechaNacimiento, int creditosAprobados, string carrera, Tutor tutor, Jefe jefe) : base(idUsuario, nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            this.idPracticante = idPracticante;
            this.fechaNacimiento = fechaNacimiento;
            this.creditosAprobados = creditosAprobados;
            this.carrera = carrera;
            this.tutor = tutor;
            this.jefe = jefe;
        }

        public Practicante(string nombreUsuario, string contrasenia, string login, string cedula, string telefono, string correo, DateTime fechaNacimiento, int creditosAprobados, string carrera, Tutor tutor, Jefe jefe) : base(0,nombreUsuario, contrasenia, login, cedula, telefono, correo)
        {
            
            this.fechaNacimiento = fechaNacimiento;
            this.creditosAprobados = creditosAprobados;
            this.carrera = carrera;
            this.tutor = tutor;
            this.jefe = jefe;
        }

        public Practicante()
        {
        }

        public override string ToString()
        {
            return this.IdPracticante+" "+this.NombreUsuario+" "+this.CreditosAprobados;
        }
    }
}
