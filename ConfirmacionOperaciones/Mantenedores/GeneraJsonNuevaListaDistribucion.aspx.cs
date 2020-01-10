using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_GeneraJsonNuevaListaDistribucion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Rut = Request.Form["Rut"].ToString();
        string Lista = Request.Form["Lista"].ToString();
        string Secuencia = Request.Form["Secuencia"].ToString();
        //string Secuencia = Request.Form["Secuancia"].ToString();

        //string resulta2s = generaLista(Rut, Lista, Secuencia);

        string resultado = CrearJson(Rut, Lista);
        Response.Clear();
        Response.Write(resultado);
    }


    public string CrearJson(string Rut, string Lista)
    {
        string contenido = "";
        Correo contJson = new Correo();
        Correo contRecor = new Correo();
        List<Correo> listaCorreo = new List<Correo>();
        listaCorreo = contJson.generaNuevaListaDistribucion(Rut, Lista);

        contenido = "[";
        for (int cont = 0; cont < listaCorreo.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaCorreo[cont];
            string origen = contRecor.Origen.ToString();
            if (origen == "0" || origen == "")
            {
                origen = "Sistema";
            }
            else
            {
                origen = "Interno";
            }
            contenido += "{\"id\": \"" + index +
                "\",\"Idlist\": \"" + contRecor.Id.ToString() +
                "\",\"Idcli\" : \"" + contRecor.Id_cliente.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                //"\",\"Origen\" : \"" + contRecor.Origen.ToString() + " \" },";
                "\",\"Origen\" : \"" + origen + " \" },";
        }

        if (listaCorreo.Count > 0)
        {
            int index = listaCorreo.Count;
            contRecor = listaCorreo[listaCorreo.Count - 1];
            string origen = contRecor.Origen.ToString();
            if (origen == "0" || origen == "")
            {
                origen = "Sistema";
            }
            else
            {
                origen = "Interno";
            }
            contenido += "{\"id\": \"" + index +
                "\",\"Idlist\": \"" + contRecor.Id.ToString() +
                "\",\"Idcli\" : \"" + contRecor.Id_cliente.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                //"\",\"Origen\" : \"" + contRecor.Origen.ToString() + " \" }";
                "\",\"Origen\" : \"" + origen + " \" }";
            contenido += "]";
        }
        else
        {
            contenido += "]";
        }

        return contenido;

    }

    public string reemplazarSeparadorMiles(String numero)
    {
        numero = numero.Replace(".", "_");
        numero = numero.Replace(",", ".");
        numero = numero.Replace("_", ",");
        return numero;

    }

}