using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoaDatos
{
    public class ClsManejador
    {
        SqlConnection conexion = new SqlConnection("server=DESKTOP-27PSK2P; database=DemoNCapas;Integrated Security=true");
        
        //Metodo para abrir conexion
        void abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        //Metodo para cerrar conexion
        void cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
        //Metodos para ejecutar el SP (Insert,Delete,Update)
        public void Ejecutar_SP(String NombreSP,List<ClsParametros> lst)
        {
            SqlCommand cmd;

            try
            {
                abrir_conexion();
                cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].m_Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].m_Nombre, lst[i].m_Valor);
                        }
                        if (lst[i].m_Direccion == ParameterDirection.Output) 
                        {
                            cmd.Parameters.Add(lst[i].m_Nombre, lst[i].m_TipoDato, lst[i].m_Tamaño).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();
                    //Recupera parametros de salida
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].m_Valor = cmd.Parameters[i].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cerrar_conexion();
        }


        //Metodo para los listados o consultas
        public DataTable Listado(String NombreSP,List<ClsParametros> lst)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].m_Nombre, lst[i].m_Valor);
                    }

                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
    }
}
