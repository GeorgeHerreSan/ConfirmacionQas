using AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_ObtenerDatosCorreo : System.Web.UI.Page
{
    string IdCorreo;
    string Rut;
    protected void Page_Load(object sender, EventArgs e)
    {
        IdCorreo = Request.Form["idCorreo"].ToString();
        Rut = Request.Form["idCliente"].ToString();

        string resultado = obtenerCorreo(IdCorreo, Rut);
        Response.Clear();
        Response.Write(resultado);
    }

    public string obtenerCorreo(string IdCorreo, string Rut)
    {
        string contenido = "";
        Correo contJson = new Correo();
        Correo contRecor = new Correo();
        List<Correo> listaCorreo = new List<Correo>();
        listaCorreo = contJson.ObetenerDataCorreo(IdCorreo, Rut);

        contenido = "{\"info\":[";

        if (listaCorreo.Count > 0)
        {
            int index = listaCorreo.Count;
            contRecor = listaCorreo[listaCorreo.Count - 1];
            contenido += "{\"id\": \"" + index +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                "\",\"Estado\" : \"" + contRecor.Estado.ToString() + " \" }";
            contenido += "]}|";
        }
        else
        {
            contenido += "]}|";
        }

        return contenido;

    }
}