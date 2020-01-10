using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class formulario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int folio = Convert.ToInt32(Request.QueryString["folio"].ToString());
        Label1.Text = "Confirmación de operación "+folio;
        folid.Value = folio.ToString();
    }

    protected void btnsi_Click(object sender, EventArgs e)
    {

        //WizardStep ws = new ws
        //ws.

    }
}
