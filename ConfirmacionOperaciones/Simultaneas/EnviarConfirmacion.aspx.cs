using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using AppCode;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


public partial class Simultanea_EnviarConfirmacion : System.Web.UI.Page //Forward_EnviarConfirmacion
{
    string idProducto;
    string operaciones;
    string reenvio;
    string folioReenvio;
    protected void Page_Load(object sender, EventArgs e)
    {
        idProducto = Request.Form["idProducto"].ToString();
        operaciones = Request.Form["Operaciones"].ToString();
        reenvio = Request.Form["Reenvio"].ToString();

        if (reenvio == "SI")
        {
            eliminarOperacionParaReenviar();
        }

        enviarOperacionesConfirmacion();

        Response.Write("OK");
        //aqui refrescar 



        Response.End();

    }

    public bool enviarOperacionesConfirmacion()
    {
        string writer = "";
        string[] operacionesList = operaciones.Split(',');
        foreach (string operacion in operacionesList)
        {
            string[] detalleOperacionList = operacion.Split('|');
            string origen = detalleOperacionList[0].ToString(); //siga

            string RSO_RAZ_SOCIAL = detalleOperacionList[1].ToString();
            string RUT_CLI = detalleOperacionList[2].ToString();
            string FOLIO_TRANS = detalleOperacionList[3].ToString();
            string FEC_TRANS = detalleOperacionList[4].ToString();
            // string idSelect = detalleOperacionList[5].ToString();
            // string COD_PER = detalleOperacionList[5].ToString();




            Confirmacion conf = new Confirmacion();
            String resultadoCreacion = "";
            resultadoCreacion = conf.crearOperacionConfirmacionSIM(idProducto, FOLIO_TRANS, origen, FEC_TRANS, RUT_CLI);
            //salidId


            generadorPDFSIM(FOLIO_TRANS, RUT_CLI, FEC_TRANS, resultadoCreacion);

            string folioOp = FOLIO_TRANS + "|" + resultadoCreacion;
            //writer = Server.MapPath("~/Archivos/");
            //writer = Server.MapPath(ConfigurationManager.AppSettings["RutaArchivos"].ToString());
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
           
           string mes = DateTime.Now.ToString("MMMM");
             string anio = DateTime.Now.ToString("yyyy");
            
              writer = (ConfigurationManager.AppSettings["RutaArchivos"].ToString()) + "Simultanea\\" + anio + "\\" + mes + "\\";
            conf.EnviarCorreoConfirmacionSIM(idProducto, FOLIO_TRANS, writer, RSO_RAZ_SOCIAL, RUT_CLI, FEC_TRANS, resultadoCreacion);

            //document.getElementById('datepickerSimultaneaEnvio').value = '2019-12-13';

            #region EnvioPorUsuario 
            //folios = folios + "," + folio;

            //if (index < operacionesList.Count() - 1)
            //{
            //    if (operacionesList[index].ToString().Substring(0, operacionesList[index].ToString().IndexOf("|")) != operacionesList[index + 1].ToString().Substring(0, operacionesList[index + 1].ToString().IndexOf("|")))
            //    {
            //        folios = folios.Substring(1);
            //        string[] foliosList = folios.Split(',');
            //        foreach (string folioaux in foliosList)
            //        {
            //            generadorPDFSinVariables(folioaux);
            //        }

            //        string writer = Server.MapPath("~/Archivos/"); 

            //        conf.EnviarCorreoConfirmacion(idProducto, folios, writer);
            //        folios = "";
            //    }
            //    index++;
            //}
            //else
            //{
            //    folios = folios.Substring(1);
            //    string[] foliosList = folios.Split(',');
            //    foreach (string folioaux in foliosList)
            //    {
            //        generadorPDFSinVariables(folioaux);
            //    }

            //    string writer = Server.MapPath("~/Archivos/"); 

            //    conf.EnviarCorreoConfirmacion(idProducto, folios, writer);
            //    folios = "";
            //}
            #endregion


        }
        //string[] files = Directory.GetFiles(writer);
        //       foreach (string file in files)
        //       {
        //           File.Delete(file);

        //       }

        return true;
    }

