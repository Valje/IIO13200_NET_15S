using System;
using System.Collections.Generic;
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

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;

namespace DemoJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods

        private void Demo1()
        {
            // Haetaan JSON
            json = GetSimpleJson();

            // Muunnetaan se olioiksi
            List<Person> persoonat = JsonConvert.DeserializeObject<List<Person>>(this.json);

            // Näytetään UI:ssa
            tbJson.Text = json;
            dgData.DataContext = persoonat;

        }

        private void Demo2()
        {
            // Haetaan JSON netistä
            json = GetRealJson();

            // Muunnetaan se olioiksi
            List<Politic> persoonat = JsonConvert.DeserializeObject<List<Politic>>(this.json);

            // Näytetään UI:ssa
            tbJson.Text = json;
            dgData.DataContext = persoonat;

        }

        // Tällä käyttöliittymän ei pitäisi odottaa.
        private void Demo2Async()
        {
            new Thread(() =>
            {
                string result = GetRealJson();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    tbJson.Text = result;
                    List<Politic> persoonat = JsonConvert.DeserializeObject<List<Politic>>(result);
                    dgData.DataContext = persoonat;
                }));
            }).Start();
        }

        private string GetSimpleJson()
        {
            return @"[
                    {'Name':'Olli Opiskelija','Gender':'Male','Birthday':'1995-12-24'},
                    {'Name':'Matti Mainio','Gender':'Male','Birthday':'1985-12-25'}
                    ]";
        }

        private string GetRealJson()
        {
            try
            {
                /**
                WebClient client = new WebClient();
                //return File.ReadAllText("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
                return client.DownloadString("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
                */

                string url = string.Format("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
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

        #endregion

        private void btnGetJson_Click(object sender, RoutedEventArgs e)
        {
            Demo2Async();
        }
    }
}
