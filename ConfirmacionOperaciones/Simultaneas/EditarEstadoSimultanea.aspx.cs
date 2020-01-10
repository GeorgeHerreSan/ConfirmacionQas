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


public partial class EditarEstadoSimultanea : System.Web.UI.Page //Forward_EnviarConfirmacion
{
    string id;
    string folio;
    string estado;
   // string folioReenvio;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.Form["id"].ToString();
            folio = Request.Form["folio"].ToString();
            estado = Request.Form["estado"].ToString();

            bool resultado = editarEstado(id, folio, estado);

            Response.Clear();
            Response.Write(resultado);
        }

        public bool editarEstado(string id, string folio, string estado)
        {
            int producto = 2;
            Confirmacion objConfirmacion = new Confirmacion();
            objConfirmacion.editarEstados(id, folio, estado, producto);

            return true;
        }
    
}