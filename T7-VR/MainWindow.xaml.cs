using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace T7_VR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string json = "";
        public List<Asema> asematiedot = new List<Asema>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateComboboxWithTrainData();
        }

        private void PopulateComboboxWithTrainData()
        {
            try
            {
                string url = string.Format("http://rata.digitraffic.fi/api/v1/metadata/station");
                using (WebClient wc = new WebClient())
                {
                    var retval = wc.DownloadString(url);
                    this.asematiedot = JsonConvert.DeserializeObject<List<Asema>>(retval);

                    foreach (var station in this.asematiedot)
                    {
                        cmbStations.Items.Add(station.AsemanNimi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string GetTrainsJson(string station = "")
        {
            try
            {
                string valittuAsema = "";

                // Käydään kaikki asemat läpi
                foreach (var asema in this.asematiedot)
                {
                    // Jos aseman nimi = valittu asema, haetaan ko. aseman koodi
                    if (asema.AsemanNimi == station)
                    {
                        valittuAsema = asema.AsemanKoodi;
                    }
                }

                // Haetaan valitun aseman data
                string url = string.Format("http://rata.digitraffic.fi/api/v1/live-trains?station=" + valittuAsema);
                using (WebClient wc = new WebClient())
                {
                    var retval = wc.DownloadString(url);
                    return retval;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGetTrainData_Click(object sender, RoutedEventArgs e)
        {
            string junatStr = "";

            if (cmbStations.SelectedIndex == -1)
            {
                MessageBox.Show("Valitse joku asema.");
            }
            else
            {
                junatStr = GetTrainsJson(cmbStations.SelectedItem.ToString());

                List<Juna> junat = JsonConvert.DeserializeObject<List<Juna>>(junatStr);
                dgData.DataContext = junat;
            }
        }
    }
}
