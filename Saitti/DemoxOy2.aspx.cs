using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DemoxOy2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ladataan asiakastiedot kannasta
        GetRealData();
    }

    protected void GetDemoData()
    {
        // täytetään GridView
        DataTable dt = JAMK.IT.DBDemoxOy2.GetDataSimple();
        gvCustomers2.DataSource = dt;
        gvCustomers2.DataBind();
    }

    protected void GetRealData()
    {
        try
        {
            DataTable dt = JAMK.IT.DBDemoxOy2.GetDataReal();
            gvCustomers2.DataSource = dt;
            gvCustomers2.DataBind();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}