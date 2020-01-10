using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_EliminarCorreo : System.Web.UI.Page
{
    string id;
    string rut;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.Form["Id"].ToString();
        rut = Request.Form["Rut"].ToString();

        string resultado = eliminarCorreo(id, rut);

        Response.Clear();
        Response.Write(resultado);
        //Response.End();
    }

    public string eliminarCorreo(string id, string Rut)
    {
        Correo objCorreo = new Correo();
        string resulta2;
        objCorreo.EliminarCorreo(id);

        resulta2 = CrearJson(Rut);
        return resulta2;
    }

    public string CrearJson(string correo)
    {
        string contenido = "";
        Correo contJson = new Correo();
        Correo contRecor = new Correo();
        List<Correo> listaCorreo = new List<Correo>();
        listaCorreo = contJson.ObtenerListaCorreos(correo);


        contenido = "[";
        //for (int cont = 0; cont < (listaForward.Count - 1); cont++)
        for (int cont = 0; cont < listaCorreo.Count - 1; cont++)
        {
            int index = cont + 1;
            contRecor = listaCorreo[cont];
            //contenido += "{\"id\": \"" + index + "\", \"Origen\" : \"" + contRecor.Origen.ToString() + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + contRecor.MtoMonPrinc.ToString() + "\", \"tc_cierre\" : \"" + contRecor.TcCierre.ToString() + "\", \"MtoMonSecu\" : \"" + contRecor.MtoMonSecu.ToString() + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipo_mov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"margen\" : \"" + contRecor.Margen.ToString() + "\", \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuario_creador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigo_moneda\" : \"" + contRecor.CodMoneda1.ToString() + "\" , \"tcTransf\" : \"" + contRecor.TcTransf.ToString() + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" },";
            string validaestado = contRecor.Estado.ToString();
            string nombreEstado = "";
            if (validaestado == "1")
            {
                nombreEstado = "Activo";
            }
            else
            {
                nombreEstado = "Inactivo";
            }
            contenido += "{\"id\": \"" + index +
                "\",\"Idinte\": \"" + contRecor.Id.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                //"\",\"Estado\" : \"" + contRecor.Estado.ToString() +
                "\",\"Estado\" : \"" + nombreEstado +
                "\",\"Origen\" : \"" + contRecor.Origen.ToString() + //"' />\" },";
                "\",\"Editar\" : \"<input type='button' class='" + contRecor.Id_cliente.ToString() + "' value='Editar' id='" + contRecor.Id.ToString() + "' onclick='editarCorreo(id = $(this).attr(`id`), clas = $(this).attr(`class`))'>" +
                "\",\"Eliminar\" : \"<input type='button' class='" + contRecor.Id_cliente.ToString() + "' value='Anular' id='" + contRecor.Id.ToString() + "' onclick='eliminarCorreo(id = $(this).attr(`id`), clas = $(this).attr(`class`))' />\" },";
        }

        if (listaCorreo.Count > 0)
        {
            int index = listaCorreo.Count;
            contRecor = listaCorreo[listaCorreo.Count - 1];
            //contenido += "{\"id\": \"" + index + "\",\"Origen\" : \"" + contRecor.Origen.ToString() + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + contRecor.MtoMonPrinc.ToString() + "\", \"tc_cierre\" : \"" + contRecor.TcCierre.ToString() + "\", \"MtoMonSecu\" : \"" + contRecor.MtoMonSecu.ToString() + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\", \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipo_mov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"margen\" : \"" + contRecor.Margen.ToString() + "\", \"ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\", \"clasificacion\" : \"" + contRecor.Clasificacion.ToString() + "\", \"usuario_creador\" : \"" + contRecor.UsuarioCreador.ToString() + "\", \"codigo_moneda\" : \"" + contRecor.CodMoneda1.ToString() + "\" , \"tcTransf\" : \"" + contRecor.TcTransf.ToString() + "\" , \"CodSecEco\" : \"" + contRecor.CodSecEco.ToString() + "\" } ";
            //contenido += "{\"id\": \"" + index + "\",\"folio\": \"" + contRecor.Folio.ToString() + "\",\"rut\" :\"" + contRecor.Rut.ToString() + "\",\"secuencia\" :\"" + contRecor.Secuencia.ToString() + "\", \"razon_social\" : \"" + contRecor.RazonSocial.ToString() + "\", \"fecha_inicio\" : \"" + contRecor.FechaInicio.ToString() + "\", \"fecha_vencimiento\" : \"" + contRecor.FechaVencimiento.ToString() + "\", \"mont_mon_princ\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonPrinc.ToString()) + "\", \"tc_cierre\" : \"" + reemplazarSeparadorMiles(contRecor.TcCierre.ToString()) + "\", \"MtoMonSecu\" : \"" + reemplazarSeparadorMiles(contRecor.MtoMonSecu.ToString()) + "\" , \"modalidad\" : \"" + contRecor.Modalidad.ToString() + "\" , \"dias\" : \"" + contRecor.Dias.ToString() + "\", \"tipoMov\" : \"" + contRecor.TipoMov.ToString() + "\" , \"CodMonPrinc\" : \"" + contRecor.Cod_Mon_Princ.ToString() + "\", \"CodMonSecu\" : \"" + contRecor.Cod_Mon_Secu.ToString() + "\", \"Ejecutivo\" : \"" + contRecor.Ejecutivo.ToString() + "\" }";
            string validaestado = contRecor.Estado.ToString();
            string nombreEstado = "";
            if (validaestado == "1")
            {
                nombreEstado = "Activo";
            }
            else
            {
                nombreEstado = "Inactivo";
            }
            contenido += "{\"id\" : \"" + index +
                "\",\"Idinte\" : \"" + contRecor.Id.ToString() +
                "\",\"Email\" : \"" + contRecor.Email.ToString() +
                "\",\"Alias\" : \"" + contRecor.Alias.ToString() +
                //"\",\"Estado\" : \"" + contRecor.Estado.ToString() +
                "\",\"Estado\" : \"" + nombreEstado +
                "\",\"Origen\" : \"" + contRecor.Origen.ToString() + //"' />\" }";
                "\",\"Editar\" : \"<input type='button' class='" + contRecor.Id_cliente.ToString() + "' value='Editar' id='" + contRecor.Id.ToString() + "' onclick='editarCorreo(id = $(this).attr(`id`), clas = $(this).attr(`class`))'>" +
                "\",\"Eliminar\" : \"<input type='button' class='" + contRecor.Id_cliente.ToString() + "' value='Anular' id='" + contRecor.Id.ToString() + "' onclick='eliminarCorreo(id = $(this).attr(`id`), clas = $(this).attr(`class`))' />\" }";
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