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
    public partial class FrmVerEmpresas : Form
    {
        List<Empresa> empresas = new List<Empresa>();
        FrmPrincipal frmPrincipal;
        Practicante practicante = new Practicante();

        public FrmVerEmpresas(FrmPrincipal frm,Practicante p)
        {
            InitializeComponent();
            frmPrincipal = frm;
            practicante = p;
        }

        private void FrmVerEmpresas_Load(object sender, EventArgs e)
        {
            empresas = DAOEmpresa.ObtenerListaEmpresas();

            foreach (var item in empresas)
            {
                lstEmpresas.Items.Add(item);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Empresa empresa = (Empresa)lstEmpresas.SelectedItem;
            
            if (empresa != null)
            {
                Console.WriteLine(Convert.ToString(practicante.IdPracticante));
                FrmSolicitud frmSolicitud = new FrmSolicitud(empresa,practicante);
                frmPrincipal.AbrirFrm(frmSolicitud);
            }
            else
            {
                MessageBox.Show("Escoja un Empresa","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }
    }
}
