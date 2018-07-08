using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoaDatos;

namespace CapaLogicadeNegocio
{
    public class ClsAlumno
    {
        //Atributos
        public String m_Dni { get; set; }
        public String m_Apellidos { get; set; }
        public String m_Nombres { get; set; }
        public Char m_Sexo { get; set; }
        public DateTime m_FechaNac { get; set; }
        public String m_Direccion { get; set; }
        

        //Registrar Alumnos
        ClsManejador M = new ClsManejador();
        public bool Registrar_Alumnos()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos los parametros de entrada
                lst.Add(new ClsParametros("@Dni", m_Dni));
                lst.Add(new ClsParametros("@Apellidos",m_Apellidos));
                lst.Add(new ClsParametros("@Nombres", m_Nombres));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@FechaNac", m_FechaNac));
                lst.Add(new ClsParametros("@Direccion", m_Direccion));


               

                return true;

            }
            catch (Exception ex)
            {
                return false;
              //  throw ex;
            }

           // return false;
        }
        //Metodo para Listado de Alumno
        public DataTable ListadoAlumnos()
        {
            return M.Listado("Listado_Alumno",null);
        }

    }
}
