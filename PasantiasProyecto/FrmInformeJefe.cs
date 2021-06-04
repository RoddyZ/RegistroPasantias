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
    public partial class FrmInformeJefe : Form
    {

        Solicitud pasantia;
        Jefe jefe = new Jefe();
        InformeJefe informe = new InformeJefe();
        String opcion;
        RegistroAsistencia registro = new RegistroAsistencia();
        Tutor tutor = new Tutor();

        public FrmInformeJefe(Solicitud s, Jefe j, InformeJefe i, String op)
        {
            InitializeComponent();
            pasantia = s;
            jefe = j;
            informe = i;
            opcion = op;
        }
        private void FrmInformeJefe_Load(object sender, EventArgs e)
        {
            registro = DAOJefe.ObtenerRegistroAsistenciaPracticante(pasantia);
            tutor = DAOJefe.ObtenerTutorPracticante(pasantia);
            if (opcion.Equals("crear"))
            {
                CargarEncabezado();
            }

            if (opcion.Equals("ver"))
            {
                btnGuardar.Visible = false;
                btnCancelar.Text = "Salir";
                DeshabilitarTextospoDefectoVer();
                CargarInforme();
            }
            if (opcion.Equals("editar"))
            {
                CargarInforme();
                DeshabilitarTextospoDefectoCrearEditar();
            }
      
        }
        private void CargarInforme()
        {
            txtnombreEmpresa.Text = informe.Solicitud.Empresa.NombreEmpresa;
            txtDireccion.Text = informe.Solicitud.Empresa.Direccion;
            txtTelefono.Text = informe.Solicitud.Empresa.Telefono;
            txtFax.Text = informe.Solicitud.Empresa.Fax;
            txtCorreo.Text = informe.Solicitud.Empresa.CorreoElectronico;
            txtNombrePracticante.Text = informe.Solicitud.Practicante.NombreUsuario;
            txtCarrera.Text = informe.Solicitud.Practicante.Carrera;
            txtCedula.Text = informe.Solicitud.Practicante.Cedula;
            txtFechaFin.Text =informe.RegistroAsistencia.FechaFin.ToString("MM/dd/yy");
            txtFechaInicio.Text = informe.RegistroAsistencia.FechaInicio.ToString("MM/dd/yy");
            txtPeriodo.Text = informe.RegistroAsistencia.PeriodoAcademico;
            txtNumeroHoras.Text = informe.RegistroAsistencia.HorasRealizadas.ToString();
            txtNombreTutor.Text = informe.Tutor.NombreUsuario;
            txtAreaAsignada.Text = informe.AreaAsignada;
            txtHorario.Text = informe.Horario;
            txtActividadesDesarolladas.Text = informe.AreaAsignada;
            txtFortalezas.Text = informe.Fortalezas;
            txtDebilidades.Text = informe.Debilidades;
            cbxAsitencia.Text = informe.Evaluacion;
            cbxMotivacion.Text = informe.Motivacion;
            cbxDesempeño.Text = informe.Desempenio;
            Tutor t = DAOJefe.ObtenerTutorPracticante(informe.Solicitud);
            txtNombreTutor.Text = t.NombreUsuario;
            if (informe.ContactoTutor) rbContactoTutorSI.Checked = true;
            else rbContactoTutorNO.Checked = true;
           

        }
        private void CargarEncabezado()
        {
            txtnombreEmpresa.Text = pasantia.Empresa.NombreEmpresa;
            txtDireccion.Text = pasantia.Empresa.Direccion;
            txtTelefono.Text = pasantia.Empresa.Telefono;
            txtFax.Text = pasantia.Empresa.Fax;
            txtCorreo.Text = pasantia.Empresa.CorreoElectronico;
            txtNombrePracticante.Text = pasantia.Practicante.NombreUsuario;
            txtCarrera.Text = pasantia.Practicante.Carrera;
            txtCedula.Text = pasantia.Practicante.Cedula;
            txtFechaFin.Text = registro.FechaFin.ToString("MM/dd/yy");
            txtFechaInicio.Text = registro.FechaInicio.ToString("MM/dd/yy");
            txtPeriodo.Text = registro.PeriodoAcademico;
            txtNumeroHoras.Text = registro.HorasRealizadas.ToString();
            txtNombreTutor.Text = tutor.NombreUsuario;
            DeshabilitarTextospoDefectoCrearEditar();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case "crear":
                    informe.AreaAsignada = txtAreaAsignada.Text;
                    informe.Horario = txtHorario.Text;
                    informe.ActividadesDesarrolladas = txtActividadesDesarolladas.Text;
                    informe.Fortalezas = txtFortalezas.Text;
                    informe.Debilidades = txtDebilidades.Text;
                    if (cbxAsitencia.SelectedIndex!=-1) informe.Evaluacion = cbxAsitencia.SelectedItem.ToString();
                    if (cbxMotivacion.SelectedIndex != -1) informe.Motivacion = cbxMotivacion.SelectedItem.ToString();
                    if (cbxDesempeño.SelectedIndex != -1) informe.Desempenio = cbxDesempeño.SelectedItem.ToString();
                    informe.Solicitud = pasantia;
                    informe.Tutor = tutor;
                    informe.RegistroAsistencia = registro;
                    informe.Jefe = jefe;
                    if (rbContactoTutorSI.Checked) informe.ContactoTutor = true;
                    if (rbContactoTutorNO.Checked) informe.ContactoTutor = false;

                    if (informe.Evaluacion!=null && informe.Motivacion!=null && informe.Motivacion!=null)
                    {
                        if (DAOJefe.CrearInforme(informe) > 0) MessageBox.Show("Informe Guardado","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        else MessageBox.Show("Fallo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Llene la Evaluacion general");
                    }
                    break;
                case "editar":
                    informe.AreaAsignada = txtAreaAsignada.Text;
                    informe.Horario = txtHorario.Text;
                    informe.ActividadesDesarrolladas = txtActividadesDesarolladas.Text;
                    informe.Fortalezas = txtFortalezas.Text;
                    informe.Debilidades = txtDebilidades.Text;
                    if (cbxAsitencia.SelectedIndex != -1) informe.Evaluacion = cbxAsitencia.SelectedItem.ToString();
                    if (cbxMotivacion.SelectedIndex != -1) informe.Motivacion = cbxMotivacion.SelectedItem.ToString();
                    if (cbxDesempeño.SelectedIndex != -1) informe.Desempenio = cbxDesempeño.SelectedItem.ToString();
                    if(rbContactoTutorSI.Checked) informe.ContactoTutor = true;
                    if (rbContactoTutorNO.Checked) informe.ContactoTutor = false;
                    DialogResult result = MessageBox.Show("Desea Guardar los cambios","Pasantias",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (DAOJefe.EditarInformeJefe(informe) > 0) MessageBox.Show("Informe Actualizado", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Fallo");
                    }
                    break;
                default:
                    break;
            }
            this.Close();
          
        }
        private void DeshabilitarTextospoDefectoCrearEditar()
        {
            txtnombreEmpresa.ReadOnly=true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtNombrePracticante.ReadOnly = true;
            txtCarrera.ReadOnly = true;
            txtCedula.ReadOnly = true;
            txtFechaFin.ReadOnly = true;
            txtFechaInicio.ReadOnly = true;
            txtPeriodo.ReadOnly = true;
            txtNumeroHoras.ReadOnly = true;
            txtNombreTutor.ReadOnly = true;
        }
        private void DeshabilitarTextospoDefectoVer()
        {
            DeshabilitarTextospoDefectoCrearEditar();
            txtAreaAsignada.ReadOnly = true;
            txtHorario.ReadOnly = true;
            txtActividadesDesarolladas.ReadOnly = true;
            txtFortalezas.ReadOnly = true;
            txtDebilidades.ReadOnly = true;
            cbxAsitencia.Enabled = false;
            cbxMotivacion.Enabled = false;
            cbxDesempeño.Enabled = false;
            txtNombreTutor.ReadOnly = true;
            rbContactoTutorSI.Enabled = false;
            rbContactoTutorNO.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
