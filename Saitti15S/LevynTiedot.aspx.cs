﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LevynTiedot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        srcLevyt.XPath = "Records/genre/record[@ISBN='" + Request.QueryString["ISBN"] + "']";
        srcBiisit.XPath = "Records/genre/record[@ISBN='" + Request.QueryString["ISBN"] + "']/song";
    }
}