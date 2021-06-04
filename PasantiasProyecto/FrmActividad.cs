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
using System.Runtime.InteropServices;

namespace PasantiasProyecto
{
    public partial class FrmActividad : Form
    {
        Practicante prac = new Practicante();
        Empresa emp = new Empresa();
        Actividad act;
        DateTime ultimaFecha;
        int estado;
        public FrmActividad(Empresa empresa, Practicante practicante, DateTime ultiFecha)
        {
            ultimaFecha = ultiFecha;
            estado = 1;
            emp = empresa;
            prac = practicante;
            InitializeComponent();
        }

        public FrmActividad(Empresa empresa, Practicante practicante, Actividad actividad, DateTime ultiFecha)
        {
            ultimaFecha = ultiFecha;
            estado = 0;
            act = actividad;
            emp = empresa;
            prac = practicante;
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void btnGuardar_Click(object sender, EventArgs e)
        {
                TimeSpan diferencia;
                diferencia = (dtpFin.Value).Subtract(dtpInicio.Value);

            


            if (diferencia.TotalHours <= 8)
            {
                if (dtpInicio.Value > ultimaFecha)
                {
                    if (estado == 1)
                    {

                        Actividad ac = new Actividad(dtpInicio.Value, dtpFin.Value, (float)(diferencia.TotalHours));
                        DAOActividad.IngresarAsistencia(DAOActividad.RecuperarIDRegistro(prac.IdPracticante, emp.IdEmpresa), ac);
                        this.Close();
                    }
                    else
                    {
                        Actividad ac = new Actividad(dtpInicio.Value, dtpFin.Value, (float)(diferencia.TotalHours));
                        ac.IdActividad = act.IdActividad;
                        DAOActividad.EditarAsistencia(ac);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No puede realizar una jornada dentro de otra", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Horas de trabajo exedidas", "Pasanttias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            
            

                
        }

        private void FrmActividad_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmActividad_Load(object sender, EventArgs e)
        {
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd-MM-yyyy HH:mm ";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "dd-MM-yyyy HH:mm ";

            if(estado == 0)
            {
                
                dtpInicio.Value = act.FechaInicio;
                dtpFin.Value = act.FechaFin;
            }
        }
    }
}
