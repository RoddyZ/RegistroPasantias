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
    public partial class FrmInformeMitad : Form
    {
        Solicitud pasantia;
        Tutor tutor = new Tutor();
        InformeMitadPeriodo informe = new InformeMitadPeriodo();
        String opcion;
        int idInformeMitad;
        DateTimePicker oDateTimePicker;
        List<ControlTutor> controls = new List<ControlTutor>();
        public FrmInformeMitad(Solicitud s,Tutor t,InformeMitadPeriodo i,String op)
        {
            InitializeComponent();
            pasantia = s;
            tutor = t;
            informe = i;
            opcion = op;
        }

        private void FrmInformeMitad_Load(object sender, EventArgs e)
        {
            dgvFechasVisitas.AllowUserToAddRows = false;
            if (opcion.Equals("crear"))
            {
                CargarEncabezado();
                dgvVerControles.Visible = false;
            }
            
            if (opcion.Equals("ver"))
            {
                btnGuardar.Visible = false;
                btnCancelar.Text = "Salir";
                dgvFechasVisitas.Visible = false;
                CargarInforme();
                DeshabilitarTextosVisualizar();
                btnNuevaVisita.Visible = false;
            }
            if (opcion.Equals("editar"))
            {
                CargarInforme();
                DeshabilitarTextosCrearEditar();
                dgvVerControles.Visible = false;
            }

        }


        private void CargarInforme()
        {
            txtnombreEmpresa.Text = informe.Solicitud.Empresa.NombreEmpresa;
            txtDireccion.Text = informe.Solicitud.Empresa.Direccion;
            txtTelefono.Text = informe.Solicitud.Empresa.Telefono;
            txtFax.Text = informe.Solicitud.Empresa.Fax;
            txtCorreo.Text = informe.Solicitud.Empresa.CorreoElectronico;
            txtNombreUsuario.Text = informe.Solicitud.Practicante.NombreUsuario;
            txtCarrera.Text = informe.Solicitud.Practicante.Carrera;

            txtPreparacionTecnica.Text = informe.PreparacionTecnica;
            txtCapacidadAprendizaje.Text = informe.CapacidadAprendizaje;
            if (informe.Creatividad) rbCreatividadSI.Checked = true;
            else rbCreatividadNO.Checked = true;

            if (informe.Puntualidad) rbPuntualidadSI.Checked = true;
            else rbPuntualidadNO.Checked = true;

            if (informe.Adaptacion) rbAdaptacionSI.Checked = true;
            else rbAdaptacionNO.Checked = true;

            if (informe.Responsabilidad) rbResponsabilidaSI.Checked = true;
            else rbResponsabilidadNO.Checked = true;

            LlenarFechasVisitas();
            
        }
        private void DeshabilitarTextosVisualizar()
        {
            DeshabilitarTextosCrearEditar();
            txtPreparacionTecnica.ReadOnly = true;
            txtCapacidadAprendizaje.ReadOnly = true;
            rbCreatividadSI.Enabled = false;
            rbCreatividadNO.Enabled = false;
            rbPuntualidadSI.Enabled = false;
            rbPuntualidadNO.Enabled = false;
            dgvFechasVisitas.ReadOnly = true;
            rbAdaptacionSI.Enabled = false;
            rbAdaptacionNO.Enabled = false;

            rbResponsabilidaSI.Enabled = false;
            rbResponsabilidadNO.Enabled = false;
        }

        private void LlenarFechasVisitas()
        {
            
            controls = DAOTUTOR.ObtenerControlTutoria(informe.IdInformeMitadPeriodo);
            dgvVerControles.DataSource = controls;
            dgvVerControles.ReadOnly = true;
            dgvVerControles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvVerControles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVerControles.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void CargarEncabezado()
        {
            txtnombreEmpresa.Text = pasantia.Empresa.NombreEmpresa;
            txtDireccion.Text = pasantia.Empresa.Direccion;
            txtTelefono.Text = pasantia.Empresa.Telefono;
            txtFax.Text = pasantia.Empresa.Fax;
            txtCorreo.Text = pasantia.Empresa.CorreoElectronico;
            txtNombreUsuario.Text = pasantia.Practicante.NombreUsuario;
            txtCarrera.Text = pasantia.Practicante.Carrera;
            DeshabilitarTextosCrearEditar();
        }

        private void DeshabilitarTextosCrearEditar()
        {
            txtnombreEmpresa.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtNombreUsuario.ReadOnly = true;
            txtCarrera.ReadOnly = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case "crear":
                    informe.PreparacionTecnica = txtPreparacionTecnica.Text;
                    informe.CapacidadAprendizaje = txtCapacidadAprendizaje.Text;
                    if (rbCreatividadSI.Checked) informe.Creatividad = true;
                    if (rbPuntualidadSI.Checked) informe.Puntualidad = true;
                    if (rbAdaptacionSI.Checked) informe.Adaptacion = true;
                    if (rbResponsabilidaSI.Checked) informe.Responsabilidad = true;

                    if ((idInformeMitad = DAOTUTOR.CrearInforme(informe, pasantia, tutor)) > 0) {
                        try
                        {
                            foreach (DataGridViewRow row in dgvFechasVisitas.Rows)
                            {
                                ControlTutor control = new ControlTutor();
                                DateTime date = Convert.ToDateTime(row.Cells["FECHA"].Value.ToString());
                                control.Fecha = date;
                                control.Medio = row.Cells["MEDIO"].Value.ToString();
                                control.Tema = row.Cells["TEMAOBSERVACIONES"].Value.ToString();
                                DAOTUTOR.InsertarControl(control, idInformeMitad);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Algunas Visitas No se Guardaron","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        }
                        MessageBox.Show("Informe Guardado","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                    }
                    else MessageBox.Show("Fallo la Operacion","Pasantias",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    break;
                case "editar":
                    informe.PreparacionTecnica = txtPreparacionTecnica.Text;
                    informe.CapacidadAprendizaje = txtCapacidadAprendizaje.Text;
                    if (rbCreatividadSI.Checked) informe.Creatividad = true;
                    if (rbPuntualidadSI.Checked) informe.Puntualidad = true;
                    if (rbAdaptacionSI.Checked) informe.Adaptacion = true;
                    if (rbResponsabilidaSI.Checked) informe.Responsabilidad = true;
                    try
                    {
                        foreach (DataGridViewRow row in dgvFechasVisitas.Rows)
                        {
                            ControlTutor control = new ControlTutor();

                            DateTime date = Convert.ToDateTime(row.Cells["FECHA"].Value.ToString());
                            control.Fecha = date;
                            control.Medio = row.Cells["MEDIO"].Value.ToString();
                            control.Tema = row.Cells["TEMAOBSERVACIONES"].Value.ToString();
                            DAOTUTOR.InsertarControl(control, informe.IdInformeMitadPeriodo);
                        }
                        if (DAOTUTOR.EditarInforme(informe) > 0) { MessageBox.Show("Informe Actualizado");this.Close(); }
                        else MessageBox.Show("Fallo la Operacion", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existe un campo sin llenar en Control Tutoria", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                    break;
                default:
                    break;
            }
            
        }

        private void dgvFechasVisitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            dgvFechasVisitas.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }
        private void dgvFechasVisitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                 
                oDateTimePicker = new DateTimePicker();
                dgvFechasVisitas.CurrentCell.Value = DateTime.Now;  
                dgvFechasVisitas.Controls.Add(oDateTimePicker);  
                oDateTimePicker.Format = DateTimePickerFormat.Short;
                Rectangle oRectangle = dgvFechasVisitas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y); 
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                oDateTimePicker.Visible = true;
            }
        }

        private void btnNuevaVisita_Click(object sender, EventArgs e)
        {
            dgvFechasVisitas.Rows.Add();
        }
    }
}
