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
    public partial class FrmAdministrador : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        List<Practicante> practicantes = new List<Practicante>();
        List<Tutor> tutores = new List<Tutor>();
        List<Jefe> jefes = new List<Jefe>();
        List<Decano> decanos = new List<Decano>();
        List<Empresa> empresas = new List<Empresa>();
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVisualizarEstudiante_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            
            
        }

        public void cargarUsuarios()
        {
            usuarios.Clear();
            practicantes.Clear();
            decanos.Clear();
            tutores.Clear();
            jefes.Clear();
            empresas.Clear();
            usuarios = DAOUsuario.obtenerUsuarios();
            empresas = DAOEmpresa.ObtenerEmpresas();
            foreach (var i in usuarios)
            {
                if (i is Practicante)
                {

                    practicantes.Add((Practicante)i);
                    
                }
                if (i is Tutor)
                {

                    tutores.Add((Tutor)i);
                }
                if (i is Decano)
                {

                    decanos.Add((Decano)i);
                }
                if (i is Jefe)
                {

                    jefes.Add((Jefe)i);
                }
            }
            dgvEstudiante.DataSource = null;
            if (cbxTipoUsuario.Text == "Practicantes")
            {
                dgvEstudiante.DataSource = practicantes;
            }
            if (cbxTipoUsuario.Text == "Tutores")
            {
                dgvEstudiante.DataSource = tutores;
            }
            if (cbxTipoUsuario.Text == "Decanos")
            {
                dgvEstudiante.DataSource = decanos;
            }
            if (cbxTipoUsuario.Text == "Jefes")
            {
                dgvEstudiante.DataSource = jefes;
            }
            if (cbxTipoUsuario.Text == "Empresas")
            {
                dgvEstudiante.DataSource = empresas;
            }
        }
        private void cbxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTipoUsuario.Text == "Practicantes")
            {
                dgvEstudiante.DataSource = practicantes;
            }
            if (cbxTipoUsuario.Text == "Tutores")
            {
                dgvEstudiante.DataSource = tutores;
            }
            if (cbxTipoUsuario.Text == "Decanos")
            {
                dgvEstudiante.DataSource = decanos;
            }
            if (cbxTipoUsuario.Text == "Jefes")
            {
                dgvEstudiante.DataSource = jefes;
            }
            if (cbxTipoUsuario.Text == "Empresas")
            {
                dgvEstudiante.DataSource = empresas;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            
            String tipo = ValidarComboBox();
            if (tipo == "")
            {
                MessageBox.Show("Seleccione un apartado valido", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmActor frmActor = new FrmActor(tipo);
                frmActor.ShowDialog();
                cargarUsuarios();

            }

        }

        
        public string ValidarComboBox()
        {
            if (cbxTipoUsuario.Text == "Practicantes")
            {
                return "Practicantes";
            }
            if (cbxTipoUsuario.Text == "Tutores")
            {
                return "Tutores";
            }
            if (cbxTipoUsuario.Text == "Decanos")
            {
                return "Decanos";
            }
            if (cbxTipoUsuario.Text == "Jefes")
            {
                return "Jefes";
            }
            if(cbxTipoUsuario.Text == "Empresas")
            {
                return "Empresas";
            }
            else
            {
                return "";
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cbxTipoUsuario.Text == "Empresas")
            {
                foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                {
                    Empresa emp = row.DataBoundItem as Empresa;
                    if (emp != null)
                    {

                        FrmActor frmActor = new FrmActor(emp, ValidarComboBox());
                        frmActor.ShowDialog();
                        cargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una empresa", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                {
                    Usuario user = row.DataBoundItem as Usuario;
                    if (user != null)
                    {

                        FrmActor frmActor = new FrmActor(user, ValidarComboBox());
                        frmActor.ShowDialog();
                        cargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un usuario valido", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String tipo = ValidarComboBox();
            switch (tipo)
            {
                case "Practicantes":
                    foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                    {
                        Practicante prac = row.DataBoundItem as Practicante;
                        if (prac != null)
                        {
                            DAOPracticante.EliminarPracticante(prac.IdPracticante);
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Practicante valido", "Pasantia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "Tutores":
                    foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                    {
                        Tutor tutor = row.DataBoundItem as Tutor;
                        if (tutor != null)
                        {
                            DAOTutor1.EliminarTutor(tutor.IdTutor);
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Tutor valido", "Pasantia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "Decanos":
                    foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                    {
                        Decano decano = row.DataBoundItem as Decano;
                        if (decano != null)
                        {
                            DAODecano.EliminarDecano(decano.IdDecano);
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Decano valido", "Pasantia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "Jefes":
                    foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                    {
                        Jefe jefe = row.DataBoundItem as Jefe;
                        if (jefe != null)
                        {
                            DAOJefe.EliminarJefe(jefe.IdJefe);
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Jefe valido", "Pasantia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "Empresas":
                    foreach (DataGridViewRow row in this.dgvEstudiante.SelectedRows)
                    {
                        Empresa empresa = row.DataBoundItem as Empresa;
                        if (empresa != null)
                        {
                            DAOEmpresa.EliminarEmpresa(empresa.IdEmpresa);
                            cargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Empresa valido", "Pasantia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
