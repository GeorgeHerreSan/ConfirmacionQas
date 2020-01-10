using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_GeneraJsonListaDistribucion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Rut = Request.Form["Rut"].ToString();
        string Lista = Request.Form["Lista"].ToString();
        string Secuencia = Request.Form["Secuancia"].ToString();

        //string resulta2s = generaLista(Rut, Lista, Secuencia);

        string resultado = CrearJson(Rut, Lista, Secuencia);
        Response.Clear();
        Response.Write(resultado);
    }


    public string CrearJson(string Rut, string Lista, string Secuencia)
    {
        string contenido = "";
        Correo contJson = new Correo();
        Correo contRecor = new Correo();
        List<Correo> listaCorreo = new List<Correo>();
        listaCorreo = contJson.generaListaDistribucion(Rut, Lista, Secuencia);

        contenido = "[";
        for (int cont = 0; cont < listaCorreo.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaCorreo[cont];
            string detecsecuencia = contRecor.Secuencia.ToString();
            if (detecsecuencia == "-1")
            {
                detecsecuencia = "General";
            }
            string incluido = "";
            if (detecsecuencia == "" || detecsecuencia == "null" || detecsecuencia == "NULL")
            {
                incluido = "false";
            }
            else
            {
                incluido = "true";
            }
            contenido += "{\"id\": \"" + index +
                "\",\"Idlist\": \"" + contRecor.Id.ToString() +
                "\",\"Idcli\" : \"" + contRecor.Id_cliente.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                "\",\"Apoderado\" : \"" + contRecor.Apoderado.ToString() +
                "\",\"Estado\" : \"" + contRecor.Estado.ToString() +
                //"\",\"Secuencia\" : \"" + detecsecuencia +
                "\",\"Incluido\" : \"" + incluido + "\" },";
        }

        if (listaCorreo.Count > 0)
        {
            int index = listaCorreo.Count;
            contRecor = listaCorreo[listaCorreo.Count - 1];
            string detecsecuencia = contRecor.Secuencia.ToString();
            if (detecsecuencia == "-1")
            {
                detecsecuencia = "General";
            }
            string incluido = "";
            if (detecsecuencia == "" || detecsecuencia == "null" || detecsecuencia == "NULL")
            {
                incluido = "false";
            }
            else
            {
                incluido = "true";
            }
            contenido += "{\"id\": \"" + index +
                "\",\"Idlist\": \"" + contRecor.Id.ToString() +
                "\",\"Idcli\" : \"" + contRecor.Id_cliente.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                "\",\"Apoderado\" : \"" + contRecor.Apoderado.ToString() +
                "\",\"Estado\" : \"" + contRecor.Estado.ToString() +
                //"\",\"Secuencia\" : \"" + contRecor.Secuencia.ToString() + " \" }";
                //"\",\"Secuencia\" : \"" + detecsecuencia +// " \" }";
                "\",\"Incluido\" : \"" + incluido + " \" }";
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