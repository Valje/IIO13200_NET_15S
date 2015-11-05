using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // jos sivu ok, niin kirjoitetaan käyttäjänimi sessioon ja siirrytään index-sivulle
        if (Page.IsValid)
        {
            Session["user"] = tbName.Text;
            Server.Transfer("indexMP.aspx");
        }
    }
}