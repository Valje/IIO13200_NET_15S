using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class palautekysely : System.Web.UI.Page
{

    DataSet ds;
    DataTable dt;
    DataView dv;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void OpenXMLFile()
    {
        // luetaan koko XML DataSettiin
        // DataSet in-memory database
        try
        {
            string file = @"D:\H3340\1.xml";
            ds = new DataSet();
            dt = new DataTable();
            dv = new DataView();
            ds.ReadXml(file);
            dt = ds.Tables[0]; // voisi viitata myös taulun nimellä. nyt satutaan tietämään että tiedostossa on vain yksi taulu
            dv = dt.DefaultView;

            //MessageBox.Show(ds.GetXml());

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void WriteXMLFile(Feedback palis)
    {
        /*
        using (XmlWriter writer = XmlWriter.Create(@"D:\H3340\1.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Palaute");
            writer.WriteElementString("pvm", palis.Date);
            writer.WriteElementString("tekija", palis.Name);
            writer.WriteElementString("opittu", palis.Learned);
            writer.WriteElementString("haluanoppia", palis.WantToLearn);
            writer.WriteElementString("hyvaa", palis.Good);
            writer.WriteElementString("parannettavaa", palis.Improvements);
            writer.WriteElementString("muuta", palis.Others);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        */

        XDocument doc = XDocument.Load(@"D:\H3340\1.xml"); //Tähän T8Palaute.Properties.Settings.Default.yhteys (app.configista) niin menee sit ghostille
        XElement palautteet = doc.Element("palautteet");
        palautteet.Add(new XElement("palaute",
                   new XElement("pvm", palis.Date),
                   new XElement("tekija", palis.Name),
                   new XElement("opittu", palis.Learned),
                   new XElement("haluanoppia", palis.WantToLearn),
                   new XElement("hyvaa", palis.Good),
                   new XElement("parannettavaa", palis.Improvements),
                   new XElement("muuta", palis.Others)));
        doc.Save(@"D:\H3340\1.xml");
    }


    protected void btnLaheta_Click(object sender, EventArgs e)
    {
        List<string> palautteet = new List<string>();

        Feedback palaute = new Feedback(
            tbNimi.Text.ToString(),
            Calendar1.SelectedDate.ToString(),
            tbOlenOppinut.Text.ToString(),
            tbHaluaisinOppia.Text.ToString(),
            tbHyvaa.Text.ToString(),
            tbHuonoa.Text.ToString(),
            tbMuuta.Text.ToString()
            );

        WriteXMLFile(palaute);
    }
}