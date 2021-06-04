using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;

namespace PasantiasProyecto
{
    public partial class FrmRegistroDeAsistencia : Form
    {
        Practicante prac = new Practicante();
        Empresa emp = new Empresa();
        List<Actividad> actividads = new List<Actividad>();
        Solicitud solicitud;
        DateTime ultimaFecha;
        
        public FrmRegistroDeAsistencia(Practicante practicante, Solicitud sol)
        {
            
            emp = sol.Empresa;
            prac = practicante;
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FrmActividad frmActividad = new FrmActividad(emp,prac,ultimaFecha);
            frmActividad.ShowDialog();
            actualizarDATA();
        }

        private void FrmRegistroDeAsistencia_Load(object sender, EventArgs e)
        {
            dtpFehcaInicio.Format = DateTimePickerFormat.Custom;
            dtpFehcaInicio.CustomFormat = "dd-MM-yyyy hh:mm tt";
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = "dd-MM-yyyy hh:mm tt";
            txtHorasRealizadas.Enabled = false;
            dtpFehcaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            actualizarDATA();
            Console.WriteLine(emp.IdEmpresa + "" + prac.IdPracticante);
        }

        public void ActualizarHoras()
        {

            try {
                float horasTotales = 0;
                foreach (var i in actividads)
                {
                    horasTotales = horasTotales + i.NumHoras;
                }
                DateTime finalizacion;
                DateTime inicio;
                inicio = finalizacion = actividads[0].FechaInicio;
                foreach (var i in actividads)
                {
                    if (i.FechaInicio < inicio)
                    {
                        inicio = i.FechaInicio;

                    }
                    if (i.FechaFin > finalizacion)
                    {
                        finalizacion = i.FechaFin;

                    }
                }

                dtpFehcaInicio.Value = inicio;
                dtpFechaFin.Value = finalizacion;
                ultimaFecha = finalizacion;

                txtHorasRealizadas.Text = Convert.ToString(horasTotales);
                DAORegistroAsistencia.actualizarHorastotales(prac.IdPracticante, horasTotales, inicio, finalizacion);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
            
        }

        public void actualizarDATA()
        {
            dgvActividades.DataSource = null;
            actividads = DAOActividad.RecuperarAsistencia(prac.IdPracticante, emp.IdEmpresa);
            dgvActividades.DataSource = actividads;
            ActualizarHoras();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvActividades.SelectedRows)
            {
                Actividad act = row.DataBoundItem as Actividad;
                if (act != null)
                {
                    FrmActividad frmActividad = new FrmActividad(emp, prac, act,ultimaFecha);
                    frmActividad.ShowDialog();
                    actualizarDATA();
                }
                else
                {
                    MessageBox.Show("Seleccione una actividad", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            actualizarDATA();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvActividades.SelectedRows)
            {
                Actividad act = row.DataBoundItem as Actividad;
                if (act != null)
                {
                    DAOActividad.EliminarActividad(act);
                    actualizarDATA();
                }
                else
                {
                    MessageBox.Show("Seleccione una actividad", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
