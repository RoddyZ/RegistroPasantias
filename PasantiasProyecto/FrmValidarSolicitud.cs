using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
namespace PasantiasProyecto
{
    public partial class FrmValidarSolicitud : Form
    {
        public FrmValidarSolicitud()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmValidarSolicitud_Load(object sender, EventArgs e)
        {

            Actualizar();
           // DAOSolicitud.ValidarSolicitud(3, 1);
        }


        private void Actualizar()
        {
            lstPasantias.Items.Clear();
            foreach (var i in DAOSolicitud.TodasSolicitudes())
            {
                if (i.EstadoSolicitud == "1")
                {
                    i.EstadoSolicitud = "Aprobado";
                }
                else if (i.EstadoSolicitud == "0")
                {
                    i.EstadoSolicitud = "Espera";
                }
                lstPasantias.Items.Add(i);
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            

            if (lstPasantias.SelectedItem != null && ((Solicitud)lstPasantias.SelectedItem).EstadoSolicitud=="Espera")

            {
                if (MessageBox.Show("Desea Aprobar esta Solicitud?", "Solicitud Pasantias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (((Solicitud)lstPasantias.SelectedItem).Practicante.Tutor == null )
                    {
                        Solicitud solicitud = (Solicitud)lstPasantias.SelectedItem;
                        FrmAsignarTutor frmAsignarTutor = new FrmAsignarTutor(solicitud.Practicante.IdPracticante);
                        
                        frmAsignarTutor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Este practicante ya tiene tutor", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    DAOSolicitud.ValidarSolicitud(((Solicitud)lstPasantias.SelectedItem).IdSolicitud, 1);
                    DAORegistroAsistencia.crearRegistro(1, DateTime.Now, DateTime.Now, "2018-B", ((Solicitud)lstPasantias.SelectedItem).IdSolicitud);


                    Actualizar();
                }
               

            }
            else if (lstPasantias.SelectedItem != null && ((Solicitud)lstPasantias.SelectedItem).EstadoSolicitud == "Aprobado")
            {
                MessageBox.Show("Esta Solicitud ya esta Aprobada", "Solicitud Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Porfavor escoga una Solicitud", "Solicitud Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Actualizar();
        }
    }
}
