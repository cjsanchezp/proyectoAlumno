using System.Data;
using System.Windows.Forms;
using CapaLogicadeNegocio;

namespace CapaPresentacion
{
    public partial class Form2 : Form
    {
        ClsAlumno Al = new ClsAlumno();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            DataTable dt = Al.ListadoAlumnos();
            dataGridView1.DataSource = dt;
        }
    }
}
