﻿using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_GuardarListaDeDistribucion : System.Web.UI.Page
{
    string Idcli;
    string Email;
    string Alias;
    string Origen;
    string Secuencia;
    string Producto;

    protected void Page_Load(object sender, EventArgs e)
    {
        Idcli = Request.Form["ListaDistribucion"].ToString();
        Secuencia = Request.Form["Secuencia"].ToString();
        Producto = Request.Form["Producto"].ToString();

        crearIdentificadoresLista(Idcli, Secuencia, Producto);

        Response.Clear();
        Response.Write("OK");
        //Response.End();
    }

    public string crearIdentificadoresLista(string info, string Secuencia, string Producto)
    {
        //string[] info = operaciones.Split(',');
        Correo objCorreo = new Correo();
        string resulta2 = "";
        string[] infoLista = info.Split(',');

        foreach (string operacionLt in infoLista)
        {
            string[] detalleOperacionList = operacionLt.Split('|');
            string Idlist = detalleOperacionList[0].ToString();
            string IdCliente = detalleOperacionList[1].ToString();
            string Email = detalleOperacionList[2].ToString();
            string Alias = detalleOperacionList[3].ToString();
            string Origen = detalleOperacionList[4].ToString();
            string Apoderado = detalleOperacionList[5].ToString();
            if(Apoderado == "true" || Apoderado == "TRUE")
            {
                Apoderado = "1";
            }
            else
            {
                Apoderado = "0";
            }

            resulta2 = objCorreo.insertarNuevaListaDeDistribucion(Idlist, IdCliente, Email, Alias, Origen, Secuencia, Apoderado, Producto);
        }


        return resulta2;
    }
}