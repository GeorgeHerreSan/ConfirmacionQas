using AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading;

public partial class Forward_GeneraJsonResultadoForwardConsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string fecha = Request.Form["fecha"].ToString();
        string producto = "1";
        string cliente = Request.Form["cliente"].ToString();
        string nOperacion = Request.Form["nOperacion"].ToString();
        string estado = Request.Form["estado"].ToString();
        string estadoContrato = Request.Form["estadoCont"].ToString();

        string resultado = CrearJson(producto, fecha, cliente, nOperacion, estado, estadoContrato);
        Response.Clear();
        Response.Write(resultado);
    }

    public string CrearJson(string producto, string fecha, string cliente, string nOperacion, string estado, string estadoContrato)
    {
        string contenido = "";
        List<Forward> listaForward = new List<Forward>();
        Confirmacion conf = new Confirmacion();
        DataTable dt = conf.consultarOperaciones(producto, fecha, cliente, nOperacion, estado, estadoContrato);
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
            contRecor1.FechaConfirmacion = row["Fecha_confirmacion"].ToString();
            contRecor1.FechaEliminacion = row["Fecha_eliminacion"].ToString();
            contRecor1.RespuestaConfirmacion = row["respuesta"].ToString();
            contRecor1.Diast = row["DiasTotales"].ToString();
            contRecor1.FechaContrato = row["FechaContrato"].ToString();
            contRecor1.EstadoContrato = row["estadoContrato"].ToString();
            //contRecor1.FechaContrato = row["FechaContrato"].ToString();
            string fechadecontratos = row["FechaContrato"].ToString();
            if (fechadecontratos == "")
            {
                contRecor1.UlrContratro = "sinlink";
            }
            else
            {
                DateTime fechaEnvioDeContrato = Convert.ToDateTime(fechadecontratos);
                //Se debe leer en ingles debido a que las carpetas se generan con el mes en ingles
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                string mesEnCurso = fechaEnvioDeContrato.ToString("MMMM");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                string anio = fechaEnvioDeContrato.Year.ToString();
                //string rutaCompleta = "";
                contRecor1.UlrContratro = "/ConfirmaciondeOperaciones/Operaciones/Forward/Contratos/" + anio + "/" + mesEnCurso + "/" + row["Folio"].ToString() + ".pdf";
            }

            listaForward.Add(contRecor1);
        }

        Forward contRecor = new Forward();
        contenido = "[";
        for (int cont = 0; cont < listaForward.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaForward[cont];

            string rutaDelContrato = "";
            if (contRecor.UlrContratro.ToString() == "sinlink")
            {
                rutaDelContrato = "Sin envío";
            }
            else
            {
                rutaDelContrato = "<a href='" + contRecor.UlrContratro.ToString() + "' target='_blank'><input type='button' value='Ver PDF'></a>";
            }

            string estadoDelContrato = "<input type='button' value='" + contRecor.EstadoContrato.ToString() + "' id='" + contRecor.Id.ToString() + "' class='" + contRecor.Folio.ToString() + "' onclick='CuadroEditarEstadosContratos(id = $(this).attr(`id`), clas = $(this).attr(`class`), val = $(this).attr(`value`))'>";

            contenido += "{\"id\": \"" + index + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"urlContrato\" : \"" + rutaDelContrato + "\", \"estado_contrato\" : \"" + estadoDelContrato + "\", \"fecha_envio_contrato\" : \"" + contRecor.FechaContrato.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"dias_totales\" : \"" + contRecor.Diast.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"Ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"fecha_envio\" : \"" + contRecor.FechaEnvioConfirmacion.ToString() + "\",\"fecha_confirmacion\" : \"" + contRecor.FechaConfirmacion.ToString() + "\", \"fecha_eliminacion\" : \"" + contRecor.FechaEliminacion.ToString() + "\", \"Estado\" : \"" + contRecor.Estado.ToString() + "\" , \"Respuesta\" : \"" + contRecor.RespuestaConfirmacion.ToString() + "\" },";

        }


        if (listaForward.Count > 0)
        {
            int index = listaForward.Count;
            contRecor = listaForward[listaForward.Count - 1];

            string rutaDelContrato = "";
            if (contRecor.UlrContratro.ToString() == "sinlink")
            {
                rutaDelContrato = "Sin Envío";
            }
            else
            {
                rutaDelContrato = "<a href='" + contRecor.UlrContratro.ToString() + "' target='_blank'><input type='button' value='Ver PDF'></a>";
            }

            string estadoDelContrato = "<input type='button' value='" + contRecor.EstadoContrato.ToString() + "' id='" + contRecor.Id.ToString() + "' class='" + contRecor.Folio.ToString() + "' onclick='CuadroEditarEstadosContratos(id = $(this).attr(`id`), clas = $(this).attr(`class`), val = $(this).attr(`value`))'>";

            contenido += "{\"id\": \"" + index + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"urlContrato\" : \"" + rutaDelContrato + "\", \"estado_contrato\" : \"" + estadoDelContrato + "\", \"fecha_envio_contrato\" : \"" + contRecor.FechaContrato.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"dias_totales\" : \"" + contRecor.Diast.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"Ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"fecha_envio\" : \"" + contRecor.FechaEnvioConfirmacion.ToString() + "\",\"fecha_confirmacion\" : \"" + contRecor.FechaConfirmacion.ToString() + "\", \"fecha_eliminacion\" : \"" + contRecor.FechaEliminacion.ToString() + "\", \"Estado\" : \"" + contRecor.Estado.ToString() + "\" , \"Respuesta\" : \"" + contRecor.RespuestaConfirmacion.ToString() + "\" }";

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

    public string CorregirBotonesPDF(String url)
    {
        return url;
    }


}