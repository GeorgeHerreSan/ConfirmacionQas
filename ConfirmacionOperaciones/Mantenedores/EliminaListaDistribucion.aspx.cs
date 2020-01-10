using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_EliminaListaDistribucion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Rut = Request.Form["Rut"].ToString();
        string Producto = Request.Form["Producto"].ToString();
        string Secuencia = Request.Form["Secuancia"].ToString();

        eliminarLista(Rut, Producto, Secuencia);

        Response.Clear();
        Response.Write("OK");
        //Response.End();
    }

    public string eliminarLista(string Rut, string Producto, string Secuencia)
    {
        Correo objCorreo = new Correo();
        string resulta2 = "";
        resulta2 = objCorreo.EliminarListaDistribucion(Rut, Producto, Secuencia);
        return resulta2;
    }
}