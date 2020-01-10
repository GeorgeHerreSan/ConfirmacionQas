using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_AgregarCorreo : System.Web.UI.Page
{
    string Email;
    string Alias;
    string Rut;
    protected void Page_Load(object sender, EventArgs e)
    {
        Email = Request.Form["Email"].ToString();
        Alias = Request.Form["Alias"].ToString();
        Rut = Request.Form["Rut"].ToString();

        string resultado = insertarCorreo(Email, Alias, Rut);
        string respuesta = "";
        if (resultado == "0")
        {
            respuesta = "seencontroregistro";
        }
        Response.Clear();
        Response.Write(respuesta);
    }

    public string insertarCorreo(string Email, string Alias, string Rut)
    {
        Correo objCorreo = new Correo();
        string resulta2;
        resulta2 = objCorreo.nuevoCorreo(Email, Alias, Rut);

        //resulta2 = CrearJson(Rut);
        return resulta2;
    }
}