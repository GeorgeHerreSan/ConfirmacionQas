using NetSqlAzMan;
using NetSqlAzMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool AmbienteDesarrollo = bool.Parse(ConfigurationManager.AppSettings["Ambiente:Desarrollo"].ToString());

        if (AmbienteDesarrollo)
        {

        }
        else
        {
            NombreUsuario.InnerText = this.Request.LogonUserIdentity.Name.ToString();




            string cs = ConfigurationManager.ConnectionStrings["NetSqlAzMan"].ConnectionString;
            IAzManStorage storage = new SqlAzManStorage(cs);
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();

            string AppConfirmaOperaciones = ConfigurationManager.AppSettings["App_NetSqlAzMan_ConfirmacionOperaciones"].ToString();
            string AppMantenedorContratos = ConfigurationManager.AppSettings["App_NetSqlAzMan_MantenedorContratos"].ToString();
            string Store = ConfigurationManager.AppSettings["Store_NetSqlAzMan"].ToString();

            //Valida acceso a confirmación de Operaciones.
            if (!storage.Stores[Store].GetApplication(AppConfirmaOperaciones).ApplicationGroups["Usuarios"].IsInGroup(this.Request.LogonUserIdentity))
            {
                //Response.Redirect("PaginaError.aspx");

                //liOperacionesDelDia.Visible = false;
                //liConsultar.Visible = false;
                liListaDistribucion.Visible = false;
                liMantenedorCorreos.Visible = false;
                divAlertas.Visible = false;
                tabs1.Visible = false;
                tabs2.Visible = false;
                //tabs3.Visible = false;
                //tabs4.Visible = false;
            }

            //Valida Acceso a Mantenedor de Contratos.
            if (!storage.Stores[Store].GetApplication(AppMantenedorContratos).ApplicationGroups["Usuarios"].IsInGroup(this.Request.LogonUserIdentity))
            {
                liContratos.Visible = false;
                tabs5.Visible = false;
            }
            else
            {
                //valida tipo de Usuario
                string validaConsultar = storage.CheckAccess(Store, AppMantenedorContratos, "Consultar", this.Request.LogonUserIdentity, DateTime.Now, false).ToString();
                if (validaConsultar == "AllowWithDelegation")
                {
                    tipoUsuario.Value = "Consulta";
                }
                string validamantenedor = storage.CheckAccess(Store, AppMantenedorContratos, "Mantenedor", this.Request.LogonUserIdentity, DateTime.Now, false).ToString();
                if (validamantenedor == "AllowWithDelegation")
                {
                    tipoUsuario.Value = "Mantenedor";
                }
            }
        }
    }


}
