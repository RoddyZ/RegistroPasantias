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
    public partial class FrmCRUDInformeMitad : Form
    {
        Tutor tutor = new Tutor();
        List<Solicitud> solicituds = new List<Solicitud>();
        List<InformeMitadPeriodo> informeMitad = new List<InformeMitadPeriodo>();
        public FrmCRUDInformeMitad(Tutor t)
        {
            InitializeComponent();
            tutor = t;
        }

        private void FrmCRUDInformeMitad_Load(object sender, EventArgs e)
        {
            //tutor.IdTutor = 1;
            solicituds=DAOTUTOR.ObtenerListaPracticantes(tutor);
            foreach (var item in solicituds)
            {
                lstSolicitud.Items.Add(item);
            }
           
            CargarInformes();
        }

        private void CargarInformes()
        {
            lstInformeMitad.Items.Clear();
            informeMitad = DAOTUTOR.ObtenerInformesMitadPeriodo(tutor);
            foreach (var item in informeMitad)
            {
                lstInformeMitad.Items.Add(item);
            }
        }

        private void btnCrearInforme_Click(object sender, EventArgs e)
        {
            Solicitud s = (Solicitud)lstSolicitud.SelectedItem;
            if (s==null)
            {
                MessageBox.Show("Escoja un Practicante","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeMitad frmInformeMitad = new FrmInformeMitad(s, tutor,new InformeMitadPeriodo(),"crear");
                frmInformeMitad.ShowDialog();
                CargarInformes();
            }
            
           
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            InformeMitadPeriodo i = (InformeMitadPeriodo)lstInformeMitad.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeMitad frmInformeMitad = new FrmInformeMitad(new Solicitud(), tutor, i, "ver");
                frmInformeMitad.ShowDialog();
                
            }


        }

        private void btnEliminarInforme_Click(object sender, EventArgs e)
        {
            InformeMitadPeriodo i = (InformeMitadPeriodo)lstInformeMitad.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe a Eliminar", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Esta Seguro de Eliminar el Informe","Pasantias",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    if (DAOTUTOR.BorrarInforme(i) > 0) MessageBox.Show("Informe Borrado","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else MessageBox.Show("Fallo");
                    
                }
            }
            CargarInformes();
        }

        private void btnEditarInforme_Click(object sender, EventArgs e)
        {
            InformeMitadPeriodo i = (InformeMitadPeriodo)lstInformeMitad.SelectedItem;
            if (i == null)
            {
                MessageBox.Show("Escoja un Informe", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeMitad frmInformeMitad = new FrmInformeMitad(new Solicitud(), tutor, i, "editar");
                frmInformeMitad.ShowDialog();
                CargarInformes();
            }
        }
    }
}
