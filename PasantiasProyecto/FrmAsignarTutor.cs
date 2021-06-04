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
    public partial class FrmAsignarTutor : Form
    {
        int idPracticante = 0;
        public FrmAsignarTutor()
        {
            InitializeComponent();
            Llenar();
        }

        public FrmAsignarTutor(int idPracticante)
        {
            this.idPracticante = idPracticante;
            InitializeComponent();
            Llenar();
        }

        private void Llenar()
        {
            lstTutores.Items.Clear();
            foreach (var i in DAOTutor1.obtenerTutores())
            {
                lstTutores.Items.Add(i);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (lstTutores.SelectedItem != null)
            {
                Console.WriteLine("Id pracicante"+idPracticante);

                DAOAsignarTutor.AsignarTutor(idPracticante, ((Tutor)lstTutores.SelectedItem).IdTutor);

                MessageBox.Show("Tutor Asignado con exito!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un tutor!", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
