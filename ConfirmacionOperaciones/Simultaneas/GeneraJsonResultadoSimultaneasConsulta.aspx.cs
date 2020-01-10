using AppCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Simultaneas_GeneraJsonResultadoSimultaneasConsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
            string fecha = Request.Form["fecha"].ToString();
            string producto = "2";
            string cliente = Request.Form["cliente"].ToString();
            string nOperacion = Request.Form["nOperacion"].ToString();
            string estado = Request.Form["estado"].ToString();
            //string estadoContrato = Request.Form["estadoCont"].ToString();

        string resultado = CrearJson(producto, fecha,cliente,nOperacion,estado);
            Response.Clear();
            Response.Write(resultado);
        }

        public string CrearJson(string producto, string fecha,string cliente,string nOperacion, string estado)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string contenido = "";
            Simultaneas contJson = new Simultaneas();
            Simultaneas contRecor = new Simultaneas();
            List<Simultaneas> listaSimultaneas = new List<Simultaneas>();
            listaSimultaneas = contJson.ObtenerConsultaSimultaneas(producto, fecha,cliente,nOperacion,estado);

        
        contenido = "[";
            for (int cont = 0; cont < listaSimultaneas.Count - 1; cont++)
            {
                contRecor = listaSimultaneas[cont];
            string estadoDelContrato = "<input type='button' value='" + contRecor.Estado.ToString() + "' id='" + contRecor.ID_OP.ToString() + "' class='" + contRecor.FOLIO_TRANS.ToString() + "' onclick='CuadroEditarEstadosContratosSIM(id = $(this).attr(`id`), clas = $(this).attr(`class`), val = $(this).attr(`value`))'>";
                         DateTime f = Convert.ToDateTime(contRecor.FECHA_CREACION);
                         String anio = f.ToString("yyyy");
                         String mes = f.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-us"));
                         string ruta = "/ConfirmaciondeOperaciones/Operaciones/Simultanea/" + anio + "/" + mes + "/";
            string link = ruta + contRecor.FOLIO_TRANS + ".pdf".ToString();
              string rutaDelPdf = "<a href='" + link + "' target='_blank'><input type='button' value='Ver PDF'></a>";
                       //reemplazarSeparadorMiles()
            if (ruta != "")
                    {
                    contenido += "{\"INDEXM\" : \"" + contRecor.INDEXM.ToString() + "\", " +
                        "\"FEC_TRANS\": \"" + contRecor.FEC_TRANS.ToString() + "\"," +
                   "\"FEC_VCTO_TP\": \"" + contRecor.FEC_VCTO_TP.ToString() + "\"," +
                   "\"FOLIO_TRANS\" : \"" + contRecor.FOLIO_TRANS.ToString() + "\", " +
                    "\"NEMO\" :\"" + contRecor.NEMO.ToString() + "\"," +
                     "\"RUT_CLI\" :\"" + contRecor.RUT_CLI.ToString() + "\"," +
                     " \"SEC_RUT_CLI\" : \"" + contRecor.SEC_RUT_CLI.ToString() + "\"," +
                      " \"RSO_RAZ_SOCIAL\" : \"" + contRecor.RSO_RAZ_SOCIAL.ToString() + "\", " +
                      "\"COD_AGENTE\" : \"" + contRecor.COD_AGENTE.ToString() + "\", " +
                      "\"CANTIDAD\" : \"" + contRecor.CANTIDAD.ToString() + "\", " +
                       "\"PRECIO\" : \"" + contRecor.PRECIO.ToString() + "\", " +
                        "\"MONTO\" : \"" + contRecor.MONTO.ToString() + "\", " +
                         "\"PRECIO_CONTADO\" : \"" + contRecor.PRECIO_CONTADO.ToString() + "\", " +
                         "\"MONTO_ACUM_VC\" : \"" + contRecor.MONTO_ACUM_VC.ToString() + "\", " +
                         "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\", " +
                       "\"ESTADO\" : \"" + estadoDelContrato + "\", " +
                       "\"PDF\" : \"" + rutaDelPdf + "\", " + 
                              "\"ID_OP\" : \"" + contRecor.ID_OP.ToString() + "\", " +
                     "\"FECHA_CREACION\" : \"" + contRecor.FECHA_CREACION.ToString() + "\" },";
            }
                   else
                    {
                    contenido += "{\"INDEXM\" : \"" + contRecor.INDEXM.ToString() + "\", " +
                    "\"FEC_TRANS\": \"" + contRecor.FEC_TRANS.ToString() + "\"," +
                   "\"FEC_VCTO_TP\": \"" + contRecor.FEC_VCTO_TP.ToString() + "\"," +
                   "\"FOLIO_TRANS\" : \"" + contRecor.FOLIO_TRANS.ToString() + "\", " +
                    "\"NEMO\" :\"" + contRecor.NEMO.ToString() + "\"," +
                     "\"RUT_CLI\" :\"" + contRecor.RUT_CLI.ToString() + "\"," +
                     " \"SEC_RUT_CLI\" : \"" + contRecor.SEC_RUT_CLI.ToString() + "\"," +
                      " \"RSO_RAZ_SOCIAL\" : \"" + contRecor.RSO_RAZ_SOCIAL.ToString() + "\", " +
                      "\"COD_AGENTE\" : \"" + contRecor.COD_AGENTE.ToString() + "\", " +
                      "\"CANTIDAD\" : \"" + contRecor.CANTIDAD.ToString() + "\", " +
                       "\"PRECIO\" : \"" + contRecor.PRECIO.ToString() + "\", " +
                        "\"MONTO\" : \"" + contRecor.MONTO.ToString() + "\", " +
                         "\"PRECIO_CONTADO\" : \"" + contRecor.PRECIO_CONTADO.ToString() + "\", " +
                     "\"MONTO_ACUM_VC\" : \"" + contRecor.MONTO_ACUM_VC.ToString() + "\", " +
                     "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\", " +
                     "\"ESTADO\" : \"" + estadoDelContrato + "\", " +
                   "\"PDF\" : \"" + "SIN PDF" + "\", " + 
                "\"ID_OP\" : \"" + contRecor.ID_OP.ToString() + "\", " +
                 "\"FECHA_CREACION\" : \"" + contRecor.FECHA_CREACION.ToString() + "\" },";
            }
            }


                    if (listaSimultaneas.Count > 0)
                    {
                        contRecor = listaSimultaneas[listaSimultaneas.Count - 1];
                        string estadoDelContrato = "<input type='button' value='" + contRecor.Estado.ToString() + "' id='" + contRecor.ID_OP.ToString() + "' class='" + contRecor.FOLIO_TRANS.ToString() + "' onclick='CuadroEditarEstadosContratosSIM(id = $(this).attr(`id`), clas = $(this).attr(`class`), val = $(this).attr(`value`))'>";
                        DateTime f = Convert.ToDateTime(contRecor.FECHA_CREACION);
                        String anio = f.ToString("yyyy");
                        String mes = f.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-us"));
                        string ruta = "/ConfirmaciondeOperaciones/Operaciones/Simultanea/" + anio + "/" + mes + "/";
                        string link = ruta + contRecor.FOLIO_TRANS + ".pdf".ToString();
                        string rutaDelPdf = "<a href='" + link + "' target='_blank'><input type='button' value='Ver PDF'></a>";
                        if (ruta != "")
                        {
                            contenido += "{\"INDEXM\" : \"" + contRecor.INDEXM.ToString() + "\", " +
                            "\"FEC_TRANS\": \"" + contRecor.FEC_TRANS.ToString() + "\"," +
                       "\"FEC_VCTO_TP\": \"" + contRecor.FEC_VCTO_TP.ToString() + "\"," +
                       "\"FOLIO_TRANS\" : \"" + contRecor.FOLIO_TRANS.ToString() + "\", " +
                        "\"NEMO\" :\"" + contRecor.NEMO.ToString() + "\"," +
                         "\"RUT_CLI\" :\"" + contRecor.RUT_CLI.ToString() + "\"," +
                         " \"SEC_RUT_CLI\" : \"" + contRecor.SEC_RUT_CLI.ToString() + "\"," +
                          " \"RSO_RAZ_SOCIAL\" : \"" + contRecor.RSO_RAZ_SOCIAL.ToString() + "\", " +
                          "\"COD_AGENTE\" : \"" + contRecor.COD_AGENTE.ToString() + "\", " +
                          "\"CANTIDAD\" : \"" + contRecor.CANTIDAD.ToString() + "\", " +
                           "\"PRECIO\" : \"" + contRecor.PRECIO.ToString() + "\", " +
                            "\"MONTO\" : \"" + contRecor.MONTO.ToString() + "\", " +
                             "\"PRECIO_CONTADO\" : \"" + contRecor.PRECIO_CONTADO.ToString() + "\", " +
                             "\"MONTO_ACUM_VC\" : \"" + contRecor.MONTO_ACUM_VC.ToString() + "\", " +
                             "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\", " +
                              "\"ESTADO\" : \"" + estadoDelContrato + "\" ," +
                         "\"PDF\" : \"" + rutaDelPdf + "\", " +
                       "\"ID_OP\" : \"" + contRecor.ID_OP.ToString() + "\", " +
                       "\"FECHA_CREACION\" : \"" + contRecor.FECHA_CREACION.ToString() + "\" }";
            }
                        else {
                            contenido += "{\"INDEXM\" : \"" + contRecor.INDEXM.ToString() + "\", " +
                            "\"FEC_TRANS\": \"" + contRecor.FEC_TRANS.ToString() + "\"," +
                       "\"FEC_VCTO_TP\": \"" + contRecor.FEC_VCTO_TP.ToString() + "\"," +
                       "\"FOLIO_TRANS\" : \"" + contRecor.FOLIO_TRANS.ToString() + "\", " +
                        "\"NEMO\" :\"" + contRecor.NEMO.ToString() + "\"," +
                         "\"RUT_CLI\" :\"" + contRecor.RUT_CLI.ToString() + "\"," +
                         " \"SEC_RUT_CLI\" : \"" + contRecor.SEC_RUT_CLI.ToString() + "\"," +
                          " \"RSO_RAZ_SOCIAL\" : \"" + contRecor.RSO_RAZ_SOCIAL.ToString() + "\", " +
                          "\"COD_AGENTE\" : \"" + contRecor.COD_AGENTE.ToString() + "\", " +
                          "\"CANTIDAD\" : \"" + contRecor.CANTIDAD.ToString() + "\", " +
                           "\"PRECIO\" : \"" + contRecor.PRECIO.ToString() + "\", " +
                            "\"MONTO\" : \"" + contRecor.MONTO.ToString() + "\", " +
                             "\"PRECIO_CONTADO\" : \"" + contRecor.PRECIO_CONTADO.ToString() + "\", " +
                             "\"MONTO_ACUM_VC\" : \"" + contRecor.MONTO_ACUM_VC.ToString() + "\", " +
                             "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\", " +
                              "\"ESTADO\" : \"" + estadoDelContrato + "\","+
                               "\"PDF\" : \"" + "SIN PDF" + "\", " +
                       "\"ID_OP\" : \"" + contRecor.ID_OP.ToString() + "\", " +
                       "\"FECHA_CREACION\" : \"" + contRecor.FECHA_CREACION.ToString() + "\" }";
            }
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
