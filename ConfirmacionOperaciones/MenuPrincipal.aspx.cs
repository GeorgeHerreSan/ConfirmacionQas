using NetSqlAzMan;
using NetSqlAzMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelDataReader;
using AppCode;
using System.Globalization;
using System.Threading;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool AmbienteDesarrollo = bool.Parse(ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString());

        if (AmbienteDesarrollo)
        {
            NombreUsuario.InnerText = this.Request.LogonUserIdentity.Name.ToString();
            //Alertas aun no implementadas.
            divAlertas.Visible = false;

            //confirmacion simulatenas aun  no implementada
            navSimultaneas.Visible = false;
        }
        else
        {
            NombreUsuario.InnerText = this.Request.LogonUserIdentity.Name.ToString();

            //Alertas aun no implementadas.
            divAlertas.Visible = false;

            //confirmacion simulatenas aun  no implementada
            navSimultaneas.Visible = false;

            string cs = ConfigurationManager.ConnectionStrings["NetSqlAzMan"].ConnectionString;
            IAzManStorage storage = new SqlAzManStorage(cs);
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

            string AppConfirmaOperaciones = ConfigurationManager.AppSettings["App_NetSqlAzMan_ConfirmacionOperaciones"].ToString();
            string Store = ConfigurationManager.AppSettings["Store_NetSqlAzMan"].ToString();

            //Valida acceso a confirmación de Operaciones.
            if (!storage.Stores[Store].GetApplication(AppConfirmaOperaciones).ApplicationGroups["Usuarios"].IsInGroup(this.Request.LogonUserIdentity))
            {
                Response.Redirect("PaginaError.aspx");
            }


        }

    }
    
    protected void  BtnCargarBlotter_Click(object sender, EventArgs e)
    {
        int valida = 0;
        try
        {
            if (FileUpload1.HasFile && datepickerBlotter.Value !="")
            {
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Archivos/" + fileName);
                    FileUpload1.SaveAs(filePath);
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet();
                            DataTable table = result.Tables[1]; /*hoja 1 es de forward*/
                            int i = 0;
                            int indexaux = 1;
                            string contenido = "";
                            string cabecera = "";
                            contenido = "[";
                            foreach (DataRow row in table.Rows)
                            {
                                int index = i;
                                if (index == 0)
                                {
                                    for (int a = 0; a < table.Columns.Count; a++)
                                    {
                                        if (row[a].ToString() != "")
                                        {
                                            cabecera += row[a].ToString() + "|";
                                        }
                                    }


                                    string cabeceraBlotter = ConfigurationManager.AppSettings["CabeceraBlotter"].ToString();
                                    if (cabecera != cabeceraBlotter)
                                    {
                                        LblMensajeBlotter.Text = "Cabecera de archivo incorrecta.";
                                        i = -1;
                                        break;
                                    }
                                }
                                if (index > 0)
                                {
                                    DateTime fechauxformato = Convert.ToDateTime(row[0].ToString().Substring(0, 10).ToString());
                                    DateTime TheDate = fechauxformato;
                                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                                    string fechaenarchivo = String.Format("{0:dd-MM-yyyy}",TheDate);


                                    //if (row[0].ToString().Substring(0, 10) == datepickerBlotter.Value  && row[17].ToString() == "Holding")
                                    if (fechaenarchivo == datepickerBlotter.Value  && row[17].ToString() == "Holding")
                                    {
                                        contenido += "{\"id\": \"" + indexaux + "\",\"fechaInicio\": \"" + row[0].ToString().Substring(0,10) + "\",\"folioOperacion\" :\"" + row[1].ToString() + "\",\"fechaVencimiento\" :\"" + row[2].ToString().Substring(0,10) + "\", \"rut\" : \"" + row[3].ToString() + "\", \"secuencia\" : \"" + row[4].ToString() + "\", \"nombreCliente\" : \"" + row[5].ToString() + "\", \"tipoMovimiento\" : \"" + row[6].ToString() + "\", \"monedaPrincipal\" : \"" + row[7].ToString() + "\", \"montoPrincipal\" : \"" + reemplazarSeparadorMiles(row[8].ToString()) + "\" , \"monedaSecundario\" : \"" + row[9].ToString() + "\" , \"tcCierreForward\" : \"" + reemplazarSeparadorMiles(row[10].ToString()) + "\", \"montoSecundario\" : \"" + reemplazarSeparadorMiles(row[11].ToString()) + "\" , \"cumplimiento\" : \"" + row[12].ToString() + "\", \"agente\" : \"" + row[13].ToString() + "\", \"montoLiquidacion\" : \"" + reemplazarSeparadorMiles(row[14].ToString()) + "\", \"margen\" : \"" + reemplazarSeparadorMiles(row[15].ToString()) + "\", \"cartera\" : \"" + row[16].ToString() + "\" , \"vehiculo\" : \"" + row[17].ToString() + "\" , \"folioAsociado\" : \"" + row[18].ToString() + "\", \"comentario\" : \"" + row[19].ToString() + "\", \"fixingDate\" : \"" + row[20].ToString() + "\", \"fechaAnticipo\" : \"" + row[21].ToString() + "\", \"tasaAnticipo\" : \"" + row[22].ToString() + "\", \"recibimosPagamos\" : \"" + reemplazarSeparadorMiles(row[23].ToString()) + "\", \"monedaAnticipo\" : \"" + reemplazarSeparadorMiles(row[24].ToString()) + "\" },";
                                        indexaux++;
                                    }
                                }
                                i++;
                            }
                            if (contenido.Length <= 1 && contenido == "[")
                            {
                                if (LblMensajeBlotter.Text != "Cabecera de archivo incorrecta.")
                                {
                                    contenido = "[]";
                                    LblMensajeBlotter.Text = "Archivo no contiene la fecha indicada";
                                    valida = 1;
                                   
                                }
                            }
                            else { 
                                contenido = contenido.Substring(0, contenido.Length - 1);
                                contenido = contenido + "]";
                            }

                            if (i == 0 || i == -1)
                            {
                                if (i == 0)
                                {
                                    LblMensajeBlotter.Text = "Archivo vacio";
                                }

                            }
                            else
                            {
                                if (valida == 0)
                                {
                                    LblMensajeBlotter.Text = "Archivo cargado correctamente";

                                    jSonBlotter.Value = contenido;
                                }
                             }
                            }
                        }
                    
                    File.Delete(filePath);

                }
                else
                {
                    LblMensajeBlotter.Text = "Archivo con formato incorrecto";
                }
            }
            else
            {
                LblMensajeBlotter.Text = "No ha cargado archivo o ingresado fecha";
            }
        }
        catch
        {
            LblMensajeBlotter.Text = "Archivo con formato incorrecto o datos erroneos";
        }
        }


    public string reemplazarSeparadorMiles(String numero)
    {
        numero = numero.Replace(".", "_");
        numero = numero.Replace(",", ".");
        numero = numero.Replace("_", ",");
        return numero;

    }
}
