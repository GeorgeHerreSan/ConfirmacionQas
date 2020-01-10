using AppCode;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forward_EnviarConfirmacionBlotter : System.Web.UI.Page
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
            string[] operacionesList = operaciones.Split(',');
            //string[] operacionesList = operaciones.Split(';');
            foreach (string operacion in operacionesList)
            {
           
                string[] detalleOperacionList = operacion.Split('|');
                string fechaInicio = detalleOperacionList[0].ToString();
                string folioOperacion = detalleOperacionList[1].ToString();
                string fechaVencimiento = detalleOperacionList[2].ToString();
                string rut = detalleOperacionList[3].ToString();
                string secuencia = detalleOperacionList[4].ToString();
                string nombreCliente = detalleOperacionList[5].ToString();
                string tipoMovimiento = detalleOperacionList[6].ToString();
                string monedaPrincipal = detalleOperacionList[7].ToString();
                string montoPrincipal = detalleOperacionList[8].ToString();
            
                string monedaSecundario = detalleOperacionList[9].ToString();
                string tcCierreForward = detalleOperacionList[10].ToString();
                string montoSecundario = detalleOperacionList[11].ToString();
                string cumplimiento = detalleOperacionList[12].ToString();
                string agente = detalleOperacionList[13].ToString();
                string vehiculo = detalleOperacionList[17].ToString();

                string recibimosPagamos = detalleOperacionList[22].ToString();
                string monedaAnticipo = detalleOperacionList[23].ToString();


            Confirmacion conf = new Confirmacion();
            String resultadoCreacion = "";
                

                resultadoCreacion = conf.crearOperacionConfirmacionBlotter(idProducto,fechaInicio.Replace("/","-"),folioOperacion,fechaVencimiento.Replace("/", "-"), rut
                                                      ,secuencia,nombreCliente,tipoMovimiento,monedaPrincipal,montoPrincipal, monedaSecundario
                                                      , tcCierreForward, montoSecundario, cumplimiento, agente, folioOperacion, folioOperacion, folioOperacion, folioOperacion
                                                      ,folioOperacion, folioOperacion, folioOperacion, folioOperacion, folioOperacion, recibimosPagamos, monedaAnticipo
                                                      );


                string rutaPDF = generadorPDF(idProducto, fechaInicio, folioOperacion, fechaVencimiento, rut
                                                      , secuencia, nombreCliente, tipoMovimiento, monedaPrincipal, montoPrincipal, monedaSecundario
                                                      , tcCierreForward, montoSecundario, cumplimiento, agente, folioOperacion, vehiculo, vehiculo, vehiculo
                                                      , vehiculo, vehiculo, folioOperacion, folioOperacion, folioOperacion);

                //string writer = Server.MapPath("~/Archivos/");
                //string writer = ConfigurationManager.AppSettings["RutaArchivos"].ToString(); 


                string folioOp = folioOperacion + "|" + resultadoCreacion;
                conf.EnviarCorreoConfirmacion(idProducto, folioOp, rutaPDF, nombreCliente, rut);


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

        public string generadorPDF(String idProducto
                                                     , String fechaInicio
                                                     , String Folio
                                                     , String fechaVencimiento
                                                     , String rut
                                                     , String secuencia
                                                     , String nombreCliente
                                                     , String tipoMovimiento
                                                     , String monedaPrincipal
                                                     , String montoPrincipal
                                                     , String monedaSecundario
                                                     , String tcCierreForward
                                                     , String montoSecundario
                                                     , String cumplimiento
                                                     , String agente
                                                     , String montoLiquidacion
                                                     , String margen
                                                     , String cartera
                                                     , String vehiculo
                                                     , String folioAsociado
                                                     , String comentario
                                                     , String fixingDate
                                                     , String fechaAnticipo
                                                     , String tasaAnticipo)
        {
            //try
            //{
                Confirmacion conf = new Confirmacion();
                DataTable dt = new DataTable();
               
                LblNumeroOP.Text = Folio;
                lblFechaInicio.Text = fechaInicio;
                //OBTIENE VALORES REFERENCIALES
                DataTable dtvalores = new DataTable();
                dtvalores = conf.ObtenerValores(fechaInicio.Substring(0,10).Replace("/","-"));
                string uf = "";
                string dolar = "";
                string euro = "";
                foreach (DataRow row2 in dtvalores.Rows)
                {
                    dolar = reemplazarSeparadorMiles(row2["dolar"].ToString());
                    euro = reemplazarSeparadorMiles(row2["euro"].ToString());
                    uf = reemplazarSeparadorMiles(row2["uf"].ToString());
                }
                lblUF.Text = uf.ToString();//row["FechaInicio"].ToString();
                lblPrecioReferencialMercado.Text = dolar.ToString();//row["FechaInicio"].ToString();

                //regla de compra y venta
                string tipop = tipoMovimiento;

                if (tipop == "COMPRA" || tipop == "compra" || tipop == "Compra")
                {
                    if (vehiculo == "Corredora" || vehiculo == "corredora" || vehiculo == "CORREDORA")
                    {
                        lblComprador.Text = "CREDICORP CAPITAL S.A. CORREDORES DE BOLSA";
                    }else if (vehiculo == "Holding" || vehiculo == "HOLDING" || vehiculo == "holding")
                    {
                        lblComprador.Text = "CREDICORP CAPITAL CHILE S.A.";
                    }
                    else
                    {
                        lblComprador.Text = "";
                    }
                    lblVendedor.Text = nombreCliente;
                    lblOperadorII.Text = agente;
                    lblOperadorI.Text = "";
            }
                else if (tipop == "VENTA" || tipop == "venta" || tipop == "Venta")
                {
                    if (vehiculo == "Corredora" || vehiculo == "corredora" || vehiculo == "CORREDORA")
                    {
                        lblVendedor.Text = "CREDICORP CAPITAL S.A. CORREDORES DE BOLSA";
                    }
                    else if (vehiculo == "Holding" || vehiculo == "HOLDING" || vehiculo == "holding")
                    {
                        lblVendedor.Text = "CREDICORP CAPITAL CHILE S.A.";
                    }
                    else
                    {
                        lblVendedor.Text = "";
                    }
                    lblComprador.Text = nombreCliente;
                    lblOperadorII.Text = "";
                    lblOperadorI.Text = agente;
                }
                else
                {
                    lblComprador.Text = "Nombre no reconocido"; //row["ejecutivo"].ToString();
                    lblVendedor.Text = "Nombre no reconocido";//row["RazonSocial"].ToString();
                }

                
                lblTipoOperacion.Text = tipoMovimiento;

                //conversion de montos, importante usar en ingles la conversion para evitar problemas con las comas y puntos 
                //la funcion reemplazarSeparadorMiles se encarga de voltear los puntos y comas
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                double cadenaMonto = Convert.ToDouble(montoPrincipal, CultureInfo.InvariantCulture);
                string formatoMonto = String.Format("{0:#,##0.0000}", cadenaMonto);
                string cadenas2 = reemplazarSeparadorMiles(formatoMonto);

                lblMonto.Text = monedaPrincipal +" "+ cadenas2;

                lblTasa.Text = "N/A";//row["TcCierre"].ToString();

                string cadena2 = tcCierreForward;
                double cadenaPrecFu = Convert.ToDouble(cadena2, CultureInfo.InvariantCulture);
                string formatoPrecioFuturo = String.Format("{0:#,##0.0000}", cadenaPrecFu);
                string cadenas3 = reemplazarSeparadorMiles(formatoPrecioFuturo);

                lblPrecioFuturo.Text = monedaPrincipal + " / " + monedaSecundario + " " + cadenas3;

                string cadena3 = montoSecundario;
                double cand = Convert.ToDouble(cadena3, CultureInfo.InvariantCulture);
                string formatoMontoFinal = String.Format("{0:#,##0.0000}", cand);
                string cadenas4 = reemplazarSeparadorMiles(formatoMontoFinal);
                double resultadoAproximadoCLP = Convert.ToDouble(Math.Round(cand));
                string formateofn = String.Format("{0:n}", resultadoAproximadoCLP);

                if(monedaSecundario == "CLP")
                {
                    if (formateofn.Contains("."))
                    {
                        string[] montosep = formateofn.Split('.');
                        string compa1 = montosep[0];
                        
                        cadenas4 = reemplazarSeparadorMiles(compa1 + ".0000");
                    }
                }
                lblMontoFinal.Text = monedaSecundario + " " + cadenas4;


                //conversion de fechas, importante usar en español debido a que se mostrará de esa manera
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                DateTime fechauxformato = Convert.ToDateTime(fechaVencimiento);
                string formatted = fechauxformato.ToString("dd-MM-yyyy");
                DateTime fechauxformato2 = Convert.ToDateTime(formatted);

                //formato y calculo de dias para el plazo
                DateTime fechaIni = Convert.ToDateTime(fechaInicio);
                DateTime fechaVen = Convert.ToDateTime(fechaVencimiento);
                string formFechIni = fechaIni.ToString("dd-MM-yyyy");
                string formfechVen = fechaVen.ToString("dd-MM-yyyy");
                DateTime fechaIniFin = Convert.ToDateTime(formFechIni);
                DateTime fechaVenFin = Convert.ToDateTime(formfechVen);

                TimeSpan ts = fechaVenFin - fechaIniFin;
                int plazoVen = ts.Days;

                lblPlazo.Text = plazoVen +" días";
                
                lblFechaVencimiento.Text = String.Format("{0:D}", fechauxformato2.ToLongDateString());  
                lblFechaValuta.Text = lblFechaVencimiento.Text;

                lblModalidadPago.Text = cumplimiento;
                //lblFechaValuta.Text = fechaVencimiento;

                string tipmoneda = monedaPrincipal;
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
                //queda como fijo como bloomberg por orden de Hector Nuñez en reunion del 19-07-19
                lblFixing.Text = "Bloomberg";//fixingDate;//row["FechaInicio"].ToString();

                lblNombreEmpresaFirma.Text = nombreCliente;

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

                //Se insertan imagenes, informacion y HTML en el PDF
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                this.Page.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 100f, 0f);

                FileStream streaming = new FileStream(rutafinal + Folio + ".pdf", FileMode.Create);
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
        //}
        //    catch (Exception ex)
        //    {
        //        string error = ex.ToString();
        //        return error;
        //    }
        }


    public string reemplazarSeparadorMiles(String numero)
    {
        numero = numero.Replace(".", "_");
        numero = numero.Replace(",", ".");
        numero = numero.Replace("_", ",");
        return numero;

    }

}

