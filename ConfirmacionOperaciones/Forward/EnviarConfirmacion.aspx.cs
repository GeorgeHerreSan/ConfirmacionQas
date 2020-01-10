﻿using System;
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

public partial class Forward_EnviarConfirmacion : System.Web.UI.Page
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
            string folio =detalleOperacionList[1].ToString();
            string origen = detalleOperacionList[2].ToString();
            string nombreEmpresa = detalleOperacionList[3].ToString();

            Confirmacion conf = new Confirmacion();
            String resultadoCreacion = "";
            resultadoCreacion = conf.crearOperacionConfirmacion(idProducto, folio, origen);


            string PDFenRuta = generadorPDF(folio);

            string folioOp = folio + "|" + resultadoCreacion;
            //writer = Server.MapPath("~/Archivos/");
            //writer = Server.MapPath(ConfigurationManager.AppSettings["RutaArchivos"].ToString());
            //writer = (ConfigurationManager.AppSettings["RutaArchivos"].ToString());
            conf.EnviarCorreoConfirmacion(idProducto, folioOp, PDFenRuta, nombreEmpresa, rut);


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

    public string generadorPDF(string folio)
    {
        try
        {
            Confirmacion conf = new Confirmacion();
            DataTable dt = new DataTable();
            dt =  conf.consultarOperacionesPorFolio("1",folio);
            LblNumeroOP.Text = folio;

            foreach (DataRow row in dt.Rows)
            {

                //lblFechaInicio.Text = row["FechaInicio"].ToString();
                DateTime fecha1inicio = DateTime.Parse(row["FechaInicio"].ToString(), CultureInfo.CreateSpecificCulture("es-ES"));
                string formattedfecha1 = fecha1inicio.ToString("dd-MM-yyyy");
                //string dia = Convert.ToString(fecha1inicio.Month);
                //string mes = Convert.ToString(fecha1inicio.Day);
                //string anio = Convert.ToString(fecha1inicio.Year);
                //string fechacompleta = dia + "-" + mes + "-" + anio;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                lblFechaInicio.Text = formattedfecha1;

                //OBTIENE VALORES REFERENCIALES
                DataTable dtvalores = new DataTable();
                dtvalores = conf.ObtenerValores(row["FechaInicio"].ToString());
                string uf = "";
                string dolar = "";
                string euro = "";
                foreach (DataRow row2 in dtvalores.Rows)
                {
                    dolar = reemplazarSeparadorMiles(row2["dolar"].ToString());
                    euro = reemplazarSeparadorMiles(row2["euro"].ToString());
                    uf = reemplazarSeparadorMiles(row2["uf"].ToString());
                }
                lblUF.Text = uf.ToString();
                lblPrecioReferencialMercado.Text = dolar.ToString();

                string tipop = row["TipoMov"].ToString();

                if (tipop == "COMPRA" || tipop == "compra" || tipop == "Compra")
                {
                    lblComprador.Text = "Credicorp Capital S.A. Corredores de Bolsa";
                    lblVendedor.Text = row["RazonSocial"].ToString();
                    lblOperadorII.Text = row["UsuarioCreador"].ToString();
                    lblOperadorI.Text = "";
                }
                else if (tipop == "VENTA" || tipop == "venta" || tipop == "Venta")
                {
                    lblVendedor.Text = "Credicorp Capital S.A. Corredores de Bolsa";
                    lblComprador.Text = row["RazonSocial"].ToString();
                    lblOperadorI.Text = row["UsuarioCreador"].ToString();
                    lblOperadorII.Text = "";
                }
                else
                {
                    lblComprador.Text = "";
                    lblVendedor.Text = "";
                }

                lblTipoOperacion.Text = row["TipoMov"].ToString();

                string cadena = row["MtoMonPrinc"].ToString();

                if (cadena.Contains("."))
                {
                    string[] montosep = cadena.Split('.');
                    string compa1 = montosep[1];

                    if (montosep[1].Length == 0)
                    {
                        lblMonto.Text = cadena + ".0000";
                    }
                    else if (montosep[1].Length == 1)
                    {
                        lblMonto.Text = cadena + "000";
                    }
                    else if (montosep[1].Length == 2)
                    {
                        lblMonto.Text = cadena + "00";
                    }
                    else if (montosep[1].Length == 3)
                    {
                        lblMonto.Text = cadena + "00";
                    }
                    else if (montosep[1].Length == 4)
                    {
                        lblMonto.Text = cadena;
                    }
                    else
                    {
                        lblMonto.Text = cadena;
                    }
                }
                else
                {
                    lblMonto.Text = cadena + ".0000";
                }

                lblMonto.Text = row["CodMonPrinc"].ToString() + " " + reemplazarSeparadorMiles(lblMonto.Text);

                lblTasa.Text = "N/A";


                string cadena2 = row["TcCierre"].ToString();

                if (cadena2.Contains("."))
                {
                    string[] montosep = cadena2.Split('.');
                    string compa1 = montosep[1];

                    if (montosep[1].Length == 0)
                    {
                        lblPrecioFuturo.Text = cadena2 + ".0000";
                    }
                    else if (montosep[1].Length == 1)
                    {
                        lblPrecioFuturo.Text = cadena2 + "000";
                    }
                    else if (montosep[1].Length == 2)
                    {
                        lblPrecioFuturo.Text = cadena2 + "00";
                    }
                    else if (montosep[1].Length == 3)
                    {
                        lblPrecioFuturo.Text = cadena2 + "00";
                    }
                    else if (montosep[1].Length == 4)
                    {
                        lblPrecioFuturo.Text = cadena2;
                    }
                    else
                    {
                        lblPrecioFuturo.Text = cadena2;
                    }
                }
                else
                {
                    lblPrecioFuturo.Text = cadena2 + ".0000";
                }

                lblPrecioFuturo.Text = row["CodMonPrinc"].ToString() + " / " + row["CodMonSecu"].ToString() + " " + reemplazarSeparadorMiles(lblPrecioFuturo.Text);



                string cadena3 = row["MtoMonSecu"].ToString();

                if (cadena3.Contains("."))
                {
                    string[] montosep = cadena3.Split('.');
                    string compa1 = montosep[1];
                    if (montosep[1].Length == 0)
                    {
                        lblMontoFinal.Text = cadena3 + ".0000";
                    }
                    else if (montosep[1].Length == 1)
                    {
                        lblMontoFinal.Text = cadena3 + "000";
                    }
                    else if (montosep[1].Length == 2)
                    {
                        lblMontoFinal.Text = cadena3 + "00";
                    }
                    else if (montosep[1].Length == 3)
                    {
                        lblMontoFinal.Text = cadena3 + "00";
                    }
                    else if (montosep[1].Length == 4)
                    {
                        lblMontoFinal.Text = cadena3;
                    }
                    else
                    {
                        lblMontoFinal.Text = cadena3;
                    }
                }
                else
                {
                    lblMontoFinal.Text = cadena3 + ".0000";
                }
                lblMontoFinal.Text = row["CodMonSecu"].ToString() + " " + reemplazarSeparadorMiles(lblMontoFinal.Text);


                lblPlazo.Text = row["Dias"].ToString() + " días";

                    DateTime fechauxformato = Convert.ToDateTime(row["FechaVcto"].ToString(), CultureInfo.CreateSpecificCulture("es-ES"));
                    string formatted = fechauxformato.ToString("dd-MM-yyyy");
                    DateTime fechauxformato2 = Convert.ToDateTime(formatted);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                    lblFechaVencimiento.Text = String.Format("{0:D}", fechauxformato2.ToLongDateString());

                lblModalidadPago.Text = row["Modalidad"].ToString();
                lblFechaValuta.Text = lblFechaVencimiento.Text;


                string tipmoneda = row["CodMonPrinc"].ToString();
                if (tipmoneda == "USD")
                {
                    lblValorReferencialSalida.Text = "Dólar observado";
                }
                else if (tipmoneda == "UF")
                {
                    lblValorReferencialSalida.Text = "Unidad de fomento";
                }
                else
                {
                    lblValorReferencialSalida.Text = tipmoneda;
                }

                lblFixing.Text = "Bloomberg";

                lblNombreEmpresaFirma.Text = row["RazonSocial"].ToString();

            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 100f, 0f);
            //string ruta = (ConfigurationManager.AppSettings["RutaArchivos"].ToString() + folio + ".pdf");
            string ruta = ConfigurationManager.AppSettings["RutaArchivos"].ToString();
            //busqueda y creacion de carpetas dinamicas
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string mes = DateTime.Now.ToString("MMMM");
            string anio = DateTime.Now.ToString("yyyy");
            
            string rutafinal = "";
            string rutaConfirmaciones = ruta + "Forward\\Confirmaciones\\" + anio + "\\" + mes + "\\";
            if (Directory.Exists(rutaConfirmaciones))
            {
                rutafinal = rutaConfirmaciones;
            }
            else
            {
                Directory.CreateDirectory(rutaConfirmaciones);
                rutafinal = rutaConfirmaciones;
            }

            FileStream streaming = new FileStream(rutafinal + folio + ".pdf", FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, streaming);

            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/Encabezado.jpg"));
            addLogo.SetAbsolutePosition(0f, 780f);
            addLogo.ScalePercent(50f);

            iTextSharp.text.Image addFooter = default(iTextSharp.text.Image);
            addFooter = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/footerpdf.jpg"));
            addFooter.SetAbsolutePosition(0f, 0f);
            addFooter.ScalePercent(50f);

            pdfDoc.Open();
            pdfDoc.Add(addLogo);
            pdfDoc.Add(addFooter);

            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();

            return rutafinal;
        }
        catch(Exception ex)
        {
            string error = ex.ToString();
            return "Se ha encontrado un error: " + error;
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