using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoaDatos
{
    public class ClsParametros
    {
        //Parametros
        public String m_Nombre { get; set; }
        public Object m_Valor { get; set; }
        public SqlDbType m_TipoDato { get; set; }
        public Int32 m_Tamaño { get; set; }
        public ParameterDirection m_Direccion { get; set; }

        //Constructores
            //Entrada
        public ClsParametros(String objNombre,Object objValor)
        {
            m_Nombre = objNombre;
            m_Valor = objValor;
            m_Direccion = ParameterDirection.Input;
        }
            //Salida
            public ClsParametros(String objNombre, SqlDbType objTipoDAto, Int32 objTamaño)
        {
            m_Nombre = objNombre;
            m_TipoDato = objTipoDAto;
            m_Tamaño = objTamaño;
            m_Direccion = ParameterDirection.Input;
        }

    }
}
