using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
//using System.Xml;

namespace T8Palaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        DataSet ds;
        DataTable dt;
        DataView dv;

        public MainWindow()
        {
            InitializeComponent();
            // Täytetään aikalaatikko
            DateTime time = DateTime.Now;

            // esitäytetään pvm
            string timestr = "" + time.Year + time.Month + time.Day;
            //tbDate.Text = time.ToShortDateString();
            tbDate.Text = timestr;
        }

        public void OpenXMLFile()
        {
            // luetaan koko XML DataSettiin
            // DataSet in-memory database
            try
            {
                string file = T8Palaute.Properties.Settings.Default.local;
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



        public bool SanityCheck(string input)
        {
            // Tarkistaa, että syötteessä on jotain
            return (input != "");
        }


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            List<string> palautteet = new List<string>();

            palautteet.Add(tbName.Text.ToString());
            palautteet.Add(tbDate.Text.ToString());
            palautteet.Add(tbLearned.Text.ToString());
            palautteet.Add(tbWantToLearn.Text.ToString());
            palautteet.Add(tbGood.Text.ToString());
            palautteet.Add(tbImprovements.Text.ToString());
            palautteet.Add(tbOthers.Text.ToString());

            foreach (var tbValue in palautteet)
            {
                if (!SanityCheck(tbValue))
                {
                    MessageBox.Show("Täytä kaikki kentät!");
                    return;
                }
            }

            Feedback palaute = new Feedback(
                tbName.Text.ToString(),
                tbDate.Text.ToString(),
                tbLearned.Text.ToString(),
                tbWantToLearn.Text.ToString(),
                tbGood.Text.ToString(),
                tbImprovements.Text.ToString(),
                tbOthers.Text.ToString()
                );

            WriteXMLFile(palaute);

            MessageBox.Show("Done.");

        }

        private void btnGetFeedbacks_Click(object sender, RoutedEventArgs e)
        {
            Inspection a = new Inspection();
            a.ShowDialog();
            OpenXMLFile();
        }
    }
}
