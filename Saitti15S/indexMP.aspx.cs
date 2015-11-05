using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class indexMP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // tutkitaan onko sessionissa tallessa user ja jos on niin näytetään
        if (Session["user"] != null)
        {
            lbllHello.Text = "Terve, " + Session["user"].ToString();
        }
    }
}