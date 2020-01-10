using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forward_EditarEstadoContrato : System.Web.UI.Page
{
    string id;
    string folio;
    string estado;

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
        int producto = 1;
        Confirmacion objConfirmacion = new Confirmacion();
        objConfirmacion.editarEstados(id, folio, estado, producto);

        return true;
    }
}