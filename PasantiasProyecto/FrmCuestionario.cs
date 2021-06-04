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
    public partial class FrmCuestionario : Form
    {
        Usuario usuario = new Usuario();

        public FrmCuestionario()
        {
            InitializeComponent();
        }

        public FrmCuestionario(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void FrmCuestionario_Load(object sender, EventArgs e)
        {
            txtNombre.Text = usuario.NombreUsuario;
            txtCarrera.Text = ((Practicante)usuario).Carrera;
            txtCreditosAprobados.Text = Convert.ToString(((Practicante)usuario).CreditosAprobados);
            txtNombre.Enabled = false;
            txtCarrera.Enabled = false;
            txtCreditosAprobados.Enabled = false;
            btnGuardar.Enabled = false;
            Llenar();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Llenar()
        {
            int aux = ((Practicante)usuario).IdPracticante;
            Console.WriteLine(  "el aux es"+aux);
            List<Empresa> empresas = DAOEmpresaPorEstudiante.EmpresaPorEstudiante(aux); ;
            cbxEmpresa.Items.Clear();
            foreach (var i in empresas)
            {
                Console.WriteLine(i);
                cbxEmpresa.Items.Add(i);
            }
        }

        private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEmpresa.SelectedItem == null)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }

        private void Pre1_Validated(object sender, EventArgs e)
        {
            Console.WriteLine("Valdadndo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int q1 = 0, q2 = 0, q3 = 0, q4 = 0, q5 = 0, q6 = 0, q7 = 0, q8 = 0, q9 = 0, q10 = 0, q11 = 0;
            //Question 1
            if (rbP11.Checked == true)
            {
                q1 = 1;
                Console.WriteLine(11);
            }
            else if (rbP12.Checked)
            {
                q1 = 1;
                Console.WriteLine(12);
            }
            else if (rbP13.Checked)
            {
                q1 = 1;
                Console.WriteLine(13);
            }
            else if (rbP14.Checked)
            {
                q1 = 1;
                Console.WriteLine(14);
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 1!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                q1 = 0;
            }

            //Question 2
            if (rbP21.Checked == true)
            {
                q2 = 1;
                Console.WriteLine(21);
            }
            else if (rbP22.Checked)
            {
                q2 = 1;
                Console.WriteLine(22);
            }
            else if (rbP23.Checked)
            {
                q2 = 1;
                Console.WriteLine(23);
            }
            else if (rbP24.Checked)
            {
                q2 = 1;
                Console.WriteLine(24);
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 2!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                q2 = 0;
            }
            //Question 3
            if (rbP31.Checked == true)
            {
                Console.WriteLine(31);
                q3 = 1;
            }
            else if (rbP32.Checked)
            {
                Console.WriteLine(32);
                q3 = 1;
            }
            else if (rbP33.Checked)
            {
                Console.WriteLine(33);
                q3 = 1;
            }
            else if (rbP34.Checked)
            {
                Console.WriteLine(34);
                q3 = 1;
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 3!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                q3 = 0;
            }
            //Question 4
            if (rbP41.Checked == true)
            {
                q4 = 1;
                Console.WriteLine(41);
            }
            else if (rbP42.Checked)
            {
                q4 = 1;
                Console.WriteLine(42);
            }
            else if (rbP43.Checked)
            {
                q4 = 1;
                Console.WriteLine(43);
            }
            else if (rbP44.Checked)
            {
                q4 = 1;
                Console.WriteLine(44);
            }
            else
            {
                q4 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 4!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 5
            if (rbP51.Checked == true)
            {
                q5 = 1;
                Console.WriteLine(51);
            }
            else if (rbP52.Checked)
            {
                q5 = 1;
                Console.WriteLine(52);
            }
            else if (rbP53.Checked)
            {
                q5 = 1;
                Console.WriteLine(53);
            }
            else if (rbP54.Checked)
            {
                q5 = 1;
                Console.WriteLine(54);
            }
            else
            {
                q5 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 5!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 6
            if (rbP61.Checked == true)
            {
                q6 = 1;
                Console.WriteLine(61);
            }
            else if (rbP62.Checked)
            {
                q6 = 1;
                Console.WriteLine(62);
            }
            else if (rbP63.Checked)
            {
                q6 = 1;
                Console.WriteLine(63);
            }
            else if (rbP64.Checked)
            {
                q6 = 1;
                Console.WriteLine(64);
            }
            else
            {
                q6 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 6!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 7
            if (rbP71.Checked == true)
            {
                q7 = 1;
                Console.WriteLine(71);
            }
            else if (rbP72.Checked)
            {
                q7 = 1;
                Console.WriteLine(72);
            }
            else if (rbP73.Checked)
            {
                q7 = 1;
                Console.WriteLine(73);
            }
            else if (rbP74.Checked)
            {
                q7 = 1;
                Console.WriteLine(74);
            }
            else
            {

                q7 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 7!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 8
            if (rbP81.Checked == true)
            {
                q8 = 1;
                Console.WriteLine(81);
            }
            else if (rbP82.Checked)
            {
                q8 = 1;
                Console.WriteLine(82);
            }
            else if (rbP83.Checked)
            {
                q8 = 1;
                Console.WriteLine(83);
            }
            else if (rbP84.Checked)
            {
                q8 = 1;
                Console.WriteLine(84);
            }
            else
            {
                q8 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 8!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 9
            if (rbP91.Checked == true)
            {
                q9 = 1;
                Console.WriteLine(91);
            }
            else if (rbP92.Checked)
            {
                q9 = 1;
                Console.WriteLine(92);
            }
            else if (rbP93.Checked)
            {
                q9 = 1;
                Console.WriteLine(93);
            }
            else if (rbP94.Checked)
            {
                q9 = 1;
                Console.WriteLine(94);
            }
            else
            {
                q9 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 9!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 10
            if (rbP101.Checked == true)
            {
                q10 = 1;
                Console.WriteLine(101);
            }
            else if (rbP102.Checked)
            {
                q10 = 1;
                Console.WriteLine(102);
            }
            else if (rbP103.Checked)
            {
                q10 = 1;
                Console.WriteLine(103);
            }
            else if (rbP104.Checked)
            {
                q10 = 1;
                Console.WriteLine(104);
            }
            else
            {
                q10 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 10!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Question 11
            if (rbP111.Checked == true)
            {
                q11 = 1;
                Console.WriteLine(111);
            }
            else if (rbP112.Checked)
            {
                q11 = 1;
                Console.WriteLine(112);
            }
            else if (rbP113.Checked)
            {
                q11 = 1;
                Console.WriteLine(113);
            }
            else if (rbP114.Checked)
            {
                q11 = 1;
                Console.WriteLine(114);
            }
            else
            {
                q11 = 0;
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 11!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (q1 == 1 && q2 == 1 && q3 == 1 && q4 == 1 && q5 == 1 && q6 == 1 && q7 == 1 && q8 == 1 && q9 == 1 && q10 == 1 && q11 == 1 /*&& txtComentariosSugerencias.Text != ""*/)
            {

                if (MessageBox.Show("Desea Guardar la encuesta?", "Pasantias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LlenarEncuesta();
                    MessageBox.Show("Encuesta Guardada con exito", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
     
            }
            else
            {

                Console.WriteLine("TODO no ok");
            }

        }


        private void LlenarEncuesta()
        {
            
            Empresa empresa = (Empresa)cbxEmpresa.SelectedItem;
            int aux = DAOSolicitudEmpesa.SolicitudEmpresa(empresa.IdEmpresa);    //Solicitud empresadevueve el id de la solicitud a partir del idEmpresa
            DAOEncuesta.CrearEncuesta(txtComentariosSugerencias.Text, aux); //creo la encuesta a partir de la funcion de arriba y del comentario que se escribe en el txt
            int aux1 = DAOEncuesta.ObtenerIdEncuesta(aux);  //a partid del id Solicitud(metodo de arriba arriba) recupero el id de la ultima encuesta creada (es decir la que cree en la linea de arriba)

            Console.WriteLine("idUltima encuesta es: "+aux1);


            //Question 1
            if (rbP11.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1,1); // en este caso la encuesta se mantendra constante, el 1er parametro == calificcacion 3er parametro = pregunta
            }
            else if (rbP12.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 1);  //calificacion 2
                Console.WriteLine(12);
            }
            else if (rbP13.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 1);  //calificacion 3
                Console.WriteLine(13);
            }
            else if (rbP14.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 1);  //calificacion 4   
                Console.WriteLine(14);
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 1!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            //Question 2
            if (rbP21.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 2);  // Pregunta 2; calificacion 1
                Console.WriteLine(21);
            }
            else if (rbP22.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 2);  // Pregunta 2; calificacion 2
                Console.WriteLine(22);
            }
            else if (rbP23.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 2); ;  // Pregunta 2; calificacion 3
                Console.WriteLine(23);
            }
            else if (rbP24.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 2);  // Pregunta 2; calificacion 14
                Console.WriteLine(24);
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 2!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            //Question 3
            if (rbP31.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 3);  // Pregunta 3; calificacion 1
                Console.WriteLine(31);
                
            }
            else if (rbP32.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 3); // Pregunta 3; calificacion 2
                Console.WriteLine(32);
                
            }
            else if (rbP33.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 3);  // Pregunta 3; calificacion 3
                Console.WriteLine(33);
                
            }
            else if (rbP34.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 3);  // Pregunta 3; calificacion 4
                Console.WriteLine(34);
                
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 3!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            //Question 4
            if (rbP41.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 4);  // Pregunta 4; calificacion 1
                Console.WriteLine(41);
            }
            else if (rbP42.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 4);  // Pregunta 4; calificacion 2
                Console.WriteLine(42);
            }
            else if (rbP43.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 4);  // Pregunta 4; calificacion 3
                Console.WriteLine(43);
            }
            else if (rbP44.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 4);  // Pregunta 4; calificacion 4
                Console.WriteLine(44);
            }
            else
            {
                
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 4!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 5
            if (rbP51.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 5);  // Pregunta 5; calificacion 1
                Console.WriteLine(51);
            }
            else if (rbP52.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 5);   // Pregunta 5; calificacion 2
                Console.WriteLine(52);
            }
            else if (rbP53.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 5);   // Pregunta 5; calificacion 3  
                Console.WriteLine(53);
            }
            else if (rbP54.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 5);   // Pregunta 5; calificacion 4
                Console.WriteLine(54);
            }
            else
            {
                
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 5!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 6
            if (rbP61.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 6);   // Pregunta 6; calificacion 1
                Console.WriteLine(61);
            }
            else if (rbP62.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 6); ;  // Pregunta 6; calificacion 2
                Console.WriteLine(62);
            }
            else if (rbP63.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 6); // Pregunta 6; calificacion 3
                Console.WriteLine(63);
            }
            else if (rbP64.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 6);  // Pregunta 6; calificacion 4
                Console.WriteLine(64);
            }
            else
            {
                
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 6!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 7
            if (rbP71.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 7);  // Pregunta 7; calificacion 1
                Console.WriteLine(71);
            }
            else if (rbP72.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 7);  // Pregunta 7; calificacion 2
                Console.WriteLine(72);
            }
            else if (rbP73.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 7); // Pregunta 7; calificacion 3
                Console.WriteLine(73);
            }
            else if (rbP74.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 7);  // Pregunta 7; calificacion 4
                Console.WriteLine(74);
            }
            else
            {

                MessageBox.Show("No se permiten campos Vacios en la Pregunta 7!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 8
            if (rbP81.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 8);  // Pregunta 8; calificacion 1
                Console.WriteLine(81);
            }
            else if (rbP82.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 8);  // Pregunta 8; calificacion 2
                Console.WriteLine(82);
            }
            else if (rbP83.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 8);  // Pregunta 8; calificacion 3
                Console.WriteLine(83);
            }
            else if (rbP84.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 8);  // Pregunta 8; calificacion 4
                Console.WriteLine(84);
            }
            else
            {
                
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 8!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 9
            if (rbP91.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 9);  // Pregunta 9; calificacion 1
                Console.WriteLine(91);
            }
            else if (rbP92.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 9);   // Pregunta 9; calificacion 2
                Console.WriteLine(92);
            }
            else if (rbP93.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 9);   // Pregunta 9; calificacion 3
                Console.WriteLine(93);
            }
            else if (rbP94.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 9);   // Pregunta 9; calificacion 4
                Console.WriteLine(94);
            }
            else
            {
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 9!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Question 10
            if (rbP101.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 10); // Pregunta 10; calificacion 1
                Console.WriteLine(101);
            }
            else if (rbP102.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 10);  // Pregunta 10; calificacion 2
                Console.WriteLine(102);
            }
            else if (rbP103.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 10);  // Pregunta 10; calificacion 3
                Console.WriteLine(103);
            }
            else if (rbP104.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 10);  // Pregunta 10; calificacion 4
                Console.WriteLine(104);
            }
            else
            {
                
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 10!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Question 11
            if (rbP111.Checked == true)
            {
                DAORespuesta.CrearRespuesta(1, aux1, 11);  // Pregunta 11; calificacion 1
                Console.WriteLine(111);
            }
            else if (rbP112.Checked)
            {
                DAORespuesta.CrearRespuesta(2, aux1, 11);  // Pregunta 11; calificacion 2
                Console.WriteLine(112);
            }
            else if (rbP113.Checked)
            {
                DAORespuesta.CrearRespuesta(3, aux1, 11);  // Pregunta 11; calificacion 3
                Console.WriteLine(113);
            }
            else if (rbP114.Checked)
            {
                DAORespuesta.CrearRespuesta(4, aux1, 11);  // Pregunta 11; calificacion 4
                Console.WriteLine(114);
            }
            else
            {
               
                MessageBox.Show("No se permiten campos Vacios en la Pregunta 11!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        

        
    }
}
