using AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forward_GeneraJsonResultadoForwardReenvio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fecha = Request.Form["folio"].ToString();
        string producto = "1";
        string resultado = CrearJson(producto, fecha);
        Response.Clear();
        Response.Write(resultado);
    }

    public string CrearJson(string producto,string nOperacion)
    {
        string contenido = "";
        List<Forward> listaForward = new List<Forward>();
        Confirmacion conf = new Confirmacion();
        DataTable dt = conf.consultarOperacionesPorFolio(producto, nOperacion);
        foreach (DataRow row in dt.Rows)
        {
            Forward contRecor1 = new Forward();
            contRecor1.Id = row["Id"].ToString();
            contRecor1.Folio = row["Folio"].ToString();
            contRecor1.Rut = row["Rut"].ToString();
            contRecor1.Secuencia = row["Secuencia"].ToString();
            contRecor1.RazonSocial = row["RazonSocial"].ToString();
            contRecor1.FechaInicio = row["FechaInicio"].ToString();
            contRecor1.FechaVencimiento = row["FechaVcto"].ToString();
            contRecor1.MtoMonPrinc = row["MtoMonPrinc"].ToString();
            contRecor1.TcCierre = row["TcCierre"].ToString();
            contRecor1.MtoMonSecu = row["MtoMonSecu"].ToString();
            contRecor1.Modalidad = row["Modalidad"].ToString();
            contRecor1.Dias = row["Dias"].ToString();
            contRecor1.TipoMov = row["TipoMov"].ToString();
            contRecor1.Cod_Mon_Princ = row["CodMonPrinc"].ToString();
            contRecor1.Cod_Mon_Secu = row["CodMonSecu"].ToString();
            contRecor1.Paridad_Cierre = row["ParidadCierre"].ToString();
            contRecor1.Margen = row["Margen"].ToString();
            contRecor1.Ejecutivo = row["Ejecutivo"].ToString();
            contRecor1.Clasificacion = row["Clasificacion"].ToString();
            contRecor1.UsuarioCreador = row["UsuarioCreador"].ToString();
            contRecor1.CodMoneda1 = row["CodMoneda"].ToString();
            //contRecor.CodMoneda2 = row["CodMoneda2"].ToString();
            contRecor1.TcTransf = row["TcTransf"].ToString();
            contRecor1.CodSecEco = row["CodSecEco"].ToString();
            contRecor1.Estado = row["Estado"].ToString();
            contRecor1.FechaEnvioConfirmacion = row["Fecha_creacion"].ToString();
            if (row["origen"].ToString() == "1")
            {
                contRecor1.Origen = "SIGA";
            }
            if (row["origen"].ToString() == "2")
            {
                contRecor1.Origen = "BLOTTER";
            }
            listaForward.Add(contRecor1);
        }

        Forward contRecor = new Forward();
        contenido = "[";
        for (int cont = 0; cont < listaForward.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaForward[cont];
            //contenido += "{\"id\": \"" + index + "\",\"Origen\" : \"" + contRecor.Origen.ToString() + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"fecha_envio\": \"" + contRecor.FechaEnvioConfirmacion.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + contRecor.MtoMonPrinc.ToString() + "\", \"tc_cierre\" : \"" + contRecor.TcCierre.ToString() + "\", \"MtoMonSecu\" : \"" + contRecor.MtoMonSecu.ToString() + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipo_mov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"margen\" : \"" + contRecor.Margen.ToString() + "\", \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuario_creador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigo_moneda\" : \"" + contRecor.CodMoneda1.ToString() + "\" , \"tcTransf\" : \"" + contRecor.TcTransf.ToString() + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" , \"estado_operacion\" : \"" + contRecor.Estado.ToString() + "\"    },";
            contenido += "{\"id\": \"" + index + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"Ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\" },";

        }


        if (listaForward.Count > 0)
        {
            int index = listaForward.Count;
            contRecor = listaForward[listaForward.Count - 1];
            //contenido += "{\"id\": \"" + index + "\",\"Origen\": \"" + contRecor.Origen.ToString() + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"fecha_envio\": \"" + contRecor.FechaEnvioConfirmacion.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + contRecor.MtoMonPrinc.ToString() + "\", \"tc_cierre\" : \"" + contRecor.TcCierre.ToString() + "\", \"MtoMonSecu\" : \"" + contRecor.MtoMonSecu.ToString() + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipo_mov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"margen\" : \"" + contRecor.Margen.ToString() + "\", \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuario_creador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigo_moneda\" : \"" + contRecor.CodMoneda1.ToString() + "\" , \"tcTransf\" : \"" + contRecor.TcTransf.ToString() + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" , \"estado_operacion\" : \"" + contRecor.Estado.ToString() + "\"    }";
            contenido += "{\"id\": \"" + index + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"Ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\" }";

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