using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WSConfirmacion;
//using WSValConf;

public partial class confirmado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string folio = Request.QueryString["folio"].ToString();
        string idOperacion = Request.QueryString["op"].ToString();
        string usurespuesta = Request.QueryString["resp"].ToString();

       if(validaLinkRespuesta("1",folio,idOperacion))
        {
           if(enviaRespuestaConfirmacion("1",folio, idOperacion, usurespuesta))
            {
                Label1.Text = "Confirmación enviada correctamente, muchas gracias.";
            }
           else
            {
                Label1.Text = "Ha ocurrido un error en el envío de su confirmación, intente mas tarde.";
            }
        }
       else
        {
            Label1.Text = "Esta operación ya tiene una confirmación prevía o fue generada nuevamente.";
        }

    }


    public bool validaLinkRespuesta(String idProducto, String folio,String idOperacion)
    {
        try
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@folio", folio);
            parameters[2] = conect.agregaParametros("@idOperacion", idOperacion);
            dt = conect.EjecutarSP_Parametros("SP_CO_VALIDA_LINK_RESPUESTA", parameters);
            if (dt.Rows.Count.ToString() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return false;
        }

    }


    public bool enviaRespuestaConfirmacion(String idProducto, String folio, String idOperacion, String respuesta)
    {
        try
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@folio", folio);
            parameters[2] = conect.agregaParametros("@idOperacion", idOperacion);
            parameters[3] = conect.agregaParametros("@respuesta", respuesta);
            dt = conect.EjecutarSP_Parametros("SP_CO_ENVIA_RESPUESTA_CONFIRMACION", parameters);
            return true;
        }
        catch
        {
            return false;
        }

    }


}
