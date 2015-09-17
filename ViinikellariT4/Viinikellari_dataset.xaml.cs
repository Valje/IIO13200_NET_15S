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
using System.Windows.Shapes;

namespace ViinikellariT4
{
    /// <summary>
    /// Interaction logic for Viinikellari_dataset.xaml
    /// </summary>
    public partial class Viinikellari_dataset : Window
    {

        List<string> maat;
        DataSet ds;
        DataTable dt;
        DataView dv;

        public Viinikellari_dataset()
        {
            InitializeComponent();
            
        }

        private void btnSearchWines_Click(object sender, RoutedEventArgs e)
        {
            // luetaan koko XML DataSettiin
            // DataSet in-memory database
            try
            {
                string file = @"D:\H3340\Viinit1.xml";
                ds = new DataSet();
                dt = new DataTable();
                dv = new DataView();
                ds.ReadXml(file);
                dt = ds.Tables[0]; // voisi viitata myös taulun nimellä. nyt satutaan tietämään että tiedostossa on vain yksi taulu
                dv = dt.DefaultView;
                dgWines.ItemsSource = dv;

                // haetaan maat comboon
                maat = new List<string>();
                dv.ToTable("UniqueData", false, "maa");

                
            }
            catch (Exception ex)
            {
                throw;
            }
            

        }

        private void dgWines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                // Asetetaan filter combolle
                dv.RowFilter = "maa LIKE " + cmbMaat.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
