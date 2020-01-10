﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace AppCode
{
    public class Confirmacion
    {
        String idProducto;
        String folio;

        public string IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }

        public string Folio
        {
            get
            {
                return folio;
            }

            set
            {
                folio = value;
            }
        }

        public Button send { get; private set; }

        //public string IdProducto { get => idProducto; set => idProducto = value; }
        //public string Folio { get => folio; set => folio = value; }

        public string crearOperacionConfirmacion(String idProducto, String idFolio, String origen)
        {
            string salidId = "";
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            if (origen == "SIGA")
            {
                origen = "1";
            }
            if (origen == "BLOTTER")
            {
                origen = "2";
            }

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@folio", idFolio);
            parameters[2] = conect.agregaParametros("@origen", origen);
            dt = conect.EjecutarSP_Parametros("SP_CO_ENVIAR_CONFIRMACION", parameters);

            foreach (DataRow row in dt.Rows)
            {
                salidId = row[0].ToString();
            }

            return salidId;
        }
		public string registrarContrato(String idFolio)
        {
            string salidId = "";
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@folio", idFolio);
            dt = conect.EjecutarSP_Parametros("SP_CO_FWD_REGISTRAR_CONTRATOS", parameters);

            return salidId;
        }
        public string crearOperacionConfirmacionSIM(String idProducto, String idFolio, String origen, String FEC_TRANS, String RUT_CLI)
        {
            //idProducto, FOLIO_TRANS, origen,FEC_TRANS,RUT_CLI    idProducto, folio, origen
            string salidId = "";
            //  string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            //  DataTable dt = new DataTable();
            //   Conexion conect = new Conexion(conexion_string);

            if (origen == "SIGA")
            {
                origen = "1";
            }
            if (origen == "BLOTTER")
            {
                origen = "2";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
          
            DateTime fec_trans_date = Convert.ToDateTime(FEC_TRANS);
            int yyyy = fec_trans_date.Year;
            int mm = fec_trans_date.Month;
            int dd = fec_trans_date.Day;
            string COD_PAR = yyyy + "-" + mm.ToString();
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);
            //  String idProducto = "2";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = conect.agregaParametros("@folio", idFolio);
            parameters[1] = conect.agregaParametros("@rut_cli", RUT_CLI);
            parameters[2] = conect.agregaParametros("@FEC_TRANS", FEC_TRANS);
            parameters[3] = conect.agregaParametros("@COD_PAR", COD_PAR);
            parameters[4] = conect.agregaParametros("@idProducto", idProducto);
            parameters[5] = conect.agregaParametros("@origen", origen);
            dt = conect.EjecutarSP_Parametros("SP_CO_SIM_INSERT_PARAMETROS_SIM", parameters);
            // SqlParameter[] parameters = new SqlParameter[3];
            //  parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            //  parameters[1] = conect.agregaParametros("@folio", idFolio);
            //   parameters[2] = conect.agregaParametros("@origen", origen);
            //  dt = conect.EjecutarSP_Parametros("SP_CO_ENVIAR_CONFIRMACION", parameters);

            foreach (DataRow row in dt.Rows)
            {
                salidId = row[0].ToString();
            }

            return salidId;
        }

        public DataTable consultarOperaciones(String idProducto, String fecha, String idCliente, String NOperacion, String estado, String estadoContrato)
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            if (fecha == "")
                fecha = "VACIO";

            if (idCliente == "")
                idCliente = "VACIO";

            if (NOperacion == "")
                NOperacion = "VACIO";

            if (estado == "")
                NOperacion = "VACIO";

            if (estadoContrato == "9")
                estadoContrato = "VACIO";

            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@fecha", fecha);
            parameters[2] = conect.agregaParametros("@idCliente", idCliente);
            parameters[3] = conect.agregaParametros("@NOperacion", NOperacion);
            parameters[4] = conect.agregaParametros("@estado", estado);
            parameters[5] = conect.agregaParametros("@estadoContrato", estadoContrato);
            dt = conect.EjecutarSP_Parametros("SP_CO_CONSULTAR_OPERACIONES", parameters);
            return dt;

        }

        public DataTable consultarOperacionesVen(String fecha, String estado)
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            //if (idCliente == "")
            //    idCliente = "VACIO";

            //if (NOperacion == "")
            //    NOperacion = "VACIO";

            //if (estado == "")
            //    NOperacion = "VACIO";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = conect.agregaParametros("@fechaBusqueda", fecha);
            parameters[1] = conect.agregaParametros("@estado", estado);
            dt = conect.EjecutarSP_Parametros("Sp_CO_consulta_vencimientos", parameters);
            return dt;

        }

        public void EnviarCorreoConfirmacionSIM(String idProducto, String folio, String adjunto, String nombreEmpresa, String idCliente, String FEC_TRANS, String resultadoCreacion)
        {
           // idProducto, FOLIO_TRANS, writer, RSO_RAZ_SOCIAL, RUT_CLI
            /*-------------------------MENSAJE DE CORREO----------------------*/

            string producto = ObtenerNombreProducto(idProducto); //se debe crear metodo que devuelve nombre de producto;

            List<String> detalle = ObtenerDetalleCorreoSIM(idProducto, producto, folio, nombreEmpresa);
            string direccion = detalle[0].ToString();
            string body = detalle[1].ToString();

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            Correo co = new Correo();
            DataTable destinatario = co.ObtenerCorreoCliente(idProducto, idCliente);
            string switchcorreo = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (switchcorreo == "false")
            {
                foreach (DataRow row in destinatario.Rows)
                {
                    mmsg.To.Add(row[0].ToString());
                }
            }
            else
            {
                mmsg.To.Add("george.herrera@siigroup.cl");
                mmsg.To.Add("rodrigo.bahamondes@siigroup.cl");
                //mmsg.To.Add("cesar.uribe@siigroup.cl");
            }

            string[] folioOperacion = folio.Split('|');
            string folioAux = folioOperacion[0].ToString();
           // string idOperacion = folioOperacion[1].ToString();


            //Asunto
            mmsg.Subject = "Confirmación de " + producto + " " + nombreEmpresa + " Folio Op:" + folioAux;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //string correocopia = ConfigurationManager.AppSettings["correoCC"].ToString();
            //mmsg.Bcc.Add(correocopia); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje

            string correorem = ConfigurationManager.AppSettings["correoRemitente"].ToString();
            string clavecorreorem = ConfigurationManager.AppSettings["clavecorreoRemitente"].ToString();
            mmsg.From = new System.Net.Mail.MailAddress(correorem);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.UseDefaultCredentials = false;
            cliente.Credentials =
                new System.Net.NetworkCredential(correorem, clavecorreorem);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

            string ambiente = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (ambiente == "true")
            {
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "SMTP.Office365.com";
            }
            else
            {
                cliente.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoMail"]);
                cliente.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSLMail"]);
                cliente.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
            }
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;


            //Archivos adjuntos.



            string[] foliosList = folioAux.Split(',');
            foreach (string folioaux1 in foliosList)
            {
                string filename = adjunto + folioaux1 + ".pdf";
                Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
                mmsg.Attachments.Add(data);
            }

            /*-------------------------ENVIO DE CORREO----------------------*/


            try
            {
                //Enviamos el mensaje      
              cliente.Send(mmsg);
                //cargar datos en tabla SIM //SP_CO_SIM_INSERT_PARAMETROS_SIM

            /*    string COD_PAR = FEC_TRANS.Substring(0,7);
                string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
                DataTable dt = new DataTable();
                Conexion conect = new Conexion(conexion_string);
              //  String idProducto = "2";
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = conect.agregaParametros("@folio", folio);
                parameters[1] = conect.agregaParametros("@rut_cli", idCliente);
                parameters[2] = conect.agregaParametros("@FEC_TRANS", FEC_TRANS);
                parameters[3] = conect.agregaParametros("@COD_PAR", COD_PAR);
                parameters[4] = conect.agregaParametros("@idProducto", idProducto);
                


                dt = conect.SP_CO_SIM_INSERT_PARAMETROS_SIM("SP_CO_SIM_INSERT_PARAMETROS_SIM", parameters);
*/
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                String error = ex.ToString();
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }
        public List<String> ObtenerDetalleCorreoSIM(String idProducto, String Producto, String idFolio, String nombreEmpresa)
        {
            string formularioCliente = ConfigurationManager.AppSettings["formularioCliente"].ToString();
            string correoDestinoProvisorio = "";


            List<String> detalle = new List<String>();

            string[] folioOperacion = idFolio.Split('|');
            string folio = folioOperacion[0].ToString();

            detalle.Add(correoDestinoProvisorio); //destinatarios
            string formularioRespuestaURL1 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + folio + "&1"));

            DateTime fechaActual = DateTime.Today;
            int yyyya = fechaActual.Year;
            int dda = fechaActual.Day;
            string mma = fechaActual.ToString("MM");
            String rutaF = "";
            string Enero = "https://i.imgur.com/QJtZwBU.png";
            string Febrero = "https://i.imgur.com/LZi5XxG.png";
            string Marzo = "https://i.imgur.com/TzdXqkY.png";
            string imagenNada = "https://confirmacionoperacionescl.credicorpcapital.cl:8443/img/cabeceras/simultaneas/";

            if (yyyya == 2020)
            {
                if (mma == "01")
                {
                    rutaF = Enero;
                }
                if (mma == "02")
                {
                    rutaF = Febrero;
                }
                if (mma == "03")
                {
                    rutaF = Marzo;
                }
            }
            else
            {
                rutaF = imagenNada + yyyya + "/" + yyyya + "-" + mma + ".png".ToString();
            }


            string formatted = fechaActual.ToString("dd/M/yyyy", CultureInfo.CreateSpecificCulture("es-ES"));

            string anio = fechaActual.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"));
            string texto = "<table width='1200'><tr><td>" +
                            "<img src='" + rutaF + "'>" +
                            "</td></tr>" +
                            "<tr><td></td></tr>" +/*< p align = 'right' > " + anio + " " + fechaActual.Year + " < p >*/
                                 "<tr><td>" +
                             "Estimado " + nombreEmpresa + ", junto con saludarlo, informamos que con fecha " + formatted + "  se realizaran las siguiente(s) "+
                            "operación(es) de simultanea(s), en conformidad a lo instruido, agradecemos confirmar mediante su firma en el documento "+
                            "adjunto, el cual debe ser enviado a la siguiente casilla electrónica: confirmacioneschile@credicorpcapital.comy "+
                            "remitir de forma física a su ejecutivo. " +
                            "<br />" +
                            "<br />" +
                            "En caso de disconformidad agradecemos contactar a su ejecutivo indicando los motivos del  <b>Rechazo</b>, para gestionar su " +
                           "corrección a la brevedad. " +
                           "<br /> <br /><br />" +
                          // "Departamento de Operaciones Financieras"+
                         //  "<br />"+
                        //   "Credicorp Capital S.A"+
                        //   "<br />" +
                       //    "Corredores de Bolsa" +
                       //    "<br />" +
                        //   "<br />" +
                            //"<img src='https://i.imgur.com/BjFOkpH.jpg'/>" +
                            "</td></tr>";
            string body = "<tr><td>" +
                           "<!DOCTYPE html>" +
                           "<html> " +
                           "<head>" +
                           "<meta charset='utf-8'/>" +
                           //"<style>" +
                           //"#contenedor{" +
                           //"border: black 1px solid;" +
                           //"text - align: center; " +
                           //"width: 50 %; " +
                           //"top: 50 %; " +
                           //"left: 50 %; " +
                           //"padding: 20px 20px 20px 20px; " +
                           //"}" +
                           //"tr{" +
                           //"    text-align:left;" +
                           //"}" +
                           //"</style>" +
                           "</head>" +
                           "<body>" +
                           "<center>" +
                           // "<h3><p style=\"text-align:center\">Confirmaci&oacute;n de operaci&oacute;n <strong>" + folio + "</strong></p></h3>" +
                            "<br>" +
                            "<br>" +
                            "<table border=\"0\">" +
                                "<tbody>" +
                                   
                                "</tbody>" +
                            "</table>" +
                           "</center>" +
                           "<br> " +
                           "</td></tr>" +
                           "<tr><td>" +
                           "<br>" +
                           
                           "<br/><br/><br/>"+
                           "Departamento de Operaciones Financieras <br/>" +
                           "Credicorp Capital S.A <br/>" +
                           "Corredores de Bolsa <br/>" +
                           "<br/><br/><br/>"+
                         //  "<img src='../ConfirmacionOperaciones/img/pie_correo_simultanea.jpg'/>" +
                           "<img src='https://i.imgur.com/BjFOkpH.jpg'/>" +
                           "</body>" +
                           "</td></tr>" +
                           "</html>";
            detalle.Add(texto + body);
            return detalle;
        }


        public void EnviarCorreoConfirmacion(String idProducto, String folio, String adjunto, String nombreEmpresa,String idCliente)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/
            Button btnCargarSIMd = (Button)send;
            //WebBrowser1.Document.GetElementById("buttonid").InvokeMember("submit")
            // $("#btnCargarSIMd").trigger("onclick");
            string producto = ObtenerNombreProducto(idProducto); //se debe crear metodo que devuelve nombre de producto;

            List<String> detalle = ObtenerDetalleCorreo(idProducto, producto, folio);
            string direccion = detalle[0].ToString();
            string body = detalle[1].ToString();

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            Correo co = new Correo();
            DataTable destinatario = co.ObtenerCorreoCliente(idProducto, idCliente);
            string switchcorreo = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (switchcorreo == "false")
            {
                foreach (DataRow row in destinatario.Rows)
            {
                mmsg.To.Add(row[0].ToString());
            }
            }
            else
            {
                mmsg.To.Add("francisco.bravo@siigroup.cl");
                //mmsg.To.Add("rodrigo.bahamondes@siigroup.cl");
                //mmsg.To.Add("cesar.uribe@siigroup.cl");
            }

            string[] folioOperacion = folio.Split('|');
            string folioAux = folioOperacion[0].ToString();
            string idOperacion = folioOperacion[1].ToString();


            //Asunto
            mmsg.Subject = "Confirmación de " + producto + " " + nombreEmpresa + " Folio Op:" + folioAux;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //string correocopia = ConfigurationManager.AppSettings["correoCC"].ToString();
            //mmsg.Bcc.Add(correocopia); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje

            string correorem = ConfigurationManager.AppSettings["correoRemitente"].ToString();
            string clavecorreorem = ConfigurationManager.AppSettings["clavecorreoRemitente"].ToString();
            mmsg.From = new System.Net.Mail.MailAddress(correorem);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.UseDefaultCredentials = false;
            cliente.Credentials =
                new System.Net.NetworkCredential(correorem, clavecorreorem);

            //Lo siguiente es obligatorio si enviamos el mensaje
            //Se revisa si esta local o produccion
            //Se debe realizar desde un correo @outlook, @hotmail o @live
            string ambiente = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (ambiente == "true")
            {
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "SMTP.Office365.com";
            }
            else
            {
                cliente.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoMail"]);
                cliente.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSLMail"]);
                cliente.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
            }
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;


            //Archivos adjuntos.
            


            string[] foliosList = folioAux.Split(',');
            foreach (string folioaux1 in foliosList)
            {
               string filename = adjunto + folioaux1 + ".pdf";
               Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
               mmsg.Attachments.Add(data);
            }

            /*-------------------------ENVIO DE CORREO----------------------*/


            try
                {
                //Enviamos el mensaje      
                cliente.Send(mmsg);

                //refrescar busqueda sim
                
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                String error = ex.ToString();
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

        public List<String> ObtenerDetalleCorreo(String idProducto,String Producto,String idFolio)
        {
            string formularioCliente = ConfigurationManager.AppSettings["formularioCliente"].ToString();
            string correoDestinoProvisorio = "";


            List<String> detalle = new List<String>();

            string[] folioOperacion = idFolio.Split('|');
            string folio = folioOperacion[0].ToString();
            string idOperacion = folioOperacion[1].ToString();
            
            detalle.Add(correoDestinoProvisorio); //destinatarios
            string formularioRespuestaURL1 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&1"));
            string formularioRespuestaURL2 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&2"));
            string formularioRespuestaURL3 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&3"));
            string formularioRespuestaURL4 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&4"));
            string formularioRespuestaURL5 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&5"));
            string formularioRespuestaURL6 = formularioCliente + "?co=" + HttpUtility.UrlEncode(Base64Encode(folio + "&" + idOperacion + "&6"));

            DateTime fechaActual = DateTime.Today;
            string rutaImagenCabecera = "";
            
            string imagenCabecera = "";

            if (fechaActual.Year == 2020)
            {
                if (fechaActual.Month == 1)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/ruG9vDZ.png'>";
                }else if (fechaActual.Month == 2)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/IVcUaTJ.png'>";
                }
                else if (fechaActual.Month == 3)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/YxVIebB.png'>";
                }
                else
                {
                    //Imagenes publicadas en aplicativo expuesto a internet
                    rutaImagenCabecera = "<img src='https://confirmacionoperacionescl.credicorpcapital.cl:8443/img/cabeceras/Forward/" + fechaActual.Year +"/" + fechaActual.Year + "-" + fechaActual.ToString("MM") + ".png" + "'>";
                }
            }
            else
            {
                //Imagenes publicadas en aplicativo expuesto a internet
                rutaImagenCabecera = "<img src='https://confirmacionoperacionescl.credicorpcapital.cl:8443/img/cabeceras/Forward/" + fechaActual.Year + "/" + fechaActual.Year + "-" + fechaActual.ToString("MM") + ".png" + "'>";
            }

            //string mesEnCurso = fechaActual.ToString("MMMM");
            string texto =  "<table width='1200'><tr><td>" +
                            //"<img src='https://i.imgur.com/bHfCV7z.jpg'>" +
                            imagenCabecera +
                            "</td></tr>" +
                            //"<tr><td><p align='right'>" + mesEnCurso + " " + fechaActual.Year + "<p></td></tr>" + 
                            "<tr><td>" +
                            "En señal de conformidad a las condiciones en el adjunto señaladas correspondientes al cierre de operación vía telefónica, agradecemos " +
                            "presionar el <b>botón confirmar</b> incluidos en el cuerpo del correo o enviar copia firmada de esta confirmación a la siguiente casilla " +
                            "electrónica: operacionesfinancieraschile@credicorpcapital.com <br /><br />" +
                            "<br />" +
                            "<br />" +
                            "</td></tr>"+
                            "<tr><td>" +
                           "<!DOCTYPE html>" +
                           "<html> " +
                           "<head>" +
                           "<meta charset='utf-8'/>" +
                           "</head>" +
                           "<body>" +
                           "<center>"+
                            "<h3><p style=\"text-align:center\">Confirmaci&oacute;n de operaci&oacute;n <strong>"+ folio +"</strong></p></h3>" +
                            "<br>"+
                            "<br>"+
                            "<table border=\"0\">" +
                                "<tbody>" +
                                    "<tr>" +
                                        "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL1+"\"><img src=\"https://i.imgur.com/ja2bAbR.png\"></a></td>" +
			                            "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL2+"\"><img src=\"https://i.imgur.com/dfxJFH0.png\"></a></td>"+
		                            "</tr>"+
                                    "<tr>" +
                                        "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL3+"\"><img src=\"https://i.imgur.com/2cRqxHn.png\"></a></td>" +
			                            "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL4+"\"><img src=\"https://i.imgur.com/F20AARe.png\"></a></td>"+
		                            "</tr>"+
                                    "<tr>" +
                                        "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL5+"\"><img src=\"https://i.imgur.com/z9EJkWh.png\"></a></td>" +
                                        "<td style=\"text-align:center\"><a href=\""+formularioRespuestaURL6+"\"><img src=\"https://i.imgur.com/KENfAC1.png\"></a></td>" +
		                            "</tr>"+
                                "</tbody>" +
                            "</table>" +
                           "</center>" +
                           "<br> " +
                           "</td></tr>" +
                           "<tr><td>" +
                           "<br>" +
                           "En caso de disconformidad agradecemos marcar una de las opciones en la sección <b>Rechazos</b>, si estas no se ajustan, favor marcar " +
                            "opción otros y será contactado por nuestra área de operaciones financieras." +
                           "<br /> <br /><br />" +
                           "<img src='https://i.imgur.com/BjFOkpH.jpg'/>" +
                           "</body>" +
                           "</td></tr>" +
                           "</html>";
            detalle.Add(texto);
            return detalle;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string ObtenerNombreProducto(String idProducto)
        {
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);
            String nombreProducto = "";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            dt = conect.EjecutarSP_Parametros("SP_CO_OBTENER_NOMBRE_PRODUCTO", parameters);

            foreach (DataRow row in dt.Rows)
            {
                nombreProducto = row["nombre"].ToString();
            }
            return nombreProducto;
        }

        public DataTable consultarOperacionesPorFolio(String idProducto, String NOperacion)
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@NOperacion", NOperacion);
            dt = conect.EjecutarSP_Parametros("SP_CO_CONSULTAR_OPERACIONES_POR_FOLIO", parameters);
            return dt;

        }
        
        public DataTable consultarOperacionesPorFolioContratos(String idProducto, String NOperacion)
        {
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@Folio", NOperacion);
            dt = conect.EjecutarSP_Parametros("SP_CO_FWD_OBTENER_OP_POR_FOLIO_CONTRATOS", parameters);
            return dt;

        }
        
        public DataTable consultarOperacionesPorFolioSIM(String FOLIO_TRANS, String RUT_CLI, String FEC_TRANS)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime f = Convert.ToDateTime(FEC_TRANS);
            int yyyy = f.Year;
            int dd = f.Day;
            string mm = f.ToString("MM");
            string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);
           // string fechamm = FEC_TRANS.Substring(3, 2).ToString();
            //string fechayy = FEC_TRANS.Substring(6, 4).ToString();
            string COD_PER = yyyy+"-"+mm.ToString();

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = conect.agregaParametros("@FOLIO_TRANS", FOLIO_TRANS);
            parameters[1] = conect.agregaParametros("@RUT_CLI", RUT_CLI);
            parameters[2] = conect.agregaParametros("@FEC_TRANS", FEC_TRANS);
            parameters[3] = conect.agregaParametros("@COD_PER", COD_PER);
            dt = conect.EjecutarSP_Parametros("SP_CO_SIM_CONSULTAR_OPERACIONES_POR_FOLIO", parameters);
            return dt;

        }


        public bool EliminaOperacionPorReenvio(String idProducto, String idFolio)
        {
            try
            {
                String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
                Conexion conect = new Conexion(conexion_string);

                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = conect.agregaParametros("@idProducto", idProducto);
                parameters[1] = conect.agregaParametros("@NOperacion", idFolio);
                conect.EjecutarSP_Parametros("SP_CO_ELIMINA_OPERACION_PARA_REENVIAR", parameters);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public String crearOperacionConfirmacionBlotter(String idProducto
                                                     ,String fechaInicio
                                                     ,String Folio
                                                     ,String fechaVencimiento
                                                     ,String rut
                                                     ,String secuencia
                                                     ,String nombreCliente
                                                     ,String tipoMovimiento
                                                     ,String monedaPrincipal
                                                     ,String montoPrincipal
                                                     ,String monedaSecundario
                                                     ,String tcCierreForward
                                                     ,String montoSecundario
                                                     ,String cumplimiento
                                                     ,String agente
                                                     ,String montoLiquidacion
                                                     ,String margen
                                                     ,String cartera
                                                     ,String vehiculo
                                                     ,String folioAsociado
                                                     ,String comentario
                                                     ,String fixingDate
                                                     ,String fechaAnticipo
                                                     ,String tasaAnticipo
                                                     ,String recibimosPagamos
                                                     ,String monedaAnticipo
                                                     )
        {
            string salidId="";
            Forward frw = new Forward();
            DataTable dt = new DataTable();

            dt = frw.CrearOperacionBlotter(idProducto
                                                     , fechaInicio
                                                     , Folio
                                                     , fechaVencimiento
                                                     , rut
                                                     , secuencia
                                                     , nombreCliente
                                                     , tipoMovimiento
                                                     , monedaPrincipal
                                                     , montoPrincipal
                                                     , monedaSecundario
                                                     , tcCierreForward
                                                     , montoSecundario
                                                     , cumplimiento
                                                     , agente
                                                     , montoLiquidacion
                                                     , margen
                                                     , cartera
                                                     , vehiculo
                                                     , folioAsociado
                                                     , comentario
                                                     , fixingDate
                                                     , fechaAnticipo
                                                     , tasaAnticipo
                                                     , recibimosPagamos
                                                     , monedaAnticipo
                                                     );
            
            foreach (DataRow row in dt.Rows)
            {
                salidId = row[0].ToString();
            }

            return salidId;
        }



        public void EnviarCorreoAvisoVencimiento(String idProducto, String folio, String tabla,String fecha, String nombre, String rut)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            string producto = ObtenerNombreProducto(idProducto); //se debe crear metodo que devuelve nombre de producto;

            List<String> detalle = ObtenerDetalleCorreoAvisoVencimiento(idProducto,nombre,rut,folio, fecha);
            string direccion = detalle[0].ToString();
            string body = detalle[1].ToString() + tabla;

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();


            //Direccion de correo electronico a la que queremos enviar el mensaje
            //mmsg.To.Add(direccion);

            Correo co = new Correo();
            DataTable destinatario = co.ObtenerCorreoCliente(idProducto, rut);

            string switchcorreo = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (switchcorreo == "false")
            {
                foreach (DataRow row in destinatario.Rows)
            {
                mmsg.To.Add(row[0].ToString());
            }
            }
            else
            {
                mmsg.To.Add("francisco.bravo@siigroup.cl");
                //mmsg.To.Add("rodrigo.bahamondes@siigroup.cl");
                //mmsg.To.Add("cesar.uribe@siigroup.cl");
            }

            //Asunto
            //mmsg.Subject = "Vencimiento Forward al día " + fecha;
            mmsg.Subject = "Vencimiento Forward " + nombre + " al día " + fecha;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //string correocopia = ConfigurationManager.AppSettings["correoCC"].ToString();
            //mmsg.Bcc.Add(correocopia); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje

            string correorem = ConfigurationManager.AppSettings["correoRemitente"].ToString();
            string clavecorreorem = ConfigurationManager.AppSettings["clavecorreoRemitente"].ToString();
            mmsg.From = new System.Net.Mail.MailAddress(correorem);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.UseDefaultCredentials = false;
            cliente.Credentials =
                new System.Net.NetworkCredential(correorem, clavecorreorem);

            //Lo siguiente es obligatorio si enviamos el mensaje
            //Se revisa si esta local o produccion
            string ambiente = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (ambiente == "true")
            {
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "SMTP.Office365.com";
            }
            else
            {
                cliente.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoMail"]);
                cliente.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSLMail"]);
                cliente.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
            }


            //Archivos adjuntos.

            //string[] foliosList = folio.Split(',');
            //foreach (string folioaux in foliosList)
            //{
            //    string filename = adjunto + folioaux + ".pdf";
            //    Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
            //    mmsg.Attachments.Add(data);
            //}

            /*-------------------------ENVIO DE CORREO----------------------*/


            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                String error = ex.ToString();
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }


        public List<String> ObtenerDetalleCorreoAvisoVencimiento(String idProducto, String Nombre,String rut, String idFolio, String fecha)
        {
            List<String> detalle = new List<String>();
            string correoDestinoProvisorio = "";


            detalle.Add(correoDestinoProvisorio); //destinatarios
            string mensaje = "<img src='https://i.imgur.com/D602qAD.jpg'> <br/><br/><br/>" +
                 "<center><table><tr><td>AVISO VENCIMIENTO FORWARDS<br/>Nombre: " + Nombre + "<br/>Rut:" + rut + " <br/>Estimado Cliente, a continuación enviamos detalle de operación(es) FORWARD a vencer el " + fecha + ".<br/><br/>";
            detalle.Add(mensaje);
            return detalle;
        }

        public DataTable ObtenerValores(String fecha)
        {
            DataTable dt = new DataTable();
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();            
            Conexion conect = new Conexion(conexion_string);            

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@fecha", fecha);
            dt = conect.EjecutarSP_Parametros("SP_CO_OBTENER_VALORES", parameters);

            return dt;

        }

        public void EnviarCorreoContrato(String idProducto, String folio, String adjunto, String nombreEmpresa, String idCliente, String rutagenerada)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            string producto = ObtenerNombreProducto(idProducto); //se debe crear metodo que devuelve nombre de producto;

            List<String> detalle = ObtenerDetalleCorreoContrato(idProducto, producto, folio);
            string direccion = detalle[0].ToString();
            string body = detalle[1].ToString();

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            Correo co = new Correo();
            DataTable destinatario = co.ObtenerCorreoCliente(idProducto, idCliente);
            string switchcorreo = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (switchcorreo == "false")
            {
                foreach (DataRow row in destinatario.Rows)
                {
                    mmsg.To.Add(row[0].ToString());
                }
            }
            else
            {
                mmsg.To.Add("francisco.bravo@siigroup.cl");
                //mmsg.To.Add("rodrigo.bahamondes@siigroup.cl");
                //mmsg.To.Add("cesar.uribe@siigroup.cl");
            }

            string[] folioOperacion = folio.Split('|');
            string folioAux = folioOperacion[0].ToString();
            string idOperacion = folioOperacion[1].ToString();


            //Asunto
            mmsg.Subject = "Contrato de " + producto + " " + nombreEmpresa + " Folio Op:" + folioAux;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //string correocopia = ConfigurationManager.AppSettings["correoCC"].ToString();
            //mmsg.Bcc.Add(correocopia); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje

            string correorem = ConfigurationManager.AppSettings["correoRemitente"].ToString();
            string clavecorreorem = ConfigurationManager.AppSettings["clavecorreoRemitente"].ToString();
            mmsg.From = new System.Net.Mail.MailAddress(correorem);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.UseDefaultCredentials = false;
            cliente.Credentials =
                new System.Net.NetworkCredential(correorem, clavecorreorem);

            //Lo siguiente es obligatorio si enviamos el mensaje
            //Se revisa si esta local o produccion
            string ambiente = ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString();
            if (ambiente == "true")
            {
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "SMTP.Office365.com";
            }
            else
            {
                cliente.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoMail"]);
                cliente.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SSLMail"]);
                cliente.Host = ConfigurationManager.AppSettings["MailHost"].ToString();
            }


            //Archivos adjuntos.



            string[] foliosList = folioAux.Split(',');
            foreach (string folioaux1 in foliosList)
            {
                string filename = rutagenerada + folioaux1 + ".pdf";
                Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
                mmsg.Attachments.Add(data);
            }

            /*-------------------------ENVIO DE CORREO----------------------*/


            try
            {
                //Enviamos el mensaje
            cliente.Send(mmsg);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                String error = ex.ToString();
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

        public List<String> ObtenerDetalleCorreoContrato(String idProducto, String Producto, String idFolio)
        {
            //string formularioCliente = ConfigurationManager.AppSettings["formularioCliente"].ToString();
            string correoDestinoProvisorio = "";

            List<String> detalle = new List<String>();

            string[] folioOperacion = idFolio.Split('|');
            string folio = folioOperacion[0].ToString();
            string idOperacion = folioOperacion[1].ToString();

            DateTime fechaActual = DateTime.Today;
            string rutaImagenCabecera = "";

            string imagenCabecera = "";

            if (fechaActual.Year == 2020)
            {
                if (fechaActual.Month == 1)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/ruG9vDZ.png'>";
                }
                else if (fechaActual.Month == 2)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/IVcUaTJ.png'>";
                }
                else if (fechaActual.Month == 3)
                {
                    imagenCabecera = "<img src='https://i.imgur.com/YxVIebB.png'>";
                }
                else
                {
                    //Imagenes publicadas en aplicativo expuesto a internet
                    rutaImagenCabecera = "<img src='https://confirmacionoperacionescl.credicorpcapital.cl:8443/img/cabeceras/Forward/" + fechaActual.Year + "/" + fechaActual.Year + "-" + fechaActual.ToString("MM") + ".png" + "'>";
                }
            }
            else
            {
                //Imagenes publicadas en aplicativo expuesto a internet
                rutaImagenCabecera = "<img src='https://confirmacionoperacionescl.credicorpcapital.cl:8443/img/cabeceras/Forward/" + fechaActual.Year + "/" + fechaActual.Year + "-" + fechaActual.ToString("MM") + ".png" + "'>";
            }

            string texto = "<!DOCTYPE html>"+
                          "<html lang='es'>"+
                            "<head>"+
                              "<meta charset='UTF-8'> "+
                            "</head>"+
                            "<body>"+
                              "<h3>Envío de contrato forward</h3>"+
                            "</body>"+
                            "</html>"+
                            "<table width='1200'><tr><td>" +                            
                            imagenCabecera +
                            "</td></tr>" +
                            "<tr><td>" +
                            "El objeto de este contrato es, para cada una de las partes contratantes, precaverse de las fluctuaciones que presentan, considerando un valor" +
                            "respecto del otro, los valores del tipo de cambio del contrato y el Dólar Control de Precio, mediante el compromiso que asumen en este acto de" +
                            "hacerse pagos recíprocos. <br /> <br />" +
                            "<br />" +
                            "<br />" +
                            "</td></tr>" +
                            "<tr><td>" +
                           "<!DOCTYPE html>" +
                           "<html> " +
                           "<head>" +
                           "<meta charset='utf-8'/>" +
                           "</head>" +
                           "<body>" +
                           "<br> " +
                           "</td></tr>" +
                           "<tr><td>" +
                           "<br>" +
                           "En caso de disconformidad agradecemos responder el correo." +
                           "<br /> <br /><br />" +
                           "<img src='https://i.imgur.com/BjFOkpH.jpg'/>" +
                           "</body>" +
                           "</td></tr>" +
                           "</html>";
            detalle.Add(correoDestinoProvisorio);
            detalle.Add(texto);
            return detalle;
        }

        public DataTable editarEstados(string id, string folio, string estado, int producto)
        {
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            if(producto == 1)
            {
                //Contratos forward
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = conect.agregaParametros("@ID", id);
                parameters[1] = conect.agregaParametros("@FOLIO", folio);
                parameters[2] = conect.agregaParametros("@ESTADO", estado);
                dt = conect.EjecutarSP_Parametros("SP_CO_FWD_CAMBIAR_ESTADO_CONTRATOS", parameters);
                
            }else if (producto == 2)
            {
                //simultaneas
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = conect.agregaParametros("@ID", id);
                parameters[1] = conect.agregaParametros("@FOLIO", folio);
                parameters[2] = conect.agregaParametros("@ESTADO", estado);
                dt = conect.EjecutarSP_Parametros("SP_CO_SIM_CAMBIAR_ESTADO_CONTRATOS", parameters);
            }
            else
            {
               //refrescar
            }

            return dt;

        }

    }


}
