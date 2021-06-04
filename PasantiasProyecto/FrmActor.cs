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
    public partial class FrmActor : Form
    {
        Usuario usuarioLocal = new Usuario();
        Empresa empresa;
        string tipoLocal;
        int estado;
        public FrmActor(Usuario user, String tipo)
        {
            tipoLocal = tipo;
            estado = 0;
            usuarioLocal = user;
            InitializeComponent();
        }
        public FrmActor(Empresa e, String tipo)
        {
            tipoLocal = tipo;
            estado = 0;
            empresa = e;
            InitializeComponent();
        }

        public FrmActor(String tipo)
        {
            estado = 1;
            tipoLocal = tipo;
            InitializeComponent();
            

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmActor_Load(object sender, EventArgs e)
        {
            switch (tipoLocal)
            {
                case "Practicantes":
                    lblDepartamento.Visible = false;
                    txtDepartamento.Visible = false;
                    lblEstado.Visible = false;
                    cbxEstado.Visible = false;
                    lblDireccion.Visible = false;
                    txtDireccion.Visible = false;
                    lblFax.Visible = false;
                    txtFax.Visible = false;
                    lblDescripcion.Visible = false;
                    txtDescripcion.Visible = false;
                    btnIngresarJefe.Visible = false;
                    if (estado == 0)
                    {
                        Practicante p = (Practicante)usuarioLocal;
                        txtNombre.Text = p.NombreUsuario;
                        txtUserName.Text = p.Login;
                        txtContrasenia.Text = p.Contrasenia;
                        txtCedula.Text = p.Cedula;
                        txtTelefono.Text = p.Telefono;
                        txtCorreo.Text = p.CorreoElectronico;
                        dtpFechaNacimiento.Value = p.FechaNacimiento;
                        txtCreditosAprobados.Text = Convert.ToString(p.CreditosAprobados);
                        txtCarrera.Text = p.Carrera;
                    }
                    break;
                case "Tutores":
                    lblFechaNacimiento.Visible = false;
                    lblCarrera.Visible = false;
                    lblCreditosAprobados.Visible = false;
                    dtpFechaNacimiento.Visible = false;
                    txtCarrera.Visible = false;
                    txtCreditosAprobados.Visible = false;
                    lblEstado.Visible = false;
                    cbxEstado.Visible = false;
                    lblDireccion.Visible = false;
                    txtDireccion.Visible = false;
                    lblFax.Visible = false;
                    txtFax.Visible = false;
                    lblDescripcion.Visible = false;
                    txtDescripcion.Visible = false;
                    btnIngresarJefe.Visible = false;
                    if (estado == 0)
                    {
                        Tutor t = (Tutor)usuarioLocal;
                        txtNombre.Text = t.NombreUsuario;
                        txtUserName.Text = t.Login;
                        txtContrasenia.Text = t.Contrasenia;
                        txtCedula.Text = t.Cedula;
                        txtTelefono.Text = t.Telefono;
                        txtCorreo.Text = t.CorreoElectronico;
                        txtDepartamento.Text = t.Departamento;
                        

                    }

                    break;
                case "Decanos":
                    lblFechaNacimiento.Visible = false;
                    lblCarrera.Visible = false;
                    lblCreditosAprobados.Visible = false;
                    dtpFechaNacimiento.Visible = false;
                    txtCarrera.Visible = false;
                    txtCreditosAprobados.Visible = false;
                    lblDepartamento.Visible = false;
                    txtDepartamento.Visible = false;
                    lblDireccion.Visible = false;
                    txtDireccion.Visible = false;
                    lblFax.Visible = false;
                    txtFax.Visible = false;
                    lblDescripcion.Visible = false;
                    txtDescripcion.Visible = false;
                    btnIngresarJefe.Visible = false;
                    if (estado == 0)
                    {
                        Decano d = (Decano)usuarioLocal;
                        txtNombre.Text = d.NombreUsuario;
                        txtUserName.Text = d.Login;
                        txtContrasenia.Text = d.Contrasenia;
                        txtCedula.Text = d.Cedula;
                        txtTelefono.Text = d.Telefono;
                        txtTelefono.Text = d.Telefono;
                        txtCorreo.Text = d.CorreoElectronico;
                        cbxEstado.Text = Convert.ToString(d.Activo);
                    }
                    break;
                case "Jefes":
                    lblFechaNacimiento.Visible = false;
                    lblCarrera.Visible = false;
                    lblCreditosAprobados.Visible = false;
                    dtpFechaNacimiento.Visible = false;
                    txtCarrera.Visible = false;
                    txtCreditosAprobados.Visible = false;
                    lblDepartamento.Visible = false;
                    txtDepartamento.Visible = false;
                    lblEstado.Visible = false;
                    cbxEstado.Visible = false;
                    lblDireccion.Visible = false;
                    txtDireccion.Visible = false;
                    lblFax.Visible = false;
                    txtFax.Visible = false;
                    lblDescripcion.Visible = false;
                    txtDescripcion.Visible = false;
                    btnIngresarJefe.Visible = false;
                    if (estado == 0)
                    {
                        Jefe j = (Jefe)usuarioLocal;
                        txtNombre.Text = j.NombreUsuario;
                        txtUserName.Text = j.Login;
                        txtContrasenia.Text = j.Contrasenia;
                        txtCedula.Text = j.Cedula;
                        txtTelefono.Text = j.Telefono;
                        txtTelefono.Text = j.Telefono;
                        txtCorreo.Text = j.CorreoElectronico;
                    }
                    break;
                case "Empresas":
                    lblFechaNacimiento.Visible = false;
                    lblCarrera.Visible = false;
                    lblCreditosAprobados.Visible = false;
                    dtpFechaNacimiento.Visible = false;
                    txtCarrera.Visible = false;
                    txtCreditosAprobados.Visible = false;
                    lblDepartamento.Visible = false;
                    txtDepartamento.Visible = false;
                    lblEstado.Visible = false;
                    cbxEstado.Visible = false;
                    lblNombreUsuario.Visible = false;
                    txtUserName.Visible = false;
                    lblContrasenia.Visible = false;
                    txtContrasenia.Visible = false;
                    lblCedula.Visible = false;
                    txtCedula.Visible = false;
                    if (estado == 0)
                    {
                        txtNombre.Text = empresa.NombreEmpresa;
                        txtDescripcion.Text = empresa.Descripcion;
                        txtDireccion.Text = empresa.Descripcion;
                        txtFax.Text = empresa.Fax;
                        txtTelefono.Text = empresa.Telefono;
                        txtCorreo.Text = empresa.CorreoElectronico;
                    }

                    break;
                default:
                    break;
            }
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tipoLocal)
                {
                    case "Practicantes":
                        if (estado == 1)
                        {
                            Practicante practicante = new Practicante(txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text, dtpFechaNacimiento.Value, Convert.ToInt32(txtCreditosAprobados.Text), txtCarrera.Text, null, null);
                            DAOPracticante.IngresarPracticante(practicante);
                            this.Close();
                        }
                        else
                        {

                            Practicante practicante = new Practicante(txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text, dtpFechaNacimiento.Value, Convert.ToInt32(txtCreditosAprobados.Text), txtCarrera.Text, null, null);
                            practicante.IdPracticante = ((Practicante)usuarioLocal).IdPracticante;
                            DAOPracticante.EditarPracticante(practicante);
                            this.Close();
                        }
                        break;
                    case "Tutores":
                        if (estado == 1)
                        {
                            Tutor tutor = new Tutor(0, txtDepartamento.Text, 0, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            DAOTutor1.IngresarTutor(tutor);
                            this.Close();
                        }
                        else
                        {
                            Tutor tutor = new Tutor(0, txtDepartamento.Text, 0, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            tutor.IdTutor = ((Tutor)usuarioLocal).IdTutor;
                            DAOTutor1.IngresarTutor(tutor);
                            this.Close();
                        }
                        break;
                    case "Decanos":
                        if (estado == 1)
                        {
                            bool activo;
                            if (cbxEstado.Text == "Activo")
                            {
                                activo = true;
                            }
                            else
                            {
                                activo = false;
                            }
                            Decano decano = new Decano(activo, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            DAODecano.IngresarDecano(decano);
                            this.Close();
                        }
                        else
                        {
                            bool activo;
                            if (cbxEstado.Text == "Activo")
                            {
                                activo = true;
                            }
                            else
                            {
                                activo = false;
                            }
                            Decano decano = new Decano(activo, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            decano.IdDecano = ((Decano)usuarioLocal).IdDecano;
                            DAODecano.EditarDecano(decano);
                            this.Close();
                        }
                        break;
                    case "Jefes":
                        if (estado == 1)
                        {
                            Jefe jefe = new Jefe(0, 0, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            DAOJefe.IngresarJefe(jefe);
                            this.Close();
                        }
                        else
                        {
                            Jefe jefe = new Jefe(0, 0, txtNombre.Text, txtContrasenia.Text, txtUserName.Text, txtCedula.Text, txtTelefono.Text, txtCorreo.Text);
                            jefe.IdJefe = ((Jefe)usuarioLocal).IdJefe;
                            DAOJefe.EditarJefe(jefe);
                            this.Close();
                        }
                        break;
                    case "Empresas":
                        if (estado == 1)
                        {
                            Empresa em = new Empresa(0, txtNombre.Text, txtDireccion.Text, txtDescripcion.Text, txtCorreo.Text, txtTelefono.Text, txtFax.Text);
                            int idJefe = DAOJefe.recuperarUltimoJefe();
                            DAOEmpresa.ingresarEmpresa(em, idJefe);
                            this.Close();
                        }
                        else
                        {

                            Empresa em = new Empresa(0, txtNombre.Text, txtDireccion.Text, txtDescripcion.Text, txtCorreo.Text, txtTelefono.Text, txtFax.Text);
                            em.IdEmpresa = empresa.IdEmpresa;
                            DAOEmpresa.EditarEmpresa(em);
                            this.Close();
                        }

                        break;
                    default:
                        break;
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error al ingresar datos", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresarJefe_Click(object sender, EventArgs e)
        {
            FrmActor frm = new FrmActor("Jefes");
            frm.ShowDialog();


        }

        private void FrmActor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
