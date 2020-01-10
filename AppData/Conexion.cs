using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{

    private string m_stringConexion;
    private SqlConnection m_cnn;
    private SqlCommand cmd;

    public Conexion(string cadenaConexion)
    {
        m_stringConexion = cadenaConexion;
        m_cnn = new SqlConnection(m_stringConexion);
    }

    public void Abrir()
    {
        m_cnn.Open();
    }

    public void Cerrar()
    {
        m_cnn.Dispose();
        m_cnn.Close();
    }

    public SqlConnection Cnn
    {
        get { return m_cnn; }
        set { m_cnn = value; }
    }

    public DataTable EjecutarSP(string sp)
    {
        try
        {
            Abrir();
            SqlCommand cmd = new SqlCommand(sp, m_cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("resultado");
            adapt.Fill(dt);
            Cerrar();
            return dt;
            
        }
        catch (Exception ex)
        {
            Cerrar();
            //throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            DataTable dt = new DataTable("resultado");
            return dt;
        }
    }

    public DataTable EjecutarSP_Parametros(string sp, SqlParameter[] parameters)
    {
        try
        {
            Abrir();
            SqlCommand cmd = new SqlCommand(sp, m_cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 320;

            for (var j = 0; j < parameters.Count(); j++)
            {
                cmd.Parameters.Add(parameters[j]);
            }
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("resultado");
            adapt.Fill(dt);
            Cerrar();
            return dt;

        }
        catch (Exception ex)
        {
            //throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            Cerrar();
            DataTable dt = new DataTable("resultado");
            return dt;
        }
    }

  
    public SqlParameter agregaParametros(string NombreParam, string valor)
    {
        SqlParameter param = new SqlParameter();
        param.ParameterName = NombreParam;
        param.Value = valor;
        param.SqlDbType = SqlDbType.VarChar;
        return param;
      
    }



}

