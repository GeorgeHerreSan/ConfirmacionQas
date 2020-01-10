using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forward_GeneraJsonResultadoForwardVencimiento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fecha = Request.Form["fecha"].ToString();
        string producto = "1";
        string resultado = CrearJson(producto, fecha);
        Response.Clear();
        Response.Write(resultado);    }

    public string CrearJson(string producto, string fecha)
    {
        string contenido = "";
        Forward contJson = new Forward();
        Forward contRecor = new Forward();
        List<Forward> listaForward = new List<Forward>();
        listaForward = contJson.ObtenerVencimientosForward(producto, fecha);


        contenido = "[";
        for (int cont = 0; cont < listaForward.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaForward[cont];

            contenido += "{\"id\": \"" + index + "\", \"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"TipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"ParidadCierre\" : \"" + reemplazarSeparadorMiles(contRecor.Paridad_Cierre.ToString()) + "\", \"margen\" : \"" + reemplazarSeparadorMiles(contRecor.Margen.ToString()) + "\" , \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuarioCreador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigoMonedaPrinc\" : \"" + contRecor.CodMoneda1.ToString() + "\", \"codigoMonedaSecun\" : \"" + contRecor.CodMoneda2.ToString() + "\" , \"tcTransf\" : \"" + reemplazarSeparadorMiles(contRecor.TcTransf.ToString()) + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" },";

        }


        if (listaForward.Count > 0)
        {
            int index = listaForward.Count;
            contRecor = listaForward[listaForward.Count - 1];

            //contenido += "{\"id\": \"" + index + "\", \"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + contRecor.MtoMonPrinc.ToString() + "\", \"tc_cierre\" : \"" + contRecor.TcCierre.ToString() + "\", \"MtoMonSecu\" : \"" + contRecor.MtoMonSecu.ToString() + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"TipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"ParidadCierre\" : \"" + contRecor.Paridad_Cierre.ToString() + "\", \"margen\" : \"" + contRecor.Margen.ToString() + "\" , \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuario_creador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigoMonedaPrinc\" : \"" + contRecor.CodMoneda1.ToString() + "\", \"codigoMonedaSecun\" : \"" + contRecor.CodMoneda2.ToString() + "\" , \"tcTransf\" : \"" + contRecor.TcTransf.ToString() + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" }";
            contenido += "{\"id\": \"" + index + "\", \"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"TipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"ParidadCierre\" : \"" + reemplazarSeparadorMiles(contRecor.Paridad_Cierre.ToString()) + "\", \"margen\" : \"" + reemplazarSeparadorMiles(contRecor.Margen.ToString()) + "\" , \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuarioCreador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigoMonedaPrinc\" : \"" + contRecor.CodMoneda1.ToString() + "\", \"codigoMonedaSecun\" : \"" + contRecor.CodMoneda2.ToString() + "\" , \"tcTransf\" : \"" + reemplazarSeparadorMiles(contRecor.TcTransf.ToString()) + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" }";

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