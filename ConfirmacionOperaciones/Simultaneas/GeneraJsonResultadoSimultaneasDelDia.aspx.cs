using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode;

public partial class GeneraJsonResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string fechaf = Request.Form["fecha"].ToString();
        string fechadd = fechaf.Substring(0, 2).ToString();
        string fechamm = fechaf.Substring(3, 2).ToString();
        string fechayy = fechaf.Substring(6, 4).ToString();
        string fecha = (fechayy + "-" + fechamm + "-" + fechadd).ToString();
        string fechax = (fechayy + "-" + fechamm).ToString();
        //Request.Form["Fecha"].ToString();
        //string producto = "1";
        string resultado = CrearJson(fechax,fecha);
        Response.Clear();
        Response.Write(resultado);
    }

    public string CrearJson(string fechax,String fecha)
    {
        string contenido = "";
        Simultaneas contJson = new Simultaneas();
        Simultaneas contRecor = new Simultaneas();
        List<Simultaneas> listaSimultaneas = new List<Simultaneas>();
        listaSimultaneas = contJson.ObtenerOpDelDiaSimultaneas(fechax,fecha);


        contenido = "[";
        int cont;
        int indexxs = 0;
        for (cont=0; cont < listaSimultaneas.Count - 1; cont++)
        {
            indexxs++;
           // String index = (contRecor.Index+1).ToString();
            contRecor = listaSimultaneas[cont];
            contenido += "{\"FEC_TRANS\" : \"" + contRecor.FEC_TRANS.ToString() + "\", " +
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
                       "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\" },";


            //"\"COD_PER\": \"" + contRecor.COD_PER + "\"," +
            //    " \"SEC_MOVTO\" : \"" + contRecor.SEC_MOVTO.ToString() + "\"," +
            //    "\"CANTIDAD_ACUM_VC\" : \"" + contRecor.CANTIDAD_ACUM_VC.ToString() + "\", " +
            //    "\"COD_CORR_CONTRA\" : \"" + contRecor.COD_CORR_CONTRA.ToString() + "\", " +
            //    "\"COD_SUC\" : \"" + contRecor.COD_SUC.ToString() + "\", " +
            //    "\"FEC_LIQ_ANTICIP\" : \"" + contRecor.FEC_LIQ_ANTICIP.ToString() + "\", " +
            //    "\"FEC_LIQUID\" : \"" + contRecor.FEC_LIQUID.ToString() + "\", " +
            //     "\"FOLIO_COMP_ADJ\" : \"" + contRecor.FOLIO_COMP_ADJ.ToString() + "\", " +
            //    "\"IND_TIT_CUS\" : \"" + contRecor.IND_TIT_CUS.ToString() + "\", " +
            //    "\"INTERES_DIA\" : \"" + contRecor.INTERES_DIA.ToString() + "\", " +
            //    "\"LIN_COMP_ADJ\" : \"" + contRecor.LIN_COMP_ADJ.ToString() + "\", " +
                
            //    "\"SPREAD\" : \"" + contRecor.SPREAD.ToString() + "\", " +
            //    "\"TASA\" : \"" + contRecor.TASA.ToString() + "\", " +
            //    "\"TIPO_COMP_ADJ\" : \"" + contRecor.TIPO_COMP_ADJ.ToString() + "\", " +
            //   "\"IND_LIQUID\" : \"" + contRecor.IND_LIQUID.ToString() + "\", " +
            //   "\"IND_SIMUL\" : \"" + contRecor.IND_SIMUL.ToString() + "\" },";
            
        }


        if (listaSimultaneas.Count > 0)
        {
            indexxs++;
            int index = listaSimultaneas.Count;
            contRecor = listaSimultaneas[listaSimultaneas.Count - 1];
           contenido += "{\"FEC_TRANS\" : \"" + contRecor.FEC_TRANS.ToString() + "\", " +
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
                       "\"TIPO_OPERAC\" : \"" + contRecor.TIPO_OPERAC.ToString() + "\" }";


            //"{\"id\": \"" + index + "\",\"numero_operacion\": \"" + contRecor.NumeroOperacion.ToString() + "\",\"rut_cliente\" :\"" + contRecor.RutCliente.ToString() + "\",\"nombre_cliente\" :\"" + contRecor.NombreCliente.ToString() + "\", \"fecha_operacion\" : \"" + contRecor.FechaOperacion.ToString() + "\", \"monto\" : \"" + contRecor.Monto.ToString() + "\", \"fecha_firma\" : \"" + contRecor.FechaFirma.ToString() + "\", \"dias_pendientes\" : \"" + contRecor.NumeroDiasPendientes.ToString() + "\", \"estado_contrato\" : \"" + contRecor.Estado.ToString() + "\" }";
            contenido += "]";
        }
        else
        {
            contenido += "]";
        }
        return contenido;

    }



}