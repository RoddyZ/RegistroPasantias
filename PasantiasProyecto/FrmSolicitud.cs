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
    public partial class FrmSolicitud : Form
    {
        Empresa empresa = new Empresa();
        Practicante practicante = new Practicante();
        Decano decano1 = new Decano();
        public FrmSolicitud(Empresa e,Practicante p )
        {
            InitializeComponent();
            empresa = e;
            practicante = p;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSolicitud_Load(object sender, EventArgs e)
        {
            
        }   

        private void FrmSolicitud_Load_1(object sender, EventArgs e)
        {
            Decano decano = DAODecano.ObtenerDecanoActivo();
            decano1 = decano;
            txtDecano.Text = decano.NombreUsuario;
            txtNombreEstudiante.Text = practicante.NombreUsuario;
            txtCarreraPracticante.Text = practicante.Carrera;
            txtCedulaPracticante.Text = practicante.Cedula;
            txtNombreEmpresa.Text = empresa.NombreEmpresa;
            txtCorreoEmpresa.Text = empresa.CorreoElectronico;
            txtTelefono.Text = empresa.Telefono;
            txtFax.Text = empresa.Fax;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta Seguro de Enviar la Solicitud","Pasantias",MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                practicante.IdPracticante = practicante.IdPracticante;
                Solicitud solicitud = new Solicitud();
                solicitud.DescripcionSolicitud = "";
                solicitud.FechaEmision = DateTime.Now;
                solicitud.EstadoSolicitud = "0";
                solicitud.Empresa = empresa;
                solicitud.Practicante = practicante;
                solicitud.Decano = decano1;
                if (DAOSolicitud.CrearSolicitud(solicitud)>0)
                {
                    MessageBox.Show("Solicitud Registrada","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Ocurrido","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

            this.Close();
        }
    }
}
