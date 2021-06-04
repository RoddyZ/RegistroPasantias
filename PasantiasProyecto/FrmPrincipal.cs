using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaDatos;
using CapaNegocio;

namespace PasantiasProyecto
{
    public partial class FrmPrincipal : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        Usuario userLocal = new Usuario();
        //Arrastrar formulario
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int wmsg, int wparam, int lparam);
        public FrmPrincipal(Usuario usuario)
        {
            userLocal = usuario;
            InitializeComponent();
        }
          //Ojo
        
        //private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparas, int lparm);

        private void btnOpcione_Click(object sender, EventArgs e)
        {
            if (PnlIzquierdo.Width==239)
            {
                PnlIzquierdo.Width = 97;
            }
            else
            {
                PnlIzquierdo.Width = 239;
            }
                
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();

        }

        private void btnMaximixar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
            btnMinimizar.Visible = true;
            btnMaximixar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimizar.Visible = false;
            btnMaximixar.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Metodo click

        public void AbrirFrm(object frmHijo )
        {
            if (this.PnlContenedor.Controls.Count>0)
            {
                this.PnlContenedor.Controls.RemoveAt(0);
            }
            Form fh = frmHijo as Form;
            fh.TopLevel = false;    //tOP LEVEL infdica si la ventana debe mostrarse como nivel superior
            fh.Dock = DockStyle.Fill;    //para acoplar al panel primario
            this.PnlContenedor.Controls.Add(fh);  //agregamos al contenedor el hijo
            this.PnlContenedor.Tag = fh;    //obtengo los objetos del contenedor
            fh.Show();
        }
        private void btnValidarSolicitud_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmValidarSolicitud());   //le enviamos lo que queremos abrir
        }

        private void btnAdministrarTutor_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmCRUDtutor());
        }

        private void btnVisualizarEstudiante_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmAdministrador());
        }
        private void btnLLenarEncuesta_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmCuestionario(userLocal));
        }

        private void btnVerPasantia_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVerPasantia((Practicante)userLocal, this,2));
        }

        private void btnInformeSemestral_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmCRUDInformeJefe((Jefe)userLocal));
        }

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVerEmpresas(this,(Practicante)userLocal));
        }

        private void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVerPasantia((Practicante)userLocal, this,1));
            //AbrirFrm(new FrmRegistroDeAsistencia((Practicante)userLocal));
        }

        private void btnInformeMitad_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmCRUDInformeMitad((Tutor)userLocal) );
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (userLocal.Login == "admi" && userLocal.Contrasenia == "1234")
            {
                btnAdministrarTutor.Visible = false;
                btnInformeMitad.Visible = false;
                btnInformeSemestral.Visible = false;
                btnLLenarEncuesta.Visible = false;
                btnRegistrarAsistencia.Visible = false;
                btnSolicitud.Visible = false;
                btnValidarSolicitud.Visible = false;
                btnVerPasantia.Visible = false;
                
                
            }
            else
            {

                if (userLocal is Practicante)
                {
                    btnAdministrarTutor.Visible = false;
                    btnInformeMitad.Visible = false;
                    btnInformeSemestral.Visible = false;
                    btnValidarSolicitud.Visible = false;
                    btnAdministracion.Visible = false;
                    btnSolicitud.Location = new Point(10, 160);
                    btnRegistrarAsistencia.Location = new Point(10, 240);
                    btnVerPasantia.Location = new Point(10, 320);
                    btnLLenarEncuesta.Location = new Point(10, 400);
               

                }
                if (userLocal is Decano)
                {
                    btnAdministrarTutor.Visible = false;
                    btnInformeSemestral.Visible = false;
                    btnLLenarEncuesta.Visible = false;
                    btnRegistrarAsistencia.Visible = false;
                    btnSolicitud.Visible = false;
                    btnInformeMitad.Visible = false;
                    btnVerPasantia.Visible = false;
                    btnAdministracion.Visible = false;
                    btnValidarSolicitud.Location = new Point(10, 160);

                }
               
                if (userLocal is Tutor)
                {
                    btnAdministrarTutor.Visible = false;
                    btnInformeSemestral.Visible = false;
                    btnLLenarEncuesta.Visible = false;
                    btnRegistrarAsistencia.Visible = false;
                    btnSolicitud.Visible = false;
                    btnValidarSolicitud.Visible = false;
                    btnVerPasantia.Visible = false;
                    btnAdministracion.Visible = false;
                    btnInformeMitad.Location = new Point(10, 160);

                }
                if (userLocal is Jefe)
                {

                    btnAdministrarTutor.Visible = false;
                    btnInformeMitad.Visible = false;
                    btnLLenarEncuesta.Visible = false;
                    btnRegistrarAsistencia.Visible = false;
                    btnSolicitud.Visible = false;
                    btnValidarSolicitud.Visible = false;
                    btnVerPasantia.Visible = false;
                    btnAdministracion.Visible = false;
                    btnInformeSemestral.Location = new Point(10, 160);
                    
                }
                if (userLocal is JefeDepartamento)
                {
                    MessageBox.Show("Es Jefe de Departamento");

                }

            }


        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sesion cerrada con Exito", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }
    }
}
