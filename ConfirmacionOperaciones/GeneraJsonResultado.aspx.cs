using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCode;

public partial class GeneraJsonResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string producto = Request.Form["producto"].ToString();
        string fecha = Request.Form["fecha"].ToString();
        string cliente = Request.Form["cliente"].ToString();
        string nOperacion = Request.Form["noperacion"].ToString();
        string resultado = CrearJson(producto, fecha, cliente, nOperacion);
        Response.Clear();
        Response.Write(resultado);
    }

    public string CrearJson(string producto,string fecha, string cliente,string nOperacion)
    {
        string contenido = "";
        Contratos contJson = new Contratos();
        Contratos contRecor = new Contratos();
        List<Contratos> listaContratos = new List<Contratos>();
        listaContratos = contJson.ObtenerContratos(producto, fecha, cliente, nOperacion);


        contenido = "[";
        for (int cont = 0; cont < listaContratos.Count - 1; cont++)
        {
            contRecor = listaContratos[cont];
            contenido += "{\"numero_operacion\": \"" + contRecor.NumeroOperacion.ToString() + "\",\"rut_cliente\" :\"" + contRecor.RutCliente.ToString() + "\",\"nombre_cliente\" :\"" + contRecor.NombreCliente.ToString() + "\", \"fecha_operacion\" : \"" + contRecor.FechaOperacion.ToString() + "\", \"monto\" : \"" + contRecor.Monto.ToString() + "\", \"fecha_firma\" : \"" + contRecor.FechaFirma.ToString() + "\", \"dias_pendientes\" : \"" + contRecor.NumeroDiasPendientes.ToString() + "\", \"estado_contrato\" : \"" + contRecor.Estado.ToString() + "\" },";
        }


        if (listaContratos.Count > 0)
        {
            contRecor = listaContratos[listaContratos.Count - 1];
            contenido += "{\"numero_operacion\": \"" + contRecor.NumeroOperacion.ToString() + "\",\"rut_cliente\" :\"" + contRecor.RutCliente.ToString() + "\",\"nombre_cliente\" :\"" + contRecor.NombreCliente.ToString() + "\", \"fecha_operacion\" : \"" + contRecor.FechaOperacion.ToString() + "\", \"monto\" : \"" + contRecor.Monto.ToString() + "\", \"fecha_firma\" : \"" + contRecor.FechaFirma.ToString() + "\", \"dias_pendientes\" : \"" + contRecor.NumeroDiasPendientes.ToString() + "\", \"estado_contrato\" : \"" + contRecor.Estado.ToString() + "\" }";
            contenido += "]";
        }
        else
        {
            contenido += "]";
        }
        return contenido;

    }



}