    public bool eliminarOperacionParaReenviar()
    {
        string[] operacionesList = operaciones.Split(',');

        foreach (string operacion in operacionesList)
        {
            string[] detalleOperacionList = operacion.Split('|');
            string rut = detalleOperacionList[0].ToString();
            string folio = detalleOperacionList[1].ToString();
            folioReenvio = folio;
            string origen = detalleOperacionList[2].ToString();
            Confirmacion conf = new Confirmacion();
            conf.EliminaOperacionPorReenvio(idProducto, folio);
        }
        return true;
    }


    public bool generadorPDFSIM(string FOLIO_TRANS, string RUT_CLI, string FEC_TRANS, string resultadoCreacion)
    {
        try
        {
            Confirmacion conf = new Confirmacion();
            DataTable dt = new DataTable();
            dt = conf.consultarOperacionesPorFolioSIM(FOLIO_TRANS, RUT_CLI, FEC_TRANS);
            //seteo en ingles
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime f = DateTime.Now;

            int yyyy = f.Year;
            int dd = f.Day;
            string mm = f.ToString("MM");
            string x = f.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"));
            String fechaL = (dd + " de " + x + " del " + yyyy).ToString();

            lblFechaHoy.Text = fechaL.ToString();
            foreach (DataRow row in dt.Rows)
            {

                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                double cadenaPrecFu = Convert.ToDouble(row["MONTO"].ToString(), CultureInfo.InvariantCulture);
                double precio = Convert.ToDouble(row["PRECIO"].ToString(), CultureInfo.InvariantCulture);
              
                lblFolio.Text = row["FOLIO_TRANS"].ToString();
                lblFecha.Text = row["FEC_TRANS"].ToString();
                lblIntrumento.Text = row["NEMO"].ToString();
                lblCantidad.Text = row["CANTIDAD"].ToString();

             lblPrecioPH.Text = ("$" + String.Format("{0:#,##0.00}", precio)).ToString();
                lblMontoPH.Text = ("$"+String.Format("{0:#,##0.00}",cadenaPrecFu)).ToString();
                  lblFechaVen.Text = row["FEC_VCTO_TP"].ToString();

                //  lblOpPlazo.Text = row["IND_TIT_CUS"].ToString();
                lblTasaFinan.Text = row["TASA"].ToString();
                lblComision.Text = row["tasa_comision"].ToString();//verificar comision Math.Round(3.44, 1);
                lblOperacion.Text = row["TIPO_OPERAC"].ToString();

                lblCliente.Text = row["RSO_RAZ_SOCIAL"].ToString();
                lblRutCliente.Text = row["RUT_CLI"].ToString();
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 20f, 10f);// iz -arr-der-aba

            //string ruta = HttpContext.Current.Server.MapPath(folio + ".pdf");
            //string ruta = Server.MapPath(ConfigurationManager.AppSettings["RutaArchivos"].ToString() + folio + ".pdf");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string mes = DateTime.Now.ToString("MMMM");
            string anio = DateTime.Now.ToString("yyyy");
            string ruta = "";
            string ruta1 = (ConfigurationManager.AppSettings["RutaArchivos"].ToString() + "\\Simultanea\\" + anio + "\\" + mes + "\\");
            if (Directory.Exists(ruta1)) { ruta = ruta1; }
            else { Directory.CreateDirectory(ruta1); }
            FileStream streaming = new FileStream((ruta1 + "/" + FOLIO_TRANS + ".pdf"), FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, streaming);

            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/Encabezado.jpg"));
            addLogo.SetAbsolutePosition(0f, 780f);
            addLogo.ScalePercent(50f);

            iTextSharp.text.Image addFooter = default(iTextSharp.text.Image);
            addFooter = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/pie_correo_simultanea.jpg"));
            addFooter.SetAbsolutePosition(0f, 0f);
            addFooter.ScalePercent(50f);

            pdfDoc.Open();
            pdfDoc.Add(addLogo);
            pdfDoc.Add(addFooter);

            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();


            return true;
    }
        catch (Exception ex)
        {
            string error = ex.ToString();
            //generadorPDF2(folio);
            return false;

        }
    }

    public string reemplazarSeparadorMiles(String numero)
    {
        numero = numero.Replace(".", "_");
        numero = numero.Replace(",", ".");
        numero = numero.Replace("_", ",");
        return numero;

    }

}