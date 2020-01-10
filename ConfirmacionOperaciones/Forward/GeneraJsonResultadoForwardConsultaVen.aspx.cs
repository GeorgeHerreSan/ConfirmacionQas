using AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forward_GeneraJsonResultadoForwardConsultaVen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fecha = Request.Form["fecha"].ToString();
        string estado = Request.Form["estado"].ToString();

        string resultado = CrearJson(fecha, estado);
        Response.Clear();
        Response.Write(resultado);
    }

    public string CrearJson(string fecha, string estado)
    {
        string contenido = "";
        List<Forward> listaForward = new List<Forward>();
        Confirmacion conf = new Confirmacion();
        DataTable dt = conf.consultarOperacionesVen(fecha, estado);
        foreach (DataRow row in dt.Rows)
        {            
                Forward con = new Forward();               
                con.Folio = row["Folio"].ToString();
                con.Rut = row["Rut"].ToString();
                con.Secuencia = row["Secuencia"].ToString();
                con.RazonSocial = row["RazonSocial"].ToString();
                con.FechaInicio = row["FechaOperacion"].ToString();
                con.FechaVencimiento = row["FechaVcto"].ToString();
                con.MtoMonPrinc = row["MtoMonPrinc"].ToString();
                con.TcCierre = row["TcCierre"].ToString();
                con.MtoMonSecu = row["MtoMonSecu"].ToString();
                con.Modalidad = row["Modalidad"].ToString();
                con.Dias = row["Dias"].ToString();
                con.TipoMov = row["TipoMov"].ToString();
                con.Cod_Mon_Princ = row["CodMonPrinc"].ToString();
                con.Cod_Mon_Secu = row["CodMonSecu"].ToString();
                con.Paridad_Cierre = row["ParidadCierre"].ToString();
                con.Margen = row["Margen"].ToString();
                con.Ejecutivo = row["Ejecutivo"].ToString();
                con.Clasificacion = row["Clasificacion"].ToString();
                con.UsuarioCreador = row["UsuarioCreador"].ToString();
                con.CodMoneda1 = row["codigoMonedaPrinc"].ToString();
                con.CodMoneda2 = row["codigoMonedaSecun"].ToString();
                con.TcTransf = row["TcTransf"].ToString();
                con.CodSecEco = row["CodSecEco"].ToString();
             
                con.Origen = "SIGA"; /*siga crm*/   
                con.Estado = row["Estado"].ToString();
                listaForward.Add(con);
        }

        Forward contRecor = new Forward();
        contenido = "[";
        for (int cont = 0; cont < listaForward.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaForward[cont];
            contenido += "{\"id\": \"" + index + "\", \"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"TipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"ParidadCierre\" : \"" + reemplazarSeparadorMiles(contRecor.Paridad_Cierre.ToString()) + "\", \"margen\" : \"" + reemplazarSeparadorMiles(contRecor.Margen.ToString()) + "\" , \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuarioCreador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigoMonedaPrinc\" : \"" + contRecor.CodMoneda1.ToString() + "\", \"codigoMonedaSecun\" : \"" + contRecor.CodMoneda2.ToString() + "\" , \"tcTransf\" : \"" + reemplazarSeparadorMiles(contRecor.TcTransf.ToString()) + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\", \"Estado\" : \"" + contRecor.Estado.ToString() + "\" },";
        }


        if (listaForward.Count > 0)
        {
            int index = listaForward.Count;
            contRecor = listaForward[listaForward.Count - 1];
            contenido += "{\"id\": \"" + index + "\", \"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"TipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"ParidadCierre\" : \"" + reemplazarSeparadorMiles(contRecor.Paridad_Cierre.ToString()) + "\", \"margen\" : \"" + reemplazarSeparadorMiles(contRecor.Margen.ToString()) + "\" , \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuarioCreador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigoMonedaPrinc\" : \"" + contRecor.CodMoneda1.ToString() + "\", \"codigoMonedaSecun\" : \"" + contRecor.CodMoneda2.ToString() + "\" , \"tcTransf\" : \"" + reemplazarSeparadorMiles(contRecor.TcTransf.ToString()) + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" , \"Estado\" : \"" + contRecor.Estado.ToString() + "\" }";
            contenido += "]";
        }
        else
        {
            contenido += "]";
        }
        return contenido;

    }

    public string reemplazarSeparadorMiles(String numero)
    {
        numero = numero.Replace(".", "_");
        numero = numero.Replace(",", ".");
        numero = numero.Replace("_", ",");
        return numero;

    }
}