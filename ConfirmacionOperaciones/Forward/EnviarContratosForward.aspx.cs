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
using AppCode;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

public partial class Forward_EnviarContratosForward : System.Web.UI.Page
{
    string idProducto;
    string operaciones;
    string reenvio;
    string folioReenvio;
    protected void Page_Load(object sender, EventArgs e)
    {
        idProducto = Request.Form["idProducto"].ToString();
        operaciones = Request.Form["Operaciones"].ToString();

        enviarOperacionesConfirmacion();

        Response.Write("OK");
        Response.End();

    }

    public bool enviarOperacionesConfirmacion()
    {
        string writer = "";
        string[] operacionesList = operaciones.Split(',');
        foreach (string operacion in operacionesList)
        {
            string[] detalleOperacionList = operacion.Split('|');
            string rut = detalleOperacionList[0].ToString();
            string folio = detalleOperacionList[1].ToString();
            string origen = detalleOperacionList[2].ToString();
            string nombreEmpresa = detalleOperacionList[3].ToString();

            Confirmacion conf = new Confirmacion();
            String resultadoCreacion = "";
            resultadoCreacion = conf.registrarContrato(folio);


            string rutagenerada = generadorPDF(folio);

            string folioOp = folio + "|" + resultadoCreacion;
            writer = (ConfigurationManager.AppSettings["RutaArchivos"].ToString());
            conf.EnviarCorreoContrato(idProducto, folioOp, writer, nombreEmpresa, rut, rutagenerada);


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

        return true;
    }

    public string generadorPDF(string folio)
    {
        try
        {
            Confirmacion conf = new Confirmacion();
            DataTable dt = new DataTable();
            dt = conf.consultarOperacionesPorFolioContratos("1", folio);
            lblfolio.Text = "Folio: <strong>" + folio + "</strong>";

            foreach (DataRow row in dt.Rows)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

                //lblfolio.Text = row["Folio"].ToString();
                //Seteo de varibles para el pdf
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                string fecha = row["FechaOperacion"].ToString();
                
                //conversion de la fecha para visualizarlo segun formato
                DateTime oDate = Convert.ToDateTime(fecha);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                string fechaoperacion = oDate.Day + " de " + oDate.ToString("MMMMM") + " del " + oDate.Year;
                lblfechaoperacion.Text = fechaoperacion;

                //seteo de varaibles del PDF
                lblcliente.Text = row["Cliente"].ToString();
                lblrutcliente.Text = row["RutCliente"].ToString();
                lbldomiciliocliente.Text = row["Direccion"].ToString();

                lbltipodemoneda.Text = row["NomMoneda"].ToString().Trim();
                lblmonedanemo.Text = row["NemoMoneda"].ToString().Trim();
                string detectaUF = "";
                if (row["Cod.Mon.Secu"].ToString().Trim() == "UF" || row["Cod.Mon.Princ"].ToString().Trim() == "UF")
                {
                    detectaUF = "CONUF";
                    lbletra1.Text = "<strong>c)&nbsp;Unidad de Fomento:&nbsp;</strong>Aquella que se refiere el capitulo&nbsp;II, B.3.&nbsp;del Compendio de Normas Financieras de Banco Central de Chile, por su&nbsp;valor vigente al día de la Liquidación en relación al N° 9) del Artículo 35 de la Ley N° 18.840.";
                    lbletra2.Text = "d)";
                    lbletra3.Text = "e)";
                }
                else
                {
                    detectaUF = "SINUF";
                    lbletra1.Text = "";
                    lbletra2.Text = "c)";
                    lbletra3.Text = "d)";
                }

                lblnombremoneda.Text = "Dolares";//row["NomMoneda"].ToString(); //falta definicion por claudio (donde obtener la palabra Dólares)
                lbltipodemoneda2.Text = row["NomMoneda"].ToString().Trim();
                lblpaismoneda.Text = "Moneda nacional de ";//row["NemoMoneda"].ToString(); //falta definicion por claudio (Moneda nacional de...)

                lblvendedor.Text = row["Cliente"].ToString();
                lblcomprador.Text = "Credicorp Capital S.A. Coredores de bolsa";//row["Cliente"].ToString();
                lbltiptran.Text = "Forward";//row["Modalidad"].ToString();
                lblfechacierre.Text = fechaoperacion;//row["fechaoperacion"].ToString();
                
                DateTime fechavencimiento = Convert.ToDateTime(row["FechaVencimiento"].ToString());
                string formatofechaven = fechavencimiento.Day + " de " + fechavencimiento.ToString("MMMMM") + " del " + fechavencimiento.Year;
                lblfechavenc.Text = formatofechaven;//row["FechaVencimiento"].ToString();
                lblmodalidad.Text = row["Modalidad"].ToString();

                //formateo y concatenacion de cantidad de moneda comprada
                string montPrinc = row["MtoMonPrinc"].ToString();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                double cadenaMonto = Convert.ToDouble(montPrinc, CultureInfo.InvariantCulture);
                string formatoMonto = String.Format("{0:#,##0.0000}", cadenaMonto);
                string formatofinalMonto = reemplazarSeparadorMiles(formatoMonto);
                lblcantmoneda.Text = row["Cod.Mon.Princ"].ToString() + " " + formatofinalMonto;

                //formateo de tipo de cambio forward pactado
                string tccierre = row["TCCierre"].ToString();
                double cadenaMontoTC = Convert.ToDouble(tccierre, CultureInfo.InvariantCulture);
                string formatoMontoTC = String.Format("{0:#,##0.0000}", cadenaMontoTC);
                string formatofinalMontoTC = reemplazarSeparadorMiles(formatoMontoTC);
                lbltipoforward.Text = formatofinalMontoTC;

                lblparidadforward.Text = "N.A.";//row["Modalidad"].ToString();

                //formateo de tipo de cambio forward pactado
                string valorpactado = row["MtoMonSecu"].ToString();
                double cadenaMontoVP = Convert.ToDouble(valorpactado, CultureInfo.InvariantCulture);
                string formatoMontoVP = String.Format("{0:#,##0.0000}", cadenaMontoVP);
                string formatofinalMontoVP = reemplazarSeparadorMiles(formatoMontoVP);
                lblvalorpactado.Text = row["Cod.Mon.Princ"].ToString() + " " + formatofinalMontoVP;

                lbltipocambio.Text = "Dólar Observado";//row["Modalidad"].ToString();
                lblparidadreferencia.Text = "N.A.";//row["Modalidad"].ToString();
                lbllugarforma.Text = "Apoquindo 3721 - Piso 9";//row["Modalidad"].ToString();
                lblcliente2.Text = row["Cliente"].ToString();
                if(detectaUF == "SINUF")
                {
                    lblCredicorp.Text = "<br /><br />Credicorp Capital S.A. Corredores de Bolsa";
                }
                else
                {
                    lblCredicorp.Text = "Credicorp Capital S.A. Corredores de Bolsa";
                }
                
            }


            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 8f, 30f, 8f);
            string ruta = ConfigurationManager.AppSettings["RutaArchivos"].ToString();

            //busqueda y creacion de carpetas dinamicas
            string mes = DateTime.Now.ToString("MMMM");
            string anio = DateTime.Now.ToString("yyyy");
            string rutafinal = "";
            string rutaConfirmaciones = ruta + "Forward\\Contratos\\" + anio + "\\" + mes + "\\";
            if (Directory.Exists(rutaConfirmaciones))
            {
                rutafinal = rutaConfirmaciones;
            }
            else
            {
                Directory.CreateDirectory(rutaConfirmaciones);
                rutafinal = rutaConfirmaciones;
            }

            FileStream streaming = new FileStream((rutafinal + folio + ".pdf"), FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, streaming);
            //Logo credicorp
            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/logo-credicorp.png"));
            addLogo.SetAbsolutePosition(28f, 780f);
            addLogo.ScalePercent(50f);

            //firma analista
            iTextSharp.text.Image addFirma1 = default(iTextSharp.text.Image);
            addFirma1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/DavidFirma.jpg"));
            addFirma1.SetAbsolutePosition(33f, 40);
            addFirma1.ScalePercent(59f);

            //firma gerente
            iTextSharp.text.Image addFirma2 = default(iTextSharp.text.Image);
            addFirma2 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/FelipeFirma.jpg"));
            addFirma2.SetAbsolutePosition(125f, 40);
            addFirma2.ScalePercent(59f);

            pdfDoc.Open();
            pdfDoc.Add(addLogo);
            pdfDoc.Add(addFirma1);
            pdfDoc.Add(addFirma2);
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();
            return rutafinal;
        }
        catch (Exception ex)
        {
            string error = ex.ToString();
            return "Error";

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