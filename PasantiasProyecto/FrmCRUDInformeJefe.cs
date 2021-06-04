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
    public partial class FrmCRUDInformeJefe : Form
    {
        Jefe jefe = new Jefe();
        List<Solicitud> solicituds = new List<Solicitud>();
        List<InformeJefe> informeJefe = new List<InformeJefe>();

        public FrmCRUDInformeJefe(Jefe j)
        {
            InitializeComponent();
            jefe = j;
        }

        private void FrmCRUDInformeJefe_Load(object sender, EventArgs e)
        {
            //jefe.IdJefe = 1;
            solicituds = DAOJefe.ObtenerListaPracticantes(jefe);
            foreach (var item in solicituds)
            {
                lstSolicitud.Items.Add(item);
            }

            CargarInformes();
        }
        private void CargarInformes()
        {
            lstInformesJefe.Items.Clear();
            informeJefe = DAOJefe.ObtenerInformesJefe(jefe);
            foreach (var item in informeJefe)
            {
                lstInformesJefe.Items.Add(item);
            }
        }

        private void btnCrearInforme_Click(object sender, EventArgs e)
        {
            Solicitud s = (Solicitud)lstSolicitud.SelectedItem;
            if (s == null)
            {
                MessageBox.Show("Escoja un Practicante", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeJefe frmInformeJefe = new FrmInformeJefe(s,jefe, new InformeJefe(), "crear");
                frmInformeJefe.ShowDialog();
                CargarInformes();
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            InformeJefe i = (InformeJefe)lstInformesJefe.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeJefe frmInformeJefe = new FrmInformeJefe(new Solicitud(), jefe, i, "ver");
                frmInformeJefe.ShowDialog();

            }
        }

        private void btnEliminarInforme_Click(object sender, EventArgs e)
        {
            InformeJefe i = (InformeJefe)lstInformesJefe.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe a Eliminar", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result =MessageBox.Show("Esta seguro de eliminar el Informe Seleccionado","Pasantias",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (DAOJefe.BorrarInforme(i) > 0) MessageBox.Show("Informe Eliminado","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else MessageBox.Show("Fallo");
                    CargarInformes();
                }
            }
        }

        private void btnEditarInforme_Click(object sender, EventArgs e)
        {
            InformeJefe i = (InformeJefe)lstInformesJefe.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeJefe frmInformeJefe = new FrmInformeJefe(new Solicitud(), jefe, i, "editar");
                frmInformeJefe.ShowDialog();
                CargarInformes();
            }
        }
    }
}
