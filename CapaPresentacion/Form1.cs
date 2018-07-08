using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicadeNegocio;


namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        ClsAlumno Al = new ClsAlumno();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Comentario
            Boolean mesj ;
            try
            {
                Al.m_Dni = txtdni.Text;
                Al.m_Apellidos = txtapellidos.Text;
                Al.m_Nombres = txtnombres.Text;
                Al.m_Sexo = rbtM.Checked == true ? 'M' : 'F';
                Al.m_FechaNac = dateTimePicker1.Value;
                Al.m_Direccion = txtdireccion.Text;

                mesj= Al.Registrar_Alumnos();
                MessageBox.Show(mesj.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
