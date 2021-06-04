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
    public partial class FrmVerPasantia : Form
    {
        //int idPracticante;
        List<Solicitud> solicituds = new List<Solicitud>();
        Practicante prac = new Practicante();
        int estado;
        FrmPrincipal principal;
        public FrmVerPasantia(Practicante p, FrmPrincipal f, int aux)
        {
            estado = aux;
            principal = f;
            prac= p;
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVerPasantia_Load(object sender, EventArgs e)
        {
            if(estado == 1)
            {

            }
            else
            {
                button1.Visible = false;
            }
           solicituds = DAOSolicitud.ObtenerSolicitud(prac.IdPracticante);
            dgvPasantias.DataSource = solicituds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrmRegistroDeAsistencia frmRegistroDeAsistencia = new FrmRegistroDeAsistencia(prac, SolicitudSeleccionada());
            principal.AbrirFrm(frmRegistroDeAsistencia);
            


        }

        public Solicitud SolicitudSeleccionada() {

            foreach (DataGridViewRow row in this.dgvPasantias.SelectedRows)
            {
                Solicitud sol = row.DataBoundItem as Solicitud;
                if (sol != null)
                {
                    return sol;
                }

            }
            return null;
        }

    }
}
